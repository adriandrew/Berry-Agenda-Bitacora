Imports System.IO

Public Class Principal

    Dim actividades As New EntidadesControl.Actividades
    Dim areas As New EntidadesControl.Areas
    Dim usuarios As New EntidadesControl.Usuarios
    Public datosEmpresa As New LogicaControl.DatosEmpresa()
    Public datosUsuario As New LogicaControl.DatosUsuario()
    Public datosArea As New LogicaControl.DatosArea()
    Public tipoTexto As New FarPoint.Win.Spread.CellType.TextCellType()
    Public tipoEntero As New FarPoint.Win.Spread.CellType.NumberCellType()
    Public tipoDoble As New FarPoint.Win.Spread.CellType.NumberCellType()
    Public tipoPorcentaje As New FarPoint.Win.Spread.CellType.PercentCellType()
    Public tipoHora As New FarPoint.Win.Spread.CellType.DateTimeCellType()
    Public tipoFecha As New FarPoint.Win.Spread.CellType.DateTimeCellType()
    Public tipoBooleano As New FarPoint.Win.Spread.CellType.CheckBoxCellType()
    Public opcionSeleccionada As Integer = 0
    Public estaMostrado As Boolean = False
    Dim ejecutarProgramaPrincipal As New ProcessStartInfo()
    Public estaCerrando As Boolean = False

    Public esDesarrollo As Boolean = False

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

    End Sub

    Private Sub Principal_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Me.Cursor = Cursors.AppStarting
        Me.Enabled = False
        If (Not ValidarAccesoTotal()) Then
            Salir()
        End If
        CargarEncabezados()
        CargarTiposDeDatos()
        CargarComboAreas()
        CargarComboUsuarios()
        CargarComboAreasDestino()
        CargarComboUsuariosDestino() 
        cbTipo.SelectedIndex = 0
        Me.estaMostrado = True
        Me.Enabled = True
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        Salir()

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If (Me.opcionSeleccionada = OpcionesMenu.Autorizaciones) Then
            EditarAutorizaciones()
        ElseIf (Me.opcionSeleccionada = OpcionesMenu.Evidencias) Then
            EditarEvidencias()
        End If

    End Sub

    Private Sub spAutorizaciones_CellClick(sender As Object, e As FarPoint.Win.Spread.CellClickEventArgs) Handles spControles.CellClick

        Dim filas As Integer = spControles.ActiveSheet.Rows.Count
        If (filas > 0) Then
            spControles.ActiveSheet.Rows(e.Row).BackColor = Color.White : Application.DoEvents()
            If (Me.opcionSeleccionada = OpcionesMenu.Autorizaciones) Then
                If (spControles.ActiveSheet.Cells(e.Row, spControles.ActiveSheet.Columns("autorizar").Index).Value) Then
                    spControles.ActiveSheet.Cells(e.Row, spControles.ActiveSheet.Columns("autorizar").Index).BackColor = Color.White : Application.DoEvents()
                    spControles.ActiveSheet.Cells(e.Row, spControles.ActiveSheet.Columns("rechazar").Index).BackColor = Color.White : Application.DoEvents()
                    spControles.ActiveSheet.Cells(e.Row, spControles.ActiveSheet.Columns("autorizar").Index).Value = False
                    spControles.ActiveSheet.Cells(e.Row, spControles.ActiveSheet.Columns("rechazar").Index).Value = False
                Else
                    spControles.ActiveSheet.Rows(e.Row).BackColor = Color.GreenYellow : Application.DoEvents()
                    spControles.ActiveSheet.Cells(e.Row, spControles.ActiveSheet.Columns("autorizar").Index).BackColor = Color.Green : Application.DoEvents()
                    spControles.ActiveSheet.Cells(e.Row, spControles.ActiveSheet.Columns("rechazar").Index).BackColor = Color.GreenYellow : Application.DoEvents()
                    spControles.ActiveSheet.Cells(e.Row, spControles.ActiveSheet.Columns("autorizar").Index).Value = True
                    spControles.ActiveSheet.Cells(e.Row, spControles.ActiveSheet.Columns("rechazar").Index).Value = False
                End If
            ElseIf (Me.opcionSeleccionada = OpcionesMenu.Evidencias) Then
                If (spControles.ActiveSheet.Cells(e.Row, spControles.ActiveSheet.Columns("solicitaEvidencia").Index).Value) Then
                    spControles.ActiveSheet.Cells(e.Row, spControles.ActiveSheet.Columns("solicitaEvidencia").Index).BackColor = Color.White : Application.DoEvents()
                    spControles.ActiveSheet.Cells(e.Row, spControles.ActiveSheet.Columns("rechazaEvidencia").Index).BackColor = Color.White : Application.DoEvents()
                    spControles.ActiveSheet.Cells(e.Row, spControles.ActiveSheet.Columns("solicitaEvidencia").Index).Value = False
                    spControles.ActiveSheet.Cells(e.Row, spControles.ActiveSheet.Columns("rechazaEvidencia").Index).Value = False
                Else
                    spControles.ActiveSheet.Rows(e.Row).BackColor = Color.GreenYellow : Application.DoEvents()
                    spControles.ActiveSheet.Cells(e.Row, spControles.ActiveSheet.Columns("solicitaEvidencia").Index).BackColor = Color.Green : Application.DoEvents()
                    spControles.ActiveSheet.Cells(e.Row, spControles.ActiveSheet.Columns("rechazaEvidencia").Index).BackColor = Color.GreenYellow : Application.DoEvents()
                    spControles.ActiveSheet.Cells(e.Row, spControles.ActiveSheet.Columns("solicitaEvidencia").Index).Value = True
                    spControles.ActiveSheet.Cells(e.Row, spControles.ActiveSheet.Columns("rechazaEvidencia").Index).Value = False
                End If
            End If
            Application.DoEvents()
        End If

    End Sub

    Private Sub spAutorizaciones_CellDoubleClick(sender As Object, e As FarPoint.Win.Spread.CellClickEventArgs) Handles spControles.CellDoubleClick

        Dim filas As Integer = spControles.ActiveSheet.Rows.Count
        If (filas > 0) Then
            spControles.ActiveSheet.Rows(e.Row).BackColor = Color.White : Application.DoEvents()
            If (Me.opcionSeleccionada = OpcionesMenu.Autorizaciones) Then
                If spControles.ActiveSheet.Cells(e.Row, spControles.ActiveSheet.Columns("rechazar").Index).Value Then
                    spControles.ActiveSheet.Cells(e.Row, spControles.ActiveSheet.Columns("rechazar").Index).BackColor = Color.White : Application.DoEvents()
                    spControles.ActiveSheet.Cells(e.Row, spControles.ActiveSheet.Columns("autorizar").Index).BackColor = Color.White : Application.DoEvents()
                    spControles.ActiveSheet.Cells(e.Row, spControles.ActiveSheet.Columns("rechazar").Index).Value = False
                    spControles.ActiveSheet.Cells(e.Row, spControles.ActiveSheet.Columns("autorizar").Index).Value = False
                Else
                    spControles.ActiveSheet.Rows(e.Row).BackColor = Color.OrangeRed : Application.DoEvents()
                    spControles.ActiveSheet.Cells(e.Row, spControles.ActiveSheet.Columns("rechazar").Index).BackColor = Color.Red : Application.DoEvents()
                    spControles.ActiveSheet.Cells(e.Row, spControles.ActiveSheet.Columns("autorizar").Index).BackColor = Color.OrangeRed : Application.DoEvents()
                    spControles.ActiveSheet.Cells(e.Row, spControles.ActiveSheet.Columns("rechazar").Index).Value = True
                    spControles.ActiveSheet.Cells(e.Row, spControles.ActiveSheet.Columns("autorizar").Index).Value = False
                End If
            ElseIf (Me.opcionSeleccionada = OpcionesMenu.Evidencias) Then
                If spControles.ActiveSheet.Cells(e.Row, spControles.ActiveSheet.Columns("rechazaEvidencia").Index).Value Then
                    spControles.ActiveSheet.Cells(e.Row, spControles.ActiveSheet.Columns("rechazaEvidencia").Index).BackColor = Color.White : Application.DoEvents()
                    spControles.ActiveSheet.Cells(e.Row, spControles.ActiveSheet.Columns("solicitaEvidencia").Index).BackColor = Color.White : Application.DoEvents()
                    spControles.ActiveSheet.Cells(e.Row, spControles.ActiveSheet.Columns("rechazaEvidencia").Index).Value = False
                    spControles.ActiveSheet.Cells(e.Row, spControles.ActiveSheet.Columns("solicitaEvidencia").Index).Value = False
                Else
                    spControles.ActiveSheet.Rows(e.Row).BackColor = Color.OrangeRed : Application.DoEvents()
                    spControles.ActiveSheet.Cells(e.Row, spControles.ActiveSheet.Columns("rechazaEvidencia").Index).BackColor = Color.Red : Application.DoEvents()
                    spControles.ActiveSheet.Cells(e.Row, spControles.ActiveSheet.Columns("solicitaEvidencia").Index).BackColor = Color.OrangeRed : Application.DoEvents()
                    spControles.ActiveSheet.Cells(e.Row, spControles.ActiveSheet.Columns("rechazaEvidencia").Index).Value = True
                    spControles.ActiveSheet.Cells(e.Row, spControles.ActiveSheet.Columns("solicitaEvidencia").Index).Value = False
                End If
            End If
        End If

    End Sub

    Private Sub btnGuardar_MouseHover(sender As Object, e As EventArgs) Handles btnGuardar.MouseHover

        AsignarTooltips("Guardar.")

    End Sub

    Private Sub btnSalir_MouseHover(sender As Object, e As EventArgs) Handles btnSalir.MouseHover

        AsignarTooltips("Salir.")

    End Sub

    Private Sub cbAreas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAreas.SelectedIndexChanged

        If cbAreas.Items.Count > 1 Then
            If cbAreas.SelectedIndex > 0 Then
                CargarComboUsuarios()
            Else
                If (Me.opcionSeleccionada = OpcionesMenu.Autorizaciones) Then
                    CargarAutorizacionesSpread()
                ElseIf (Me.opcionSeleccionada = OpcionesMenu.Evidencias) Then 
                    CargarEvidenciasSpread()
                End If
            End If
        End If

    End Sub

    Private Sub cbAreasDestino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAreasDestino.SelectedIndexChanged

        If cbAreasDestino.Items.Count > 1 Then
            If cbAreasDestino.SelectedIndex > 0 Then
                CargarComboUsuariosDestino()
            Else
                If (Me.opcionSeleccionada = OpcionesMenu.Autorizaciones) Then
                    CargarAutorizacionesSpread()
                ElseIf (Me.opcionSeleccionada = OpcionesMenu.Evidencias) Then 
                    CargarEvidenciasSpread()
                End If
            End If
        End If

    End Sub

    Private Sub cbUsuarios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbUsuarios.SelectedIndexChanged

        If (Me.opcionSeleccionada = OpcionesMenu.Autorizaciones) Then
            CargarAutorizacionesSpread()
        ElseIf (Me.opcionSeleccionada = OpcionesMenu.Evidencias) Then
            CargarEvidenciasSpread()
        End If

    End Sub

    Private Sub cbUsuariosDestino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbUsuariosDestino.SelectedIndexChanged

        If (Me.opcionSeleccionada = OpcionesMenu.Autorizaciones) Then
            CargarAutorizacionesSpread()
        ElseIf (Me.opcionSeleccionada = OpcionesMenu.Evidencias) Then
            CargarEvidenciasSpread()
        End If

    End Sub

    Private Sub pnlCuerpo_MouseHover(sender As Object, e As EventArgs) Handles pnlPie.MouseHover, pnlEncabezado.MouseHover, pnlCuerpo.MouseHover

        AsignarTooltips(String.Empty)

    End Sub

    Private Sub temporizador_Tick(sender As Object, e As EventArgs) Handles temporizador.Tick

        If (Me.estaCerrando) Then
            Desvanecer()
        End If

    End Sub

    Private Sub btnAyuda_MouseHover(sender As Object, e As EventArgs) Handles btnAyuda.MouseHover

        AsignarTooltips("Ayuda.")

    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click

        MostrarAyuda()

    End Sub

    Private Sub spAutorizaciones_MouseHover(sender As Object, e As EventArgs) Handles spControles.MouseHover

        AsignarTooltips("Clic para Seleccionar una Actividad a Autorizar o Denegar.")

    End Sub

    Private Sub pnlExterna_MouseHover(sender As Object, e As EventArgs) Handles pnlExterna.MouseHover

        AsignarTooltips("Filtros para Actividades a Autorizar o Denegar.")

    End Sub

    Private Sub chkMostrarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkMostrarTodo.CheckedChanged

        CargarAutorizacionesSpread()

    End Sub

    Private Sub rbtnAutorizaciones_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnAutorizaciones.CheckedChanged

        If (rbtnAutorizaciones.Checked) Then
            Me.opcionSeleccionada = OpcionesMenu.Autorizaciones
            chkMostrarTodo.Visible = True
            cbTipo.Visible = False
            FormatearSpreadGeneral()
            CargarAutorizacionesSpread()
        End If

    End Sub

    Private Sub rbtnEvidencias_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnEvidencias.CheckedChanged

        If (Me.estaMostrado) Then
            If (rbtnEvidencias.Checked) Then
                cbTipo.SelectedIndex = 0
                Me.opcionSeleccionada = OpcionesMenu.Evidencias
                chkMostrarTodo.Visible = False
                cbTipo.Visible = True
                FormatearSpreadGeneral()
                CargarEvidenciasSpread()
            End If
        End If

    End Sub

    Private Sub cbTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTipo.SelectedIndexChanged

        CargarEvidenciasSpread()

    End Sub

