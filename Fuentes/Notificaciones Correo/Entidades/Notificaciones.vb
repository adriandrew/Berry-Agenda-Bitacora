Imports System.Data.SqlClient

Public Class Notificaciones

    Private id As Integer
    Private idArea As Integer
    Private idUsuario As Integer
    Private esVisto As Boolean
    Private fecha As Date

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
    Public Property EEsVisto() As Boolean
        Get
            Return Me.esVisto
        End Get
        Set(value As Boolean)
            Me.esVisto = value
        End Set
    End Property
    Public Property EFecha() As Date
        Get
            Return Me.fecha
        End Get
        Set(value As Date)
            Me.fecha = value
        End Set
    End Property

    Public Sub Guardar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionAgenda
            comando.CommandText = "INSERT INTO Notificaciones VALUES (@idArea, @idUsuario, @esVisto, @fecha)"
            'comando.Parameters.AddWithValue("@id", Me.EId)
            comando.Parameters.AddWithValue("@idArea", Me.EIdArea)
            comando.Parameters.AddWithValue("@idUsuario", Me.EIdUsuario)
            comando.Parameters.AddWithValue("@esVisto", Me.EEsVisto)
            comando.Parameters.AddWithValue("@fecha", Me.EFecha)
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
