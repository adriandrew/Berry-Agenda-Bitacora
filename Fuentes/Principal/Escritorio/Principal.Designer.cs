namespace Escritorio
{
    partial class Principal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.pnlIniciarSesion = new System.Windows.Forms.Panel();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.btnEntrar = new System.Windows.Forms.Button();
            this.btnMostrarOpciones = new System.Windows.Forms.Button();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.picUsuario = new System.Windows.Forms.PictureBox();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlPie = new System.Windows.Forms.Panel();
            this.btnAyuda = new System.Windows.Forms.Button();
            this.lblDescripcionTooltip = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnCambiarEmpresa = new System.Windows.Forms.Button();
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblEncabezadoArea = new System.Windows.Forms.Label();
            this.lblEncabezadoUsuario = new System.Windows.Forms.Label();
            this.lblEncabezadoEmpresa = new System.Windows.Forms.Label();
            this.lblEncabezadoPrograma = new System.Windows.Forms.Label();
            this.temporizador = new System.Windows.Forms.Timer(this.components);
            this.chkMostrarNotificaciones = new System.Windows.Forms.CheckBox();
            this.pnlOpciones = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlContenido.SuspendLayout();
            this.pnlIniciarSesion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUsuario)).BeginInit();
            this.pnlPie.SuspendLayout();
            this.pnlEncabezado.SuspendLayout();
            this.pnlOpciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContenido
            // 
            this.pnlContenido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContenido.BackColor = System.Drawing.Color.DarkSlateGray;
            this.pnlContenido.BackgroundImage = global::PrincipalBerry.Properties.Resources.Logo3;
            this.pnlContenido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlContenido.Controls.Add(this.pnlOpciones);
            this.pnlContenido.Controls.Add(this.pnlIniciarSesion);
            this.pnlContenido.Controls.Add(this.pnlMenu);
            this.pnlContenido.Controls.Add(this.pnlPie);
            this.pnlContenido.Controls.Add(this.pnlEncabezado);
            this.pnlContenido.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlContenido.Location = new System.Drawing.Point(0, 0);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(1035, 633);
            this.pnlContenido.TabIndex = 1;
            this.pnlContenido.MouseHover += new System.EventHandler(this.pnlContenido_MouseHover);
            // 
            // pnlIniciarSesion
            // 
            this.pnlIniciarSesion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlIniciarSesion.BackColor = System.Drawing.Color.White;
            this.pnlIniciarSesion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlIniciarSesion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlIniciarSesion.Controls.Add(this.txtContraseña);
            this.pnlIniciarSesion.Controls.Add(this.txtUsuario);
            this.pnlIniciarSesion.Controls.Add(this.btnEntrar);
            this.pnlIniciarSesion.Controls.Add(this.btnMostrarOpciones);
            this.pnlIniciarSesion.Controls.Add(this.lblContraseña);
            this.pnlIniciarSesion.Controls.Add(this.lblUsuario);
            this.pnlIniciarSesion.Controls.Add(this.picUsuario);
            this.pnlIniciarSesion.ForeColor = System.Drawing.Color.Black;
            this.pnlIniciarSesion.Location = new System.Drawing.Point(310, 225);
            this.pnlIniciarSesion.Name = "pnlIniciarSesion";
            this.pnlIniciarSesion.Size = new System.Drawing.Size(422, 206);
            this.pnlIniciarSesion.TabIndex = 6;
            this.pnlIniciarSesion.MouseHover += new System.EventHandler(this.pnlIniciarSesion_MouseHover);
            // 
            // txtContraseña
            // 
            this.txtContraseña.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtContraseña.BackColor = System.Drawing.Color.White;
            this.txtContraseña.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraseña.Location = new System.Drawing.Point(151, 144);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(196, 31);
            this.txtContraseña.TabIndex = 22;
            this.txtContraseña.UseSystemPasswordChar = true;
            this.txtContraseña.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContraseña_KeyDown);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUsuario.BackColor = System.Drawing.Color.White;
            this.txtUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(151, 107);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(249, 31);
            this.txtUsuario.TabIndex = 21;
            this.txtUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUsuario_KeyDown);
            // 
            // btnEntrar
            // 
            this.btnEntrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEntrar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnEntrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEntrar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnEntrar.FlatAppearance.BorderSize = 3;
            this.btnEntrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine;
            this.btnEntrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntrar.ForeColor = System.Drawing.Color.White;
            this.btnEntrar.Image = ((System.Drawing.Image)(resources.GetObject("btnEntrar.Image")));
            this.btnEntrar.Location = new System.Drawing.Point(353, 142);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(47, 33);
            this.btnEntrar.TabIndex = 23;
            this.btnEntrar.UseVisualStyleBackColor = false;
            this.btnEntrar.Click += new System.EventHandler(this.btnIniciarSesion_Click);
            this.btnEntrar.MouseHover += new System.EventHandler(this.btnEntrar_MouseHover);
            // 
            // btnMostrarOpciones
            // 
            this.btnMostrarOpciones.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMostrarOpciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMostrarOpciones.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMostrarOpciones.Image = ((System.Drawing.Image)(resources.GetObject("btnMostrarOpciones.Image")));
            this.btnMostrarOpciones.Location = new System.Drawing.Point(434, 115);
            this.btnMostrarOpciones.Name = "btnMostrarOpciones";
            this.btnMostrarOpciones.Size = new System.Drawing.Size(29, 55);
            this.btnMostrarOpciones.TabIndex = 24;
            this.btnMostrarOpciones.UseVisualStyleBackColor = false;
            this.btnMostrarOpciones.Visible = false;
            // 
            // lblContraseña
            // 
            this.lblContraseña.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContraseña.ForeColor = System.Drawing.Color.Black;
            this.lblContraseña.Location = new System.Drawing.Point(9, 146);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(140, 25);
            this.lblContraseña.TabIndex = 20;
            this.lblContraseña.Text = "Contraseña:";
            this.lblContraseña.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.Black;
            this.lblUsuario.Location = new System.Drawing.Point(9, 110);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(100, 25);
            this.lblUsuario.TabIndex = 19;
            this.lblUsuario.Text = "Usuario:";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picUsuario
            // 
            this.picUsuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picUsuario.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picUsuario.BackgroundImage")));
            this.picUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picUsuario.Location = new System.Drawing.Point(190, 22);
            this.picUsuario.Name = "picUsuario";
            this.picUsuario.Size = new System.Drawing.Size(70, 70);
            this.picUsuario.TabIndex = 0;
            this.picUsuario.TabStop = false;
            // 
            // pnlMenu
            // 
            this.pnlMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMenu.AutoScroll = true;
            this.pnlMenu.BackColor = System.Drawing.Color.Transparent;
            this.pnlMenu.Location = new System.Drawing.Point(3, 78);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(1029, 489);
            this.pnlMenu.TabIndex = 9;
            this.pnlMenu.Visible = false;
            this.pnlMenu.MouseHover += new System.EventHandler(this.pnlMenu_MouseHover);
            // 
            // pnlPie
            // 
            this.pnlPie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPie.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.pnlPie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPie.Controls.Add(this.btnAyuda);
            this.pnlPie.Controls.Add(this.lblDescripcionTooltip);
            this.pnlPie.Controls.Add(this.btnSalir);
            this.pnlPie.Controls.Add(this.btnCambiarEmpresa);
            this.pnlPie.Location = new System.Drawing.Point(0, 570);
            this.pnlPie.Name = "pnlPie";
            this.pnlPie.Size = new System.Drawing.Size(1035, 60);
            this.pnlPie.TabIndex = 8;
            this.pnlPie.MouseHover += new System.EventHandler(this.pnlPie_MouseHover);
            // 
            // btnAyuda
            // 
            this.btnAyuda.BackColor = System.Drawing.Color.White;
            this.btnAyuda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAyuda.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAyuda.FlatAppearance.BorderSize = 3;
            this.btnAyuda.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine;
            this.btnAyuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAyuda.ForeColor = System.Drawing.Color.Black;
            this.btnAyuda.Image = ((System.Drawing.Image)(resources.GetObject("btnAyuda.Image")));
            this.btnAyuda.Location = new System.Drawing.Point(0, 0);
            this.btnAyuda.Margin = new System.Windows.Forms.Padding(0);
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Size = new System.Drawing.Size(60, 60);
            this.btnAyuda.TabIndex = 5;
            this.btnAyuda.UseVisualStyleBackColor = false;
            this.btnAyuda.Click += new System.EventHandler(this.btnAyuda_Click);
            this.btnAyuda.MouseHover += new System.EventHandler(this.btnAyuda_MouseHover);
            // 
            // lblDescripcionTooltip
            // 
            this.lblDescripcionTooltip.AutoSize = true;
            this.lblDescripcionTooltip.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcionTooltip.ForeColor = System.Drawing.Color.White;
            this.lblDescripcionTooltip.Location = new System.Drawing.Point(101, 17);
            this.lblDescripcionTooltip.Name = "lblDescripcionTooltip";
            this.lblDescripcionTooltip.Size = new System.Drawing.Size(0, 31);
            this.lblDescripcionTooltip.TabIndex = 4;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.White;
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSalir.FlatAppearance.BorderSize = 3;
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(973, 0);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(0);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 60);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            this.btnSalir.MouseHover += new System.EventHandler(this.btnSalir_MouseHover);
            // 
            // btnCambiarEmpresa
            // 
            this.btnCambiarEmpresa.BackColor = System.Drawing.Color.White;
            this.btnCambiarEmpresa.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCambiarEmpresa.FlatAppearance.BorderSize = 3;
            this.btnCambiarEmpresa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine;
            this.btnCambiarEmpresa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiarEmpresa.Image = ((System.Drawing.Image)(resources.GetObject("btnCambiarEmpresa.Image")));
            this.btnCambiarEmpresa.Location = new System.Drawing.Point(912, 0);
            this.btnCambiarEmpresa.Margin = new System.Windows.Forms.Padding(0);
            this.btnCambiarEmpresa.Name = "btnCambiarEmpresa";
            this.btnCambiarEmpresa.Size = new System.Drawing.Size(60, 60);
            this.btnCambiarEmpresa.TabIndex = 0;
            this.btnCambiarEmpresa.UseVisualStyleBackColor = false;
            this.btnCambiarEmpresa.Visible = false;
            this.btnCambiarEmpresa.Click += new System.EventHandler(this.btnCambiarEmpresa_Click);
            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlEncabezado.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.pnlEncabezado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEncabezado.Controls.Add(this.lblEncabezadoArea);
            this.pnlEncabezado.Controls.Add(this.lblEncabezadoUsuario);
            this.pnlEncabezado.Controls.Add(this.lblEncabezadoEmpresa);
            this.pnlEncabezado.Controls.Add(this.lblEncabezadoPrograma);
            this.pnlEncabezado.Location = new System.Drawing.Point(0, 0);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(1035, 75);
            this.pnlEncabezado.TabIndex = 7;
            this.pnlEncabezado.MouseHover += new System.EventHandler(this.pnlEncabezado_MouseHover);
            // 
            // lblEncabezadoArea
            // 
            this.lblEncabezadoArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEncabezadoArea.AutoSize = true;
            this.lblEncabezadoArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncabezadoArea.ForeColor = System.Drawing.Color.White;
            this.lblEncabezadoArea.Location = new System.Drawing.Point(600, 0);
            this.lblEncabezadoArea.Name = "lblEncabezadoArea";
            this.lblEncabezadoArea.Size = new System.Drawing.Size(0, 33);
            this.lblEncabezadoArea.TabIndex = 5;
            // 
            // lblEncabezadoUsuario
            // 
            this.lblEncabezadoUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEncabezadoUsuario.AutoSize = true;
            this.lblEncabezadoUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncabezadoUsuario.ForeColor = System.Drawing.Color.White;
            this.lblEncabezadoUsuario.Location = new System.Drawing.Point(600, 35);
            this.lblEncabezadoUsuario.Name = "lblEncabezadoUsuario";
            this.lblEncabezadoUsuario.Size = new System.Drawing.Size(0, 33);
            this.lblEncabezadoUsuario.TabIndex = 4;
            // 
            // lblEncabezadoEmpresa
            // 
            this.lblEncabezadoEmpresa.AutoSize = true;
            this.lblEncabezadoEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncabezadoEmpresa.ForeColor = System.Drawing.Color.White;
            this.lblEncabezadoEmpresa.Location = new System.Drawing.Point(10, 35);
            this.lblEncabezadoEmpresa.Name = "lblEncabezadoEmpresa";
            this.lblEncabezadoEmpresa.Size = new System.Drawing.Size(0, 33);
            this.lblEncabezadoEmpresa.TabIndex = 1;
            // 
            // lblEncabezadoPrograma
            // 
            this.lblEncabezadoPrograma.AutoSize = true;
            this.lblEncabezadoPrograma.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncabezadoPrograma.ForeColor = System.Drawing.Color.White;
            this.lblEncabezadoPrograma.Location = new System.Drawing.Point(10, 0);
            this.lblEncabezadoPrograma.Name = "lblEncabezadoPrograma";
            this.lblEncabezadoPrograma.Size = new System.Drawing.Size(0, 33);
            this.lblEncabezadoPrograma.TabIndex = 0;
            // 
            // temporizador
            // 
            this.temporizador.Interval = 1;
            this.temporizador.Tick += new System.EventHandler(this.temporizador_Tick);
            // 
            // chkMostrarNotificaciones
            // 
            this.chkMostrarNotificaciones.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkMostrarNotificaciones.Checked = true;
            this.chkMostrarNotificaciones.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMostrarNotificaciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkMostrarNotificaciones.FlatAppearance.BorderSize = 2;
            this.chkMostrarNotificaciones.FlatAppearance.CheckedBackColor = System.Drawing.Color.LimeGreen;
            this.chkMostrarNotificaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkMostrarNotificaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMostrarNotificaciones.ForeColor = System.Drawing.Color.White;
            this.chkMostrarNotificaciones.Location = new System.Drawing.Point(124, 30);
            this.chkMostrarNotificaciones.Name = "chkMostrarNotificaciones";
            this.chkMostrarNotificaciones.Size = new System.Drawing.Size(45, 25);
            this.chkMostrarNotificaciones.TabIndex = 25;
            this.chkMostrarNotificaciones.Text = "SI";
            this.chkMostrarNotificaciones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkMostrarNotificaciones.UseVisualStyleBackColor = true;
            this.chkMostrarNotificaciones.CheckedChanged += new System.EventHandler(this.chkMostrarNotificaciones_CheckedChanged);
            // 
            // pnlOpciones
            // 
            this.pnlOpciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOpciones.BackColor = System.Drawing.Color.Transparent;
            this.pnlOpciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOpciones.Controls.Add(this.label1);
            this.pnlOpciones.Controls.Add(this.chkMostrarNotificaciones);
            this.pnlOpciones.Location = new System.Drawing.Point(854, 78);
            this.pnlOpciones.Name = "pnlOpciones";
            this.pnlOpciones.Size = new System.Drawing.Size(175, 489);
            this.pnlOpciones.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 16);
            this.label1.TabIndex = 26;
            this.label1.Text = "Mostrar notificaciones?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1035, 631);
            this.Controls.Add(this.pnlContenido);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Principal";
            this.Text = "Iniciar Sesión y Menú";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Principal_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Principal_FormClosed);
            this.Load += new System.EventHandler(this.Principal_Load);
            this.Shown += new System.EventHandler(this.Principal_Shown);
            this.pnlContenido.ResumeLayout(false);
            this.pnlIniciarSesion.ResumeLayout(false);
            this.pnlIniciarSesion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUsuario)).EndInit();
            this.pnlPie.ResumeLayout(false);
            this.pnlPie.PerformLayout();
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.pnlOpciones.ResumeLayout(false);
            this.pnlOpciones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCambiarEmpresa;
        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.Panel pnlIniciarSesion;
        private System.Windows.Forms.PictureBox picUsuario;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Button btnEntrar;
        private System.Windows.Forms.Button btnMostrarOpciones;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label lblEncabezadoPrograma;
        private System.Windows.Forms.Panel pnlPie;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label lblEncabezadoArea;
        private System.Windows.Forms.Label lblEncabezadoUsuario;
        public System.Windows.Forms.Label lblEncabezadoEmpresa;
        internal System.Windows.Forms.Label lblDescripcionTooltip;
        internal System.Windows.Forms.Timer temporizador;
        private System.Windows.Forms.Button btnAyuda;
        private System.Windows.Forms.Panel pnlOpciones;
        internal System.Windows.Forms.CheckBox chkMostrarNotificaciones;
        private System.Windows.Forms.Label label1;

    }
}