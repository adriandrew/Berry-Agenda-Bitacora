Imports System.IO

Public Class Imagen

    Public nombreArchivo As String

#Region "Eventos"

    Private Sub Imagen_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Me.CenterToScreen()
        Me.BringToFront()

    End Sub

    Private Sub Imagen_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged

        Me.pbImagen.Size = Me.Size
        Me.pbImagen.SizeMode = PictureBoxSizeMode.StretchImage

    End Sub

    Private Sub Imagen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Centrar()
        AsignarTooltips()
        CargarValores()
        Mostrar()

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        Salir()

    End Sub

    Private Sub btnAgregarImagen_MouseHover(sender As Object, e As EventArgs)

        AsignarTooltips("Agregar Imagen.")

    End Sub

    Private Sub btnEliminarImagen_MouseHover(sender As Object, e As EventArgs)

        AsignarTooltips("Eliminar Imagen.")

    End Sub

    Private Sub btnSalir_MouseHover(sender As Object, e As EventArgs) Handles btnSalir.MouseHover

        AsignarTooltips("Salir.")

    End Sub

    Private Sub Imagen_MouseHover(sender As Object, e As EventArgs) Handles MyBase.MouseHover

        AsignarTooltips(String.Empty)

    End Sub

    Private Sub pnlCuerpo_MouseHover(sender As Object, e As EventArgs) Handles pnlCuerpo.MouseHover

        AsignarTooltips(String.Empty)

    End Sub

    Private Sub pnlPie_MouseHover(sender As Object, e As EventArgs) Handles pnlPie.MouseHover

        AsignarTooltips(String.Empty)

    End Sub

    Private Sub pbImagen_MouseHover(sender As Object, e As EventArgs) Handles pbImagen.MouseHover

        AsignarTooltips(String.Empty)

    End Sub

#End Region

#Region "Métodos"

    Private Sub Salir()

        Me.Close()
        Principal.BringToFront()

    End Sub

    Public Sub Mostrar()

        Dim pImagen As IO.FileStream = Nothing
        Try
            pImagen = New IO.FileStream(Me.nombreArchivo, FileMode.Open, FileAccess.Read)
            pbImagen.SizeMode = PictureBoxSizeMode.StretchImage
            pbImagen.Image = Image.FromStream(pImagen)
        Catch e As Exception
            Try
                pbImagen.Image = Nothing
                pbImagen.SizeMode = PictureBoxSizeMode.StretchImage
            Catch ex As Exception
                Me.pbImagen.Image = Nothing
            End Try
        Finally
            If (Not pImagen Is Nothing) Then
                pImagen.Close()
                pImagen.Dispose()
            End If
        End Try

    End Sub

    Public Function ObtenerRutaCarpeta() As String

        Dim ruta As String = String.Empty
        If (Principal.esDesarrollo) Then
            ruta = "X:\"
        Else
            ruta = CurDir()
        End If
        Return ruta

    End Function

    Public Sub CargarValores()

        Dim desglose As String() = Me.nombreArchivo.Split(":")
        If (desglose.Count = 1) Then ' Si no trae unidad se le agrega.
            Me.nombreArchivo = ObtenerRutaCarpeta() & desglose(0)
        ElseIf (desglose.Count > 1) Then ' Si trae la unidad incluida se reemplaza.
            Me.nombreArchivo = ObtenerRutaCarpeta() & desglose(1)
        End If

    End Sub

    Private Sub Centrar()

        Me.CenterToScreen()
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
        pnlCuerpo.Height = Me.Height - pnlPie.Height - 50
        pbImagen.Size = pnlCuerpo.Size

    End Sub

    Private Sub AsignarTooltips()

        Dim tp As New ToolTip()
        tp.AutoPopDelay = 5000
        tp.InitialDelay = 0
        tp.ReshowDelay = 100
        tp.ShowAlways = True
        tp.SetToolTip(Me.btnSalir, "Salir.")

    End Sub

    Private Sub AsignarTooltips(ByVal texto As String)

        lblDescripcionTooltip.Text = texto

    End Sub

#End Region

End Class