<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Principal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Principal))
        Dim EnhancedScrollBarRenderer1 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim EnhancedScrollBarRenderer2 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Me.pnlContenido = New System.Windows.Forms.Panel()
        Me.pnlCuerpo = New System.Windows.Forms.Panel()
        Me.tbActividades = New System.Windows.Forms.TabControl()
        Me.tpCapturarActividades = New System.Windows.Forms.TabPage()
        Me.btnCapturaIdAnterior = New System.Windows.Forms.Button()
        Me.btnCapturaIdSiguiente = New System.Windows.Forms.Button()
        Me.dtpCapturaFechaVencimiento = New System.Windows.Forms.DateTimePicker()
        Me.dtpCapturaFechaCreacion = New System.Windows.Forms.DateTimePicker()
        Me.btnCapturaGuardar = New System.Windows.Forms.Button()
        Me.chkCapturaEsUrgente = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCapturaId = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCapturaDescripcion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCapturaNombre = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.spResolverActividades = New FarPoint.Win.Spread.FpSpread()
        Me.spResolverActividades_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblEncabezadoEmpresa = New System.Windows.Forms.Label()
        Me.lblEncabezadoPrograma = New System.Windows.Forms.Label()
        Me.pnlContenido.SuspendLayout()
        Me.pnlCuerpo.SuspendLayout()
        Me.tbActividades.SuspendLayout()
        Me.tpCapturarActividades.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.spResolverActividades, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spResolverActividades_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlContenido
        '
        Me.pnlContenido.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlContenido.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnlContenido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlContenido.Controls.Add(Me.pnlCuerpo)
        Me.pnlContenido.Controls.Add(Me.pnlPie)
        Me.pnlContenido.Controls.Add(Me.pnlEncabezado)
        Me.pnlContenido.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlContenido.Location = New System.Drawing.Point(2, 1)
        Me.pnlContenido.Name = "pnlContenido"
        Me.pnlContenido.Size = New System.Drawing.Size(1035, 633)
        Me.pnlContenido.TabIndex = 2
        '
        'pnlCuerpo
        '
        Me.pnlCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlCuerpo.AutoScroll = True
        Me.pnlCuerpo.BackColor = System.Drawing.Color.Transparent
        Me.pnlCuerpo.Controls.Add(Me.tbActividades)
        Me.pnlCuerpo.Location = New System.Drawing.Point(3, 135)
        Me.pnlCuerpo.Name = "pnlCuerpo"
        Me.pnlCuerpo.Size = New System.Drawing.Size(1029, 429)
        Me.pnlCuerpo.TabIndex = 9
        '
        'tbActividades
        '
        Me.tbActividades.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbActividades.Controls.Add(Me.tpCapturarActividades)
        Me.tbActividades.Controls.Add(Me.TabPage2)
        Me.tbActividades.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbActividades.Location = New System.Drawing.Point(3, 0)
        Me.tbActividades.Name = "tbActividades"
        Me.tbActividades.SelectedIndex = 0
        Me.tbActividades.Size = New System.Drawing.Size(1023, 429)
        Me.tbActividades.TabIndex = 1
        '
        'tpCapturarActividades
        '
        Me.tpCapturarActividades.AutoScroll = True
        Me.tpCapturarActividades.BackColor = System.Drawing.Color.White
        Me.tpCapturarActividades.Controls.Add(Me.btnCapturaIdAnterior)
        Me.tpCapturarActividades.Controls.Add(Me.btnCapturaIdSiguiente)
        Me.tpCapturarActividades.Controls.Add(Me.dtpCapturaFechaVencimiento)
        Me.tpCapturarActividades.Controls.Add(Me.dtpCapturaFechaCreacion)
        Me.tpCapturarActividades.Controls.Add(Me.btnCapturaGuardar)
        Me.tpCapturarActividades.Controls.Add(Me.chkCapturaEsUrgente)
        Me.tpCapturarActividades.Controls.Add(Me.Label5)
        Me.tpCapturarActividades.Controls.Add(Me.Label4)
        Me.tpCapturarActividades.Controls.Add(Me.txtCapturaId)
        Me.tpCapturarActividades.Controls.Add(Me.Label3)
        Me.tpCapturarActividades.Controls.Add(Me.txtCapturaDescripcion)
        Me.tpCapturarActividades.Controls.Add(Me.Label2)
        Me.tpCapturarActividades.Controls.Add(Me.txtCapturaNombre)
        Me.tpCapturarActividades.Controls.Add(Me.Label1)
        Me.tpCapturarActividades.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tpCapturarActividades.Location = New System.Drawing.Point(4, 33)
        Me.tpCapturarActividades.Name = "tpCapturarActividades"
        Me.tpCapturarActividades.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCapturarActividades.Size = New System.Drawing.Size(1015, 392)
        Me.tpCapturarActividades.TabIndex = 0
        Me.tpCapturarActividades.Text = "Capturar Actividades"
        '
        'btnCapturaIdAnterior
        '
        Me.btnCapturaIdAnterior.BackColor = System.Drawing.Color.White
        Me.btnCapturaIdAnterior.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCapturaIdAnterior.Location = New System.Drawing.Point(558, 15)
        Me.btnCapturaIdAnterior.Name = "btnCapturaIdAnterior"
        Me.btnCapturaIdAnterior.Size = New System.Drawing.Size(42, 29)
        Me.btnCapturaIdAnterior.TabIndex = 15
        Me.btnCapturaIdAnterior.Text = "<"
        Me.btnCapturaIdAnterior.UseVisualStyleBackColor = False
        '
        'btnCapturaIdSiguiente
        '
        Me.btnCapturaIdSiguiente.BackColor = System.Drawing.Color.White
        Me.btnCapturaIdSiguiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCapturaIdSiguiente.Location = New System.Drawing.Point(600, 15)
        Me.btnCapturaIdSiguiente.Name = "btnCapturaIdSiguiente"
        Me.btnCapturaIdSiguiente.Size = New System.Drawing.Size(42, 29)
        Me.btnCapturaIdSiguiente.TabIndex = 14
        Me.btnCapturaIdSiguiente.Text = ">"
        Me.btnCapturaIdSiguiente.UseVisualStyleBackColor = False
        '
        'dtpCapturaFechaVencimiento
        '
        Me.dtpCapturaFechaVencimiento.Location = New System.Drawing.Point(190, 184)
        Me.dtpCapturaFechaVencimiento.Name = "dtpCapturaFechaVencimiento"
        Me.dtpCapturaFechaVencimiento.Size = New System.Drawing.Size(363, 29)
        Me.dtpCapturaFechaVencimiento.TabIndex = 13
        '
        'dtpCapturaFechaCreacion
        '
        Me.dtpCapturaFechaCreacion.Location = New System.Drawing.Point(190, 149)
        Me.dtpCapturaFechaCreacion.Name = "dtpCapturaFechaCreacion"
        Me.dtpCapturaFechaCreacion.Size = New System.Drawing.Size(363, 29)
        Me.dtpCapturaFechaCreacion.TabIndex = 12
        '
        'btnCapturaGuardar
        '
        Me.btnCapturaGuardar.BackColor = System.Drawing.Color.White
        Me.btnCapturaGuardar.Image = CType(resources.GetObject("btnCapturaGuardar.Image"), System.Drawing.Image)
        Me.btnCapturaGuardar.Location = New System.Drawing.Point(493, 251)
        Me.btnCapturaGuardar.Margin = New System.Windows.Forms.Padding(0)
        Me.btnCapturaGuardar.Name = "btnCapturaGuardar"
        Me.btnCapturaGuardar.Size = New System.Drawing.Size(60, 60)
        Me.btnCapturaGuardar.TabIndex = 11
        Me.btnCapturaGuardar.UseVisualStyleBackColor = False
        '
        'chkCapturaEsUrgente
        '
        Me.chkCapturaEsUrgente.AutoSize = True
        Me.chkCapturaEsUrgente.Location = New System.Drawing.Point(338, 219)
        Me.chkCapturaEsUrgente.Name = "chkCapturaEsUrgente"
        Me.chkCapturaEsUrgente.Size = New System.Drawing.Size(215, 28)
        Me.chkCapturaEsUrgente.TabIndex = 10
        Me.chkCapturaEsUrgente.Text = "Marcar Como Urgente"
        Me.chkCapturaEsUrgente.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 188)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(180, 24)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Fecha Vencimiento:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 153)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(150, 24)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Fecha Creación:"
        '
        'txtCapturaId
        '
        Me.txtCapturaId.Location = New System.Drawing.Point(190, 15)
        Me.txtCapturaId.MaxLength = 6
        Me.txtCapturaId.Name = "txtCapturaId"
        Me.txtCapturaId.Size = New System.Drawing.Size(363, 29)
        Me.txtCapturaId.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 24)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Id:"
        '
        'txtCapturaDescripcion
        '
        Me.txtCapturaDescripcion.Location = New System.Drawing.Point(190, 85)
        Me.txtCapturaDescripcion.Multiline = True
        Me.txtCapturaDescripcion.Name = "txtCapturaDescripcion"
        Me.txtCapturaDescripcion.Size = New System.Drawing.Size(363, 59)
        Me.txtCapturaDescripcion.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 24)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Descripción:"
        '
        'txtCapturaNombre
        '
        Me.txtCapturaNombre.Location = New System.Drawing.Point(190, 50)
        Me.txtCapturaNombre.Name = "txtCapturaNombre"
        Me.txtCapturaNombre.Size = New System.Drawing.Size(363, 29)
        Me.txtCapturaNombre.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre:"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.spResolverActividades)
        Me.TabPage2.Location = New System.Drawing.Point(4, 33)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1015, 392)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Resolver Actividades"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'spResolverActividades
        '
        Me.spResolverActividades.AccessibleDescription = "spCatalogos, Sheet1, Row 0, Column 0, "
        Me.spResolverActividades.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spResolverActividades.BackColor = System.Drawing.Color.White
        Me.spResolverActividades.HorizontalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.spResolverActividades.HorizontalScrollBar.Name = ""
        EnhancedScrollBarRenderer1.ArrowColor = System.Drawing.Color.DarkSlateGray
        EnhancedScrollBarRenderer1.ArrowHoveredColor = System.Drawing.Color.DarkSlateGray
        EnhancedScrollBarRenderer1.ArrowSelectedColor = System.Drawing.Color.DarkSlateGray
        EnhancedScrollBarRenderer1.ButtonBackgroundColor = System.Drawing.Color.CadetBlue
        EnhancedScrollBarRenderer1.ButtonBorderColor = System.Drawing.Color.SlateGray
        EnhancedScrollBarRenderer1.ButtonHoveredBackgroundColor = System.Drawing.Color.SlateGray
        EnhancedScrollBarRenderer1.ButtonHoveredBorderColor = System.Drawing.Color.DarkGray
        EnhancedScrollBarRenderer1.ButtonSelectedBackgroundColor = System.Drawing.Color.DarkGray
        EnhancedScrollBarRenderer1.ButtonSelectedBorderColor = System.Drawing.Color.CadetBlue
        EnhancedScrollBarRenderer1.TrackBarBackgroundColor = System.Drawing.Color.CadetBlue
        EnhancedScrollBarRenderer1.TrackBarSelectedBackgroundColor = System.Drawing.Color.SlateGray
        Me.spResolverActividades.HorizontalScrollBar.Renderer = EnhancedScrollBarRenderer1
        Me.spResolverActividades.HorizontalScrollBar.TabIndex = 0
        Me.spResolverActividades.Location = New System.Drawing.Point(6, 134)
        Me.spResolverActividades.Name = "spResolverActividades"
        Me.spResolverActividades.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.spResolverActividades_Sheet1})
        Me.spResolverActividades.Size = New System.Drawing.Size(995, 122)
        Me.spResolverActividades.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Seashell
        Me.spResolverActividades.TabIndex = 2
        Me.spResolverActividades.VerticalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.spResolverActividades.VerticalScrollBar.Name = ""
        EnhancedScrollBarRenderer2.ArrowColor = System.Drawing.Color.DarkSlateGray
        EnhancedScrollBarRenderer2.ArrowHoveredColor = System.Drawing.Color.DarkSlateGray
        EnhancedScrollBarRenderer2.ArrowSelectedColor = System.Drawing.Color.DarkSlateGray
        EnhancedScrollBarRenderer2.ButtonBackgroundColor = System.Drawing.Color.CadetBlue
        EnhancedScrollBarRenderer2.ButtonBorderColor = System.Drawing.Color.SlateGray
        EnhancedScrollBarRenderer2.ButtonHoveredBackgroundColor = System.Drawing.Color.SlateGray
        EnhancedScrollBarRenderer2.ButtonHoveredBorderColor = System.Drawing.Color.DarkGray
        EnhancedScrollBarRenderer2.ButtonSelectedBackgroundColor = System.Drawing.Color.DarkGray
        EnhancedScrollBarRenderer2.ButtonSelectedBorderColor = System.Drawing.Color.CadetBlue
        EnhancedScrollBarRenderer2.TrackBarBackgroundColor = System.Drawing.Color.CadetBlue
        EnhancedScrollBarRenderer2.TrackBarSelectedBackgroundColor = System.Drawing.Color.SlateGray
        Me.spResolverActividades.VerticalScrollBar.Renderer = EnhancedScrollBarRenderer2
        Me.spResolverActividades.VerticalScrollBar.TabIndex = 1
        '
        'spResolverActividades_Sheet1
        '
        Me.spResolverActividades_Sheet1.Reset()
        spResolverActividades_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.spResolverActividades_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.spResolverActividades_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spResolverActividades_Sheet1.ColumnFooter.DefaultStyle.Parent = "ColumnHeaderSeashell"
        Me.spResolverActividades_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spResolverActividades_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerSeashell"
        Me.spResolverActividades_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spResolverActividades_Sheet1.ColumnHeader.DefaultStyle.Parent = "ColumnHeaderSeashell"
        Me.spResolverActividades_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spResolverActividades_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderSeashell"
        Me.spResolverActividades_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spResolverActividades_Sheet1.SheetCornerStyle.Parent = "CornerSeashell"
        Me.spResolverActividades_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'pnlPie
        '
        Me.pnlPie.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPie.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.pnlPie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPie.Controls.Add(Me.btnSalir)
        Me.pnlPie.Location = New System.Drawing.Point(0, 570)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1035, 60)
        Me.pnlPie.TabIndex = 8
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.BackColor = System.Drawing.Color.White
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(973, -1)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(0)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(60, 60)
        Me.btnSalir.TabIndex = 2
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlEncabezado.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.pnlEncabezado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEncabezado.Controls.Add(Me.lblEncabezadoEmpresa)
        Me.pnlEncabezado.Controls.Add(Me.lblEncabezadoPrograma)
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1035, 129)
        Me.pnlEncabezado.TabIndex = 7
        '
        'lblEncabezadoEmpresa
        '
        Me.lblEncabezadoEmpresa.AutoSize = True
        Me.lblEncabezadoEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezadoEmpresa.ForeColor = System.Drawing.Color.White
        Me.lblEncabezadoEmpresa.Location = New System.Drawing.Point(12, 50)
        Me.lblEncabezadoEmpresa.Name = "lblEncabezadoEmpresa"
        Me.lblEncabezadoEmpresa.Size = New System.Drawing.Size(0, 33)
        Me.lblEncabezadoEmpresa.TabIndex = 1
        '
        'lblEncabezadoPrograma
        '
        Me.lblEncabezadoPrograma.AutoSize = True
        Me.lblEncabezadoPrograma.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezadoPrograma.ForeColor = System.Drawing.Color.White
        Me.lblEncabezadoPrograma.Location = New System.Drawing.Point(12, 9)
        Me.lblEncabezadoPrograma.Name = "lblEncabezadoPrograma"
        Me.lblEncabezadoPrograma.Size = New System.Drawing.Size(0, 33)
        Me.lblEncabezadoPrograma.TabIndex = 0
        '
        'Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1039, 635)
        Me.Controls.Add(Me.pnlContenido)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Principal"
        Me.Text = "Actividades"
        Me.pnlContenido.ResumeLayout(False)
        Me.pnlCuerpo.ResumeLayout(False)
        Me.tbActividades.ResumeLayout(False)
        Me.tpCapturarActividades.ResumeLayout(False)
        Me.tpCapturarActividades.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.spResolverActividades, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spResolverActividades_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents pnlContenido As System.Windows.Forms.Panel
    Private WithEvents pnlCuerpo As System.Windows.Forms.Panel
    Private WithEvents pnlPie As System.Windows.Forms.Panel
    Private WithEvents btnSalir As System.Windows.Forms.Button
    Private WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Private WithEvents lblEncabezadoEmpresa As System.Windows.Forms.Label
    Private WithEvents lblEncabezadoPrograma As System.Windows.Forms.Label
    Friend WithEvents tbActividades As System.Windows.Forms.TabControl
    Friend WithEvents tpCapturarActividades As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents spResolverActividades As FarPoint.Win.Spread.FpSpread
    Friend WithEvents spResolverActividades_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents txtCapturaNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCapturaDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCapturaId As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkCapturaEsUrgente As System.Windows.Forms.CheckBox
    Private WithEvents btnCapturaGuardar As System.Windows.Forms.Button
    Friend WithEvents dtpCapturaFechaCreacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpCapturaFechaVencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnCapturaIdSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnCapturaIdAnterior As System.Windows.Forms.Button
End Class
