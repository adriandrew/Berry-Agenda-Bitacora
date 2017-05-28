Imports System.Data.SqlClient

Public Class HorariosNotificaciones

    Private idArea As Integer
    Private hora As String

    Public Property EIdArea() As Integer
        Get
            Return Me.idArea
        End Get
        Set(value As Integer)
            Me.idArea = value
        End Set
    End Property
    Public Property EHora() As String
        Get
            Return Me.hora
        End Get
        Set(value As String)
            Me.hora = value
        End Set
    End Property

    Public Sub Guardar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo
            comando.CommandText = "INSERT INTO HorariosNotificaciones VALUES (@idArea, @hora)"
            comando.Parameters.AddWithValue("@idArea", Me.EIdArea)
            comando.Parameters.AddWithValue("@hora", Me.EHora)
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
            Dim condicion As String = String.Empty
            If (Me.EIdArea > 0) Then
                condicion &= " AND IdArea = @idArea"
            End If
            comando.CommandText = "DELETE FROM HorariosNotificaciones WHERE 0=0 " & condicion
            comando.Parameters.AddWithValue("@idArea", Me.EIdArea)
            BaseDatos.conexionCatalogo.Open()
            comando.ExecuteNonQuery()
            BaseDatos.conexionCatalogo.Close()
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionCatalogo.Close()
        End Try

    End Sub

    Public Function ObtenerListadoReporte() As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo
            comando.CommandText = "SELECT HN.IdArea, A.Nombre, HN.Hora FROM HorariosNotificaciones AS HN LEFT JOIN Areas AS A ON HN.IdArea = A.Id ORDER BY HN.IdArea ASC"
            comando.Parameters.AddWithValue("@idArea", Me.idArea)
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
