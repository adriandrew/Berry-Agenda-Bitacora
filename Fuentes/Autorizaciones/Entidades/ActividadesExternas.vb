Imports System.Data.SqlClient

Public Class ActividadesExternas

    Private id As Integer
    Private idArea As Integer
    Private nombreArea As String
    Private idUsuario As Integer
    Private nombreUsuario As String
    Private idAreaDestino As Integer
    Private nombreAreaDestino As String
    Private idUsuarioDestino As Integer
    Private nombreUsuarioDestino As String
    Private nombre As String
    Private descripcion As String
    Private fechaCreacion As Date
    Private fechaVencimiento As Date
    Private esUrgente As Boolean
    Private esExterna As Boolean
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
    Public Property ENombreArea() As String
        Get
            Return Me.nombreArea
        End Get
        Set(value As String)
            Me.nombreArea = value
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
    Public Property EIdAreaDestino() As Integer
        Get
            Return Me.idAreaDestino
        End Get
        Set(value As Integer)
            Me.idAreaDestino = value
        End Set
    End Property
    Public Property ENombreAreaDestino() As String
        Get
            Return Me.nombreAreaDestino
        End Get
        Set(value As String)
            Me.nombreAreaDestino = value
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
    Public Property ENombreUsuarioDestino() As String
        Get
            Return Me.nombreUsuarioDestino
        End Get
        Set(value As String)
            Me.nombreUsuarioDestino = value
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

    Public Function ObtenerListadoPendientesExternas() As List(Of ActividadesExternas)

        Dim lista As New List(Of ActividadesExternas)
        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionAgenda
            Dim consultaWhere As String = String.Empty 
            If Me.EIdArea > 0 Then
                consultaWhere &= " AND A.IdArea=@idArea "
            End If
            If Me.EIdUsuario > 0 Then
                consultaWhere &= " AND A.IdUsuario=@idUsuario "
            End If
            If Me.EIdAreaDestino > 0 Then
                consultaWhere &= " AND A.IdAreaDestino=@idAreaDestino "
            Else
                consultaWhere &= " AND NOT A.IdAreaDestino IS NULL AND A.IdAreaDestino > 0 "
            End If
            If Me.EIdUsuarioDestino > 0 Then
                consultaWhere &= " AND A.IdUsuarioDestino=@idUsuarioDestino "
            Else
                consultaWhere &= " AND NOT A.IdUsuarioDestino IS NULL AND A.IdUsuarioDestino > 0 "
            End If
            comando.CommandText = "SELECT A.Id, A.IdArea, Areas.Nombre AS NombreArea, A.IdUsuario, U.Nombre AS NombreUsuario, A.Nombre, A.IdAreaDestino, AreasDestino.Nombre AS NombreAreaDestino, A.IdUsuarioDestino, UD.Nombre AS NombreUsuarioDestino, A.Descripcion, A.FechaCreacion, A.FechaVencimiento, A.EsUrgente, A.EsExterna, A.EsAutorizado, A.EsRechazado, A.EstaResuelto " & _
            " FROM ((((Actividades AS A LEFT JOIN ActividadesResueltas AS AR ON A.Id = AR.IdActividad AND A.IdArea = AR.IdArea AND A.IdUsuario = AR.IdUsuario) " & _
            " LEFT JOIN [INFORMACION].dbo.Usuarios AS U ON A.IdUsuario = U.Id) " & _
            " LEFT JOIN [INFORMACION].dbo.Usuarios AS UD ON A.IdUsuarioDestino = UD.Id) " & _
            " LEFT JOIN [CATALOGOS].dbo.Areas ON A.IdArea = Areas.Id) " & _
            " LEFT JOIN [CATALOGOS].dbo.Areas AS AreasDestino ON A.IdAreaDestino = AreasDestino.Id " & _
            " WHERE AR.IdActividad IS NULL AND AR.IdArea IS NULL AND AR.IdUsuario IS NULL AND (A.EsAutorizado = 'FALSE' OR A.EsAutorizado IS NULL) AND (A.EsRechazado = 'FALSE' OR A.EsRechazado IS NULL) " & consultaWhere
            comando.Parameters.AddWithValue("@idArea", Me.EIdArea)
            comando.Parameters.AddWithValue("@idUsuario", Me.EIdUsuario)
            comando.Parameters.AddWithValue("@idAreaDestino", Me.EIdAreaDestino)
            comando.Parameters.AddWithValue("@idUsuarioDestino", Me.EIdUsuarioDestino)
            BaseDatos.conexionAgenda.Open()
            Dim dataReader As SqlDataReader
            dataReader = comando.ExecuteReader()
            Dim actividades As New ActividadesExternas
            While (dataReader.Read())
                actividades = New ActividadesExternas()
                actividades.id = Convert.ToInt32(dataReader("Id"))
                actividades.idArea = Convert.ToInt32(dataReader("IdArea")) 
                actividades.nombreArea = dataReader("NombreArea").ToString
                actividades.idUsuario = dataReader("IdUsuario").ToString
                actividades.nombreUsuario = dataReader("NombreUsuario").ToString
                actividades.idAreaDestino = Convert.ToInt32(IIf(IsNumeric(dataReader("IdAreaDestino")), dataReader("IdAreaDestino"), 0))
                actividades.nombreAreaDestino = dataReader("NombreAreaDestino").ToString
                actividades.idUsuarioDestino = Convert.ToInt32(IIf(IsNumeric(dataReader("IdUsuarioDestino")), dataReader("IdUsuarioDestino"), 0))
                actividades.nombreUsuarioDestino = dataReader("NombreUsuarioDestino").ToString
                actividades.nombre = dataReader("Nombre").ToString()
                actividades.descripcion = dataReader("Descripcion").ToString()
                actividades.fechaCreacion = dataReader("FechaCreacion").ToString()
                actividades.fechaVencimiento = dataReader("FechaVencimiento").ToString()
                actividades.esUrgente = dataReader("EsUrgente").ToString()
                actividades.esExterna = IIf(Not IsDBNull(dataReader("EsExterna")), dataReader("EsExterna"), False)
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

    Public Sub Editar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionAgenda 
            comando.CommandText = "UPDATE Actividades SET EsAutorizado=@esAutorizado, EsRechazado=@esRechazado WHERE Id=@id AND IdArea=@idArea AND IdUsuario=@idUsuario"
            comando.Parameters.AddWithValue("@id", Me.EId)
            comando.Parameters.AddWithValue("@idArea", Me.EIdArea)
            comando.Parameters.AddWithValue("@idUsuario", Me.EIdUsuario)
            comando.Parameters.AddWithValue("@esAutorizado", Me.EEsAutorizado)
            comando.Parameters.AddWithValue("@esRechazado", Me.EEsRechazado)
            BaseDatos.conexionAgenda.Open()
            comando.ExecuteNonQuery()
            BaseDatos.conexionAgenda.Close()
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionAgenda.Close()
        End Try

    End Sub

End Class
