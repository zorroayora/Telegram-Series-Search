using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

using SortOrder = System.Windows.Forms.SortOrder;

namespace Series
{
    public partial class frmMain : Form
    {
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

        private int columnaOrdenActual = -1;
        private bool ascendente = true;
        private IComparer lvwColumnSorter;
        private SortOrder orderOfSort;
        private int columnToSort;

        private List<Serie> listaSeries = new List<Serie>();
        private string watermark = ""; //"Buscar serie...";
        private Color watermarkColor = Color.Gray;
        private Color normalColor = Color.Black;

        #region Properties

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private int borderRadius = 30;
        private int borderSize = 2;
        private Color borderColor = Color.FromArgb(255, 255, 255);

        #endregion

        #region Forms

        public frmMain()
        {
            InitializeComponent();

            InicializarListView();
            InicializarWatermarkFiltro();

            Control.CheckForIllegalCrossThreadCalls = true;

            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.panelTitleBar.BackColor = borderColor;
            this.panelTitleBar.ForeColor = Color.White;
            this.BackColor = borderColor;
            this.ForeColor = Color.MediumPurple;

            listView1.OwnerDraw = true;
            listView1.DrawColumnHeader += listView1_DrawColumnHeader;
            listView1.DrawItem += listView1_DrawItem;
            listView1.DrawSubItem += listView1_DrawSubItem;
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void frmMain_ResizeEnd(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        #endregion

        #region Methods

        private void ApplicationOnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            string message = String.Format("Sorry, something went wrong.\r\n{0}\r\nPlease contact support.", e.Exception.Message);

            Console.WriteLine("ERROR {0}: {1}", DateTimeOffset.Now, e.Exception);

            MessageBox.Show(message, "Unexpected Error");
        }

        private void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string message = String.Format("Sorry, something went wrong.\r\n{0}\r\nPlease contact support.", e.ExceptionObject);

            Console.WriteLine("ERROR {0}: {1}", DateTimeOffset.Now, e.ExceptionObject);

            MessageBox.Show(message, "Unexpected Error");
        }

        private void DrawPath(Rectangle rect, Graphics graph, Color color)
        {
            using (GraphicsPath roundPath = GetRoundedPath(rect, borderRadius))

            using (Pen penBorder = new Pen(color, 3))
            {
                graph.DrawPath(penBorder, roundPath);
            }
        }

        private void FormRegionAndBorder(Form form, float radius, Graphics graph, Color borderColor, float borderSize)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                using (GraphicsPath roundPath = GetRoundedPath(form.ClientRectangle, radius))
                using (Pen penBorder = new Pen(borderColor, borderSize))

                using (Matrix transform = new Matrix())
                {
                    graph.SmoothingMode = SmoothingMode.AntiAlias;

                    form.Region = new Region(roundPath);

                    if (borderSize >= 1)
                    {
                        Rectangle rect = form.ClientRectangle;

                        float scaleX = 1.0F - ((borderSize + 1) / rect.Width);
                        float scaleY = 1.0F - ((borderSize + 1) / rect.Height);

                        transform.Scale(scaleX, scaleY);
                        transform.Translate(borderSize / 1.6F, borderSize / 1.6F);

                        graph.Transform = transform;
                        graph.DrawPath(penBorder, roundPath);
                    }
                }
            }
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();

            float curveSize = radius * 2F;

