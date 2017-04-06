Imports System.Data.SqlClient

Public Class CorreosUsuarios

    Private idEmpresa As Integer
    Private idUsuario As Integer
    Private nombreUsuario As String
    Private direccion As String

    Public Property EIdEmpresa() As Integer
        Get
            Return Me.idEmpresa
        End Get
        Set(value As Integer)
            Me.idEmpresa = value
        End Set
    End Property
    Public Property EIdUsuario() As Integer
        Get
            Return Me.idUsuario
        End Get
        Set(value As Integer)
            Me.idUsuario = value
        End Set
    End Property
    Public Property ENombreUsuario() As String
        Get
            Return Me.nombreUsuario
        End Get
        Set(value As String)
            Me.nombreUsuario = value
        End Set
    End Property
    Public Property EDireccion() As String
        Get
            Return Me.direccion
        End Get
        Set(value As String)
            Me.direccion = value
        End Set
    End Property

    Public Function ObtenerListadoPorEmpresa() As List(Of CorreosUsuarios)

        Dim lista As New List(Of CorreosUsuarios)
        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo
            comando.CommandText = "SELECT U.IdEmpresa, C.IdUsuario, U.Nombre AS NombreUsuario, C.Direccion FROM Correos AS C LEFT JOIN Informacion.dbo.Usuarios AS U ON C.IdUsuario=U.Id WHERE U.IdEmpresa=@idEmpresa"
            comando.Parameters.AddWithValue("@idEmpresa", Me.EIdEmpresa)
            BaseDatos.conexionCatalogo.Open()
            Dim dataReader As SqlDataReader
            dataReader = comando.ExecuteReader()
            Dim correos As New CorreosUsuarios
            While (dataReader.Read())
                correos = New CorreosUsuarios()
                correos.idEmpresa = Convert.ToInt32(dataReader("IdEmpresa"))
                correos.idUsuario = Convert.ToInt32(dataReader("IdUsuario"))
                correos.nombreUsuario = dataReader("NombreUsuario").ToString()
                correos.direccion = dataReader("Direccion").ToString()
                lista.Add(correos)
            End While
            BaseDatos.conexionCatalogo.Close()
            Return lista
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionCatalogo.Close()
        End Try

    End Function

End Class
