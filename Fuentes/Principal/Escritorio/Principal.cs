﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Data.Sql;

namespace Escritorio
{
    public partial class Principal : Form
    {

        Entidades.Usuarios usuarios = new Entidades.Usuarios();
        Entidades.Empresas empresas = new Entidades.Empresas();
        Entidades.Areas areas = new Entidades.Areas();
        Entidades.BaseDatos baseDatos = new Entidades.BaseDatos();
        Entidades.Modulos modulos = new Entidades.Modulos();
        Entidades.BloqueoUsuarios bloqueoUsuarios = new Entidades.BloqueoUsuarios();
        Entidades.EmpresasPrincipal empresasPrincipal = new Entidades.EmpresasPrincipal();
        Entidades.Licencia licencia = new Entidades.Licencia();
        Entidades.Registros registros = new Entidades.Registros();
        public Logica.DatosEmpresa datosEmpresa = new Logica.DatosEmpresa();
        Logica.DatosUsuario datosUsuario = new Logica.DatosUsuario();
        Logica.DatosArea datosArea = new Logica.DatosArea();
        ProcessStartInfo ejecutarPrograma = new ProcessStartInfo();
        public int numeroEmpresa;
        public bool tieneParametros = false;
        public bool tieneSesionActivada = false;
        public bool esInicioSesion = true;
        public int idEmpresaSesion = 0; public int idUsuarioSesion = 0; public int idModuloSesion = 1;
        public string nombreEstePrograma = string.Empty;
        public string nombreProgramaAbierto = string.Empty;
        public bool estaCerrando = false; public bool estaAbriendoPrograma = false;
        public int diasDePrueba = 15;
        public Color colorCuadroOriginal = Color.Transparent;
        public string nombreEsteEquipo = System.Environment.MachineName;

        public bool esDesarrollo = false;

        public Principal()
        {
            InitializeComponent();
        }
        
        #region Eventos

        private void Principal_Load(object sender, EventArgs e)
        {

            Centrar();
            ConectarUnidadRed();
            AsignarTooltips();
            AsignarFocos();
            ConfigurarConexiones();

        }

        private void Principal_Shown(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            this.Enabled = false;
            CargarEncabezados();
            CargarTitulosEmpresa();
            VerificarLicencia();
            this.Enabled = true;
            this.txtUsuario.Focus();
            this.Cursor = Cursors.Default;

        }

        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {

            Salir();

        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {

            this.estaCerrando = true;
            Desvanecer();

        }

        private void cuadro_Click(object sender, EventArgs e)
        {

            ValidarAbrirPrograma(sender);
             
        }

        private void cuadro_MouseEnter(object sender, EventArgs e)
        {

            EventoRatonEncimaCuadro(sender);

        }

        private void cuadro_MouseLeave(object sender, EventArgs e)
        {

            EventoRatonDejandoCuadro(sender);
             
        }

        private void etiquetaNombre_Click(object sender, EventArgs e)
        {

            Label objetoEtiqueta = new Label();
            objetoEtiqueta = (Label)sender;
            Control objetoControl = new Control();
            objetoControl = objetoEtiqueta.Parent;
            Panel objetoPanel = new Panel();
            objetoPanel = (Panel)objetoControl;
            ValidarAbrirPrograma(objetoPanel);

        }

        private void etiquetaNombre_MouseEnter(object sender, EventArgs e)
        {
             
            Label objetoEtiqueta = new Label(); 
            objetoEtiqueta = (Label)sender;
            Control objetoControl = new Control();
            objetoControl = objetoEtiqueta.Parent;
            Panel objetoPanel = new Panel();
            objetoPanel = (Panel)objetoControl;
            EventoRatonEncimaCuadro(objetoPanel);

        }

        private void etiquetaNombre_MouseLeave(object sender, EventArgs e)
        {

            Label objetoEtiqueta = new Label();
            objetoEtiqueta = (Label)sender;
            Control objetoControl = new Control();
            objetoControl = objetoEtiqueta.Parent;
            Panel objetoPanel = new Panel();
            objetoPanel = (Panel)objetoControl;
            EventoRatonDejandoCuadro(objetoPanel);

        }

        private void btnCambiarEmpresa_Click(object sender, EventArgs e)
        {

            this.Hide();            
            new AdministrarEmpresas().Show();

        }
        
        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (!string.IsNullOrEmpty(this.txtUsuario.Text))
                { 
                    this.txtContraseña.Focus();                
                }            
            } 

        }

