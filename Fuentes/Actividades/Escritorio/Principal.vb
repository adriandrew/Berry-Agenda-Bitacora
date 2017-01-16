Public Class Principal

    Dim actividades As New EntidadesActividades.Actividades
    Dim actividadesResueltas As New EntidadesActividades.ActividadesResueltas
    Public datosEmpresa As New LogicaActividades.DatosEmpresa()
    Public datosUsuario As New LogicaActividades.DatosUsuario()
    Public tipoTexto As New FarPoint.Win.Spread.CellType.TextCellType()
    Public tipoEntero As New FarPoint.Win.Spread.CellType.NumberCellType()
    Public tipoDoble As New FarPoint.Win.Spread.CellType.NumberCellType()
    Public tipoPorcentaje As New FarPoint.Win.Spread.CellType.PercentCellType()
    Public tipoHora As New FarPoint.Win.Spread.CellType.DateTimeCellType()
    Public tipoFecha As New FarPoint.Win.Spread.CellType.DateTimeCellType()
    Public tipoBooleano As New FarPoint.Win.Spread.CellType.CheckBoxCellType()

    Public opcionSeleccionada As Integer = 0

#Region "Eventos"

    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Centrar()
        AsignarTooltips()
        ConfigurarConexiones()
        CargarEncabezados()
        CargarConsecutivoActividades()
        ComenzarCargarActividadesResueltas()
        CargarTiposDeDatos()
        CargarIndiceActividades()

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        Application.Exit()

    End Sub

    Private Sub spCapturarActividades_KeyDown(sender As Object, e As KeyEventArgs)

        If e.KeyData = Keys.F9 Then
            Dim columnaActiva As Integer = spResolverActividades.ActiveSheet.ActiveColumnIndex
            '    if (columnaActiva = spCapturarActividades.ActiveSheet.Columns["idProductor"].Index) then
            '         Catalogos.opcionSeleccionada = (int)LogicaTarima.NumeracionCatalogos.Numeracion.productor;
            '        new Escritorio.Catalogos().Show();
            'End If
        ElseIf e.KeyData = Keys.F11 Then
            If (MessageBox.Show("Confirmas que deseas eliminar el registro seleccionado?", "Confirmacion.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                If (Me.opcionSeleccionada = OpcionActividades.Capturar) Then
                    EliminarActividadesResueltas()
                ElseIf (Me.opcionSeleccionada = OpcionActividades.Resolver) Then
                End If
            End If
        ElseIf (e.KeyData = Keys.Enter) Then
            ControlarSpreadActividadesResueltasEnter()
        End If

    End Sub
     
    Private Sub Principal_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        PonerFocoEnControl(txtCapturaId)

    End Sub

    Private Sub btnCapturaGuardar_Click(sender As Object, e As EventArgs) Handles btnCapturaGuardar.Click

        If (Me.opcionSeleccionada = OpcionActividades.Capturar) Then
            GuardarEditarActividades()
        End If

    End Sub

    Private Sub txtId_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCapturaId.KeyPress

        Dim valor As Boolean = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
        'If CInt(Val(e.KeyChar)) <= 0 Then
        '    valor = True
        'End If
        e.Handled = valor

    End Sub

    Private Sub btnCapturaIdAnterior_Click(sender As Object, e As EventArgs) Handles btnCapturaIdAnterior.Click

        If IsNumeric(txtCapturaId.Text) Then
            If CInt(txtCapturaId.Text) > 1 Then
                txtCapturaId.Text -= 1
                CargarActividades()
                PonerFocoEnControl(txtCapturaId)
            End If
        Else
            txtCapturaId.Clear()
        End If

    End Sub

    Private Sub btnCapturaIdSiguiente_Click(sender As Object, e As EventArgs) Handles btnCapturaIdSiguiente.Click

        If IsNumeric(txtCapturaId.Text) Then
            If CInt(txtCapturaId.Text) > 0 Then
                txtCapturaId.Text += 1
                CargarActividades()
                PonerFocoEnControl(txtCapturaId)
            End If
        Else
            txtCapturaId.Clear()
        End If

    End Sub

    Private Sub txtCapturaId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCapturaNombre.KeyDown, txtCapturaId.KeyDown, txtCapturaDescripcion.KeyDown, dtpCapturaFechaVencimiento.KeyDown, dtpCapturaFechaCreacion.KeyDown

        If e.KeyData = Keys.Enter Then
            e.SuppressKeyPress = True
            If sender.Equals(txtCapturaId) Then 
                If IsNumeric(txtCapturaId.Text) Then
                    If CInt(txtCapturaId.Text) > 0 Then
                        CargarActividades()
                        txtCapturaNombre.Focus()
                    End If
                End If
            ElseIf sender.Equals(txtCapturaNombre) Then 
                If Not String.IsNullOrEmpty(txtCapturaNombre.Text) Then
                    txtCapturaDescripcion.Focus()
                End If
            ElseIf sender.Equals(txtCapturaDescripcion) Then
                dtpCapturaFechaCreacion.Focus()
            ElseIf sender.Equals(dtpCapturaFechaCreacion) Then
                If IsDate(dtpCapturaFechaCreacion.Value) Then
                    dtpCapturaFechaVencimiento.Focus()
                End If
            ElseIf sender.Equals(dtpCapturaFechaVencimiento) Then
                If IsDate(dtpCapturaFechaVencimiento.Value) Then
                    btnCapturaGuardar.Focus()
                End If
            End If
            'ElseIf e.KeyData = Keys.Escape Then
            '    e.SuppressKeyPress = True
            '    SendKeys.Send("+({TAB})")
        End If

    End Sub

    Private Sub btnCapturaEliminar_Click(sender As Object, e As EventArgs) Handles btnCapturaEliminar.Click

        If (MessageBox.Show("Confirmas que deseas eliminar la actividad seleccionada?", "Confirmacion.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
            If (Me.opcionSeleccionada = OpcionActividades.Capturar) Then
                EliminarActividades()
            End If
        End If

    End Sub

    Private Sub tbActividades_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbActividades.SelectedIndexChanged

        If tbActividades.SelectedIndex = 0 Then
            Me.opcionSeleccionada = OpcionActividades.Capturar
            PonerFocoEnControl(txtCapturaId)
        Else
            Me.opcionSeleccionada = OpcionActividades.Resolver
            ComenzarCargarActividadesResueltas()
        End If

    End Sub

    Private Sub spResolverActividades_CellDoubleClick(sender As Object, e As FarPoint.Win.Spread.CellClickEventArgs) Handles spResolverActividades.CellDoubleClick

        ''If spResolverActividades.ActiveSheet.Cells(spResolverActividades.ActiveSheet.ActiveRowIndex, spResolverActividades.ActiveSheet.Columns("resolver").Index).Value Then
        ''    spResolverActividades.ActiveSheet.Cells(spResolverActividades.ActiveSheet.ActiveRowIndex, spResolverActividades.ActiveSheet.Columns("resolver").Index).Value = False
        ''    spResolverActividades.ActiveSheet.Rows(-1).BackColor = Color.White
        ''    spResolverActividades.ActiveSheet.Rows(spResolverActividades.ActiveSheet.ActiveRowIndex).BackColor = Color.White
        ''Else
        'spResolverActividades.ActiveSheet.Cells(spResolverActividades.ActiveSheet.ActiveRowIndex, spResolverActividades.ActiveSheet.Columns("resolver").Index).Value = True
        'spResolverActividades.ActiveSheet.Rows(0, spResolverActividades.ActiveSheet.Rows.Count - 1).BackColor = Color.White
        'spResolverActividades.ActiveSheet.Rows(spResolverActividades.ActiveSheet.ActiveRowIndex).BackColor = Color.GreenYellow
        ''End If
        'CargarActividadesResueltas()
        'PonerFocoEnControl(txtResolucionDescripcion)

    End Sub

    Private Sub spResolverActividades_CellClick(sender As Object, e As FarPoint.Win.Spread.CellClickEventArgs) Handles spResolverActividades.CellClick

        spResolverActividades.ActiveSheet.Rows(0, spResolverActividades.ActiveSheet.Rows.Count - 1).BackColor = Color.White
        spResolverActividades.ActiveSheet.Rows(e.Row).BackColor = Color.GreenYellow
        spResolverActividades.ActiveSheet.ActiveRowIndex = e.Row
        CargarActividadesResueltas()
        PonerFocoEnControl(txtResolucionMotivoRetraso)

    End Sub

    Private Sub btnResolucionGuardar_Click(sender As Object, e As EventArgs) Handles btnResolucionGuardar.Click

        GuardarEditarActividadesResueltas()

    End Sub

    Private Sub txtResolucionId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtResolucionMotivoRetraso.KeyDown, txtResolucionId.KeyDown, txtResolucionDescripcion.KeyDown, dtpResolucionFecha.KeyDown

        If e.KeyData = Keys.Enter Then
            e.SuppressKeyPress = True
            If sender.Equals(txtResolucionDescripcion) Then
                If Not String.IsNullOrEmpty(txtResolucionDescripcion.Text) Then
                    txtResolucionMotivoRetraso.Focus()
                End If
            ElseIf sender.Equals(txtResolucionMotivoRetraso) Then
                dtpResolucionFecha.Focus()
            ElseIf sender.Equals(dtpResolucionFecha) Then
                If IsDate(dtpResolucionFecha.Value) Then
                    btnResolucionGuardar.Focus()
                End If
            End If
        End If

    End Sub

    Private Sub btnCapturaGuardar_MouseHover(sender As Object, e As EventArgs) Handles btnCapturaGuardar.MouseHover

        AsignarTooltips("Guardar o Editar.")

    End Sub

    Private Sub btnCapturaEliminar_MouseHover(sender As Object, e As EventArgs) Handles btnCapturaEliminar.MouseHover

        AsignarTooltips("Eliminar.")

    End Sub

    Private Sub tpCapturarActividades_MouseHover(sender As Object, e As EventArgs) Handles tpCapturarActividades.MouseHover

        AsignarTooltips(String.Empty)

    End Sub

    Private Sub btnSalir_MouseHover(sender As Object, e As EventArgs) Handles btnSalir.MouseHover

        AsignarTooltips("Salir.")

    End Sub

    Private Sub btnResolucionGuardar_MouseHover(sender As Object, e As EventArgs) Handles btnResolucionGuardar.MouseHover

        AsignarTooltips("Guardar o Editar.")

    End Sub

    Private Sub tpResolverActividades_MouseHover(sender As Object, e As EventArgs) Handles tpResolverActividades.MouseHover

        AsignarTooltips(String.Empty)

    End Sub

    Private Sub btnCapturaFechaCreacionAnterior_Click(sender As Object, e As EventArgs) Handles btnCapturaFechaCreacionAnterior.Click

        dtpCapturaFechaCreacion.Value = dtpCapturaFechaCreacion.Value.AddDays(-1)

    End Sub

    Private Sub btnCapturaFechaCreacionSiguiente_Click(sender As Object, e As EventArgs) Handles btnCapturaFechaCreacionSiguiente.Click

        dtpCapturaFechaCreacion.Value = dtpCapturaFechaCreacion.Value.AddDays(1)

    End Sub

    Private Sub btnCapturaFechaVencimientoAnterior_Click(sender As Object, e As EventArgs) Handles btnCapturaFechaVencimientoAnterior.Click

        dtpCapturaFechaVencimiento.Value = dtpCapturaFechaVencimiento.Value.AddDays(-1)

    End Sub

    Private Sub btnCapturaFechaVencimientoSiguiente_Click(sender As Object, e As EventArgs) Handles btnCapturaFechaVencimientoSiguiente.Click

        dtpCapturaFechaVencimiento.Value = dtpCapturaFechaVencimiento.Value.AddDays(1)

    End Sub

    Private Sub btnResolucionFechaAnterior_Click(sender As Object, e As EventArgs) Handles btnResolucionFechaAnterior.Click

        dtpResolucionFecha.Value = dtpResolucionFecha.Value.AddDays(-1)

    End Sub

    Private Sub btnResolucionFechaSiguiente_Click(sender As Object, e As EventArgs) Handles btnResolucionFechaSiguiente.Click

        dtpResolucionFecha.Value = dtpResolucionFecha.Value.AddDays(1)

    End Sub

#End Region

#Region "Métodos"

#Region "Genericos"

    Private Sub Centrar()

        Me.CenterToScreen()
        'Me.Opacity = 0.97 'Está bien perro esto.  
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size

    End Sub

    Private Sub AsignarTooltips()

        Dim tp As New ToolTip()
        tp.AutoPopDelay = 5000
        tp.InitialDelay = 0
        tp.ReshowDelay = 100
        tp.ShowAlways = True
        tp.SetToolTip(Me.btnSalir, "Salir.")
        tp.SetToolTip(Me.btnCapturaGuardar, "Guardar o Editar.")
        tp.SetToolTip(Me.btnCapturaEliminar, "Eliminar.")
        tp.SetToolTip(Me.btnCapturaIdAnterior, "Id Anterior.")
        tp.SetToolTip(Me.btnCapturaIdSiguiente, "Id Siguiente.")
        tp.SetToolTip(Me.btnCapturaFechaCreacionAnterior, "Fecha Anterior.")
        tp.SetToolTip(Me.btnCapturaFechaCreacionSiguiente, "Fecha Siguiente.")
        tp.SetToolTip(Me.btnCapturaFechaVencimientoAnterior, "Fecha Anterior.")
        tp.SetToolTip(Me.btnCapturaFechaVencimientoSiguiente, "Fecha Siguiente.")
        tp.SetToolTip(Me.btnResolucionGuardar, "Guardar o Editar.")
        tp.SetToolTip(Me.spResolverActividades, "Click para Seleccionar una Actividad A Resolver.")

    End Sub

    Private Sub AsignarTooltips(ByVal texto As String)

        lblDescripcionTooltip.Text = texto

    End Sub

    Public Sub ControlarSpread(ByVal spread As FarPoint.Win.Spread.FpSpread)

        Dim valor1 As FarPoint.Win.Spread.InputMap
        Dim valor2 As FarPoint.Win.Spread.InputMap
        valor1 = spread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused)
        valor1.Put(New FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextColumnWrap)
        valor1 = spread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused)
        valor1.Put(New FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextColumnWrap)
        valor2 = spread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused)
        valor2.Put(New FarPoint.Win.Spread.Keystroke(Keys.Escape, Keys.None), FarPoint.Win.Spread.SpreadActions.None)
        valor2 = spread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused)
        valor2.Put(New FarPoint.Win.Spread.Keystroke(Keys.Escape, Keys.None), FarPoint.Win.Spread.SpreadActions.None)

    End Sub

    Private Sub CargarTiposDeDatos()

        tipoDoble.DecimalPlaces = 2
        tipoDoble.DecimalSeparator = "."
        tipoDoble.Separator = ","
        tipoDoble.ShowSeparator = True
        tipoEntero.DecimalPlaces = 0
        tipoEntero.Separator = ","
        tipoEntero.ShowSeparator = True

    End Sub

    Private Sub ConfigurarConexiones()

        Dim esPrueba As Boolean = False
        If (esPrueba) Then
            'baseDatos.CadenaConexionInformacion = "C:\\Berry-Agenda\\BD\\PODC\\Agenda.mdf"
            EntidadesActividades.BaseDatos.ECadenaConexionAgenda = "Agenda"
        Else
            Me.datosEmpresa.ObtenerParametrosInformacionEmpresa()
            Me.datosUsuario.ObtenerParametrosInformacionUsuario()
            EntidadesActividades.BaseDatos.ECadenaConexionAgenda = "Agenda" 'datosEmpresa.EDirectorio & "\\Agenda.mdf" 
        End If
        EntidadesActividades.BaseDatos.AbrirConexionAgenda()

    End Sub

    Private Sub CargarEncabezados()

        lblEncabezadoPrograma.Text = "Programa: " + Me.Text
        lblEncabezadoEmpresa.Text = "Empresa: " + datosEmpresa.ENombre
        lblEncabezadoUsuario.Text = "Usuario: " + datosUsuario.ENombre

    End Sub

    Private Sub PonerFocoEnControl(ByVal c As Control)

        c.Focus() 

    End Sub

