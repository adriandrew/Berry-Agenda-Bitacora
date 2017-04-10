Imports System.Data.SqlClient

Public Class ProveedoresCorreo

    Private id As Integer
    Private nombre As String
    Private servidor As String
    Private dominio As String
    Private puerto As String

    Public Property EId() As Integer
        Get
            Return Me.id
        End Get
        Set(value As Integer)
            Me.id = value
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
    Public Property EServidor() As String
        Get
            Return Me.servidor
        End Get
        Set(value As String)
            Me.servidor = value
        End Set
    End Property
    Public Property EDominio() As String
        Get
            Return Me.dominio
        End Get
        Set(value As String)
            Me.dominio = value
        End Set
    End Property
    Public Property EPuerto() As String
        Get
            Return Me.puerto
        End Get
        Set(value As String)
            Me.puerto = value
        End Set
    End Property

    Public Function ObtenerListado() As List(Of ProveedoresCorreo)

        Dim lista As New List(Of ProveedoresCorreo)
        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionAgenda
            comando.CommandText = "SELECT * FROM ProveedoresCorreo"
            BaseDatos.conexionAgenda.Open()
            Dim dataReader As SqlDataReader
            dataReader = comando.ExecuteReader()
            Dim proveedoresCorreo As New ProveedoresCorreo
            While (dataReader.Read())
                proveedoresCorreo = New ProveedoresCorreo()
                proveedoresCorreo.id = Convert.ToInt32(dataReader("Id").ToString())
                proveedoresCorreo.nombre = dataReader("Nombre").ToString()
                proveedoresCorreo.servidor = dataReader("Servidor").ToString()
                proveedoresCorreo.dominio = dataReader("Dominio").ToString()
                proveedoresCorreo.puerto = dataReader("Puerto").ToString()
                lista.Add(proveedoresCorreo)
            End While
            BaseDatos.conexionAgenda.Close()
            Return lista
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionAgenda.Close()
        End Try

    End Function

End Class
