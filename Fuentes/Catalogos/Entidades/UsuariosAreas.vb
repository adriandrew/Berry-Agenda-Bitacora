Imports System.Data.SqlClient

Public Class UsuariosAreas

    Private idEmpresa As Integer
    Private id As Integer
    Private nombre As String
    Private contrasena As String
    Private nivel As Integer
    Private accesoTotal As Boolean
    Private idArea As Integer
    Private nombreArea As String

    Public Property EIdEmpresa() As Integer
        Get
            Return idEmpresa
        End Get
        Set(value As Integer)
            idEmpresa = value
        End Set
    End Property
    Public Property EId() As Integer
        Get
            Return id
        End Get
        Set(value As Integer)
            id = value
        End Set
    End Property
    Public Property ENombre() As String
        Get
            Return nombre
        End Get
        Set(value As String)
            nombre = value
        End Set
    End Property
    Public Property EContrasena() As String
        Get
            Return contrasena
        End Get
        Set(value As String)
            contrasena = value
        End Set
    End Property
    Public Property ENivel() As Integer
        Get
            Return nivel
        End Get
        Set(value As Integer)
            nivel = value
        End Set
    End Property
    Public Property EAccesoTotal() As Boolean
        Get
            Return accesoTotal
        End Get
        Set(value As Boolean)
            accesoTotal = value
        End Set
    End Property
    Public Property EIdArea() As Integer
        Get
            Return idArea
        End Get
        Set(value As Integer)
            idArea = value
        End Set
    End Property
    Public Property ENombreArea() As String
        Get
            Return nombreArea
        End Get
        Set(value As String)
            nombreArea = value
        End Set
    End Property

    Public Function ObtenerListadoPorEmpresa() As List(Of UsuariosAreas)

        Dim lista As New List(Of UsuariosAreas)()
        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionInformacion
            comando.CommandText = "SELECT U.*, A.Nombre AS NombreArea FROM Usuarios AS U LEFT JOIN Catalogos.dbo.Areas AS A ON U.IdArea=A.Id WHERE U.IdEmpresa=@idEmpresa"
            comando.Parameters.AddWithValue("@idEmpresa", Me.EIdEmpresa)
            BaseDatos.conexionInformacion.Open()
            Dim dataReader As SqlDataReader = comando.ExecuteReader()
            Dim usuarios As UsuariosAreas
            While dataReader.Read()
                usuarios = New UsuariosAreas()
                usuarios.EIdEmpresa = Convert.ToInt32(dataReader("IdEmpresa").ToString())
                usuarios.EId = Convert.ToInt32(dataReader("Id").ToString())
                usuarios.ENombre = dataReader("Nombre").ToString()
                usuarios.EContrasena = dataReader("Contrasena").ToString()
                usuarios.ENivel = Convert.ToInt32(dataReader("Nivel").ToString())
                usuarios.EAccesoTotal = Convert.ToBoolean(dataReader("AccesoTotal").ToString())
                usuarios.EIdArea = Convert.ToInt32(dataReader("IdArea").ToString())
                usuarios.ENombreArea = dataReader("NombreArea").ToString()
                lista.Add(usuarios)
            End While
            BaseDatos.conexionInformacion.Close()
            Return lista
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionInformacion.Close()
        End Try

    End Function

End Class