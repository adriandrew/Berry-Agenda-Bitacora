Imports System.Data.SqlClient

Public Class Actividades

    Private id As Integer
    Private idUsuario As Integer
    Private nombre As String
    Private descripcion As String
    Private fechaCreacion As Date
    Private fechaVencimiento As Date
    Private esUrgente As Boolean

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
    Public Property EEsUrgente() As String
        Get
            Return Me.esUrgente
        End Get
        Set(value As String)
            Me.esUrgente = value
        End Set
    End Property

    Public Function ObtenerListado() As List(Of Actividades)

        Dim lista As New List(Of Actividades)
        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionAgenda
            comando.CommandText = "SELECT * FROM Actividades"
            BaseDatos.conexionAgenda.Open()
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
                actividades.esUrgente = dataReader("EsUrgente").ToString()
                lista.Add(actividades)
            End While
            BaseDatos.conexionAgenda.Close()
            Return lista
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ObtenerListadoSinResolucion() As List(Of Actividades)

        Dim lista As New List(Of Actividades)
        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionAgenda
            comando.CommandText = "SELECT A.* FROM Actividades AS A LEFT JOIN ActividadesResueltas AS AR ON A.Id = AR.IdActividad WHERE AR.IdActividad IS NULL AND CONVERT(CHAR(10), FechaVencimiento, 121) < CONVERT(CHAR(10), GETDATE(), 121) ORDER BY FechaVencimiento ASC"
            BaseDatos.conexionAgenda.Open()
            Dim dataReader As SqlDataReader
            dataReader = comando.ExecuteReader()
            Dim actividades As New Actividades
            While (dataReader.Read())
                actividades = New Actividades()
                actividades.id = Convert.ToInt32(dataReader("Id"))
                actividades.idUsuario = Convert.ToInt32(dataReader("IdUsuario"))
                actividades.nombre = dataReader("Nombre").ToString()
                actividades.descripcion = dataReader("Descripcion").ToString()
                actividades.fechaCreacion = dataReader("FechaCreacion").ToString()
                actividades.fechaVencimiento = dataReader("FechaVencimiento").ToString()
                actividades.esUrgente = dataReader("EsUrgente").ToString()
                lista.Add(actividades)
            End While
            BaseDatos.conexionAgenda.Close()
            Return lista
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ObtenerListadoPorId() As List(Of Actividades)

        Dim lista As New List(Of Actividades)()
        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionAgenda
            comando.CommandText = "SELECT * FROM Actividades WHERE Id=@id"
            comando.Parameters.AddWithValue("@id", Me.EId)
            BaseDatos.conexionAgenda.Open()
            Dim dataReader As SqlDataReader = comando.ExecuteReader()
            Dim Actividades As Actividades
            While dataReader.Read()
                Actividades = New Actividades()
                Actividades.id = Convert.ToInt32(dataReader("Id"))
                Actividades.nombre = dataReader("Nombre").ToString()
                Actividades.descripcion = dataReader("Descripcion").ToString()
                Actividades.fechaCreacion = dataReader("FechaCreacion").ToString()
                Actividades.fechaVencimiento = dataReader("FechaVencimiento").ToString()
                Actividades.esUrgente = dataReader("EsUrgente").ToString()
                lista.Add(Actividades)
            End While
            BaseDatos.conexionAgenda.Close()
            Return lista
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionAgenda.Close()
        End Try

    End Function

    Public Sub Guardar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionAgenda
            comando.CommandText = "INSERT INTO Actividades VALUES (@id, @idUsuario, @nombre, @descripcion, @fechaCreacion, @fechaVencimiento, @esUrgente)"
            comando.Parameters.AddWithValue("@id", Me.EId)
            comando.Parameters.AddWithValue("@idUsuario", Me.EIdUsuario)
            comando.Parameters.AddWithValue("@nombre", Me.ENombre)
            comando.Parameters.AddWithValue("@descripcion", Me.EDescripcion)
            comando.Parameters.AddWithValue("@fechaCreacion", Me.EFechaCreacion)
            comando.Parameters.AddWithValue("@fechaVencimiento", Me.EFechaVencimiento)
            comando.Parameters.AddWithValue("@esUrgente", Me.EEsUrgente)
            BaseDatos.conexionAgenda.Open()
            comando.ExecuteNonQuery()
            BaseDatos.conexionAgenda.Close()
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionAgenda.Close()
        End Try

    End Sub

    Public Sub Editar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionAgenda
            comando.CommandText = "UPDATE Actividades SET IdUsuario=@idUsuario, Nombre=@nombre, Descripcion=@descripcion, FechaCreacion=@fechaCreacion, FechaVencimiento=@fechaVencimiento, EsUrgente=@esUrgente WHERE Id=@id"
            comando.Parameters.AddWithValue("@id", Me.EId)
            comando.Parameters.AddWithValue("@idUsuario", Me.EIdUsuario)
            comando.Parameters.AddWithValue("@nombre", Me.ENombre)
            comando.Parameters.AddWithValue("@descripcion", Me.EDescripcion)
            comando.Parameters.AddWithValue("@fechaCreacion", Me.EFechaCreacion)
            comando.Parameters.AddWithValue("@fechaVencimiento", Me.EFechaVencimiento)
            comando.Parameters.AddWithValue("@esUrgente", Me.EEsUrgente)
            BaseDatos.conexionAgenda.Open()
            comando.ExecuteNonQuery()
            BaseDatos.conexionAgenda.Close()
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionAgenda.Close()
        End Try

    End Sub

    Public Sub Eliminar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionAgenda
            comando.CommandText = "DELETE FROM Actividades WHERE Id=@id"
            comando.Parameters.AddWithValue("@id", Me.EId)
            BaseDatos.conexionAgenda.Open()
            comando.ExecuteNonQuery()
            BaseDatos.conexionAgenda.Close()
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionAgenda.Close()
        End Try

    End Sub

    Public Function ValidarPorNumero() As Boolean

        Try
            Dim resultado As Boolean = False
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionAgenda
            comando.CommandText = "SELECT * FROM Actividades WHERE Id=@id"
            comando.Parameters.AddWithValue("@id", Me.EId)
            BaseDatos.conexionAgenda.Open()
            Dim dataReader As SqlDataReader
            dataReader = comando.ExecuteReader()
            If (dataReader.HasRows) Then
                resultado = True
            Else
                resultado = False
            End If
            BaseDatos.conexionAgenda.Close()
            Return resultado
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionInformacion.Close()
        End Try

    End Function

    Public Function ObtenerMaximo() As Integer

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionAgenda
            comando.CommandText = "SELECT MAX(Id) AS Id FROM Actividades" 
            BaseDatos.conexionAgenda.Open()
            Dim dataReader As SqlDataReader
            dataReader = comando.ExecuteReader()
            If (Not dataReader.HasRows) Then
                Return 1
            End If
            While (dataReader.Read())
                If (String.IsNullOrEmpty(dataReader("Id").ToString())) Then
                    Me.id = 1
                Else
                    Me.id = Convert.ToInt32(dataReader("Id").ToString()) + 1
                End If
            End While
            BaseDatos.conexionAgenda.Close()
            Return Me.id
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionAgenda.Close()
        End Try
    End Function

End Class
