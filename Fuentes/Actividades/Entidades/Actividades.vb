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
    Private solicitaAutorizacion As Boolean
    Private solicitaEvidencia As Boolean
    Private esFija As Boolean 

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
    Public Property ESolicitaAutorizacion() As Boolean
        Get
            Return Me.solicitaAutorizacion
        End Get
        Set(value As Boolean)
            Me.solicitaAutorizacion = value
        End Set
    End Property
    Public Property ESolicitaEvidencia() As Boolean
        Get
            Return Me.solicitaEvidencia
        End Get
        Set(value As Boolean)
            Me.solicitaEvidencia = value
        End Set
    End Property
    Public Property EEsFija() As Boolean
        Get
            Return Me.esFija
        End Get
        Set(value As Boolean)
            Me.esFija = value
        End Set
    End Property 

    Public Function ObtenerListadoPendientes() As List(Of Actividades)

        Try
            Dim lista As New List(Of Actividades)
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionAgenda
            comando.CommandText = "SELECT A.Id, A.IdArea, A.IdUsuario, A.Nombre, A.Descripcion, A.FechaCreacion, A.FechaVencimiento, A.EsUrgente, A.EsExterna, A.IdAreaDestino, A.IdUsuarioDestino, A.EsAutorizado, A.EsRechazado, A.EstaResuelto, A.SolicitaAutorizacion, A.SolicitaEvidencia FROM Actividades AS A LEFT JOIN ActividadesResueltas AS AR ON A.Id = AR.IdActividad AND A.IdArea = AR.IdArea AND A.IdUsuario = AR.IdUsuario " & _
            " WHERE A.IdArea=@idArea AND A.IdUsuario=@idUsuario AND AR.IdActividad IS NULL AND AR.IdArea IS NULL AND AR.IdUsuario IS NULL AND A.EsRechazado='FALSE'"
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
                actividades.solicitaAutorizacion = IIf(Not IsDBNull(dataReader("SolicitaAutorizacion")), dataReader("SolicitaAutorizacion"), False)
                actividades.solicitaEvidencia = IIf(Not IsDBNull(dataReader("SolicitaEvidencia")), dataReader("SolicitaEvidencia"), False) 
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

        Try
            Dim lista As New List(Of Actividades)
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionAgenda
            comando.CommandText = "SELECT Id, IdArea, IdUsuario, Nombre, Descripcion, FechaCreacion, FechaVencimiento, EsUrgente, EsExterna, IdAreaDestino, IdUsuarioDestino, EsAutorizado, EsRechazado, EstaResuelto, SolicitaAutorizacion, SolicitaEvidencia FROM Actividades WHERE Id=@id AND IdArea=@idArea AND IdUsuario=@idUsuario"
            comando.Parameters.AddWithValue("@id", Me.EId)
            comando.Parameters.AddWithValue("@idArea", Me.EIdArea)
            comando.Parameters.AddWithValue("@idUsuario", Me.EIdUsuario)
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
                actividades.solicitaAutorizacion = IIf(Not IsDBNull(dataReader("SolicitaAutorizacion")), dataReader("SolicitaAutorizacion"), False)
                actividades.solicitaEvidencia = IIf(Not IsDBNull(dataReader("SolicitaEvidencia")), dataReader("SolicitaEvidencia"), False)
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
            comando.CommandText = "INSERT INTO Actividades (Id, IdArea, IdUsuario, Nombre, Descripcion, FechaCreacion, FechaVencimiento, EsUrgente, EsExterna, IdAreaDestino, IdUsuarioDestino, EsAutorizado, EsRechazado, EstaResuelto, SolicitaAutorizacion, SolicitaEvidencia, EsFija) VALUES (@id, @idArea, @idUsuario, @nombre, @descripcion, @fechaCreacion, @fechaVencimiento, @esUrgente, @esExterna, @idAreaDestino, @idUsuarioDestino, @esAutorizado, @esRechazado, @estaResuelto, @solicitaAutorizacion, @solicitaEvidencia, @esFija)"
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
            comando.Parameters.AddWithValue("@solicitaAutorizacion", Me.ESolicitaAutorizacion)
            comando.Parameters.AddWithValue("@solicitaEvidencia", Me.ESolicitaEvidencia)
            comando.Parameters.AddWithValue("@esFija", Me.EEsFija) 
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
            comando.CommandText = "UPDATE Actividades SET Nombre=@nombre, Descripcion=@descripcion, FechaCreacion=@fechaCreacion, FechaVencimiento=@fechaVencimiento, EsUrgente=@esUrgente, EsExterna=@esExterna, IdAreaDestino=@idAreaDestino, IdUsuarioDestino=@idUsuarioDestino, EsAutorizado=@esAutorizado, EsRechazado=@esRechazado, EstaResuelto=@estaResuelto, SolicitaAutorizacion=@solicitaAutorizacion, SolicitaEvidencia=@solicitaEvidencia WHERE Id=@id AND IdArea=@idArea AND IdUsuario=@idUsuario"
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
            comando.Parameters.AddWithValue("@solicitaAutorizacion", Me.ESolicitaAutorizacion)
            comando.Parameters.AddWithValue("@solicitaEvidencia", Me.ESolicitaEvidencia)
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
            comando.CommandText = "DELETE FROM Actividades WHERE Id=@id AND IdArea=@idArea AND IdUsuario=@idUsuario"
            comando.Parameters.AddWithValue("@id", Me.EId)
            comando.Parameters.AddWithValue("@idArea", Me.EIdArea)
            comando.Parameters.AddWithValue("@idUsuario", Me.EIdUsuario)
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
            comando.CommandText = "SELECT Id FROM Actividades WHERE Id=@id AND IdArea=@idArea AND IdUsuario=@idUsuario"
            comando.Parameters.AddWithValue("@id", Me.EId)
            comando.Parameters.AddWithValue("@idArea", Me.EIdArea)
            comando.Parameters.AddWithValue("@idUsuario", Me.EIdUsuario)
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
            comando.CommandText = "SELECT EstaResuelto FROM Actividades WHERE Id=@id AND IdArea=@idArea AND IdUsuario=@idUsuario"
            comando.Parameters.AddWithValue("@id", Me.EId)
            comando.Parameters.AddWithValue("@idArea", Me.EIdArea)
            comando.Parameters.AddWithValue("@idUsuario", Me.EIdUsuario)
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
            comando.CommandText = "SELECT MAX(Id) AS Id FROM Actividades WHERE IdArea=@idArea AND IdUsuario=@idUsuario"
            comando.Parameters.AddWithValue("@idArea", Me.EIdArea)
            comando.Parameters.AddWithValue("@idUsuario", Me.EIdUsuario)
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
