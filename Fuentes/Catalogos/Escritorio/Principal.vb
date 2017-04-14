Imports System.IO
Imports System.ComponentModel

Public Class Principal

    Dim usuarios As New EntidadesCatalogos.Usuarios
    Dim areas As New EntidadesCatalogos.Areas
    Dim correos As New EntidadesCatalogos.Correos
    Dim correosUsuarios As New EntidadesCatalogos.CorreosUsuarios
    Public datosEmpresa As New LogicaCatalogos.DatosEmpresa()
    Public datosUsuario As New LogicaCatalogos.DatosUsuario()
    Public datosArea As New LogicaCatalogos.DatosArea()
    Public tipoTexto As New FarPoint.Win.Spread.CellType.TextCellType()
    Public tipoEntero As New FarPoint.Win.Spread.CellType.NumberCellType()
    Public tipoDoble As New FarPoint.Win.Spread.CellType.NumberCellType()
    Public tipoPorcentaje As New FarPoint.Win.Spread.CellType.PercentCellType()
    Public tipoHora As New FarPoint.Win.Spread.CellType.DateTimeCellType()
    Public tipoFecha As New FarPoint.Win.Spread.CellType.DateTimeCellType()
    Public opcionSeleccionada As Integer = 0
    Dim ejecutarProgramaPrincipal As New ProcessStartInfo()
    Public estaCerrando As Boolean = False

    Public esPrueba As Boolean = False

