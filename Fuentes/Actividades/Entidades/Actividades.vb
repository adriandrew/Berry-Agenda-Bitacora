Imports System.Data.SqlClient

Public Class Actividades

    Private id As Integer
    Private idUsuario As Integer
    Private nombre As String
    Private descripcion As String
    Private fechaCreacion As Date
    Private fechaVencimiento As Date
    Private esUrente As Boolean

    Public Property EId() As Integer
        Get
            Return Me.id
        End Get
        Set(value As Integer)
            Me.id = value
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
    Public Property ENombre() As String
        Get
            Return Me.nombre
        End Get
        Set(value As String)
            Me.nombre = value
        End Set
    End Property
    Public Property EDescripcion() As String
        Get
            Return Me.descripcion
        End Get
        Set(value As String)
            Me.descripcion = value
        End Set
    End Property
    Public Property EFechaCreacion() As String
        Get
            Return Me.fechaCreacion
        End Get
        Set(value As String)
            Me.fechaCreacion = value
        End Set
    End Property
    Public Property EFechaVencimiento() As String
        Get
            Return Me.fechaVencimiento
        End Get
        Set(value As String)
            Me.fechaVencimiento = value
        End Set
    End Property
    Public Property EEsUrente() As String
        Get
            Return Me.esUrente
        End Get
        Set(value As String)
            Me.esUrente = value
        End Set
    End Property

    Public Function ObtenerListado() As List(Of Actividades)

        Dim lista As New List(Of Actividades)
        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo
            comando.CommandText = "SELECT * FROM Areas"
            BaseDatos.conexionCatalogo.Open()
            Dim dataReader As SqlDataReader
            dataReader = comando.ExecuteReader()
            Dim actividades As New Actividades
            While (dataReader.Read())
                actividades = New Actividades()
                actividades.id = Convert.ToInt32(dataReader("Id"))
                actividades.nombre = dataReader("Nombre").ToString()
                actividades.descripcion = dataReader("Descripcion").ToString()
                actividades.fechaCreacion = dataReader("FechaCreacion").ToString()
                actividades.fechaVencimiento = dataReader("FechaVencimiento").ToString()
                actividades.esUrente = dataReader("EsUrente").ToString()
                lista.Add(actividades)
            End While
            BaseDatos.conexionCatalogo.Close()
            Return lista
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Sub Guardar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo
            comando.CommandText = "INSERT INTO Areas VALUES (@id, @nombre, @clave)"
            comando.Parameters.AddWithValue("@id", Me.EId)
            comando.Parameters.AddWithValue("@nombre", Me.ENombre)
            comando.Parameters.AddWithValue("@clave", Me.EClave)
            BaseDatos.conexionCatalogo.Open()
            comando.ExecuteNonQuery()
            BaseDatos.conexionCatalogo.Close()
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionCatalogo.Close()
        End Try

    End Sub

    Public Sub Editar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo
            comando.CommandText = "UPDATE Areas SET Nombre=@nombre, Clave=@clave WHERE Id=@id"
            comando.Parameters.AddWithValue("@id", Me.EId)
            comando.Parameters.AddWithValue("@nombre", Me.ENombre)
            comando.Parameters.AddWithValue("@clave", Me.EClave)
            BaseDatos.conexionCatalogo.Open()
            comando.ExecuteNonQuery()
            BaseDatos.conexionCatalogo.Close()
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionCatalogo.Close()
        End Try

    End Sub

    Public Sub Eliminar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo
            comando.CommandText = "DELETE FROM Areas WHERE Id=@id"
            comando.Parameters.AddWithValue("@id", Me.id)
            BaseDatos.conexionCatalogo.Open()
            comando.ExecuteNonQuery()
            BaseDatos.conexionCatalogo.Close()
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionCatalogo.Close()
        End Try

    End Sub

    Public Function ValidarPorNumero() As Boolean

        Try
            Dim resultado As Boolean = False
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo
            comando.CommandText = "SELECT * FROM Areas WHERE Id=@id"
            comando.Parameters.AddWithValue("@id", Me.EId)
            BaseDatos.conexionCatalogo.Open()
            Dim dataReader As SqlDataReader
            dataReader = comando.ExecuteReader()
            If (dataReader.HasRows) Then
                resultado = True
            Else
                resultado = False
            End If
            BaseDatos.conexionCatalogo.Close()
            Return resultado
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionInformacion.Close()
        End Try

    End Function


End Class
