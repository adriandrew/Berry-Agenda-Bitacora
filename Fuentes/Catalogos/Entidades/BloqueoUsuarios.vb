Imports System.Data.SqlClient

    Public Class BloqueoUsuarios

    Private idEmpresa As Integer
    Private idUsuario As Integer
    Private idModulo As Integer
    Private idPrograma As Integer
    Private idSubPrograma As Integer

    Public Property EIdEmpresa() As Integer
        Get
            Return idEmpresa
        End Get
        Set(value As Integer)
            idEmpresa = value
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
    Public Property EIdPrograma() As Integer
        Get
            Return idPrograma
        End Get
        Set(value As Integer)
            idPrograma = value
        End Set
    End Property
    Public Property EIdSubPrograma() As Integer
        Get
            Return idSubPrograma
        End Get
        Set(value As Integer)
            idSubPrograma = value
        End Set
    End Property

    Public Sub Guardar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionInformacion
            comando.CommandText = "INSERT INTO BloqueoUsuarios (IdEmpresa, IdUsuario, IdModulo, IdPrograma, IdSubPrograma) VALUES (@idEmpresa, @idUsuario, @idModulo, @idPrograma, @idSubPrograma)"
            comando.Parameters.AddWithValue("@idEmpresa", Me.EIdEmpresa)
            comando.Parameters.AddWithValue("@idUsuario", Me.EIdUsuario)
            comando.Parameters.AddWithValue("@idModulo", Me.EIdModulo)
            comando.Parameters.AddWithValue("@idPrograma", Me.EIdPrograma)
            comando.Parameters.AddWithValue("@idSubPrograma", Me.EIdSubPrograma)
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
            Dim condiciones As String = String.Empty
            If Me.EIdModulo > 0 Then
                condiciones += " AND IdModulo=@idModulo "
            End If
            If Me.EIdPrograma > 0 Then
                condiciones += " AND IdPrograma=@idPrograma "
            End If
            If Me.EIdSubPrograma > 0 Then
                condiciones += " AND IdSubPrograma=@idSubPrograma "
            End If
            comando.CommandText = Convert.ToString("DELETE FROM BloqueoUsuarios WHERE IdEmpresa=@idEmpresa AND IdUsuario=@idUsuario ") & condiciones
            comando.Parameters.AddWithValue("@idEmpresa", Me.EIdEmpresa)
            comando.Parameters.AddWithValue("@idUsuario", Me.EIdUsuario)
            comando.Parameters.AddWithValue("@idModulo", Me.EIdModulo)
            comando.Parameters.AddWithValue("@idPrograma", Me.EIdPrograma)
            comando.Parameters.AddWithValue("@idSubPrograma", Me.EIdSubPrograma)
            BaseDatos.conexionInformacion.Open()
            comando.ExecuteNonQuery()
            BaseDatos.conexionInformacion.Close()
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionInformacion.Close()
        End Try

    End Sub

    Public Function Obtener() As Boolean

        Try
            Dim resultado As Boolean = False
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionInformacion
            comando.CommandText = "SELECT * FROM BloqueoUsuarios WHERE IdEmpresa=@idEmpresa AND IdUsuario=@idUsuario AND IdModulo=@idModulo AND IdPrograma=@idPrograma"
            comando.Parameters.AddWithValue("@idEmpresa", Me.EIdEmpresa)
            comando.Parameters.AddWithValue("@idUsuario", Me.EIdUsuario)
            comando.Parameters.AddWithValue("@idModulo", Me.EIdModulo)
            comando.Parameters.AddWithValue("@idPrograma", Me.EIdPrograma)
            BaseDatos.conexionInformacion.Open()
            Dim dataReader As SqlDataReader = comando.ExecuteReader()
            If dataReader.HasRows Then
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

    Public Function ValidarPorNumero() As Boolean

        Try
            Dim resultado As Boolean = False
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionInformacion
            comando.CommandText = "SELECT * FROM BloqueoUsuarios WHERE IdEmpresa=@idEmpresa AND IdUsuario=@idUsuario AND IdModulo=@idModulo AND IdPrograma=@idPrograma"
            comando.Parameters.AddWithValue("@idEmpresa", Me.EIdEmpresa)
            comando.Parameters.AddWithValue("@idUsuario", Me.EIdUsuario)
            comando.Parameters.AddWithValue("@idModulo", Me.EIdModulo)
            comando.Parameters.AddWithValue("@idPrograma", Me.EIdPrograma)
            BaseDatos.conexionInformacion.Open()
            Dim dataReader As SqlDataReader = comando.ExecuteReader()
            If dataReader.HasRows Then
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

    End Class 