#End Region

#Region "Captura de Actividades"

    Private Sub CargarIndiceActividades()

        Me.opcionSeleccionada = OpcionActividades.Capturar

    End Sub

    Private Sub CargarConsecutivoActividades()

        txtCapturaId.Text = actividades.ObtenerMaximo()

    End Sub

    Private Sub CargarActividades()

        Dim lista As New List(Of EntidadesActividades.Actividades)
        actividades.EId = LogicaActividades.Funciones.ValidarNumero(txtCapturaId.Text)
        lista = actividades.ObtenerListadoPorId()
        If lista.Count = 1 Then
            txtCapturaNombre.Text = lista(0).ENombre
            txtCapturaDescripcion.Text = lista(0).EDescripcion
            dtpCapturaFechaCreacion.Value = lista(0).EFechaCreacion
            dtpCapturaFechaVencimiento.Value = lista(0).EFechaVencimiento
            chkCapturaEsUrgente.Checked = lista(0).EEsUrgente
        Else
            LimpiarPantallaActividades()
        End If

    End Sub

    Private Sub GuardarEditarActividades()

        Dim id As Integer = LogicaActividades.Funciones.ValidarNumero(txtCapturaId.Text)
        Dim idUsuario As Integer = 1 'Me.IdUsuario ' TODO. Pendiente obtener de los parametros.
        Dim nombre As String = txtCapturaNombre.Text
        Dim descripcion As String = txtCapturaDescripcion.Text
        Dim fechaCreacion As Date = dtpCapturaFechaCreacion.Text
        Dim fechaVencimiento As Date = dtpCapturaFechaVencimiento.Text
        Dim esUrgente As Boolean = chkCapturaEsUrgente.Checked
        If (id > 0) And (Not String.IsNullOrEmpty(nombre)) And (IsDate(fechaCreacion)) And IsDate(fechaVencimiento) Then
            actividades.EId = id
            actividades.EIdUsuario = idUsuario
            actividades.ENombre = nombre
            actividades.EDescripcion = descripcion
            actividades.EFechaCreacion = fechaCreacion
            actividades.EFechaVencimiento = fechaVencimiento
            actividades.EEsUrgente = esUrgente
            Dim tieneActividades As Boolean = actividades.ValidarPorNumero()
            If tieneActividades Then
                actividades.Editar()
            Else
                actividades.Guardar()
            End If
            MsgBox("Guardado o editado finalizado.", MsgBoxStyle.ApplicationModal, "Finalizado.")
            CargarConsecutivoActividades()
            LimpiarPantallaActividades()
        End If

    End Sub

    Private Sub LimpiarPantallaActividades()

        txtCapturaNombre.Clear()
        txtCapturaDescripcion.Clear()
        dtpCapturaFechaCreacion.Value = Today
        dtpCapturaFechaVencimiento.Value = Today
        chkCapturaEsUrgente.Checked = False
        PonerFocoEnControl(txtCapturaId)
        Application.DoEvents()

    End Sub

    Private Sub EliminarActividades()

        Dim id As Integer = LogicaActividades.Funciones.ValidarNumero(txtCapturaId.Text)
        If (id > 0) Then
            actividades.EId = id
            actividades.Eliminar()
            CargarActividades()
        End If

    End Sub