        private void txtContraseña_KeyDown(object sender, KeyEventArgs e)
        { 

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (!string.IsNullOrEmpty(this.txtContraseña.Text))
                {
                    this.btnEntrar.Focus();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.txtUsuario.Focus();
            } 

        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        { 

            ValidarSesion(); 

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

            SalirOVolver();

        }

        private void btnEntrar_MouseHover(object sender, EventArgs e)
        {

            AsignarTooltips("Entrar.");

        }

        private void btnSalir_MouseHover(object sender, EventArgs e)
        {

            if (this.esInicioSesion)
            {
                AsignarTooltips("Salir."); 
            }
            else
            {
                AsignarTooltips("Volver a Iniciar Sesión."); 
            }

        }
         
        private void pnlEncabezado_MouseHover(object sender, EventArgs e)
        {

            AsignarTooltips(string.Empty); 

        }

        private void pnlContenido_MouseHover(object sender, EventArgs e)
        {

            AsignarTooltips(string.Empty); 

        }

        private void pnlMenu_MouseHover(object sender, EventArgs e)
        {

            AsignarTooltips(string.Empty); 

        }

        private void pnlIniciarSesion_MouseHover(object sender, EventArgs e)
        {

            AsignarTooltips(string.Empty); 

        }

        private void pnlPie_MouseHover(object sender, EventArgs e)
        {

            AsignarTooltips(string.Empty); 

        }

        private void temporizador_Tick(object sender, EventArgs e)
        {

            if (this.estaCerrando)
            {
                Desvanecer();
            }

        }
        
        private void btnAyuda_MouseHover(object sender, EventArgs e)
        {

            AsignarTooltips("Ayuda.");

        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {

            MostrarAyuda();

        }

        private void chkMostrarNotificaciones_CheckedChanged(object sender, EventArgs e)
        {
             
            if (chkMostrarNotificaciones.Checked) 
            { 
                chkMostrarNotificaciones.Text = "SI";
            }
            else
            {
                chkMostrarNotificaciones.Text = "NO";
            } 

        }

        #endregion

        #region Métodos

        private void ConectarUnidadRed()
        {

            //MessageBox.Show(Directory.GetDirectories(Application.StartupPath).Count().ToString());
            if (Directory.GetDirectories(Application.StartupPath).Count() == 0)
            {
                try
                {
                    // Opcion 1.
                    //        MessageBox.Show("Intentando conectar con unidad de red.", "Conectando.", MessageBoxButtons.OK, MessageBoxIcon.None);
                    //        string ruta = Application.StartupPath + "\\Unidades.bat";
                    //        ProcessStartInfo procesoInicio = new ProcessStartInfo(ruta);
                    //        System.Diagnostics.Process.Start(procesoInicio);
                    //        System.Threading.Thread.Sleep(3000);
                    // Opcion 2.
                    string unidad = Application.StartupPath;
                    //MessageBox.Show(unidad);
                    Process.Start("explorer.exe", @"" + unidad);
                    System.Threading.Thread.Sleep(2000);
                    foreach (Process p in Process.GetProcessesByName("explorer"))
                    {
                        if (p.MainWindowTitle.ToUpper().Contains(@"" + unidad.Replace("\\", "").Replace("//", "/")) || Application.StartupPath.ToUpper().Equals(p.MainWindowTitle.ToUpper()))
                        {
                            p.Kill();
                        }
                    }
                    this.BringToFront();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al intentar conectar a unidad de red. " + ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void VerificarLicencia()
        {

            List<Entidades.Licencia> lista = new List<Entidades.Licencia>();
            lista = licencia.ObtenerListado();
            if (lista.Count > 0)
            {
                if (lista[0].EsPrueba)
                {
                    DateTime registro; DateTime vencimiento;
                    if (DateTime.TryParse(lista[0].FechaRegistro.ToString(), out registro) == true)
                    { 
                        if (DateTime.TryParse(lista[0].FechaVencimiento.ToString(), out vencimiento) == true)
                        {
                            //vencimiento = Convert.ToDateTime("22/04/2017");
                            if (DateTime.Today.CompareTo(vencimiento) > 0)
                            {
                                MessageBox.Show("La versión de prueba ha terminado. Contacte a su proveedor de este sistema para obtener una licencia.", "Versión de prueba.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                SalirOVolver();
                            }
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("Este programa no se encuentra registrado. Si desea, puede activar la versión de prueba dando clic en aceptar/si.", "Versión de prueba.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            licencia.EsPrueba = true;
                            licencia.FechaRegistro = DateTime.Today;
                            licencia.FechaVencimiento = DateTime.Today.AddDays(this.diasDePrueba);
                            licencia.Eliminar();
                            licencia.Guardar();
                            MessageBox.Show("Activación de versión de prueba de " + this.diasDePrueba + " dias correcta.", "Versión de prueba.", MessageBoxButtons.OK, MessageBoxIcon.None);
                        }
                        else
                        {
                            SalirOVolver();
                        }
                    }
                }
            }
            else
            {
                if (MessageBox.Show("Este programa no se encuentra registrado. Active la versión de prueba dando clic en aceptar/si.", "Versión de prueba.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    licencia.EsPrueba = true;
                    licencia.FechaRegistro = DateTime.Today;
                    licencia.FechaVencimiento = DateTime.Today.AddDays(this.diasDePrueba);
                    licencia.Eliminar();
                    licencia.Guardar();
                    MessageBox.Show("Activación de versión de prueba de " + this.diasDePrueba + " dias correcta.", "Versión de prueba.", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                else
                {
                    SalirOVolver();
                }
            }

        }

        private void Salir() 
        {

            this.Cursor = Cursors.WaitCursor; 
            if (this.estaAbriendoPrograma)
            {
                System.Threading.Thread.Sleep(3000);
            }
            else
            { 
                GuardarEditarRegistro(datosEmpresa.Id, 0, 0, false); 
            }
            Application.ExitThread();
            Application.Exit();
            this.Cursor = Cursors.Default;

        }

        private void SalirOVolver() 
        {

            this.Cursor = Cursors.WaitCursor;  
            GuardarEditarRegistro(datosEmpresa.Id, 0, 0, false);
            if (this.esInicioSesion)
            {
                Application.Exit();
            }
            else
            {
                pnlContenido.BackgroundImage = global::PrincipalBerry.Properties.Resources.Logo3;
                pnlContenido.BackgroundImageLayout = ImageLayout.Zoom;
                pnlContenido.BackColor = Color.DarkSlateGray;
                //pnlContenido.BackgroundImage = global::Principal.Properties.Resources.hiedra;
                //pnlContenido.BackgroundImageLayout = ImageLayout.Stretch;
                pnlMenu.Visible = false;
                pnlIniciarSesion.Visible = true;
                pnlOpciones.Visible = true;
                txtContraseña.Text = string.Empty;
                txtUsuario.Text = string.Empty;
                txtUsuario.Focus();
                this.esInicioSesion = true;
            }
            this.Cursor = Cursors.Default;

        }

        private void MostrarAyuda()
        {

            this.Cursor = Cursors.WaitCursor;  
            Panel pnlAyuda = new Panel();
            TextBox txtAyuda = new TextBox();
            if (pnlContenido.Controls.Find("pnlAyuda", true).Count() == 0)
            {
                pnlAyuda.Name = "pnlAyuda"; Application.DoEvents();
                pnlAyuda.Visible = false; Application.DoEvents();
                pnlContenido.Controls.Add(pnlAyuda); Application.DoEvents();
                txtAyuda.Name = "txtAyuda"; Application.DoEvents();
                pnlAyuda.Controls.Add(txtAyuda); Application.DoEvents();
            }
            else
            {
                pnlAyuda = pnlContenido.Controls.Find("pnlAyuda", false).FirstOrDefault() as Panel; Application.DoEvents();
                txtAyuda = pnlAyuda.Controls.Find("txtAyuda", false).FirstOrDefault() as TextBox; Application.DoEvents();
            }
            if ((!pnlAyuda.Visible))
            {
                if (this.esInicioSesion)
                {
                    pnlIniciarSesion.Visible = false; Application.DoEvents();
                    pnlOpciones.Visible = false; Application.DoEvents();
                }
                else
                { 
                    pnlMenu.Visible = false; Application.DoEvents(); 
                }
                pnlAyuda.Visible = true; Application.DoEvents();
                pnlAyuda.Size = pnlMenu.Size; Application.DoEvents();
                pnlAyuda.Location = pnlMenu.Location; Application.DoEvents();
                pnlContenido.Controls.Add(pnlAyuda); Application.DoEvents();
                txtAyuda.ScrollBars = ScrollBars.Both; Application.DoEvents();
                txtAyuda.Multiline = true; Application.DoEvents();
                txtAyuda.Width = pnlAyuda.Width - 10; Application.DoEvents();
                txtAyuda.Height = pnlAyuda.Height - 10; Application.DoEvents();
                txtAyuda.Location = new Point(5, 5); Application.DoEvents();
                txtAyuda.Text = "Sección de Ayuda: " + System.Environment.NewLine + System.Environment.NewLine + "* Iniciar Sesión: " + System.Environment.NewLine + "En esta parte se capturarán los datos de usuario y contraseña. " + System.Environment.NewLine + "Se le puede dar enter para avanzar, primero en usuario, luego en contraseña y despues de otro enter iniciará sesión, o en su caso darle clic al botón de la flecha. " + System.Environment.NewLine + System.Environment.NewLine + "* Menú: " + System.Environment.NewLine + "Una vez iniciado sesión, en este apartado aparecen todos los programas en un color distinto y aleatorio. " + System.Environment.NewLine + "Para abrir un programa simplemente hay que darle clic en la opción correspondiente y esperar a que se muestre. Dependiendo los permisos de usuario se podrá acceder o no."; Application.DoEvents();
                pnlAyuda.Controls.Add(txtAyuda); Application.DoEvents();
            }
            else
            {
                if (this.esInicioSesion)
                {
                    pnlIniciarSesion.Visible = true; Application.DoEvents();
                    pnlOpciones.Visible = true; Application.DoEvents();
                }
                else 
                { 
                    pnlMenu.Visible = true; Application.DoEvents(); 
                }
                pnlAyuda.Visible = false; Application.DoEvents();
            }
            this.Cursor = Cursors.Default;

        } 

        private void Desvanecer()
        {
             
            // Se ponen en color gris todos los controles de esta pantalla.
            foreach (Control c in this.Controls)
            {
                if (c.BackColor != Color.Gray)
                c.BackColor = Color.Gray;
                c.Parent.BackColor = Color.Gray; 
            }
            Application.DoEvents();
            // Se comienza a desaparecer el programa gradualmente.
            temporizador.Interval = 10;
            temporizador.Enabled = true;
            temporizador.Start();
            if (this.Opacity > 0)
            {
                this.Opacity -= 0.25; Application.DoEvents();
            }
            else
            {
                temporizador.Enabled = false;
                temporizador.Stop();
            } 

        }

        private bool ValidarAccesso(int idModulo, int idPrograma)
        { 
        
            bool valor = false;
            bloqueoUsuarios.IdEmpresa = this.idEmpresaSesion;
            bloqueoUsuarios.IdUsuario = this.idUsuarioSesion;
            bloqueoUsuarios.IdModulo = idModulo;
            bloqueoUsuarios.IdPrograma = idPrograma;
            valor = bloqueoUsuarios.ValidarPorNumero();
            return valor;

        }

        private void ValidarSesion()
        { 

            if (!string.IsNullOrEmpty(this.txtUsuario.Text) && !string.IsNullOrEmpty(this.txtContraseña.Text))
            {
                if ((txtUsuario.Text.ToUpper().Equals("Admin".ToUpper())) && (txtContraseña.Text.Equals("@berry")))
                {
                    this.Hide();
                    PanelControl.nombreEmpresa = this.datosEmpresa.Nombre; 
                    new PanelControl().Show();
                }
                else
                {
                    usuarios.Nombre = this.txtUsuario.Text;
                    usuarios.IdEmpresa = datosEmpresa.Id;
                    List<Entidades.Usuarios> lista = usuarios.ObtenerPorNombre();
                    if (lista.Count > 0)
                    {
                        if (this.txtContraseña.Text.Equals(lista[0].Contrasena))
                        {
                            // Se guarda registro de qué equipos tienen notificaciones en pantalla.
                            GuardarEditarRegistro(lista[0].IdEmpresa, lista[0].Id, lista[0].IdArea, true);
                            PermitirAcceso(lista[0].IdEmpresa, lista[0].Id, chkMostrarNotificaciones.Checked);
                        }
                        else
                        {
                            if (lista[0].Id.Equals(string.Empty))
                            {
                                MessageBox.Show("Usuario inexistente en esta empresa.", "Datos incorrectos.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.txtUsuario.Text = string.Empty;
                                this.txtContraseña.Text = string.Empty;
                                this.txtUsuario.Focus();
                            }
                            else
                            {
                                this.txtContraseña.Text = string.Empty;
                                this.txtContraseña.Focus();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario inexistente en esta empresa.", "Datos incorrectos.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.txtUsuario.Text = string.Empty;
                        this.txtContraseña.Text = string.Empty;
                        this.txtUsuario.Focus();
                    }
                }
            }
            else
            {
                MessageBox.Show("Faltan datos.", "Faltan datos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUsuario.Focus(); 
            }

        }
         
        private void GuardarEditarRegistro(int idEmpresa, int idUsuario, int idArea, bool esSesionIniciada)
        { 

            int idModulo = 0; // Aquí van a ir cuando sean distintos modulos.
            string nombreEquipo = this.nombreEsteEquipo; 
            if ((idEmpresa > 0) & (!string.IsNullOrEmpty(nombreEquipo)))
            {
                registros.IdEmpresa = idEmpresa;
                registros.IdArea = idArea;
                registros.IdUsuario = idUsuario;
                registros.IdModulo = idModulo;
                registros.NombreEquipo = nombreEquipo;
                registros.EsSesionIniciada = esSesionIniciada;
                bool tieneRegistro = registros.ValidarPorIdEmpresaYNombreEquipo();
                if ((tieneRegistro))
                {
                    if (esSesionIniciada)
                    {
                        registros.Editar();
                    }
                    else
                    {
                        registros.EditarSoloSesion();
                    }
                }
                else
                {
                    registros.Guardar();
                }
            }

        }

        private void PermitirAcceso(int idEmpresa, int idUsuario, bool abrirNotificaciones)
        {

            pnlIniciarSesion.Visible = false; 
            pnlOpciones.Visible = false; 
            pnlMenu.Visible = true; 
            Application.DoEvents();
            this.esInicioSesion = false;
            this.idEmpresaSesion = idEmpresa;
            this.idUsuarioSesion = idUsuario;
            GenerarMenu();
            ConsultarInformacionUsuario(this.idEmpresaSesion, this.idUsuarioSesion);
            ConsultarInformacionArea(datosUsuario.IdArea);
            CargarEncabezados();
            CargarTitulosEmpresa();
            if (abrirNotificaciones){
                CerrarPrograma("NotificacionesPantalla");
                System.Threading.Thread.Sleep(500);
                AbrirPrograma("NotificacionesPantalla", false);
            }

        }

        private void Centrar()
        {

            this.nombreEstePrograma = this.Text;
            this.CenterToScreen();
            //this.Opacity = .97; //Está bien perro esto.  
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

        }

        private void AsignarTooltips()
        {

            ToolTip tp = new ToolTip();
            tp.AutoPopDelay = 5000;
            tp.InitialDelay = 0;
            tp.ReshowDelay = 100;
            tp.ShowAlways = true;
            tp.SetToolTip(this.btnCambiarEmpresa, "Cambiar de Empresa.");
            tp.SetToolTip(this.btnEntrar, "Entrar.");
            tp.SetToolTip(this.btnMostrarOpciones, "Mostrar Opciones.");
            tp.SetToolTip(this.btnSalir, "Salir.");
            tp.SetToolTip(this.btnAyuda, "Ayuda.");

        }

        private void AsignarTooltips(string texto)
        {

            lblDescripcionTooltip.Text = texto;

        }

        private void AsignarFocos()
        {

            this.btnEntrar.Focus();            

        }

        private void ConfigurarConexionPrincipal() 
        {

            if (this.esDesarrollo)
            {
                baseDatos.CadenaConexionPrincipal = "C:\\Berry Agenda-Bitacora\\Principal.sdf";
            }
            else
            {
                string ruta = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                ruta = ruta.Replace("file:\\", null);
                baseDatos.CadenaConexionPrincipal = string.Format("{0}\\Principal.sdf", ruta); 
            }
            baseDatos.AbrirConexionPrincipal();
        
        }

        private void ConfigurarConexiones() 
        { 
            
            // Se obtiene si tiene parametros.  
	        string[] parametros = Environment.GetCommandLineArgs().ToArray();
	        if ((parametros.Length > 1)) 
            {
		        this.tieneParametros = true;
                pnlIniciarSesion.Visible = false;
                pnlOpciones.Visible = false;
                pnlMenu.Visible = true;  
                Application.DoEvents();
	        } 
            if (this.esDesarrollo)
            {
                baseDatos.CadenaConexionPrincipal = "C:\\Berry Agenda-Bitacora\\Principal.sdf"; 
                Logica.DatosEmpresaPrincipal.instanciaSql = "BERRY1-DELL\\SQLEXPRESS2008";
                Logica.DatosEmpresaPrincipal.usuarioSql = "AdminBerry"; 
                Logica.DatosEmpresaPrincipal.contrasenaSql = "@berry2017";
                Logica.DatosEmpresaPrincipal.idEmpresa = 1; 
                ConfigurarConexionPrincipal(); 
                //string[] activa = InstanciaSql().Split('|'); ' Es para obtener las instancias sql. Nunca se usó ya que no es lo correcto.
                //string servidor = activa[0];
                //string instancia = activa[1];
                //MessageBox.Show(servidor + " " + instancia);
            }
            else
            {
                //string ruta = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                //ruta = ruta.Replace("file:\\", null);
                //baseDatos.CadenaConexionInformacion = string.Format("{0}\\Informacion.mdf", ruta); 
                ConfigurarConexionPrincipal();
                if (this.tieneParametros)
                {
                    Logica.DatosEmpresaPrincipal.ObtenerParametrosInformacionEmpresa();
                    this.datosEmpresa.ObtenerParametrosInformacionEmpresa();
                    this.datosUsuario.ObtenerParametrosInformacionUsuario();
                    this.datosArea.ObtenerParametrosInformacionArea();
                }
                else
                {
                    ConsultarInformacionEmpresaPrincipalPredeterminada();
                }
            } 
            baseDatos.CadenaConexionInformacion = "Informacion";
            baseDatos.CadenaConexionCatalogo = "Catalogos";
            baseDatos.CadenaConexionAgenda = "Agenda";
            baseDatos.AbrirConexionInformacion();
            baseDatos.AbrirConexionCatalogo();
            baseDatos.AbrirConexionAgenda();
            //MessageBox.Show(Entidades.BaseDatos.conexionInformacion.ConnectionString);
            if (this.tieneParametros) // Se permite el acceso ya que con los parametros se sabe cuales son sus datos.
            {
                ConsultarInformacionEmpresa(datosEmpresa.Id);
                PermitirAcceso(datosEmpresa.Id, datosUsuario.Id, false);
            }
            else // Si no tiene parametros solo se carga normal.
            { 
                // Se pregunta si tiene sesión iniciada, para proceder a cargar su información si es así. 
                registros.IdEmpresa = Logica.DatosEmpresaPrincipal.idEmpresa;
                registros.NombreEquipo = this.nombreEsteEquipo; 
                bool tieneSesion = registros.ValidarSesionPorIdEmpresayNombreEquipo(); 
                if (tieneSesion)
                { 
                    // Se obtienen registros de lo que corresponda a esta empresa y este nombre de equipo.
                    ObtenerRegistroPorIdEmpresaYNombreEquipo();
                    PermitirAcceso(datosEmpresa.Id, datosUsuario.Id, false); 
                }
                else 
                { 
                    // Si no tiene sesión, se procede a cargar el programa normal, sin usuario ni area.
                    ConsultarInformacionEmpresa(Logica.DatosEmpresaPrincipal.idEmpresa); 
                }
            }

        }

        private void ObtenerRegistroPorIdEmpresaYNombreEquipo()
        {

            List<Entidades.Registros> lista = new List<Entidades.Registros>();
            registros.IdEmpresa = Logica.DatosEmpresaPrincipal.idEmpresa;
            registros.NombreEquipo = this.nombreEsteEquipo;
            lista = registros.ObtenerPorIdEmpresayNombreEquipo();
            ConsultarInformacionEmpresa(Logica.DatosEmpresaPrincipal.idEmpresa);
            if ((lista.Count > 0))
            {
                ConsultarInformacionUsuario(Logica.DatosEmpresaPrincipal.idEmpresa, lista[0].IdUsuario);
                ConsultarInformacionArea(lista[0].IdArea);
            }

        }

        public string InstanciaSql()
        {

            DataTable datos = SqlDataSourceEnumerator.Instance.GetDataSources();
            string valor = string.Empty; 
            string valor2 = string.Empty;
            if (datos.Rows.Count == 1)
            {
                valor = datos.Rows[0]["ServerName"].ToString();
                valor2 = datos.Rows[0]["InstanceName"].ToString();  
            }
            return valor +'|'+ valor2;

        }

        private void ConsultarInformacionEmpresaPrincipalPredeterminada()
        {
             
            List<Entidades.EmpresasPrincipal> lista = new List<Entidades.EmpresasPrincipal>();
            lista = empresasPrincipal.ObtenerPredeterminada();
            Logica.DatosEmpresaPrincipal.idEmpresa = Convert.ToInt32(lista[0].IdEmpresa);
            Logica.DatosEmpresaPrincipal.activa = Convert.ToBoolean(lista[0].Activa.ToString());
            Logica.DatosEmpresaPrincipal.instanciaSql = Convert.ToString(lista[0].InstanciaSql.ToString());
            Logica.DatosEmpresaPrincipal.rutaBd = lista[0].RutaBd.ToString();
            Logica.DatosEmpresaPrincipal.usuarioSql = lista[0].UsuarioSql.ToString();
            Logica.DatosEmpresaPrincipal.contrasenaSql = lista[0].ContrasenaSql.ToString();

        }

        private void ConsultarInformacionEmpresa()
        {

            string[] datos = empresas.ObtenerPredeterminada().Split('|');
            datosEmpresa.Id = Convert.ToInt32(datos[0]);
            datosEmpresa.Nombre = datos[1];
            datosEmpresa.Descripcion = datos[2];
            datosEmpresa.Domicilio = datos[3];
            datosEmpresa.Localidad = datos[4];
            datosEmpresa.Rfc = datos[5];
            datosEmpresa.Directorio = datos[6];
            datosEmpresa.Logo = datos[7];
            datosEmpresa.Activa = Convert.ToBoolean(datos[8]);
            datosEmpresa.Equipo = datos[9];

        }

        private void ConsultarInformacionEmpresa(int idEmpresa)
        {

            empresas.Id = idEmpresa;
            List<Entidades.Empresas> datos = new List<Entidades.Empresas>();
            datos = empresas.ObtenerPorId();
            datosEmpresa.Id = datos[0].Id;
            datosEmpresa.Nombre = datos[0].Nombre;
            datosEmpresa.Descripcion = datos[0].Descripcion;
            datosEmpresa.Domicilio = datos[0].Domicilio;
            datosEmpresa.Localidad = datos[0].Localidad;
            datosEmpresa.Rfc = datos[0].Rfc;
            datosEmpresa.Directorio = datos[0].Directorio;
            datosEmpresa.Logo = datos[0].Logo;
            datosEmpresa.Activa = datos[0].Activa;
            datosEmpresa.Equipo = datos[0].Equipo;

        }

        public void ConsultarInformacionUsuario(int idEmpresa, int idUsuario)
        {

            usuarios.IdEmpresa = idEmpresa;
            usuarios.Id = idUsuario;
            List<Entidades.Usuarios> datos = new List<Entidades.Usuarios>();
            datos = usuarios.ObtenerListaPorId();
            datosUsuario.Id = datos[0].Id;
            datosUsuario.Nombre = datos[0].Nombre;
            datosUsuario.Contrasena = datos[0].Contrasena;
            datosUsuario.Nivel = datos[0].Nivel;
            datosUsuario.AccesoTotal = datos[0].AccesoTotal;
            datosUsuario.IdArea = datos[0].IdArea;

        } 

        public void ConsultarInformacionArea(int idArea)
        {

            areas.Id = idArea;
            List<Entidades.Areas> datos = new List<Entidades.Areas>();
            datos = areas.ObtenerListadoPorId();
            datosArea.Id = datos[0].Id;
            datosArea.Nombre = datos[0].Nombre;
            datosArea.Clave = datos[0].Clave;

        }

        private void EventoRatonEncimaCuadro(object sender)
        {

            string nombre = ((Panel)sender).Name;
            Panel objetoPanel = new Panel();
            objetoPanel = (Panel)(pnlMenu.Controls[nombre]);
            objetoPanel.BorderStyle = BorderStyle.Fixed3D;
            this.colorCuadroOriginal = objetoPanel.BackColor;
            objetoPanel.BackColor = ControlPaint.Dark(objetoPanel.BackColor); 

        }

        private void EventoRatonDejandoCuadro(object sender)
        {
             
            string nombre = ((Panel)sender).Name;
            Panel objetoPanel = new Panel();
            objetoPanel = (Panel)(pnlMenu.Controls[nombre]);
            objetoPanel.BorderStyle = BorderStyle.FixedSingle;
            objetoPanel.BackColor = this.colorCuadroOriginal; 

        }

        private void ValidarAbrirPrograma(object sender)
        {

            this.Cursor = Cursors.WaitCursor;
            string nombre = ((Panel)sender).Name;
            string[] nombres = nombre.Split('_');
            int idModulo = Convert.ToInt32(nombres[1]);
            int idPrograma = Convert.ToInt32(nombres[2]);
            bool bloqueado = ValidarAccesso(idModulo, idPrograma);
            if (bloqueado)
            {
                Panel objetoPanel = new Panel();
                objetoPanel = (Panel)(pnlMenu.Controls[nombre]);
                objetoPanel.Enabled = false;
                MessageBox.Show("No tienes permisos para acceder a este programa.", "No permitido.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                List<Entidades.Modulos> lista = new List<Entidades.Modulos>();
                modulos.Id = this.idModuloSesion;
                lista = modulos.ObtenerListadoPorId();
                string nombreModulo = lista[0].Prefijo;
                string nombrePrograma = nombreModulo + idPrograma.ToString().PadLeft(2, '0');
                this.nombreProgramaAbierto = nombrePrograma;
                this.estaAbriendoPrograma = true;
                AbrirPrograma(nombrePrograma, true);
            }
            this.Cursor = Cursors.Default;

        }

        private void GenerarMenu()
        {

            // Se obtiene información de los programas.
            Entidades.Programas programas = new Entidades.Programas();
            List<Entidades.Programas> lista = new List<Entidades.Programas>();
            programas.IdEmpresa = empresas.Id;
            lista = programas.ObtenerListadoDeProgramas();
            // Se quita la imagen de fondo del programa.
            //pnlContenido.BackgroundImage = null; Application.DoEvents();
            //pnlContenido.BackColor = Color.White; //Color.FromArgb(240, 240, 240); Application.DoEvents();
            // Se calculan los controles necesarios.
            int alto = 190; int ancho = 380; // Los tamaños de los controles.
            int posicionY = 0; int posicionX = 0; // Las posiciones donde inician los controles.
            int margen = 5; // Margen de espacio hacia los lados
            double cantidadEnAltura = Convert.ToDouble((pnlMenu.Height)) / (alto + margen + 10); // Tamaño de menu entre alto de paneles mas margenes mas 10 de la barra inferior.
            cantidadEnAltura = Math.Floor(cantidadEnAltura); // Es la cantidad de controles que caben verticalmente.    
            int cantidad = lista.Count; // Cantidad de programas configurados obtenidos desde bd. 
            int indiceVariable = 0; // Se utiliza para controlar la cantidad de opciones verticales.
            for (int indice = 1; indice <= cantidad; indice++) // Crea controles.
            {
                // Se crean los paneles.
                Panel cuadro = new Panel();
                cuadro.Size = new Size(ancho, alto);
                cuadro.Top = posicionY;
                cuadro.Left = posicionX;
                cuadro.BorderStyle = BorderStyle.FixedSingle;
                cuadro.BackColor = ObtenerColorAleatorio();
                System.Threading.Thread.Sleep(70);
                cuadro.Name = "pnlPrograma_1_" + lista[indice-1].Id; // El 1 está fijo, pero corresponde al modulo.
                cuadro.Click += new System.EventHandler(cuadro_Click); // Se genera el evento desde codigo. 
                cuadro.MouseEnter += new System.EventHandler(cuadro_MouseEnter); // Se genera el evento desde codigo.
                cuadro.MouseLeave += new System.EventHandler(cuadro_MouseLeave); // Se genera el evento desde codigo.
                cuadro.Cursor = Cursors.Hand;
                pnlMenu.Controls.Add(cuadro); Application.DoEvents();
                // Se crean las etiquetas de los nombres de los paneles.
                Label etiquetaNombre = new Label();
                etiquetaNombre.Width = ancho; 
                if (lista[indice - 1].Nombre.ToString().Length > 24)
                {
                    etiquetaNombre.Top = cuadro.Height - etiquetaNombre.Height - 45;
                    etiquetaNombre.Height = 80;
                }
                else
                { 
                    etiquetaNombre.Top = cuadro.Height - etiquetaNombre.Height - 15;
                    etiquetaNombre.Height = 40;
                } 
                etiquetaNombre.BorderStyle = BorderStyle.None;
                etiquetaNombre.Left = 0;
                etiquetaNombre.Text = lista[indice-1].Nombre.ToString();
                etiquetaNombre.ForeColor = Color.White;
                etiquetaNombre.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Regular);
                etiquetaNombre.Click += new System.EventHandler(etiquetaNombre_Click); // Se genera el evento desde codigo.
                etiquetaNombre.MouseEnter += new System.EventHandler(etiquetaNombre_MouseEnter); // Se genera el evento desde codigo.
                etiquetaNombre.MouseLeave += new System.EventHandler(etiquetaNombre_MouseLeave); // Se genera el evento desde codigo.
                etiquetaNombre.Cursor = Cursors.Hand;
                cuadro.Controls.Add(etiquetaNombre); Application.DoEvents();
                //// Se crean las etiquetas de las iniciales de los paneles.
                //Label etiquetaIniciales = new Label();
                //etiquetaIniciales.Width = ancho;
                //etiquetaIniciales.Top = 0;
                //etiquetaIniciales.Height = 45;
                ////etiquetaIniciales.BackColor = Color.Black; 
                //etiquetaIniciales.BorderStyle = BorderStyle.None;
                //etiquetaIniciales.Left = 0; 
                //string[] listadoNombres = lista[indice - 1].Nombre.ToString().Split(' ');
                //string iniciales = string.Empty;
                //foreach (string s in listadoNombres)
                //{
                //    iniciales += (s.Substring(0, 1) + "." + " ").ToUpper();
                //} 
                //etiquetaIniciales.Text = iniciales;
                //etiquetaIniciales.ForeColor = Color.White;
                //etiquetaIniciales.Font = new Font("Microsoft Sans Serif", 30, FontStyle.Regular);
                //cuadro.Controls.Add(etiquetaIniciales); Application.DoEvents();
                // Se calculan y se distribuyen de acuerdo al tamaño del panel del menu.
                indiceVariable += 1;
                if (indiceVariable < Convert.ToInt32(cantidadEnAltura))
                {
                    posicionY += alto + margen;
                }
                else
                {
                    indiceVariable = 0;
                    posicionX += ancho + margen;
                    posicionY = 0;
                } 
            }

        }
        
        private Color ObtenerColorAleatorio() 
        {

            Random aleatorio = new Random();
            Color opcionColor = new Color();
            //opcionColor = Color.FromArgb(aleatorio.Next(180), aleatorio.Next(180), aleatorio.Next(180));
            KnownColor[] nombres = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            KnownColor nombreAleatorio = nombres[aleatorio.Next(nombres.Length)];
            opcionColor = Color.FromKnownColor(nombreAleatorio); 
            Color colorOscuro = ControlPaint.Dark(opcionColor); // Se oscurece.
            return colorOscuro;

        }

        private void CargarTitulosEmpresa()
        {

            this.Text = this.nombreEstePrograma + ": " +  datosEmpresa.Nombre;

        }

        private void CargarEncabezados()
        { 

            lblEncabezadoPrograma.Text = "Programa: " + this.nombreEstePrograma;
            lblEncabezadoEmpresa.Text = "Empresa: " + datosEmpresa.Nombre;
            lblEncabezadoUsuario.Text = "Usuario: " + datosUsuario.Nombre;
            lblEncabezadoArea.Text = "Area: " + datosArea.Nombre;

        }

        private void CerrarPrograma(string nombre)
        {

            Process[] myProcesses;
            myProcesses = Process.GetProcessesByName(nombre);
            foreach (Process myProcess in myProcesses)
            { 
                myProcess.Kill();
            }

        }

        private void AbrirPrograma(string nombre, bool salir)
        {

            //this.SuspendLayout();
            if (this.esDesarrollo)
            {
                return;
            }
            ejecutarPrograma.UseShellExecute = true;
            ejecutarPrograma.FileName = nombre + ".exe";
            ejecutarPrograma.WorkingDirectory = Application.StartupPath;
            ejecutarPrograma.Arguments = Logica.DatosEmpresaPrincipal.idEmpresa.ToString().Trim().Replace(" ", "|") + " " + Logica.DatosEmpresaPrincipal.activa.ToString().Trim().Replace(" ", "|") + " " + Logica.DatosEmpresaPrincipal.instanciaSql.ToString().Trim().Replace(" ", "|") + " " + Logica.DatosEmpresaPrincipal.rutaBd.ToString().Trim().Replace(" ", "|") + " " + Logica.DatosEmpresaPrincipal.usuarioSql.ToString().Trim().Replace(" ", "|") + " " + Logica.DatosEmpresaPrincipal.contrasenaSql.ToString().Trim().Replace(" ", "|") + " " + "Aquí terminan los de empresa principal, indice 7 ;)".Replace(" ", "|") + " " + datosEmpresa.Id.ToString().Trim().Replace(" ", "|") + " " + datosEmpresa.Nombre.Trim().Replace(" ", "|") + " " + datosEmpresa.Descripcion.Trim().Replace(" ", "|") + " " + datosEmpresa.Domicilio.Trim().Replace(" ", "|") + " " + datosEmpresa.Localidad.Trim().Replace(" ", "|") + " " + datosEmpresa.Rfc.Trim().Replace(" ", "|") + " " + datosEmpresa.Directorio.Trim().Replace(" ", "|") + " " + datosEmpresa.Logo.Trim().Replace(" ", "|") + " " + datosEmpresa.Activa.ToString().Trim().Replace(" ", "|") + " " + datosEmpresa.Equipo.Trim().Replace(" ", "|") + " " + "Aquí terminan los de empresa, indice 18 ;)".Replace(" ", "|") + " " + datosUsuario.Id.ToString().Trim().Replace(" ", "|") + " " + datosUsuario.Nombre.Trim().Replace(" ", "|") + " " + datosUsuario.Contrasena.Trim().Replace(" ", "|") + " " + datosUsuario.Nivel.ToString().Trim().Replace(" ", "|") + " " + datosUsuario.AccesoTotal.ToString().Trim().Replace(" ", "|") + " " + datosUsuario.IdArea.ToString().Trim().Replace(" ", "|") + " " + "Aquí terminan los de usuario, indice 25 ;)".Replace(" ", "|") + " " + datosArea.Id.ToString().Trim().Replace(" ", "|") + " " + datosArea.Nombre.ToString().Trim().Replace(" ", "|") + " " + datosArea.Clave.ToString().Trim().Replace(" ", "|") + " " + "Aquí terminan los de area, indice 29 ;)".Replace(" ", "|");
            try
            {
                var proceso = Process.Start(ejecutarPrograma);
                proceso.WaitForInputIdle(); 
                //this.ResumeLayout();
                if (salir)
                { 
                    if (this.ShowIcon)
                    {
                        this.ShowIcon = false;
                    } 
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede abrir el programa principal en la ruta : " + ejecutarPrograma.WorkingDirectory + "\\" + nombre + Environment.NewLine + Environment.NewLine + ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion
         
    }
}