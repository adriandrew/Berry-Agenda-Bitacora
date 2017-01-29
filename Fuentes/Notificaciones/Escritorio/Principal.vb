Imports System.Threading
Imports System.Net.Mail
Imports System.Net.Mime
Imports System.Text

Public Class Principal

    Dim actividades As New EntidadesNotificaciones.Actividades
    Public datosEmpresa As New LogicaNotificaciones.DatosEmpresa()
    Public datosUsuario As New LogicaNotificaciones.DatosUsuario()
    Public datosArea As New LogicaNotificaciones.DatosArea()
    Public empresas As New EntidadesNotificaciones.Empresas()

#Region "Eventos"

    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Centrar()
        ConfigurarConexiones()
        'CargarEncabezados()
        ConsultarInformacionEmpresa()
        IniciarProceso()

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        'Application.Exit()

    End Sub

    Private Sub Principal_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Me.Hide()

    End Sub

#End Region

#Region "Métodos"

#Region "Genericos"

    Private Sub Centrar()

        Me.CenterToScreen()
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size

    End Sub

    Private Sub ConfigurarConexiones()

        Dim esPrueba As Boolean = False
        If (esPrueba) Then
            'baseDatos.CadenaConexionInformacion = "C:\\Berry-Agenda\\BD\\PODC\\Agenda.mdf"
            EntidadesNotificaciones.BaseDatos.ECadenaConexionInformacion = "Informacion"
            EntidadesNotificaciones.BaseDatos.ECadenaConexionAgenda = "Agenda"
            Me.datosUsuario.EId = 1
            Me.datosUsuario.ENombre = "Adrián Andrew"
            Me.datosUsuario.EIdArea = 1
        Else
            EntidadesNotificaciones.BaseDatos.ECadenaConexionInformacion = "Informacion"
            EntidadesNotificaciones.BaseDatos.ECadenaConexionAgenda = "Agenda"
            'datosEmpresa.EDirectorio & "\\Agenda.mdf" 
            Try
                Me.datosEmpresa.ObtenerParametrosInformacionEmpresa()
                Me.datosUsuario.ObtenerParametrosInformacionUsuario()
                Me.datosArea.ObtenerParametrosInformacionArea()
                'MsgBox("    Usuario: " & Me.datosUsuario.ENombre & "   Area: " & Me.datosArea.ENombre)
            Catch ex As Exception
                'MsgBox("Error al obtener parametros de información. " & vbNewLine & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Error.")
            End Try
        End If
        EntidadesNotificaciones.BaseDatos.AbrirConexionInformacion()
        EntidadesNotificaciones.BaseDatos.AbrirConexionAgenda()

    End Sub

    Private Sub CargarEncabezados()

        lblEncabezadoPrograma.Text = "Programa: " + Me.Text
        lblEncabezadoEmpresa.Text = "Empresa: " + datosEmpresa.ENombre
        lblEncabezadoUsuario.Text = "Usuario: " + datosUsuario.ENombre
        lblEncabezadoArea.Text = "Area: " + datosArea.ENombre

    End Sub

#End Region

