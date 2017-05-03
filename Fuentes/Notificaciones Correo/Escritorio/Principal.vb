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
    Dim configuracionProveedoresCorreo As New EntidadesNotificacionesCorreo.ConfiguracionProveedoresCorreo
    Dim correos As New EntidadesNotificacionesCorreo.Correos
    Public datosEmpresa As New LogicaNotificacionesCorreo.DatosEmpresa()
    Public datosUsuario As New LogicaNotificacionesCorreo.DatosUsuario()
    Public datosArea As New LogicaNotificacionesCorreo.DatosArea()
    Public filaActivaSpread As Integer = 0
    Public esDivisible As Boolean = False

    Public esPrueba As Boolean = False

#Region "Eventos"

    Private Sub Principal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Salir()

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

        Salir()

    End Sub

    Private Sub btnSalir_MouseHover(sender As Object, e As EventArgs) Handles btnSalir.MouseHover

        AsignarTooltips("Salir.")

    End Sub

    Private Sub pnlCuerpo_MouseHover(sender As Object, e As EventArgs) Handles pnlPie.MouseHover, pnlEncabezado.MouseHover, pnlCuerpo.MouseHover

        AsignarTooltips(String.Empty)

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
            txtAyuda.Text = "Sección de Ayuda: " & vbNewLine & vbNewLine & "* Notificaciones por Correo: " & vbNewLine & "En esta pantalla se despliegan los correos enviados a los distintos usuarios con sus tipos de actividades, internas o externas. " & vbNewLine & "En dado caso de que exista algún error al enviar, en esta misma bitácora se mostrará." : Application.DoEvents()
            pnlAyuda.Controls.Add(txtAyuda) : Application.DoEvents()
        Else
            pnlCuerpo.Visible = True : Application.DoEvents()
            pnlAyuda.Visible = False : Application.DoEvents()
        End If

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

    Private Sub Salir()

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

        If (Me.esPrueba) Then
            EntidadesNotificacionesCorreo.BaseDatos.ECadenaConexionPrincipal = "C:\Berry Agenda-Bitacora\Principal.sdf"
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
        EntidadesNotificacionesCorreo.BaseDatos.ECadenaConexionCatalogo = "Catalogos"
        EntidadesNotificacionesCorreo.BaseDatos.ECadenaConexionAgenda = "Agenda"
        EntidadesNotificacionesCorreo.BaseDatos.AbrirConexionInformacion()
        EntidadesNotificacionesCorreo.BaseDatos.AbrirConexionCatalogo()
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
        listaUsuarios = usuarios.ObtenerListadoPorEmpresa()
        ' Se obtiene la configuracion de datos de correo.
        Dim listaConfiguracion As New List(Of EntidadesNotificacionesCorreo.ConfiguracionProveedoresCorreo)
        listaConfiguracion = configuracionProveedoresCorreo.ObtenerListado()
        Dim listaConfiguracionLocal As New Object
        If listaConfiguracion.Count > 0 Then
            listaConfiguracionLocal = listaConfiguracion(0)
        Else
            MostrarEnSpread("Todos.", Now, "Falta configurar datos de correo.", "Gerente")
            System.Threading.Thread.Sleep(60000)
            Exit Sub
        End If
        If (String.IsNullOrEmpty(listaConfiguracionLocal.EDireccion) Or String.IsNullOrEmpty(listaConfiguracionLocal.EContrasena) Or String.IsNullOrEmpty(listaConfiguracionLocal.EServidor) Or String.IsNullOrEmpty(listaConfiguracionLocal.EPuerto)) Then
            MostrarEnSpread("Todos.", Now, "Falta configurar datos de correo.", "Gerente")
            System.Threading.Thread.Sleep(60000)
            Exit Sub
        End If
        ' Se recorre cada uno y se envian sus actividades pendientes, internas y externas.
        For fila = 0 To listaUsuarios.Count - 1
            Dim listaActividades As New List(Of EntidadesNotificacionesCorreo.Actividades) : Dim listaExterna As New List(Of EntidadesNotificacionesCorreo.ActividadesExternas)
            Dim listaActividadesLocal As New Object
            ' Actividades internas.
            actividades.EIdArea = listaUsuarios(fila).EIdArea
            actividades.EIdUsuario = listaUsuarios(fila).EId
            listaActividades = actividades.ObtenerListadoPendientes()
            listaActividadesLocal = listaActividades
            If listaActividades.Count > 0 Then
                EnviarCorreo(listaConfiguracionLocal, listaActividadesLocal, TipoActividad.internas, listaUsuarios(fila).EId, listaUsuarios(fila).ENombre, "Internas")
            End If
            System.Threading.Thread.Sleep(5000)
            listaActividadesLocal = New Object
            ' Actividades externas.
            actividadesExternas.EIdArea = listaUsuarios(fila).EIdArea
            actividadesExternas.EIdUsuario = listaUsuarios(fila).EId
            listaExterna = actividadesExternas.ObtenerListadoPendientesExternas()
            listaActividadesLocal = listaExterna
            If listaExterna.Count > 0 Then
                EnviarCorreo(listaConfiguracionLocal, listaActividadesLocal, TipoActividad.externas, listaUsuarios(fila).EId, listaUsuarios(fila).ENombre, "Externas")
            End If
            listaActividadesLocal = New Object
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
                esRangoValido = True
            Else
                If Me.esPrueba Then
                    esRangoValido = True
                Else
                    esRangoValido = False
                End If
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

    Private Sub EnviarCorreo(ByVal listaConfiguracion As Object, ByVal listaActividades As Object, ByVal tipo As Integer, ByVal idUsuario As Integer, ByVal nombreUsuario As String, ByVal tipoNombre As String)

        Me.Cursor = Cursors.WaitCursor
        Dim descripcionError As String = String.Empty
        Dim datosExtra As String = String.Empty
        Dim mail As New MailMessage()
        Dim archivoAdjunto As Attachment
        Dim emisor As String = listaConfiguracion.EDireccion & listaConfiguracion.EDominio '"aaandrewlopez@gmail.com"
        Dim receptor As String = "yulianapem@gmail.com"
        Dim contrasena As String = listaConfiguracion.EContrasena
        If tipo = TipoActividad.externas Then
            datosExtra = "externas "
        End If
        Dim asunto As String = IIf(String.IsNullOrEmpty(listaConfiguracion.EAsunto), "Tareas pendientes ", listaConfiguracion.EAsunto & " ") & datosExtra & Today
        Dim mensaje As String = nombreUsuario & IIf(String.IsNullOrEmpty(listaConfiguracion.EMensaje), " tienes pendientes las siguientes actividades:", " " & listaConfiguracion.EMensaje & " ") & vbNewLine & vbNewLine
        Dim mensajeHtml As String = "<h2>" & mensaje & "</h2><br><br>"
        Dim servidorProveedor As String = listaConfiguracion.EServidor '"smtp.gmail.com"
        Dim puerto As Integer = listaConfiguracion.EPuerto '587
        mail.From = New MailAddress(emisor)
        mail.Priority = MailPriority.High 
        Dim listaCorreos As New List(Of EntidadesNotificacionesCorreo.Correos)
        correos.EIdUsuario = idUsuario
        listaCorreos = correos.ObtenerPorIdUsuario()
        If listaCorreos.Count <= 0 Then
            descripcionError &= "Debe especificar un destinatario. "
        End If
        For indice As Integer = 0 To listaCorreos.Count - 1
            mail.To.Add(listaCorreos(indice).EDireccion)
        Next
        ' Se crean los mensajes planos y htmls.
        For indice As Integer = 0 To listaActividades.Count - 1
            datosExtra = String.Empty
            If tipo = TipoActividad.externas Then
                datosExtra = " Solicita " & listaActividades(indice).ENombreUsuario & " "
            End If
            mensaje &= listaActividades(indice).EFechaVencimiento & datosExtra & " " & listaActividades(indice).ENombre & " - " & listaActividades(indice).EDescripcion & vbNewLine & vbNewLine
            mensajeHtml &= "<img src='cid:imagen'/><h3 style='display:inline'>&nbsp;&nbsp;" & listaActividades(indice).EFechaVencimiento & " " & datosExtra & listaActividades(indice).ENombre & " - " & listaActividades(indice).EDescripcion & "<br><br></h3>"
        Next
        ' Se adjunta la imagen del logo de berry.
        Try
            Dim rutaLogoPng As String = String.Empty
            If (Me.esPrueba) Then
                rutaLogoPng = "C:\BERRY AGENDA-BITACORA\logo3.png"
            Else
                rutaLogoPng = CurDir() & "\logo3.png"
            End If
            archivoAdjunto = New Attachment(rutaLogoPng)
            mail.Attachments.Add(archivoAdjunto)
        Catch ex As Exception
            archivoAdjunto = Nothing
        End Try
        mail.Subject = asunto
        mail.Body = mensaje
        ' Creamos la vista para clientes que sólo pueden acceder a texto plano...
        Dim vistaPlana As AlternateView = AlternateView.CreateAlternateViewFromString(mensaje, Encoding.UTF8, MediaTypeNames.Text.Plain)
        ' Ahora creamos la vista para clientes que pueden mostrar contenido HTML...
        Dim vistaHtml As AlternateView = AlternateView.CreateAlternateViewFromString(mensajeHtml, Encoding.UTF8, MediaTypeNames.Text.Html)
        ' Creamos el recurso a incrustar. Observad que el ID que le asignamos (arbitrario) está referenciado desde el código HTML como origen de la imagen.
        Dim rutaLogoJpg As String = String.Empty
        If (Me.esPrueba) Then
            rutaLogoJpg = "C:\BERRY AGENDA-BITACORA\logo3.jpg"
        Else
            rutaLogoJpg = CurDir() & "\logo3.jpg"
        End If
        Dim imagenIcono As New LinkedResource(rutaLogoJpg, MediaTypeNames.Image.Jpeg)
        imagenIcono.ContentId = "imagen"
        ' Lo incrustamos en la vista HTML...
        vistaHtml.LinkedResources.Add(imagenIcono)
        ' Por último, vinculamos ambas vistas al mensaje...
        mail.AlternateViews.Add(vistaPlana)
        mail.AlternateViews.Add(vistaHtml)
        Dim servidor As New SmtpClient(servidorProveedor)
        servidor.UseDefaultCredentials = False
        servidor.Port = puerto
        servidor.Credentials = New System.Net.NetworkCredential(emisor, contrasena)
        servidor.EnableSsl = True
        Try
            servidor.Send(mail)
            notificador.BalloonTipTitle = "Correo para " & nombreUsuario
            notificador.BalloonTipText = "Notificaciones enviadas por correo!"
            notificador.BalloonTipIcon = ToolTipIcon.Info
            notificador.ShowBalloonTip(5)
            MostrarEnSpread(tipoNombre, Now, notificador.BalloonTipText, nombreUsuario)
        Catch ex As Exception
            notificador.BalloonTipTitle = "Correo para " & nombreUsuario
            notificador.BalloonTipText = "Error al enviar notificaciones por correo. " & descripcionError & ex.Message
            notificador.BalloonTipIcon = ToolTipIcon.Error
            notificador.ShowBalloonTip(5)
            MostrarEnSpread(tipoNombre, Now, notificador.BalloonTipText, nombreUsuario)
        End Try
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub MostrarEnSpread(ByVal tipo As String, ByVal fecha As String, ByVal descripcion As String, ByVal usuario As String)

        Try
