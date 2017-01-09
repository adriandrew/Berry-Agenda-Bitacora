using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Escritorio
{
    public partial class PanelControl : Form
    {

        FarPoint.Win.Spread.CellType.TextCellType tipoTexto = new FarPoint.Win.Spread.CellType.TextCellType();
        FarPoint.Win.Spread.CellType.TextCellType tipoTextoContrasena = new FarPoint.Win.Spread.CellType.TextCellType();
        FarPoint.Win.Spread.CellType.NumberCellType tipoEntero = new FarPoint.Win.Spread.CellType.NumberCellType();
        FarPoint.Win.Spread.CellType.NumberCellType tipoDoble = new FarPoint.Win.Spread.CellType.NumberCellType();
        FarPoint.Win.Spread.CellType.PercentCellType tipoPorcentaje = new FarPoint.Win.Spread.CellType.PercentCellType();
        FarPoint.Win.Spread.CellType.DateTimeCellType tipoHora = new FarPoint.Win.Spread.CellType.DateTimeCellType();
        FarPoint.Win.Spread.CellType.CheckBoxCellType tipoBooleano = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
        
        Entidades.Empresas empresas = new Entidades.Empresas();
        Entidades.Usuarios usuarios = new Entidades.Usuarios();
        Entidades.Programas programas = new Entidades.Programas();
        Entidades.BloqueoUsuarios bloqueoUsuarios = new Entidades.BloqueoUsuarios();

        #region Eventos

        public PanelControl()
        {
            InitializeComponent();
        }

        private void PanelControl_Load(object sender, EventArgs e)
        {

            Centrar();
            ReiniciarControles();
            ControlarSpread(spAdministrar);

        }
       
        private void rbtnUsuarios_CheckedChanged(object sender, EventArgs e)
        {

            if (rbtnUsuarios.Checked)
            {
                CargarEmpresasCombobox();
                CargarUsuarios();
                FormatearSpread();
                FormatearSpreadUsuarios();
            }

        }
        
        private void PanelControl_Shown(object sender, EventArgs e)
        {

            ReiniciarControles();

        }
         
        private void spAdministrar_KeyDown(object sender, KeyEventArgs e)
        {

            // Eliminar.
            if (e.KeyData == Keys.F11)
            {
                if (MessageBox.Show("Confirmas que deseas eliminar el registro seleccionado?", "Confirmacion.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int fila = spAdministrar.ActiveSheet.ActiveRowIndex;
                    if (rbtnUsuarios.Checked)
                    {
                        string empresa = cbEmpresas.SelectedValue.ToString();
                        string numero = spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["numero"].Index].Text;
                        if (!string.IsNullOrEmpty(empresa) && !string.IsNullOrEmpty(numero))
                        {
                            usuarios.IdEmpresa = Logica.Funciones.ValidarNumero(empresa);
                            usuarios.Id = Logica.Funciones.ValidarNumero(numero);
                            usuarios.Eliminar();
                        }
                    }
                    else if (rbtnEmpresas.Checked)
                    {
                        string numero = spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["numero"].Index].Text;
                        if (!string.IsNullOrEmpty(numero))
                        {                            
                            empresas.Id = Logica.Funciones.ValidarNumero(numero);
                            empresas.Eliminar();
                        }
                    }
                }
            }
            // Guardar o editar.
            else if (e.KeyData == Keys.Enter)
            {
                if (spAdministrar.ActiveSheet.ActiveColumnIndex == spAdministrar.ActiveSheet.Columns.Count - 1)
                {
                    spAdministrar.ActiveSheet.AddRows(spAdministrar.ActiveSheet.Rows.Count, 1);
                    //int fila = spAdministrar.ActiveSheet.ActiveRowIndex;
                    if (rbtnUsuarios.Checked)
                    {
                        GuardarEditarUsuarios();
                    }
                    else if (rbtnEmpresas.Checked)
                    {
                        GuardarEditarEmpresas();
                    }
                }
               
            }

        }

        private void GuardarEditarUsuarios() 
        {

            int fila = spAdministrar.ActiveSheet.ActiveRowIndex;
            string empresa = cbEmpresas.SelectedValue.ToString();
            string numero = spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["numero"].Index].Text;
            string nombre = spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["nombre"].Index].Text;
            string contrasena = spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["contrasena"].Index].Value.ToString();
            string nivel = spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["nivel"].Index].Text;
            bool accesoTotal = Convert.ToBoolean(spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["accesoTotal"].Index].Value);
            string idArea = spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["idArea"].Index].Text;
            if (!string.IsNullOrEmpty(empresa) && !string.IsNullOrEmpty(numero) && !string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(contrasena) && !string.IsNullOrEmpty(nivel) && !string.IsNullOrEmpty(idArea))
            {
                usuarios.IdEmpresa = Convert.ToInt32(empresa);
                usuarios.Id = Convert.ToInt32(numero);
                bool tieneUsuarios = usuarios.ValidarPorNumero();
                usuarios.Nombre = nombre;
                usuarios.Contrasena = contrasena;
                usuarios.Nivel = Convert.ToInt32(nivel);
                usuarios.AccesoTotal = accesoTotal;
                usuarios.IdArea = Convert.ToInt32(idArea);
                if (!tieneUsuarios)
                {
                    usuarios.Guardar();
                }
                else
                {
                    usuarios.Editar();
                }
            }

        }

        private void GuardarBloqueoUsuarios() 
        {

            int fila = spAdministrar.ActiveSheet.ActiveRowIndex;
            int filaProgramas = spProgramas.ActiveSheet.ActiveRowIndex;
            int idEmpresa = Convert.ToInt32(cbEmpresas.SelectedValue.ToString());
            int idUsuario = Convert.ToInt32(spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["numero"].Index].Text);
            int idModulo = Convert.ToInt32(spProgramas.ActiveSheet.Cells[filaProgramas, spProgramas.ActiveSheet.Columns["idModulo"].Index].Text);
            int idPrograma = Convert.ToInt32(spProgramas.ActiveSheet.Cells[filaProgramas, spProgramas.ActiveSheet.Columns["id"].Index].Text);
            int idSubPrograma = 0;
            if ((idEmpresa>0) && (idUsuario>0))
            {
                bloqueoUsuarios.IdEmpresa = idEmpresa;
                bloqueoUsuarios.IdUsuario = idUsuario;
                bloqueoUsuarios.IdModulo = idModulo;
                bloqueoUsuarios.IdPrograma = idPrograma;
                bloqueoUsuarios.IdSubPrograma = idSubPrograma;
                //bool tieneUsuarios = usuarios.ValidarPorNumero();  
                //if (!tieneUsuarios)
                //{
                bloqueoUsuarios.Guardar();
                //}
                //else
                //{
                //    usuarios.Editar();
                //}
            }

        }

        private void GuardarEditarEmpresas()
        {

            int fila = spAdministrar.ActiveSheet.ActiveRowIndex;
            string id = spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["numero"].Index].Text;
            string nombre = spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["nombre"].Index].Text;
            string descripcion = spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["descripcion"].Index].Text;
            string domicilio = spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["domicilio"].Index].Text;
            string localidad = spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["localidad"].Index].Text;
            string rfc = spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["rfc"].Index].Text;
            string directorio = spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["directorio"].Index].Text;
            string logo = spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["logo"].Index].Text;
            bool activa = Convert.ToBoolean(spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["activa"].Index].Value);
            string equipo = spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["equipo"].Index].Text;
            if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(descripcion) && !string.IsNullOrEmpty(domicilio) && !string.IsNullOrEmpty(rfc) && !string.IsNullOrEmpty(directorio) && !string.IsNullOrEmpty(logo))
            {
                empresas.Id = Convert.ToInt32(id);
                bool tieneEmpresas = empresas.ValidarPorNumero();
                empresas.Nombre = nombre;
                empresas.Descripcion = descripcion;
                empresas.Domicilio = domicilio;
                empresas.Localidad = localidad;
                empresas.Rfc = rfc;
                empresas.Directorio = directorio;
                empresas.Logo = logo;
                empresas.Activa = activa;
                empresas.Equipo = equipo;
                if (!tieneEmpresas)
                {
                    empresas.Guardar();
                }
                else
                {
                    empresas.Editar();
                }
            }

        }

        private void EliminarBloqueoUsuarios()
        {

            int fila = spProgramas.ActiveSheet.ActiveRowIndex;
            int idEmpresa = Convert.ToInt32(cbEmpresas.SelectedValue.ToString());
            int idUsuario = Convert.ToInt32(spProgramas.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["numero"].Index].Text);
            int idModulo = Convert.ToInt32(spProgramas.ActiveSheet.Cells[fila, spProgramas.ActiveSheet.Columns["idModulo"].Index].Text);
            int idPrograma = Convert.ToInt32(spProgramas.ActiveSheet.Cells[fila, spProgramas.ActiveSheet.Columns["id"].Index].Text);
            int idSubPrograma = 0;
            if ((idEmpresa>0) && (idUsuario>0))
            {
                bloqueoUsuarios.IdEmpresa = idEmpresa;
                bloqueoUsuarios.IdUsuario = idUsuario;
                bloqueoUsuarios.IdModulo = idModulo;
                bloqueoUsuarios.IdPrograma = idPrograma;
                bloqueoUsuarios.IdSubPrograma = idSubPrograma;
                bloqueoUsuarios.Eliminar();
            }

        }

        private void PanelControl_FormClosed(object sender, FormClosedEventArgs e)
        {

            new Principal().Show();

        }

        private void rbtnEmpresas_CheckedChanged(object sender, EventArgs e)
        {
            
            if (rbtnEmpresas.Checked)
            {
                CargarEmpresasSpread();
                FormatearSpread();
                FormatearSpreadEmpresas();               
            }

        }

        private void cbEmpresas_SelectedIndexChanged(object sender, EventArgs e)
        {

            CargarUsuarios();
            FormatearSpread();
            FormatearSpreadUsuarios();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

            this.Dispose();
            new Principal().Show();            

        }

        private void spAdministrar_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {

            if (rbtnUsuarios.Checked)
            {
                //if (spAdministrar.ActiveSheet.ActiveColumnIndex == spAdministrar.ActiveSheet.Columns["nivel"].Index)
                //{
                    int fila = e.Row;
                    spAdministrar.ActiveSheet.ActiveRowIndex = fila;
                    int valorCelda = Convert.ToInt32(spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["nivel"].Index].Value);
                    FormatearSpread();
                    if (valorCelda == 1) // Nivel de bloqueo de los modulos. // TODO. Pendiente.
                    {

                    }
                    else if (valorCelda == 2) // Nivel de bloqueo de los programas.
                    {
                        spProgramas.Visible = true;
                        spSubProgramas.Visible = false;
                        spAdministrar.Height = ((pnlContenido.Height - pnlPie.Height) / 2) - 10;
                        spProgramas.Top = spAdministrar.Height + 20;
                        spProgramas.Height = spAdministrar.Height;
                        spProgramas.Width = spAdministrar.Width;
                        CargarProgramas();
                        FormatearSpreadProgramas();
                    }
                    else if (valorCelda == 3) // Nivel de bloqueo de los subprogramas. TODO. Pendiente.
                    {
                        //spProgramas.Visible = true;
                        //spSubProgramas.Visible = true;
                    }
                //}
            }

        }
         
        private void spProgramas_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            
            if (rbtnUsuarios.Checked)
            {
                int fila = e.Row;
                spProgramas.ActiveSheet.ActiveRowIndex = fila; Application.DoEvents();
                bool valorCelda = Convert.ToBoolean(spProgramas.ActiveSheet.Cells[fila, spProgramas.ActiveSheet.Columns["estatus"].Index].Value);
                valorCelda = ((valorCelda == true) ? false : true);
                if (valorCelda) // Agrega.
                {
                    GuardarBloqueoUsuarios();
                }
                else if (!valorCelda) // Elimina.
                {
                    EliminarBloqueoUsuarios();
                }
                CargarProgramas();
                FormatearSpreadProgramas();
            }

        }

        #endregion

        #region Metodos Privados

        private void Centrar()
        {

            this.CenterToScreen();
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

        }
         
        private void ReiniciarControles() 
        {

            spAdministrar.Visible = false;
            rbtnUsuarios.Checked = false;
            rbtnEmpresas.Checked = false;
            rbtnProgramas.Checked = false;
            spProgramas.Visible = false;
            spSubProgramas.Visible = false;

        }

        private void FormatearSpread()
        {

            // Se cargan tipos de datos.
            tipoEntero.DecimalPlaces = 0;
            tipoTextoContrasena.PasswordChar = '*';
            // Se cargan las opciones generales de cada spread.
            spAdministrar.Visible = true;  
            spAdministrar.ActiveSheet.GrayAreaBackColor = Color.White;
            spProgramas.ActiveSheet.GrayAreaBackColor = Color.White;
            spSubProgramas.ActiveSheet.GrayAreaBackColor = Color.White;
            spAdministrar.Font = new Font("microsoft sans serif", 12, FontStyle.Bold);
            spProgramas.Font = new Font("microsoft sans serif", 12, FontStyle.Bold);
            spSubProgramas.Font = new Font("microsoft sans serif", 12, FontStyle.Bold);
            spAdministrar.ActiveSheetIndex = 0;
            spProgramas.ActiveSheetIndex = 0;
            spSubProgramas.ActiveSheetIndex = 0;
            spAdministrar.ActiveSheet.ColumnHeader.Rows[0].Height = 45;
            spProgramas.ActiveSheet.ColumnHeader.Rows[0].Height = 45;
            spSubProgramas.ActiveSheet.ColumnHeader.Rows[0].Height = 45;
            spAdministrar.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            spProgramas.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            spSubProgramas.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;

        }
        
        private void FormatearSpreadUsuarios()
        {

            spAdministrar.Height = pnlContenido.Height - pnlPie.Height - 25;
            spAdministrar.ActiveSheet.Columns[0].Tag = "empresa";
            spAdministrar.ActiveSheet.Columns[1].Tag = "numero";
            spAdministrar.ActiveSheet.Columns[2].Tag = "nombre";
            spAdministrar.ActiveSheet.Columns[3].Tag = "contrasena";
            spAdministrar.ActiveSheet.Columns[4].Tag = "nivel";
            spAdministrar.ActiveSheet.Columns[5].Tag = "accesoTotal";
            spAdministrar.ActiveSheet.Columns[6].Tag = "idArea";   
            spAdministrar.ActiveSheet.Columns["empresa"].Width = 220;     
            spAdministrar.ActiveSheet.Columns["numero"].Width = 50;
            spAdministrar.ActiveSheet.Columns["nombre"].Width = 220;
            spAdministrar.ActiveSheet.Columns["contrasena"].Width = 180;
            spAdministrar.ActiveSheet.Columns["nivel"].Width = 80;
            spAdministrar.ActiveSheet.Columns["accesoTotal"].Width = 130;
            spAdministrar.ActiveSheet.Columns["idArea"].Width = 80;
            spAdministrar.ActiveSheet.Columns["empresa"].CellType = tipoEntero;
            spAdministrar.ActiveSheet.Columns["numero"].CellType = tipoEntero;
            spAdministrar.ActiveSheet.Columns["nombre"].CellType = tipoTexto;
            spAdministrar.ActiveSheet.Columns["contrasena"].CellType = tipoTextoContrasena;
            spAdministrar.ActiveSheet.Columns["nivel"].CellType = tipoEntero;
            spAdministrar.ActiveSheet.Columns["accesoTotal"].CellType = tipoBooleano;
            spAdministrar.ActiveSheet.Columns["idArea"].CellType = tipoEntero;
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["empresa"].Index].Value = "Empresa".ToUpper();
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["numero"].Index].Value = "No.".ToUpper();
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["nombre"].Index].Value = "Nombre".ToUpper();
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["contrasena"].Index].Value = "Contraseña".ToUpper();
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["nivel"].Index].Value = "Nivel".ToUpper();
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["accesoTotal"].Index].Value = "Acceso Total".ToUpper();
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["idArea"].Index].Value = "No. Area".ToUpper();
            spAdministrar.ActiveSheet.Columns["empresa"].Visible = false;
            spAdministrar.ActiveSheet.Rows.Count += 1; 

        }

        private void FormatearSpreadProgramas()
        {

            spProgramas.ActiveSheet.Columns.Count = 5;
            spProgramas.ActiveSheet.Columns[0].Tag = "idEmpresa";
            spProgramas.ActiveSheet.Columns[1].Tag = "idModulo";
            spProgramas.ActiveSheet.Columns[2].Tag = "id";
            spProgramas.ActiveSheet.Columns[3].Tag = "nombre";
            spProgramas.ActiveSheet.Columns[4].Tag = "estatus";
            spProgramas.ActiveSheet.Columns["idEmpresa"].Width = 100;
            spProgramas.ActiveSheet.Columns["idModulo"].Width = 220;
            spProgramas.ActiveSheet.Columns["id"].Width = 50;
            spProgramas.ActiveSheet.Columns["nombre"].Width = 220;
            spProgramas.ActiveSheet.Columns["estatus"].Width = 120;
            spProgramas.ActiveSheet.Columns["idEmpresa"].CellType = tipoEntero;
            spProgramas.ActiveSheet.Columns["idModulo"].CellType = tipoEntero;
            spProgramas.ActiveSheet.Columns["id"].CellType = tipoEntero;
            spProgramas.ActiveSheet.Columns["nombre"].CellType = tipoTexto;
            spProgramas.ActiveSheet.Columns["estatus"].CellType = tipoBooleano;
            spProgramas.ActiveSheet.ColumnHeader.Cells[0, spProgramas.ActiveSheet.Columns["idEmpresa"].Index].Value = "Empresa".ToUpper();
            spProgramas.ActiveSheet.ColumnHeader.Cells[0, spProgramas.ActiveSheet.Columns["idModulo"].Index].Value = "Modulo".ToUpper();
            spProgramas.ActiveSheet.ColumnHeader.Cells[0, spProgramas.ActiveSheet.Columns["id"].Index].Value = "No.".ToUpper();
            spProgramas.ActiveSheet.ColumnHeader.Cells[0, spProgramas.ActiveSheet.Columns["nombre"].Index].Value = "Nombre".ToUpper();
            spProgramas.ActiveSheet.ColumnHeader.Cells[0, spProgramas.ActiveSheet.Columns["estatus"].Index].Value = "Bloquear".ToUpper();
            //spProgramas.ActiveSheet.Cells[0, spProgramas.ActiveSheet.Columns["estatus"].Index, spProgramas.ActiveSheet.Rows.Count - 1, spProgramas.ActiveSheet.Columns["estatus"].Index].Value = false;
            spProgramas.ActiveSheet.Columns["idEmpresa"].Visible = false;

        }

        private void CargarEmpresasCombobox()
        {

            cbEmpresas.Visible = true;
            cbEmpresas.DataSource = empresas.ObtenerListado();
            cbEmpresas.ValueMember = "Id";
            cbEmpresas.DisplayMember = "Nombre";
            try
            {
                cbEmpresas.SelectedIndex = 0;
            }
            catch (Exception)
            {
            }
            
        }

        private void CargarUsuarios()
        {

            try
            {
                usuarios.IdEmpresa = Convert.ToInt32(cbEmpresas.SelectedValue.ToString());            
                spAdministrar.DataSource = usuarios.ObtenerListadoDeEmpresa();
            }
            catch (Exception)
            {                             
            }

        }

        private void CargarProgramas()
        {

            try
            {
                int idEmpresa = Convert.ToInt32(cbEmpresas.SelectedValue.ToString());
                programas.IdEmpresa = idEmpresa;
                spProgramas.ActiveSheet.DataSource = programas.ObtenerListadoDeProgramas();
                
                FormatearSpreadProgramas();
                int filaUsuarios = spAdministrar.ActiveSheet.ActiveRowIndex;
                int idUsuario = Convert.ToInt32(spAdministrar.ActiveSheet.Cells[filaUsuarios, spAdministrar.ActiveSheet.Columns["numero"].Index].Text);
                for (int fila = 0; fila < spProgramas.ActiveSheet.Rows.Count; fila++)
                {
                    int idModulo = Convert.ToInt32(spProgramas.ActiveSheet.Cells[fila, spProgramas.ActiveSheet.Columns["idModulo"].Index].Text);
                    int idPrograma = Convert.ToInt32(spProgramas.ActiveSheet.Cells[fila, spProgramas.ActiveSheet.Columns["id"].Index].Text);
                    bloqueoUsuarios.IdEmpresa = idEmpresa;
                    bloqueoUsuarios.IdUsuario = idUsuario;
                    bloqueoUsuarios.IdModulo = idModulo;
                    bloqueoUsuarios.IdPrograma = idPrograma;
                    spProgramas.ActiveSheet.Cells[fila, spProgramas.ActiveSheet.Columns["estatus"].Index].Value = bloqueoUsuarios.Obtener(); Application.DoEvents();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
                
        private void ControlarSpread(FarPoint.Win.Spread.FpSpread spread)
        {

            FarPoint.Win.Spread.InputMap valor1;
            FarPoint.Win.Spread.InputMap valor2;
            valor1 = spread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            valor1.Put(new FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextColumnWrap);
            valor1 = spread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused);
            valor1.Put(new FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextColumnWrap);
            valor2 = spread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused);
            valor2.Put(new FarPoint.Win.Spread.Keystroke(Keys.Escape, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
            valor2 = spread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            valor2.Put(new FarPoint.Win.Spread.Keystroke(Keys.Escape, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

        }

        private void CargarEmpresasSpread()
        {
             
            spAdministrar.DataSource = empresas.ObtenerListado();
                       
        }

        private void FormatearSpreadEmpresas()
        {

            cbEmpresas.Visible = false;
            spAdministrar.ActiveSheet.Columns[0].Tag = "numero";
            spAdministrar.ActiveSheet.Columns[1].Tag = "nombre";
            spAdministrar.ActiveSheet.Columns[2].Tag = "descripcion";
            spAdministrar.ActiveSheet.Columns[3].Tag = "domicilio";
            spAdministrar.ActiveSheet.Columns[4].Tag = "localidad";
            spAdministrar.ActiveSheet.Columns[5].Tag = "rfc";
            spAdministrar.ActiveSheet.Columns[6].Tag = "directorio";
            spAdministrar.ActiveSheet.Columns[7].Tag = "logo";
            spAdministrar.ActiveSheet.Columns[8].Tag = "activa";
            spAdministrar.ActiveSheet.Columns[9].Tag = "equipo";
            spAdministrar.ActiveSheet.Columns["numero"].Width = 50;
            spAdministrar.ActiveSheet.Columns["nombre"].Width = 220;
            spAdministrar.ActiveSheet.Columns["descripcion"].Width = 220;
            spAdministrar.ActiveSheet.Columns["domicilio"].Width = 120;
            spAdministrar.ActiveSheet.Columns["localidad"].Width = 120;
            spAdministrar.ActiveSheet.Columns["rfc"].Width = 115;
            spAdministrar.ActiveSheet.Columns["directorio"].Width = 150;
            spAdministrar.ActiveSheet.Columns["logo"].Width = 150;
            spAdministrar.ActiveSheet.Columns["activa"].Width = 130;
            spAdministrar.ActiveSheet.Columns["equipo"].Width = 100;
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["numero"].Index].Value = "No.".ToUpper();
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["nombre"].Index].Value = "Nombre".ToUpper();
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["descripcion"].Index].Value = "Descripcion".ToUpper();
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["domicilio"].Index].Value = "Domicilio".ToUpper();
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["localidad"].Index].Value = "Localidad".ToUpper();
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["rfc"].Index].Value = "Rfc".ToUpper();
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["directorio"].Index].Value = "Directorio".ToUpper();
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["logo"].Index].Value = "Logo".ToUpper();
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["activa"].Index].Value = "Activa".ToUpper();
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["equipo"].Index].Value = "Equipo".ToUpper();            
            spAdministrar.ActiveSheet.Columns[0, spAdministrar.ActiveSheet.Columns.Count-1].Visible = true;
            spAdministrar.ActiveSheet.Rows.Count += 1;

        }

        #endregion

    }
}
