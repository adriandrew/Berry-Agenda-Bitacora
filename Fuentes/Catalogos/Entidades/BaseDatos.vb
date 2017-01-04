﻿Imports System.Data.SqlClient

Public Module BaseDatos

    Private cadenaConexionInformacion As String
    Private cadenaConexionCatalogo As String
    Public conexionInformacion As New SqlConnection()
    Public conexionCatalogo As New SqlConnection()

    Public Property ECadenaConexionInformacion() As String
        Get
            Return BaseDatos.cadenaConexionInformacion
        End Get
        Set(value As String)
            BaseDatos.cadenaConexionInformacion = value
        End Set
    End Property
    Public Property ECadenaConexionCatalogo() As String
        Get
            Return BaseDatos.cadenaConexionCatalogo
        End Get
        Set(value As String)
            BaseDatos.cadenaConexionCatalogo = value
        End Set
    End Property

    Public Sub AbrirConexionInformacion()

        BaseDatos.ECadenaConexionInformacion = String.Format("Data Source=.\\SQLEXPRESS;Initial Catalog={0};Integrated Security=True;Connect Timeout=30", BaseDatos.ECadenaConexionInformacion)
        conexionInformacion.ConnectionString = BaseDatos.ECadenaConexionInformacion

    End Sub


    Public Sub AbrirConexionCatalogo()

        BaseDatos.ECadenaConexionCatalogo = String.Format("Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog={0};Integrated Security=True;Connect Timeout=30", BaseDatos.ECadenaConexionCatalogo)
        'BaseDatos.ECadenaConexionCatalogo = "Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=CATALOGOS;Integrated Security=True"
        conexionCatalogo.ConnectionString = BaseDatos.ECadenaConexionCatalogo

    End Sub

End Module