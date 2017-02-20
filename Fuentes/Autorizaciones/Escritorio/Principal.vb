Public Class Principal

    Dim actividadesExternas As New EntidadesActividades.ActividadesExternas
    Dim areas As New EntidadesActividades.Areas
    Dim usuarios As New EntidadesActividades.Usuarios
    Public datosEmpresa As New LogicaActividades.DatosEmpresa()
    Public datosUsuario As New LogicaActividades.DatosUsuario()
    Public datosArea As New LogicaActividades.DatosArea()
    Public tipoTexto As New FarPoint.Win.Spread.CellType.TextCellType()
    Public tipoEntero As New FarPoint.Win.Spread.CellType.NumberCellType()
    Public tipoDoble As New FarPoint.Win.Spread.CellType.NumberCellType()
    Public tipoPorcentaje As New FarPoint.Win.Spread.CellType.PercentCellType()
    Public tipoHora As New FarPoint.Win.Spread.CellType.DateTimeCellType()
    Public tipoFecha As New FarPoint.Win.Spread.CellType.DateTimeCellType()
    Public tipoBooleano As New FarPoint.Win.Spread.CellType.CheckBoxCellType()

    Public opcionSeleccionada As Integer = 0
    Public pintado As Boolean = False

#Region "Eventos"

    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
         
        Centrar()
        AsignarTooltips()
        ConfigurarConexiones()
        CargarEncabezados()  
        CargarTiposDeDatos()
        CargarComboAreas()
        CargarComboUsuarios()
        CargarComboAreasDestino()
        CargarComboUsuariosDestino()
        ComenzarCargarAutorizaciones()

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        Application.Exit()

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Editar()

    End Sub

    Private Sub spAutorizaciones_CellClick(sender As Object, e As FarPoint.Win.Spread.CellClickEventArgs) Handles spAutorizaciones.CellClick

        Dim filas As Integer = spAutorizaciones.ActiveSheet.Rows.Count
        If filas > 0 Then 
            If spAutorizaciones.ActiveSheet.Cells(e.Row, spAutorizaciones.ActiveSheet.Columns("autorizar").Index).Value Then
                spAutorizaciones.ActiveSheet.Rows(e.Row).BackColor = Color.White
                spAutorizaciones.ActiveSheet.Cells(e.Row, spAutorizaciones.ActiveSheet.Columns("autorizar").Index).Value = False
            Else
                spAutorizaciones.ActiveSheet.Rows(e.Row).BackColor = Color.GreenYellow
                spAutorizaciones.ActiveSheet.Cells(e.Row, spAutorizaciones.ActiveSheet.Columns("autorizar").Index).Value = True
            End If 
        End If

    End Sub

    Private Sub btnGuardar_MouseHover(sender As Object, e As EventArgs) Handles btnGuardar.MouseHover

        AsignarTooltips("Guardar.")

    End Sub

    Private Sub btnSalir_MouseHover(sender As Object, e As EventArgs) Handles btnSalir.MouseHover

        AsignarTooltips("Salir.")

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
        tp.SetToolTip(Me.btnGuardar, "Guardar o Editar.")
        tp.SetToolTip(Me.spAutorizaciones, "Click para Seleccionar una Actividad a Resolver.")

    End Sub

    Private Sub AsignarTooltips(ByVal texto As String)

        lblDescripcionTooltip.Text = texto

    End Sub

    Public Sub ControlarSpreadEnter(ByVal spread As FarPoint.Win.Spread.FpSpread)

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
            EntidadesActividades.BaseDatos.ECadenaConexionCatalogo = "Catalogos"
            EntidadesActividades.BaseDatos.ECadenaConexionInformacion = "Informacion"
            Me.datosUsuario.EId = 1
            Me.datosUsuario.EIdArea = 1
            Me.datosEmpresa.EId = 1
        Else
            Me.datosEmpresa.ObtenerParametrosInformacionEmpresa()
            Me.datosUsuario.ObtenerParametrosInformacionUsuario()
            Me.datosArea.ObtenerParametrosInformacionArea()
            'EntidadesActividades.BaseDatos.ECadenaConexionAgenda = datosEmpresa.EDirectorio & "\\Agenda.mdf"
            EntidadesActividades.BaseDatos.ECadenaConexionAgenda = "Agenda"
            EntidadesActividades.BaseDatos.ECadenaConexionCatalogo = "Catalogos"
            EntidadesActividades.BaseDatos.ECadenaConexionInformacion = "Informacion"
        End If
        EntidadesActividades.BaseDatos.AbrirConexionAgenda()
        EntidadesActividades.BaseDatos.AbrirConexionCatalogo()
        EntidadesActividades.BaseDatos.AbrirConexionInformacion()

    End Sub

    Private Sub CargarEncabezados()

        lblEncabezadoPrograma.Text = "Programa: " + Me.Text
        lblEncabezadoEmpresa.Text = "Empresa: " + datosEmpresa.ENombre
        lblEncabezadoUsuario.Text = "Usuario: " + datosUsuario.ENombre
        lblEncabezadoArea.Text = "Area: " + datosArea.ENombre

    End Sub

    Private Sub PonerFocoEnControl(ByVal c As Control)

        c.Focus()

    End Sub

