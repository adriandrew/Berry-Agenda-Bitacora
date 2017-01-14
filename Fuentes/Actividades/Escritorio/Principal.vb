Public Class Principal

    Dim actividades As New EntidadesActividades.Actividades
    Public datosEmpresa As New LogicaActividades.DatosEmpresa()
    Public tipoTexto As New FarPoint.Win.Spread.CellType.TextCellType()
    Public tipoEntero As New FarPoint.Win.Spread.CellType.NumberCellType()
    Public tipoDoble As New FarPoint.Win.Spread.CellType.NumberCellType()
    Public tipoPorcentaje As New FarPoint.Win.Spread.CellType.PercentCellType()
    Public tipoHora As New FarPoint.Win.Spread.CellType.DateTimeCellType()
    Public tipoFecha As New FarPoint.Win.Spread.CellType.DateTimeCellType()
    Public opcionSeleccionada As Integer = 0

#Region "Eventos"

    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Centrar()
        AsignarTooltips()
        ConfigurarConexiones()
        CargarEncabezados()
        CargarConsecutivoActividades()
        'ComenzarCargarActividades()
        'CargarTiposDeDatos() 

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

    Private Sub tbActividades_TabIndexChanged(sender As Object, e As EventArgs) Handles tbActividades.TabIndexChanged

        If tbActividades.TabIndex = 0 Then
            Me.opcionSeleccionada = OpcionActividades.Capturar
        Else
            Me.opcionSeleccionada = OpcionActividades.Resolver
        End If

    End Sub

    Private Sub Principal_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        PonerFoco()

    End Sub

    Private Sub btnCapturaGuardar_Click(sender As Object, e As EventArgs) Handles btnCapturaGuardar.Click

        GuardarEditarActividades()

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
                PonerFoco()
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
                PonerFoco()
            End If
        Else
            txtCapturaId.Clear()
        End If

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
        tp.SetToolTip(Me.btnCapturaGuardar, "Guardar.")
        tp.SetToolTip(Me.btnCapturaIdAnterior, "Id Anterior.")
        tp.SetToolTip(Me.btnCapturaIdSiguiente, "Id Siguiente.")

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

        Dim esPrueba As Boolean = True
        If (esPrueba) Then
            'baseDatos.CadenaConexionInformacion = "C:\\Berry-Agenda\\BD\\PODC\\Agenda.mdf"
            EntidadesActividades.BaseDatos.ECadenaConexionAgenda = "Agenda"
        Else
            Me.datosEmpresa.ObtenerParametrosInformacionEmpresa()
            EntidadesActividades.BaseDatos.ECadenaConexionAgenda = "Agenda" 'datosEmpresa.EDirectorio & "\\Agenda.mdf" 
        End If
        EntidadesActividades.BaseDatos.AbrirConexionAgenda()

    End Sub

    Private Sub CargarEncabezados()

        lblEncabezadoPrograma.Text = "Programa: " + Me.Text
        lblEncabezadoEmpresa.Text = "Empresa: " + datosEmpresa.ENombre

    End Sub

    Private Sub PonerFoco()

        txtCapturaNombre.Focus()

    End Sub

#End Region

#Region "Captura de Actividades"

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
        PonerFoco()

    End Sub

#End Region

#Region "Resolucion de Actividades"

    Private Sub ComenzarCargarActividadesResueltas()

        FormatearSpreadGeneralActividadesResueltas()
        CargarActividades()
        FormatearSpreadActividadesResueltas()

    End Sub

    Private Sub CargarActividadesResueltas()

        Dim lista As New List(Of EntidadesActividades.Actividades)
        lista = actividades.ObtenerListado()
        spResolverActividades.ActiveSheet.DataSource = lista
        spResolverActividades.ActiveSheet.Rows.Count += 1

    End Sub

    Private Sub GuardarEditarActividadesResueltas()

        Dim fila As Integer = spResolverActividades.ActiveSheet.ActiveRowIndex
        Dim id As Integer = spResolverActividades.ActiveSheet.Cells(fila, spResolverActividades.ActiveSheet.Columns("id").Index).Value
        Dim idUsuario As Integer = spResolverActividades.ActiveSheet.Cells(fila, spResolverActividades.ActiveSheet.Columns("idUsuario").Index).Value
        Dim nombre As String = spResolverActividades.ActiveSheet.Cells(fila, spResolverActividades.ActiveSheet.Columns("nombre").Index).Value
        Dim descripcion As String = spResolverActividades.ActiveSheet.Cells(fila, spResolverActividades.ActiveSheet.Columns("descripcion").Index).Value
        Dim fechaCreacion As Date = spResolverActividades.ActiveSheet.Cells(fila, spResolverActividades.ActiveSheet.Columns("fechaCreacion").Index).Value
        Dim fechaVencimiento As Date = spResolverActividades.ActiveSheet.Cells(fila, spResolverActividades.ActiveSheet.Columns("fechaVencimiento").Index).Value
        Dim esUrgente As Boolean = spResolverActividades.ActiveSheet.Cells(fila, spResolverActividades.ActiveSheet.Columns("esUrgente").Index).Value
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
        End If

    End Sub

    Private Sub FormatearSpreadGeneralActividadesResueltas()

        spResolverActividades.Reset() : Application.DoEvents()
        ControlarSpread(spResolverActividades)
        spResolverActividades.Visible = True : Application.DoEvents()
        spResolverActividades.ActiveSheet.GrayAreaBackColor = Color.White : Application.DoEvents()
        spResolverActividades.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold) : Application.DoEvents()
        spResolverActividades.ActiveSheet.Rows(-1).Height = 25 : Application.DoEvents()
        spResolverActividades.ActiveSheetIndex = 0 : Application.DoEvents()

    End Sub

    Private Sub FormatearSpreadActividadesResueltas()

        Dim numeracion As Integer = 0
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "nombre" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "clave" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns("id").Width = 100 : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("nombre").Width = 200 : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("clave").Width = 150 : Application.DoEvents()
        'spCapturarActividades.ActiveSheet.Columns("clave").CellType =
        spResolverActividades.ActiveSheet.ColumnHeader.Cells(0, spResolverActividades.ActiveSheet.Columns("id").Index).Value = "Id".ToUpper : Application.DoEvents()
        spResolverActividades.ActiveSheet.ColumnHeader.Cells(0, spResolverActividades.ActiveSheet.Columns("nombre").Index).Value = "Nombre".ToUpper : Application.DoEvents()
        spResolverActividades.ActiveSheet.ColumnHeader.Cells(0, spResolverActividades.ActiveSheet.Columns("clave").Index).Value = "Clave".ToUpper : Application.DoEvents()

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

#End Region

#End Region

#Region "Clases"

    Public Enum OpcionActividades

        Capturar = 1
        Resolver = 2

    End Enum

#End Region

    Private Sub txtCapturaId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCapturaNombre.KeyDown, txtCapturaId.KeyDown, txtCapturaDescripcion.KeyDown, dtpCapturaFechaVencimiento.KeyDown, dtpCapturaFechaCreacion.KeyDown

        If e.KeyData = Keys.Enter Then
            e.SuppressKeyPress = True
            If sender.Equals(txtCapturaId) Then
                'e.SuppressKeyPress = True
                If IsNumeric(txtCapturaId.Text) Then
                    If CInt(txtCapturaId.Text) > 0 Then
                        CargarActividades()
                        txtCapturaNombre.Focus()
                    End If
                End If
            ElseIf sender.Equals(txtCapturaNombre) Then
                'e.SuppressKeyPress = True
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

End Class