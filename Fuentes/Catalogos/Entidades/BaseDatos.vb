Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data.SqlClient
Imports System.Configuration

Public Class BaseDatos

    Private cadenaConexionInformacion As String
    Private cadenaConexionCatalogo As String
    Public conexionInformacion As New SqlConnection()
    Public conexionCatalogo As New SqlConnection()

    Public Property ECadenaConexionInformacion() As String
        Get
            Return Me.cadenaConexionInformacion
        End Get
        Set(value As String)
            Me.cadenaConexionInformacion = value
        End Set
    End Property
    Public Property ECadenaConexionCatalogo() As String
        Get
            Return Me.cadenaConexionCatalogo
        End Get
        Set(value As String)
            Me.cadenaConexionCatalogo = value
        End Set
    End Property

    Public Sub AbrirConexionInformacion() 
         
        Me.cadenaConexionInformacion = String.Format("Data Source=.\\SQLEXPRESSInitial Catalog={0}Integrated Security=TrueConnect Timeout=30", Me.cadenaConexionInformacion)
        conexionInformacion.ConnectionString = Me.cadenaConexionInformacion

    End Sub
     

    Public Sub AbrirConexionCatalogo() 

        Me.cadenaConexionCatalogo = String.Format("Data Source=.\\SQLEXPRESSInitial Catalog={0}Integrated Security=TrueConnect Timeout=30", Me.cadenaConexionCatalogo)
        conexionCatalogo.ConnectionString = Me.cadenaConexionCatalogo

    End Sub

End Class