#End Region

#Region "Todos"

    Private Sub ComenzarCargarAutorizaciones()

        FormatearSpreadGeneral()
        CargarAutorizacionesSpread()

    End Sub

    Private Sub CargarAutorizacionesSpread()

        ' Actividades externas.
        'spAutorizaciones.ActiveSheetIndex = 1
        Dim listaExterna As New List(Of EntidadesActividades.ActividadesExternas)
        If Me.pintado Then
            actividadesExternas.EIdArea = cbAreas.SelectedValue
            actividadesExternas.EIdUsuario = cbUsuarios.SelectedValue
            actividadesExternas.EIdAreaDestino = cbAreasDestino.SelectedValue
            actividadesExternas.EIdUsuarioDestino = cbUsuariosDestino.SelectedValue
        End If
        listaExterna = actividadesExternas.ObtenerListadoPendientesExternas()
        spAutorizaciones.ActiveSheet.DataSource = listaExterna
        FormatearSpreadAutorizacionesPendientesExternas(spAutorizaciones.ActiveSheet.Columns.Count)

    End Sub

    Private Sub FormatearSpreadGeneral()

        spAutorizaciones.Reset() : Application.DoEvents()
        'spAutorizaciones.Sheets.Count = 2
        'spAutorizaciones.Sheets(0).SheetName = "Internas"
        spAutorizaciones.Sheets(0).SheetName = "Externas"
        spAutorizaciones.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Seashell
        'ControlarSpreadEnter(spAutorizaciones)
        spAutorizaciones.Visible = True : Application.DoEvents()
        spAutorizaciones.Font = New Font("Microsoft Sans Serif", 14, FontStyle.Regular) : Application.DoEvents()
        spAutorizaciones.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        spAutorizaciones.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded

    End Sub

    Private Sub FormatearSpreadAutorizacionesPendientesExternas(ByVal cantidadColumnas As Integer)

        'spAutorizaciones.ActiveSheetIndex = 1
        spAutorizaciones.ActiveSheet.GrayAreaBackColor = Color.White : Application.DoEvents()
        spAutorizaciones.ActiveSheet.ColumnHeader.Rows(0).Height = 65 : Application.DoEvents()
        spAutorizaciones.ActiveSheet.Rows(-1).Height = 50 : Application.DoEvents()
        spAutorizaciones.ActiveSheet.ColumnHeader.Rows(0).Font = New Font("Microsoft Sans Serif", 14, FontStyle.Bold) : Application.DoEvents()
        Dim numeracion As Integer = 0
        spAutorizaciones.ActiveSheet.Columns.Count = cantidadColumnas + 2 ' Es una columna para autorizar y otra para rechazar.
        spAutorizaciones.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        spAutorizaciones.ActiveSheet.Columns(numeracion).Tag = "idArea" : numeracion += 1
        spAutorizaciones.ActiveSheet.Columns(numeracion).Tag = "nombreArea" : numeracion += 1
        spAutorizaciones.ActiveSheet.Columns(numeracion).Tag = "idUsuario" : numeracion += 1
        spAutorizaciones.ActiveSheet.Columns(numeracion).Tag = "nombreUsuario" : numeracion += 1
        spAutorizaciones.ActiveSheet.Columns(numeracion).Tag = "idAreaDestino" : numeracion += 1
        spAutorizaciones.ActiveSheet.Columns(numeracion).Tag = "nombreAreaDestino" : numeracion += 1
        spAutorizaciones.ActiveSheet.Columns(numeracion).Tag = "idUsuarioDestino" : numeracion += 1
        spAutorizaciones.ActiveSheet.Columns(numeracion).Tag = "nombreUsuarioDestino" : numeracion += 1
        spAutorizaciones.ActiveSheet.Columns(numeracion).Tag = "nombre" : numeracion += 1
        spAutorizaciones.ActiveSheet.Columns(numeracion).Tag = "descripcion" : numeracion += 1
        spAutorizaciones.ActiveSheet.Columns(numeracion).Tag = "fechaCreacion" : numeracion += 1
        spAutorizaciones.ActiveSheet.Columns(numeracion).Tag = "fechaVencimiento" : numeracion += 1
        spAutorizaciones.ActiveSheet.Columns(numeracion).Tag = "esUrgente" : numeracion += 1
        spAutorizaciones.ActiveSheet.Columns(numeracion).Tag = "esExterna" : numeracion += 1
        spAutorizaciones.ActiveSheet.Columns(numeracion).Tag = "esAutorizado" : numeracion += 1
        spAutorizaciones.ActiveSheet.Columns(numeracion).Tag = "esRechazado" : numeracion += 1
        spAutorizaciones.ActiveSheet.Columns(numeracion).Tag = "autorizar" : numeracion += 1
        spAutorizaciones.ActiveSheet.Columns(numeracion).Tag = "rechazar" : numeracion += 1
        spAutorizaciones.ActiveSheet.Columns("id").Width = 80 : Application.DoEvents()
        spAutorizaciones.ActiveSheet.Columns("idArea").Width = 90 : Application.DoEvents()
        spAutorizaciones.ActiveSheet.Columns("nombreArea").Width = 110 : Application.DoEvents()
        spAutorizaciones.ActiveSheet.Columns("idUsuario").Width = 100 : Application.DoEvents()
        spAutorizaciones.ActiveSheet.Columns("nombreUsuario").Width = 110 : Application.DoEvents()
        spAutorizaciones.ActiveSheet.Columns("idAreaDestino").Width = 90 : Application.DoEvents()
        spAutorizaciones.ActiveSheet.Columns("nombreAreaDestino").Width = 110 : Application.DoEvents()
        spAutorizaciones.ActiveSheet.Columns("idUsuarioDestino").Width = 100 : Application.DoEvents()
        spAutorizaciones.ActiveSheet.Columns("nombreUsuarioDestino").Width = 110 : Application.DoEvents()
        spAutorizaciones.ActiveSheet.Columns("nombre").Width = 300 : Application.DoEvents()
        spAutorizaciones.ActiveSheet.Columns("descripcion").Width = 500 : Application.DoEvents()
        spAutorizaciones.ActiveSheet.Columns("fechaCreacion").Width = 160 : Application.DoEvents()
        spAutorizaciones.ActiveSheet.Columns("fechaVencimiento").Width = 170 : Application.DoEvents()
        spAutorizaciones.ActiveSheet.Columns("esUrgente").Width = 130 : Application.DoEvents()
        spAutorizaciones.ActiveSheet.Columns("autorizar").Width = 130 : Application.DoEvents()
        spAutorizaciones.ActiveSheet.Columns("rechazar").Width = 130 : Application.DoEvents()
        spAutorizaciones.ActiveSheet.Columns("esUrgente").CellType = tipoBooleano : Application.DoEvents()
        spAutorizaciones.ActiveSheet.Columns("autorizar").CellType = tipoBooleano : Application.DoEvents()
        spAutorizaciones.ActiveSheet.Columns("rechazar").CellType = tipoBooleano : Application.DoEvents()
        spAutorizaciones.ActiveSheet.Columns("nombre").HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Justify : Application.DoEvents()
        spAutorizaciones.ActiveSheet.Columns("descripcion").HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Justify : Application.DoEvents()
        spAutorizaciones.ActiveSheet.ColumnHeader.Cells(0, spAutorizaciones.ActiveSheet.Columns("id").Index).Value = "Id".ToUpper : Application.DoEvents()
        spAutorizaciones.ActiveSheet.ColumnHeader.Cells(0, spAutorizaciones.ActiveSheet.Columns("idArea").Index).Value = "Id Area".ToUpper : Application.DoEvents()
        spAutorizaciones.ActiveSheet.ColumnHeader.Cells(0, spAutorizaciones.ActiveSheet.Columns("nombreArea").Index).Value = "Nombre Area".ToUpper : Application.DoEvents()
        spAutorizaciones.ActiveSheet.ColumnHeader.Cells(0, spAutorizaciones.ActiveSheet.Columns("idUsuario").Index).Value = "Id Usuario".ToUpper : Application.DoEvents()
        spAutorizaciones.ActiveSheet.ColumnHeader.Cells(0, spAutorizaciones.ActiveSheet.Columns("nombreUsuario").Index).Value = "Nombre Usuario".ToUpper : Application.DoEvents()
        spAutorizaciones.ActiveSheet.ColumnHeader.Cells(0, spAutorizaciones.ActiveSheet.Columns("idAreaDestino").Index).Value = "Id Area Destino".ToUpper : Application.DoEvents()
        spAutorizaciones.ActiveSheet.ColumnHeader.Cells(0, spAutorizaciones.ActiveSheet.Columns("nombreAreaDestino").Index).Value = "Nombre Area Destino".ToUpper : Application.DoEvents()
        spAutorizaciones.ActiveSheet.ColumnHeader.Cells(0, spAutorizaciones.ActiveSheet.Columns("idUsuarioDestino").Index).Value = "Id Usuario Destino".ToUpper : Application.DoEvents()
        spAutorizaciones.ActiveSheet.ColumnHeader.Cells(0, spAutorizaciones.ActiveSheet.Columns("nombreUsuarioDestino").Index).Value = "Nombre Usuario Destino".ToUpper : Application.DoEvents()
        spAutorizaciones.ActiveSheet.ColumnHeader.Cells(0, spAutorizaciones.ActiveSheet.Columns("nombre").Index).Value = "Nombre".ToUpper : Application.DoEvents()
        spAutorizaciones.ActiveSheet.ColumnHeader.Cells(0, spAutorizaciones.ActiveSheet.Columns("descripcion").Index).Value = "Descripción".ToUpper : Application.DoEvents()
        spAutorizaciones.ActiveSheet.ColumnHeader.Cells(0, spAutorizaciones.ActiveSheet.Columns("fechaCreacion").Index).Value = "Fecha de Creación".ToUpper : Application.DoEvents()
        spAutorizaciones.ActiveSheet.ColumnHeader.Cells(0, spAutorizaciones.ActiveSheet.Columns("fechaVencimiento").Index).Value = "Fecha de Vencimiento".ToUpper : Application.DoEvents()
        spAutorizaciones.ActiveSheet.ColumnHeader.Cells(0, spAutorizaciones.ActiveSheet.Columns("esUrgente").Index).Value = "Es Urgente?".ToUpper : Application.DoEvents()
        spAutorizaciones.ActiveSheet.ColumnHeader.Cells(0, spAutorizaciones.ActiveSheet.Columns("autorizar").Index).Value = "Autorizar".ToUpper : Application.DoEvents()
        spAutorizaciones.ActiveSheet.ColumnHeader.Cells(0, spAutorizaciones.ActiveSheet.Columns("rechazar").Index).Value = "Rechazar".ToUpper : Application.DoEvents()
        spAutorizaciones.ActiveSheet.Columns("esExterna").Visible = False : Application.DoEvents()
        spAutorizaciones.ActiveSheet.Columns("esAutorizado").Visible = False : Application.DoEvents()
        spAutorizaciones.ActiveSheet.Columns("esRechazado").Visible = False : Application.DoEvents()
        spAutorizaciones.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect

    End Sub

    Private Sub Editar()

        For fila = 0 To spAutorizaciones.ActiveSheet.Rows.Count - 1 
            Dim id As Integer = spAutorizaciones.ActiveSheet.Cells(fila, spAutorizaciones.ActiveSheet.Columns("id").Index).Value 'LogicaActividadesExternas.Funciones.ValidarNumero(txtCapturaId.Text)
            Dim idArea As Integer = spAutorizaciones.ActiveSheet.Cells(fila, spAutorizaciones.ActiveSheet.Columns("idArea").Index).Value
            Dim idUsuario As Integer = spAutorizaciones.ActiveSheet.Cells(fila, spAutorizaciones.ActiveSheet.Columns("idUsuario").Index).Value
            Dim idAreaDestino As Integer = spAutorizaciones.ActiveSheet.Cells(fila, spAutorizaciones.ActiveSheet.Columns("idAreaDestino").Index).Value
            Dim idUsuarioDestino As Integer = spAutorizaciones.ActiveSheet.Cells(fila, spAutorizaciones.ActiveSheet.Columns("idUsuarioDestino").Index).Value
            Dim autorizar As Boolean = spAutorizaciones.ActiveSheet.Cells(fila, spAutorizaciones.ActiveSheet.Columns("autorizar").Index).Value
            Dim rechazar As Boolean = spAutorizaciones.ActiveSheet.Cells(fila, spAutorizaciones.ActiveSheet.Columns("rechazar").Index).Value
            If (id > 0) And (idArea > 0) And (idUsuario > 0) And (idAreaDestino > 0) And (idUsuarioDestino > 0) And (autorizar Or rechazar) Then
                actividadesExternas.EId = id
                actividadesExternas.EIdArea = idArea
                actividadesExternas.EIdUsuario = idUsuario
                'actividadesExternas.EIdAreaDestino = idAreaDestino
                'actividadesExternas.EIdUsuarioDestino = idUsuarioDestino
                actividadesExternas.EEsAutorizado = autorizar
                actividadesExternas.EEsRechazado = rechazar
                actividadesExternas.Editar()
                MsgBox("Editado finalizado.", MsgBoxStyle.ApplicationModal, "Finalizado.")
                ComenzarCargarAutorizaciones()
            End If
        Next

    End Sub
 
    Private Sub CargarComboAreas()

        Dim lista As New List(Of EntidadesActividades.Areas)
        lista = areas.ObtenerListado()
        cbAreas.DataSource = lista
        cbAreas.ValueMember = "EId"
        cbAreas.DisplayMember = "ENombre"

    End Sub

    Private Sub CargarComboUsuarios()

        Try
            Dim idArea As Integer = cbAreas.SelectedValue()
            Dim lista As New List(Of EntidadesActividades.Usuarios)
            usuarios.EIdEmpresa = datosEmpresa.EId
            usuarios.EIdArea = idArea
            lista = usuarios.ObtenerListadoDeEmpresa()
            cbUsuarios.DataSource = lista
            cbUsuarios.ValueMember = "EId"
            cbUsuarios.DisplayMember = "ENombre"
        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Private Sub CargarComboAreasDestino()

        Dim lista As New List(Of EntidadesActividades.Areas)
        lista = areas.ObtenerListado()
        cbAreasDestino.DataSource = lista
        cbAreasDestino.ValueMember = "EId"
        cbAreasDestino.DisplayMember = "ENombre"

    End Sub

    Private Sub CargarComboUsuariosDestino()

        Try
            Dim idArea As Integer = cbAreasDestino.SelectedValue()
            Dim lista As New List(Of EntidadesActividades.Usuarios)
            usuarios.EIdEmpresa = datosEmpresa.EId
            usuarios.EIdArea = idArea
            lista = usuarios.ObtenerListadoDeEmpresa()
            cbUsuariosDestino.DataSource = lista
            cbUsuariosDestino.ValueMember = "EId"
            cbUsuariosDestino.DisplayMember = "ENombre"
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

