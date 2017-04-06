Public Class DatosArea

    Private id As Integer
    Private nombre As String
    Private clave As String

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
    Public Property EClave() As String
        Get
            Return Me.clave
        End Get
        Set(value As String)
            Me.clave = value
        End Set
    End Property

    Public Sub ObtenerParametrosInformacionArea()

        Dim parametros() = Environment.GetCommandLineArgs().ToArray()
        If (parametros.Length > 1) Then
            Dim numeracion As Integer = 26
            Me.EId = Convert.ToInt32(parametros(numeracion).Replace("|", " ")) : numeracion += 1
            Me.ENombre = parametros(numeracion).Replace("|", " ") : numeracion += 1
            Me.EClave = parametros(numeracion).Replace("|", " ") : numeracion += 1
        End If

    End Sub

End Class