            path.StartFigure();

            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);

            path.CloseFigure();

            return path;
        }

        public string RemoveMulitWhite(string Input)
        {
            System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex("[ ]{2,}", RegexOptions.Multiline);
            string result = regex1.Replace(Input, " ");

            return result;
        }

        #endregion

        #region TabControl

        #region TabYoutube

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnMinimized_Click(object sender, System.EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
            }
        }

        #endregion

        #region TabConverter


        #endregion

        #endregion

        private void frmMain_Load(object sender, EventArgs e)
        {
            SetWatermark();

            CargarSeries();
        }

        private void CargarSeries()
        {
            listaSeries.Clear();

            DataSet ds = new DataSet();
            ds.ReadXml("series_info.xml");

            DataTable tabla = ds.Tables["series_info"];

            foreach (DataRow row in tabla.Rows)
            {
                listaSeries.Add(new Serie
                {
                    Id = int.Parse(row["id"].ToString()),
                    Fecha = DateTime.Parse(row["fecha"].ToString()),
                    SerieNombre = row["serie"].ToString(),
                    Idioma = row["idioma"].ToString(),
                    Subtitulo = row["subtitulo"].ToString(),
                    Temporada = int.Parse(row["temporada"].ToString()),
                    Episodios = int.Parse(row["episodios"].ToString()),
                    Enlace = row["enlace"].ToString()
                });
            }

            MostrarSeriesEnListView(listaSeries);
        }

        private void MostrarSeriesEnListView(List<Serie> lista)
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();

            foreach (var s in lista)
            {
                var item = new ListViewItem(s.Id.ToString());
                item.SubItems.Add(s.Fecha.ToString("yyyy-MM-dd"));
                item.SubItems.Add(s.SerieNombre);
                item.SubItems.Add(s.Idioma);
                item.SubItems.Add(s.Subtitulo.ToString());
                item.SubItems.Add(s.Temporada.ToString());
                item.SubItems.Add(s.Episodios.ToString());
                item.SubItems.Add(s.Enlace);

                listView1.Items.Add(item);
            }

            listView1.EndUpdate();
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == columnaOrdenActual)
                ascendente = !ascendente;
            else
                ascendente = true;

            columnaOrdenActual = e.Column;
            listView1.ListViewItemSorter = new ListViewItemComparer(e.Column, ascendente);
            listView1.Sort();

            // *** Forzar redibujado real del header ***
            const int LVM_GETHEADER = 0x101F;
            IntPtr header = SendMessage(listView1.Handle, LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero);
            InvalidateRect(header, IntPtr.Zero, true);
        }

        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawBackground();

            string txt = e.Header.Text;

            if (e.ColumnIndex == columnaOrdenActual)
                txt += ascendente ? " ▲" : " ▼";

            TextRenderer.DrawText(e.Graphics, txt, e.Font, e.Bounds, e.ForeColor);
        }

        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            if ((e.State & ListViewItemStates.Selected) != 0)
                e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
            else
                e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);

            e.DrawDefault = true;
        }

        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if ((e.ItemState & ListViewItemStates.Selected) != 0)
                e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
            else
                e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);

            e.DrawDefault = true;
        }

        private void MostrarEnListView(List<Serie> lista)
        {
            listView1.Items.Clear();

            foreach (var serie in lista)
            {
                var item = new ListViewItem(serie.Id.ToString());
                item.SubItems.Add(serie.Fecha.ToString("yyyy-MM-dd")); // Convert DateTime to string
                item.SubItems.Add(serie.SerieNombre);
                item.SubItems.Add(serie.Idioma);
                item.SubItems.Add(serie.Subtitulo.ToString());
                item.SubItems.Add(serie.Temporada.ToString());
                item.SubItems.Add(serie.Episodios.ToString());
                item.SubItems.Add(serie.Enlace);

                listView1.Items.Add(item);
            }
        }

        private void InicializarListView()
        {
            listView1.View = View.Details;
            listView1.Columns.Clear();
            listView1.Columns.Add("ID", 40, HorizontalAlignment.Right);
            listView1.Columns.Add("Fecha", 70, HorizontalAlignment.Center);
            listView1.Columns.Add("Serie", 270, HorizontalAlignment.Left);
            listView1.Columns.Add("Idioma", 65, HorizontalAlignment.Left);
            listView1.Columns.Add("Subtitulo", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Temporada", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Episodios", 70, HorizontalAlignment.Right);
            listView1.Columns.Add("Enlace", 210);

            listView1.FullRowSelect = true;
            listView1.MultiSelect = false;
        }

        private void InicializarWatermarkFiltro()
        {
            txtFiltroNombre.ForeColor = watermarkColor;
            txtFiltroNombre.Text = watermark;
            txtFiltroNombre.Enter += (s, e) =>
            {
                if (txtFiltroNombre.Text == watermark)
                {
                    txtFiltroNombre.Text = "";
                    txtFiltroNombre.ForeColor = normalColor;
                }
            };

            txtFiltroNombre.Leave += (s, e) => SetWatermark();
            txtFiltroNombre.TextChanged += txtFiltroNombre_TextChanged;
        }

        private void SetWatermark()
        {
            txtFiltroNombre.Text = watermark;
            txtFiltroNombre.ForeColor = watermarkColor;
        }

        private void txtFiltroNombre_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtFiltroNombre.Text;

            if (filtro == watermark || string.IsNullOrWhiteSpace(filtro))
            {
                MostrarSeriesEnListView(listaSeries);

                return;
            }

            filtro = filtro.Trim().ToLower();

            var filtradas = listaSeries
                .Where(s => s.SerieNombre.ToLower().Contains(filtro))
                .ToList();

            MostrarSeriesEnListView(filtradas);
        }

        private void btnResetFiltro_Click(object sender, EventArgs e)
        {
            txtFiltroNombre.Text = "";
            txtFiltroNombre.Focus();

            ResetData();

            MostrarSeriesEnListView(listaSeries);
        }

        private void ResetData()
        {
            txtFiltroNombre.Text = watermark;
            listView1.SelectedItems.Clear();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo hitTestInfo = listView1.HitTest(e.Location);

            if (hitTestInfo.Item != null && hitTestInfo.SubItem != null)
            {
                if (!hitTestInfo.SubItem.Text.StartsWith("https://t.me/"))
                    return;

                string url = hitTestInfo.SubItem.Text; // Suponiendo que el subitem contiene la URL
                try
                {
                    System.Diagnostics.Process.Start(new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al abrir el enlace: " + ex.Message);
                }
            }
        }
    }

    public class ListViewItemComparer : System.Collections.IComparer
    {
        private int col;
        private bool ascendente;

        public ListViewItemComparer(int column, bool asc)
        {
            col = column;
            ascendente = asc;
        }

        public int Compare(object x, object y)
        {
            string valX = ((ListViewItem)x).SubItems[col].Text;
            string valY = ((ListViewItem)y).SubItems[col].Text;

            decimal numX, numY;

            bool isNumX = decimal.TryParse(valX, out numX);
            bool isNumY = decimal.TryParse(valY, out numY);

            int resultado;
            if (isNumX && isNumY)
                resultado = decimal.Compare(numX, numY);
            else
                resultado = string.Compare(valX, valY);

            return ascendente ? resultado : -resultado;
        }
    }

    public class Serie
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string SerieNombre { get; set; }
        public string Idioma { get; set; }
        public string Subtitulo { get; set; }
        public int Temporada { get; set; }
        public int Episodios { get; set; }
        public string Enlace { get; set; }
    }
}