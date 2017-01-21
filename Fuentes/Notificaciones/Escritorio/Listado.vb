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

#Region "Metodos Publicos"

    Public Sub GenerarListado(ByVal lista As List(Of EntidadesNotificaciones.Actividades))

        ' Se calculan los controles necesarios.
        ' Los tamaños de los controles.
        Dim alto As Integer = 200
        Dim ancho As Integer = Me.Width - 45
        ' Las posiciones donde inician los controles.
        Dim posicionY As Integer = 0
        Dim posicionX As Integer = 5
        ' Margen de espacio hacia abajo.
        Dim margen As Integer = 5
        ' Es la cantidad de controles que caben verticalmente.    
        Dim cantidad As Integer = lista.Count
        ' Se utiliza para controlar la cantidad de opciones verticales.
        For indice As Integer = 1 To cantidad
            ' Crea controles.
            ' Se crean los paneles.
            Dim etiqueta As New Label()
            'etiqueta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            etiqueta.BackColor = Color.Transparent
            etiqueta.BorderStyle = BorderStyle.FixedSingle
            etiqueta.Font = New Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Dim diferenciaDias As Integer = DateDiff(DateInterval.Day, CDate(lista(indice - 1).EFechaVencimiento), Now, FirstDayOfWeek.System, FirstWeekOfYear.Jan1)
            If diferenciaDias > 10 Then
                etiqueta.ForeColor = Color.Red
            ElseIf diferenciaDias > 5 And diferenciaDias < 10 Then
                etiqueta.ForeColor = Color.Orange
            Else
                etiqueta.ForeColor = Color.Yellow
            End If
            etiqueta.Top = posicionY
            etiqueta.Left = posicionX
            etiqueta.Name = "lbl_" & indice
            etiqueta.Size = New Size(ancho, alto)
            etiqueta.TabIndex = indice - 1
            etiqueta.Text = "    " & lista(indice - 1).EFechaVencimiento & "    " & lista(indice - 1).ENombre.ToString() & vbNewLine & lista(indice - 1).EDescripcion.ToString()
            etiqueta.AutoSize = False
            etiqueta.Image = Global.Notificaciones.My.Resources.Resources.Logo3
            etiqueta.ImageAlign = ContentAlignment.TopLeft
            ' Se genera el evento desde codigo.
            'etiqueta.Click += New System.EventHandler(etiqueta_Click)
            ' Se genera el evento desde codigo.
            'etiqueta.MouseHover += New System.EventHandler(etiqueta_MouseHover)
            ' Se genera el evento desde codigo.
            'etiqueta.MouseLeave += New System.EventHandler(etiqueta_MouseLeave)
            Me.Controls.Add(etiqueta)
            Application.DoEvents()
            System.Threading.Thread.Sleep(50)
            ' Se distribuyen hacia abajo. 
            posicionY += alto + margen
        Next

    End Sub

#End Region
     
End Class