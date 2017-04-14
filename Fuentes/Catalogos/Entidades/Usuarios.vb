Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Text
Imports System.ComponentModel

Public Class Usuarios

    Private idEmpresa As Integer
    Private id As Integer
    Private nombre As String
    Private contrasena As String
    Private nivel As Integer
    Private accesoTotal As Boolean
    Private idArea As Integer

    Public Property EIdEmpresa() As Integer
        Get
            Return idEmpresa
        End Get
        Set(value As Integer)
            idEmpresa = value
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
    Public Property EContrasena() As String
        Get
            Return contrasena
        End Get
        Set(value As String)
            contrasena = value
        End Set
    End Property
    Public Property ENivel() As Integer
        Get
            Return nivel
        End Get
        Set(value As Integer)
            nivel = value
        End Set
    End Property
    Public Property EAccesoTotal() As Boolean
        Get
            Return accesoTotal
        End Get
        Set(value As Boolean)
            accesoTotal = value
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

    Public Function ObtenerListadoPorId() As List(Of Usuarios)

        Dim lista As New List(Of Usuarios)()
        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionInformacion
            comando.CommandText = "SELECT * FROM Usuarios WHERE IdEmpresa=@idEmpresa AND Id=@id"
            comando.Parameters.AddWithValue("@idEmpresa", Me.idEmpresa)
            comando.Parameters.AddWithValue("@id", Me.id)
            BaseDatos.conexionInformacion.Open()
            Dim dataReader As SqlDataReader = comando.ExecuteReader()
            Dim usuarios As Usuarios
            While dataReader.Read()
                usuarios = New Usuarios()
                usuarios.idEmpresa = Convert.ToInt32(dataReader("IdEmpresa").ToString())
                usuarios.id = Convert.ToInt32(dataReader("Id").ToString())
                usuarios.nombre = dataReader("Nombre").ToString()
                usuarios.contrasena = dataReader("Contrasena").ToString()
                usuarios.nivel = Convert.ToInt32(dataReader("Nivel").ToString())
                usuarios.accesoTotal = Convert.ToBoolean(dataReader("AccesoTotal").ToString())
                usuarios.idArea = Convert.ToInt32(dataReader("IdArea").ToString())
                lista.Add(usuarios)
            End While
            BaseDatos.conexionInformacion.Close()
            Return lista
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionInformacion.Close()
        End Try

    End Function

    Public Function ObtenerListado() As DataTable

        Dim datos As New DataTable
        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionInformacion
            comando.CommandText = "SELECT Id, Nombre FROM Usuarios WHERE IdEmpresa=@idEmpresa ORDER BY Id"
            comando.Parameters.AddWithValue("@idEmpresa", Me.idEmpresa)
            BaseDatos.conexionInformacion.Open()
            Dim dataReader As SqlDataReader
            dataReader = comando.ExecuteReader()
            datos.Load(dataReader)
            BaseDatos.conexionInformacion.Close()
            Return datos
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionInformacion.Close()
        End Try

    End Function

End Class
