﻿Imports System.Data.SqlClient

Public Class ActividadesResueltas

    Inherits Actividades

    Private descripcionResolucion As String
    Private motivoRetraso As String
    Private fechaResolucion As Date
    Private idAreaOrigen As Integer
    Private idUsuarioOrigen As Integer
    Private rutaImagen As String

    Public Property EDescripcionResolucion() As String
        Get
            Return Me.descripcionResolucion
        End Get
        Set(value As String)
            Me.descripcionResolucion = value
        End Set
    End Property
    Public Property EMotivoRetraso() As String
        Get
            Return Me.motivoRetraso
        End Get
        Set(value As String)
            Me.motivoRetraso = value
        End Set
    End Property
    Public Property EFechaResolucion() As String
        Get
            Return Me.fechaResolucion
        End Get
        Set(value As String)
            Me.fechaResolucion = value
        End Set
    End Property
    Public Property EIdAreaOrigen() As Integer
        Get
            Return Me.idAreaOrigen
        End Get
        Set(value As Integer)
            Me.idAreaOrigen = value
        End Set
    End Property
    Public Property EIdUsuarioOrigen() As Integer
        Get
            Return Me.idUsuarioOrigen
        End Get
        Set(value As Integer)
            Me.idUsuarioOrigen = value
        End Set
    End Property
    Public Property ERutaImagen() As String
        Get
            Return Me.rutaImagen
        End Get
        Set(value As String)
            Me.rutaImagen = value
        End Set
    End Property

    Public Overloads Sub Guardar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionAgenda
            comando.CommandText = "INSERT INTO ActividadesResueltas (IdActividad, IdArea, IdUsuario, Descripcion, MotivoRetraso, FechaResolucion, IdAreaOrigen, IdUsuarioOrigen, RutaImagen) VALUES (@id, @idArea, @idUsuario, @descripcion, @motivoRetraso, @fechaResolucion, @idAreaOrigen, @idUsuarioOrigen, @rutaImagen)"
            comando.Parameters.AddWithValue("@id", Me.EId)
            comando.Parameters.AddWithValue("@idArea", Me.EIdArea)
            comando.Parameters.AddWithValue("@idUsuario", Me.EIdUsuario)
            comando.Parameters.AddWithValue("@descripcion", Me.EDescripcionResolucion)
            comando.Parameters.AddWithValue("@motivoRetraso", Me.EMotivoRetraso)
            comando.Parameters.AddWithValue("@fechaResolucion", Me.EFechaResolucion)
            comando.Parameters.AddWithValue("@idAreaOrigen", Me.EIdAreaOrigen)
            comando.Parameters.AddWithValue("@idUsuarioOrigen", Me.EIdUsuarioOrigen)
            comando.Parameters.AddWithValue("@rutaImagen", Me.ERutaImagen)
            BaseDatos.conexionAgenda.Open()
            comando.ExecuteNonQuery()
            BaseDatos.conexionAgenda.Close()
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionAgenda.Close()
        End Try

    End Sub

    Public Sub GuardarEstatusResuelto()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionAgenda
            comando.CommandText = "UPDATE Actividades SET EstaResuelto=@estaResuelto WHERE Id=@id AND IdArea=@idArea AND IdUsuario=@idUsuario"
            comando.Parameters.AddWithValue("@id", Me.EId)
            comando.Parameters.AddWithValue("@idArea", Me.EIdArea)
            comando.Parameters.AddWithValue("@idUsuario", Me.EIdUsuario)
            comando.Parameters.AddWithValue("@estaResuelto", Me.EEstaResuelto)
            BaseDatos.conexionAgenda.Open()
            comando.ExecuteNonQuery()
            BaseDatos.conexionAgenda.Close()
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionAgenda.Close()
        End Try

    End Sub

    Public Overloads Sub Editar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionAgenda
            comando.CommandText = "UPDATE ActividadesResueltas SET Descripcion=@descripcionResolucion, MotivoRetraso=@motivoRetraso, FechaResolucion=@fechaResolucion, IdAreaOrigen=@idAreaOrigen, IdUsuarioOrigen=@idUsuarioOrigen, RutaImagen=@rutaImagen WHERE IdActividad=@id AND IdArea=@idArea AND IdUsuario=@idUsuario"
            comando.Parameters.AddWithValue("@id", Me.EId)
            comando.Parameters.AddWithValue("@idArea", Me.EIdArea)
            comando.Parameters.AddWithValue("@idUsuario", Me.EIdUsuario)
            comando.Parameters.AddWithValue("@descripcionResolucion", Me.EDescripcionResolucion)
            comando.Parameters.AddWithValue("@motivoRetraso", Me.EMotivoRetraso)
            comando.Parameters.AddWithValue("@fechaResolucion", Me.EFechaResolucion)
            comando.Parameters.AddWithValue("@idAreaOrigen", Me.EIdAreaOrigen)
            comando.Parameters.AddWithValue("@idUsuarioOrigen", Me.EIdUsuarioOrigen)
            comando.Parameters.AddWithValue("@rutaImagen", Me.ERutaImagen)
            BaseDatos.conexionAgenda.Open()
            comando.ExecuteNonQuery()
            BaseDatos.conexionAgenda.Close()
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionAgenda.Close()
        End Try

    End Sub

    Public Overloads Sub Eliminar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionAgenda
            comando.CommandText = "DELETE FROM ActividadesResueltas WHERE IdActividad=@id AND IdArea=@idArea AND IdUsuario=@idUsuario"
            comando.Parameters.AddWithValue("@id", Me.EId)
            comando.Parameters.AddWithValue("@idArea", Me.EIdArea)
            comando.Parameters.AddWithValue("@idUsuario", Me.EIdUsuario)
            BaseDatos.conexionAgenda.Open()
            comando.ExecuteNonQuery()
            BaseDatos.conexionAgenda.Close()
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionAgenda.Close()
        End Try

    End Sub

    Public Overloads Function ValidarPorId() As Boolean

        Try
            Dim resultado As Boolean = False
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionAgenda
            comando.CommandText = "SELECT IdActividad FROM ActividadesResueltas WHERE IdActividad=@id AND IdArea=@idArea AND IdUsuario=@idUsuario"
            comando.Parameters.AddWithValue("@id", Me.EId)
            comando.Parameters.AddWithValue("@idArea", Me.EIdArea)
            comando.Parameters.AddWithValue("@idUsuario", Me.EIdUsuario)
            BaseDatos.conexionAgenda.Open()
            Dim dataReader As SqlDataReader
            dataReader = comando.ExecuteReader()
            If (dataReader.HasRows) Then
                resultado = True
            Else
                resultado = False
            End If
            BaseDatos.conexionAgenda.Close()
            Return resultado
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionAgenda.Close()
        End Try

    End Function

End Class
