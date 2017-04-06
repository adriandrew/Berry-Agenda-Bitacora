Imports System.Threading
Imports System.Net.Mail
Imports System.Net.Mime
Imports System.Text

Public Class Principal

    Dim empresasPrincipal As New EntidadesNotificacionesCorreo.EmpresasPrincipal()
    Dim empresas As New EntidadesNotificacionesCorreo.Empresas()
    Dim actividades As New EntidadesNotificacionesCorreo.Actividades
    Dim actividadesExternas As New EntidadesNotificacionesCorreo.ActividadesExternas
    Dim usuarios As New EntidadesNotificacionesCorreo.Usuarios
    Dim notificaciones As New EntidadesNotificacionesCorreo.Notificaciones
    Public datosEmpresa As New LogicaNotificacionesCorreo.DatosEmpresa()
    Public datosUsuario As New LogicaNotificacionesCorreo.DatosUsuario()
    Public datosArea As New LogicaNotificacionesCorreo.DatosArea()
    Public filaActivaSpread As Integer = 0
    Public esDivisible As Boolean = False

    Public esPrueba As Boolean = False

#Region "Eventos"

    Private Sub Principal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Cerrar()

    End Sub

    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Centrar()
        AsignarTooltips()
        ConfigurarConexionPrincipal() 
        ConsultarInformacionEmpresaPrincipalPredeterminada()
        ConfigurarConexiones()
        ConsultarInformacionEmpresa()
        CargarEncabezados()
        FormatearSpreadGeneral()
        FormatearSpreadNotificaciones()
        IniciarProceso()

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        Cerrar()

    End Sub

    Private Sub btnSalir_MouseHover(sender As Object, e As EventArgs) Handles btnSalir.MouseHover

        AsignarTooltips("Salir.")

    End Sub

    Private Sub pnlCuerpo_MouseHover(sender As Object, e As EventArgs) Handles pnlPie.MouseHover, pnlEncabezado.MouseHover, pnlCuerpo.MouseHover

        AsignarTooltips(String.Empty)

    End Sub

#End Region

#Region "Métodos"

