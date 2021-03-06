﻿Public Class DatosEmpresa

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
            Me.EId = Convert.ToInt32(parametros(1).Replace("|", " "))
            Me.ENombre = parametros(2).Replace("|", " ")
            Me.EDescripcion = parametros(3).Replace("|", " ")
            Me.EDomicilio = parametros(4).Replace("|", " ")
            Me.ELocalidad = parametros(5).Replace("|", " ")
            Me.ERfc = parametros(6).Replace("|", " ")
            Me.EDirectorio = parametros(7).Replace("|", " ")
            Me.ELogo = parametros(8).Replace("|", " ")
            Me.EActiva = True 'Convert.ToBoolean(parametros(9).Replace("|", " "))
            Me.EEquipo = parametros(10).Replace("|", " ") 
        End If

    End Sub

End Class
