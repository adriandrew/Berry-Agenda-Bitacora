Imports System.Data.SqlServerCe

Public Class EmpresasPrincipal

    Private idEmpresa As Integer
    Private activa As Boolean
    Private instanciaSql As String
    Private rutaBd As String
    Private usuarioSql As String
    Private contrasenaSql As String

    Public Property EIdEmpresa() As Integer
        Get
            Return Me.idEmpresa
        End Get
        Set(value As Integer)
            Me.idEmpresa = value
        End Set
    End Property
    Public Property EActiva() As Boolean
        Get
            Return Me.activa
        End Get
        Set(value As Boolean)
            Me.activa = value
        End Set
    End Property
    Public Property EInstanciaSql() As String
        Get
            Return Me.instanciaSql
        End Get
        Set(value As String)
            Me.instanciaSql = value
        End Set
    End Property
    Public Property ERutaBd() As String
        Get
            Return rutaBd
        End Get
        Set(value As String)
            rutaBd = value
        End Set
    End Property
    Public Property EUsuarioSql() As String
        Get
            Return usuarioSql
        End Get
        Set(value As String)
            usuarioSql = value
        End Set
    End Property
    Public Property EContrasenaSql() As String
        Get
            Return contrasenaSql
        End Get
        Set(value As String)
            contrasenaSql = value
        End Set
    End Property

    Public Function ObtenerPredeterminada() As List(Of EmpresasPrincipal)

        Dim lista As New List(Of EmpresasPrincipal)()
        Try
            Dim comando As New SqlCeCommand()
            comando.Connection = BaseDatos.conexionPrincipal
            comando.CommandText = "SELECT * FROM Empresas WHERE Activa='TRUE'"
            BaseDatos.conexionPrincipal.Open()
            Dim dataReader As SqlCeDataReader = Nothing
            dataReader = comando.ExecuteReader()
            Dim empresasPrincipal As EmpresasPrincipal
            While (dataReader.Read())
                empresasPrincipal = New EmpresasPrincipal()
                empresasPrincipal.EIdEmpresa = Convert.ToInt32(dataReader("IdEmpresa"))
                empresasPrincipal.EActiva = Convert.ToBoolean(dataReader("Activa").ToString())
                empresasPrincipal.EInstanciaSql = dataReader("InstanciaSql").ToString()
                empresasPrincipal.ERutaBd = dataReader("RutaBd").ToString()
                empresasPrincipal.EUsuarioSql = dataReader("UsuarioSql").ToString()
                empresasPrincipal.EContrasenaSql = dataReader("ContrasenaSql").ToString()
                lista.Add(empresasPrincipal)
            End While
            BaseDatos.conexionPrincipal.Close()
            Return lista
        Catch ex As Exception
            Throw ex
        End Try

    End Function

End Class