#End Region

#Region "Métodos"

#Region "Genéricos"

    Private Sub Salir()

        Application.Exit()

    End Sub

    Private Sub MostrarAyuda()

        Dim pnlAyuda As New Panel()
        Dim txtAyuda As New TextBox()
        If (pnlContenido.Controls.Find("pnlAyuda", True).Count = 0) Then
            pnlAyuda.Name = "pnlAyuda" : Application.DoEvents()
            pnlAyuda.Visible = False : Application.DoEvents()
            pnlContenido.Controls.Add(pnlAyuda) : Application.DoEvents()
            txtAyuda.Name = "txtAyuda" : Application.DoEvents()
            pnlAyuda.Controls.Add(txtAyuda) : Application.DoEvents()
        Else
            pnlAyuda = pnlContenido.Controls.Find("pnlAyuda", False)(0) : Application.DoEvents()
            txtAyuda = pnlAyuda.Controls.Find("txtAyuda", False)(0) : Application.DoEvents()
        End If
        If (Not pnlAyuda.Visible) Then
            pnlCuerpo.Visible = False : Application.DoEvents()
            pnlAyuda.Visible = True : Application.DoEvents()
            pnlAyuda.Size = pnlCuerpo.Size : Application.DoEvents()
            pnlAyuda.Location = pnlCuerpo.Location : Application.DoEvents()
            pnlContenido.Controls.Add(pnlAyuda) : Application.DoEvents()
            txtAyuda.ScrollBars = ScrollBars.Both : Application.DoEvents()
            txtAyuda.Multiline = True : Application.DoEvents()
            txtAyuda.Width = pnlAyuda.Width - 10 : Application.DoEvents()
            txtAyuda.Height = pnlAyuda.Height - 10 : Application.DoEvents()
            txtAyuda.Location = New Point(5, 5) : Application.DoEvents()
            txtAyuda.Text = "Sección de Ayuda: " & vbNewLine & vbNewLine & "* Autorizaciones: " & vbNewLine & "En esta parte se procede a autorizar las actividades externas creadas por usuarios, es decir, las actividades que van con destino a un usuario distinto al que lo creó. " & vbNewLine & "Las actividades se tienen que seleccionar del listado. Para que sea mas facil se pueden filtrar por area y/o usuario origen y/o area destino y/o usuario destino. Al darle un clic se marcan en verde y significan autorizadas, al darle dos clics se marcan en rojo y significan rechazadas. Despues se procede a guardar y ya quedan autorizadas o rechazadas según sea el caso." : Application.DoEvents()
            pnlAyuda.Controls.Add(txtAyuda) : Application.DoEvents()
        Else
            pnlCuerpo.Visible = True : Application.DoEvents()
            pnlAyuda.Visible = False : Application.DoEvents()
        End If

    End Sub

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
        tp.SetToolTip(Me.btnGuardar, "Guardar o Editar.")
        tp.SetToolTip(Me.spControles, "Clic para Seleccionar una Actividad a Autorizar o Denegar.")

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

        If (Me.esDesarrollo) Then
            'baseDatos.CadenaConexionInformacion = "C:\\Berry-Agenda\\BD\\PODC\\Agenda.mdf"
            Me.datosUsuario.EId = 1
            Me.datosUsuario.EIdArea = 1
            Me.datosUsuario.EAccesoTotal = True
            Me.datosEmpresa.EId = 1
            LogicaControl.DatosEmpresaPrincipal.instanciaSql = "BERRY1-DELL\SQLEXPRESS2008"
            LogicaControl.DatosEmpresaPrincipal.usuarioSql = "AdminBerry"
            LogicaControl.DatosEmpresaPrincipal.contrasenaSql = "@berry2017"
        Else
            'EntidadesActividades.BaseDatos.ECadenaConexionAgenda = datosEmpresa.EDirectorio & "\\Agenda.mdf"
            LogicaControl.DatosEmpresaPrincipal.ObtenerParametrosInformacionEmpresa()
            Me.datosEmpresa.ObtenerParametrosInformacionEmpresa()
            Me.datosUsuario.ObtenerParametrosInformacionUsuario()
            Me.datosArea.ObtenerParametrosInformacionArea()
        End If
        EntidadesControl.BaseDatos.ECadenaConexionAgenda = "Agenda"
        EntidadesControl.BaseDatos.ECadenaConexionCatalogo = "Catalogos"
        EntidadesControl.BaseDatos.ECadenaConexionInformacion = "Informacion"
        EntidadesControl.BaseDatos.AbrirConexionAgenda()
        EntidadesControl.BaseDatos.AbrirConexionCatalogo()
        EntidadesControl.BaseDatos.AbrirConexionInformacion()

    End Sub

    Private Sub CargarEncabezados()

        lblEncabezadoPrograma.Text = "Programa: " + Me.Text
        lblEncabezadoEmpresa.Text = "Empresa: " + datosEmpresa.ENombre
        lblEncabezadoUsuario.Text = "Usuario: " + datosUsuario.ENombre
        lblEncabezadoArea.Text = "Area: " + datosArea.ENombre

    End Sub

    Private Sub AbrirPrograma(nombre As String, salir As Boolean)

        If (Me.esDesarrollo) Then
            Exit Sub
        End If
        ejecutarProgramaPrincipal.UseShellExecute = True
        ejecutarProgramaPrincipal.FileName = nombre & Convert.ToString(".exe")
        ejecutarProgramaPrincipal.WorkingDirectory = Directory.GetCurrentDirectory()
        ejecutarProgramaPrincipal.Arguments = LogicaControl.DatosEmpresaPrincipal.idEmpresa.ToString().Trim().Replace(" ", "|") & " " & LogicaControl.DatosEmpresaPrincipal.activa.ToString().Trim().Replace(" ", "|") & " " & LogicaControl.DatosEmpresaPrincipal.instanciaSql.ToString().Trim().Replace(" ", "|") & " " & LogicaControl.DatosEmpresaPrincipal.rutaBd.ToString().Trim().Replace(" ", "|") & " " & LogicaControl.DatosEmpresaPrincipal.usuarioSql.ToString().Trim().Replace(" ", "|") & " " & LogicaControl.DatosEmpresaPrincipal.contrasenaSql.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de empresa principal, indice 7 ;)".Replace(" ", "|") & " " & datosEmpresa.EId.ToString().Trim().Replace(" ", "|") & " " & datosEmpresa.ENombre.Trim().Replace(" ", "|") & " " & datosEmpresa.EDescripcion.Trim().Replace(" ", "|") & " " & datosEmpresa.EDomicilio.Trim().Replace(" ", "|") & " " & datosEmpresa.ELocalidad.Trim().Replace(" ", "|") & " " & datosEmpresa.ERfc.Trim().Replace(" ", "|") & " " & datosEmpresa.EDirectorio.Trim().Replace(" ", "|") & " " & datosEmpresa.ELogo.Trim().Replace(" ", "|") & " " & datosEmpresa.EActiva.ToString().Trim().Replace(" ", "|") & " " & datosEmpresa.EEquipo.Trim().Replace(" ", "|") & " " & "Aquí terminan los de empresa, indice 18 ;)".Replace(" ", "|") & " " & datosUsuario.EId.ToString().Trim().Replace(" ", "|") & " " & datosUsuario.ENombre.Trim().Replace(" ", "|") & " " & datosUsuario.EContrasena.Trim().Replace(" ", "|") & " " & datosUsuario.ENivel.ToString().Trim().Replace(" ", "|") & " " & datosUsuario.EAccesoTotal.ToString().Trim().Replace(" ", "|") & " " & datosUsuario.EIdArea.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de usuario, indice 25 ;)".Replace(" ", "|") & " " & datosArea.EId.ToString().Trim().Replace(" ", "|") & " " & datosArea.ENombre.ToString().Trim().Replace(" ", "|") & " " & datosArea.EClave.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de area, indice 29 ;)".Replace(" ", "|")
        Try
            Process.Start(ejecutarProgramaPrincipal)
            If salir Then
                Application.Exit()
            End If
        Catch ex As Exception
            MessageBox.Show((Convert.ToString("No se puede abrir el programa principal en la ruta : " & ejecutarProgramaPrincipal.WorkingDirectory & "\") & nombre) & Environment.NewLine & Environment.NewLine & ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Function ValidarAccesoTotal() As Boolean

        If ((Not datosUsuario.EAccesoTotal) Or (datosUsuario.EAccesoTotal = 0) Or (datosUsuario.EAccesoTotal = False)) Then
            MsgBox("No tienes permisos suficientes para acceder a este programa.", MsgBoxStyle.Information, "Permisos insuficientes.")
            Return False
        Else
            Return True
        End If

    End Function

#End Region

#Region "Todos"

    Private Sub CargarComboAreas()

        Dim lista As New List(Of EntidadesControl.Areas)
        lista = areas.ObtenerListado()
        cbAreas.DataSource = lista
        cbAreas.ValueMember = "EId"
        cbAreas.DisplayMember = "ENombre"

    End Sub

    Private Sub CargarComboUsuarios()

        Try
            Dim idArea As Integer = cbAreas.SelectedValue()
            Dim lista As New List(Of EntidadesControl.Usuarios)
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

        Dim lista As New List(Of EntidadesControl.Areas)
        lista = areas.ObtenerListado()
        cbAreasDestino.DataSource = lista
        cbAreasDestino.ValueMember = "EId"
        cbAreasDestino.DisplayMember = "ENombre"

    End Sub

    Private Sub CargarComboUsuariosDestino()

        Try
            Dim idArea As Integer = cbAreasDestino.SelectedValue()
            Dim lista As New List(Of EntidadesControl.Usuarios)
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

    Private Sub LimpiarSpread()

        If (Me.estaMostrado) Then
            Me.Cursor = Cursors.WaitCursor
            spControles.ActiveSheet.DataSource = Nothing
            'spControles.ActiveSheet.ClearRange(0, 0, spControles.ActiveSheet.Rows.Count, spControles.ActiveSheet.Columns.Count, True)
            spControles.BackColor = Color.White
            Me.Cursor = Cursors.Default
        End If

    End Sub

    Private Sub FormatearSpreadGeneral()

        Me.Cursor = Cursors.WaitCursor
        spControles.Reset()
        spControles.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Seashell
        spControles.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Regular)
        spControles.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        spControles.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded 
        spControles.ActiveSheet.SetColumnAllowFilter(0, spControles.ActiveSheet.Columns.Count, True)
        spControles.ActiveSheet.SetColumnAllowAutoSort(0, spControles.ActiveSheet.Columns.Count, True)
        spControles.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect
        spControles.ActiveSheet.GrayAreaBackColor = Color.White
        Application.DoEvents()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub CargarAutorizacionesSpread()

        If (Me.estaMostrado) Then
            Me.Cursor = Cursors.WaitCursor
            LimpiarSpread()
            Dim lista As New List(Of EntidadesControl.Actividades)
            actividades.EIdArea = cbAreas.SelectedValue
            actividades.EIdUsuario = cbUsuarios.SelectedValue
            actividades.EIdAreaDestino = cbAreasDestino.SelectedValue
            actividades.EIdUsuarioDestino = cbUsuariosDestino.SelectedValue
            lista = actividades.ObtenerListadoAutorizaciones(chkMostrarTodo.Checked)
            spControles.ActiveSheet.DataSource = lista
            FormatearSpreadAutorizaciones(spControles.ActiveSheet.Columns.Count)
            Me.Cursor = Cursors.Default
        End If

    End Sub

    Private Sub FormatearSpreadAutorizaciones(ByVal cantidadColumnas As Integer)

        Me.Cursor = Cursors.WaitCursor
        spControles.Visible = True
        Application.DoEvents()
        spControles.ActiveSheet.ColumnHeader.Rows(0).Height = 35
        spControles.ActiveSheet.Rows(-1).Height = 50
        spControles.ActiveSheet.ColumnHeader.RowCount = 2
        spControles.ActiveSheet.ColumnHeader.Rows(0, spControles.ActiveSheet.ColumnHeader.Rows.Count - 1).Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        Dim numeracion As Integer = 0
        spControles.ActiveSheet.Columns.Count = cantidadColumnas + 2 ' Es una columna para autorizar y otra para rechazar.
        spControles.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "idArea" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "nombreArea" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "idUsuario" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "nombreUsuario" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "idAreaDestino" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "nombreAreaDestino" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "idUsuarioDestino" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "nombreUsuarioDestino" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "nombre" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "descripcion" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "fechaCreacion" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "fechaVencimiento" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "esUrgente" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "esExterna" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "esAutorizado" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "esRechazado" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "estaResuelto" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "solicitaEvidencia" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "rechazaEvidencia" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "solicitaAutorizacion" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "autorizar" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "rechazar" : numeracion += 1
        spControles.ActiveSheet.Columns("id").Width = 80
        spControles.ActiveSheet.Columns("idArea").Width = 80
        spControles.ActiveSheet.Columns("nombreArea").Width = 150
        spControles.ActiveSheet.Columns("idUsuario").Width = 80
        spControles.ActiveSheet.Columns("nombreUsuario").Width = 150
        spControles.ActiveSheet.Columns("idAreaDestino").Width = 80
        spControles.ActiveSheet.Columns("nombreAreaDestino").Width = 160
        spControles.ActiveSheet.Columns("idUsuarioDestino").Width = 80
        spControles.ActiveSheet.Columns("nombreUsuarioDestino").Width = 160
        spControles.ActiveSheet.Columns("nombre").Width = 300
        spControles.ActiveSheet.Columns("descripcion").Width = 500
        spControles.ActiveSheet.Columns("fechaCreacion").Width = 160
        spControles.ActiveSheet.Columns("fechaVencimiento").Width = 160
        spControles.ActiveSheet.Columns("esUrgente").Width = 170
        spControles.ActiveSheet.Columns("esExterna").Width = 170
        spControles.ActiveSheet.Columns("estaResuelto").Width = 170
        spControles.ActiveSheet.Columns("solicitaEvidencia").Width = 170
        spControles.ActiveSheet.Columns("rechazaEvidencia").Width = 170
        spControles.ActiveSheet.Columns("solicitaAutorizacion").Width = 190
        spControles.ActiveSheet.Columns("autorizar").Width = 150
        spControles.ActiveSheet.Columns("rechazar").Width = 150
        spControles.ActiveSheet.Columns("esUrgente").CellType = tipoBooleano
        spControles.ActiveSheet.Columns("esExterna").CellType = tipoBooleano
        spControles.ActiveSheet.Columns("estaResuelto").CellType = tipoBooleano
        spControles.ActiveSheet.Columns("solicitaEvidencia").CellType = tipoBooleano
        spControles.ActiveSheet.Columns("rechazaEvidencia").CellType = tipoBooleano
        spControles.ActiveSheet.Columns("solicitaAutorizacion").CellType = tipoBooleano
        spControles.ActiveSheet.Columns("autorizar").CellType = tipoBooleano
        spControles.ActiveSheet.Columns("rechazar").CellType = tipoBooleano
        spControles.ActiveSheet.Columns("nombre").HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Justify
        spControles.ActiveSheet.Columns("descripcion").HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Justify
        spControles.ActiveSheet.AddColumnHeaderSpanCell(0, spControles.ActiveSheet.Columns("id").Index, 2, 1)
        spControles.ActiveSheet.ColumnHeader.Cells(0, spControles.ActiveSheet.Columns("id").Index).Value = "No.".ToUpper
        spControles.ActiveSheet.AddColumnHeaderSpanCell(0, spControles.ActiveSheet.Columns("idArea").Index, 1, 2)
        spControles.ActiveSheet.ColumnHeader.Cells(0, spControles.ActiveSheet.Columns("idArea").Index).Value = "Area".ToUpper
        spControles.ActiveSheet.ColumnHeader.Cells(1, spControles.ActiveSheet.Columns("idArea").Index).Value = "No.".ToUpper
        spControles.ActiveSheet.ColumnHeader.Cells(1, spControles.ActiveSheet.Columns("nombreArea").Index).Value = "Nombre".ToUpper
        spControles.ActiveSheet.AddColumnHeaderSpanCell(0, spControles.ActiveSheet.Columns("idUsuario").Index, 1, 2)
        spControles.ActiveSheet.ColumnHeader.Cells(0, spControles.ActiveSheet.Columns("idUsuario").Index).Value = "Usuario".ToUpper
        spControles.ActiveSheet.ColumnHeader.Cells(1, spControles.ActiveSheet.Columns("idUsuario").Index).Value = "No.".ToUpper
        spControles.ActiveSheet.ColumnHeader.Cells(1, spControles.ActiveSheet.Columns("nombreUsuario").Index).Value = "Nombre".ToUpper
        spControles.ActiveSheet.AddColumnHeaderSpanCell(0, spControles.ActiveSheet.Columns("idAreaDestino").Index, 1, 2)
        spControles.ActiveSheet.ColumnHeader.Cells(0, spControles.ActiveSheet.Columns("idAreaDestino").Index).Value = "Area Destino".ToUpper
        spControles.ActiveSheet.ColumnHeader.Cells(1, spControles.ActiveSheet.Columns("idAreaDestino").Index).Value = "No.".ToUpper
        spControles.ActiveSheet.ColumnHeader.Cells(1, spControles.ActiveSheet.Columns("nombreAreaDestino").Index).Value = "Nombre".ToUpper
        spControles.ActiveSheet.AddColumnHeaderSpanCell(0, spControles.ActiveSheet.Columns("idUsuarioDestino").Index, 1, 2)
        spControles.ActiveSheet.ColumnHeader.Cells(0, spControles.ActiveSheet.Columns("idUsuarioDestino").Index).Value = "Usuario Destino".ToUpper
        spControles.ActiveSheet.ColumnHeader.Cells(1, spControles.ActiveSheet.Columns("idUsuarioDestino").Index).Value = "No.".ToUpper
        spControles.ActiveSheet.ColumnHeader.Cells(1, spControles.ActiveSheet.Columns("nombreUsuarioDestino").Index).Value = "Nombre".ToUpper
        spControles.ActiveSheet.AddColumnHeaderSpanCell(0, spControles.ActiveSheet.Columns("nombre").Index, 2, 1)
        spControles.ActiveSheet.ColumnHeader.Cells(0, spControles.ActiveSheet.Columns("nombre").Index).Value = "Nombre".ToUpper
        spControles.ActiveSheet.AddColumnHeaderSpanCell(0, spControles.ActiveSheet.Columns("descripcion").Index, 2, 1)
        spControles.ActiveSheet.ColumnHeader.Cells(0, spControles.ActiveSheet.Columns("descripcion").Index).Value = "Descripción".ToUpper
        spControles.ActiveSheet.AddColumnHeaderSpanCell(0, spControles.ActiveSheet.Columns("fechaCreacion").Index, 2, 1)
        spControles.ActiveSheet.ColumnHeader.Cells(0, spControles.ActiveSheet.Columns("fechaCreacion").Index).Value = "Fecha de Creación".ToUpper
        spControles.ActiveSheet.AddColumnHeaderSpanCell(0, spControles.ActiveSheet.Columns("fechaVencimiento").Index, 2, 1)
        spControles.ActiveSheet.ColumnHeader.Cells(0, spControles.ActiveSheet.Columns("fechaVencimiento").Index).Value = "Fecha de Vencimiento".ToUpper
        spControles.ActiveSheet.AddColumnHeaderSpanCell(0, spControles.ActiveSheet.Columns("esUrgente").Index, 2, 1)
        spControles.ActiveSheet.ColumnHeader.Cells(0, spControles.ActiveSheet.Columns("esUrgente").Index).Value = "Es Urgente?".ToUpper
        spControles.ActiveSheet.AddColumnHeaderSpanCell(0, spControles.ActiveSheet.Columns("esExterna").Index, 2, 1)
        spControles.ActiveSheet.ColumnHeader.Cells(0, spControles.ActiveSheet.Columns("esExterna").Index).Value = "Es Externa?".ToUpper
        spControles.ActiveSheet.AddColumnHeaderSpanCell(0, spControles.ActiveSheet.Columns("estaResuelto").Index, 2, 1)
        spControles.ActiveSheet.ColumnHeader.Cells(0, spControles.ActiveSheet.Columns("estaResuelto").Index).Value = "Esta Resuelta?".ToUpper
        spControles.ActiveSheet.AddColumnHeaderSpanCell(0, spControles.ActiveSheet.Columns("solicitaEvidencia").Index, 2, 1)
        spControles.ActiveSheet.ColumnHeader.Cells(0, spControles.ActiveSheet.Columns("solicitaEvidencia").Index).Value = "Solicita Evidencia?".ToUpper
        spControles.ActiveSheet.AddColumnHeaderSpanCell(0, spControles.ActiveSheet.Columns("rechazaEvidencia").Index, 2, 1)
        spControles.ActiveSheet.ColumnHeader.Cells(0, spControles.ActiveSheet.Columns("rechazaEvidencia").Index).Value = "Rechaza Evidencia?".ToUpper
        spControles.ActiveSheet.AddColumnHeaderSpanCell(0, spControles.ActiveSheet.Columns("solicitaAutorizacion").Index, 2, 1)
        spControles.ActiveSheet.ColumnHeader.Cells(0, spControles.ActiveSheet.Columns("solicitaAutorizacion").Index).Value = "Solicita Autorización?".ToUpper
        spControles.ActiveSheet.AddColumnHeaderSpanCell(0, spControles.ActiveSheet.Columns("autorizar").Index, 2, 1)
        spControles.ActiveSheet.ColumnHeader.Cells(0, spControles.ActiveSheet.Columns("autorizar").Index).Value = "Autorizar".ToUpper
        spControles.ActiveSheet.AddColumnHeaderSpanCell(0, spControles.ActiveSheet.Columns("rechazar").Index, 2, 1)
        spControles.ActiveSheet.ColumnHeader.Cells(0, spControles.ActiveSheet.Columns("rechazar").Index).Value = "Rechazar".ToUpper 
        Application.DoEvents() 
        spControles.ActiveSheet.Columns("esAutorizado").Visible = False
        spControles.ActiveSheet.Columns("esRechazado").Visible = False 
        Application.DoEvents()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub EditarAutorizaciones()

        For fila = 0 To spControles.ActiveSheet.Rows.Count - 1
            Dim id As Integer = spControles.ActiveSheet.Cells(fila, spControles.ActiveSheet.Columns("id").Index).Value 'LogicaActividadesExternas.Funciones.ValidarNumero(txtCapturaId.Text)
            Dim idArea As Integer = spControles.ActiveSheet.Cells(fila, spControles.ActiveSheet.Columns("idArea").Index).Value
            Dim idUsuario As Integer = spControles.ActiveSheet.Cells(fila, spControles.ActiveSheet.Columns("idUsuario").Index).Value
            Dim idAreaDestino As Integer = spControles.ActiveSheet.Cells(fila, spControles.ActiveSheet.Columns("idAreaDestino").Index).Value
            Dim idUsuarioDestino As Integer = spControles.ActiveSheet.Cells(fila, spControles.ActiveSheet.Columns("idUsuarioDestino").Index).Value
            Dim autorizar As Boolean = spControles.ActiveSheet.Cells(fila, spControles.ActiveSheet.Columns("autorizar").Index).Value
            Dim rechazar As Boolean = spControles.ActiveSheet.Cells(fila, spControles.ActiveSheet.Columns("rechazar").Index).Value
            If (id > 0) And (idArea > 0) And (idUsuario > 0) And (idAreaDestino > 0) And (idUsuarioDestino > 0) And (autorizar Or rechazar) Then
                actividades.EId = id
                actividades.EIdArea = idArea
                actividades.EIdUsuario = idUsuario
                actividades.EEsAutorizado = autorizar
                actividades.EEsRechazado = rechazar
                actividades.EditarAutorizaciones()
            End If
        Next
        MsgBox("Guardado finalizado.", MsgBoxStyle.ApplicationModal, "Finalizado.")
        CargarAutorizacionesSpread()

    End Sub
     
    Private Sub CargarEvidenciasSpread()

        If (Me.estaMostrado) Then
            Me.Cursor = Cursors.WaitCursor
            LimpiarSpread()
            Dim datos As New DataTable
            actividades.EIdArea = cbAreas.SelectedValue
            actividades.EIdUsuario = cbUsuarios.SelectedValue
            actividades.EIdAreaDestino = cbAreasDestino.SelectedValue
            actividades.EIdUsuarioDestino = cbUsuariosDestino.SelectedValue
            datos = actividades.ObtenerListadoEvidenciasReporte(cbTipo.SelectedIndex)
            spControles.ActiveSheet.DataSource = datos
            FormatearSpreadEvidencias(spControles.ActiveSheet.Columns.Count)
            Me.Cursor = Cursors.Default
        End If

    End Sub

    Private Sub FormatearSpreadEvidencias(ByVal cantidadColumnas As Integer)

        Me.Cursor = Cursors.WaitCursor
        spControles.Visible = True
        Application.DoEvents() 
        spControles.ActiveSheet.ColumnHeader.Rows(0).Height = 35
        spControles.ActiveSheet.Rows(-1).Height = 80
        spControles.ActiveSheet.ColumnHeader.RowCount = 2
        spControles.ActiveSheet.ColumnHeader.Rows(0, spControles.ActiveSheet.ColumnHeader.Rows.Count - 1).Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        Dim numeracion As Integer = 0
        spControles.ActiveSheet.Columns.Count = cantidadColumnas + 2 ' Una para solicitar y otra para rechazar evidencia.
        spControles.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "idArea" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "nombreArea" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "idUsuario" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "nombreUsuario" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "idAreaDestino" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "nombreAreaDestino" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "idUsuarioDestino" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "nombreUsuarioDestino" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "nombre" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "descripcion" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "fechaCreacion" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "fechaVencimiento" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "esUrgente" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "esExterna" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "solicitaAutorizacion" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "esAutorizado" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "esRechazado" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "estaResuelto" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "solicitaEvidencia" : numeracion += 1
        spControles.ActiveSheet.Columns(numeracion).Tag = "rechazaEvidencia" : numeracion += 1
        spControles.ActiveSheet.Columns("id").Width = 80
        spControles.ActiveSheet.Columns("idArea").Width = 80
        spControles.ActiveSheet.Columns("nombreArea").Width = 150
        spControles.ActiveSheet.Columns("idUsuario").Width = 80
        spControles.ActiveSheet.Columns("nombreUsuario").Width = 150
        spControles.ActiveSheet.Columns("idAreaDestino").Width = 80
        spControles.ActiveSheet.Columns("nombreAreaDestino").Width = 150
        spControles.ActiveSheet.Columns("idUsuarioDestino").Width = 80
        spControles.ActiveSheet.Columns("nombreUsuarioDestino").Width = 150
        spControles.ActiveSheet.Columns("nombre").Width = 300
        spControles.ActiveSheet.Columns("descripcion").Width = 500
        spControles.ActiveSheet.Columns("fechaCreacion").Width = 150
        spControles.ActiveSheet.Columns("fechaVencimiento").Width = 170
        spControles.ActiveSheet.Columns("esUrgente").Width = 170
        spControles.ActiveSheet.Columns("esExterna").Width = 170
        spControles.ActiveSheet.Columns("solicitaAutorizacion").Width = 180
        spControles.ActiveSheet.Columns("esAutorizado").Width = 170
        spControles.ActiveSheet.Columns("esRechazado").Width = 170
        spControles.ActiveSheet.Columns("estaResuelto").Width = 170
        spControles.ActiveSheet.Columns("solicitaEvidencia").Width = 170
        spControles.ActiveSheet.Columns("rechazaEvidencia").Width = 170
        spControles.ActiveSheet.Columns("esUrgente").CellType = tipoBooleano
        spControles.ActiveSheet.Columns("esExterna").CellType = tipoBooleano
        spControles.ActiveSheet.Columns("solicitaAutorizacion").CellType = tipoBooleano
        spControles.ActiveSheet.Columns("esAutorizado").CellType = tipoBooleano
        spControles.ActiveSheet.Columns("esRechazado").CellType = tipoBooleano
        spControles.ActiveSheet.Columns("estaResuelto").CellType = tipoBooleano
        spControles.ActiveSheet.Columns("solicitaEvidencia").CellType = tipoBooleano
        spControles.ActiveSheet.Columns("rechazaEvidencia").CellType = tipoBooleano
        spControles.ActiveSheet.Columns("nombre").HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Justify
        spControles.ActiveSheet.Columns("descripcion").HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Justify
        spControles.ActiveSheet.AddColumnHeaderSpanCell(0, spControles.ActiveSheet.Columns("id").Index, 2, 1)
        spControles.ActiveSheet.ColumnHeader.Cells(0, spControles.ActiveSheet.Columns("id").Index).Value = "No.".ToUpper
        spControles.ActiveSheet.AddColumnHeaderSpanCell(0, spControles.ActiveSheet.Columns("idArea").Index, 1, 2)
        spControles.ActiveSheet.ColumnHeader.Cells(0, spControles.ActiveSheet.Columns("idArea").Index).Value = "Area".ToUpper
        spControles.ActiveSheet.ColumnHeader.Cells(1, spControles.ActiveSheet.Columns("idArea").Index).Value = "No.".ToUpper
        spControles.ActiveSheet.ColumnHeader.Cells(1, spControles.ActiveSheet.Columns("nombreArea").Index).Value = "Nombre".ToUpper
        spControles.ActiveSheet.AddColumnHeaderSpanCell(0, spControles.ActiveSheet.Columns("idUsuario").Index, 1, 2)
        spControles.ActiveSheet.ColumnHeader.Cells(0, spControles.ActiveSheet.Columns("idUsuario").Index).Value = "Usuario".ToUpper
        spControles.ActiveSheet.ColumnHeader.Cells(1, spControles.ActiveSheet.Columns("idUsuario").Index).Value = "No.".ToUpper
        spControles.ActiveSheet.ColumnHeader.Cells(1, spControles.ActiveSheet.Columns("nombreUsuario").Index).Value = "Nombre".ToUpper
        spControles.ActiveSheet.AddColumnHeaderSpanCell(0, spControles.ActiveSheet.Columns("idAreaDestino").Index, 1, 2)
        spControles.ActiveSheet.ColumnHeader.Cells(0, spControles.ActiveSheet.Columns("idAreaDestino").Index).Value = "Area Destino".ToUpper
        spControles.ActiveSheet.ColumnHeader.Cells(1, spControles.ActiveSheet.Columns("idAreaDestino").Index).Value = "No.".ToUpper
        spControles.ActiveSheet.ColumnHeader.Cells(1, spControles.ActiveSheet.Columns("nombreAreaDestino").Index).Value = "Nombre".ToUpper
        spControles.ActiveSheet.AddColumnHeaderSpanCell(0, spControles.ActiveSheet.Columns("idUsuarioDestino").Index, 1, 2)
        spControles.ActiveSheet.ColumnHeader.Cells(0, spControles.ActiveSheet.Columns("idUsuarioDestino").Index).Value = "Usuario Destino".ToUpper
        spControles.ActiveSheet.ColumnHeader.Cells(1, spControles.ActiveSheet.Columns("idUsuarioDestino").Index).Value = "No.".ToUpper
        spControles.ActiveSheet.ColumnHeader.Cells(1, spControles.ActiveSheet.Columns("nombreUsuarioDestino").Index).Value = "Nombre".ToUpper
        spControles.ActiveSheet.AddColumnHeaderSpanCell(0, spControles.ActiveSheet.Columns("nombre").Index, 2, 1)
        spControles.ActiveSheet.ColumnHeader.Cells(0, spControles.ActiveSheet.Columns("nombre").Index).Value = "Nombre".ToUpper
        spControles.ActiveSheet.AddColumnHeaderSpanCell(0, spControles.ActiveSheet.Columns("descripcion").Index, 2, 1)
        spControles.ActiveSheet.ColumnHeader.Cells(0, spControles.ActiveSheet.Columns("descripcion").Index).Value = "Descripción".ToUpper
        spControles.ActiveSheet.AddColumnHeaderSpanCell(0, spControles.ActiveSheet.Columns("fechaCreacion").Index, 2, 1)
        spControles.ActiveSheet.ColumnHeader.Cells(0, spControles.ActiveSheet.Columns("fechaCreacion").Index).Value = "Fecha de Creación".ToUpper
        spControles.ActiveSheet.AddColumnHeaderSpanCell(0, spControles.ActiveSheet.Columns("fechaVencimiento").Index, 2, 1)
        spControles.ActiveSheet.ColumnHeader.Cells(0, spControles.ActiveSheet.Columns("fechaVencimiento").Index).Value = "Fecha de Vencimiento".ToUpper
        spControles.ActiveSheet.AddColumnHeaderSpanCell(0, spControles.ActiveSheet.Columns("esUrgente").Index, 2, 1)
        spControles.ActiveSheet.ColumnHeader.Cells(0, spControles.ActiveSheet.Columns("esUrgente").Index).Value = "Es Urgente?".ToUpper
        spControles.ActiveSheet.AddColumnHeaderSpanCell(0, spControles.ActiveSheet.Columns("esExterna").Index, 2, 1)
        spControles.ActiveSheet.ColumnHeader.Cells(0, spControles.ActiveSheet.Columns("esExterna").Index).Value = "Es Externa?".ToUpper
        spControles.ActiveSheet.AddColumnHeaderSpanCell(0, spControles.ActiveSheet.Columns("solicitaAutorizacion").Index, 2, 1)
        spControles.ActiveSheet.ColumnHeader.Cells(0, spControles.ActiveSheet.Columns("solicitaAutorizacion").Index).Value = "Solicita Autorización?".ToUpper
        spControles.ActiveSheet.AddColumnHeaderSpanCell(0, spControles.ActiveSheet.Columns("esAutorizado").Index, 2, 1)
        spControles.ActiveSheet.ColumnHeader.Cells(0, spControles.ActiveSheet.Columns("esAutorizado").Index).Value = "Es Autorizado?".ToUpper
        spControles.ActiveSheet.AddColumnHeaderSpanCell(0, spControles.ActiveSheet.Columns("esRechazado").Index, 2, 1)
        spControles.ActiveSheet.ColumnHeader.Cells(0, spControles.ActiveSheet.Columns("esRechazado").Index).Value = "Es Rechazado?".ToUpper
        spControles.ActiveSheet.AddColumnHeaderSpanCell(0, spControles.ActiveSheet.Columns("estaResuelto").Index, 2, 1)
        spControles.ActiveSheet.ColumnHeader.Cells(0, spControles.ActiveSheet.Columns("estaResuelto").Index).Value = "Esta Resuelto?".ToUpper
        spControles.ActiveSheet.AddColumnHeaderSpanCell(0, spControles.ActiveSheet.Columns("solicitaEvidencia").Index, 2, 1)
        spControles.ActiveSheet.ColumnHeader.Cells(0, spControles.ActiveSheet.Columns("solicitaEvidencia").Index).Value = "Solicitar Evidencia".ToUpper
        spControles.ActiveSheet.AddColumnHeaderSpanCell(0, spControles.ActiveSheet.Columns("rechazaEvidencia").Index, 2, 1)
        spControles.ActiveSheet.ColumnHeader.Cells(0, spControles.ActiveSheet.Columns("rechazaEvidencia").Index).Value = "Rechazar Evidencia".ToUpper
        Application.DoEvents()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub EditarEvidencias()

        For fila = 0 To spControles.ActiveSheet.Rows.Count - 1
            Dim id As Integer = spControles.ActiveSheet.Cells(fila, spControles.ActiveSheet.Columns("id").Index).Value
            Dim idArea As Integer = spControles.ActiveSheet.Cells(fila, spControles.ActiveSheet.Columns("idArea").Index).Value
            Dim idUsuario As Integer = spControles.ActiveSheet.Cells(fila, spControles.ActiveSheet.Columns("idUsuario").Index).Value
            Dim solicitarEvidencia As Boolean = spControles.ActiveSheet.Cells(fila, spControles.ActiveSheet.Columns("solicitaEvidencia").Index).Value
            Dim rechazarEvidencia As Boolean = spControles.ActiveSheet.Cells(fila, spControles.ActiveSheet.Columns("rechazaEvidencia").Index).Value
            If (id > 0) And (idArea > 0) And (idUsuario > 0) And (solicitarEvidencia Or rechazarEvidencia) Then
                actividades.EId = id
                actividades.EIdArea = idArea
                actividades.EIdUsuario = idUsuario
                actividades.ESolicitaEvidencia = solicitarEvidencia
                actividades.ERechazaEvidencia = rechazarEvidencia
                actividades.EditarEvidencias()
            End If
        Next
        MsgBox("Guardado finalizado.", MsgBoxStyle.ApplicationModal, "Finalizado.")
        CargarEvidenciasSpread()

    End Sub

#End Region

#End Region

#Region "Enumeraciones"

    Enum OpcionesMenu

        Autorizaciones = 0
        Evidencias = 1

    End Enum

#End Region

End Class