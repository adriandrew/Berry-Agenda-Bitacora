<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Listado
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Listado))
        Me.pnlPrueba1 = New System.Windows.Forms.Panel()
        Me.pnlPrueba2 = New System.Windows.Forms.Panel()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.lbl2 = New System.Windows.Forms.Label()
        Me.pnlPrueba1.SuspendLayout()
        Me.pnlPrueba2.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlPrueba1
        '
        Me.pnlPrueba1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPrueba1.BackColor = System.Drawing.Color.White
        Me.pnlPrueba1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPrueba1.Controls.Add(Me.lbl1)
        Me.pnlPrueba1.Location = New System.Drawing.Point(-1, 0)
        Me.pnlPrueba1.Name = "pnlPrueba1"
        Me.pnlPrueba1.Size = New System.Drawing.Size(1040, 100)
        Me.pnlPrueba1.TabIndex = 0
        '
        'pnlPrueba2
        '
        Me.pnlPrueba2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPrueba2.BackColor = System.Drawing.Color.White
        Me.pnlPrueba2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPrueba2.Controls.Add(Me.lbl2)
        Me.pnlPrueba2.Location = New System.Drawing.Point(-1, 106)
        Me.pnlPrueba2.Name = "pnlPrueba2"
        Me.pnlPrueba2.Size = New System.Drawing.Size(1040, 100)
        Me.pnlPrueba2.TabIndex = 1
        '
        'lbl1
        '
        Me.lbl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl1.AutoSize = True
        Me.lbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1.ForeColor = System.Drawing.Color.Black
        Me.lbl1.Location = New System.Drawing.Point(6, 8)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(1027, 37)
        Me.lbl1.TabIndex = 0
        Me.lbl1.Text = "                                                                                 " & _
    "                    "
        '
        'lbl2
        '
        Me.lbl2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl2.AutoSize = True
        Me.lbl2.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2.ForeColor = System.Drawing.Color.Black
        Me.lbl2.Location = New System.Drawing.Point(6, 9)
        Me.lbl2.Name = "lbl2"
        Me.lbl2.Size = New System.Drawing.Size(1027, 37)
        Me.lbl2.TabIndex = 1
        Me.lbl2.Text = "                                                                                 " & _
    "                    "
        '
        'Listado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.GhostWhite
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1039, 635)
        Me.Controls.Add(Me.pnlPrueba2)
        Me.Controls.Add(Me.pnlPrueba1)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Listado"
        Me.Opacity = 0.95R
        Me.Text = "Notificaciones - Listado de Actividades Vencidas "
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlPrueba1.ResumeLayout(False)
        Me.pnlPrueba1.PerformLayout()
        Me.pnlPrueba2.ResumeLayout(False)
        Me.pnlPrueba2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlPrueba1 As System.Windows.Forms.Panel
    Friend WithEvents pnlPrueba2 As System.Windows.Forms.Panel
    Friend WithEvents lbl1 As System.Windows.Forms.Label
    Friend WithEvents lbl2 As System.Windows.Forms.Label
End Class
