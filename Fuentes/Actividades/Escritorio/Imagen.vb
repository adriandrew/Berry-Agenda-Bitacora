Imports System.IO

Public Class Imagen

    Public idArea As Integer = 0
    Public idUsuario As Integer = 0
    Public idActividad As Integer = 0 
    Public imagenError As IO.FileStream
    Public nombreArchivo As String
    Public ruta As String

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
        Cargar()

    End Sub

    Private Sub btnAgregarImagen_Click(sender As Object, e As EventArgs) Handles btnAgregarImagen.Click

        Guardar()

    End Sub

    Private Sub btnEliminarImagen_Click(sender As Object, e As EventArgs) Handles btnEliminarImagen.Click

        Eliminar()

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        Me.Close()
        Principal.BringToFront()

    End Sub

    Private Sub btnAgregarImagen_MouseHover(sender As Object, e As EventArgs) Handles btnAgregarImagen.MouseHover

        AsignarTooltips("Agregar Imagen.")

    End Sub

    Private Sub btnEliminarImagen_MouseHover(sender As Object, e As EventArgs) Handles btnEliminarImagen.MouseHover

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

#Region "Metodos"

    Public Sub Guardar()
         
        Try
            If (Not Directory.Exists(Me.ruta)) Then
                Directory.CreateDirectory(Me.ruta)
            End If
        Catch ex As Exception
        End Try
        Dim pDialogResult As DialogResult
        pDialogResult = opdDialogo.ShowDialog()
        If (pDialogResult = Windows.Forms.DialogResult.OK) Then
            Try
                If (Not pbImagen.Image Is Nothing) Then
                    pbImagen.Image.Dispose()
                    pbImagen.Image = Nothing
                End If
                Dim fs As IO.FileStream = Nothing
                My.Computer.FileSystem.CopyFile(opdDialogo.FileName, Me.ruta + Me.nombreArchivo + ".jpg", True)
                Try
                    fs = New IO.FileStream(Me.ruta + Me.nombreArchivo + ".jpg", FileMode.Open, FileAccess.Read)
                    pbImagen.Image = Image.FromStream(fs)
                Catch e As Exception
                    pbImagen.Image = Image.FromStream(imagenError)
                Finally
                    If (Not fs Is Nothing) Then
                        fs.Close()
                        fs.Dispose()
                    End If
                End Try
                Principal.rutaImagen = Me.ruta + Me.nombreArchivo + ".jpg"
                Principal.tieneImagen = True
            Catch ex As Exception
                Try
                    pbImagen.Image = Image.FromStream(imagenError)
                Catch ex1 As Exception
                End Try
                Principal.rutaImagen = String.Empty
                Principal.tieneImagen = False
            End Try
            Principal.pbImagen.Image = Me.pbImagen.Image
        End If

    End Sub

    Private Sub Eliminar()

        If MessageBox.Show("Desea eliminar la imagen?", "Eliminar.", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try
                pbImagen.Image.Dispose()
                pbImagen.Image = Nothing
                My.Computer.FileSystem.DeleteFile(Me.ruta + Me.nombreArchivo + ".jpg")
                pbImagen.Image = Image.FromStream(imagenError)
                Principal.rutaImagen = String.Empty
                Principal.tieneImagen = False
            Catch ex As Exception
                Principal.tieneImagen = True
            End Try
            Principal.pbImagen.Image = Me.pbImagen.Image
        End If

    End Sub

    Public Sub Mostrar()

        Try
            If (Not Directory.Exists(Me.ruta)) Then
                Directory.CreateDirectory(Me.ruta)
            End If
        Catch e As Exception
            MsgBox("No se pudo crear carpeta de imagenes. ", MsgBoxStyle.Critical, "Error.")
        End Try
        Dim pImagen As IO.FileStream = Nothing
        Try
            pImagen = New IO.FileStream(Me.ruta + Me.nombreArchivo + ".jpg", FileMode.Open, FileAccess.Read)
            pbImagen.SizeMode = PictureBoxSizeMode.StretchImage
            pbImagen.Image = Image.FromStream(pImagen)
            Principal.rutaImagen = Me.ruta + Me.nombreArchivo + ".jpg"
            Principal.tieneImagen = True
        Catch e As Exception
            Try
                pbImagen.Image = Image.FromStream(imagenError) 'pbFotoEmpleado.ErrorImage
                pbImagen.SizeMode = PictureBoxSizeMode.StretchImage
                Principal.rutaImagen = String.Empty
                Principal.tieneImagen = False
            Catch ex As Exception
            End Try
        Finally
            If (Not pImagen Is Nothing) Then
                pImagen.Close()
                pImagen.Dispose()
            End If
        End Try
        Principal.pbImagen.Image = Me.pbImagen.Image

    End Sub

    Public Function ObtenerRutaCarpeta() As String

        Dim ruta As String
        If Principal.esPrueba Then
            ruta = "Z:\"
        Else
            ruta = CurDir() ' TODO. Descomentar
        End If
        Return ruta

    End Function

    Public Sub CargarValores()

        Me.nombreArchivo = Me.idArea.ToString.PadLeft(2, "0") + "-" + Me.idUsuario.ToString.PadLeft(3, "0").ToString + "-" + Me.idActividad.ToString.PadLeft(6, "0")
        Me.ruta = ObtenerRutaCarpeta() + "\ImagenesEvidencia\" 
        Me.imagenError = New IO.FileStream(Me.ruta + "NoFoto.jpg", FileMode.OpenOrCreate, FileAccess.Read)

    End Sub

    Private Sub Cargar()

        'If (Me.idActividad > 0) And (Me.idArea > 0) And (Me.idUsuario > 0) Then
        Mostrar()
        'End If

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
        tp.SetToolTip(Me.btnAgregarImagen, "Agregar Imagen.")
        tp.SetToolTip(Me.btnEliminarImagen, "Eliminar Imagen.")
        tp.SetToolTip(Me.btnMostrarImagen, "Mostrar Imagen.")

    End Sub

    Private Sub AsignarTooltips(ByVal texto As String)

        lblDescripcionTooltip.Text = texto

    End Sub

#End Region
      
End Class