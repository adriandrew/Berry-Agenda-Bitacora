namespace Escritorio
{
    partial class PanelControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelControl));
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.spSubProgramas = new FarPoint.Win.Spread.FpSpread();
            this.spSubProgramas_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.spProgramas = new FarPoint.Win.Spread.FpSpread();
            this.spProgramas_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlPie = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.cbEmpresas = new System.Windows.Forms.ComboBox();
            this.spAdministrar = new FarPoint.Win.Spread.FpSpread();
            this.spAdministrar_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.rbtnProgramas = new System.Windows.Forms.RadioButton();
            this.rbtnEmpresas = new System.Windows.Forms.RadioButton();
            this.rbtnUsuarios = new System.Windows.Forms.RadioButton();
            this.pnlContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spSubProgramas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spSubProgramas_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spProgramas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spProgramas_Sheet1)).BeginInit();
            this.pnlPie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spAdministrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spAdministrar_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContenido
            // 
            this.pnlContenido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContenido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlContenido.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlContenido.BackgroundImage")));
            this.pnlContenido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlContenido.Controls.Add(this.spSubProgramas);
            this.pnlContenido.Controls.Add(this.spProgramas);
            this.pnlContenido.Controls.Add(this.pnlPie);
            this.pnlContenido.Controls.Add(this.cbEmpresas);
            this.pnlContenido.Controls.Add(this.spAdministrar);
            this.pnlContenido.Controls.Add(this.rbtnProgramas);
            this.pnlContenido.Controls.Add(this.rbtnEmpresas);
            this.pnlContenido.Controls.Add(this.rbtnUsuarios);
            this.pnlContenido.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlContenido.Location = new System.Drawing.Point(0, 1);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(1035, 549);
            this.pnlContenido.TabIndex = 2;
            // 
            // spSubProgramas
            // 
            this.spSubProgramas.AccessibleDescription = "";
            this.spSubProgramas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spSubProgramas.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spSubProgramas.Location = new System.Drawing.Point(653, 273);
            this.spSubProgramas.Name = "spSubProgramas";
            this.spSubProgramas.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spSubProgramas_Sheet1});
            this.spSubProgramas.Size = new System.Drawing.Size(370, 207);
            this.spSubProgramas.TabIndex = 11;
            this.spSubProgramas.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spSubProgramas.Visible = false;
            // 
            // spSubProgramas_Sheet1
            // 
            this.spSubProgramas_Sheet1.Reset();
            spSubProgramas_Sheet1.SheetName = "Sheet1";
            // 
            // spProgramas
            // 
            this.spProgramas.AccessibleDescription = "";
            this.spProgramas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.spProgramas.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spProgramas.Location = new System.Drawing.Point(273, 273);
            this.spProgramas.Name = "spProgramas";
            this.spProgramas.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spProgramas_Sheet1});
            this.spProgramas.Size = new System.Drawing.Size(370, 207);
            this.spProgramas.TabIndex = 10;
            this.spProgramas.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spProgramas.Visible = false;
            this.spProgramas.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spProgramas_CellClick);
            // 
            // spProgramas_Sheet1
            // 
            this.spProgramas_Sheet1.Reset();
            spProgramas_Sheet1.SheetName = "Sheet1";
            // 
            // pnlPie
            // 
            this.pnlPie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPie.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.pnlPie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPie.Controls.Add(this.btnSalir);
            this.pnlPie.Location = new System.Drawing.Point(0, 486);
            this.pnlPie.Name = "pnlPie";
            this.pnlPie.Size = new System.Drawing.Size(1035, 60);
            this.pnlPie.TabIndex = 9;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.White;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(973, -1);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(0);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 60);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // cbEmpresas
            // 
            this.cbEmpresas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEmpresas.FormattingEnabled = true;
            this.cbEmpresas.Location = new System.Drawing.Point(12, 124);
            this.cbEmpresas.Name = "cbEmpresas";
            this.cbEmpresas.Size = new System.Drawing.Size(255, 28);
            this.cbEmpresas.TabIndex = 4;
            this.cbEmpresas.Visible = false;
            this.cbEmpresas.SelectedIndexChanged += new System.EventHandler(this.cbEmpresas_SelectedIndexChanged);
            // 
            // spAdministrar
            // 
            this.spAdministrar.AccessibleDescription = "";
            this.spAdministrar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spAdministrar.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spAdministrar.Location = new System.Drawing.Point(273, 11);
            this.spAdministrar.Name = "spAdministrar";
            this.spAdministrar.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spAdministrar_Sheet1});
            this.spAdministrar.Size = new System.Drawing.Size(750, 256);
            this.spAdministrar.TabIndex = 3;
            this.spAdministrar.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spAdministrar.Visible = false;
            this.spAdministrar.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spAdministrar_CellDoubleClick);
            this.spAdministrar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.spAdministrar_KeyDown);
            // 
            // spAdministrar_Sheet1
            // 
            this.spAdministrar_Sheet1.Reset();
            spAdministrar_Sheet1.SheetName = "Sheet1";
            // 
            // rbtnProgramas
            // 
            this.rbtnProgramas.AutoSize = true;
            this.rbtnProgramas.ForeColor = System.Drawing.Color.White;
            this.rbtnProgramas.Location = new System.Drawing.Point(12, 79);
            this.rbtnProgramas.Name = "rbtnProgramas";
            this.rbtnProgramas.Size = new System.Drawing.Size(119, 28);
            this.rbtnProgramas.TabIndex = 2;
            this.rbtnProgramas.TabStop = true;
            this.rbtnProgramas.Text = "Programas";
            this.rbtnProgramas.UseVisualStyleBackColor = true;
            // 
            // rbtnEmpresas
            // 
            this.rbtnEmpresas.AutoSize = true;
            this.rbtnEmpresas.ForeColor = System.Drawing.Color.White;
            this.rbtnEmpresas.Location = new System.Drawing.Point(12, 45);
            this.rbtnEmpresas.Name = "rbtnEmpresas";
            this.rbtnEmpresas.Size = new System.Drawing.Size(113, 28);
            this.rbtnEmpresas.TabIndex = 1;
            this.rbtnEmpresas.TabStop = true;
            this.rbtnEmpresas.Text = "Empresas";
            this.rbtnEmpresas.UseVisualStyleBackColor = true;
            this.rbtnEmpresas.CheckedChanged += new System.EventHandler(this.rbtnEmpresas_CheckedChanged);
            // 
            // rbtnUsuarios
            // 
            this.rbtnUsuarios.AutoSize = true;
            this.rbtnUsuarios.ForeColor = System.Drawing.Color.White;
            this.rbtnUsuarios.Location = new System.Drawing.Point(12, 11);
            this.rbtnUsuarios.Name = "rbtnUsuarios";
            this.rbtnUsuarios.Size = new System.Drawing.Size(101, 28);
            this.rbtnUsuarios.TabIndex = 0;
            this.rbtnUsuarios.TabStop = true;
            this.rbtnUsuarios.Text = "Usuarios";
            this.rbtnUsuarios.UseVisualStyleBackColor = true;
            this.rbtnUsuarios.CheckedChanged += new System.EventHandler(this.rbtnUsuarios_CheckedChanged);
            // 
            // PanelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 547);
            this.Controls.Add(this.pnlContenido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PanelControl";
            this.Text = "Panel de Control";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PanelControl_FormClosed);
            this.Load += new System.EventHandler(this.PanelControl_Load);
            this.Shown += new System.EventHandler(this.PanelControl_Shown);
            this.pnlContenido.ResumeLayout(false);
            this.pnlContenido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spSubProgramas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spSubProgramas_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spProgramas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spProgramas_Sheet1)).EndInit();
            this.pnlPie.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spAdministrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spAdministrar_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContenido;
        private FarPoint.Win.Spread.FpSpread spAdministrar;
        private FarPoint.Win.Spread.SheetView spAdministrar_Sheet1;
        private System.Windows.Forms.RadioButton rbtnProgramas;
        private System.Windows.Forms.RadioButton rbtnEmpresas;
        private System.Windows.Forms.RadioButton rbtnUsuarios;
        private System.Windows.Forms.ComboBox cbEmpresas;
        private System.Windows.Forms.Panel pnlPie;
        private System.Windows.Forms.Button btnSalir;
        private FarPoint.Win.Spread.FpSpread spSubProgramas;
        private FarPoint.Win.Spread.SheetView spSubProgramas_Sheet1;
        private FarPoint.Win.Spread.FpSpread spProgramas;
        private FarPoint.Win.Spread.SheetView spProgramas_Sheet1;
    }
}