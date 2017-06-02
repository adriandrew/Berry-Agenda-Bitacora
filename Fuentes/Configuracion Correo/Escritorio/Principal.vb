Imports System.IO

Public Class Principal
     
    Dim proveedores As New EntidadesConfiguracionCorreo.ProveedoresCorreo
    Dim configuracion As New EntidadesConfiguracionCorreo.ConfiguracionCorreo
    Public datosEmpresa As New LogicaConfiguracionCorreo.DatosEmpresa()
    Public datosUsuario As New LogicaConfiguracionCorreo.DatosUsuario()
    Public datosArea As New LogicaConfiguracionCorreo.DatosArea()
    Public pintado As Boolean = False
    Dim ejecutarProgramaPrincipal As New ProcessStartInfo()
    Public tieneDatos As Boolean = False
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
        CargarComboProveedores()
        CargarConfiguracion()
        Me.Enabled = True
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        Salir()

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Guardar()

    End Sub

    Private Sub btnGuardar_MouseHover(sender As Object, e As EventArgs) Handles btnGuardar.MouseHover

        AsignarTooltips("Guardar.")

    End Sub

    Private Sub btnSalir_MouseHover(sender As Object, e As EventArgs) Handles btnSalir.MouseHover

        AsignarTooltips("Salir.")

    End Sub

    Private Sub Principal_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint

        If (Not Me.pintado) Then
            Me.pintado = True
            txtDireccion.Focus()
        End If

    End Sub

    Private Sub txtDireccion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDireccion.KeyDown

        If e.KeyCode = Keys.Enter Then
            If (Not String.IsNullOrEmpty(txtDireccion.Text)) Then
                txtContrasena.Focus()
            End If
        End If

    End Sub

    Private Sub txtContrasena_KeyDown(sender As Object, e As KeyEventArgs) Handles txtContrasena.KeyDown

        If e.KeyCode = Keys.Escape Then
            txtDireccion.Focus()
        ElseIf e.KeyCode = Keys.Enter Then
            If (Not String.IsNullOrEmpty(txtContrasena.Text)) Then
                txtAsunto.Focus()
            End If
        End If

    End Sub

    Private Sub txtAsunto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAsunto.KeyDown

        If e.KeyCode = Keys.Escape Then
            txtContrasena.Focus()
        ElseIf e.KeyCode = Keys.Enter Then
            If (Not String.IsNullOrEmpty(txtAsunto.Text)) Then
                txtMensaje.Focus()
            End If
        End If

    End Sub

    Private Sub txtMensaje_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMensaje.KeyDown

        If e.KeyCode = Keys.Escape Then
            txtAsunto.Focus()
        ElseIf e.KeyCode = Keys.Enter Then
            If (Not String.IsNullOrEmpty(txtMensaje.Text)) Then
                btnGuardar.Focus()
            End If
        End If

    End Sub

    Private Sub pnlEncabezado_MouseHover(sender As Object, e As EventArgs) Handles pnlPie.MouseHover, pnlEncabezado.MouseHover, pnlCuerpo.MouseHover

        AsignarTooltips(String.Empty)

    End Sub

    Private Sub temporizador_Tick(sender As Object, e As EventArgs) Handles temporizador.Tick

        If (Me.estaCerrando) Then
            Desvanecer()
        End If

    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click

        MostrarAyuda()

    End Sub

    Private Sub btnAyuda_MouseHover(sender As Object, e As EventArgs) Handles btnAyuda.MouseHover

        AsignarTooltips("Ayuda.")

    End Sub

#End Region

#Region "Métodos"

