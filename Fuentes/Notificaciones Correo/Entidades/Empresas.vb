Imports System.Data.SqlClient

Public Class Empresas

    Private id As Integer
    Private nombre As String
    Private descripcion As String
    Private domicilio As String
    Private localidad As String
    Private rfc As String
    Private directorio As String
    Private logo As String
    Private activa As Boolean
    Private equipo As String

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
    Public Property EDescripcion() As String
        Get
            Return descripcion
        End Get
        Set(value As String)
            descripcion = value
        End Set
    End Property
    Public Property EDomicilio() As String
        Get
            Return domicilio
        End Get
        Set(value As String)
            domicilio = value
        End Set
    End Property
    Public Property ELocalidad() As String
        Get
            Return localidad
        End Get
        Set(value As String)
            localidad = value
        End Set
    End Property
    Public Property ERfc() As String
        Get
            Return rfc
        End Get
        Set(value As String)
            rfc = value
        End Set
    End Property
    Public Property EDirectorio() As String
        Get
            Return directorio
        End Get
        Set(value As String)
            directorio = value
        End Set
    End Property
    Public Property ELogo() As String
        Get
            Return logo
        End Get
        Set(value As String)
            logo = value
        End Set
    End Property
    Public Property EActiva() As Boolean
        Get
            Return activa
        End Get
        Set(value As Boolean)
            activa = value
        End Set
    End Property
    Public Property EEquipo() As String
        Get
            Return equipo
        End Get
        Set(value As String)
            equipo = value
        End Set
    End Property

    Public Function ObtenerPredeterminada() As String

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionInformacion
            comando.CommandText = "SELECT * FROM Empresas WHERE Activa='TRUE'"
            BaseDatos.conexionInformacion.Open()
            Dim dataReader As SqlDataReader = comando.ExecuteReader()
            While dataReader.Read()
                Me.id = Convert.ToInt32(dataReader("id").ToString())
                Me.nombre = dataReader("nombre").ToString()
                Me.descripcion = dataReader("descripcion").ToString()
                Me.domicilio = dataReader("domicilio").ToString()
                Me.localidad = dataReader("localidad").ToString()
                Me.rfc = dataReader("rfc").ToString()
                Me.directorio = dataReader("directorio").ToString()
                Me.logo = dataReader("logo").ToString()
                Me.activa = Convert.ToBoolean(dataReader("activa").ToString())
                Me.equipo = dataReader("equipo").ToString()
            End While
            BaseDatos.conexionInformacion.Close()
            Return Me.id & "|" & Me.nombre & "|" & Me.descripcion & "|" & Me.domicilio & "|" & Me.localidad & "|" & Me.rfc & "|" & Me.directorio & "|" & Me.logo & "|" & Me.activa & "|" & Me.equipo
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionInformacion.Close()
        End Try

    End Function

    Public Function ObtenerPorId() As List(Of Empresas)

        Dim lista As New List(Of Empresas)()
        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionInformacion
            comando.CommandText = "SELECT * FROM Empresas WHERE Id = @id"
            comando.Parameters.AddWithValue("@id", Me.EId)
            BaseDatos.conexionInformacion.Open()
            Dim dataReader As SqlDataReader = comando.ExecuteReader()
            Dim empresas As Empresas
            While dataReader.Read()
                empresas = New Empresas()
                empresas.id = Convert.ToInt32(dataReader("id").ToString())
                empresas.nombre = dataReader("nombre").ToString()
                empresas.descripcion = dataReader("descripcion").ToString()
                empresas.domicilio = dataReader("domicilio").ToString()
                empresas.localidad = dataReader("localidad").ToString()
                empresas.rfc = dataReader("rfc").ToString()
                empresas.directorio = dataReader("directorio").ToString()
                empresas.logo = dataReader("logo").ToString()
                empresas.activa = Convert.ToBoolean(dataReader("activa").ToString())
                empresas.equipo = dataReader("equipo").ToString()
                lista.Add(empresas)
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