#End Region
     
    Private Sub cbAreas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAreas.SelectedIndexChanged
         
        If cbAreas.Items.Count > 1 Then
            If cbAreas.SelectedIndex > 0 Then
                CargarComboUsuarios()
            Else 
                ComenzarCargarAutorizaciones()
            End If
        End If

    End Sub

    Private Sub cbAreasDestino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAreasDestino.SelectedIndexChanged

        If cbAreasDestino.Items.Count > 1 Then
            If cbAreasDestino.SelectedIndex > 0 Then
                CargarComboUsuariosDestino()
            Else
                ComenzarCargarAutorizaciones()
            End If
        End If

    End Sub

    Private Sub cbUsuarios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbUsuarios.SelectedIndexChanged

        ComenzarCargarAutorizaciones()

    End Sub

    Private Sub cbUsuariosDestino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbUsuariosDestino.SelectedIndexChanged

        ComenzarCargarAutorizaciones()

    End Sub

    Private Sub Principal_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint

        Me.pintado = True

    End Sub

    Private Sub spAutorizaciones_CellDoubleClick(sender As Object, e As FarPoint.Win.Spread.CellClickEventArgs) Handles spAutorizaciones.CellDoubleClick

        Dim filas As Integer = spAutorizaciones.ActiveSheet.Rows.Count
        If filas > 0 Then
            If spAutorizaciones.ActiveSheet.Cells(e.Row, spAutorizaciones.ActiveSheet.Columns("rechazar").Index).Value Then
                spAutorizaciones.ActiveSheet.Rows(e.Row).BackColor = Color.White
                spAutorizaciones.ActiveSheet.Cells(e.Row, spAutorizaciones.ActiveSheet.Columns("rechazar").Index).Value = False
            Else
                spAutorizaciones.ActiveSheet.Rows(e.Row).BackColor = Color.OrangeRed
                spAutorizaciones.ActiveSheet.Cells(e.Row, spAutorizaciones.ActiveSheet.Columns("rechazar").Index).Value = True
            End If
        End If 

    End Sub
     
End Class