#Region "Notificaciones"

    Private Sub ConsultarInformacionEmpresa()

        Dim datos As String() = empresas.ObtenerPredeterminada().Split("|")
        datosEmpresa.EId = Convert.ToInt32(datos(0))
        datosEmpresa.ENombre = datos(1)
        datosEmpresa.EDescripcion = datos(2)
        datosEmpresa.EDomicilio = datos(3)
        datosEmpresa.ELocalidad = datos(4)
        datosEmpresa.ERfc = datos(5)
        datosEmpresa.EDirectorio = datos(6)
        datosEmpresa.ELogo = datos(7)
        datosEmpresa.EActiva = Convert.ToBoolean(datos(8))
        datosEmpresa.EEquipo = datos(9)

    End Sub

    Private Sub CargarActividadesVencidas()

        Dim lista As New List(Of EntidadesNotificaciones.Actividades)
        actividades.EIdArea = Me.datosUsuario.EIdArea
        lista = actividades.ObtenerListadoSinResolucion()
        If Me.Visible Then
            Me.Hide()
        End If
        If Not Listado.Visible Then
            Listado.Show()
        Else
            Listado.Dispose()
            System.Threading.Thread.Sleep(5000)
            Listado.Show()
        End If
        Listado.GenerarListado(lista)
        Listado.Text &= "    Usuario: " & Me.datosUsuario.ENombre & "   Area: " & Me.datosArea.ENombre
        If lista.Count > 0 Then
            EnviarCorreo(lista)
        End If

    End Sub

    Private Sub IniciarProceso()

        Me.Hide()
        Dim hilo As New Thread(AddressOf CiclarInfinitamente)
        CheckForIllegalCrossThreadCalls = False
        Try
            hilo.Start()
            System.Threading.Thread.Sleep(30)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al iniciar programa de notificaciones.")
        Finally
        End Try

    End Sub

    Private Sub CiclarInfinitamente()

        Dim hora As Integer = 0
        Dim minutos As Integer = 0
        Dim esRangoValido As Boolean = False
        Dim esPrimeraVez As Boolean = True
        While True
            hora = Date.Now.Hour
            minutos = Date.Now.Minute
            If (minutos >= 1 And minutos <= 30) Then
                'If (minutos Mod 2) = 0 Then
                esRangoValido = True
            Else
                esRangoValido = False ' TODO. Cambiar a false.
            End If
            If (esRangoValido) And (esPrimeraVez) Then
                CargarActividadesVencidas()
                esPrimeraVez = False
                Application.DoEvents()
            ElseIf (esRangoValido) And (Not esPrimeraVez) Then
                esPrimeraVez = False
                Application.DoEvents()
            Else
                esPrimeraVez = True
                Application.DoEvents()
            End If
        End While

    End Sub

    Private Sub EnviarCorreo(ByVal lista As List(Of EntidadesNotificaciones.Actividades))

        Dim mail As New MailMessage()
        Dim adjunto1 As Attachment
        Dim emisor As String = "aaandrewlopez@gmail.com"
        Dim emisor2 As String = "Yulianapem@gmail.com"
        Dim contraseña As String = "andrew1007"
        Dim asunto As String = "Notificaciones de tareas pendientes! " & Me.datosUsuario.ENombre
        Dim mensaje As String = Me.datosUsuario.ENombre & " tienes pendientes las siguientes actividades:" & vbNewLine & vbNewLine
        Dim mensajeHtml As String = "<h2>" & mensaje & "</h2><br><br>"
        Dim datosServidor As String = "smtp.gmail.com"
        Dim puerto As Integer = 587
        mail.From = New MailAddress(emisor)
        mail.Priority = MailPriority.High
        mail.To.Add(emisor)
        mail.To.Add(emisor2)
        ' Se crean los mensajes planos y htmls.
        For indice As Integer = 0 To lista.Count - 1
            mensaje &= lista(indice).EFechaVencimiento & " " & lista(indice).ENombre & " - " & lista(indice).EDescripcion & vbNewLine & vbNewLine
            mensajeHtml &= "<img src='cid:imagen'/><h3 style='display:inline'>&nbsp;&nbsp;" & lista(indice).EFechaVencimiento & " " & lista(indice).ENombre & " - " & lista(indice).EDescripcion & "<br><br></h3>"
        Next
        ' Se adjunta la imagen del logo de berry.
        Try
            adjunto1 = New Attachment("C:\BERRY-AGENDA\logo3.png")
            mail.Attachments.Add(adjunto1)
        Catch ex As Exception
            adjunto1 = Nothing
        End Try
        mail.Subject = asunto
        mail.Body = mensaje
        ' Creamos la vista para clientes que sólo pueden acceder a texto plano...
        Dim vistaPlana As AlternateView = AlternateView.CreateAlternateViewFromString(mensaje, Encoding.UTF8, MediaTypeNames.Text.Plain)
        ' Ahora creamos la vista para clientes que pueden mostrar contenido HTML...
        Dim vistaHtml As AlternateView = AlternateView.CreateAlternateViewFromString(mensajeHtml, Encoding.UTF8, MediaTypeNames.Text.Html)
        ' Creamos el recurso a incrustar. Observad que el ID que le asignamos (arbitrario) está referenciado desde el código HTML como origen de la imagen (resaltado en amarillo)...
        Dim imagenIcono As New LinkedResource("C:\BERRY-AGENDA\logo3.jpg", MediaTypeNames.Image.Jpeg)
        imagenIcono.ContentId = "imagen"
        ' Lo incrustamos en la vista HTML...
        vistaHtml.LinkedResources.Add(imagenIcono)
        ' Por último, vinculamos ambas vistas al mensaje...
        mail.AlternateViews.Add(vistaPlana)
        mail.AlternateViews.Add(vistaHtml)
        'For j As Integer = 0 To sp1.Sheets.Count - 1
        '    For i As Integer = 0 To sp1.Sheets(j).Rows.Count - 1
        '        If sp1.Sheets(j).Cells(i, 2).Text <> "" Then
        '            If sp1.Sheets(j).Cells(i, 3).Value = True Then
        '                mail.To.Add(sp1.Sheets(j).Cells(i, 2).Text)
        '            End If
        '        End If
        '    Next
        'Next 
        Dim server As New SmtpClient(datosServidor)
        server.UseDefaultCredentials = False
        server.Port = puerto
        server.Credentials = New System.Net.NetworkCredential(emisor, contraseña)
        server.EnableSsl = True
        Try
            server.Send(mail)
            'MsgBox("Notificaciones enviadas por correo.", MsgBoxStyle.ApplicationModal, "Terminado.")
        Catch ex As Exception
            MsgBox("Hay un error al enviar correo. " & ex.Message, MsgBoxStyle.Critical, "Error.")
        End Try

    End Sub

#End Region

#End Region

End Class