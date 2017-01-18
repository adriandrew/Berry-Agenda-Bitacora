Imports System.Threading

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
        CargarEncabezados()
        ConsultarInformacionEmpresa()
        CargarActividadesSinResolver()
        'ComenzarCargarActividades() 

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        'Application.Exit()

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

        Dim esPrueba As Boolean = True
        If (esPrueba) Then
            'baseDatos.CadenaConexionInformacion = "C:\\Berry-Agenda\\BD\\PODC\\Agenda.mdf"
            EntidadesNotificaciones.BaseDatos.ECadenaConexionInformacion = "Informacion"
            EntidadesNotificaciones.BaseDatos.ECadenaConexionAgenda = "Agenda"
        Else
            EntidadesNotificaciones.BaseDatos.ECadenaConexionInformacion = "Informacion"
            EntidadesNotificaciones.BaseDatos.ECadenaConexionAgenda = "Agenda"
            'datosEmpresa.EDirectorio & "\\Agenda.mdf" 
            'Me.datosEmpresa.ObtenerParametrosInformacionEmpresa()
            'Me.datosUsuario.ObtenerParametrosInformacionUsuario()
            'Me.datosArea.ObtenerParametrosInformacionArea()
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

    Private Sub CargarActividadesSinResolver()

        Dim lista As New List(Of EntidadesNotificaciones.Actividades)
        lista = actividades.ObtenerListadoSinResolucion()

    End Sub

    Private Sub IniciarProceso(ByVal segundos As Integer)

        Me.Hide()
        Dim hilo As New Thread(AddressOf CiclarInfinitamente)
        CheckForIllegalCrossThreadCalls = False
        Try
            hilo.Start()
            System.Threading.Thread.Sleep(segundos)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al iniciar programa de notificaciones.")
        Finally
            Me.Visible = True
            Me.ShowInTaskbar = True
        End Try

    End Sub

    Private Sub CiclarInfinitamente()

        Dim hora As Integer = 0
        Dim minutos As Integer = 0
        While True
            hora = Date.Now.Hour
            minutos = Date.Now.Minute
            If (minutos >= 1 And minutos <= 15) Then 'Oficina
                Me.Show()
                Me.Visible = True 
                'ProcesaInformacion("EMPAQUE")                 
                System.Threading.Thread.Sleep(900000) ' 15 minutos.
            Else
                System.Threading.Thread.Sleep(300000) ' 5 minutos.
            End If
        End While

    End Sub

#End Region

#End Region

End Class