Public Module Funciones

    Public Function ValidarNumero(ByVal valor As String) As Integer

        If IsNumeric(valor) Then
            Return valor
        Else            
            Return 0
        End If

    End Function

End Module