#Region "Genericos"

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

    Private Sub Cerrar()

        Try
            Application.ExitThread()
            End
        Catch ex As Exception
            End
        End Try

    End Sub

    Private Sub Centrar()

        Me.CenterToScreen()
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size

    End Sub

    Private Sub ConfigurarConexionPrincipal()

        If Me.esPrueba Then
            EntidadesNotificacionesCorreo.BaseDatos.ECadenaConexionPrincipal = "C:\Berry-Bitacora\Principal.sdf"
        Else
            Dim ruta As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
            ruta = ruta.Replace("file:\", Nothing)
            EntidadesNotificacionesCorreo.BaseDatos.ECadenaConexionPrincipal = String.Format("{0}\Principal.sdf", ruta)
        End If
        EntidadesNotificacionesCorreo.BaseDatos.AbrirConexionPrincipal()

    End Sub

    Private Sub ConfigurarConexiones()

        If (Me.esPrueba) Then
            'baseDatos.CadenaConexionInformacion = "C:\\Berry-Agenda\\BD\\PODC\\Agenda.mdf" 
        Else
            'baseDatos.CadenaConexionInformacion = datosEmpresa.EDirectorio & "\\Agenda.mdf"  
        End If
        EntidadesNotificacionesCorreo.BaseDatos.ECadenaConexionInformacion = "Informacion"
        EntidadesNotificacionesCorreo.BaseDatos.ECadenaConexionAgenda = "Agenda"
        EntidadesNotificacionesCorreo.BaseDatos.AbrirConexionInformacion()
        EntidadesNotificacionesCorreo.BaseDatos.AbrirConexionAgenda()

    End Sub

    Private Sub ConsultarInformacionEmpresaPrincipalPredeterminada()

        Dim lista As New List(Of EntidadesNotificacionesCorreo.EmpresasPrincipal)()
        lista = empresasPrincipal.ObtenerPredeterminada()
        LogicaNotificacionesCorreo.DatosEmpresaPrincipal.idEmpresa = Convert.ToInt32(lista(0).EIdEmpresa)
        LogicaNotificacionesCorreo.DatosEmpresaPrincipal.activa = Convert.ToBoolean(lista(0).EActiva.ToString())
        LogicaNotificacionesCorreo.DatosEmpresaPrincipal.instanciaSql = Convert.ToString(lista(0).EInstanciaSql.ToString())
        LogicaNotificacionesCorreo.DatosEmpresaPrincipal.rutaBd = lista(0).ERutaBd.ToString()
        LogicaNotificacionesCorreo.DatosEmpresaPrincipal.usuarioSql = lista(0).EUsuarioSql.ToString()
        LogicaNotificacionesCorreo.DatosEmpresaPrincipal.contrasenaSql = lista(0).EContrasenaSql.ToString()

    End Sub

    Private Sub ConsultarInformacionEmpresa()

        empresas.EId = LogicaNotificacionesCorreo.DatosEmpresaPrincipal.idEmpresa
        Dim datos As New List(Of EntidadesNotificacionesCorreo.Empresas)
        datos = empresas.ObtenerPorId()
        datosEmpresa.EId = datos(0).EId
        datosEmpresa.ENombre = datos(0).ENombre
        datosEmpresa.EDescripcion = datos(0).EDescripcion
        datosEmpresa.EDomicilio = datos(0).EDomicilio
        datosEmpresa.ELocalidad = datos(0).ELocalidad
        datosEmpresa.ERfc = datos(0).ERfc
        datosEmpresa.EDirectorio = datos(0).EDirectorio
        datosEmpresa.ELogo = datos(0).ELogo
        datosEmpresa.EActiva = datos(0).EActiva
        datosEmpresa.EEquipo = datos(0).EEquipo

    End Sub

    Private Sub CargarEncabezados()

        lblEncabezadoPrograma.Text = "Programa: " + Me.Text
        lblEncabezadoEmpresa.Text = "Empresa: " + Me.datosEmpresa.ENombre
        lblEncabezadoUsuario.Text = "Usuario: " + "Todos"
        lblEncabezadoArea.Text = "Area: " + "Todos"

    End Sub

#End Region

#Region "Todos"

    Private Sub CargarActividadesVencidas()

        ' Se obtienen los distintos usuarios existentes.
        Dim listaUsuarios As New List(Of EntidadesNotificacionesCorreo.Usuarios)
        usuarios.EIdEmpresa = Me.datosEmpresa.EId
        listaUsuarios = usuarios.ObtenerListadoPorEmpresa
        ' Se recorre cada uno y se envian sus actividades pendientes, internas y externas.
        For fila = 0 To listaUsuarios.Count - 1
            Dim lista As New List(Of EntidadesNotificacionesCorreo.Actividades) : Dim listaExterna As New List(Of EntidadesNotificacionesCorreo.ActividadesExternas)
            Dim listaLocal As New Object
            ' Actividades internas.
            actividades.EIdArea = listaUsuarios(fila).EIdArea
            actividades.EIdUsuario = listaUsuarios(fila).EId
            lista = actividades.ObtenerListadoPendientes()
            listaLocal = lista
            If lista.Count > 0 Then
                EnviarCorreo(listaLocal, TipoActividad.internas, listaUsuarios(fila).ENombre, "Internas")
            End If
            System.Threading.Thread.Sleep(5000)
            listaLocal = New Object
            ' Actividades externas.
            actividadesExternas.EIdArea = listaUsuarios(fila).EIdArea
            actividadesExternas.EIdUsuario = listaUsuarios(fila).EId
            listaExterna = actividadesExternas.ObtenerListadoPendientesExternas()
            listaLocal = listaExterna
            If listaExterna.Count > 0 Then
                EnviarCorreo(listaLocal, TipoActividad.externas, listaUsuarios(fila).ENombre, "Externas")
            End If
            listaLocal = New Object
            System.Threading.Thread.Sleep(10000)
        Next

    End Sub

    Private Sub IniciarProceso()

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
        While True
            hora = Date.Now.Hour
            minutos = Date.Now.Minute
            If (minutos = 1) Then
                'If (minutos Mod 2) = 0 Then
                esRangoValido = True
            Else
                esRangoValido = False
            End If
            If (esRangoValido) Then
                If Me.esDivisible Then
                    Me.esDivisible = False
                Else
                    Me.esDivisible = True
                End If
                CargarActividadesVencidas()
                Application.DoEvents()
            End If
        End While

    End Sub

    Private Sub EnviarCorreo(ByVal lista As Object, ByVal tipo As Integer, ByVal nombreUsuario As String, ByVal tipoNombre As String)

        Me.Cursor = Cursors.WaitCursor
        'notificador.BalloonTipTitle = "Correo"
        'notificador.BalloonTipText = "Enviando notificaciones por correo..."
        'notificador.BalloonTipIcon = ToolTipIcon.Info
        'notificador.ShowBalloonTip(1)
        Dim datosExtra As String = String.Empty
        Dim mail As New MailMessage()
        Dim adjunto1 As Attachment
        Dim emisor As String = "aaandrewlopez@gmail.com"
        Dim emisor2 As String = "yulianapem@gmail.com"
        Dim contraseña As String = "andrew1007"
        If tipo = TipoActividad.externas Then
            datosExtra = "externas "
        End If
        Dim asunto As String = "Tareas pendientes " & datosExtra & Today ' nombreUsuario
        Dim mensaje As String = nombreUsuario & " tienes pendientes las siguientes actividades:" & vbNewLine & vbNewLine
        Dim mensajeHtml As String = "<h2>" & mensaje & "</h2><br><br>"
        Dim datosServidor As String = "smtp.gmail.com"
        Dim puerto As Integer = 587
        mail.From = New MailAddress(emisor)
        mail.Priority = MailPriority.High
        mail.To.Add(emisor)
        mail.To.Add(emisor2)
        ' Se crean los mensajes planos y htmls.
        For indice As Integer = 0 To lista.Count - 1
            datosExtra = String.Empty
            If tipo = TipoActividad.externas Then
                datosExtra = " Solicita " & lista(indice).ENombreUsuario & " "
            End If
            mensaje &= lista(indice).EFechaVencimiento & datosExtra & " " & lista(indice).ENombre & " - " & lista(indice).EDescripcion & vbNewLine & vbNewLine
            mensajeHtml &= "<img src='cid:imagen'/><h3 style='display:inline'>&nbsp;&nbsp;" & lista(indice).EFechaVencimiento & " " & datosExtra & lista(indice).ENombre & " - " & lista(indice).EDescripcion & "<br><br></h3>"
        Next
        ' Se adjunta la imagen del logo de berry.
        Try
            Dim rutaLogoPng As String = String.Empty
            If Me.esPrueba Then
                rutaLogoPng = "C:\BERRY-BITACORA\logo3.png"
            Else
                rutaLogoPng = CurDir() & "\logo3.png" ' TODO. Corregir ruta.
            End If
            adjunto1 = New Attachment(rutaLogoPng)
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
        Dim rutaLogoJpg As String = String.Empty
        If Me.esPrueba Then
            rutaLogoJpg = "C:\BERRY-BITACORA\logo3.jpg"
        Else
            rutaLogoJpg = CurDir() & "\logo3.jpg"
        End If
        Dim imagenIcono As New LinkedResource(rutaLogoJpg, MediaTypeNames.Image.Jpeg) ' TODO. Corregir ruta.
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
            notificador.BalloonTipTitle = "Correo para " & nombreUsuario
            notificador.BalloonTipText = "Notificaciones enviadas por correo!"
            notificador.BalloonTipIcon = ToolTipIcon.Info
            notificador.ShowBalloonTip(5)
            MostrarEnSpread(tipoNombre, Now, notificador.BalloonTipText, nombreUsuario)
        Catch ex As Exception
            notificador.BalloonTipTitle = "Correo para " & nombreUsuario
            notificador.BalloonTipText = "Error al enviar notificaciones por correo. " & ex.Message
            notificador.BalloonTipIcon = ToolTipIcon.Error
            notificador.ShowBalloonTip(5)
            MostrarEnSpread(tipoNombre, Now, notificador.BalloonTipText, nombreUsuario)
        End Try
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub MostrarEnSpread(ByVal tipo As String, ByVal fecha As String, ByVal descripcion As String, ByVal usuario As String)

        spNotificaciones.ActiveSheet.Cells(filaActivaSpread, spNotificaciones.ActiveSheet.Columns("tipo").Index).Value = tipo : Application.DoEvents()
        spNotificaciones.ActiveSheet.Cells(filaActivaSpread, spNotificaciones.ActiveSheet.Columns("descripcion").Index).Value = descripcion : Application.DoEvents()
        spNotificaciones.ActiveSheet.Cells(filaActivaSpread, spNotificaciones.ActiveSheet.Columns("usuario").Index).Value = usuario : Application.DoEvents()
        spNotificaciones.ActiveSheet.Cells(filaActivaSpread, spNotificaciones.ActiveSheet.Columns("fecha").Index).Value = fecha : Application.DoEvents()
        spNotificaciones.ActiveSheet.Rows.Count += 1 : Application.DoEvents()
        If Me.esDivisible Then
            spNotificaciones.ActiveSheet.Rows(filaActivaSpread).BackColor = Color.LightCyan
        Else

        End If
        spNotificaciones.Refresh()
        Me.filaActivaSpread += 1
        System.Threading.Thread.Sleep(2000)

    End Sub

    Private Sub FormatearSpreadGeneral()

        spNotificaciones.Reset() : Application.DoEvents()
        spNotificaciones.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Seashell
        spNotificaciones.Visible = True : Application.DoEvents()
        spNotificaciones.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Regular) : Application.DoEvents()
        spNotificaciones.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        spNotificaciones.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded

    End Sub

    Private Sub FormatearSpreadNotificaciones()

        spNotificaciones.ActiveSheet.GrayAreaBackColor = Color.White : Application.DoEvents()
        spNotificaciones.ActiveSheet.ColumnHeader.Rows(0).Height = 30 : Application.DoEvents()
        spNotificaciones.ActiveSheet.Rows(-1).Height = 25 : Application.DoEvents()
        spNotificaciones.ActiveSheet.ColumnHeader.Rows(0).Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold) : Application.DoEvents()
        Dim numeracion As Integer = 0
        spNotificaciones.ActiveSheet.Columns.Count = 4
        spNotificaciones.ActiveSheet.Rows.Count = 1
        spNotificaciones.ActiveSheet.Columns(numeracion).Tag = "tipo" : numeracion += 1
        spNotificaciones.ActiveSheet.Columns(numeracion).Tag = "descripcion" : numeracion += 1
        spNotificaciones.ActiveSheet.Columns(numeracion).Tag = "usuario" : numeracion += 1
        spNotificaciones.ActiveSheet.Columns(numeracion).Tag = "fecha" : numeracion += 1
        spNotificaciones.ActiveSheet.Columns("tipo").Width = 100 : Application.DoEvents()
        spNotificaciones.ActiveSheet.Columns("descripcion").Width = 400 : Application.DoEvents()
        spNotificaciones.ActiveSheet.Columns("usuario").Width = 250 : Application.DoEvents()
        spNotificaciones.ActiveSheet.Columns("fecha").Width = 250 : Application.DoEvents()
        spNotificaciones.ActiveSheet.ColumnHeader.Cells(0, spNotificaciones.ActiveSheet.Columns("tipo").Index).Value = "Tipo".ToUpper : Application.DoEvents()
        spNotificaciones.ActiveSheet.ColumnHeader.Cells(0, spNotificaciones.ActiveSheet.Columns("descripcion").Index).Value = "Descripción".ToUpper : Application.DoEvents()
        spNotificaciones.ActiveSheet.ColumnHeader.Cells(0, spNotificaciones.ActiveSheet.Columns("usuario").Index).Value = "Usuario Enviado".ToUpper : Application.DoEvents()
        spNotificaciones.ActiveSheet.ColumnHeader.Cells(0, spNotificaciones.ActiveSheet.Columns("fecha").Index).Value = "Fecha".ToUpper : Application.DoEvents()
        spNotificaciones.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect : Application.DoEvents()

    End Sub

#End Region

#End Region

#Region "Numeraciones"

    Public Enum TipoActividad

        internas = 0
        externas = 1

    End Enum

#End Region

End Class