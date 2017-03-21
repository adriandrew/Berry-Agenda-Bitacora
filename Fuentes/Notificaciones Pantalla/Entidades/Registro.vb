Imports System.Data.SqlClient

Public Class Registro

    Private idEmpresa As Integer
    Private idArea As Integer
    Private idUsuario As Integer
    Private idModulo As Integer
    Private nombreEquipo As String

    Public Property EIdEmpresa() As Integer
        Get
            Return idEmpresa
        End Get
        Set(value As Integer)
            idEmpresa = value
        End Set
    End Property
    Public Property EIdArea() As Integer
        Get
            Return idArea
        End Get
        Set(value As Integer)
            idArea = value
        End Set
    End Property
    Public Property EIdUsuario() As Integer
        Get
            Return idUsuario
        End Get
        Set(value As Integer)
            idUsuario = value
        End Set
    End Property
    Public Property EIdModulo() As Integer
        Get
            Return idModulo
        End Get
        Set(value As Integer)
            idModulo = value
        End Set
    End Property
    Public Property ENombreEquipo() As String
        Get
            Return nombreEquipo
        End Get
        Set(value As String)
            nombreEquipo = value
        End Set
    End Property

    Public Sub Guardar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionInformacion
            comando.CommandText = "INSERT INTO Registro (IdEmpresa, IdArea, IdUsuario, IdModulo, NombreEquipo) VALUES (@idEmpresa, @idArea, @idUsuario, @idModulo, @nombreEquipo)"
            comando.Parameters.AddWithValue("@idEmpresa", Me.EIdEmpresa)
            comando.Parameters.AddWithValue("@idArea", Me.EIdArea)
            comando.Parameters.AddWithValue("@idUsuario", Me.EIdUsuario)
            comando.Parameters.AddWithValue("@idModulo", Me.EIdModulo)
            comando.Parameters.AddWithValue("@nombreEquipo", Me.ENombreEquipo)
            BaseDatos.conexionInformacion.Open()
            comando.ExecuteNonQuery()
            BaseDatos.conexionInformacion.Close()
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionInformacion.Close()
        End Try

    End Sub

    Public Sub Editar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionInformacion
            comando.CommandText = "UPDATE Registro SET IdUsuario=@idUsuario, IdArea=@idArea, IdModulo=@idModulo WHERE IdEmpresa=@idEmpresa AND NombreEquipo=@nombreEquipo"
            comando.Parameters.AddWithValue("@idEmpresa", Me.EIdEmpresa)
            comando.Parameters.AddWithValue("@idArea", Me.EIdArea)
            comando.Parameters.AddWithValue("@idUsuario", Me.EIdUsuario)
            comando.Parameters.AddWithValue("@idModulo", Me.EIdModulo)
            comando.Parameters.AddWithValue("@nombreEquipo", Me.ENombreEquipo)
            BaseDatos.conexionInformacion.Open()
            comando.ExecuteNonQuery()
            BaseDatos.conexionInformacion.Close()
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionInformacion.Close()
        End Try

    End Sub

    Public Sub Eliminar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionInformacion
            comando.CommandText = "DELETE FROM Registro WHERE IdEmpresa=@idEmpresa AND NombreEquipo=@nombreEquipo"
            comando.Parameters.AddWithValue("@idEmpresa", Me.EIdEmpresa)
            comando.Parameters.AddWithValue("@nombreEquipo", Me.ENombreEquipo)
            BaseDatos.conexionInformacion.Open()
            comando.ExecuteNonQuery()
            BaseDatos.conexionInformacion.Close()
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionInformacion.Close()
        End Try

    End Sub

    Public Function ValidarPorId() As Boolean

        Try
            Dim resultado As Boolean = False
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionInformacion
            comando.CommandText = "SELECT * FROM Registro WHERE IdEmpresa=@idEmpresa AND NombreEquipo=@nombreEquipo"
            comando.Parameters.AddWithValue("@idEmpresa", Me.EIdEmpresa)
            comando.Parameters.AddWithValue("@nombreEquipo", Me.ENombreEquipo)
            BaseDatos.conexionInformacion.Open()
            Dim dataReader As SqlDataReader
            dataReader = comando.ExecuteReader()
            If (dataReader.HasRows) Then
                resultado = True
            Else
                resultado = False
            End If
            BaseDatos.conexionInformacion.Close()
            Return resultado
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionInformacion.Close()
        End Try

    End Function

    Public Function ObtenerPorIdEmpresaIdUsuarioyNombreEquipo() As List(Of Registro)

        Dim lista As New List(Of Registro)
        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionInformacion
            comando.CommandText = "SELECT * FROM Registro WHERE IdEmpresa=@idEmpresa AND IdUsuario=@idUsuario AND NombreEquipo=@nombreEquipo"
            comando.Parameters.AddWithValue("@idEmpresa", Me.EIdEmpresa)
            comando.Parameters.AddWithValue("@idArea", Me.EIdArea)
            comando.Parameters.AddWithValue("@idUsuario", Me.EIdUsuario)
            comando.Parameters.AddWithValue("@nombreEquipo", Me.ENombreEquipo)
            BaseDatos.conexionInformacion.Open()
            Dim dataReader As SqlDataReader
            dataReader = comando.ExecuteReader()
            Dim registro As New Registro
            While (dataReader.Read())
                registro = New Registro()
                registro.idEmpresa = Convert.ToInt32(dataReader("IdEmpresa"))
                registro.idArea = Convert.ToInt32(dataReader("IdArea"))
                registro.idUsuario = Convert.ToInt32(dataReader("IdUsuario"))
                registro.idModulo = Convert.ToInt32(dataReader("IdModulo"))
                registro.nombreEquipo = dataReader("NombreEquipo").ToString()
                lista.Add(registro)
            End While
            BaseDatos.conexionInformacion.Close()
            Return lista
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionInformacion.Close()
        End Try

    End Function

    Public Function ObtenerPorIdEmpresayNombreEquipo() As List(Of Registro)

        Dim lista As New List(Of Registro)
        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionInformacion
            comando.CommandText = "SELECT * FROM Registro WHERE IdEmpresa=@idEmpresa AND NombreEquipo=@nombreEquipo"
            comando.Parameters.AddWithValue("@idEmpresa", Me.EIdEmpresa) 
            comando.Parameters.AddWithValue("@nombreEquipo", Me.ENombreEquipo)
            BaseDatos.conexionInformacion.Open()
            Dim dataReader As SqlDataReader
            dataReader = comando.ExecuteReader()
            Dim registro As New Registro
            While (dataReader.Read())
                registro = New Registro()
                registro.idEmpresa = Convert.ToInt32(dataReader("IdEmpresa"))
                registro.idArea = Convert.ToInt32(dataReader("IdArea"))
                registro.idUsuario = Convert.ToInt32(dataReader("IdUsuario"))
                registro.idModulo = Convert.ToInt32(dataReader("IdModulo"))
                registro.nombreEquipo = dataReader("NombreEquipo").ToString()
                lista.Add(registro)
            End While
            BaseDatos.conexionInformacion.Close()
            Return lista
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionInformacion.Close()
        End Try

    End Function

End Class
