Imports System.Data.SqlClient

Public Class ActividadesFijas

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

    Public Function ObtenerListado() As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo
            '" WHERE IdArea=@idArea AND IdUsuario=@idUsuario " & _
            comando.CommandText = "SELECT IdArea, IdUsuario, Id, Nombre, Descripcion, IdRangoFijoCreacion, IdRangoFijoVencimiento, EsUrgente, EsExterna, IdAreaDestino, IdUsuarioDestino, SolicitaAutorizacion, SolicitaEvidencia " & _
            " FROM ActividadesFijas" & _
            " ORDER BY IdArea, IdUsuario, Id ASC"
            comando.Parameters.AddWithValue("@idArea", Me.EIdArea)
            comando.Parameters.AddWithValue("@idUsuario", Me.EIdUsuario)
            BaseDatos.conexionCatalogo.Open()
            Dim dataReader As SqlDataReader
            dataReader = comando.ExecuteReader()
            datos.Load(dataReader)
            BaseDatos.conexionCatalogo.Close()
            Return datos
        Catch ex As Exception
            Throw ex
        End Try

    End Function

End Class
