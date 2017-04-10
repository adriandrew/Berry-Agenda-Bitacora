Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Text

Public Class ConfiguracionProveedoresCorreo

    Private direccion As String
    Private contrasena As String
    Private asunto As String
    Private mensaje As String
    Private idProveedor As Integer 
    Private id As Integer
    Private nombre As String
    Private servidor As String
    Private dominio As String
    Private puerto As String

    Public Property EDireccion() As String
        Get
            Return direccion
        End Get
        Set(value As String)
            direccion = value
        End Set
    End Property
    Public Property EContrasena() As String
        Get
            Return contrasena
        End Get
        Set(value As String)
            contrasena = value
        End Set
    End Property
    Public Property EAsunto() As String
        Get
            Return asunto
        End Get
        Set(value As String)
            asunto = value
        End Set
    End Property
    Public Property EMensaje() As String
        Get
            Return mensaje
        End Get
        Set(value As String)
            mensaje = value
        End Set
    End Property
    Public Property EIdProveedor() As Integer
        Get
            Return idProveedor
        End Get
        Set(value As Integer)
            idProveedor = value
        End Set
    End Property 
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

    Public Function ObtenerListado() As List(Of ConfiguracionProveedoresCorreo)

        Dim lista As New List(Of ConfiguracionProveedoresCorreo)()
        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionAgenda
            comando.CommandText = "SELECT CC.*, PC.* FROM ConfiguracionCorreo AS CC LEFT JOIN ProveedoresCorreo AS PC ON CC.IdProveedor = PC.Id"
            BaseDatos.conexionAgenda.Open()
            Dim dataReader As SqlDataReader = comando.ExecuteReader()
            Dim configuracionCorreo As ConfiguracionProveedoresCorreo
            While dataReader.Read()
                configuracionCorreo = New ConfiguracionProveedoresCorreo()
                configuracionCorreo.direccion = dataReader("Direccion").ToString()
                configuracionCorreo.contrasena = dataReader("Contrasena").ToString()
                configuracionCorreo.asunto = dataReader("Asunto").ToString()
                configuracionCorreo.mensaje = dataReader("Mensaje").ToString()
                configuracionCorreo.idProveedor = Convert.ToInt32(dataReader("IdProveedor").ToString())
                configuracionCorreo.id = Convert.ToInt32(dataReader("Id").ToString())
                configuracionCorreo.nombre = dataReader("Nombre").ToString()
                configuracionCorreo.servidor = dataReader("Servidor").ToString()
                configuracionCorreo.dominio = dataReader("Dominio").ToString()
                configuracionCorreo.puerto = dataReader("Puerto").ToString()
                lista.Add(configuracionCorreo)
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
