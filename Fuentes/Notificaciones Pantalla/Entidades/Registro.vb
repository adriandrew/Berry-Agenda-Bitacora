Imports System.Data.SqlClient

Public Class Registros

    Private idEmpresa As Integer
    Private idArea As Integer
    Private idUsuario As Integer
    Private idModulo As Integer
    Private nombreEquipo As String
    Private esSesionIniciada As Boolean

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
    Public Property EEsSesionIniciada() As Boolean
        Get
            Return esSesionIniciada
        End Get
        Set(value As Boolean)
            esSesionIniciada = value
        End Set
    End Property
      
    Public Function ObtenerPorIdEmpresayNombreEquipo() As List(Of Registros)

        Dim lista As New List(Of Registros)
        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionInformacion
            comando.CommandText = "SELECT * FROM Registros WHERE IdEmpresa=@idEmpresa AND NombreEquipo=@nombreEquipo"
            comando.Parameters.AddWithValue("@idEmpresa", Me.EIdEmpresa)
            comando.Parameters.AddWithValue("@nombreEquipo", Me.ENombreEquipo)
            BaseDatos.conexionInformacion.Open()
            Dim dataReader As SqlDataReader
            dataReader = comando.ExecuteReader()
            Dim registro As New Registros
            While (dataReader.Read())
                registro = New Registros()
                registro.idEmpresa = Convert.ToInt32(dataReader("IdEmpresa").ToString())
                registro.idArea = Convert.ToInt32(dataReader("IdArea").ToString())
                registro.idUsuario = Convert.ToInt32(dataReader("IdUsuario").ToString())
                registro.idModulo = Convert.ToInt32(dataReader("IdModulo").ToString())
                registro.nombreEquipo = dataReader("NombreEquipo").ToString()
                registro.esSesionIniciada = Convert.ToBoolean(dataReader("EsSesionIniciada").ToString())
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