regresa:
            spNotificaciones.ActiveSheet.Cells(filaActivaSpread, spNotificaciones.ActiveSheet.Columns("tipo").Index).Value = tipo : Application.DoEvents()
            spNotificaciones.ActiveSheet.Cells(filaActivaSpread, spNotificaciones.ActiveSheet.Columns("descripcion").Index).Value = descripcion : Application.DoEvents()
            spNotificaciones.ActiveSheet.Cells(filaActivaSpread, spNotificaciones.ActiveSheet.Columns("usuario").Index).Value = usuario : Application.DoEvents()
            spNotificaciones.ActiveSheet.Cells(filaActivaSpread, spNotificaciones.ActiveSheet.Columns("fecha").Index).Value = fecha : Application.DoEvents()
            spNotificaciones.ActiveSheet.Rows.Count += 1 : Application.DoEvents()
            If Me.esDivisible Then
                spNotificaciones.ActiveSheet.Rows(filaActivaSpread).BackColor = Color.LightCyan
            Else
                spNotificaciones.ActiveSheet.Rows(filaActivaSpread).BackColor = Color.White
            End If
            spNotificaciones.Refresh()
        Catch
            GoTo regresa
        End Try
        Me.filaActivaSpread += 1
        System.Threading.Thread.Sleep(2000)

    End Sub

    Private Sub FormatearSpreadGeneral()

        Try
