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

        BaseDatos.ECadenaConexionInformacion = String.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3}", LogicaActividades.DatosEmpresaPrincipal.instanciaSql, BaseDatos.ECadenaConexionInformacion, LogicaActividades.DatosEmpresaPrincipal.usuarioSql, LogicaActividades.DatosEmpresaPrincipal.contrasenaSql)
        conexionInformacion.ConnectionString = BaseDatos.ECadenaConexionInformacion

    End Sub

    Public Sub AbrirConexionCatalogo()

        BaseDatos.ECadenaConexionCatalogo = String.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3}", LogicaActividades.DatosEmpresaPrincipal.instanciaSql, BaseDatos.ECadenaConexionCatalogo, LogicaActividades.DatosEmpresaPrincipal.usuarioSql, LogicaActividades.DatosEmpresaPrincipal.contrasenaSql)
        conexionCatalogo.ConnectionString = BaseDatos.ECadenaConexionCatalogo

    End Sub

    Public Sub AbrirConexionAgenda()

        BaseDatos.ECadenaConexionAgenda = String.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3}", LogicaActividades.DatosEmpresaPrincipal.instanciaSql, BaseDatos.ECadenaConexionAgenda, LogicaActividades.DatosEmpresaPrincipal.usuarioSql, LogicaActividades.DatosEmpresaPrincipal.contrasenaSql)
        conexionAgenda.ConnectionString = BaseDatos.ECadenaConexionAgenda

    End Sub

End Module
