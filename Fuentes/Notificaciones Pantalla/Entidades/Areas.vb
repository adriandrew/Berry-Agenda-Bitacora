Imports System.Data.SqlClient

Public Class Areas

    Private id As Integer
    Private nombre As String
    Private clave As String

    Public Property EId() As Integer
        Get
            Return Me.id
        End Get
        Set(value As Integer)
            Me.id = value
        End Set
    End Property
    Public Property ENombre() As String
        Get
            Return Me.nombre
        End Get
        Set(value As String)
            Me.nombre = value
        End Set
    End Property
    Public Property EClave() As String
        Get
            Return Me.clave
        End Get
        Set(value As String)
            Me.clave = value
        End Set
    End Property

    Public Function ObtenerPorId() As List(Of Areas)

        Dim lista As New List(Of Areas)
        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo
            comando.CommandText = "SELECT * FROM Areas WHERE Id = @id"
            comando.Parameters.AddWithValue("@id", Me.EId)
            BaseDatos.conexionCatalogo.Open()
            Dim dataReader As SqlDataReader
            dataReader = comando.ExecuteReader()
            Dim areas As New Areas
            While (dataReader.Read())
                areas = New Areas()
                areas.id = Convert.ToInt32(dataReader("Id"))
                areas.nombre = dataReader("Nombre").ToString()
                areas.clave = dataReader("Clave").ToString()
                lista.Add(areas)
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