regresa:
            spNotificaciones.Reset() : Application.DoEvents()
            spNotificaciones.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Seashell
            spNotificaciones.Visible = True : Application.DoEvents()
            spNotificaciones.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Regular) : Application.DoEvents()
            spNotificaciones.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
            spNotificaciones.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        Catch
            GoTo regresa
        End Try

    End Sub

    Private Sub FormatearSpreadNotificaciones()

        Try
regresa:
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
            spNotificaciones.ActiveSheet.Columns("descripcion").Width = 600 : Application.DoEvents()
            spNotificaciones.ActiveSheet.Columns("usuario").Width = 250 : Application.DoEvents()
            spNotificaciones.ActiveSheet.Columns("fecha").Width = 250 : Application.DoEvents()
            spNotificaciones.ActiveSheet.ColumnHeader.Cells(0, spNotificaciones.ActiveSheet.Columns("tipo").Index).Value = "Tipo".ToUpper : Application.DoEvents()
            spNotificaciones.ActiveSheet.ColumnHeader.Cells(0, spNotificaciones.ActiveSheet.Columns("descripcion").Index).Value = "Descripción".ToUpper : Application.DoEvents()
            spNotificaciones.ActiveSheet.ColumnHeader.Cells(0, spNotificaciones.ActiveSheet.Columns("usuario").Index).Value = "Usuario Enviado".ToUpper : Application.DoEvents()
            spNotificaciones.ActiveSheet.ColumnHeader.Cells(0, spNotificaciones.ActiveSheet.Columns("fecha").Index).Value = "Fecha".ToUpper : Application.DoEvents()
            spNotificaciones.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect : Application.DoEvents()
        Catch
            GoTo regresa
        End Try

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