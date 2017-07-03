Imports System.Data.SqlClient

Public Class RangosFijos

    Private id As Integer
    Private nombre As String

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

    Public Function ObtenerListadoPorId() As List(Of RangosFijos)

        Dim lista As New List(Of RangosFijos)()
        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo
            comando.CommandText = "SELECT * FROM RangosFijos WHERE Id=@id"
            comando.Parameters.AddWithValue("@id", Me.id)
            BaseDatos.conexionCatalogo.Open()
            Dim dataReader As SqlDataReader = Nothing
            dataReader = comando.ExecuteReader()
            Dim rangos As New RangosFijos()
            While (dataReader.Read())
                rangos = New RangosFijos()
                rangos.id = Convert.ToInt32(dataReader("Id"))
                rangos.nombre = dataReader("Nombre").ToString()
                lista.Add(rangos)
            End While
            BaseDatos.conexionCatalogo.Close()
            Return lista
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionCatalogo.Close()
        End Try

    End Function

    Public Function ObtenerListadoReporte() As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo
            comando.CommandText = "SELECT Id, Nombre FROM RangosFijos ORDER BY Id ASC"
            comando.Parameters.AddWithValue("@id", Me.EId)
            BaseDatos.conexionCatalogo.Open()
            Dim dataReader As SqlDataReader
            dataReader = comando.ExecuteReader()
            datos.Load(dataReader)
            BaseDatos.conexionCatalogo.Close()
            Return datos
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionCatalogo.Close()
        End Try

    End Function

End Class
