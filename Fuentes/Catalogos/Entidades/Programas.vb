Imports System.Data.SqlClient
 
    Public Class Programas

    Private idEmpresa As Integer
    Private idModulo As Integer
    Private id As Integer
    Private nombre As String

    Public Property EIdEmpresa() As Integer
        Get
            Return idEmpresa
        End Get
        Set(value As Integer)
            idEmpresa = value
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
    Public Property EId() As Integer
        Get
            Return id
        End Get
        Set(value As Integer)
            id = value
        End Set
    End Property
    Public Property ENombre() As String
        Get
            Return nombre
        End Get
        Set(value As String)
            nombre = value
        End Set
    End Property

    Public Function ObtenerListadoDeProgramas() As List(Of Programas)

        Dim lista As New List(Of Programas)()
        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionInformacion
            comando.CommandText = "SELECT * FROM Programas WHERE IdEmpresa=@idEmpresa"
            comando.Parameters.AddWithValue("@idEmpresa", Me.EIdEmpresa)
            BaseDatos.conexionInformacion.Open()
            Dim dataReader As SqlDataReader = comando.ExecuteReader()
            Dim programas As Programas
            While dataReader.Read()
                programas = New Programas()
                programas.EIdEmpresa = Convert.ToInt32(dataReader("IdEmpresa").ToString())
                programas.EIdModulo = Convert.ToInt32(dataReader("IdModulo").ToString())
                programas.EId = Convert.ToInt32(dataReader("Id").ToString())
                programas.ENombre = dataReader("Nombre").ToString()
                lista.Add(programas)
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