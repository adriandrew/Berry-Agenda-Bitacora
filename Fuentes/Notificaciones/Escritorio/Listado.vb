Public Class Listado

    Public fueVisto As Boolean = False

#Region "Eventos"

    Private Sub Listado_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If Not fueVisto Then
            Principal.GuardarVisto(False)
        End If

    End Sub

    Private Sub Listado_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Centrar()

    End Sub

#End Region

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

    Public Sub AcomodarPaneles()

        Me.pnlInternas.Location = New Point(0, 0)
        Me.pnlInternas.Width = Me.Width / 2 - 20
        Me.pnlExternas.Location = New Point(Me.pnlInternas.Width + 5, 0)
        Me.pnlExternas.Width = Me.Width / 2 - 20

    End Sub

    Public Sub GenerarListado(ByVal lista As Object, ByVal tipo As Integer)

        Me.Cursor = Cursors.WaitCursor
        ' Se calculan los controles necesarios.
        ' Los tamaños de los controles.
        Dim alto As Integer = 200
        Dim ancho As Integer = Me.splitContenedor.Panel1.Width - 25 '- 45
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
            etiqueta.Name = "lbl_" & tipo & indice
            etiqueta.Size = New Size(ancho, alto)
            etiqueta.TabIndex = indice - 1

            Dim datosExtra As String = String.Empty
            If tipo = TipoActividad.externas Then
                datosExtra = "    Solicita " & lista(indice - 1).ENombreUsuario
            End If

            etiqueta.Text = "    " & lista(indice - 1).EFechaVencimiento & datosExtra & "    " & lista(indice - 1).ENombre.ToString() & vbNewLine & lista(indice - 1).EDescripcion.ToString()
            etiqueta.AutoSize = False
            etiqueta.Image = Global.Notificaciones.My.Resources.Resources.Logo3
            etiqueta.ImageAlign = ContentAlignment.TopLeft
            ' Se generan los eventos desde codigo.
            'etiqueta.Click += New System.EventHandler(etiqueta_Click)
            'RaiseEvent etiqueta.MouseHover += New System.EventHandler(etiquetaInterna_MouseHover)
            'etiqueta.MouseLeave += New System.EventHandler(etiquetaInterna_MouseLeave)
            If tipo = TipoActividad.internas Then
                Me.splitContenedor.Panel1.Controls.Add(etiqueta)
            ElseIf tipo = TipoActividad.externas Then
                Me.splitContenedor.Panel2.Controls.Add(etiqueta)
            End If
            'etiqueta.SendToBack()
            Application.DoEvents()
            System.Threading.Thread.Sleep(10)
            ' Se distribuyen hacia abajo. 
            posicionY += alto + margen
        Next
        Me.Cursor = Cursors.Default

    End Sub

#End Region

#Region "Numeraciones"

    Public Enum TipoActividad

        internas = 0
        externas = 1

    End Enum

#End Region

    Private Sub splitContenedor_Panel1_MouseHover(sender As Object, e As EventArgs) Handles splitContenedor.Panel1.MouseHover

        'splitContenedor.Panel1.BackColor = ControlPaint.Dark(splitContenedor.Panel1.BackColor)

    End Sub

    Private Sub pnlMarcarVisto_MouseHover(sender As Object, e As EventArgs) Handles pnlMarcarVisto.MouseHover, chkMarcarVisto.MouseHover

        pnlMarcarVisto.BackColor = Color.Transparent
        pnlMarcarVisto.ForeColor = Color.White

    End Sub

    Private Sub pnlMarcarVisto_MouseLeave(sender As Object, e As EventArgs) Handles pnlMarcarVisto.MouseLeave, chkMarcarVisto.MouseLeave

        pnlMarcarVisto.BackColor = Color.White
        pnlMarcarVisto.ForeColor = Color.Black

    End Sub

    Private Sub chkMarcarVisto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMarcarVisto.CheckedChanged

        If chkMarcarVisto.Checked Then
            pnlMarcarVisto.Visible = False
            Me.fueVisto = True
            Principal.GuardarVisto(True)
        End If

    End Sub

End Class