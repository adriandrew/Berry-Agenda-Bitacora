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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Listado))
        Me.pnlInternas = New System.Windows.Forms.Panel()
        Me.pnlExternas = New System.Windows.Forms.Panel()
        Me.splitContenedor = New System.Windows.Forms.SplitContainer()
        Me.notificador = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.pnlMarcarVisto = New System.Windows.Forms.Panel()
        Me.chkMarcarVisto = New System.Windows.Forms.CheckBox()
        Me.splitContenedor.SuspendLayout()
        Me.pnlMarcarVisto.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlInternas
        '
        Me.pnlInternas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlInternas.AutoScroll = True
        Me.pnlInternas.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnlInternas.Cursor = System.Windows.Forms.Cursors.Default
        Me.pnlInternas.Location = New System.Drawing.Point(0, 0)
        Me.pnlInternas.Name = "pnlInternas"
        Me.pnlInternas.Size = New System.Drawing.Size(515, 633)
        Me.pnlInternas.TabIndex = 0
        '
        'pnlExternas
        '
        Me.pnlExternas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlExternas.AutoScroll = True
        Me.pnlExternas.AutoSize = True
        Me.pnlExternas.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlExternas.Cursor = System.Windows.Forms.Cursors.Default
        Me.pnlExternas.Location = New System.Drawing.Point(524, 1)
        Me.pnlExternas.Name = "pnlExternas"
        Me.pnlExternas.Size = New System.Drawing.Size(515, 633)
        Me.pnlExternas.TabIndex = 1
        '
        'splitContenedor
        '
        Me.splitContenedor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.splitContenedor.Location = New System.Drawing.Point(0, 0)
        Me.splitContenedor.Name = "splitContenedor"
        '
        'splitContenedor.Panel1
        '
        Me.splitContenedor.Panel1.AutoScroll = True
        Me.splitContenedor.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'splitContenedor.Panel2
        '
        Me.splitContenedor.Panel2.AutoScroll = True
        Me.splitContenedor.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.splitContenedor.Size = New System.Drawing.Size(1039, 633)
        Me.splitContenedor.SplitterDistance = 519
        Me.splitContenedor.TabIndex = 2
        '
        'notificador
        '
        Me.notificador.Icon = CType(resources.GetObject("notificador.Icon"), System.Drawing.Icon)
        Me.notificador.Text = "Notificador"
        Me.notificador.Visible = True
        '
        'pnlMarcarVisto
        '
        Me.pnlMarcarVisto.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pnlMarcarVisto.BackColor = System.Drawing.Color.White
        Me.pnlMarcarVisto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMarcarVisto.Controls.Add(Me.chkMarcarVisto)
        Me.pnlMarcarVisto.Location = New System.Drawing.Point(405, 0)
        Me.pnlMarcarVisto.Name = "pnlMarcarVisto"
        Me.pnlMarcarVisto.Size = New System.Drawing.Size(232, 39)
        Me.pnlMarcarVisto.TabIndex = 0
        '
        'chkMarcarVisto
        '
        Me.chkMarcarVisto.AutoSize = True
        Me.chkMarcarVisto.BackColor = System.Drawing.Color.Transparent
        Me.chkMarcarVisto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine
        Me.chkMarcarVisto.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMarcarVisto.Location = New System.Drawing.Point(4, 4)
        Me.chkMarcarVisto.Name = "chkMarcarVisto"
        Me.chkMarcarVisto.Size = New System.Drawing.Size(225, 29)
        Me.chkMarcarVisto.TabIndex = 0
        Me.chkMarcarVisto.Text = "Marcar como leído"
        Me.chkMarcarVisto.UseVisualStyleBackColor = False
        '
        'Listado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.GhostWhite
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1039, 635)
        Me.Controls.Add(Me.pnlMarcarVisto)
        Me.Controls.Add(Me.splitContenedor)
        Me.Controls.Add(Me.pnlInternas)
        Me.Controls.Add(Me.pnlExternas)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Listado"
        Me.Opacity = 0.9R
        Me.Text = "Notificaciones - Listado de Actividades Vencidas "
        Me.TopMost = True
        Me.splitContenedor.ResumeLayout(False)
        Me.pnlMarcarVisto.ResumeLayout(False)
        Me.pnlMarcarVisto.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlInternas As System.Windows.Forms.Panel
    Friend WithEvents pnlExternas As System.Windows.Forms.Panel
    Friend WithEvents splitContenedor As System.Windows.Forms.SplitContainer
    Friend WithEvents notificador As System.Windows.Forms.NotifyIcon
    Friend WithEvents pnlMarcarVisto As System.Windows.Forms.Panel
    Friend WithEvents chkMarcarVisto As System.Windows.Forms.CheckBox
End Class
