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
        If (parametros.Length > 0) Then
            Me.EId = Convert.ToInt32(parametros(19).Replace("|", " "))
            Me.ENombre = parametros(20).Replace("|", " ")
            Me.EClave = parametros(21).Replace("|", " ")
        End If

    End Sub

End Class
