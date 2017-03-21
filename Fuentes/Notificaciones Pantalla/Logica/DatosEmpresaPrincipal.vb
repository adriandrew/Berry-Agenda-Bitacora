Public Class DatosEmpresaPrincipal

    Public Shared idEmpresa As Integer
    Public Shared activa As Boolean
    Public Shared instanciaSql As String
    Public Shared rutaBd As String
    Public Shared usuarioSql As String
    Public Shared contrasenaSql As String

    Public Shared Sub ObtenerParametrosInformacionEmpresa()

        Dim parametros() = Environment.GetCommandLineArgs().ToArray()
        If (parametros.Length > 1) Then
            Dim numeracion As Integer = 1
            idEmpresa = Convert.ToInt32(parametros(numeracion).Replace("|", " ")) : numeracion += 1
            activa = parametros(numeracion).Replace("|", " ") : numeracion += 1
            instanciaSql = parametros(numeracion).Replace("|", " ") : numeracion += 1
            rutaBd = parametros(numeracion).Replace("|", " ") : numeracion += 1
            usuarioSql = parametros(numeracion).Replace("|", " ") : numeracion += 1
            contrasenaSql = parametros(numeracion).Replace("|", " ") : numeracion += 1
        End If

    End Sub

End Class
