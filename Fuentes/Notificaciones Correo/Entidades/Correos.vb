Imports System.Data.SqlClient

Public Class Correos

    Private idUsuario As Integer
    Private direccion As String

    Public Property EIdUsuario() As Integer
        Get
            Return Me.idUsuario
        End Get
        Set(value As Integer)
            Me.idUsuario = value
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

    Public Function ObtenerPorIdUsuario() As List(Of Correos)

        Dim lista As New List(Of Correos)
        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo
            comando.CommandText = "SELECT * FROM Correos WHERE IdUsuario=@idUsuario"
            comando.Parameters.AddWithValue("@idUsuario", Me.EIdUsuario)
            BaseDatos.conexionCatalogo.Open()
            Dim dataReader As SqlDataReader
            dataReader = comando.ExecuteReader()
            Dim correos As New Correos
            While (dataReader.Read())
                correos = New Correos
                correos.idUsuario = Convert.ToInt32(dataReader("IdUsuario").ToString())
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