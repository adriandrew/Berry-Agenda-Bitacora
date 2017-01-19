Public Class Listado

    Private Sub Listado_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Centrar()

    End Sub

#Region "Metodos Privados"

#Region "Genericos"

    Private Sub Centrar()

        Me.CenterToScreen()
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size 
        Me.BringToFront()
        Me.Focus()

    End Sub

    Private Sub CiclarInfinitamente()

        Dim hora As Integer = 0
        Dim minutos As Integer = 0
        While Me.Visible
            hora = Date.Now.Hour
            minutos = Date.Now.Minute
            'If (minutos >= 1 And minutos <= 15) Then 'Oficina 
            System.Threading.Thread.Sleep(60000)
            'System.Threading.Thread.Sleep(900000) ' 15 minutos.
            'Else
            'System.Threading.Thread.Sleep(300000) ' 5 minutos.
            'End If
        End While

    End Sub

#End Region

#End Region
     
End Class