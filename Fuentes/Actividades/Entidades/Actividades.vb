Imports System.Data.SqlClient

Public Class Actividades

    Private id As Integer
    Private idArea As Integer
    Private idUsuario As Integer
    Private nombre As String
    Private descripcion As String
    Private fechaCreacion As Date
    Private fechaVencimiento As Date
    Private esUrgente As Boolean
    Private esExterna As Boolean
    Private idAreaDestino As Integer
    Private idUsuarioDestino As Integer
    Private esAutorizado As Boolean
    Private esRechazado As Boolean
    Private estaResuelto As Boolean

    Public Property EId() As Integer
        Get
            Return Me.id
        End Get
        Set(value As Integer)
            Me.id = value
        End Set
    End Property
    Public Property EIdArea() As Integer
        Get
            Return Me.idArea
        End Get
        Set(value As Integer)
            Me.idArea = value
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
    Public Property EEsUrgente() As Boolean
        Get
            Return Me.esUrgente
        End Get
        Set(value As Boolean)
            Me.esUrgente = value
        End Set
    End Property
    Public Property EEsExterna() As Boolean
        Get
            Return Me.esExterna
        End Get
        Set(value As Boolean)
            Me.esExterna = value
        End Set
    End Property
    Public Property EIdAreaDestino() As Integer
        Get
            Return Me.idAreaDestino
        End Get
        Set(value As Integer)
            Me.idAreaDestino = value
        End Set
    End Property
    Public Property EIdUsuarioDestino() As Integer
        Get
            Return Me.idUsuarioDestino
        End Get
        Set(value As Integer)
            Me.idUsuarioDestino = value
        End Set
    End Property
    Public Property EEsAutorizado() As Boolean
        Get
            Return Me.esAutorizado
        End Get
        Set(value As Boolean)
            Me.esAutorizado = value
        End Set
    End Property
    Public Property EEsRechazado() As Boolean
        Get
            Return Me.esRechazado
        End Get
        Set(value As Boolean)
            Me.esRechazado = value
        End Set
    End Property
    Public Property EEstaResuelto() As Boolean
        Get
            Return Me.estaResuelto
        End Get
        Set(value As Boolean)
            Me.estaResuelto = value
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
                actividades.idArea = Convert.ToInt32(dataReader("IdArea"))
                actividades.idUsuario = Convert.ToInt32(dataReader("IdUsuario"))
                actividades.nombre = dataReader("Nombre").ToString()
                actividades.descripcion = dataReader("Descripcion").ToString()
                actividades.fechaCreacion = dataReader("FechaCreacion").ToString()
                actividades.fechaVencimiento = dataReader("FechaVencimiento").ToString()
                actividades.esUrgente = dataReader("EsUrgente").ToString()
                actividades.esExterna = IIf(Not IsDBNull(dataReader("EsExterna")), dataReader("EsExterna"), False)
                actividades.idAreaDestino = Convert.ToInt32(IIf(IsNumeric(dataReader("IdAreaDestino")), dataReader("IdAreaDestino"), 0))
                actividades.idUsuarioDestino = Convert.ToInt32(IIf(IsNumeric(dataReader("IdUsuarioDestino")), dataReader("IdUsuarioDestino"), 0))
                actividades.esAutorizado = IIf(Not IsDBNull(dataReader("EsAutorizado")), dataReader("EsAutorizado"), False)
                actividades.esRechazado = IIf(Not IsDBNull(dataReader("EsRechazado")), dataReader("EsRechazado"), False)
                actividades.estaResuelto = IIf(Not IsDBNull(dataReader("EstaResuelto")), dataReader("EstaResuelto"), False)
                lista.Add(actividades)
            End While
            BaseDatos.conexionAgenda.Close()
            Return lista
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionAgenda.Close()
        End Try

    End Function

    Public Function ObtenerListadoPendientes() As List(Of Actividades)

        Dim lista As New List(Of Actividades)
        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionAgenda
            comando.CommandText = "SELECT A.* FROM Actividades AS A LEFT JOIN ActividadesResueltas AS AR ON A.Id = AR.IdActividad AND A.IdArea = AR.IdArea WHERE A.IdArea=@idArea AND A.IdUsuario=@idUsuario AND AR.IdActividad IS NULL AND AR.IdArea IS NULL"
            comando.Parameters.AddWithValue("@idArea", Me.EIdArea)
            comando.Parameters.AddWithValue("@idUsuario", Me.EIdUsuario)
            BaseDatos.conexionAgenda.Open()
            Dim dataReader As SqlDataReader
            dataReader = comando.ExecuteReader()
            Dim actividades As New Actividades
            While (dataReader.Read())
                actividades = New Actividades()
                actividades.id = Convert.ToInt32(dataReader("Id"))
                actividades.idArea = Convert.ToInt32(dataReader("IdArea"))
                actividades.idUsuario = Convert.ToInt32(dataReader("IdUsuario"))
                actividades.nombre = dataReader("Nombre").ToString()
                actividades.descripcion = dataReader("Descripcion").ToString()
                actividades.fechaCreacion = dataReader("FechaCreacion").ToString()
                actividades.fechaVencimiento = dataReader("FechaVencimiento").ToString()
                actividades.esUrgente = dataReader("EsUrgente").ToString()
                actividades.esExterna = IIf(Not IsDBNull(dataReader("EsExterna")), dataReader("EsExterna"), False)
                actividades.idAreaDestino = Convert.ToInt32(IIf(IsNumeric(dataReader("IdAreaDestino")), dataReader("IdAreaDestino"), 0))
                actividades.idUsuarioDestino = Convert.ToInt32(IIf(IsNumeric(dataReader("IdUsuarioDestino")), dataReader("IdUsuarioDestino"), 0))
                actividades.esAutorizado = IIf(Not IsDBNull(dataReader("EsAutorizado")), dataReader("EsAutorizado"), False)
                actividades.esRechazado = IIf(Not IsDBNull(dataReader("EsRechazado")), dataReader("EsRechazado"), False)
                actividades.estaResuelto = IIf(Not IsDBNull(dataReader("EstaResuelto")), dataReader("EstaResuelto"), False)
                lista.Add(actividades)
            End While
            BaseDatos.conexionAgenda.Close()
            Return lista
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionAgenda.Close()
        End Try

    End Function

    Public Function ObtenerListadoPorId() As List(Of Actividades)

        Dim lista As New List(Of Actividades)()
        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionAgenda
            comando.CommandText = "SELECT * FROM Actividades WHERE Id=@id AND IdArea=@idArea"
            comando.Parameters.AddWithValue("@id", Me.EId)
            comando.Parameters.AddWithValue("@idArea", Me.EIdArea)
            BaseDatos.conexionAgenda.Open()
            Dim dataReader As SqlDataReader = comando.ExecuteReader()
            Dim actividades As Actividades
            While dataReader.Read()
                actividades = New Actividades()
                actividades.id = Convert.ToInt32(dataReader("Id"))
                actividades.idArea = Convert.ToInt32(dataReader("IdArea"))
                actividades.idUsuario = Convert.ToInt32(dataReader("IdUsuario"))
                actividades.nombre = dataReader("Nombre").ToString()
                actividades.descripcion = dataReader("Descripcion").ToString()
                actividades.fechaCreacion = dataReader("FechaCreacion").ToString()
                actividades.fechaVencimiento = dataReader("FechaVencimiento").ToString()
                actividades.esUrgente = dataReader("EsUrgente").ToString() 
                actividades.esExterna = IIf(Not IsDBNull(dataReader("EsExterna")), dataReader("EsExterna"), False)
                actividades.idAreaDestino = Convert.ToInt32(IIf(IsNumeric(dataReader("IdAreaDestino")), dataReader("IdAreaDestino"), 0))
                actividades.idUsuarioDestino = Convert.ToInt32(IIf(IsNumeric(dataReader("IdUsuarioDestino")), dataReader("IdUsuarioDestino"), 0))
                actividades.esAutorizado = IIf(Not IsDBNull(dataReader("EsAutorizado")), dataReader("EsAutorizado"), False)
                actividades.esRechazado = IIf(Not IsDBNull(dataReader("EsRechazado")), dataReader("EsRechazado"), False)
                actividades.estaResuelto = IIf(Not IsDBNull(dataReader("EstaResuelto")), dataReader("EstaResuelto"), False)
                lista.Add(actividades)
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
            comando.CommandText = "INSERT INTO Actividades VALUES (@id, @idArea, @idUsuario, @nombre, @descripcion, @fechaCreacion, @fechaVencimiento, @esUrgente, @esExterna, @idAreaDestino, @idUsuarioDestino, @esAutorizado, @esRechazado, @estaResuelto)"
            comando.Parameters.AddWithValue("@id", Me.EId)
            comando.Parameters.AddWithValue("@idArea", Me.EIdArea)
            comando.Parameters.AddWithValue("@idUsuario", Me.EIdUsuario)
            comando.Parameters.AddWithValue("@nombre", Me.ENombre)
            comando.Parameters.AddWithValue("@descripcion", Me.EDescripcion)
            comando.Parameters.AddWithValue("@fechaCreacion", Me.EFechaCreacion)
            comando.Parameters.AddWithValue("@fechaVencimiento", Me.EFechaVencimiento)
            comando.Parameters.AddWithValue("@esUrgente", Me.EEsUrgente)
            comando.Parameters.AddWithValue("@esExterna", Me.EEsExterna)
            comando.Parameters.AddWithValue("@idAreaDestino", Me.EIdAreaDestino)
            comando.Parameters.AddWithValue("@idUsuarioDestino", Me.EIdUsuarioDestino)
            comando.Parameters.AddWithValue("@esAutorizado", Me.EEsAutorizado)
            comando.Parameters.AddWithValue("@esRechazado", Me.EEsRechazado)
            comando.Parameters.AddWithValue("@estaResuelto", Me.EEstaResuelto)
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
            comando.CommandText = "UPDATE Actividades SET IdUsuario=@idUsuario, Nombre=@nombre, Descripcion=@descripcion, FechaCreacion=@fechaCreacion, FechaVencimiento=@fechaVencimiento, EsUrgente=@esUrgente, EsExterna=@esExterna, IdAreaDestino=@idAreaDestino, IdUsuarioDestino=@idUsuarioDestino, EsAutorizado=@esAutorizado, EsRechazado=@esRechazado, EstaResuelto=@estaResuelto WHERE Id=@id AND IdArea=@idArea"
            comando.Parameters.AddWithValue("@id", Me.EId)
            comando.Parameters.AddWithValue("@idArea", Me.EIdArea)
            comando.Parameters.AddWithValue("@idUsuario", Me.EIdUsuario)
            comando.Parameters.AddWithValue("@nombre", Me.ENombre)
            comando.Parameters.AddWithValue("@descripcion", Me.EDescripcion)
            comando.Parameters.AddWithValue("@fechaCreacion", Me.EFechaCreacion)
            comando.Parameters.AddWithValue("@fechaVencimiento", Me.EFechaVencimiento)
            comando.Parameters.AddWithValue("@esUrgente", Me.EEsUrgente)
            comando.Parameters.AddWithValue("@esExterna", Me.EEsExterna)
            comando.Parameters.AddWithValue("@idAreaDestino", Me.EIdAreaDestino)
            comando.Parameters.AddWithValue("@idUsuarioDestino", Me.EIdUsuarioDestino)
            comando.Parameters.AddWithValue("@esAutorizado", Me.EEsAutorizado)
            comando.Parameters.AddWithValue("@esRechazado", Me.EEsRechazado)
            comando.Parameters.AddWithValue("@estaResuelto", Me.EEstaResuelto)
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
            comando.CommandText = "DELETE FROM Actividades WHERE Id=@id AND IdArea=@idArea"
            comando.Parameters.AddWithValue("@id", Me.EId)
            comando.Parameters.AddWithValue("@idArea", Me.EIdArea)
            BaseDatos.conexionAgenda.Open()
            comando.ExecuteNonQuery()
            BaseDatos.conexionAgenda.Close()
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionAgenda.Close()
        End Try

    End Sub

    Public Function ValidarPorId() As Boolean

        Try
            Dim resultado As Boolean = False
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionAgenda
            comando.CommandText = "SELECT Id FROM Actividades WHERE Id=@id AND IdArea=@idArea"
            comando.Parameters.AddWithValue("@id", Me.EId)
            comando.Parameters.AddWithValue("@idArea", Me.EIdArea)
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
            BaseDatos.conexionAgenda.Close()
        End Try

    End Function

    Public Function ValidarResueltaPorId() As Boolean

        Try
            Dim resultado As Boolean = False
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionAgenda
            comando.CommandText = "SELECT EstaResuelto FROM Actividades WHERE Id=@id AND IdArea=@idArea"
            comando.Parameters.AddWithValue("@id", Me.EId)
            comando.Parameters.AddWithValue("@idArea", Me.EIdArea)
            BaseDatos.conexionAgenda.Open()
            Dim dataReader As SqlDataReader
            dataReader = comando.ExecuteReader()
            While dataReader.Read()
                resultado = IIf(Not IsDBNull(dataReader("EstaResuelto")), dataReader("EstaResuelto"), False)
            End While
            BaseDatos.conexionAgenda.Close()
            Return resultado
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionAgenda.Close()
        End Try

    End Function

    Public Function ObtenerMaximo() As Integer

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionAgenda
            comando.CommandText = "SELECT MAX(Id) AS Id FROM Actividades WHERE IdArea=@idArea"
            comando.Parameters.AddWithValue("@idArea", Me.EIdArea)
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
