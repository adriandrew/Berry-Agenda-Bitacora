Imports System.Threading
Imports System.Net.Mail
Imports System.Net.Mime
Imports System.Text

Public Class Principal

    Dim empresasPrincipal As New EntidadesNotificacionesPantalla.EmpresasPrincipal()
    Dim empresas As New EntidadesNotificacionesPantalla.Empresas()
    Dim usuarios As New EntidadesNotificacionesPantalla.Usuarios()
    Dim areas As New EntidadesNotificacionesPantalla.Areas()
    Dim registro As New EntidadesNotificacionesPantalla.Registro()
    Dim notificaciones As New EntidadesNotificacionesPantalla.Notificaciones
    Dim actividades As New EntidadesNotificacionesPantalla.Actividades
    Dim actividadesExternas As New EntidadesNotificacionesPantalla.ActividadesExternas
    Public datosEmpresa As New LogicaNotificacionesPantalla.DatosEmpresa()
    Public datosUsuario As New LogicaNotificacionesPantalla.DatosUsuario()
    Public datosArea As New LogicaNotificacionesPantalla.DatosArea()
    Public tieneParametros As Boolean = False
    Public nombreEsteEquipo As String = My.Computer.Name

    Public esPrueba As Boolean = False

#Region "Eventos"

    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Centrar()
        ConfigurarConexiones()
        'CargarEncabezados()
        IniciarProceso()

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        'Application.Exit()

    End Sub

    Private Sub Principal_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Me.Hide()

    End Sub

    Private Sub btnSalir_MouseHover(sender As Object, e As EventArgs) Handles btnSalir.MouseHover

        AsignarTooltips("Salir.")

    End Sub

    Private Sub pnlEncabezado_MouseHover(sender As Object, e As EventArgs) Handles pnlPie.MouseHover, pnlEncabezado.MouseHover, pnlCuerpo.MouseHover

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

    Private Sub Centrar()

        Me.CenterToScreen()
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size

    End Sub

    Private Sub ConfigurarConexionPrincipal()

        If Me.esPrueba Then
            EntidadesNotificacionesPantalla.BaseDatos.ECadenaConexionPrincipal = "C:\Berry-Bitacora\Principal.sdf"
        Else
            Dim ruta As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
            ruta = ruta.Replace("file:\", Nothing)
            EntidadesNotificacionesPantalla.BaseDatos.ECadenaConexionPrincipal = String.Format("{0}\Principal.sdf", ruta)
        End If
        EntidadesNotificacionesPantalla.BaseDatos.AbrirConexionPrincipal()

    End Sub

    Private Sub ConfigurarConexiones()

        ' Se obtiene si tiene parametros.
        Dim parametros() = Environment.GetCommandLineArgs().ToArray()
        If (parametros.Length > 1) Then
            Me.tieneParametros = True
        End If
        If (Me.esPrueba) Then
            'baseDatos.CadenaConexionInformacion = "C:\\Berry-Agenda\\BD\\PODC\\Agenda.mdf"
            'LogicaNotificacionesPantalla.DatosEmpresaPrincipal.instanciaSql = "ANDREW-MAC\SQLEXPRESS"
            'LogicaNotificacionesPantalla.DatosEmpresaPrincipal.usuarioSql = "AdminBerry"
            'LogicaNotificacionesPantalla.DatosEmpresaPrincipal.contrasenaSql = "@berry"
            ConfigurarConexionPrincipal()
            ConsultarInformacionEmpresaPrincipal()
        Else
            'baseDatos.CadenaConexionInformacion = datosEmpresa.EDirectorio & "\\Agenda.mdf"
            ' Si tiene parametros se toman de ahí.
            If Me.tieneParametros Then
                LogicaNotificacionesPantalla.DatosEmpresaPrincipal.ObtenerParametrosInformacionEmpresa()
            Else ' Si no tiene parametros se consulta la empresa por defecto, despues de eso se consulta el equipo, para saber que usuario es.
                ConfigurarConexionPrincipal()
                ConsultarInformacionEmpresaPrincipal()
            End If
        End If
        EntidadesNotificacionesPantalla.BaseDatos.ECadenaConexionInformacion = "Informacion"
        EntidadesNotificacionesPantalla.BaseDatos.ECadenaConexionCatalogo = "Catalogos"
        EntidadesNotificacionesPantalla.BaseDatos.ECadenaConexionAgenda = "Agenda"
        EntidadesNotificacionesPantalla.BaseDatos.AbrirConexionInformacion()
        EntidadesNotificacionesPantalla.BaseDatos.AbrirConexionCatalogo()
        EntidadesNotificacionesPantalla.BaseDatos.AbrirConexionAgenda()
        CargarParametros() 

    End Sub

    Private Sub CargarParametros()

        If Me.esPrueba Then
            'Me.datosUsuario.EId = 2
            'Me.datosUsuario.ENombre = "Adrián Andrew"
            'Me.datosUsuario.EIdArea = 2
            ObtenerRegistroPorIdEmpresaYNombreEquipo()
        Else
            If Me.tieneParametros Then
                Me.datosEmpresa.ObtenerParametrosInformacionEmpresa()
                Me.datosUsuario.ObtenerParametrosInformacionUsuario()
                Me.datosArea.ObtenerParametrosInformacionArea()
                ' Se guarda registro de que equipos tienen notificaciones en pantalla.
                GuardarEditarRegistro()
            Else
                ' Se obtienen registros de lo que corresponda a esta empresa y este nombre de equipo.
                ObtenerRegistroPorIdEmpresaYNombreEquipo()
            End If
        End If

    End Sub

    Private Sub CargarEncabezados()

        lblEncabezadoPrograma.Text = "Programa: " + Me.Text
        lblEncabezadoEmpresa.Text = "Empresa: " + datosEmpresa.ENombre
        lblEncabezadoUsuario.Text = "Usuario: " + datosUsuario.ENombre
        lblEncabezadoArea.Text = "Area: " + datosArea.ENombre

    End Sub

    Private Sub ConsultarInformacionEmpresaPrincipal()

        Dim lista As New List(Of EntidadesNotificacionesPantalla.EmpresasPrincipal)()
        lista = empresasPrincipal.ObtenerPredeterminada()
        LogicaNotificacionesPantalla.DatosEmpresaPrincipal.idEmpresa = Convert.ToInt32(lista(0).EIdEmpresa)
        LogicaNotificacionesPantalla.DatosEmpresaPrincipal.activa = Convert.ToBoolean(lista(0).EActiva.ToString())
        LogicaNotificacionesPantalla.DatosEmpresaPrincipal.instanciaSql = Convert.ToString(lista(0).EInstanciaSql.ToString())
        LogicaNotificacionesPantalla.DatosEmpresaPrincipal.rutaBd = lista(0).ERutaBd.ToString()
        LogicaNotificacionesPantalla.DatosEmpresaPrincipal.usuarioSql = lista(0).EUsuarioSql.ToString()
        LogicaNotificacionesPantalla.DatosEmpresaPrincipal.contrasenaSql = lista(0).EContrasenaSql.ToString()

    End Sub

    Private Sub ConsultarInformacionEmpresa(ByVal idEmpresa As Integer)

        empresas.EId = idEmpresa
        Dim datos As New List(Of EntidadesNotificacionesPantalla.Empresas)
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

    Public Sub ConsultarInformacionUsuario(ByVal idEmpresa As Integer, ByVal idUsuario As Integer)
         
        usuarios.EIdEmpresa = idEmpresa
        usuarios.EId = idUsuario
        Dim datos As New List(Of EntidadesNotificacionesPantalla.Usuarios)
        datos = usuarios.ObtenerPorId()
        datosUsuario.EId = datos(0).EId
        datosUsuario.ENombre = datos(0).ENombre
        datosUsuario.EContrasena = datos(0).EContrasena
        datosUsuario.ENivel = datos(0).ENivel
        datosUsuario.EAccesoTotal = datos(0).EAccesoTotal
        datosUsuario.EIdArea = datos(0).EIdArea

    End Sub

    Public Sub ConsultarInformacionArea(ByVal idArea As Integer)

        areas.EId = idArea
        Dim datos As New List(Of EntidadesNotificacionesPantalla.Areas)
        datos = areas.ObtenerPorId()
        datosArea.EId = datos(0).EId
        datosArea.ENombre = datos(0).ENombre
        datosArea.EClave = datos(0).EClave

    End Sub

    Private Sub GuardarEditarRegistro()

        Dim idEmpresa As Integer = Me.datosEmpresa.EId
        Dim idUsuario As Integer = Me.datosUsuario.EId
        Dim idArea As Integer = Me.datosArea.EId
        Dim idModulo As Integer = 0 ' Aquí van a ir cuando sean distintos modulos.
        Dim nombreEquipo As String = Me.nombreEsteEquipo
        If (idEmpresa > 0) And (Not String.IsNullOrEmpty(nombreEquipo)) Then
            registro.EIdEmpresa = idEmpresa
            registro.EIdArea = idArea
            registro.EIdUsuario = idUsuario
            registro.EIdModulo = idModulo
            registro.ENombreEquipo = nombreEquipo
            Dim tieneRegistro As Boolean = registro.ValidarPorId()
            If tieneRegistro Then
                registro.Editar()
            Else
                registro.Guardar()
            End If
        End If

    End Sub

    Private Sub ObtenerRegistroPorIdEmpresaYNombreEquipo()

        Dim lista As New List(Of EntidadesNotificacionesPantalla.Registro)
        registro.EIdEmpresa = LogicaNotificacionesPantalla.DatosEmpresaPrincipal.idEmpresa
        registro.ENombreEquipo = Me.nombreEsteEquipo
        lista = registro.ObtenerPorIdEmpresayNombreEquipo()
        ConsultarInformacionEmpresa(LogicaNotificacionesPantalla.DatosEmpresaPrincipal.idEmpresa)
        If lista.Count > 0 Then
            ConsultarInformacionUsuario(LogicaNotificacionesPantalla.DatosEmpresaPrincipal.idEmpresa, lista(0).EIdUsuario)
            ConsultarInformacionArea(lista(0).EIdArea)
        End If

    End Sub

#End Region

#Region "Todos"

    Private Sub CargarActividadesVencidas()

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
        'Listado.AcomodarPaneles() ' Esta descontinuado.
        Dim lista As New List(Of EntidadesNotificacionesPantalla.Actividades) : Dim listaExterna As New List(Of EntidadesNotificacionesPantalla.ActividadesExternas)
        Dim listaLocal As New Object
        ' Actividades internas.
        actividades.EIdArea = Me.datosUsuario.EIdArea
        actividades.EIdUsuario = Me.datosUsuario.EId
        lista = actividades.ObtenerListadoPendientes()
        listaLocal = lista
        Listado.GenerarListado(listaLocal, Listado.TipoActividad.internas)
        listaLocal = New Object
        ' Actividades externas.
        actividadesExternas.EIdArea = Me.datosUsuario.EIdArea
        actividadesExternas.EIdUsuario = Me.datosUsuario.EId
        listaExterna = actividadesExternas.ObtenerListadoPendientesExternas()
        listaLocal = listaExterna
        Listado.GenerarListado(listaLocal, Listado.TipoActividad.externas)
        listaLocal = New Object
        Listado.Text &= "    Usuario: " & Me.datosUsuario.ENombre & "   Area: " & Me.datosArea.ENombre

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
        Dim esPrimeraVezAbierto As Boolean = True ' Es para cuando se abre este programa.
        Dim esRangoValido As Boolean = False ' Es el rango de tiempo valido.
        Dim esPrimeraVezRango As Boolean = True ' Es el contadador de la primera vez que se entra de nuevo al rango.
        While True
            hora = Date.Now.Hour
            minutos = Date.Now.Minute
            If (minutos >= 1 And minutos <= 30) Then
                'If (minutos Mod 2) = 0 Then
                esRangoValido = True
            Else
                esRangoValido = False
            End If
            If ((esRangoValido) And (esPrimeraVezRango)) Or (esPrimeraVezAbierto) Then
                CargarActividadesVencidas()
                esPrimeraVezAbierto = False
                esPrimeraVezRango = False
                Application.DoEvents()
            ElseIf (Not esRangoValido) Then
                esPrimeraVezRango = True
                Application.DoEvents()
            Else
                Application.DoEvents()
            End If
        End While

    End Sub

    Public Sub GuardarVisto(ByVal esVisto As Boolean)

        CargarParametros()
        notificaciones.EIdArea = Me.datosUsuario.EIdArea
        notificaciones.EIdUsuario = Me.datosUsuario.EId
        notificaciones.EEsVisto = esVisto
        notificaciones.EFecha = DateTime.Today & " " & DateTime.Now.Hour & ":" & DateTime.Now.Minute
        notificaciones.Guardar()

    End Sub

#End Region

#End Region

End Class