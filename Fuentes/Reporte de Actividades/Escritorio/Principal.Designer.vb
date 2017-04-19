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
        Me.components = New System.ComponentModel.Container()
        Dim EnhancedScrollBarRenderer1 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim EnhancedScrollBarRenderer2 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim EnhancedScrollBarRenderer3 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim EnhancedScrollBarRenderer4 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Principal))
        Me.pnlContenido = New System.Windows.Forms.Panel()
        Me.pnlCuerpo = New System.Windows.Forms.Panel()
        Me.spParaClonar = New FarPoint.Win.Spread.FpSpread()
        Me.spParaClonar_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.gbFechas = New System.Windows.Forms.GroupBox()
        Me.chkFechaResolucion = New System.Windows.Forms.CheckBox()
        Me.chkFechaVencimiento = New System.Windows.Forms.CheckBox()
        Me.chkFechaCreacion = New System.Windows.Forms.CheckBox()
        Me.dtpFechaResolucion = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaVencimiento = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaCreacionFinal = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpFechaResolucionFinal = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpFechaVencimientoFinal = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFechaCreacion = New System.Windows.Forms.DateTimePicker()
        Me.gbCalificacion = New System.Windows.Forms.GroupBox()
        Me.rbtnCalificacionPendientes = New System.Windows.Forms.RadioButton()
        Me.rbtnCalificacionTodos = New System.Windows.Forms.RadioButton()
        Me.rbtnCalificacionAutorizadas = New System.Windows.Forms.RadioButton()
        Me.rbtnCalificacionRechazadas = New System.Windows.Forms.RadioButton()
        Me.gbFiltros = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbUsuariosDestino = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbAreasDestino = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbUsuarios = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbAreas = New System.Windows.Forms.ComboBox()
        Me.gbEstatus = New System.Windows.Forms.GroupBox()
        Me.rbtnEstatusTodos = New System.Windows.Forms.RadioButton()
        Me.rbtnEstatusResueltas = New System.Windows.Forms.RadioButton()
        Me.rbtnEstatusAbiertas = New System.Windows.Forms.RadioButton()
        Me.gbTipo = New System.Windows.Forms.GroupBox()
        Me.rbtnTipoTodos = New System.Windows.Forms.RadioButton()
        Me.rbtnTipoExternas = New System.Windows.Forms.RadioButton()
        Me.rbtnTipoInternas = New System.Windows.Forms.RadioButton()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.spReporte = New FarPoint.Win.Spread.FpSpread()
        Me.spReporte_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.btnExportarPdf = New System.Windows.Forms.Button()
        Me.lblLeyendaParcial = New System.Windows.Forms.Label()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.lblDescripcionTooltip = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblEncabezadoArea = New System.Windows.Forms.Label()
        Me.lblEncabezadoUsuario = New System.Windows.Forms.Label()
        Me.lblEncabezadoEmpresa = New System.Windows.Forms.Label()
        Me.lblEncabezadoPrograma = New System.Windows.Forms.Label()
        Me.temporizador = New System.Windows.Forms.Timer(Me.components)
        Me.impresor = New System.Windows.Forms.PrintDialog()
        Me.btnAyuda = New System.Windows.Forms.Button()
        Me.pnlContenido.SuspendLayout()
        Me.pnlCuerpo.SuspendLayout()
        CType(Me.spParaClonar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spParaClonar_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFiltros.SuspendLayout()
        Me.gbFechas.SuspendLayout()
        Me.gbCalificacion.SuspendLayout()
        Me.gbFiltros.SuspendLayout()
        Me.gbEstatus.SuspendLayout()
        Me.gbTipo.SuspendLayout()
        CType(Me.spReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spReporte_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlCuerpo.BackColor = System.Drawing.Color.White
        Me.pnlCuerpo.Controls.Add(Me.spParaClonar)
        Me.pnlCuerpo.Controls.Add(Me.pnlFiltros)
        Me.pnlCuerpo.Controls.Add(Me.spReporte)
        Me.pnlCuerpo.Location = New System.Drawing.Point(3, 78)
        Me.pnlCuerpo.Name = "pnlCuerpo"
        Me.pnlCuerpo.Size = New System.Drawing.Size(1029, 489)
        Me.pnlCuerpo.TabIndex = 9
        '
        'spParaClonar
        '
        Me.spParaClonar.AccessibleDescription = ""
        Me.spParaClonar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spParaClonar.HorizontalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.spParaClonar.HorizontalScrollBar.Name = ""
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
        Me.spParaClonar.HorizontalScrollBar.Renderer = EnhancedScrollBarRenderer1
        Me.spParaClonar.HorizontalScrollBar.TabIndex = 2
        Me.spParaClonar.Location = New System.Drawing.Point(404, 396)
        Me.spParaClonar.Name = "spParaClonar"
        Me.spParaClonar.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.spParaClonar_Sheet1})
        Me.spParaClonar.Size = New System.Drawing.Size(142, 89)
        Me.spParaClonar.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Seashell
        Me.spParaClonar.TabIndex = 33
        Me.spParaClonar.VerticalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.spParaClonar.VerticalScrollBar.Name = ""
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
        Me.spParaClonar.VerticalScrollBar.Renderer = EnhancedScrollBarRenderer2
        Me.spParaClonar.VerticalScrollBar.TabIndex = 3
        Me.spParaClonar.Visible = False
        '
        'spParaClonar_Sheet1
        '
        Me.spParaClonar_Sheet1.Reset()
        spParaClonar_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.spParaClonar_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.spParaClonar_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spParaClonar_Sheet1.ColumnFooter.DefaultStyle.Parent = "ColumnHeaderSeashell"
        Me.spParaClonar_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spParaClonar_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerSeashell"
        Me.spParaClonar_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spParaClonar_Sheet1.ColumnHeader.DefaultStyle.Parent = "ColumnHeaderSeashell"
        Me.spParaClonar_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spParaClonar_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderSeashell"
        Me.spParaClonar_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spParaClonar_Sheet1.SheetCornerStyle.Parent = "CornerSeashell"
        Me.spParaClonar_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'pnlFiltros
        '
        Me.pnlFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlFiltros.AutoScroll = True
        Me.pnlFiltros.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnlFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlFiltros.Controls.Add(Me.gbFechas)
        Me.pnlFiltros.Controls.Add(Me.gbCalificacion)
        Me.pnlFiltros.Controls.Add(Me.gbFiltros)
        Me.pnlFiltros.Controls.Add(Me.gbEstatus)
        Me.pnlFiltros.Controls.Add(Me.gbTipo)
        Me.pnlFiltros.Controls.Add(Me.btnGenerar)
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 0)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(393, 485)
        Me.pnlFiltros.TabIndex = 22
        '
        'gbFechas
        '
        Me.gbFechas.BackColor = System.Drawing.Color.Transparent
        Me.gbFechas.Controls.Add(Me.chkFechaResolucion)
        Me.gbFechas.Controls.Add(Me.chkFechaVencimiento)
        Me.gbFechas.Controls.Add(Me.chkFechaCreacion)
        Me.gbFechas.Controls.Add(Me.dtpFechaResolucion)
        Me.gbFechas.Controls.Add(Me.dtpFechaVencimiento)
        Me.gbFechas.Controls.Add(Me.dtpFechaCreacionFinal)
        Me.gbFechas.Controls.Add(Me.Label5)
        Me.gbFechas.Controls.Add(Me.dtpFechaResolucionFinal)
        Me.gbFechas.Controls.Add(Me.Label4)
        Me.gbFechas.Controls.Add(Me.dtpFechaVencimientoFinal)
        Me.gbFechas.Controls.Add(Me.Label3)
        Me.gbFechas.Controls.Add(Me.dtpFechaCreacion)
        Me.gbFechas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbFechas.ForeColor = System.Drawing.Color.White
        Me.gbFechas.Location = New System.Drawing.Point(3, 181)
        Me.gbFechas.Name = "gbFechas"
        Me.gbFechas.Size = New System.Drawing.Size(370, 187)
        Me.gbFechas.TabIndex = 17
        Me.gbFechas.TabStop = False
        Me.gbFechas.Text = "Fechas"
        '
        'chkFechaResolucion
        '
        Me.chkFechaResolucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 72.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFechaResolucion.Location = New System.Drawing.Point(347, 149)
        Me.chkFechaResolucion.Name = "chkFechaResolucion"
        Me.chkFechaResolucion.Size = New System.Drawing.Size(16, 25)
        Me.chkFechaResolucion.TabIndex = 22
        Me.chkFechaResolucion.UseVisualStyleBackColor = True
        '
        'chkFechaVencimiento
        '
        Me.chkFechaVencimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 72.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFechaVencimiento.Location = New System.Drawing.Point(346, 96)
        Me.chkFechaVencimiento.Name = "chkFechaVencimiento"
        Me.chkFechaVencimiento.Size = New System.Drawing.Size(16, 25)
        Me.chkFechaVencimiento.TabIndex = 21
        Me.chkFechaVencimiento.UseVisualStyleBackColor = True
        '
        'chkFechaCreacion
        '
        Me.chkFechaCreacion.Checked = True
        Me.chkFechaCreacion.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFechaCreacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 72.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFechaCreacion.Location = New System.Drawing.Point(346, 43)
        Me.chkFechaCreacion.Name = "chkFechaCreacion"
        Me.chkFechaCreacion.Size = New System.Drawing.Size(16, 25)
        Me.chkFechaCreacion.TabIndex = 20
        Me.chkFechaCreacion.UseVisualStyleBackColor = True
        '
        'dtpFechaResolucion
        '
        Me.dtpFechaResolucion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtpFechaResolucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaResolucion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaResolucion.Location = New System.Drawing.Point(8, 149)
        Me.dtpFechaResolucion.Name = "dtpFechaResolucion"
        Me.dtpFechaResolucion.Size = New System.Drawing.Size(165, 26)
        Me.dtpFechaResolucion.TabIndex = 19
        '
        'dtpFechaVencimiento
        '
        Me.dtpFechaVencimiento.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtpFechaVencimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaVencimiento.Location = New System.Drawing.Point(8, 96)
        Me.dtpFechaVencimiento.Name = "dtpFechaVencimiento"
        Me.dtpFechaVencimiento.Size = New System.Drawing.Size(165, 26)
        Me.dtpFechaVencimiento.TabIndex = 18
        '
        'dtpFechaCreacionFinal
        '
        Me.dtpFechaCreacionFinal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtpFechaCreacionFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaCreacionFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaCreacionFinal.Location = New System.Drawing.Point(176, 43)
        Me.dtpFechaCreacionFinal.Name = "dtpFechaCreacionFinal"
        Me.dtpFechaCreacionFinal.Size = New System.Drawing.Size(165, 26)
        Me.dtpFechaCreacionFinal.TabIndex = 17
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(94, 129)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(183, 20)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Fecha de Resolución:"
        '
        'dtpFechaResolucionFinal
        '
        Me.dtpFechaResolucionFinal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtpFechaResolucionFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaResolucionFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaResolucionFinal.Location = New System.Drawing.Point(176, 149)
        Me.dtpFechaResolucionFinal.Name = "dtpFechaResolucionFinal"
        Me.dtpFechaResolucionFinal.Size = New System.Drawing.Size(165, 26)
        Me.dtpFechaResolucionFinal.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(90, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(193, 20)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Fecha de Vencimiento:"
        '
        'dtpFechaVencimientoFinal
        '
        Me.dtpFechaVencimientoFinal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtpFechaVencimientoFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaVencimientoFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaVencimientoFinal.Location = New System.Drawing.Point(176, 96)
        Me.dtpFechaVencimientoFinal.Name = "dtpFechaVencimientoFinal"
        Me.dtpFechaVencimientoFinal.Size = New System.Drawing.Size(165, 26)
        Me.dtpFechaVencimientoFinal.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(110, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(165, 20)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Fecha de Creación:"
        '
        'dtpFechaCreacion
        '
        Me.dtpFechaCreacion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtpFechaCreacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaCreacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaCreacion.Location = New System.Drawing.Point(8, 43)
        Me.dtpFechaCreacion.Name = "dtpFechaCreacion"
        Me.dtpFechaCreacion.Size = New System.Drawing.Size(165, 26)
        Me.dtpFechaCreacion.TabIndex = 0
        '
        'gbCalificacion
        '
        Me.gbCalificacion.BackColor = System.Drawing.Color.Transparent
        Me.gbCalificacion.Controls.Add(Me.rbtnCalificacionPendientes)
        Me.gbCalificacion.Controls.Add(Me.rbtnCalificacionTodos)
        Me.gbCalificacion.Controls.Add(Me.rbtnCalificacionAutorizadas)
        Me.gbCalificacion.Controls.Add(Me.rbtnCalificacionRechazadas)
        Me.gbCalificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCalificacion.ForeColor = System.Drawing.Color.White
        Me.gbCalificacion.Location = New System.Drawing.Point(3, 108)
        Me.gbCalificacion.Name = "gbCalificacion"
        Me.gbCalificacion.Size = New System.Drawing.Size(370, 70)
        Me.gbCalificacion.TabIndex = 16
        Me.gbCalificacion.TabStop = False
        Me.gbCalificacion.Text = "Calificación"
        '
        'rbtnCalificacionPendientes
        '
        Me.rbtnCalificacionPendientes.AutoSize = True
        Me.rbtnCalificacionPendientes.BackColor = System.Drawing.Color.Transparent
        Me.rbtnCalificacionPendientes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbtnCalificacionPendientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnCalificacionPendientes.ForeColor = System.Drawing.Color.White
        Me.rbtnCalificacionPendientes.Location = New System.Drawing.Point(196, 20)
        Me.rbtnCalificacionPendientes.Name = "rbtnCalificacionPendientes"
        Me.rbtnCalificacionPendientes.Size = New System.Drawing.Size(117, 24)
        Me.rbtnCalificacionPendientes.TabIndex = 18
        Me.rbtnCalificacionPendientes.Text = "Pendientes"
        Me.rbtnCalificacionPendientes.UseVisualStyleBackColor = False
        '
        'rbtnCalificacionTodos
        '
        Me.rbtnCalificacionTodos.AutoSize = True
        Me.rbtnCalificacionTodos.BackColor = System.Drawing.Color.Transparent
        Me.rbtnCalificacionTodos.Checked = True
        Me.rbtnCalificacionTodos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbtnCalificacionTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnCalificacionTodos.ForeColor = System.Drawing.Color.White
        Me.rbtnCalificacionTodos.Location = New System.Drawing.Point(52, 20)
        Me.rbtnCalificacionTodos.Name = "rbtnCalificacionTodos"
        Me.rbtnCalificacionTodos.Size = New System.Drawing.Size(76, 24)
        Me.rbtnCalificacionTodos.TabIndex = 17
        Me.rbtnCalificacionTodos.TabStop = True
        Me.rbtnCalificacionTodos.Text = "Todas"
        Me.rbtnCalificacionTodos.UseVisualStyleBackColor = False
        '
        'rbtnCalificacionAutorizadas
        '
        Me.rbtnCalificacionAutorizadas.AutoSize = True
        Me.rbtnCalificacionAutorizadas.BackColor = System.Drawing.Color.Transparent
        Me.rbtnCalificacionAutorizadas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbtnCalificacionAutorizadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnCalificacionAutorizadas.ForeColor = System.Drawing.Color.White
        Me.rbtnCalificacionAutorizadas.Location = New System.Drawing.Point(196, 41)
        Me.rbtnCalificacionAutorizadas.Name = "rbtnCalificacionAutorizadas"
        Me.rbtnCalificacionAutorizadas.Size = New System.Drawing.Size(123, 24)
        Me.rbtnCalificacionAutorizadas.TabIndex = 16
        Me.rbtnCalificacionAutorizadas.Text = "Autorizadas"
        Me.rbtnCalificacionAutorizadas.UseVisualStyleBackColor = False
        '
        'rbtnCalificacionRechazadas
        '
        Me.rbtnCalificacionRechazadas.AutoSize = True
        Me.rbtnCalificacionRechazadas.BackColor = System.Drawing.Color.Transparent
        Me.rbtnCalificacionRechazadas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbtnCalificacionRechazadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnCalificacionRechazadas.ForeColor = System.Drawing.Color.White
        Me.rbtnCalificacionRechazadas.Location = New System.Drawing.Point(52, 41)
        Me.rbtnCalificacionRechazadas.Name = "rbtnCalificacionRechazadas"
        Me.rbtnCalificacionRechazadas.Size = New System.Drawing.Size(127, 24)
        Me.rbtnCalificacionRechazadas.TabIndex = 15
        Me.rbtnCalificacionRechazadas.Text = "Rechazadas"
        Me.rbtnCalificacionRechazadas.UseVisualStyleBackColor = False
        '
        'gbFiltros
        '
        Me.gbFiltros.BackColor = System.Drawing.Color.Transparent
        Me.gbFiltros.Controls.Add(Me.Label1)
        Me.gbFiltros.Controls.Add(Me.cbUsuariosDestino)
        Me.gbFiltros.Controls.Add(Me.Label2)
        Me.gbFiltros.Controls.Add(Me.cbAreasDestino)
        Me.gbFiltros.Controls.Add(Me.Label11)
        Me.gbFiltros.Controls.Add(Me.cbUsuarios)
        Me.gbFiltros.Controls.Add(Me.Label10)
        Me.gbFiltros.Controls.Add(Me.cbAreas)
        Me.gbFiltros.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbFiltros.ForeColor = System.Drawing.Color.White
        Me.gbFiltros.Location = New System.Drawing.Point(3, 372)
        Me.gbFiltros.Name = "gbFiltros"
        Me.gbFiltros.Size = New System.Drawing.Size(370, 138)
        Me.gbFiltros.TabIndex = 15
        Me.gbFiltros.TabStop = False
        Me.gbFiltros.Text = "Filtros"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(1, 109)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 20)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Usuario Destino:"
        '
        'cbUsuariosDestino
        '
        Me.cbUsuariosDestino.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbUsuariosDestino.BackColor = System.Drawing.Color.White
        Me.cbUsuariosDestino.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbUsuariosDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbUsuariosDestino.FormattingEnabled = True
        Me.cbUsuariosDestino.Location = New System.Drawing.Point(146, 106)
        Me.cbUsuariosDestino.Name = "cbUsuariosDestino"
        Me.cbUsuariosDestino.Size = New System.Drawing.Size(220, 28)
        Me.cbUsuariosDestino.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(25, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 20)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Area Destino:"
        '
        'cbAreasDestino
        '
        Me.cbAreasDestino.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbAreasDestino.BackColor = System.Drawing.Color.White
        Me.cbAreasDestino.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbAreasDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAreasDestino.FormattingEnabled = True
        Me.cbAreasDestino.Location = New System.Drawing.Point(146, 48)
        Me.cbAreasDestino.Name = "cbAreasDestino"
        Me.cbAreasDestino.Size = New System.Drawing.Size(220, 28)
        Me.cbAreasDestino.TabIndex = 14
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(10, 80)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(134, 20)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "Usuario Origen:"
        '
        'cbUsuarios
        '
        Me.cbUsuarios.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbUsuarios.BackColor = System.Drawing.Color.White
        Me.cbUsuarios.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbUsuarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbUsuarios.FormattingEnabled = True
        Me.cbUsuarios.Location = New System.Drawing.Point(146, 77)
        Me.cbUsuarios.Name = "cbUsuarios"
        Me.cbUsuarios.Size = New System.Drawing.Size(220, 28)
        Me.cbUsuarios.TabIndex = 12
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(34, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(110, 20)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Area Origen:"
        '
        'cbAreas
        '
        Me.cbAreas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbAreas.BackColor = System.Drawing.Color.White
        Me.cbAreas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbAreas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAreas.FormattingEnabled = True
        Me.cbAreas.Location = New System.Drawing.Point(146, 19)
        Me.cbAreas.Name = "cbAreas"
        Me.cbAreas.Size = New System.Drawing.Size(220, 28)
        Me.cbAreas.TabIndex = 10
        '
        'gbEstatus
        '
        Me.gbEstatus.BackColor = System.Drawing.Color.Transparent
        Me.gbEstatus.Controls.Add(Me.rbtnEstatusTodos)
        Me.gbEstatus.Controls.Add(Me.rbtnEstatusResueltas)
        Me.gbEstatus.Controls.Add(Me.rbtnEstatusAbiertas)
        Me.gbEstatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbEstatus.ForeColor = System.Drawing.Color.White
        Me.gbEstatus.Location = New System.Drawing.Point(3, 55)
        Me.gbEstatus.Name = "gbEstatus"
        Me.gbEstatus.Size = New System.Drawing.Size(370, 50)
        Me.gbEstatus.TabIndex = 14
        Me.gbEstatus.TabStop = False
        Me.gbEstatus.Text = "Estatus"
        '
        'rbtnEstatusTodos
        '
        Me.rbtnEstatusTodos.AutoSize = True
        Me.rbtnEstatusTodos.BackColor = System.Drawing.Color.Transparent
        Me.rbtnEstatusTodos.Checked = True
        Me.rbtnEstatusTodos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbtnEstatusTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnEstatusTodos.ForeColor = System.Drawing.Color.White
        Me.rbtnEstatusTodos.Location = New System.Drawing.Point(29, 19)
        Me.rbtnEstatusTodos.Name = "rbtnEstatusTodos"
        Me.rbtnEstatusTodos.Size = New System.Drawing.Size(76, 24)
        Me.rbtnEstatusTodos.TabIndex = 17
        Me.rbtnEstatusTodos.TabStop = True
        Me.rbtnEstatusTodos.Text = "Todas"
        Me.rbtnEstatusTodos.UseVisualStyleBackColor = False
        '
        'rbtnEstatusResueltas
        '
        Me.rbtnEstatusResueltas.AutoSize = True
        Me.rbtnEstatusResueltas.BackColor = System.Drawing.Color.Transparent
        Me.rbtnEstatusResueltas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbtnEstatusResueltas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnEstatusResueltas.ForeColor = System.Drawing.Color.White
        Me.rbtnEstatusResueltas.Location = New System.Drawing.Point(238, 19)
        Me.rbtnEstatusResueltas.Name = "rbtnEstatusResueltas"
        Me.rbtnEstatusResueltas.Size = New System.Drawing.Size(108, 24)
        Me.rbtnEstatusResueltas.TabIndex = 16
        Me.rbtnEstatusResueltas.Text = "Resueltas"
        Me.rbtnEstatusResueltas.UseVisualStyleBackColor = False
        '
        'rbtnEstatusAbiertas
        '
        Me.rbtnEstatusAbiertas.AutoSize = True
        Me.rbtnEstatusAbiertas.BackColor = System.Drawing.Color.Transparent
        Me.rbtnEstatusAbiertas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbtnEstatusAbiertas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnEstatusAbiertas.ForeColor = System.Drawing.Color.White
        Me.rbtnEstatusAbiertas.Location = New System.Drawing.Point(123, 19)
        Me.rbtnEstatusAbiertas.Name = "rbtnEstatusAbiertas"
        Me.rbtnEstatusAbiertas.Size = New System.Drawing.Size(94, 24)
        Me.rbtnEstatusAbiertas.TabIndex = 15
        Me.rbtnEstatusAbiertas.Text = "Abiertas"
        Me.rbtnEstatusAbiertas.UseVisualStyleBackColor = False
        '
        'gbTipo
        '
        Me.gbTipo.BackColor = System.Drawing.Color.Transparent
        Me.gbTipo.Controls.Add(Me.rbtnTipoTodos)
        Me.gbTipo.Controls.Add(Me.rbtnTipoExternas)
        Me.gbTipo.Controls.Add(Me.rbtnTipoInternas)
        Me.gbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTipo.ForeColor = System.Drawing.Color.White
        Me.gbTipo.Location = New System.Drawing.Point(3, 2)
        Me.gbTipo.Name = "gbTipo"
        Me.gbTipo.Size = New System.Drawing.Size(370, 50)
        Me.gbTipo.TabIndex = 13
        Me.gbTipo.TabStop = False
        Me.gbTipo.Text = "Tipo"
        '
        'rbtnTipoTodos
        '
        Me.rbtnTipoTodos.AutoSize = True
        Me.rbtnTipoTodos.BackColor = System.Drawing.Color.Transparent
        Me.rbtnTipoTodos.Checked = True
        Me.rbtnTipoTodos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbtnTipoTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnTipoTodos.ForeColor = System.Drawing.Color.White
        Me.rbtnTipoTodos.Location = New System.Drawing.Point(34, 20)
        Me.rbtnTipoTodos.Name = "rbtnTipoTodos"
        Me.rbtnTipoTodos.Size = New System.Drawing.Size(76, 24)
        Me.rbtnTipoTodos.TabIndex = 17
        Me.rbtnTipoTodos.TabStop = True
        Me.rbtnTipoTodos.Text = "Todas"
        Me.rbtnTipoTodos.UseVisualStyleBackColor = False
        '
        'rbtnTipoExternas
        '
        Me.rbtnTipoExternas.AutoSize = True
        Me.rbtnTipoExternas.BackColor = System.Drawing.Color.Transparent
        Me.rbtnTipoExternas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbtnTipoExternas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnTipoExternas.ForeColor = System.Drawing.Color.White
        Me.rbtnTipoExternas.Location = New System.Drawing.Point(241, 20)
        Me.rbtnTipoExternas.Name = "rbtnTipoExternas"
        Me.rbtnTipoExternas.Size = New System.Drawing.Size(98, 24)
        Me.rbtnTipoExternas.TabIndex = 16
        Me.rbtnTipoExternas.Text = "Externas"
        Me.rbtnTipoExternas.UseVisualStyleBackColor = False
        '
        'rbtnTipoInternas
        '
        Me.rbtnTipoInternas.AutoSize = True
        Me.rbtnTipoInternas.BackColor = System.Drawing.Color.Transparent
        Me.rbtnTipoInternas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbtnTipoInternas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnTipoInternas.ForeColor = System.Drawing.Color.White
        Me.rbtnTipoInternas.Location = New System.Drawing.Point(129, 20)
        Me.rbtnTipoInternas.Name = "rbtnTipoInternas"
        Me.rbtnTipoInternas.Size = New System.Drawing.Size(94, 24)
        Me.rbtnTipoInternas.TabIndex = 15
        Me.rbtnTipoInternas.Text = "Internas"
        Me.rbtnTipoInternas.UseVisualStyleBackColor = False
        '
        'btnGenerar
        '
        Me.btnGenerar.BackColor = System.Drawing.Color.White
        Me.btnGenerar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGenerar.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnGenerar.FlatAppearance.BorderSize = 3
        Me.btnGenerar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine
        Me.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.ForeColor = System.Drawing.Color.Black
        Me.btnGenerar.Location = New System.Drawing.Point(245, 512)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(128, 55)
        Me.btnGenerar.TabIndex = 10
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.UseVisualStyleBackColor = False
        '
        'spReporte
        '
        Me.spReporte.AccessibleDescription = ""
        Me.spReporte.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spReporte.BackColor = System.Drawing.Color.White
        Me.spReporte.HorizontalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.spReporte.HorizontalScrollBar.Name = ""
        EnhancedScrollBarRenderer3.ArrowColor = System.Drawing.Color.DarkSlateGray
        EnhancedScrollBarRenderer3.ArrowHoveredColor = System.Drawing.Color.DarkSlateGray
        EnhancedScrollBarRenderer3.ArrowSelectedColor = System.Drawing.Color.DarkSlateGray
        EnhancedScrollBarRenderer3.ButtonBackgroundColor = System.Drawing.Color.CadetBlue
        EnhancedScrollBarRenderer3.ButtonBorderColor = System.Drawing.Color.SlateGray
        EnhancedScrollBarRenderer3.ButtonHoveredBackgroundColor = System.Drawing.Color.SlateGray
        EnhancedScrollBarRenderer3.ButtonHoveredBorderColor = System.Drawing.Color.DarkGray
        EnhancedScrollBarRenderer3.ButtonSelectedBackgroundColor = System.Drawing.Color.DarkGray
        EnhancedScrollBarRenderer3.ButtonSelectedBorderColor = System.Drawing.Color.CadetBlue
        EnhancedScrollBarRenderer3.TrackBarBackgroundColor = System.Drawing.Color.CadetBlue
        EnhancedScrollBarRenderer3.TrackBarSelectedBackgroundColor = System.Drawing.Color.SlateGray
        Me.spReporte.HorizontalScrollBar.Renderer = EnhancedScrollBarRenderer3
        Me.spReporte.HorizontalScrollBar.TabIndex = 0
        Me.spReporte.Location = New System.Drawing.Point(404, 3)
        Me.spReporte.Name = "spReporte"
        Me.spReporte.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.spReporte_Sheet1})
        Me.spReporte.Size = New System.Drawing.Size(622, 483)
        Me.spReporte.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Seashell
        Me.spReporte.TabIndex = 3
        Me.spReporte.VerticalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.spReporte.VerticalScrollBar.Name = ""
        EnhancedScrollBarRenderer4.ArrowColor = System.Drawing.Color.DarkSlateGray
        EnhancedScrollBarRenderer4.ArrowHoveredColor = System.Drawing.Color.DarkSlateGray
        EnhancedScrollBarRenderer4.ArrowSelectedColor = System.Drawing.Color.DarkSlateGray
        EnhancedScrollBarRenderer4.ButtonBackgroundColor = System.Drawing.Color.CadetBlue
        EnhancedScrollBarRenderer4.ButtonBorderColor = System.Drawing.Color.SlateGray
        EnhancedScrollBarRenderer4.ButtonHoveredBackgroundColor = System.Drawing.Color.SlateGray
        EnhancedScrollBarRenderer4.ButtonHoveredBorderColor = System.Drawing.Color.DarkGray
        EnhancedScrollBarRenderer4.ButtonSelectedBackgroundColor = System.Drawing.Color.DarkGray
        EnhancedScrollBarRenderer4.ButtonSelectedBorderColor = System.Drawing.Color.CadetBlue
        EnhancedScrollBarRenderer4.TrackBarBackgroundColor = System.Drawing.Color.CadetBlue
        EnhancedScrollBarRenderer4.TrackBarSelectedBackgroundColor = System.Drawing.Color.SlateGray
        Me.spReporte.VerticalScrollBar.Renderer = EnhancedScrollBarRenderer4
        Me.spReporte.VerticalScrollBar.TabIndex = 1
        Me.spReporte.Visible = False
        '
        'spReporte_Sheet1
        '
        Me.spReporte_Sheet1.Reset()
        spReporte_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.spReporte_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.spReporte_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spReporte_Sheet1.ColumnFooter.DefaultStyle.Parent = "ColumnHeaderSeashell"
        Me.spReporte_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spReporte_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerSeashell"
        Me.spReporte_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spReporte_Sheet1.ColumnHeader.DefaultStyle.Parent = "ColumnHeaderSeashell"
        Me.spReporte_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spReporte_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderSeashell"
        Me.spReporte_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spReporte_Sheet1.SheetCornerStyle.Parent = "CornerSeashell"
        Me.spReporte_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'pnlPie
        '
        Me.pnlPie.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPie.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.pnlPie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPie.Controls.Add(Me.btnAyuda)
        Me.pnlPie.Controls.Add(Me.btnExportarPdf)
        Me.pnlPie.Controls.Add(Me.lblLeyendaParcial)
        Me.pnlPie.Controls.Add(Me.btnExportarExcel)
        Me.pnlPie.Controls.Add(Me.btnImprimir)
        Me.pnlPie.Controls.Add(Me.lblDescripcionTooltip)
        Me.pnlPie.Controls.Add(Me.btnSalir)
        Me.pnlPie.Location = New System.Drawing.Point(0, 571)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1035, 60)
        Me.pnlPie.TabIndex = 8
        '
        'btnExportarPdf
        '
        Me.btnExportarPdf.BackColor = System.Drawing.Color.White
        Me.btnExportarPdf.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExportarPdf.Enabled = False
        Me.btnExportarPdf.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnExportarPdf.FlatAppearance.BorderSize = 3
        Me.btnExportarPdf.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine
        Me.btnExportarPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportarPdf.Image = CType(resources.GetObject("btnExportarPdf.Image"), System.Drawing.Image)
        Me.btnExportarPdf.Location = New System.Drawing.Point(184, -1)
        Me.btnExportarPdf.Name = "btnExportarPdf"
        Me.btnExportarPdf.Size = New System.Drawing.Size(60, 60)
        Me.btnExportarPdf.TabIndex = 53
        Me.btnExportarPdf.UseVisualStyleBackColor = False
        '
        'lblLeyendaParcial
        '
        Me.lblLeyendaParcial.AutoSize = True
        Me.lblLeyendaParcial.BackColor = System.Drawing.Color.White
        Me.lblLeyendaParcial.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblLeyendaParcial.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblLeyendaParcial.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLeyendaParcial.ForeColor = System.Drawing.Color.White
        Me.lblLeyendaParcial.Location = New System.Drawing.Point(219, 15)
        Me.lblLeyendaParcial.Name = "lblLeyendaParcial"
        Me.lblLeyendaParcial.Size = New System.Drawing.Size(0, 20)
        Me.lblLeyendaParcial.TabIndex = 52
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.BackColor = System.Drawing.Color.White
        Me.btnExportarExcel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExportarExcel.Enabled = False
        Me.btnExportarExcel.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnExportarExcel.FlatAppearance.BorderSize = 3
        Me.btnExportarExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine
        Me.btnExportarExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportarExcel.Image = CType(resources.GetObject("btnExportarExcel.Image"), System.Drawing.Image)
        Me.btnExportarExcel.Location = New System.Drawing.Point(123, -1)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(60, 60)
        Me.btnExportarExcel.TabIndex = 50
        Me.btnExportarExcel.UseVisualStyleBackColor = False
        '
        'btnImprimir
        '
        Me.btnImprimir.BackColor = System.Drawing.Color.White
        Me.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImprimir.Enabled = False
        Me.btnImprimir.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnImprimir.FlatAppearance.BorderSize = 3
        Me.btnImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.Location = New System.Drawing.Point(62, -1)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(60, 60)
        Me.btnImprimir.TabIndex = 51
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'lblDescripcionTooltip
        '
        Me.lblDescripcionTooltip.AutoSize = True
        Me.lblDescripcionTooltip.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblDescripcionTooltip.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcionTooltip.ForeColor = System.Drawing.Color.White
        Me.lblDescripcionTooltip.Location = New System.Drawing.Point(265, 15)
        Me.lblDescripcionTooltip.Name = "lblDescripcionTooltip"
        Me.lblDescripcionTooltip.Size = New System.Drawing.Size(0, 31)
        Me.lblDescripcionTooltip.TabIndex = 3
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.BackColor = System.Drawing.Color.White
        Me.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnSalir.FlatAppearance.BorderSize = 3
        Me.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.ForeColor = System.Drawing.Color.Black
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
        Me.pnlEncabezado.Controls.Add(Me.lblEncabezadoArea)
        Me.pnlEncabezado.Controls.Add(Me.lblEncabezadoUsuario)
        Me.pnlEncabezado.Controls.Add(Me.lblEncabezadoEmpresa)
        Me.pnlEncabezado.Controls.Add(Me.lblEncabezadoPrograma)
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1035, 75)
        Me.pnlEncabezado.TabIndex = 7
        '
        'lblEncabezadoArea
        '
        Me.lblEncabezadoArea.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEncabezadoArea.AutoSize = True
        Me.lblEncabezadoArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezadoArea.ForeColor = System.Drawing.Color.White
        Me.lblEncabezadoArea.Location = New System.Drawing.Point(600, 0)
        Me.lblEncabezadoArea.Name = "lblEncabezadoArea"
        Me.lblEncabezadoArea.Size = New System.Drawing.Size(0, 33)
        Me.lblEncabezadoArea.TabIndex = 3
        '
        'lblEncabezadoUsuario
        '
        Me.lblEncabezadoUsuario.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEncabezadoUsuario.AutoSize = True
        Me.lblEncabezadoUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezadoUsuario.ForeColor = System.Drawing.Color.White
        Me.lblEncabezadoUsuario.Location = New System.Drawing.Point(600, 35)
        Me.lblEncabezadoUsuario.Name = "lblEncabezadoUsuario"
        Me.lblEncabezadoUsuario.Size = New System.Drawing.Size(0, 33)
        Me.lblEncabezadoUsuario.TabIndex = 2
        '
        'lblEncabezadoEmpresa
        '
        Me.lblEncabezadoEmpresa.AutoSize = True
        Me.lblEncabezadoEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezadoEmpresa.ForeColor = System.Drawing.Color.White
        Me.lblEncabezadoEmpresa.Location = New System.Drawing.Point(12, 35)
        Me.lblEncabezadoEmpresa.Name = "lblEncabezadoEmpresa"
        Me.lblEncabezadoEmpresa.Size = New System.Drawing.Size(0, 33)
        Me.lblEncabezadoEmpresa.TabIndex = 1
        '
        'lblEncabezadoPrograma
        '
        Me.lblEncabezadoPrograma.AutoSize = True
        Me.lblEncabezadoPrograma.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezadoPrograma.ForeColor = System.Drawing.Color.White
        Me.lblEncabezadoPrograma.Location = New System.Drawing.Point(12, 0)
        Me.lblEncabezadoPrograma.Name = "lblEncabezadoPrograma"
        Me.lblEncabezadoPrograma.Size = New System.Drawing.Size(0, 33)
        Me.lblEncabezadoPrograma.TabIndex = 0
        '
        'temporizador
        '
        Me.temporizador.Interval = 1
        '
        'impresor
        '
        Me.impresor.UseEXDialog = True
        '
        'btnAyuda
        '
        Me.btnAyuda.BackColor = System.Drawing.Color.White
        Me.btnAyuda.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAyuda.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnAyuda.FlatAppearance.BorderSize = 3
        Me.btnAyuda.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine
        Me.btnAyuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAyuda.ForeColor = System.Drawing.Color.Black
        Me.btnAyuda.Image = CType(resources.GetObject("btnAyuda.Image"), System.Drawing.Image)
        Me.btnAyuda.Location = New System.Drawing.Point(0, 0)
        Me.btnAyuda.Margin = New System.Windows.Forms.Padding(0)
        Me.btnAyuda.Name = "btnAyuda"
        Me.btnAyuda.Size = New System.Drawing.Size(60, 60)
        Me.btnAyuda.TabIndex = 54
        Me.btnAyuda.UseVisualStyleBackColor = False
        '
        'Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1039, 635)
        Me.Controls.Add(Me.pnlContenido)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Principal"
        Me.Text = "Reporte de Actividades"
        Me.pnlContenido.ResumeLayout(False)
        Me.pnlCuerpo.ResumeLayout(False)
        CType(Me.spParaClonar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spParaClonar_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFiltros.ResumeLayout(False)
        Me.gbFechas.ResumeLayout(False)
        Me.gbFechas.PerformLayout()
        Me.gbCalificacion.ResumeLayout(False)
        Me.gbCalificacion.PerformLayout()
        Me.gbFiltros.ResumeLayout(False)
        Me.gbFiltros.PerformLayout()
        Me.gbEstatus.ResumeLayout(False)
        Me.gbEstatus.PerformLayout()
        Me.gbTipo.ResumeLayout(False)
        Me.gbTipo.PerformLayout()
        CType(Me.spReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spReporte_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
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
    Friend WithEvents lblDescripcionTooltip As System.Windows.Forms.Label
    Private WithEvents lblEncabezadoUsuario As System.Windows.Forms.Label
    Private WithEvents lblEncabezadoArea As System.Windows.Forms.Label
    Friend WithEvents spReporte As FarPoint.Win.Spread.FpSpread
    Friend WithEvents spReporte_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents pnlFiltros As System.Windows.Forms.Panel
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents gbTipo As System.Windows.Forms.GroupBox
    Friend WithEvents rbtnTipoExternas As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnTipoInternas As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnTipoTodos As System.Windows.Forms.RadioButton
    Friend WithEvents gbEstatus As System.Windows.Forms.GroupBox
    Friend WithEvents rbtnEstatusTodos As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnEstatusResueltas As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnEstatusAbiertas As System.Windows.Forms.RadioButton
    Friend WithEvents gbFiltros As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbUsuariosDestino As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbAreasDestino As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cbUsuarios As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cbAreas As System.Windows.Forms.ComboBox
    Friend WithEvents gbCalificacion As System.Windows.Forms.GroupBox
    Friend WithEvents rbtnCalificacionTodos As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnCalificacionAutorizadas As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnCalificacionRechazadas As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnCalificacionPendientes As System.Windows.Forms.RadioButton
    Friend WithEvents gbFechas As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaCreacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaResolucionFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaVencimientoFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaVencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaCreacionFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaResolucion As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkFechaCreacion As System.Windows.Forms.CheckBox
    Friend WithEvents chkFechaResolucion As System.Windows.Forms.CheckBox
    Friend WithEvents chkFechaVencimiento As System.Windows.Forms.CheckBox
    Friend WithEvents temporizador As System.Windows.Forms.Timer
    Friend WithEvents btnExportarPdf As System.Windows.Forms.Button
    Friend WithEvents lblLeyendaParcial As System.Windows.Forms.Label
    Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents impresor As System.Windows.Forms.PrintDialog
    Friend WithEvents spParaClonar As FarPoint.Win.Spread.FpSpread
    Friend WithEvents spParaClonar_Sheet1 As FarPoint.Win.Spread.SheetView
    Private WithEvents btnAyuda As System.Windows.Forms.Button
End Class
