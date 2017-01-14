Imports System.Data.SqlClient

Public Module BaseDatos

    Private cadenaConexionInformacion As String
    Private cadenaConexionCatalogo As String
    Private cadenaConexionAgenda As String
    Public conexionInformacion As New SqlConnection()
    Public conexionCatalogo As New SqlConnection()
    Public conexionAgenda As New SqlConnection()

    Public Property ECadenaConexionInformacion() As String
        Get
            Return BaseDatos.cadenaConexionInformacion
        End Get
        Set(value As String)
            BaseDatos.cadenaConexionInformacion = value
        End Set
    End Property
    Public Property ECadenaConexionCatalogo() As String
        Get
            Return BaseDatos.cadenaConexionCatalogo
        End Get
        Set(value As String)
            BaseDatos.cadenaConexionCatalogo = value
        End Set
    End Property
    Public Property ECadenaConexionAgenda() As String
        Get
            Return BaseDatos.cadenaConexionAgenda
        End Get
        Set(value As String)
            BaseDatos.cadenaConexionAgenda = value
        End Set
    End Property

    Public Sub AbrirConexionInformacion()

        BaseDatos.ECadenaConexionInformacion = String.Format("Data Source=.\\SQLEXPRESS;Initial Catalog={0};Integrated Security=True;Connect Timeout=30", BaseDatos.ECadenaConexionInformacion)
        conexionInformacion.ConnectionString = BaseDatos.ECadenaConexionInformacion

    End Sub

    Public Sub AbrirConexionCatalogo()

        BaseDatos.ECadenaConexionCatalogo = String.Format("Data Source=SYS21ALIEN03-PC\SQLEXPRESS;Initial Catalog={0};User Id=AdminBerry;Password=@berry", BaseDatos.ECadenaConexionCatalogo)
        'BaseDatos.ECadenaConexionCatalogo = "Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=CATALOGOS;Integrated Security=True"
        conexionCatalogo.ConnectionString = BaseDatos.ECadenaConexionCatalogo

    End Sub

    Public Sub AbrirConexionAgenda()

        BaseDatos.ECadenaConexionAgenda = String.Format("Data Source=SYS21ALIEN03-PC\SQLEXPRESS;Initial Catalog={0};User Id=AdminBerry;Password=@berry", BaseDatos.ECadenaConexionAgenda)
        'BaseDatos.ECadenaConexionAgenda = "Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=AGENDA;Integrated Security=True"
        conexionAgenda.ConnectionString = BaseDatos.ECadenaConexionAgenda

    End Sub

End Module
