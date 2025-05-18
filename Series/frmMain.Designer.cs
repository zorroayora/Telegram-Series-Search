namespace Series
{
    partial class frmMain
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnClose = new AltoControls.AltoButton();
            this.btnMinimized = new AltoControls.AltoButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtFiltroNombre = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnResetFiltro = new AltoControls.AltoButton();
            this.listView1 = new System.Windows.Forms.ListView();
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFecha = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSerie = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIdioma = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSubtitulos = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTemporada = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEpisodios = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEnlace = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.SystemColors.Control;
            this.panelTitleBar.Controls.Add(this.picLogo);
            this.panelTitleBar.Controls.Add(this.btnClose);
            this.panelTitleBar.Controls.Add(this.btnMinimized);
            this.panelTitleBar.Controls.Add(this.lblTitle);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(0, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(969, 104);
            this.panelTitleBar.TabIndex = 16;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // picLogo
            // 
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(60, 0);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(125, 94);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 27;
            this.picLogo.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btnClose.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(188)))), ((int)(((byte)(210)))));
            this.btnClose.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btnClose.Location = new System.Drawing.Point(900, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Radius = 10;
            this.btnClose.Size = new System.Drawing.Size(24, 24);
            this.btnClose.Stroke = false;
            this.btnClose.StrokeColor = System.Drawing.Color.Gray;
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "X";
            this.btnClose.Transparency = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMinimized
            // 
            this.btnMinimized.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btnMinimized.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btnMinimized.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimized.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnMinimized.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnMinimized.ForeColor = System.Drawing.Color.White;
            this.btnMinimized.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(188)))), ((int)(((byte)(210)))));
            this.btnMinimized.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btnMinimized.Location = new System.Drawing.Point(865, 15);
            this.btnMinimized.Name = "btnMinimized";
            this.btnMinimized.Radius = 10;
            this.btnMinimized.Size = new System.Drawing.Size(24, 24);
            this.btnMinimized.Stroke = false;
            this.btnMinimized.StrokeColor = System.Drawing.Color.Gray;
            this.btnMinimized.TabIndex = 3;
            this.btnMinimized.Text = "_";
            this.btnMinimized.Transparency = false;
            this.btnMinimized.Click += new System.EventHandler(this.btnMinimized_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitle.Location = new System.Drawing.Point(200, 28);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(359, 26);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Telegram Series Groups Search  v.1.1.0";
            // 
            // txtFiltroNombre
            // 
            this.txtFiltroNombre.Location = new System.Drawing.Point(518, 72);
            this.txtFiltroNombre.Name = "txtFiltroNombre";
            this.txtFiltroNombre.Size = new System.Drawing.Size(190, 20);
            this.txtFiltroNombre.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(463, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 20);
            this.label10.TabIndex = 28;
            this.label10.Text = "Filtro: ";
            // 
            // btnResetFiltro
            // 
            this.btnResetFiltro.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btnResetFiltro.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btnResetFiltro.BackColor = System.Drawing.Color.Transparent;
            this.btnResetFiltro.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnResetFiltro.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnResetFiltro.ForeColor = System.Drawing.Color.Black;
            this.btnResetFiltro.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(188)))), ((int)(((byte)(210)))));
            this.btnResetFiltro.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btnResetFiltro.Location = new System.Drawing.Point(733, 65);
            this.btnResetFiltro.Name = "btnResetFiltro";
            this.btnResetFiltro.Radius = 10;
            this.btnResetFiltro.Size = new System.Drawing.Size(110, 30);
            this.btnResetFiltro.Stroke = false;
            this.btnResetFiltro.StrokeColor = System.Drawing.Color.Gray;
            this.btnResetFiltro.TabIndex = 27;
            this.btnResetFiltro.Text = "Reset Filtro";
            this.btnResetFiltro.Transparency = false;
            this.btnResetFiltro.Click += new System.EventHandler(this.btnResetFiltro_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colFecha,
            this.colSerie,
            this.colIdioma,
            this.colSubtitulos,
            this.colTemporada,
            this.colEpisodios,
            this.colEnlace});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(45, 110);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(870, 540);
            this.listView1.TabIndex = 26;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // colID
            // 
            this.colID.Text = "ID";
            this.colID.Width = 40;
            // 
            // colFecha
            // 
            this.colFecha.Text = "Fecha";
            this.colFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colFecha.Width = 75;
            // 
            // colSerie
            // 
            this.colSerie.Text = "Serie";
            this.colSerie.Width = 250;
            // 
            // colIdioma
            // 
            this.colIdioma.DisplayIndex = 5;
            this.colIdioma.Text = "Idioma";
            this.colIdioma.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colIdioma.Width = 65;
            // 
            // colSubtitulos
            // 
            this.colSubtitulos.DisplayIndex = 6;
            this.colSubtitulos.Text = "Subs";
            this.colSubtitulos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colSubtitulos.Width = 65;
            // 
            // colTemporada
            // 
            this.colTemporada.DisplayIndex = 3;
            this.colTemporada.Text = "Temp.";
            this.colTemporada.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colTemporada.Width = 70;
            // 
            // colEpisodios
            // 
            this.colEpisodios.DisplayIndex = 4;
            this.colEpisodios.Text = "Episodios";
            this.colEpisodios.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colEpisodios.Width = 70;
            // 
            // colEnlace
            // 
            this.colEnlace.Text = "Enlace";
            this.colEnlace.Width = 210;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(648, 660);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 23);
            this.label1.TabIndex = 28;
            this.label1.Text = "rafael.camara.martinez@gmail.com";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(82, 660);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 23);
            this.label2.TabIndex = 30;
            this.label2.Text = "Developed by @zorro48";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 696);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFiltroNombre);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnResetFiltro);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.panelTitleBar);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "     Audio-Video Converter";
            this.Activated += new System.EventHandler(this.frmMain_Activated);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResizeEnd += new System.EventHandler(this.frmMain_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.frmMain_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmMain_Paint);
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label lblTitle;
        private AltoControls.AltoButton btnClose;
        private AltoControls.AltoButton btnMinimized;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.TextBox txtFiltroNombre;
        private System.Windows.Forms.Label label10;
        private AltoControls.AltoButton btnResetFiltro;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colFecha;
        private System.Windows.Forms.ColumnHeader colSerie;
        private System.Windows.Forms.ColumnHeader colIdioma;
        private System.Windows.Forms.ColumnHeader colSubtitulos;
        private System.Windows.Forms.ColumnHeader colTemporada;
        private System.Windows.Forms.ColumnHeader colEpisodios;
        private System.Windows.Forms.ColumnHeader colEnlace;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

