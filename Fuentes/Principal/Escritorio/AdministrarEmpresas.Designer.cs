namespace Escritorio
{
    partial class AdministrarEmpresas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdministrarEmpresas));
            this.pnlEmpresas = new System.Windows.Forms.Panel();
            this.spEmpresas = new FarPoint.Win.Spread.FpSpread();
            this.spEmpresas_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlEmpresas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spEmpresas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spEmpresas_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlEmpresas
            // 
            this.pnlEmpresas.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.pnlEmpresas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlEmpresas.BackgroundImage")));
            this.pnlEmpresas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlEmpresas.Controls.Add(this.spEmpresas);
            this.pnlEmpresas.Location = new System.Drawing.Point(0, -1);
            this.pnlEmpresas.Name = "pnlEmpresas";
            this.pnlEmpresas.Size = new System.Drawing.Size(1032, 278);
            this.pnlEmpresas.TabIndex = 1;
            // 
            // spEmpresas
            // 
            this.spEmpresas.AccessibleDescription = "";
            this.spEmpresas.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spEmpresas.Location = new System.Drawing.Point(12, 13);
            this.spEmpresas.Name = "spEmpresas";
            this.spEmpresas.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spEmpresas_Sheet1});
            this.spEmpresas.Size = new System.Drawing.Size(1007, 253);
            this.spEmpresas.TabIndex = 1;
            this.spEmpresas.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spEmpresas.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spEmpresas_CellDoubleClick);
            // 
            // spEmpresas_Sheet1
            // 
            this.spEmpresas_Sheet1.Reset();
            spEmpresas_Sheet1.SheetName = "Sheet1";
            // 
            // AdministrarEmpresas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1033, 275);
            this.Controls.Add(this.pnlEmpresas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "AdministrarEmpresas";
            this.Text = "Empresas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdministrarEmpresas_FormClosed);
            this.Load += new System.EventHandler(this.Empresas_Load);
            this.pnlEmpresas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spEmpresas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spEmpresas_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlEmpresas;
        private FarPoint.Win.Spread.FpSpread spEmpresas;
        private FarPoint.Win.Spread.SheetView spEmpresas_Sheet1;
    }
}