#End Region

#Region "Resolucion de Actividades"

    Private Sub ComenzarCargarActividadesResueltas()

        FormatearSpreadGeneralActividadesResueltas()
        CargarActividadesResueltasSpread()

    End Sub

    Private Sub CargarActividadesResueltas()

        Dim fila As Integer = spResolverActividades.ActiveSheet.ActiveRowIndex
        If fila > 0 Then
            txtResolucionId.Text = spResolverActividades.ActiveSheet.Cells(fila, spResolverActividades.ActiveSheet.Columns("id").Index).Value
        End If

    End Sub

    Private Sub CargarActividadesResueltasSpread()

        Dim lista As New List(Of EntidadesActividades.Actividades)
        lista = actividades.ObtenerListadoSinResolucion()
        spResolverActividades.ActiveSheet.DataSource = lista 
        FormatearSpreadActividadesResueltas(spResolverActividades.ActiveSheet.Columns.Count)

    End Sub

    Private Sub GuardarEditarActividadesResueltas()

        Dim fila As Integer = spResolverActividades.ActiveSheet.ActiveRowIndex
        Dim id As Integer = LogicaActividades.Funciones.ValidarNumero(spResolverActividades.ActiveSheet.Cells(fila, spResolverActividades.ActiveSheet.Columns("id").Index).Value)
        Dim descripcion As String = txtResolucionDescripcion.Text
        Dim motivoRetraso As String = txtResolucionMotivoRetraso.Text
        Dim fechaResolucion As Date = dtpResolucionFecha.Text
        If (id > 0) And (Not String.IsNullOrEmpty(descripcion)) And IsDate(fechaResolucion) Then
            actividadesResueltas.EId = id
            actividadesResueltas.EDescripcionResolucion = descripcion
            actividadesResueltas.EMotivoRetraso = motivoRetraso
            actividadesResueltas.EFechaResolucion = fechaResolucion
            Dim tieneActividades As Boolean = actividadesResueltas.ValidarPorNumero()
            If tieneActividades Then
                actividadesResueltas.Editar()
            Else
                actividadesResueltas.Guardar()
            End If
            MsgBox("Guardado o editado finalizado.", MsgBoxStyle.ApplicationModal, "Finalizado.")
            CargarActividadesResueltasSpread()
            LimpiarPantallaActividadesResueltas()
        End If

    End Sub

    Private Sub FormatearSpreadGeneralActividadesResueltas()

        spResolverActividades.Reset() : Application.DoEvents()
        spResolverActividades.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Seashell
        ControlarSpread(spResolverActividades)
        spResolverActividades.Visible = True : Application.DoEvents()
        spResolverActividades.ActiveSheet.GrayAreaBackColor = Color.White : Application.DoEvents()
        spResolverActividades.Font = New Font("Microsoft Sans Serif", 14, FontStyle.Regular) : Application.DoEvents()
        spResolverActividades.ActiveSheet.Rows(-1).Height = 50 : Application.DoEvents()
        spResolverActividades.ActiveSheetIndex = 0 : Application.DoEvents()
        spResolverActividades.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        spResolverActividades.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded

    End Sub

    Private Sub FormatearSpreadActividadesResueltas(ByVal cantidadColumnas As Integer)

        spResolverActividades.ActiveSheet.ColumnHeader.Rows(0).Font = New Font("Microsoft Sans Serif", 14, FontStyle.Bold) : Application.DoEvents()
        Dim numeracion As Integer = 0
        spResolverActividades.ActiveSheet.Columns.Count = cantidadColumnas + 1
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "idUsuario" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "nombre" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "descripcion" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "fechaCreacion" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "fechaVencimiento" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "esUrgente" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "resolver" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns("id").Width = 100 : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("nombre").Width = 300 : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("descripcion").Width = 500 : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("fechaCreacion").Width = 150 : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("fechaVencimiento").Width = 150 : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("esUrgente").Width = 130 : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("resolver").Width = 130 : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("esUrgente").CellType = tipoBooleano : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("resolver").CellType = tipoBooleano : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("nombre").HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Justify : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("descripcion").HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Justify : Application.DoEvents()
        spResolverActividades.ActiveSheet.ColumnHeader.Cells(0, spResolverActividades.ActiveSheet.Columns("id").Index).Value = "Id".ToUpper : Application.DoEvents()
        spResolverActividades.ActiveSheet.ColumnHeader.Cells(0, spResolverActividades.ActiveSheet.Columns("nombre").Index).Value = "Nombre".ToUpper : Application.DoEvents()
        spResolverActividades.ActiveSheet.ColumnHeader.Cells(0, spResolverActividades.ActiveSheet.Columns("descripcion").Index).Value = "Descripción".ToUpper : Application.DoEvents()
        spResolverActividades.ActiveSheet.ColumnHeader.Cells(0, spResolverActividades.ActiveSheet.Columns("fechaCreacion").Index).Value = "Fecha de Creación".ToUpper : Application.DoEvents()
        spResolverActividades.ActiveSheet.ColumnHeader.Cells(0, spResolverActividades.ActiveSheet.Columns("fechaVencimiento").Index).Value = "Fecha de Vencimiento".ToUpper : Application.DoEvents()
        spResolverActividades.ActiveSheet.ColumnHeader.Cells(0, spResolverActividades.ActiveSheet.Columns("esUrgente").Index).Value = "Es Urgente?".ToUpper : Application.DoEvents()
        spResolverActividades.ActiveSheet.ColumnHeader.Cells(0, spResolverActividades.ActiveSheet.Columns("resolver").Index).Value = "Resolver?".ToUpper : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("idUsuario").Visible = False : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("resolver").Visible = False : Application.DoEvents()
        spResolverActividades.ActiveSheet.ColumnHeader.Rows(0).Height = 45 : Application.DoEvents()
        spResolverActividades.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect

    End Sub

    Private Sub ControlarSpreadActividadesResueltasEnter()

        Dim columnaActiva As Integer = spResolverActividades.ActiveSheet.ActiveColumnIndex
        ' Guardar o editar. 
        If (spResolverActividades.ActiveSheet.ActiveColumnIndex = spResolverActividades.ActiveSheet.Columns.Count - 1) Then
            spResolverActividades.ActiveSheet.AddRows(spResolverActividades.ActiveSheet.Rows.Count, 1)
            Dim filaActiva As Integer = spResolverActividades.ActiveSheet.ActiveRowIndex
            If (Me.opcionSeleccionada = OpcionActividades.Capturar) Then
                'GuardarEditarActividadesResueltas()
            ElseIf (Me.opcionSeleccionada = OpcionActividades.Resolver) Then
                'GuardarEditarEmpresas()
            End If
        End If

    End Sub

    Private Sub EliminarActividadesResueltas()

        Dim fila As Integer = spResolverActividades.ActiveSheet.ActiveRowIndex
        Dim id As String = spResolverActividades.ActiveSheet.Cells(fila, spResolverActividades.ActiveSheet.Columns("id").Index).Value
        If (Not String.IsNullOrEmpty(id)) Then
            actividades.EId = LogicaActividades.Funciones.ValidarNumero(id)
            actividades.Eliminar()
            'CargarActividades()
        End If

    End Sub

    Private Sub LimpiarPantallaActividadesResueltas()

        txtResolucionId.Clear()
        txtResolucionDescripcion.Clear()
        txtResolucionMotivoRetraso.Clear() 
        dtpResolucionFecha.Value = Today
        spResolverActividades.ActiveSheet.Rows(0, spResolverActividades.ActiveSheet.Rows.Count - 1).BackColor = Color.White
        Application.DoEvents()

    End Sub

#End Region

#End Region

#Region "Clases"

    Public Enum OpcionActividades

        Capturar = 1
        Resolver = 2

    End Enum

#End Region

End Class