#Region "Eventos"

    Private Sub Principal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        Me.Cursor = Cursors.WaitCursor
        Dim nombrePrograma As String = "PrincipalBerry"
        AbrirPrograma(nombrePrograma, True)
        System.Threading.Thread.Sleep(5000)
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Principal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Me.estaCerrando = True
        Desvanecer()

    End Sub

    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Centrar()
        AsignarTooltips()
        ConfigurarConexiones()
        CargarEncabezados()
        SeleccionoAreas()
        ComenzarCargarAreas()
        CargarTiposDeDatos()

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        Application.Exit()

    End Sub

    Private Sub miArea_Click(sender As Object, e As EventArgs) Handles miArea.Click

        SeleccionoAreas()
        ComenzarCargarAreas()

    End Sub

    Private Sub miCorreo_Click(sender As Object, e As EventArgs) Handles miCorreo.Click

        SeleccionoCorreos()

    End Sub

    Private Sub spCatalogos_DialogKey(sender As Object, e As FarPoint.Win.Spread.DialogKeyEventArgs) Handles spCatalogos.DialogKey

        If (e.KeyData = Keys.Enter) Then
            ControlarSpreadEnter()
        End If

    End Sub

    Private Sub spCatalogos_KeyDown(sender As Object, e As KeyEventArgs) Handles spCatalogos.KeyDown

        If e.KeyData = Keys.F5 Then ' Abrir catalogos.
            If (spCatalogos.ActiveSheet.ActiveColumnIndex = spCatalogos.ActiveSheet.Columns("idUsuario").Index) Or (spCatalogos.ActiveSheet.ActiveColumnIndex = spCatalogos.ActiveSheet.Columns("nombreUsuario").Index) Then
                spCatalogos.Enabled = False
                CargarCatalogoUsuarios()
                FormatearSpreadCatalogoUsuarios(False)
                spCatalogos2.Focus()
            End If
        ElseIf e.KeyData = Keys.F6 Then ' Eliminar un registro.
            If (MessageBox.Show("Confirmas que deseas eliminar el registro seleccionado?", "Confirmación.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                Dim fila As Integer = spCatalogos.ActiveSheet.ActiveRowIndex
                'If (Me.opcionSeleccionada = Reportes.Areas) Then
                spCatalogos.ActiveSheet.Rows.Remove(fila, 1)
                'ElseIf (Me.opcionSeleccionada = Reportes.Correos) Then
                '    spCatalogos.ActiveSheet.Rows.Remove(fila, 1)
                'End If
            End If
        ElseIf (e.KeyData = Keys.Enter) Then
            ControlarSpreadEnter()
        End If

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If (Me.opcionSeleccionada = Reportes.Areas) Then
            GuardarEditarAreas()
        ElseIf (Me.opcionSeleccionada = Reportes.Correos) Then
            GuardarEditarCorreos()
        End If

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        If (Me.opcionSeleccionada = Reportes.Areas) Then
            EliminarAreas()
        ElseIf (Me.opcionSeleccionada = Reportes.Correos) Then
            EliminarCorreos()
        End If

    End Sub

    Private Sub btnGuardar_MouseHover(sender As Object, e As EventArgs) Handles btnGuardar.MouseHover

        AsignarTooltips("Guardar.")

    End Sub

    Private Sub btnEliminar_MouseHover(sender As Object, e As EventArgs) Handles btnEliminar.MouseHover

        AsignarTooltips("Eliminar.")

    End Sub

    Private Sub btnSalir_MouseHover(sender As Object, e As EventArgs) Handles btnSalir.MouseHover

        AsignarTooltips("Salir.")

    End Sub

    Private Sub pnlEncabezado_MouseHover(sender As Object, e As EventArgs) Handles pnlPie.MouseHover, pnlEncabezado.MouseHover, pnlCuerpo.MouseHover

        AsignarTooltips(String.Empty)

    End Sub

    Private Sub spCatalogos2_CellClick(sender As Object, e As FarPoint.Win.Spread.CellClickEventArgs) Handles spCatalogos2.CellClick

        Dim fila As Integer = e.Row
        spCatalogos.ActiveSheet.Cells(spCatalogos.ActiveSheet.ActiveRowIndex, spCatalogos.ActiveSheet.Columns("idUsuario").Index).Text = spCatalogos2.ActiveSheet.Cells(fila, spCatalogos2.ActiveSheet.Columns("id").Index).Text
        spCatalogos.ActiveSheet.Cells(spCatalogos.ActiveSheet.ActiveRowIndex, spCatalogos.ActiveSheet.Columns("nombreUsuario").Index).Text = spCatalogos2.ActiveSheet.Cells(fila, spCatalogos2.ActiveSheet.Columns("nombre").Index).Text

    End Sub

    Private Sub spCatalogos2_CellDoubleClick(sender As Object, e As FarPoint.Win.Spread.CellClickEventArgs) Handles spCatalogos2.CellDoubleClick

        VolverFocoCatalogos()

    End Sub

    Private Sub spCatalogos2_KeyDown(sender As Object, e As KeyEventArgs) Handles spCatalogos2.KeyDown

        If e.KeyCode = Keys.Escape Then
            VolverFocoCatalogos()
        End If

    End Sub

    Private Sub temporizador_Tick(sender As Object, e As EventArgs) Handles temporizador.Tick

        If (Me.estaCerrando) Then
            Desvanecer()
        End If

    End Sub

#End Region

#Region "Metodos"

#Region "Genericos"

    Private Sub Desvanecer()

        temporizador.Interval = 10
        temporizador.Enabled = True
        temporizador.Start()
        If (Me.Opacity > 0) Then
            Me.Opacity -= 0.25 : Application.DoEvents()
        Else
            temporizador.Enabled = False
            temporizador.Stop()
        End If

    End Sub

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

    End Sub

    Private Sub AsignarTooltips(ByVal texto As String)

        lblDescripcionTooltip.Text = texto

    End Sub

    Private Sub ConfigurarConexiones()

        If (Me.esPrueba) Then
            'EntidadesCatalogos.BaseDatos.ECadenaConexionCatalogo = "C:\\Berry-Agenda\\BD\\PODC\\Catalogos.mdf"
            LogicaCatalogos.DatosEmpresaPrincipal.instanciaSql = "ANDREW-MAC\SQLEXPRESS"
            LogicaCatalogos.DatosEmpresaPrincipal.usuarioSql = "AdminBerry"
            LogicaCatalogos.DatosEmpresaPrincipal.contrasenaSql = "@berry"
            datosEmpresa.EId = 1
        Else
            'EntidadesCatalogos.BaseDatos.ECadenaConexionCatalogo = datosEmpresa.EDirectorio & "\\Catalogos.mdf" 
            LogicaCatalogos.DatosEmpresaPrincipal.ObtenerParametrosInformacionEmpresa()
            Me.datosEmpresa.ObtenerParametrosInformacionEmpresa()
            Me.datosUsuario.ObtenerParametrosInformacionUsuario()
            Me.datosArea.ObtenerParametrosInformacionArea()
        End If
        EntidadesCatalogos.BaseDatos.ECadenaConexionCatalogo = "Catalogos"
        EntidadesCatalogos.BaseDatos.ECadenaConexionInformacion = "Informacion"
        EntidadesCatalogos.BaseDatos.AbrirConexionCatalogo()
        EntidadesCatalogos.BaseDatos.AbrirConexionInformacion()

    End Sub

    Private Sub CargarEncabezados()

        lblEncabezadoPrograma.Text = "Programa: " + Me.Text
        lblEncabezadoEmpresa.Text = "Empresa: " + datosEmpresa.ENombre
        lblEncabezadoUsuario.Text = "Usuario: " + datosUsuario.ENombre
        lblEncabezadoArea.Text = "Area: " + datosArea.ENombre

    End Sub

    Private Sub AbrirPrograma(nombre As String, salir As Boolean)

        ejecutarProgramaPrincipal.UseShellExecute = True
        ejecutarProgramaPrincipal.FileName = nombre & Convert.ToString(".exe")
        ejecutarProgramaPrincipal.WorkingDirectory = Directory.GetCurrentDirectory()
        ejecutarProgramaPrincipal.Arguments = LogicaCatalogos.DatosEmpresaPrincipal.idEmpresa.ToString().Trim().Replace(" ", "|") & " " & LogicaCatalogos.DatosEmpresaPrincipal.activa.ToString().Trim().Replace(" ", "|") & " " & LogicaCatalogos.DatosEmpresaPrincipal.instanciaSql.ToString().Trim().Replace(" ", "|") & " " & LogicaCatalogos.DatosEmpresaPrincipal.rutaBd.ToString().Trim().Replace(" ", "|") & " " & LogicaCatalogos.DatosEmpresaPrincipal.usuarioSql.ToString().Trim().Replace(" ", "|") & " " & LogicaCatalogos.DatosEmpresaPrincipal.contrasenaSql.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de empresa principal, indice 7 ;)".Replace(" ", "|") & " " & datosEmpresa.EId.ToString().Trim().Replace(" ", "|") & " " & datosEmpresa.ENombre.Trim().Replace(" ", "|") & " " & datosEmpresa.EDescripcion.Trim().Replace(" ", "|") & " " & datosEmpresa.EDomicilio.Trim().Replace(" ", "|") & " " & datosEmpresa.ELocalidad.Trim().Replace(" ", "|") & " " & datosEmpresa.ERfc.Trim().Replace(" ", "|") & " " & datosEmpresa.EDirectorio.Trim().Replace(" ", "|") & " " & datosEmpresa.ELogo.Trim().Replace(" ", "|") & " " & datosEmpresa.EActiva.ToString().Trim().Replace(" ", "|") & " " & datosEmpresa.EEquipo.Trim().Replace(" ", "|") & " " & "Aquí terminan los de empresa, indice 18 ;)".Replace(" ", "|") & " " & datosUsuario.EId.ToString().Trim().Replace(" ", "|") & " " & datosUsuario.ENombre.Trim().Replace(" ", "|") & " " & datosUsuario.EContrasena.Trim().Replace(" ", "|") & " " & datosUsuario.ENivel.ToString().Trim().Replace(" ", "|") & " " & datosUsuario.EAccesoTotal.ToString().Trim().Replace(" ", "|") & " " & datosUsuario.EIdArea.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de usuario, indice 25 ;)".Replace(" ", "|") & " " & datosArea.EId.ToString().Trim().Replace(" ", "|") & " " & datosArea.ENombre.ToString().Trim().Replace(" ", "|") & " " & datosArea.EClave.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de area, indice 29 ;)".Replace(" ", "|")
        Try
            Process.Start(ejecutarProgramaPrincipal)
            If salir Then
                Application.Exit()
            End If
        Catch ex As Exception
            MessageBox.Show((Convert.ToString("No se puede abrir el programa principal en la ruta : " & ejecutarProgramaPrincipal.WorkingDirectory & "\") & nombre) & Environment.NewLine & Environment.NewLine & ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

#Region "Todos"

    Private Sub FormatearSpread()

        spCatalogos.Reset() : Application.DoEvents()
        spCatalogos2.Reset() : Application.DoEvents()
        ControlarSpreadEnter(spCatalogos)
        spCatalogos.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Seashell : Application.DoEvents()
        spCatalogos2.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Midnight : Application.DoEvents()
        spCatalogos.Visible = True : Application.DoEvents()
        spCatalogos2.Visible = False : Application.DoEvents()
        spCatalogos.ActiveSheet.GrayAreaBackColor = Color.White : Application.DoEvents()
        spCatalogos.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Regular) : Application.DoEvents()
        spCatalogos2.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Regular) : Application.DoEvents()
        spCatalogos.ActiveSheet.Rows(-1).Height = 30 : Application.DoEvents()
        spCatalogos2.ActiveSheet.Rows(-1).Height = 30 : Application.DoEvents()
        spCatalogos.ActiveSheetIndex = 0 : Application.DoEvents()

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

    Private Sub SeleccionoAreas()

        miArea.BackColor = Color.LightSeaGreen
        miCorreo.BackColor = msMenu.BackColor
        Me.opcionSeleccionada = Reportes.Areas
        CargarAreas()

    End Sub

    Private Sub ComenzarCargarAreas()

        FormatearSpread()
        CargarAreas()
        FormatearSpreadAreas()

    End Sub

    Private Sub CargarAreas()

        Dim lista As New List(Of EntidadesCatalogos.Areas)
        lista = areas.ObtenerListado()
        spCatalogos.ActiveSheet.DataSource = lista
        spCatalogos.ActiveSheet.Rows.Count += 1

    End Sub

    Private Sub GuardarEditarAreas()

        Me.Cursor = Cursors.WaitCursor
        areas.EliminarTodo()
        For filaActiva = 0 To spCatalogos.ActiveSheet.Rows.Count - 1
            Dim id As Integer = spCatalogos.ActiveSheet.Cells(filaActiva, spCatalogos.ActiveSheet.Columns("id").Index).Value
            Dim nombre As String = spCatalogos.ActiveSheet.Cells(filaActiva, spCatalogos.ActiveSheet.Columns("nombre").Index).Value
            Dim clave As String = LogicaCatalogos.ValidarLetra(spCatalogos.ActiveSheet.Cells(filaActiva, spCatalogos.ActiveSheet.Columns("clave").Index).Value)
            If (Not String.IsNullOrEmpty(id)) And (Not String.IsNullOrEmpty(nombre)) Then
                areas.EId = id
                areas.ENombre = nombre
                areas.EClave = clave
                Dim tieneAreas As Boolean = areas.ValidarPorId()
                If tieneAreas Then
                    areas.Editar()
                Else
                    areas.Guardar()
                End If
            End If
        Next
        MsgBox("Guardado correcto.", MsgBoxStyle.ApplicationModal, "Correcto.")
        CargarAreas()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub EliminarAreasEnter()

        'Dim id As String = spCatalogos.ActiveSheet.Cells(filaActiva, spCatalogos.ActiveSheet.Columns("id").Index).Value
        'If (Not String.IsNullOrEmpty(id)) Then
        '    areas.EId = LogicaCatalogos.Funciones.ValidarNumero(id)
        '    areas.Eliminar()
        '    CargarAreas()
        'End If

    End Sub

    Private Sub EliminarAreas()

        If (MessageBox.Show("Confirmas que deseas eliminar todo?", "Confirmación.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
            Me.Cursor = Cursors.WaitCursor
            areas.EliminarTodo()
            CargarAreas()
            Me.Cursor = Cursors.Default
        End If

    End Sub

    Private Sub FormatearSpreadAreas()

        spCatalogos.ActiveSheet.ColumnHeader.Rows(0).Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold) : Application.DoEvents()
        Dim numeracion As Integer = 0
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "nombre" : numeracion += 1
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "clave" : numeracion += 1
        spCatalogos.ActiveSheet.Columns("id").Width = 100 : Application.DoEvents()
        spCatalogos.ActiveSheet.Columns("nombre").Width = 250 : Application.DoEvents()
        spCatalogos.ActiveSheet.Columns("clave").Width = 150 : Application.DoEvents()
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("id").Index).Value = "Id".ToUpper : Application.DoEvents()
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("nombre").Index).Value = "Nombre".ToUpper : Application.DoEvents()
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("clave").Index).Value = "Clave".ToUpper : Application.DoEvents()
        spCatalogos.ActiveSheet.ColumnHeader.Rows(0).Height = 35 : Application.DoEvents()
        spCatalogos.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded : Application.DoEvents()
        spCatalogos.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded : Application.DoEvents()

    End Sub

    Private Sub SeleccionoCorreos()

        miCorreo.BackColor = Color.LightSeaGreen
        miArea.BackColor = msMenu.BackColor
        Me.opcionSeleccionada = Reportes.Correos
        CargarCorreos()

    End Sub

    Private Sub CargarCorreos()

        FormatearSpread()
        correosUsuarios.EIdEmpresa = datosEmpresa.EId
        Dim lista As New List(Of EntidadesCatalogos.CorreosUsuarios)
        lista = correosUsuarios.ObtenerListadoPorEmpresa()
        spCatalogos.ActiveSheet.DataSource = lista
        spCatalogos.ActiveSheet.Rows.Count += 1
        FormatearSpreadCorreos()

    End Sub

    Private Sub GuardarEditarCorreos()

        Me.Cursor = Cursors.WaitCursor
        correos.EliminarTodo()
        For filaActiva = 0 To spCatalogos.ActiveSheet.Rows.Count - 1
            Dim idUsuario As Integer = spCatalogos.ActiveSheet.Cells(filaActiva, spCatalogos.ActiveSheet.Columns("idUsuario").Index).Value
            Dim direccion As String = spCatalogos.ActiveSheet.Cells(filaActiva, spCatalogos.ActiveSheet.Columns("direccion").Index).Value
            If (idUsuario > 0) And (Not String.IsNullOrEmpty(direccion)) Then
                correos.EIdUsuario = idUsuario
                correos.EDireccion = direccion
                Dim tieneCorreos As Boolean = correos.ValidarPorIdyDireccion()
                If (Not tieneCorreos) Then
                    correos.Guardar()
                End If
            End If
        Next
        MsgBox("Guardado correcto.", MsgBoxStyle.ApplicationModal, "Correcto.")
        CargarCorreos()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub EliminarCorreos()

        If (MessageBox.Show("Confirmas que deseas eliminar todo?", "Confirmación.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
            Me.Cursor = Cursors.WaitCursor
            correos.EliminarTodo()
            CargarCorreos()
            Me.Cursor = Cursors.Default
        End If

    End Sub

    Private Sub FormatearSpreadCorreos()

        spCatalogos.ActiveSheet.ColumnHeader.Rows(0).Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold) : Application.DoEvents()
        Dim numeracion As Integer = 0
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "idEmpresa" : numeracion += 1
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "idUsuario" : numeracion += 1
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "nombreUsuario" : numeracion += 1
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "direccion" : numeracion += 1
        spCatalogos.ActiveSheet.Columns("idUsuario").Width = 70 : Application.DoEvents()
        spCatalogos.ActiveSheet.Columns("nombreUsuario").Width = 210 : Application.DoEvents()
        spCatalogos.ActiveSheet.Columns("direccion").Width = 300 : Application.DoEvents()
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("idUsuario").Index).Value = "Id".ToUpper : Application.DoEvents()
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("nombreUsuario").Index).Value = "Nombre Usuario".ToUpper : Application.DoEvents()
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("direccion").Index).Value = "Correo".ToUpper : Application.DoEvents()
        spCatalogos.ActiveSheet.ColumnHeader.Rows(0).Height = 45 : Application.DoEvents()
        spCatalogos.ActiveSheet.Columns("idEmpresa").Visible = False : Application.DoEvents()
        spCatalogos.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded : Application.DoEvents()
        spCatalogos.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded : Application.DoEvents()

    End Sub

    Private Sub ControlarSpreadEnter()

        Dim columnaActiva As Integer = spCatalogos.ActiveSheet.ActiveColumnIndex
        If (columnaActiva = spCatalogos.ActiveSheet.Columns.Count - 1) Then
            spCatalogos.ActiveSheet.AddRows(spCatalogos.ActiveSheet.Rows.Count, 1)
        End If
        Dim filaActiva As Integer = spCatalogos.ActiveSheet.ActiveRowIndex
        If (Me.opcionSeleccionada = Reportes.Areas) Then
            'GuardarEditarAreas()
        ElseIf (Me.opcionSeleccionada = Reportes.Correos) Then
            If (columnaActiva = spCatalogos.ActiveSheet.Columns("idUsuario").Index) Then
                usuarios.EIdEmpresa = datosEmpresa.EId
                Dim idUsuario As Integer = spCatalogos.ActiveSheet.Cells(filaActiva, spCatalogos.ActiveSheet.Columns("idUsuario").Index).Value
                usuarios.EId = idUsuario
                If (idUsuario > 0) Then
                    Dim lista As New List(Of EntidadesCatalogos.Usuarios)
                    lista = usuarios.ObtenerListadoPorId
                    If (lista.Count > 0) Then
                        spCatalogos.ActiveSheet.Cells(filaActiva, spCatalogos.ActiveSheet.Columns("nombreUsuario").Index).Value = lista(0).ENombre
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub FormatearSpreadCatalogoUsuarios(ByVal izquierda As Boolean)

        spCatalogos2.ActiveSheet.ColumnHeader.Rows(0).Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold) : Application.DoEvents()
        spCatalogos2.Width = 300 : Application.DoEvents()
        If (izquierda) Then
            spCatalogos2.Location = New Point(spCatalogos.Location.X, spCatalogos.Location.Y) : Application.DoEvents()
        Else
            spCatalogos2.Location = New Point(spCatalogos.Width - spCatalogos2.Width, spCatalogos.Location.Y) : Application.DoEvents()
        End If
        spCatalogos2.Visible = True : Application.DoEvents()
        spCatalogos2.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never : Application.DoEvents()
        spCatalogos2.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect : Application.DoEvents()
        spCatalogos2.Height = spCatalogos.Height : Application.DoEvents()
        Dim numeracion As Integer = 0
        spCatalogos2.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        spCatalogos2.ActiveSheet.Columns(numeracion).Tag = "nombre" : numeracion += 1
        spCatalogos2.ActiveSheet.Columns("id").Width = 50 : Application.DoEvents()
        spCatalogos2.ActiveSheet.Columns("nombre").Width = 210 : Application.DoEvents()
        spCatalogos2.ActiveSheet.ColumnHeader.Cells(0, spCatalogos2.ActiveSheet.Columns("id").Index).Value = "No.".ToUpper : Application.DoEvents()
        spCatalogos2.ActiveSheet.ColumnHeader.Cells(0, spCatalogos2.ActiveSheet.Columns("nombre").Index).Value = "Nombre".ToUpper : Application.DoEvents()
        spCatalogos2.ActiveSheet.ColumnHeader.Rows(0).Height = 35 : Application.DoEvents()
        spCatalogos2.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded : Application.DoEvents()
        spCatalogos2.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded : Application.DoEvents()

    End Sub

    Private Sub CargarCatalogoUsuarios()

        usuarios.EIdEmpresa = datosEmpresa.EId 
        spCatalogos2.ActiveSheet.DataSource = usuarios.ObtenerListado() : Application.DoEvents()
        spCatalogos2.Focus()

    End Sub

    Private Sub VolverFocoCatalogos()

        spCatalogos.Enabled = True
        spCatalogos.Focus()
        spCatalogos.ActiveSheet.SetActiveCell(spCatalogos.ActiveSheet.ActiveRowIndex, spCatalogos.ActiveSheet.Columns("idUsuario").Index)
        spCatalogos2.Visible = False 

    End Sub

#End Region

#End Region

#Region "Enumeraciones"

    Public Enum Reportes

        Areas = 1
        Correos = 2

    End Enum

#End Region

End Class