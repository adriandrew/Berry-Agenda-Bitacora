Public Class DatosEmpresa

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
    Public Property EDescripcion() As String
        Get
            Return Me.descripcion
        End Get
        Set(value As String)
            Me.descripcion = value
        End Set
    End Property
    Public Property EDomicilio() As String
        Get
            Return Me.domicilio
        End Get
        Set(value As String)
            Me.domicilio = value
        End Set
    End Property
    Public Property ELocalidad() As String
        Get
            Return Me.localidad
        End Get
        Set(value As String)
            Me.localidad = value
        End Set
    End Property
    Public Property ERfc() As String
        Get
            Return Me.rfc
        End Get
        Set(value As String)
            Me.rfc = value
        End Set
    End Property
    Public Property EDirectorio() As String
        Get
            Return Me.directorio
        End Get
        Set(value As String)
            Me.directorio = value
        End Set
    End Property
    Public Property ELogo() As String
        Get
            Return Me.logo
        End Get
        Set(value As String)
            Me.logo = value
        End Set
    End Property
    Public Property EActiva() As Boolean
        Get
            Return Me.activa
        End Get
        Set(value As Boolean)
            Me.activa = value
        End Set
    End Property
    Public Property EEquipo() As String
        Get
            Return Me.equipo
        End Get
        Set(value As String)
            Me.equipo = value
        End Set
    End Property

    Public Sub ObtenerParametrosInformacionEmpresa()

        Dim parametros() = Environment.GetCommandLineArgs().ToArray()
        If (parametros.Length > 0) Then
            Dim numeracion As Integer = 8
            Me.id = Convert.ToInt32(parametros(numeracion).Replace("|", " ")) : numeracion += 1
            Me.nombre = parametros(numeracion).Replace("|", " ") : numeracion += 1
            Me.descripcion = parametros(numeracion).Replace("|", " ") : numeracion += 1
            Me.domicilio = parametros(numeracion).Replace("|", " ") : numeracion += 1
            Me.localidad = parametros(numeracion).Replace("|", " ") : numeracion += 1
            Me.rfc = parametros(numeracion).Replace("|", " ") : numeracion += 1
            Me.directorio = parametros(numeracion).Replace("|", " ") : numeracion += 1
            Me.logo = parametros(numeracion).Replace("|", " ") : numeracion += 1
            Me.activa = True : numeracion += 1 'Convert.ToBoolean(parametros(9).Replace("|", " "))
            Me.equipo = parametros(numeracion).Replace("|", " ") : numeracion += 1
        End If

    End Sub

End Class
