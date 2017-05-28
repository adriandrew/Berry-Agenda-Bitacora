<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Imagen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Imagen))
        Me.pbImagen = New System.Windows.Forms.PictureBox()
        Me.opdDialogo = New System.Windows.Forms.OpenFileDialog()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.btnEliminarImagen = New System.Windows.Forms.Button()
        Me.btnMostrarImagen = New System.Windows.Forms.Button()
        Me.btnAgregarImagen = New System.Windows.Forms.Button()
        Me.lblDescripcionTooltip = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.pnlContenido = New System.Windows.Forms.Panel()
        Me.pnlCuerpo = New System.Windows.Forms.Panel()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlContenido.SuspendLayout()
        Me.pnlCuerpo.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbImagen
        '
        Me.pbImagen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbImagen.BackColor = System.Drawing.Color.Transparent
        Me.pbImagen.Location = New System.Drawing.Point(0, 0)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(1029, 566)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbImagen.TabIndex = 0
        Me.pbImagen.TabStop = False
        '
        'opdDialogo
        '
        Me.opdDialogo.FileName = "OpenFileDialog1"
        '
        'pnlPie
        '
        Me.pnlPie.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPie.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.pnlPie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPie.Controls.Add(Me.btnEliminarImagen)
        Me.pnlPie.Controls.Add(Me.btnMostrarImagen)
        Me.pnlPie.Controls.Add(Me.btnAgregarImagen)
        Me.pnlPie.Controls.Add(Me.lblDescripcionTooltip)
        Me.pnlPie.Controls.Add(Me.btnSalir)
        Me.pnlPie.Location = New System.Drawing.Point(0, 574)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1035, 60)
        Me.pnlPie.TabIndex = 9
        '
        'btnEliminarImagen
        '
        Me.btnEliminarImagen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminarImagen.BackColor = System.Drawing.Color.White
        Me.btnEliminarImagen.Image = CType(resources.GetObject("btnEliminarImagen.Image"), System.Drawing.Image)
        Me.btnEliminarImagen.Location = New System.Drawing.Point(896, -1)
        Me.btnEliminarImagen.Margin = New System.Windows.Forms.Padding(0)
        Me.btnEliminarImagen.Name = "btnEliminarImagen"
        Me.btnEliminarImagen.Size = New System.Drawing.Size(60, 60)
        Me.btnEliminarImagen.TabIndex = 28
        Me.btnEliminarImagen.UseVisualStyleBackColor = False
        '
        'btnMostrarImagen
        '
        Me.btnMostrarImagen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMostrarImagen.BackColor = System.Drawing.Color.White
        Me.btnMostrarImagen.Image = CType(resources.GetObject("btnMostrarImagen.Image"), System.Drawing.Image)
        Me.btnMostrarImagen.Location = New System.Drawing.Point(758, -1)
        Me.btnMostrarImagen.Margin = New System.Windows.Forms.Padding(0)
        Me.btnMostrarImagen.Name = "btnMostrarImagen"
        Me.btnMostrarImagen.Size = New System.Drawing.Size(60, 60)
        Me.btnMostrarImagen.TabIndex = 27
        Me.btnMostrarImagen.UseVisualStyleBackColor = False
        Me.btnMostrarImagen.Visible = False
        '
        'btnAgregarImagen
        '
        Me.btnAgregarImagen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAgregarImagen.BackColor = System.Drawing.Color.White
        Me.btnAgregarImagen.Image = CType(resources.GetObject("btnAgregarImagen.Image"), System.Drawing.Image)
        Me.btnAgregarImagen.Location = New System.Drawing.Point(827, -1)
        Me.btnAgregarImagen.Margin = New System.Windows.Forms.Padding(0)
        Me.btnAgregarImagen.Name = "btnAgregarImagen"
        Me.btnAgregarImagen.Size = New System.Drawing.Size(60, 60)
        Me.btnAgregarImagen.TabIndex = 26
        Me.btnAgregarImagen.UseVisualStyleBackColor = False
        '
        'lblDescripcionTooltip
        '
        Me.lblDescripcionTooltip.AutoSize = True
        Me.lblDescripcionTooltip.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcionTooltip.ForeColor = System.Drawing.Color.White
        Me.lblDescripcionTooltip.Location = New System.Drawing.Point(101, 17)
        Me.lblDescripcionTooltip.Name = "lblDescripcionTooltip"
        Me.lblDescripcionTooltip.Size = New System.Drawing.Size(0, 31)
        Me.lblDescripcionTooltip.TabIndex = 3
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.BackColor = System.Drawing.Color.White
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(973, -1)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(0)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(60, 60)
        Me.btnSalir.TabIndex = 2
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'pnlContenido
        '
        Me.pnlContenido.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlContenido.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnlContenido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlContenido.Controls.Add(Me.pnlCuerpo)
        Me.pnlContenido.Controls.Add(Me.pnlPie)
        Me.pnlContenido.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlContenido.Location = New System.Drawing.Point(2, 1)
        Me.pnlContenido.Name = "pnlContenido"
        Me.pnlContenido.Size = New System.Drawing.Size(1035, 633)
        Me.pnlContenido.TabIndex = 10
        '
        'pnlCuerpo
        '
        Me.pnlCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlCuerpo.AutoScroll = True
        Me.pnlCuerpo.BackColor = System.Drawing.Color.Transparent
        Me.pnlCuerpo.Controls.Add(Me.pbImagen)
        Me.pnlCuerpo.Location = New System.Drawing.Point(3, 3)
        Me.pnlCuerpo.Name = "pnlCuerpo"
        Me.pnlCuerpo.Size = New System.Drawing.Size(1029, 566)
        Me.pnlCuerpo.TabIndex = 9
        '
        'Imagen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1039, 635)
        Me.Controls.Add(Me.pnlContenido)
        Me.ForeColor = System.Drawing.Color.White
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Imagen"
        Me.Text = "Imagen de evidencia"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlContenido.ResumeLayout(False)
        Me.pnlCuerpo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents opdDialogo As System.Windows.Forms.OpenFileDialog
    Private WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents lblDescripcionTooltip As System.Windows.Forms.Label
    Private WithEvents btnSalir As System.Windows.Forms.Button
    Private WithEvents btnMostrarImagen As System.Windows.Forms.Button
    Private WithEvents btnAgregarImagen As System.Windows.Forms.Button
    Private WithEvents btnEliminarImagen As System.Windows.Forms.Button
    Private WithEvents pnlContenido As System.Windows.Forms.Panel
    Private WithEvents pnlCuerpo As System.Windows.Forms.Panel
End Class
