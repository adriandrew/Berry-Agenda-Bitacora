Imports System.Threading
Imports System.Net.Mail
Imports System.Net.Mime
Imports System.Text

Public Class Principal

    Dim actividades As New EntidadesNotificacionesPantalla.Actividades
    Dim actividadesExternas As New EntidadesNotificacionesPantalla.ActividadesExternas
    Public datosEmpresa As New LogicaNotificacionesPantalla.DatosEmpresa()
    Public datosUsuario As New LogicaNotificacionesPantalla.DatosUsuario()
    Public datosArea As New LogicaNotificacionesPantalla.DatosArea()
    Public empresas As New EntidadesNotificacionesPantalla.Empresas()
    Dim notificaciones As New EntidadesNotificacionesPantalla.Notificaciones
    Public esPrueba As Boolean = False ' TODO. Cambiar a false.

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

        If (Me.esPrueba) Then
            'baseDatos.CadenaConexionInformacion = "C:\\Berry-Agenda\\BD\\PODC\\Agenda.mdf"
            EntidadesNotificacionesPantalla.BaseDatos.ECadenaConexionInformacion = "Informacion"
            EntidadesNotificacionesPantalla.BaseDatos.ECadenaConexionAgenda = "Agenda"
            CargarParametros(Me.esPrueba)
        Else
            EntidadesNotificacionesPantalla.BaseDatos.ECadenaConexionInformacion = "Informacion"
            EntidadesNotificacionesPantalla.BaseDatos.ECadenaConexionAgenda = "Agenda"
            'datosEmpresa.EDirectorio & "\\Agenda.mdf"  
            CargarParametros(Me.esPrueba)
        End If
        EntidadesNotificacionesPantalla.BaseDatos.AbrirConexionInformacion()
        EntidadesNotificacionesPantalla.BaseDatos.AbrirConexionAgenda()

    End Sub

    Private Sub CargarParametros(ByVal esPrueba As Boolean)

        If esPrueba Then
            Me.datosUsuario.EId = 2
            Me.datosUsuario.ENombre = "Adrián Andrew"
            Me.datosUsuario.EIdArea = 2
        Else
            Try
                Me.datosEmpresa.ObtenerParametrosInformacionEmpresa()
                Me.datosUsuario.ObtenerParametrosInformacionUsuario()
                Me.datosArea.ObtenerParametrosInformacionArea()
                'MsgBox("    Usuario: " & Me.datosUsuario.ENombre & "   Area: " & Me.datosArea.ENombre)
            Catch ex As Exception
                'MsgBox("Error al obtener parametros de información. " & vbNewLine & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Error.")
            End Try
        End If

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
        Dim esRangoValido As Boolean = False
        Dim esPrimeraVez As Boolean = True
        While True
            hora = Date.Now.Hour
            minutos = Date.Now.Minute
            If (minutos >= 1 And minutos <= 30) Then
                'If (minutos Mod 2) = 0 Then
                esRangoValido = True
            Else
                'If Me.esPrueba Then
                esRangoValido = False
                'Else
                '    esRangoValido = False
                'End If
            End If
            If ((esRangoValido) And (esPrimeraVez)) Then
                CargarActividadesVencidas()
                esPrimeraVez = False
                Application.DoEvents()
            ElseIf ((esRangoValido) And (Not esPrimeraVez)) Then
                esPrimeraVez = False
                Application.DoEvents()
            Else
                esPrimeraVez = True
                Application.DoEvents()
            End If
        End While

    End Sub

    Public Sub GuardarVisto(ByVal esVisto As Boolean)

        CargarParametros(Me.esPrueba)
        notificaciones.EIdArea = Me.datosUsuario.EIdArea
        notificaciones.EIdUsuario = Me.datosUsuario.EId
        notificaciones.EEsVisto = esVisto
        notificaciones.EFecha = DateTime.Today & " " & DateTime.Now.Hour & ":" & DateTime.Now.Minute
        notificaciones.Guardar()

    End Sub

#End Region

#End Region

End Class