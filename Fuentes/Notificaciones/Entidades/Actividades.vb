Imports System.Data.SqlClient

Public Class Actividades

    Private id As Integer
    Private idUsuario As Integer
    Private idArea As Integer
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
    Public Property EIdArea() As Integer
        Get
            Return Me.idArea
        End Get
        Set(value As Integer)
            Me.idArea = value
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

    Public Function ObtenerListadoSinResolucion() As List(Of Actividades)

        Dim lista As New List(Of Actividades)
        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionAgenda
            comando.CommandText = "SELECT A.* FROM Actividades AS A LEFT JOIN ActividadesResueltas AS AR ON A.Id = AR.IdActividad AND A.IdArea = AR.IdArea WHERE A.IdArea=@idArea AND AR.IdActividad IS NULL AND AR.IdArea IS NULL AND CONVERT(CHAR(10), FechaVencimiento, 121) < CONVERT(CHAR(10), GETDATE(), 121) ORDER BY FechaVencimiento ASC"
            comando.Parameters.AddWithValue("@idArea", Me.EIdArea)
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
                lista.Add(actividades)
            End While
            BaseDatos.conexionAgenda.Close()
            Return lista
        Catch ex As Exception
            Throw ex
        End Try

    End Function

End Class
