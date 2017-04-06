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
            idEmpresa = Funciones.ValidarNumero(parametros(numeracion).Replace("|", " ")) : numeracion += 1
            activa = Funciones.ValidarNumero(parametros(numeracion).Replace("|", " ")) : numeracion += 1
            instanciaSql = Funciones.ValidarLetra(parametros(numeracion).Replace("|", " ")) : numeracion += 1
            rutaBd = Funciones.ValidarLetra(parametros(numeracion).Replace("|", " ")) : numeracion += 1
            usuarioSql = Funciones.ValidarLetra(parametros(numeracion).Replace("|", " ")) : numeracion += 1
            contrasenaSql = Funciones.ValidarLetra(parametros(numeracion).Replace("|", " ")) : numeracion += 1
        End If

    End Sub

End Class
