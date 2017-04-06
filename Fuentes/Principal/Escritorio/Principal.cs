using System;
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
        public Logica.DatosEmpresa datosEmpresa = new Logica.DatosEmpresa();
        Logica.DatosUsuario datosUsuario = new Logica.DatosUsuario();
        Logica.DatosArea datosArea = new Logica.DatosArea();
        ProcessStartInfo ejecutarProgramaPrincipal = new ProcessStartInfo();
        public int numeroEmpresa; 
        public bool tieneParametros = false;
        public bool esInicioSesion = true;
        public int idEmpresaSesion = 0; public int idUsuarioSesion = 0; public int idModuloSesion = 1;
        public string nombrePrograma = string.Empty;

        public bool esPrueba = false;

        #region Eventos

        public Principal()
        {
            InitializeComponent();
        }
        
        private void Principal_Load(object sender, EventArgs e)
        {

            Centrar();
            AsignarTooltips();
            AsignarFocos();
            ConfigurarConexiones(); 
            CargarEncabezados();
            CargarTitulosEmpresa();

        }
        
        private void cuadro_Click(object sender, EventArgs e)
        {

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
                MessageBox.Show("No tienes permisos para acceder a este programa.", "No permitido.", MessageBoxButtons.OK);
            }
            else
            {
                List<Entidades.Modulos> lista = new List<Entidades.Modulos>();
                modulos.Id = this.idModuloSesion;
                lista = modulos.ObtenerListadoPorId();
                string nombreModulo = lista[0].Prefijo; 
                string nombrePrograma = nombreModulo + idPrograma.ToString().PadLeft(2, '0');  
                AbrirPrograma(nombrePrograma, true);
            }
             
        }

        private void cuadro_MouseHover(object sender, EventArgs e)
        {

            this.Cursor = Cursors.Hand;
            string nombre = ((Panel)sender).Name;
            Panel objetoPanel = new Panel();
            objetoPanel = (Panel)(pnlMenu.Controls[nombre]);
            objetoPanel.BorderStyle = BorderStyle.Fixed3D;
            
        }

        private void cuadro_MouseLeave(object sender, EventArgs e)
        {

            this.Cursor = Cursors.Default;
            string nombre = ((Panel)sender).Name;
            Panel objetoPanel = new Panel();
            objetoPanel = (Panel)(pnlMenu.Controls[nombre]);
            objetoPanel.BorderStyle = BorderStyle.None;

        }

        private void btnCambiarEmpresa_Click(object sender, EventArgs e)
        {

            this.Hide();            
            new AdministrarEmpresas().Show();

        }

        private void Principal_Shown(object sender, EventArgs e)
        {

            this.txtUsuario.Focus();

        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
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
                txtContraseña.Text = string.Empty;       
                txtUsuario.Text = string.Empty;
                txtUsuario.Focus();
                this.esInicioSesion = true;
            }

        }

        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {

            Application.ExitThread();
            Application.Exit();

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

        #endregion

        #region Metodos

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
            
            // Falta agregar lo de la empresa.
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
                    string[] datos = usuarios.ObtenerPorNombre().Split('|');
                    if (this.txtContraseña.Text.Equals(datos[3]))
                    {
                        PermitirAcceso(Convert.ToInt32(datos[0]), Convert.ToInt32(datos[1]), true);
                    }
                    else
                    {
                        if (datos[1].Equals(string.Empty))
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
            }
            else
            {
                MessageBox.Show("Faltan datos.", "Faltan datos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUsuario.Focus(); 
            }

        }

        private void PermitirAcceso(int idEmpresa, int idUsuario, bool abrirNotificaciones)
        {

            pnlIniciarSesion.Visible = false; Application.DoEvents();
            pnlMenu.Visible = true; Application.DoEvents();
            this.esInicioSesion = false;
            this.idEmpresaSesion = idEmpresa; //Convert.ToInt32(datos[0]);
            this.idUsuarioSesion = idUsuario; //Convert.ToInt32(datos[1]);
            GenerarMenu();
            ConsultarInformacionUsuario(this.idEmpresaSesion, this.idUsuarioSesion);
            ConsultarInformacionArea(datosUsuario.IdArea);
            CargarEncabezados();
            CargarTitulosEmpresa();
            if (abrirNotificaciones){
                CerrarPrograma("NotificacionesPantalla");
                System.Threading.Thread.Sleep(1000);
                AbrirPrograma("NotificacionesPantalla", false);
            }

        }

        private void Centrar()
        {

            this.nombrePrograma = this.Text;
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

            if (this.esPrueba)
            {
                baseDatos.CadenaConexionPrincipal = "C:\\Berry-Bitacora\\Principal.sdf";
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
	        } 
            if (this.esPrueba)
            {
                baseDatos.CadenaConexionPrincipal = "C:\\Berry-Bitacora\\Principal.sdf";
                Logica.DatosEmpresaPrincipal.instanciaSql = "ANDREW-MAC\\SQLEXPRESS";
                Logica.DatosEmpresaPrincipal.usuarioSql = "AdminBerry";
                Logica.DatosEmpresaPrincipal.contrasenaSql = "@berry";
                Logica.DatosEmpresaPrincipal.idEmpresa = 1;
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
                if (this.tieneParametros)
                {
                    Logica.DatosEmpresaPrincipal.ObtenerParametrosInformacionEmpresa();
                    this.datosEmpresa.ObtenerParametrosInformacionEmpresa();
                    this.datosUsuario.ObtenerParametrosInformacionUsuario();
                    this.datosArea.ObtenerParametrosInformacionArea();
                }
                else
                {
                    ConfigurarConexionPrincipal();
                    ConsultarInformacionEmpresaPrincipalPredeterminada();
                }
            } 
            baseDatos.CadenaConexionInformacion = "Informacion";
            baseDatos.CadenaConexionCatalogo = "Catalogos";
            baseDatos.AbrirConexionInformacion();
            baseDatos.AbrirConexionCatalogo();
            if (this.tieneParametros)
            {
                ConsultarInformacionEmpresa(datosEmpresa.Id);
                PermitirAcceso(datosEmpresa.Id, datosUsuario.Id, false);
            }
            else
            { 
                ConsultarInformacionEmpresa(Logica.DatosEmpresaPrincipal.idEmpresa);
                //ConsultarInformacionUsuario(this.idEmpresaSesion, this.idUsuarioSesion);
                //ConsultarInformacionArea(datosUsuario.IdArea);
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
            datos = areas.ObtenerListaPorId();
            datosArea.Id = datos[0].Id;
            datosArea.Nombre = datos[0].Nombre;
            datosArea.Clave = datos[0].Clave;

        }

        //private void ConsultarInformacionArea()
        //{

        //    areas.Id = datosUsuario.IdArea;
        //    string[] datos = areas.ObtenerPorId().Split('|');
        //    datosArea.Id = Convert.ToInt32(datos[0]);
        //    datosArea.Nombre = datos[1];
        //    datosArea.Clave = datos[2];

        //}

        //private void ConsultarInformacionUsuario()
        //{

        //    usuarios.Id = this.idUsuarioSesion;
        //    string[] datos = usuarios.ObtenerPorId().Split('|');
        //    datosUsuario.IdEmpresa = Convert.ToInt32(datos[0]);
        //    datosUsuario.Id = Convert.ToInt32(datos[1]);
        //    datosUsuario.Nombre = datos[2];
        //    datosUsuario.Contrasena = datos[3];
        //    datosUsuario.Nivel = Convert.ToInt32(datos[4]);
        //    datosUsuario.AccesoTotal = Convert.ToBoolean(datos[5]);
        //    datosUsuario.IdArea = Convert.ToInt32(datos[6]);

        //}

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
                System.Threading.Thread.Sleep(60);
                //cuadro.BackColor = ControlPaint.Dark(cuadro.BackColor); 
                cuadro.Name = "pnlPrograma_1_" + lista[indice-1].Id; // El 1 está fijo, pero corresponde al modulo.
                cuadro.Click += new System.EventHandler(cuadro_Click); // Se genera el evento desde codigo.
                cuadro.MouseHover += new System.EventHandler(cuadro_MouseHover); // Se genera el evento desde codigo.
                cuadro.MouseLeave += new System.EventHandler(cuadro_MouseLeave); // Se genera el evento desde codigo.
                pnlMenu.Controls.Add(cuadro); Application.DoEvents();
                // Se crean las etiquetas de los paneles.
                Label etiqueta = new Label();
                etiqueta.Width = ancho;
                etiqueta.Top = cuadro.Height - etiqueta.Height - 15;
                //etiqueta.BackColor = Color.Black;
                etiqueta.Height = 40;
                etiqueta.Left = 0;
                etiqueta.Text = lista[indice-1].Nombre.ToString(); //"idEmpresa " + indice; 
                etiqueta.ForeColor = Color.White;
                etiqueta.Font = new Font( "Microsoft Sans Serif", 20, FontStyle.Regular);
                cuadro.Controls.Add(etiqueta); Application.DoEvents();
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
            Color colorOscuro = ControlPaint.Dark(opcionColor);                        
            return colorOscuro;

        }

        private void CargarTitulosEmpresa()
        {

            this.Text = this.nombrePrograma + ": " +  datosEmpresa.Nombre;

        }

        private void CargarEncabezados()
        { 

            lblEncabezadoPrograma.Text = "Programa: " + this.nombrePrograma;
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
             
            ejecutarProgramaPrincipal.UseShellExecute = true;
            ejecutarProgramaPrincipal.FileName = nombre + ".exe";
            ejecutarProgramaPrincipal.WorkingDirectory = Directory.GetCurrentDirectory();
            ejecutarProgramaPrincipal.Arguments = Logica.DatosEmpresaPrincipal.idEmpresa.ToString().Trim().Replace(" ", "|") + " " + Logica.DatosEmpresaPrincipal.activa.ToString().Trim().Replace(" ", "|") + " " + Logica.DatosEmpresaPrincipal.instanciaSql.ToString().Trim().Replace(" ", "|") + " " + Logica.DatosEmpresaPrincipal.rutaBd.ToString().Trim().Replace(" ", "|") + " " + Logica.DatosEmpresaPrincipal.usuarioSql.ToString().Trim().Replace(" ", "|") + " " + Logica.DatosEmpresaPrincipal.contrasenaSql.ToString().Trim().Replace(" ", "|") + " " + "Aquí terminan los de empresa principal, indice 7 ;)".Replace(" ", "|") + " " + datosEmpresa.Id.ToString().Trim().Replace(" ", "|") + " " + datosEmpresa.Nombre.Trim().Replace(" ", "|") + " " + datosEmpresa.Descripcion.Trim().Replace(" ", "|") + " " + datosEmpresa.Domicilio.Trim().Replace(" ", "|") + " " + datosEmpresa.Localidad.Trim().Replace(" ", "|") + " " + datosEmpresa.Rfc.Trim().Replace(" ", "|") + " " + datosEmpresa.Directorio.Trim().Replace(" ", "|") + " " + datosEmpresa.Logo.Trim().Replace(" ", "|") + " " + datosEmpresa.Activa.ToString().Trim().Replace(" ", "|") + " " + datosEmpresa.Equipo.Trim().Replace(" ", "|") + " " + "Aquí terminan los de empresa, indice 18 ;)".Replace(" ", "|") + " " + datosUsuario.Id.ToString().Trim().Replace(" ", "|") + " " + datosUsuario.Nombre.Trim().Replace(" ", "|") + " " + datosUsuario.Contrasena.Trim().Replace(" ", "|") + " " + datosUsuario.Nivel.ToString().Trim().Replace(" ", "|") + " " + datosUsuario.AccesoTotal.ToString().Trim().Replace(" ", "|") + " " + datosUsuario.IdArea.ToString().Trim().Replace(" ", "|") + " " + "Aquí terminan los de usuario, indice 25 ;)".Replace(" ", "|") + " " + datosArea.Id.ToString().Trim().Replace(" ", "|") + " " + datosArea.Nombre.ToString().Trim().Replace(" ", "|") + " " + datosArea.Clave.ToString().Trim().Replace(" ", "|") + " " + "Aquí terminan los de area, indice 29 ;)".Replace(" ", "|");
            try
            {
                Process.Start(ejecutarProgramaPrincipal);
                if (salir)
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede abrir el programa principal en la ruta : " + ejecutarProgramaPrincipal.WorkingDirectory + "\\" + nombre + Environment.NewLine + Environment.NewLine + ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion

    }
}