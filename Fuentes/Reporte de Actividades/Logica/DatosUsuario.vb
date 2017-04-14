Public Class DatosUsuario

    Private idEmpresa As Integer
    Private id As Integer
    Private nombre As String
    Private contrasena As String
    Private nivel As Integer
    Private accesoTotal As Boolean
    Private idArea As Integer

    Public Property EIdEmpresa As Integer
        Get
            Return Me.idEmpresa
        End Get
        Set(value As Integer)
            Me.idEmpresa = value
        End Set
    End Property 
    Public Property EId() As Integer
        Get
            Return Id
        End Get
        Set(value As Integer)
            id = value
        End Set
    End Property
    Public Property ENombre() As String
        Get
            Return Nombre
        End Get
        Set(value As String)
            nombre = value
        End Set
    End Property
    Public Property EContrasena() As String
        Get
            Return Contrasena
        End Get
        Set(value As String)
            contrasena = value
        End Set
    End Property
    Public Property ENivel() As Integer
        Get
            Return Nivel
        End Get
        Set(value As Integer)
            nivel = value
        End Set
    End Property
    Public Property EAccesoTotal() As Boolean
        Get
            Return AccesoTotal
        End Get
        Set(value As Boolean)
            accesoTotal = value
        End Set
    End Property
    Public Property EIdArea() As Integer
        Get
            Return IdArea
        End Get
        Set(value As Integer)
            idArea = value
        End Set
    End Property

    Public Sub ObtenerParametrosInformacionUsuario()

        Dim parametros() = Environment.GetCommandLineArgs().ToArray()
        If (parametros.Length > 0) Then
            Dim numeracion As Integer = 19
            Me.EId = Convert.ToInt32(parametros(numeracion).Replace("|", " ")) : numeracion += 1
            Me.ENombre = parametros(numeracion).Replace("|", " ") : numeracion += 1
            Me.EContrasena = parametros(numeracion).Replace("|", " ") : numeracion += 1
            Me.ENivel = Convert.ToInt32(parametros(numeracion).Replace("|", " ")) : numeracion += 1
            Me.EAccesoTotal = Convert.ToBoolean(parametros(numeracion).Replace("|", " ")) : numeracion += 1
            Me.EIdArea = Convert.ToInt32(parametros(numeracion).Replace("|", " ")) : numeracion += 1
        End If

    End Sub

End Class
