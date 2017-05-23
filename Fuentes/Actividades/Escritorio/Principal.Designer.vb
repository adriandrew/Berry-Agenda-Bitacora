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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Principal))
        Dim EnhancedScrollBarRenderer3 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim EnhancedScrollBarRenderer4 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Me.pnlContenido = New System.Windows.Forms.Panel()
        Me.pnlCuerpo = New System.Windows.Forms.Panel()
        Me.tbActividades = New System.Windows.Forms.TabControl()
        Me.tpCapturarActividades = New System.Windows.Forms.TabPage()
        Me.lblEstatus = New System.Windows.Forms.Label()
        Me.lblCalificacion = New System.Windows.Forms.Label()
        Me.btnCapturaFechaVencimientoAnterior = New System.Windows.Forms.Button()
        Me.btnCapturaFechaVencimientoSiguiente = New System.Windows.Forms.Button()
        Me.btnCapturaFechaCreacionAnterior = New System.Windows.Forms.Button()
        Me.btnCapturaFechaCreacionSiguiente = New System.Windows.Forms.Button()
        Me.btnCapturaEliminar = New System.Windows.Forms.Button()
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
        Me.pnlExterna = New System.Windows.Forms.Panel()
        Me.lblUsuarios = New System.Windows.Forms.Label()
        Me.cbUsuarios = New System.Windows.Forms.ComboBox()
        Me.lblAreas = New System.Windows.Forms.Label()
        Me.cbAreas = New System.Windows.Forms.ComboBox()
        Me.chkCapturaEsExterna = New System.Windows.Forms.CheckBox()
        Me.tpResolverActividades = New System.Windows.Forms.TabPage()
        Me.pnlResolucion = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pbImagen = New System.Windows.Forms.PictureBox()
        Me.btnAdministrarImagen = New System.Windows.Forms.Button()
        Me.btnResolucionFechaAnterior = New System.Windows.Forms.Button()
        Me.btnResolucionFechaSiguiente = New System.Windows.Forms.Button()
        Me.btnResolucionGuardar = New System.Windows.Forms.Button()
        Me.dtpResolucionFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtResolucionId = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtResolucionDescripcion = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtResolucionMotivoRetraso = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.spResolverActividades = New FarPoint.Win.Spread.FpSpread()
        Me.spResolverActividades_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.btnAyuda = New System.Windows.Forms.Button()
        Me.lblDescripcionTooltip = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblEncabezadoArea = New System.Windows.Forms.Label()
        Me.lblEncabezadoUsuario = New System.Windows.Forms.Label()
        Me.lblEncabezadoEmpresa = New System.Windows.Forms.Label()
        Me.lblEncabezadoPrograma = New System.Windows.Forms.Label()
        Me.temporizador = New System.Windows.Forms.Timer(Me.components)
        Me.pnlContenido.SuspendLayout()
        Me.pnlCuerpo.SuspendLayout()
        Me.tbActividades.SuspendLayout()
        Me.tpCapturarActividades.SuspendLayout()
        Me.pnlExterna.SuspendLayout()
        Me.tpResolverActividades.SuspendLayout()
        Me.pnlResolucion.SuspendLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlCuerpo.Location = New System.Drawing.Point(3, 78)
        Me.pnlCuerpo.Name = "pnlCuerpo"
        Me.pnlCuerpo.Size = New System.Drawing.Size(1029, 489)
        Me.pnlCuerpo.TabIndex = 9
        '
        'tbActividades
        '
        Me.tbActividades.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbActividades.Controls.Add(Me.tpCapturarActividades)
        Me.tbActividades.Controls.Add(Me.tpResolverActividades)
        Me.tbActividades.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tbActividades.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbActividades.HotTrack = True
        Me.tbActividades.Location = New System.Drawing.Point(3, 0)
        Me.tbActividades.Name = "tbActividades"
        Me.tbActividades.SelectedIndex = 0
        Me.tbActividades.Size = New System.Drawing.Size(1023, 489)
        Me.tbActividades.TabIndex = 1
        '
        'tpCapturarActividades
        '
        Me.tpCapturarActividades.AutoScroll = True
        Me.tpCapturarActividades.BackColor = System.Drawing.Color.White
        Me.tpCapturarActividades.Controls.Add(Me.lblEstatus)
        Me.tpCapturarActividades.Controls.Add(Me.lblCalificacion)
        Me.tpCapturarActividades.Controls.Add(Me.btnCapturaFechaVencimientoAnterior)
        Me.tpCapturarActividades.Controls.Add(Me.btnCapturaFechaVencimientoSiguiente)
        Me.tpCapturarActividades.Controls.Add(Me.btnCapturaFechaCreacionAnterior)
        Me.tpCapturarActividades.Controls.Add(Me.btnCapturaFechaCreacionSiguiente)
        Me.tpCapturarActividades.Controls.Add(Me.btnCapturaEliminar)
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
        Me.tpCapturarActividades.Controls.Add(Me.pnlExterna)
        Me.tpCapturarActividades.Cursor = System.Windows.Forms.Cursors.Default
        Me.tpCapturarActividades.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tpCapturarActividades.Location = New System.Drawing.Point(4, 33)
        Me.tpCapturarActividades.Name = "tpCapturarActividades"
        Me.tpCapturarActividades.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCapturarActividades.Size = New System.Drawing.Size(1015, 452)
        Me.tpCapturarActividades.TabIndex = 0
        Me.tpCapturarActividades.Text = "Capturar Actividades"
        '
        'lblEstatus
        '
        Me.lblEstatus.AutoSize = True
        Me.lblEstatus.BackColor = System.Drawing.Color.Transparent
        Me.lblEstatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstatus.ForeColor = System.Drawing.Color.Black
        Me.lblEstatus.Location = New System.Drawing.Point(705, 16)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(0, 24)
        Me.lblEstatus.TabIndex = 23
        '
        'lblCalificacion
        '
        Me.lblCalificacion.AutoSize = True
        Me.lblCalificacion.BackColor = System.Drawing.Color.Transparent
        Me.lblCalificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCalificacion.ForeColor = System.Drawing.Color.Black
        Me.lblCalificacion.Location = New System.Drawing.Point(705, 53)
        Me.lblCalificacion.Name = "lblCalificacion"
        Me.lblCalificacion.Size = New System.Drawing.Size(0, 24)
        Me.lblCalificacion.TabIndex = 22
        '
        'btnCapturaFechaVencimientoAnterior
        '
        Me.btnCapturaFechaVencimientoAnterior.BackColor = System.Drawing.Color.White
        Me.btnCapturaFechaVencimientoAnterior.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCapturaFechaVencimientoAnterior.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCapturaFechaVencimientoAnterior.Location = New System.Drawing.Point(615, 257)
        Me.btnCapturaFechaVencimientoAnterior.Name = "btnCapturaFechaVencimientoAnterior"
        Me.btnCapturaFechaVencimientoAnterior.Size = New System.Drawing.Size(42, 29)
        Me.btnCapturaFechaVencimientoAnterior.TabIndex = 20
        Me.btnCapturaFechaVencimientoAnterior.Text = "<"
        Me.btnCapturaFechaVencimientoAnterior.UseVisualStyleBackColor = False
        '
        'btnCapturaFechaVencimientoSiguiente
        '
        Me.btnCapturaFechaVencimientoSiguiente.BackColor = System.Drawing.Color.White
        Me.btnCapturaFechaVencimientoSiguiente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCapturaFechaVencimientoSiguiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCapturaFechaVencimientoSiguiente.Location = New System.Drawing.Point(657, 257)
        Me.btnCapturaFechaVencimientoSiguiente.Name = "btnCapturaFechaVencimientoSiguiente"
        Me.btnCapturaFechaVencimientoSiguiente.Size = New System.Drawing.Size(42, 29)
        Me.btnCapturaFechaVencimientoSiguiente.TabIndex = 19
        Me.btnCapturaFechaVencimientoSiguiente.Text = ">"
        Me.btnCapturaFechaVencimientoSiguiente.UseVisualStyleBackColor = False
        '
        'btnCapturaFechaCreacionAnterior
        '
        Me.btnCapturaFechaCreacionAnterior.BackColor = System.Drawing.Color.White
        Me.btnCapturaFechaCreacionAnterior.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCapturaFechaCreacionAnterior.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCapturaFechaCreacionAnterior.Location = New System.Drawing.Point(615, 222)
        Me.btnCapturaFechaCreacionAnterior.Name = "btnCapturaFechaCreacionAnterior"
        Me.btnCapturaFechaCreacionAnterior.Size = New System.Drawing.Size(42, 29)
        Me.btnCapturaFechaCreacionAnterior.TabIndex = 18
        Me.btnCapturaFechaCreacionAnterior.Text = "<"
        Me.btnCapturaFechaCreacionAnterior.UseVisualStyleBackColor = False
        '
        'btnCapturaFechaCreacionSiguiente
        '
        Me.btnCapturaFechaCreacionSiguiente.BackColor = System.Drawing.Color.White
        Me.btnCapturaFechaCreacionSiguiente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCapturaFechaCreacionSiguiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCapturaFechaCreacionSiguiente.Location = New System.Drawing.Point(657, 222)
        Me.btnCapturaFechaCreacionSiguiente.Name = "btnCapturaFechaCreacionSiguiente"
        Me.btnCapturaFechaCreacionSiguiente.Size = New System.Drawing.Size(42, 29)
        Me.btnCapturaFechaCreacionSiguiente.TabIndex = 17
        Me.btnCapturaFechaCreacionSiguiente.Text = ">"
        Me.btnCapturaFechaCreacionSiguiente.UseVisualStyleBackColor = False
        '
        'btnCapturaEliminar
        '
        Me.btnCapturaEliminar.BackColor = System.Drawing.Color.White
        Me.btnCapturaEliminar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCapturaEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnCapturaEliminar.FlatAppearance.BorderSize = 3
        Me.btnCapturaEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine
        Me.btnCapturaEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCapturaEliminar.ForeColor = System.Drawing.Color.Black
        Me.btnCapturaEliminar.Image = CType(resources.GetObject("btnCapturaEliminar.Image"), System.Drawing.Image)
        Me.btnCapturaEliminar.Location = New System.Drawing.Point(578, 434)
        Me.btnCapturaEliminar.Margin = New System.Windows.Forms.Padding(0)
        Me.btnCapturaEliminar.Name = "btnCapturaEliminar"
        Me.btnCapturaEliminar.Size = New System.Drawing.Size(60, 60)
        Me.btnCapturaEliminar.TabIndex = 16
        Me.btnCapturaEliminar.UseVisualStyleBackColor = False
        '
        'btnCapturaIdAnterior
        '
        Me.btnCapturaIdAnterior.BackColor = System.Drawing.Color.White
        Me.btnCapturaIdAnterior.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCapturaIdAnterior.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCapturaIdAnterior.Location = New System.Drawing.Point(615, 15)
        Me.btnCapturaIdAnterior.Name = "btnCapturaIdAnterior"
        Me.btnCapturaIdAnterior.Size = New System.Drawing.Size(42, 29)
        Me.btnCapturaIdAnterior.TabIndex = 15
        Me.btnCapturaIdAnterior.Text = "<"
        Me.btnCapturaIdAnterior.UseVisualStyleBackColor = False
        '
        'btnCapturaIdSiguiente
        '
        Me.btnCapturaIdSiguiente.BackColor = System.Drawing.Color.White
        Me.btnCapturaIdSiguiente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCapturaIdSiguiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCapturaIdSiguiente.Location = New System.Drawing.Point(657, 15)
        Me.btnCapturaIdSiguiente.Name = "btnCapturaIdSiguiente"
        Me.btnCapturaIdSiguiente.Size = New System.Drawing.Size(42, 29)
        Me.btnCapturaIdSiguiente.TabIndex = 14
        Me.btnCapturaIdSiguiente.Text = ">"
        Me.btnCapturaIdSiguiente.UseVisualStyleBackColor = False
        '
        'dtpCapturaFechaVencimiento
        '
        Me.dtpCapturaFechaVencimiento.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtpCapturaFechaVencimiento.Location = New System.Drawing.Point(247, 257)
        Me.dtpCapturaFechaVencimiento.Name = "dtpCapturaFechaVencimiento"
        Me.dtpCapturaFechaVencimiento.Size = New System.Drawing.Size(363, 29)
        Me.dtpCapturaFechaVencimiento.TabIndex = 13
        '
        'dtpCapturaFechaCreacion
        '
        Me.dtpCapturaFechaCreacion.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpCapturaFechaCreacion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtpCapturaFechaCreacion.Location = New System.Drawing.Point(247, 222)
        Me.dtpCapturaFechaCreacion.Name = "dtpCapturaFechaCreacion"
        Me.dtpCapturaFechaCreacion.Size = New System.Drawing.Size(363, 29)
        Me.dtpCapturaFechaCreacion.TabIndex = 12
        '
        'btnCapturaGuardar
        '
        Me.btnCapturaGuardar.BackColor = System.Drawing.Color.White
        Me.btnCapturaGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCapturaGuardar.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnCapturaGuardar.FlatAppearance.BorderSize = 3
        Me.btnCapturaGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine
        Me.btnCapturaGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCapturaGuardar.ForeColor = System.Drawing.Color.Black
        Me.btnCapturaGuardar.Image = CType(resources.GetObject("btnCapturaGuardar.Image"), System.Drawing.Image)
        Me.btnCapturaGuardar.Location = New System.Drawing.Point(639, 434)
        Me.btnCapturaGuardar.Margin = New System.Windows.Forms.Padding(0)
        Me.btnCapturaGuardar.Name = "btnCapturaGuardar"
        Me.btnCapturaGuardar.Size = New System.Drawing.Size(60, 60)
        Me.btnCapturaGuardar.TabIndex = 11
        Me.btnCapturaGuardar.UseVisualStyleBackColor = False
        '
        'chkCapturaEsUrgente
        '
        Me.chkCapturaEsUrgente.AutoSize = True
        Me.chkCapturaEsUrgente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkCapturaEsUrgente.Location = New System.Drawing.Point(247, 292)
        Me.chkCapturaEsUrgente.Name = "chkCapturaEsUrgente"
        Me.chkCapturaEsUrgente.Size = New System.Drawing.Size(215, 28)
        Me.chkCapturaEsUrgente.TabIndex = 10
        Me.chkCapturaEsUrgente.Text = "Marcar Como Urgente"
        Me.chkCapturaEsUrgente.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 261)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(228, 24)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Fecha de Vencimiento:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 226)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(195, 24)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Fecha de Creación:"
        '
        'txtCapturaId
        '
        Me.txtCapturaId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCapturaId.Location = New System.Drawing.Point(247, 15)
        Me.txtCapturaId.MaxLength = 6
        Me.txtCapturaId.Name = "txtCapturaId"
        Me.txtCapturaId.Size = New System.Drawing.Size(363, 29)
        Me.txtCapturaId.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 24)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Id:"
        '
        'txtCapturaDescripcion
        '
        Me.txtCapturaDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCapturaDescripcion.Location = New System.Drawing.Point(247, 85)
        Me.txtCapturaDescripcion.Multiline = True
        Me.txtCapturaDescripcion.Name = "txtCapturaDescripcion"
        Me.txtCapturaDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCapturaDescripcion.Size = New System.Drawing.Size(452, 131)
        Me.txtCapturaDescripcion.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 24)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Descripción:"
        '
        'txtCapturaNombre
        '
        Me.txtCapturaNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCapturaNombre.Location = New System.Drawing.Point(247, 50)
        Me.txtCapturaNombre.Name = "txtCapturaNombre"
        Me.txtCapturaNombre.Size = New System.Drawing.Size(452, 29)
        Me.txtCapturaNombre.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre:"
        '
        'pnlExterna
        '
        Me.pnlExterna.Controls.Add(Me.lblUsuarios)
        Me.pnlExterna.Controls.Add(Me.cbUsuarios)
        Me.pnlExterna.Controls.Add(Me.lblAreas)
        Me.pnlExterna.Controls.Add(Me.cbAreas)
        Me.pnlExterna.Controls.Add(Me.chkCapturaEsExterna)
        Me.pnlExterna.Location = New System.Drawing.Point(241, 322)
        Me.pnlExterna.Name = "pnlExterna"
        Me.pnlExterna.Size = New System.Drawing.Size(462, 110)
        Me.pnlExterna.TabIndex = 21
        '
        'lblUsuarios
        '
        Me.lblUsuarios.AutoSize = True
        Me.lblUsuarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuarios.Location = New System.Drawing.Point(3, 74)
        Me.lblUsuarios.Name = "lblUsuarios"
        Me.lblUsuarios.Size = New System.Drawing.Size(87, 24)
        Me.lblUsuarios.TabIndex = 5
        Me.lblUsuarios.Text = "Usuario:"
        Me.lblUsuarios.Visible = False
        '
        'cbUsuarios
        '
        Me.cbUsuarios.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbUsuarios.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbUsuarios.FormattingEnabled = True
        Me.cbUsuarios.Location = New System.Drawing.Point(96, 71)
        Me.cbUsuarios.Name = "cbUsuarios"
        Me.cbUsuarios.Size = New System.Drawing.Size(353, 32)
        Me.cbUsuarios.TabIndex = 4
        Me.cbUsuarios.Visible = False
        '
        'lblAreas
        '
        Me.lblAreas.AutoSize = True
        Me.lblAreas.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAreas.Location = New System.Drawing.Point(3, 36)
        Me.lblAreas.Name = "lblAreas"
        Me.lblAreas.Size = New System.Drawing.Size(60, 24)
        Me.lblAreas.TabIndex = 3
        Me.lblAreas.Text = "Area:"
        Me.lblAreas.Visible = False
        '
        'cbAreas
        '
        Me.cbAreas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbAreas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbAreas.FormattingEnabled = True
        Me.cbAreas.Location = New System.Drawing.Point(96, 33)
        Me.cbAreas.Name = "cbAreas"
        Me.cbAreas.Size = New System.Drawing.Size(353, 32)
        Me.cbAreas.TabIndex = 1
        Me.cbAreas.Visible = False
        '
        'chkCapturaEsExterna
        '
        Me.chkCapturaEsExterna.AutoSize = True
        Me.chkCapturaEsExterna.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkCapturaEsExterna.Location = New System.Drawing.Point(6, 4)
        Me.chkCapturaEsExterna.Name = "chkCapturaEsExterna"
        Me.chkCapturaEsExterna.Size = New System.Drawing.Size(121, 28)
        Me.chkCapturaEsExterna.TabIndex = 0
        Me.chkCapturaEsExterna.Text = "Es Externa"
        Me.chkCapturaEsExterna.UseVisualStyleBackColor = True
        '
        'tpResolverActividades
        '
        Me.tpResolverActividades.BackColor = System.Drawing.Color.White
        Me.tpResolverActividades.Controls.Add(Me.pnlResolucion)
        Me.tpResolverActividades.Controls.Add(Me.spResolverActividades)
        Me.tpResolverActividades.Cursor = System.Windows.Forms.Cursors.Default
        Me.tpResolverActividades.Location = New System.Drawing.Point(4, 33)
        Me.tpResolverActividades.Name = "tpResolverActividades"
        Me.tpResolverActividades.Padding = New System.Windows.Forms.Padding(3)
        Me.tpResolverActividades.Size = New System.Drawing.Size(1015, 455)
        Me.tpResolverActividades.TabIndex = 1
        Me.tpResolverActividades.Text = "Resolver Actividades"
        '
        'pnlResolucion
        '
        Me.pnlResolucion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlResolucion.Controls.Add(Me.Label10)
        Me.pnlResolucion.Controls.Add(Me.pbImagen)
        Me.pnlResolucion.Controls.Add(Me.btnAdministrarImagen)
        Me.pnlResolucion.Controls.Add(Me.btnResolucionFechaAnterior)
        Me.pnlResolucion.Controls.Add(Me.btnResolucionFechaSiguiente)
        Me.pnlResolucion.Controls.Add(Me.btnResolucionGuardar)
        Me.pnlResolucion.Controls.Add(Me.dtpResolucionFecha)
        Me.pnlResolucion.Controls.Add(Me.Label6)
        Me.pnlResolucion.Controls.Add(Me.txtResolucionId)
        Me.pnlResolucion.Controls.Add(Me.Label7)
        Me.pnlResolucion.Controls.Add(Me.txtResolucionDescripcion)
        Me.pnlResolucion.Controls.Add(Me.Label8)
        Me.pnlResolucion.Controls.Add(Me.txtResolucionMotivoRetraso)
        Me.pnlResolucion.Controls.Add(Me.Label9)
        Me.pnlResolucion.Location = New System.Drawing.Point(6, 7)
        Me.pnlResolucion.Name = "pnlResolucion"
        Me.pnlResolucion.Size = New System.Drawing.Size(677, 334)
        Me.pnlResolucion.TabIndex = 27
        Me.pnlResolucion.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(4, 64)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(151, 24)
        Me.Label10.TabIndex = 40
        Me.Label10.Text = "de Resolución:"
        '
        'pbImagen
        '
        Me.pbImagen.BackColor = System.Drawing.Color.Transparent
        Me.pbImagen.Location = New System.Drawing.Point(219, 168)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(160, 160)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbImagen.TabIndex = 39
        Me.pbImagen.TabStop = False
        '
        'btnAdministrarImagen
        '
        Me.btnAdministrarImagen.BackColor = System.Drawing.Color.White
        Me.btnAdministrarImagen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAdministrarImagen.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnAdministrarImagen.FlatAppearance.BorderSize = 3
        Me.btnAdministrarImagen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine
        Me.btnAdministrarImagen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdministrarImagen.ForeColor = System.Drawing.Color.Black
        Me.btnAdministrarImagen.Image = CType(resources.GetObject("btnAdministrarImagen.Image"), System.Drawing.Image)
        Me.btnAdministrarImagen.Location = New System.Drawing.Point(382, 172)
        Me.btnAdministrarImagen.Margin = New System.Windows.Forms.Padding(0)
        Me.btnAdministrarImagen.Name = "btnAdministrarImagen"
        Me.btnAdministrarImagen.Size = New System.Drawing.Size(60, 60)
        Me.btnAdministrarImagen.TabIndex = 38
        Me.btnAdministrarImagen.UseVisualStyleBackColor = False
        '
        'btnResolucionFechaAnterior
        '
        Me.btnResolucionFechaAnterior.BackColor = System.Drawing.Color.White
        Me.btnResolucionFechaAnterior.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnResolucionFechaAnterior.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResolucionFechaAnterior.Location = New System.Drawing.Point(587, 140)
        Me.btnResolucionFechaAnterior.Name = "btnResolucionFechaAnterior"
        Me.btnResolucionFechaAnterior.Size = New System.Drawing.Size(42, 29)
        Me.btnResolucionFechaAnterior.TabIndex = 37
        Me.btnResolucionFechaAnterior.Text = "<"
        Me.btnResolucionFechaAnterior.UseVisualStyleBackColor = False
        '
        'btnResolucionFechaSiguiente
        '
        Me.btnResolucionFechaSiguiente.BackColor = System.Drawing.Color.White
        Me.btnResolucionFechaSiguiente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnResolucionFechaSiguiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResolucionFechaSiguiente.Location = New System.Drawing.Point(629, 140)
        Me.btnResolucionFechaSiguiente.Name = "btnResolucionFechaSiguiente"
        Me.btnResolucionFechaSiguiente.Size = New System.Drawing.Size(42, 29)
        Me.btnResolucionFechaSiguiente.TabIndex = 36
        Me.btnResolucionFechaSiguiente.Text = ">"
        Me.btnResolucionFechaSiguiente.UseVisualStyleBackColor = False
        '
        'btnResolucionGuardar
        '
        Me.btnResolucionGuardar.BackColor = System.Drawing.Color.White
        Me.btnResolucionGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnResolucionGuardar.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnResolucionGuardar.FlatAppearance.BorderSize = 3
        Me.btnResolucionGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine
        Me.btnResolucionGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnResolucionGuardar.ForeColor = System.Drawing.Color.Black
        Me.btnResolucionGuardar.Image = CType(resources.GetObject("btnResolucionGuardar.Image"), System.Drawing.Image)
        Me.btnResolucionGuardar.Location = New System.Drawing.Point(611, 172)
        Me.btnResolucionGuardar.Margin = New System.Windows.Forms.Padding(0)
        Me.btnResolucionGuardar.Name = "btnResolucionGuardar"
        Me.btnResolucionGuardar.Size = New System.Drawing.Size(60, 60)
        Me.btnResolucionGuardar.TabIndex = 35
        Me.btnResolucionGuardar.UseVisualStyleBackColor = False
        '
        'dtpResolucionFecha
        '
        Me.dtpResolucionFecha.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtpResolucionFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpResolucionFecha.Location = New System.Drawing.Point(219, 140)
        Me.dtpResolucionFecha.Name = "dtpResolucionFecha"
        Me.dtpResolucionFecha.Size = New System.Drawing.Size(362, 29)
        Me.dtpResolucionFecha.TabIndex = 34
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 141)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(216, 24)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "Fecha de Resolución:"
        '
        'txtResolucionId
        '
        Me.txtResolucionId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtResolucionId.Enabled = False
        Me.txtResolucionId.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResolucionId.Location = New System.Drawing.Point(219, 6)
        Me.txtResolucionId.MaxLength = 6
        Me.txtResolucionId.Name = "txtResolucionId"
        Me.txtResolucionId.Size = New System.Drawing.Size(452, 29)
        Me.txtResolucionId.TabIndex = 32
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 24)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "Id:"
        '
        'txtResolucionDescripcion
        '
        Me.txtResolucionDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtResolucionDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResolucionDescripcion.Location = New System.Drawing.Point(219, 40)
        Me.txtResolucionDescripcion.Multiline = True
        Me.txtResolucionDescripcion.Name = "txtResolucionDescripcion"
        Me.txtResolucionDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtResolucionDescripcion.Size = New System.Drawing.Size(452, 59)
        Me.txtResolucionDescripcion.TabIndex = 30
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(4, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(121, 24)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "Descripción"
        '
        'txtResolucionMotivoRetraso
        '
        Me.txtResolucionMotivoRetraso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtResolucionMotivoRetraso.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResolucionMotivoRetraso.Location = New System.Drawing.Point(219, 105)
        Me.txtResolucionMotivoRetraso.Name = "txtResolucionMotivoRetraso"
        Me.txtResolucionMotivoRetraso.Size = New System.Drawing.Size(452, 29)
        Me.txtResolucionMotivoRetraso.TabIndex = 28
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(4, 105)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(184, 24)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Motivo de Retraso:"
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
        Me.spResolverActividades.HorizontalScrollBar.Renderer = EnhancedScrollBarRenderer3
        Me.spResolverActividades.HorizontalScrollBar.TabIndex = 0
        Me.spResolverActividades.Location = New System.Drawing.Point(6, 347)
        Me.spResolverActividades.Name = "spResolverActividades"
        Me.spResolverActividades.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.spResolverActividades_Sheet1})
        Me.spResolverActividades.Size = New System.Drawing.Size(1003, 99)
        Me.spResolverActividades.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Seashell
        Me.spResolverActividades.TabIndex = 2
        Me.spResolverActividades.VerticalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.spResolverActividades.VerticalScrollBar.Name = ""
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
        Me.spResolverActividades.VerticalScrollBar.Renderer = EnhancedScrollBarRenderer4
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
        Me.pnlPie.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.pnlPie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPie.Controls.Add(Me.btnAyuda)
        Me.pnlPie.Controls.Add(Me.lblDescripcionTooltip)
        Me.pnlPie.Controls.Add(Me.btnSalir)
        Me.pnlPie.ForeColor = System.Drawing.Color.White
        Me.pnlPie.Location = New System.Drawing.Point(0, 573)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1035, 60)
        Me.pnlPie.TabIndex = 8
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
        Me.btnAyuda.TabIndex = 4
        Me.btnAyuda.UseVisualStyleBackColor = False
        '
        'lblDescripcionTooltip
        '
        Me.lblDescripcionTooltip.AutoSize = True
        Me.lblDescripcionTooltip.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcionTooltip.ForeColor = System.Drawing.Color.White
        Me.lblDescripcionTooltip.Location = New System.Drawing.Point(100, 15)
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
        Me.btnSalir.Location = New System.Drawing.Point(973, 0)
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
        Me.pnlEncabezado.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.pnlEncabezado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEncabezado.Controls.Add(Me.lblEncabezadoArea)
        Me.pnlEncabezado.Controls.Add(Me.lblEncabezadoUsuario)
        Me.pnlEncabezado.Controls.Add(Me.lblEncabezadoEmpresa)
        Me.pnlEncabezado.Controls.Add(Me.lblEncabezadoPrograma)
        Me.pnlEncabezado.ForeColor = System.Drawing.Color.White
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
        'Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1039, 635)
        Me.Controls.Add(Me.pnlContenido)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Principal"
        Me.Text = "Actividades"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlContenido.ResumeLayout(False)
        Me.pnlCuerpo.ResumeLayout(False)
        Me.tbActividades.ResumeLayout(False)
        Me.tpCapturarActividades.ResumeLayout(False)
        Me.tpCapturarActividades.PerformLayout()
        Me.pnlExterna.ResumeLayout(False)
        Me.pnlExterna.PerformLayout()
        Me.tpResolverActividades.ResumeLayout(False)
        Me.pnlResolucion.ResumeLayout(False)
        Me.pnlResolucion.PerformLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spResolverActividades, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spResolverActividades_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents tbActividades As System.Windows.Forms.TabControl
    Friend WithEvents tpCapturarActividades As System.Windows.Forms.TabPage
    Friend WithEvents tpResolverActividades As System.Windows.Forms.TabPage
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
    Private WithEvents btnCapturaEliminar As System.Windows.Forms.Button
    Friend WithEvents lblDescripcionTooltip As System.Windows.Forms.Label
    Friend WithEvents btnCapturaFechaVencimientoAnterior As System.Windows.Forms.Button
    Friend WithEvents btnCapturaFechaVencimientoSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnCapturaFechaCreacionAnterior As System.Windows.Forms.Button
    Friend WithEvents btnCapturaFechaCreacionSiguiente As System.Windows.Forms.Button
    Private WithEvents lblEncabezadoUsuario As System.Windows.Forms.Label
    Private WithEvents lblEncabezadoArea As System.Windows.Forms.Label
    Friend WithEvents pnlExterna As System.Windows.Forms.Panel
    Friend WithEvents chkCapturaEsExterna As System.Windows.Forms.CheckBox
    Friend WithEvents lblAreas As System.Windows.Forms.Label
    Friend WithEvents cbAreas As System.Windows.Forms.ComboBox
    Friend WithEvents lblUsuarios As System.Windows.Forms.Label
    Friend WithEvents cbUsuarios As System.Windows.Forms.ComboBox
    Friend WithEvents temporizador As System.Windows.Forms.Timer
    Private WithEvents btnAyuda As System.Windows.Forms.Button
    Friend WithEvents pnlResolucion As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Private WithEvents btnAdministrarImagen As System.Windows.Forms.Button
    Friend WithEvents btnResolucionFechaAnterior As System.Windows.Forms.Button
    Friend WithEvents btnResolucionFechaSiguiente As System.Windows.Forms.Button
    Friend WithEvents dtpResolucionFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtResolucionId As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtResolucionDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtResolucionMotivoRetraso As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents btnResolucionGuardar As System.Windows.Forms.Button
    Friend WithEvents lblCalificacion As System.Windows.Forms.Label
    Friend WithEvents lblEstatus As System.Windows.Forms.Label
End Class