#Region "Genericos"

    Private Sub Salir()

        Application.Exit()

    End Sub

    Private Function ValidarAccesoTotal() As Boolean

        If ((Not datosUsuario.EAccesoTotal) Or (datosUsuario.EAccesoTotal = 0) Or (datosUsuario.EAccesoTotal = False)) Then
            MsgBox("No tienes permisos suficientes para acceder a este programa.", MsgBoxStyle.Information, "Permisos insuficientes.")
            Return False
        Else
            Return True
        End If

    End Function

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
            txtAyuda.Text = "Sección de Ayuda: " & vbNewLine & vbNewLine & "* Configuración de Correo: " & vbNewLine & "En esta parte se configura la dirección y contraseña de correo como parte de las credenciales de inicio de sesión del cual se enviarán las notificaciones a los usuarios. " & vbNewLine & "En asunto va pues el asunto del correo, y mensaje el mensaje del correo. En dado caso de que se configure el asunto y/o mensaje en blanco o vacios se les pondrá un asunto y/o mensaje por defecto al enviarlos." : Application.DoEvents()
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

    Private Sub ConfigurarConexiones()

        If (Me.esDesarrollo) Then
            'baseDatos.CadenaConexionInformacion = "C:\\Berry-Agenda\\BD\\PODC\\Agenda.mdf"
            Me.datosUsuario.EId = 1
            Me.datosUsuario.EIdArea = 1
            Me.datosEmpresa.EId = 1
            Me.datosUsuario.EAccesoTotal = True
            'LogicaConfiguracionCorreo.DatosEmpresaPrincipal.instanciaSql = "ANDREW-MAC\SQLEXPRESS"
            LogicaConfiguracionCorreo.DatosEmpresaPrincipal.instanciaSql = "BERRY1-DELL\SQLEXPRESS2008"
            LogicaConfiguracionCorreo.DatosEmpresaPrincipal.usuarioSql = "AdminBerry"
            'LogicaConfiguracionCorreo.DatosEmpresaPrincipal.contrasenaSql = "@berry"
            LogicaConfiguracionCorreo.DatosEmpresaPrincipal.contrasenaSql = "@berry2017"
        Else
            'EntidadesActividades.BaseDatos.ECadenaConexionAgenda = datosEmpresa.EDirectorio & "\\Agenda.mdf"
            LogicaConfiguracionCorreo.DatosEmpresaPrincipal.ObtenerParametrosInformacionEmpresa()
            Me.datosEmpresa.ObtenerParametrosInformacionEmpresa()
            Me.datosUsuario.ObtenerParametrosInformacionUsuario()
            Me.datosArea.ObtenerParametrosInformacionArea()
        End If
        EntidadesConfiguracionCorreo.BaseDatos.ECadenaConexionAgenda = "Agenda"
        EntidadesConfiguracionCorreo.BaseDatos.ECadenaConexionCatalogo = "Catalogos"
        EntidadesConfiguracionCorreo.BaseDatos.ECadenaConexionInformacion = "Informacion"
        EntidadesConfiguracionCorreo.BaseDatos.AbrirConexionAgenda()
        EntidadesConfiguracionCorreo.BaseDatos.AbrirConexionCatalogo()
        EntidadesConfiguracionCorreo.BaseDatos.AbrirConexionInformacion()

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

    Private Sub AbrirPrograma(nombre As String, salir As Boolean)

        If (Me.esDesarrollo) Then
            Exit Sub
        End If
        ejecutarProgramaPrincipal.UseShellExecute = True
        ejecutarProgramaPrincipal.FileName = nombre & Convert.ToString(".exe")
        ejecutarProgramaPrincipal.WorkingDirectory = Application.StartupPath
        ejecutarProgramaPrincipal.Arguments = LogicaConfiguracionCorreo.DatosEmpresaPrincipal.idEmpresa.ToString().Trim().Replace(" ", "|") & " " & LogicaConfiguracionCorreo.DatosEmpresaPrincipal.activa.ToString().Trim().Replace(" ", "|") & " " & LogicaConfiguracionCorreo.DatosEmpresaPrincipal.instanciaSql.ToString().Trim().Replace(" ", "|") & " " & LogicaConfiguracionCorreo.DatosEmpresaPrincipal.rutaBd.ToString().Trim().Replace(" ", "|") & " " & LogicaConfiguracionCorreo.DatosEmpresaPrincipal.usuarioSql.ToString().Trim().Replace(" ", "|") & " " & LogicaConfiguracionCorreo.DatosEmpresaPrincipal.contrasenaSql.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de empresa principal, indice 7 ;)".Replace(" ", "|") & " " & datosEmpresa.EId.ToString().Trim().Replace(" ", "|") & " " & datosEmpresa.ENombre.Trim().Replace(" ", "|") & " " & datosEmpresa.EDescripcion.Trim().Replace(" ", "|") & " " & datosEmpresa.EDomicilio.Trim().Replace(" ", "|") & " " & datosEmpresa.ELocalidad.Trim().Replace(" ", "|") & " " & datosEmpresa.ERfc.Trim().Replace(" ", "|") & " " & datosEmpresa.EDirectorio.Trim().Replace(" ", "|") & " " & datosEmpresa.ELogo.Trim().Replace(" ", "|") & " " & datosEmpresa.EActiva.ToString().Trim().Replace(" ", "|") & " " & datosEmpresa.EEquipo.Trim().Replace(" ", "|") & " " & "Aquí terminan los de empresa, indice 18 ;)".Replace(" ", "|") & " " & datosUsuario.EId.ToString().Trim().Replace(" ", "|") & " " & datosUsuario.ENombre.Trim().Replace(" ", "|") & " " & datosUsuario.EContrasena.Trim().Replace(" ", "|") & " " & datosUsuario.ENivel.ToString().Trim().Replace(" ", "|") & " " & datosUsuario.EAccesoTotal.ToString().Trim().Replace(" ", "|") & " " & datosUsuario.EIdArea.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de usuario, indice 25 ;)".Replace(" ", "|") & " " & datosArea.EId.ToString().Trim().Replace(" ", "|") & " " & datosArea.ENombre.ToString().Trim().Replace(" ", "|") & " " & datosArea.EClave.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de area, indice 29 ;)".Replace(" ", "|")
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

    Private Sub CargarConfiguracion()

        Dim lista As New List(Of EntidadesConfiguracionCorreo.ConfiguracionCorreo)
        lista = configuracion.ObtenerListado()
        If lista.Count > 0 Then
            txtDireccion.Text = lista(0).EDireccion
            txtContrasena.Text = lista(0).EContrasena
            txtAsunto.Text = lista(0).EAsunto
            txtMensaje.Text = lista(0).EMensaje
            cbProveedores.SelectedValue = lista(0).EIdProveedor
            Me.tieneDatos = True
        Else
            Me.tieneDatos = False
        End If

    End Sub

    Private Sub Guardar()

        Dim direccion As String = txtDireccion.Text
        Dim contrasena As String = txtContrasena.Text
        Dim asunto As String = txtAsunto.Text
        Dim mensaje As String = txtMensaje.Text
        Dim idProveedor As Integer = cbProveedores.SelectedValue
        If ((Not String.IsNullOrEmpty(direccion)) And (Not String.IsNullOrEmpty(contrasena)) And (idProveedor > 0)) Then
            configuracion.EDireccion = direccion
            configuracion.EContrasena = contrasena
            configuracion.EAsunto = asunto
            configuracion.EMensaje = mensaje
            configuracion.EIdProveedor = idProveedor
            If (Me.tieneDatos) Then
                configuracion.Editar()
            Else
                configuracion.Guardar()
            End If
            MsgBox("Guardado finalizado.", MsgBoxStyle.ApplicationModal, "Finalizado.")
            CargarConfiguracion()
        End If

    End Sub

    Private Sub CargarComboProveedores()

        Dim lista As New List(Of EntidadesConfiguracionCorreo.ProveedoresCorreo)
        lista = proveedores.ObtenerListado()
        cbProveedores.DataSource = lista
        cbProveedores.ValueMember = "EId"
        cbProveedores.DisplayMember = "EDominio"

    End Sub

#End Region

#End Region
     
End Class