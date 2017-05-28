Imports System.Data.SqlClient

Public Class Horarios

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

    Public Function ObtenerListadoReporte() As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo
            Dim condicion As String = String.Empty
            If (Me.EIdArea > 0) Then
                condicion &= " AND IdArea = @idArea"
            End If
            comando.CommandText = "SELECT IdArea, Hora FROM HorariosNotificaciones WHERE 0=0 " & condicion
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

    Public Function ObtenerListado() As List(Of Horarios)

        Try
            Dim lista As New List(Of Horarios)
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo
            Dim condicion As String = String.Empty
            If (Me.EIdArea > 0) Then
                condicion &= " AND IdArea = @idArea"
            End If
            comando.CommandText = "SELECT IdArea, Hora FROM HorariosNotificaciones WHERE 0=0 " & condicion
            comando.Parameters.AddWithValue("@idArea", Me.idArea)
            BaseDatos.conexionCatalogo.Open()
            Dim dataReader As SqlDataReader
            dataReader = comando.ExecuteReader()
            Dim horarios As New Horarios
            While (dataReader.Read())
                horarios = New Horarios()
                horarios.idArea = Convert.ToInt32(dataReader("IdArea"))
                horarios.hora = dataReader("Hora").ToString()
                lista.Add(horarios)
            End While
            BaseDatos.conexionCatalogo.Close()
            Return lista
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionCatalogo.Close()
        End Try

    End Function

End Class
