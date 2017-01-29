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
            FarPoint.Win.Spread.EnhancedScrollBarRenderer enhancedScrollBarRenderer1 = new FarPoint.Win.Spread.EnhancedScrollBarRenderer();
            FarPoint.Win.Spread.EnhancedScrollBarRenderer enhancedScrollBarRenderer2 = new FarPoint.Win.Spread.EnhancedScrollBarRenderer();
            FarPoint.Win.Spread.EnhancedScrollBarRenderer enhancedScrollBarRenderer3 = new FarPoint.Win.Spread.EnhancedScrollBarRenderer();
            FarPoint.Win.Spread.EnhancedScrollBarRenderer enhancedScrollBarRenderer4 = new FarPoint.Win.Spread.EnhancedScrollBarRenderer();
            FarPoint.Win.Spread.EnhancedScrollBarRenderer enhancedScrollBarRenderer5 = new FarPoint.Win.Spread.EnhancedScrollBarRenderer();
            FarPoint.Win.Spread.EnhancedScrollBarRenderer enhancedScrollBarRenderer6 = new FarPoint.Win.Spread.EnhancedScrollBarRenderer();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelControl));
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblEncabezadoEmpresa = new System.Windows.Forms.Label();
            this.lblEncabezadoPrograma = new System.Windows.Forms.Label();
            this.pnlCuerpo = new System.Windows.Forms.Panel();
            this.spAdministrar = new FarPoint.Win.Spread.FpSpread();
            this.spAdministrar_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.cbEmpresas = new System.Windows.Forms.ComboBox();
            this.rbtnUsuarios = new System.Windows.Forms.RadioButton();
            this.rbtnEmpresas = new System.Windows.Forms.RadioButton();
            this.rbtnProgramas = new System.Windows.Forms.RadioButton();
            this.spProgramas = new FarPoint.Win.Spread.FpSpread();
            this.spProgramas_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.spSubProgramas = new FarPoint.Win.Spread.FpSpread();
            this.spSubProgramas_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlPie = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.pnlContenido.SuspendLayout();
            this.pnlEncabezado.SuspendLayout();
            this.pnlCuerpo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spAdministrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spAdministrar_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spProgramas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spProgramas_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spSubProgramas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spSubProgramas_Sheet1)).BeginInit();
            this.pnlPie.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContenido
            // 
            this.pnlContenido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContenido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlContenido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlContenido.Controls.Add(this.pnlEncabezado);
            this.pnlContenido.Controls.Add(this.pnlCuerpo);
            this.pnlContenido.Controls.Add(this.pnlPie);
            this.pnlContenido.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlContenido.Location = new System.Drawing.Point(0, 1);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(1031, 629);
            this.pnlContenido.TabIndex = 2;
            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlEncabezado.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.pnlEncabezado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEncabezado.Controls.Add(this.lblEncabezadoEmpresa);
            this.pnlEncabezado.Controls.Add(this.lblEncabezadoPrograma);
            this.pnlEncabezado.Location = new System.Drawing.Point(0, 0);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(1035, 129);
            this.pnlEncabezado.TabIndex = 13;
            // 
            // lblEncabezadoEmpresa
            // 
            this.lblEncabezadoEmpresa.AutoSize = true;
            this.lblEncabezadoEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncabezadoEmpresa.ForeColor = System.Drawing.Color.White;
            this.lblEncabezadoEmpresa.Location = new System.Drawing.Point(12, 50);
            this.lblEncabezadoEmpresa.Name = "lblEncabezadoEmpresa";
            this.lblEncabezadoEmpresa.Size = new System.Drawing.Size(0, 33);
            this.lblEncabezadoEmpresa.TabIndex = 1;
            // 
            // lblEncabezadoPrograma
            // 
            this.lblEncabezadoPrograma.AutoSize = true;
            this.lblEncabezadoPrograma.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncabezadoPrograma.ForeColor = System.Drawing.Color.White;
            this.lblEncabezadoPrograma.Location = new System.Drawing.Point(12, 9);
            this.lblEncabezadoPrograma.Name = "lblEncabezadoPrograma";
            this.lblEncabezadoPrograma.Size = new System.Drawing.Size(0, 33);
            this.lblEncabezadoPrograma.TabIndex = 0;
            // 
            // pnlCuerpo
            // 
            this.pnlCuerpo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCuerpo.AutoScroll = true;
            this.pnlCuerpo.BackColor = System.Drawing.Color.Transparent;
            this.pnlCuerpo.Controls.Add(this.btnEliminar);
            this.pnlCuerpo.Controls.Add(this.btnGuardar);
            this.pnlCuerpo.Controls.Add(this.spAdministrar);
            this.pnlCuerpo.Controls.Add(this.cbEmpresas);
            this.pnlCuerpo.Controls.Add(this.rbtnUsuarios);
            this.pnlCuerpo.Controls.Add(this.rbtnEmpresas);
            this.pnlCuerpo.Controls.Add(this.rbtnProgramas);
            this.pnlCuerpo.Controls.Add(this.spProgramas);
            this.pnlCuerpo.Controls.Add(this.spSubProgramas);
            this.pnlCuerpo.Location = new System.Drawing.Point(1, 133);
            this.pnlCuerpo.Name = "pnlCuerpo";
            this.pnlCuerpo.Size = new System.Drawing.Size(1029, 429);
            this.pnlCuerpo.TabIndex = 12;
            // 
            // spAdministrar
            // 
            this.spAdministrar.AccessibleDescription = "";
            this.spAdministrar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spAdministrar.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spAdministrar.HorizontalScrollBar.Name = "";
            enhancedScrollBarRenderer1.ArrowColor = System.Drawing.Color.DarkSlateGray;
            enhancedScrollBarRenderer1.ArrowHoveredColor = System.Drawing.Color.DarkSlateGray;
            enhancedScrollBarRenderer1.ArrowSelectedColor = System.Drawing.Color.DarkSlateGray;
            enhancedScrollBarRenderer1.ButtonBackgroundColor = System.Drawing.Color.CadetBlue;
            enhancedScrollBarRenderer1.ButtonBorderColor = System.Drawing.Color.SlateGray;
            enhancedScrollBarRenderer1.ButtonHoveredBackgroundColor = System.Drawing.Color.SlateGray;
            enhancedScrollBarRenderer1.ButtonHoveredBorderColor = System.Drawing.Color.DarkGray;
            enhancedScrollBarRenderer1.ButtonSelectedBackgroundColor = System.Drawing.Color.DarkGray;
            enhancedScrollBarRenderer1.ButtonSelectedBorderColor = System.Drawing.Color.CadetBlue;
            enhancedScrollBarRenderer1.TrackBarBackgroundColor = System.Drawing.Color.CadetBlue;
            enhancedScrollBarRenderer1.TrackBarSelectedBackgroundColor = System.Drawing.Color.SlateGray;
            this.spAdministrar.HorizontalScrollBar.Renderer = enhancedScrollBarRenderer1;
            this.spAdministrar.HorizontalScrollBar.TabIndex = 2;
            this.spAdministrar.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spAdministrar.Location = new System.Drawing.Point(11, 11);
            this.spAdministrar.Name = "spAdministrar";
            this.spAdministrar.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spAdministrar_Sheet1});
            this.spAdministrar.Size = new System.Drawing.Size(1007, 238);
            this.spAdministrar.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Seashell;
            this.spAdministrar.TabIndex = 3;
            this.spAdministrar.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spAdministrar.VerticalScrollBar.Name = "";
            enhancedScrollBarRenderer2.ArrowColor = System.Drawing.Color.DarkSlateGray;
            enhancedScrollBarRenderer2.ArrowHoveredColor = System.Drawing.Color.DarkSlateGray;
            enhancedScrollBarRenderer2.ArrowSelectedColor = System.Drawing.Color.DarkSlateGray;
            enhancedScrollBarRenderer2.ButtonBackgroundColor = System.Drawing.Color.CadetBlue;
            enhancedScrollBarRenderer2.ButtonBorderColor = System.Drawing.Color.SlateGray;
            enhancedScrollBarRenderer2.ButtonHoveredBackgroundColor = System.Drawing.Color.SlateGray;
            enhancedScrollBarRenderer2.ButtonHoveredBorderColor = System.Drawing.Color.DarkGray;
            enhancedScrollBarRenderer2.ButtonSelectedBackgroundColor = System.Drawing.Color.DarkGray;
            enhancedScrollBarRenderer2.ButtonSelectedBorderColor = System.Drawing.Color.CadetBlue;
            enhancedScrollBarRenderer2.TrackBarBackgroundColor = System.Drawing.Color.CadetBlue;
            enhancedScrollBarRenderer2.TrackBarSelectedBackgroundColor = System.Drawing.Color.SlateGray;
            this.spAdministrar.VerticalScrollBar.Renderer = enhancedScrollBarRenderer2;
            this.spAdministrar.VerticalScrollBar.TabIndex = 3;
            this.spAdministrar.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spAdministrar.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spAdministrar_CellDoubleClick);
            this.spAdministrar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.spAdministrar_KeyDown);
            // 
            // spAdministrar_Sheet1
            // 
            this.spAdministrar_Sheet1.Reset();
            spAdministrar_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spAdministrar_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.spAdministrar_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spAdministrar_Sheet1.ColumnFooter.DefaultStyle.Parent = "ColumnHeaderSeashell";
            this.spAdministrar_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spAdministrar_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerSeashell";
            this.spAdministrar_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spAdministrar_Sheet1.ColumnHeader.DefaultStyle.Parent = "ColumnHeaderSeashell";
            this.spAdministrar_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spAdministrar_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderSeashell";
            this.spAdministrar_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spAdministrar_Sheet1.SheetCornerStyle.Parent = "CornerSeashell";
            this.spAdministrar_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // cbEmpresas
            // 
            this.cbEmpresas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEmpresas.FormattingEnabled = true;
            this.cbEmpresas.Location = new System.Drawing.Point(11, 124);
            this.cbEmpresas.Name = "cbEmpresas";
            this.cbEmpresas.Size = new System.Drawing.Size(255, 28);
            this.cbEmpresas.TabIndex = 4;
            this.cbEmpresas.Visible = false;
            this.cbEmpresas.SelectedIndexChanged += new System.EventHandler(this.cbEmpresas_SelectedIndexChanged);
            // 
            // rbtnUsuarios
            // 
            this.rbtnUsuarios.AutoSize = true;
            this.rbtnUsuarios.ForeColor = System.Drawing.Color.White;
            this.rbtnUsuarios.Location = new System.Drawing.Point(11, 11);
            this.rbtnUsuarios.Name = "rbtnUsuarios";
            this.rbtnUsuarios.Size = new System.Drawing.Size(101, 28);
            this.rbtnUsuarios.TabIndex = 0;
            this.rbtnUsuarios.TabStop = true;
            this.rbtnUsuarios.Text = "Usuarios";
            this.rbtnUsuarios.UseVisualStyleBackColor = true;
            this.rbtnUsuarios.CheckedChanged += new System.EventHandler(this.rbtnUsuarios_CheckedChanged);
            // 
            // rbtnEmpresas
            // 
            this.rbtnEmpresas.AutoSize = true;
            this.rbtnEmpresas.ForeColor = System.Drawing.Color.White;
            this.rbtnEmpresas.Location = new System.Drawing.Point(11, 45);
            this.rbtnEmpresas.Name = "rbtnEmpresas";
            this.rbtnEmpresas.Size = new System.Drawing.Size(113, 28);
            this.rbtnEmpresas.TabIndex = 1;
            this.rbtnEmpresas.TabStop = true;
            this.rbtnEmpresas.Text = "Empresas";
            this.rbtnEmpresas.UseVisualStyleBackColor = true;
            this.rbtnEmpresas.CheckedChanged += new System.EventHandler(this.rbtnEmpresas_CheckedChanged);
            // 
            // rbtnProgramas
            // 
            this.rbtnProgramas.AutoSize = true;
            this.rbtnProgramas.ForeColor = System.Drawing.Color.White;
            this.rbtnProgramas.Location = new System.Drawing.Point(11, 79);
            this.rbtnProgramas.Name = "rbtnProgramas";
            this.rbtnProgramas.Size = new System.Drawing.Size(119, 28);
            this.rbtnProgramas.TabIndex = 2;
            this.rbtnProgramas.TabStop = true;
            this.rbtnProgramas.Text = "Programas";
            this.rbtnProgramas.UseVisualStyleBackColor = true;
            // 
            // spProgramas
            // 
            this.spProgramas.AccessibleDescription = "";
            this.spProgramas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.spProgramas.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spProgramas.HorizontalScrollBar.Name = "";
            enhancedScrollBarRenderer3.ArrowColor = System.Drawing.Color.DarkSlateGray;
            enhancedScrollBarRenderer3.ArrowHoveredColor = System.Drawing.Color.DarkSlateGray;
            enhancedScrollBarRenderer3.ArrowSelectedColor = System.Drawing.Color.DarkSlateGray;
            enhancedScrollBarRenderer3.ButtonBackgroundColor = System.Drawing.Color.CadetBlue;
            enhancedScrollBarRenderer3.ButtonBorderColor = System.Drawing.Color.SlateGray;
            enhancedScrollBarRenderer3.ButtonHoveredBackgroundColor = System.Drawing.Color.SlateGray;
            enhancedScrollBarRenderer3.ButtonHoveredBorderColor = System.Drawing.Color.DarkGray;
            enhancedScrollBarRenderer3.ButtonSelectedBackgroundColor = System.Drawing.Color.DarkGray;
            enhancedScrollBarRenderer3.ButtonSelectedBorderColor = System.Drawing.Color.CadetBlue;
            enhancedScrollBarRenderer3.TrackBarBackgroundColor = System.Drawing.Color.CadetBlue;
            enhancedScrollBarRenderer3.TrackBarSelectedBackgroundColor = System.Drawing.Color.SlateGray;
            this.spProgramas.HorizontalScrollBar.Renderer = enhancedScrollBarRenderer3;
            this.spProgramas.HorizontalScrollBar.TabIndex = 2;
            this.spProgramas.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spProgramas.Location = new System.Drawing.Point(11, 255);
            this.spProgramas.Name = "spProgramas";
            this.spProgramas.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spProgramas_Sheet1});
            this.spProgramas.Size = new System.Drawing.Size(500, 160);
            this.spProgramas.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Seashell;
            this.spProgramas.TabIndex = 10;
            this.spProgramas.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spProgramas.VerticalScrollBar.Name = "";
            enhancedScrollBarRenderer4.ArrowColor = System.Drawing.Color.DarkSlateGray;
            enhancedScrollBarRenderer4.ArrowHoveredColor = System.Drawing.Color.DarkSlateGray;
            enhancedScrollBarRenderer4.ArrowSelectedColor = System.Drawing.Color.DarkSlateGray;
            enhancedScrollBarRenderer4.ButtonBackgroundColor = System.Drawing.Color.CadetBlue;
            enhancedScrollBarRenderer4.ButtonBorderColor = System.Drawing.Color.SlateGray;
            enhancedScrollBarRenderer4.ButtonHoveredBackgroundColor = System.Drawing.Color.SlateGray;
            enhancedScrollBarRenderer4.ButtonHoveredBorderColor = System.Drawing.Color.DarkGray;
            enhancedScrollBarRenderer4.ButtonSelectedBackgroundColor = System.Drawing.Color.DarkGray;
            enhancedScrollBarRenderer4.ButtonSelectedBorderColor = System.Drawing.Color.CadetBlue;
            enhancedScrollBarRenderer4.TrackBarBackgroundColor = System.Drawing.Color.CadetBlue;
            enhancedScrollBarRenderer4.TrackBarSelectedBackgroundColor = System.Drawing.Color.SlateGray;
            this.spProgramas.VerticalScrollBar.Renderer = enhancedScrollBarRenderer4;
            this.spProgramas.VerticalScrollBar.TabIndex = 3;
            this.spProgramas.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spProgramas.Visible = false;
            this.spProgramas.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spProgramas_CellClick);
            // 
            // spProgramas_Sheet1
            // 
            this.spProgramas_Sheet1.Reset();
            spProgramas_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spProgramas_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.spProgramas_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spProgramas_Sheet1.ColumnFooter.DefaultStyle.Parent = "ColumnHeaderSeashell";
            this.spProgramas_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spProgramas_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerSeashell";
            this.spProgramas_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spProgramas_Sheet1.ColumnHeader.DefaultStyle.Parent = "ColumnHeaderSeashell";
            this.spProgramas_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spProgramas_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderSeashell";
            this.spProgramas_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spProgramas_Sheet1.SheetCornerStyle.Parent = "CornerSeashell";
            this.spProgramas_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // spSubProgramas
            // 
            this.spSubProgramas.AccessibleDescription = "";
            this.spSubProgramas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spSubProgramas.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spSubProgramas.HorizontalScrollBar.Name = "";
            enhancedScrollBarRenderer5.ArrowColor = System.Drawing.Color.DarkSlateGray;
            enhancedScrollBarRenderer5.ArrowHoveredColor = System.Drawing.Color.DarkSlateGray;
            enhancedScrollBarRenderer5.ArrowSelectedColor = System.Drawing.Color.DarkSlateGray;
            enhancedScrollBarRenderer5.ButtonBackgroundColor = System.Drawing.Color.CadetBlue;
            enhancedScrollBarRenderer5.ButtonBorderColor = System.Drawing.Color.SlateGray;
            enhancedScrollBarRenderer5.ButtonHoveredBackgroundColor = System.Drawing.Color.SlateGray;
            enhancedScrollBarRenderer5.ButtonHoveredBorderColor = System.Drawing.Color.DarkGray;
            enhancedScrollBarRenderer5.ButtonSelectedBackgroundColor = System.Drawing.Color.DarkGray;
            enhancedScrollBarRenderer5.ButtonSelectedBorderColor = System.Drawing.Color.CadetBlue;
            enhancedScrollBarRenderer5.TrackBarBackgroundColor = System.Drawing.Color.CadetBlue;
            enhancedScrollBarRenderer5.TrackBarSelectedBackgroundColor = System.Drawing.Color.SlateGray;
            this.spSubProgramas.HorizontalScrollBar.Renderer = enhancedScrollBarRenderer5;
            this.spSubProgramas.HorizontalScrollBar.TabIndex = 2;
            this.spSubProgramas.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spSubProgramas.Location = new System.Drawing.Point(518, 255);
            this.spSubProgramas.Name = "spSubProgramas";
            this.spSubProgramas.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spSubProgramas_Sheet1});
            this.spSubProgramas.Size = new System.Drawing.Size(500, 160);
            this.spSubProgramas.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Seashell;
            this.spSubProgramas.TabIndex = 11;
            this.spSubProgramas.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spSubProgramas.VerticalScrollBar.Name = "";
            enhancedScrollBarRenderer6.ArrowColor = System.Drawing.Color.DarkSlateGray;
            enhancedScrollBarRenderer6.ArrowHoveredColor = System.Drawing.Color.DarkSlateGray;
            enhancedScrollBarRenderer6.ArrowSelectedColor = System.Drawing.Color.DarkSlateGray;
            enhancedScrollBarRenderer6.ButtonBackgroundColor = System.Drawing.Color.CadetBlue;
            enhancedScrollBarRenderer6.ButtonBorderColor = System.Drawing.Color.SlateGray;
            enhancedScrollBarRenderer6.ButtonHoveredBackgroundColor = System.Drawing.Color.SlateGray;
            enhancedScrollBarRenderer6.ButtonHoveredBorderColor = System.Drawing.Color.DarkGray;
            enhancedScrollBarRenderer6.ButtonSelectedBackgroundColor = System.Drawing.Color.DarkGray;
            enhancedScrollBarRenderer6.ButtonSelectedBorderColor = System.Drawing.Color.CadetBlue;
            enhancedScrollBarRenderer6.TrackBarBackgroundColor = System.Drawing.Color.CadetBlue;
            enhancedScrollBarRenderer6.TrackBarSelectedBackgroundColor = System.Drawing.Color.SlateGray;
            this.spSubProgramas.VerticalScrollBar.Renderer = enhancedScrollBarRenderer6;
            this.spSubProgramas.VerticalScrollBar.TabIndex = 3;
            this.spSubProgramas.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spSubProgramas.Visible = false;
            // 
            // spSubProgramas_Sheet1
            // 
            this.spSubProgramas_Sheet1.Reset();
            spSubProgramas_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spSubProgramas_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.spSubProgramas_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spSubProgramas_Sheet1.ColumnFooter.DefaultStyle.Parent = "ColumnHeaderSeashell";
            this.spSubProgramas_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spSubProgramas_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerSeashell";
            this.spSubProgramas_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spSubProgramas_Sheet1.ColumnHeader.DefaultStyle.Parent = "ColumnHeaderSeashell";
            this.spSubProgramas_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spSubProgramas_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderSeashell";
            this.spSubProgramas_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spSubProgramas_Sheet1.SheetCornerStyle.Parent = "CornerSeashell";
            this.spSubProgramas_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlPie
            // 
            this.pnlPie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPie.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.pnlPie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPie.Controls.Add(this.btnSalir);
            this.pnlPie.Location = new System.Drawing.Point(0, 566);
            this.pnlPie.Name = "pnlPie";
            this.pnlPie.Size = new System.Drawing.Size(1031, 60);
            this.pnlPie.TabIndex = 9;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.White;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(969, -1);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(0);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 60);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.BackColor = System.Drawing.Color.White;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.Location = new System.Drawing.Point(898, 369);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(0);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(60, 60);
            this.btnEliminar.TabIndex = 20;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.White;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(958, 369);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(0);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(60, 60);
            this.btnGuardar.TabIndex = 19;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // PanelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 627);
            this.Controls.Add(this.pnlContenido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PanelControl";
            this.Text = "Panel de Control";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PanelControl_FormClosed);
            this.Load += new System.EventHandler(this.PanelControl_Load);
            this.Shown += new System.EventHandler(this.PanelControl_Shown);
            this.pnlContenido.ResumeLayout(false);
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.pnlCuerpo.ResumeLayout(false);
            this.pnlCuerpo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spAdministrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spAdministrar_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spProgramas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spProgramas_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spSubProgramas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spSubProgramas_Sheet1)).EndInit();
            this.pnlPie.ResumeLayout(false);
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
        private System.Windows.Forms.Panel pnlCuerpo;
        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label lblEncabezadoEmpresa;
        private System.Windows.Forms.Label lblEncabezadoPrograma;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnGuardar;
    }
}