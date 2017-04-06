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
        Entidades.Areas areas = new Entidades.Areas();
        Entidades.UsuariosAreas usuariosAreas = new Entidades.UsuariosAreas();
        Entidades.Programas programas = new Entidades.Programas();
        Entidades.BloqueoUsuarios bloqueoUsuarios = new Entidades.BloqueoUsuarios();
        public int opcionSeleccionada = 0;
        public static string nombreEmpresa = string.Empty;
        
        public PanelControl()
        {
            InitializeComponent();
        }

        #region Eventos

        private void PanelControl_Load(object sender, EventArgs e)
        {

            Centrar();
            AsignarTooltips();
            ReiniciarControles();
            ControlarSpreadEnter(spAdministrar);
            CargarEncabezados();
            CargarEmpresasCombobox();
            CargarUsuarios();

        }
       
        private void rbtnUsuarios_CheckedChanged(object sender, EventArgs e)
        {

            //if (rbtnUsuarios.Checked)
            //{
            //    CargarEmpresasCombobox();
            //    CargarUsuarios();
            //    FormatearSpread();
            //    FormatearSpreadUsuarios();
            //}

        }
        
        private void PanelControl_Shown(object sender, EventArgs e)
        {

            ReiniciarControles();

        }
         
        private void spAdministrar_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.F5) // Abrir catalogo de areas.
            {
                if ((spAdministrar.ActiveSheet.ActiveColumnIndex == spAdministrar.ActiveSheet.Columns["idArea"].Index) || (spAdministrar.ActiveSheet.ActiveColumnIndex == spAdministrar.ActiveSheet.Columns["nombreArea"].Index))
                {
                    spAdministrar.Enabled = false;
                    CargarAreas();
                    FormatearSpreadCatalogoAreas();
                    spCatalogos.Focus();
                }
            } 
            else if (e.KeyData == Keys.F6) // Eliminar.
            {
                if (MessageBox.Show("Confirmas que deseas eliminar el registro seleccionado?", "Confirmacion.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int fila = spAdministrar.ActiveSheet.ActiveRowIndex;
                    spAdministrar.ActiveSheet.Rows.Remove(fila, 1);
                    //else if (rbtnEmpresas.Checked)
                    //{
                    //    string idEmpresa = spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["idEmpresa"].Index].Text;
                    //    if (!string.IsNullOrEmpty(idEmpresa))
                    //    {                            
                    //        empresas.IdEmpresa = Logica.Funciones.ValidarNumero(idEmpresa);
                    //        empresas.Eliminar();
                    //    }
                    //}
                }
            }
            else if (e.KeyData == Keys.Enter) // Validar.
            {
                ControlarSpreadEnter(); 
            }

        }
        
        private void PanelControl_FormClosed(object sender, FormClosedEventArgs e)
        {

            new Principal().Show();

        }

        private void rbtnEmpresas_CheckedChanged(object sender, EventArgs e)
        {
            
            //if (rbtnEmpresas.Checked)
            //{
            //    CargarEmpresasSpread();
            //    FormatearSpread();
            //    FormatearSpreadEmpresas();               
            //}

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
                    if (valorCelda == 0) 
                    {
                        spProgramas.Visible = false;
                        spSubProgramas.Visible = false;                        
                    }
                    else if (valorCelda == 1) // Nivel de bloqueo de los modulos. // TODO. Pendiente.
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            //if (this.opcionSeleccionada = TipoControl.Usuarios) 
            //{
                GuardarEditarUsuarios();
            //}

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            EliminarUsuarios();

        }

        private void spAdministrar_DialogKey(object sender, FarPoint.Win.Spread.DialogKeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter)
            {
                ControlarSpreadEnter();
            }

        }

        private void spCatalogos_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {

            int fila = e.Row;
            spAdministrar.ActiveSheet.Cells[spAdministrar.ActiveSheet.ActiveRowIndex, spAdministrar.ActiveSheet.Columns["idArea"].Index].Text = spCatalogos.ActiveSheet.Cells[fila, spCatalogos.ActiveSheet.Columns["idArea"].Index].Text;
            spAdministrar.ActiveSheet.Cells[spAdministrar.ActiveSheet.ActiveRowIndex, spAdministrar.ActiveSheet.Columns["nombreArea"].Index].Text = spCatalogos.ActiveSheet.Cells[fila, spCatalogos.ActiveSheet.Columns["nombreArea"].Index].Text;

        }

        private void spCatalogos_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {

            spAdministrar.Enabled = true;
            spAdministrar.Focus();
            spAdministrar.ActiveSheet.SetActiveCell(spAdministrar.ActiveSheet.ActiveRowIndex, spAdministrar.ActiveSheet.Columns["idArea"].Index);
            spCatalogos.Visible = false;

        }

        private void spCatalogos_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
            {
                spAdministrar.Enabled = true;
                spAdministrar.Focus();
                spAdministrar.ActiveSheet.SetActiveCell(spAdministrar.ActiveSheet.ActiveRowIndex, spAdministrar.ActiveSheet.Columns["idArea"].Index);
                spCatalogos.Visible = false;
            } 

        }

        private void btnGuardar_MouseHover(object sender, EventArgs e)
        {

            AsignarTooltips("Guardar.");

        }

        private void btnEliminar_MouseHover(object sender, EventArgs e)
        {

            AsignarTooltips("Eliminar.");

        }

        private void btnSalir_MouseHover(object sender, EventArgs e)
        {

            AsignarTooltips("Salir.");

        }

        private void pnlEncabezado_MouseHover(object sender, EventArgs e)
        {

            AsignarTooltips(string.Empty);

        }

        private void pnlCuerpo_MouseHover(object sender, EventArgs e)
        {

            AsignarTooltips(string.Empty);

        }

        private void pnlPie_MouseHover(object sender, EventArgs e)
        {

            AsignarTooltips(string.Empty);

        }

        private void pnlContenido_MouseHover(object sender, EventArgs e)
        {

            AsignarTooltips(string.Empty);

        }

        #endregion

        #region Metodos 

        private void Centrar()
        {

            this.CenterToScreen();
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
            tp.SetToolTip(this.btnGuardar, "Guardar.");
            tp.SetToolTip(this.btnEliminar, "Eliminar.");
            tp.SetToolTip(this.btnSalir, "Salir.");

        } 

        private void AsignarTooltips(string texto)
        {

            lblDescripcionTooltip.Text = texto;

        }

        private void ControlarSpreadEnter()
        {

            int fila = spAdministrar.ActiveSheet.ActiveRowIndex;
            //if (this.opcionSeleccionada == (int)TipoControl.Usuarios)
            //{
                if (spAdministrar.ActiveSheet.ActiveColumnIndex == spAdministrar.ActiveSheet.Columns["idArea"].Index)
                {
                    int idArea = Logica.Funciones.ValidarNumero(spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["idArea"].Index].Value.ToString());
                    if (idArea > 0)
                    { 
                        areas.Id = idArea;
                        List<Entidades.Areas> datos = new List<Entidades.Areas>();
                        datos = areas.ObtenerListaPorId(); 
                        spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["nombreArea"].Index].Text = datos[0].Nombre; 
                    }
                }
            //}
            if (spAdministrar.ActiveSheet.ActiveColumnIndex == spAdministrar.ActiveSheet.Columns.Count - 1)
            {
                spAdministrar.ActiveSheet.AddRows(spAdministrar.ActiveSheet.Rows.Count, 1);
                //if (rbtnUsuarios.Checked)
                //{
                    //GuardarEditarUsuarios();
                //}
                //else if (rbtnEmpresas.Checked)
                //{
                    //GuardarEditarEmpresas();
                //}
            }

        }

        private void ReiniciarControles() 
        {

            //spAdministrar.Visible = false            
            rbtnUsuarios.Checked = true;
            rbtnEmpresas.Checked = false;
            rbtnProgramas.Checked = false;
            spProgramas.Visible = false;
            spSubProgramas.Visible = false;

        }

        private void CargarEncabezados()
        {

            lblEncabezadoPrograma.Text = "Programa: " + this.Text;
            lblEncabezadoEmpresa.Text = "Empresa: " + PanelControl.nombreEmpresa;
            
        }

        private void FormatearSpread()
        {

            // Se cargan tipos de datos.
            tipoEntero.DecimalPlaces = 0;
            tipoTextoContrasena.PasswordChar = '*';
            // Se cargan las opciones generales de cada spread.
            spAdministrar.Visible = true; Application.DoEvents();
            spAdministrar.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Seashell; Application.DoEvents();
            spProgramas.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Seashell; Application.DoEvents();
            spSubProgramas.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Seashell; Application.DoEvents(); 
            spCatalogos.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Midnight; Application.DoEvents();
            spAdministrar.ActiveSheet.GrayAreaBackColor = Color.White; Application.DoEvents();
            spProgramas.ActiveSheet.GrayAreaBackColor = Color.White; Application.DoEvents();
            spSubProgramas.ActiveSheet.GrayAreaBackColor = Color.White; Application.DoEvents();
            spCatalogos.ActiveSheet.GrayAreaBackColor = Color.FromArgb(230, 230, 255); Application.DoEvents();
            spAdministrar.Font = new Font("microsoft sans serif", 12, FontStyle.Regular); Application.DoEvents();
            spProgramas.Font = new Font("microsoft sans serif", 12, FontStyle.Regular); Application.DoEvents();
            spSubProgramas.Font = new Font("microsoft sans serif", 12, FontStyle.Regular); Application.DoEvents();
            spCatalogos.Font = new Font("microsoft sans serif", 12, FontStyle.Regular); Application.DoEvents();
            spAdministrar.ActiveSheetIndex = 0; Application.DoEvents();
            spProgramas.ActiveSheetIndex = 0; Application.DoEvents();
            spSubProgramas.ActiveSheetIndex = 0; Application.DoEvents();
            spCatalogos.ActiveSheetIndex = 0; Application.DoEvents();
            spAdministrar.ActiveSheet.ColumnHeader.Rows[0].Height = 45; Application.DoEvents();
            spProgramas.ActiveSheet.ColumnHeader.Rows[0].Height = 45; Application.DoEvents();
            spSubProgramas.ActiveSheet.ColumnHeader.Rows[0].Height = 45; Application.DoEvents();
            spCatalogos.ActiveSheet.ColumnHeader.Rows[0].Height = 45; Application.DoEvents();
            spAdministrar.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded; Application.DoEvents();
            spProgramas.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded; Application.DoEvents();
            spSubProgramas.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded; Application.DoEvents();
            spCatalogos.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded; Application.DoEvents();
            spAdministrar.ActiveSheet.Rows[-1].Height = 22;
            spCatalogos.ActiveSheet.Rows[-1].Height = 22;
            
        }
        
        private void FormatearSpreadUsuarios()
        {

            spAdministrar.ActiveSheet.ColumnHeader.Rows[0].Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold); Application.DoEvents();
            spAdministrar.Height = pnlCuerpo.Height - btnGuardar.Height - 5; Application.DoEvents();
            int numeracion = 0;
            spAdministrar.ActiveSheet.Columns[numeracion].Tag = "empresa"; numeracion += 1;
            spAdministrar.ActiveSheet.Columns[numeracion].Tag = "numero"; numeracion += 1;
            spAdministrar.ActiveSheet.Columns[numeracion].Tag = "nombre"; numeracion += 1;
            spAdministrar.ActiveSheet.Columns[numeracion].Tag = "contrasena"; numeracion += 1;
            spAdministrar.ActiveSheet.Columns[numeracion].Tag = "nivel"; numeracion += 1;
            spAdministrar.ActiveSheet.Columns[numeracion].Tag = "accesoTotal"; numeracion += 1;
            spAdministrar.ActiveSheet.Columns[numeracion].Tag = "idArea"; numeracion += 1;
            spAdministrar.ActiveSheet.Columns[numeracion].Tag = "nombreArea"; numeracion += 1;
            spAdministrar.ActiveSheet.Columns["empresa"].Width = 220; Application.DoEvents();
            spAdministrar.ActiveSheet.Columns["numero"].Width = 50; Application.DoEvents();
            spAdministrar.ActiveSheet.Columns["nombre"].Width = 220; Application.DoEvents();
            spAdministrar.ActiveSheet.Columns["contrasena"].Width = 180; Application.DoEvents();
            spAdministrar.ActiveSheet.Columns["nivel"].Width = 80; Application.DoEvents();
            spAdministrar.ActiveSheet.Columns["accesoTotal"].Width = 130; Application.DoEvents();
            spAdministrar.ActiveSheet.Columns["idArea"].Width = 80; Application.DoEvents();
            spAdministrar.ActiveSheet.Columns["nombreArea"].Width = 180; Application.DoEvents();
            spAdministrar.ActiveSheet.Columns["empresa"].CellType = tipoEntero; Application.DoEvents();
            spAdministrar.ActiveSheet.Columns["numero"].CellType = tipoEntero; Application.DoEvents();
            spAdministrar.ActiveSheet.Columns["nombre"].CellType = tipoTexto; Application.DoEvents();
            spAdministrar.ActiveSheet.Columns["contrasena"].CellType = tipoTextoContrasena; Application.DoEvents();
            spAdministrar.ActiveSheet.Columns["nivel"].CellType = tipoEntero; Application.DoEvents();
            spAdministrar.ActiveSheet.Columns["accesoTotal"].CellType = tipoBooleano; Application.DoEvents();
            spAdministrar.ActiveSheet.Columns["idArea"].CellType = tipoEntero; Application.DoEvents();
            spAdministrar.ActiveSheet.Columns["nombreArea"].CellType = tipoTexto; Application.DoEvents();
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["empresa"].Index].Value = "Empresa".ToUpper(); Application.DoEvents();
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["numero"].Index].Value = "No.".ToUpper(); Application.DoEvents();
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["nombre"].Index].Value = "Nombre".ToUpper(); Application.DoEvents();
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["contrasena"].Index].Value = "Contraseña".ToUpper(); Application.DoEvents();
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["nivel"].Index].Value = "Nivel".ToUpper(); Application.DoEvents();
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["accesoTotal"].Index].Value = "Acceso Total".ToUpper(); Application.DoEvents();
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["idArea"].Index].Value = "No.".ToUpper(); Application.DoEvents();
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["nombreArea"].Index].Value = "Nombre Area".ToUpper(); Application.DoEvents();
            spAdministrar.ActiveSheet.Columns["empresa"].Visible = false; Application.DoEvents();
            spAdministrar.ActiveSheet.Rows.Count += 1; Application.DoEvents();

        }

        private void FormatearSpreadProgramas()
        {

            spProgramas.ActiveSheet.ColumnHeader.Rows[0].Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold); Application.DoEvents();
            spProgramas.ActiveSheet.Columns.Count = 5; Application.DoEvents();
            spProgramas.ActiveSheet.Columns[0].Tag = "idEmpresa";
            spProgramas.ActiveSheet.Columns[1].Tag = "idModulo";
            spProgramas.ActiveSheet.Columns[2].Tag = "id";
            spProgramas.ActiveSheet.Columns[3].Tag = "nombre";
            spProgramas.ActiveSheet.Columns[4].Tag = "estatus";
            spProgramas.ActiveSheet.Columns["idEmpresa"].Width = 100; Application.DoEvents();
            spProgramas.ActiveSheet.Columns["idModulo"].Width = 220; Application.DoEvents();
            spProgramas.ActiveSheet.Columns["id"].Width = 50; Application.DoEvents();
            spProgramas.ActiveSheet.Columns["nombre"].Width = 220; Application.DoEvents();
            spProgramas.ActiveSheet.Columns["estatus"].Width = 120; Application.DoEvents();
            spProgramas.ActiveSheet.Columns["idEmpresa"].CellType = tipoEntero; Application.DoEvents();
            spProgramas.ActiveSheet.Columns["idModulo"].CellType = tipoEntero; Application.DoEvents();
            spProgramas.ActiveSheet.Columns["id"].CellType = tipoEntero; Application.DoEvents();
            spProgramas.ActiveSheet.Columns["nombre"].CellType = tipoTexto; Application.DoEvents();
            spProgramas.ActiveSheet.Columns["estatus"].CellType = tipoBooleano; Application.DoEvents();
            spProgramas.ActiveSheet.ColumnHeader.Cells[0, spProgramas.ActiveSheet.Columns["idEmpresa"].Index].Value = "Empresa".ToUpper(); Application.DoEvents();
            spProgramas.ActiveSheet.ColumnHeader.Cells[0, spProgramas.ActiveSheet.Columns["idModulo"].Index].Value = "Modulo".ToUpper(); Application.DoEvents();
            spProgramas.ActiveSheet.ColumnHeader.Cells[0, spProgramas.ActiveSheet.Columns["id"].Index].Value = "No.".ToUpper(); Application.DoEvents();
            spProgramas.ActiveSheet.ColumnHeader.Cells[0, spProgramas.ActiveSheet.Columns["nombre"].Index].Value = "Nombre".ToUpper(); Application.DoEvents();
            spProgramas.ActiveSheet.ColumnHeader.Cells[0, spProgramas.ActiveSheet.Columns["estatus"].Index].Value = "Bloquear".ToUpper(); Application.DoEvents();
            //spProgramas.ActiveSheet.Cells[0, spProgramas.ActiveSheet.Columns["estatus"].Index, spProgramas.ActiveSheet.Rows.Count - 1, spProgramas.ActiveSheet.Columns["estatus"].Index].Value = false;
            spProgramas.ActiveSheet.Columns["idEmpresa"].Visible = false; Application.DoEvents();

        }

        private void FormatearSpreadCatalogoAreas()
        {

            spCatalogos.ActiveSheet.ColumnHeader.Rows[0].Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold); Application.DoEvents();
            spCatalogos.Location = new Point(spAdministrar.Location.X, spAdministrar.Location.Y); Application.DoEvents();
            spCatalogos.Visible = true; Application.DoEvents();
            spCatalogos.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never; Application.DoEvents();
            spCatalogos.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect; Application.DoEvents();
            spCatalogos.Height = spAdministrar.Height; Application.DoEvents();
            spCatalogos.Width = 310; Application.DoEvents();
            int numeracion = 0; 
            spCatalogos.ActiveSheet.Columns[numeracion].Tag = "idArea"; numeracion += 1;
            spCatalogos.ActiveSheet.Columns[numeracion].Tag = "nombreArea"; numeracion += 1;
            spCatalogos.ActiveSheet.Columns[numeracion].Tag = "claveArea"; numeracion += 1;  
            spCatalogos.ActiveSheet.Columns["idArea"].Width = 50; Application.DoEvents();
            spCatalogos.ActiveSheet.Columns["nombreArea"].Width = 220; Application.DoEvents();
            spCatalogos.ActiveSheet.Columns["claveArea"].Width = 180; Application.DoEvents();  
            spCatalogos.ActiveSheet.Columns["idArea"].CellType = tipoEntero; Application.DoEvents();
            spCatalogos.ActiveSheet.Columns["nombreArea"].CellType = tipoTexto; Application.DoEvents();
            spCatalogos.ActiveSheet.Columns["claveArea"].CellType = tipoTexto; Application.DoEvents();  
            spCatalogos.ActiveSheet.ColumnHeader.Cells[0, spCatalogos.ActiveSheet.Columns["idArea"].Index].Value = "No.".ToUpper(); Application.DoEvents();
            spCatalogos.ActiveSheet.ColumnHeader.Cells[0, spCatalogos.ActiveSheet.Columns["nombreArea"].Index].Value = "Nombre".ToUpper(); Application.DoEvents();
            spCatalogos.ActiveSheet.ColumnHeader.Cells[0, spCatalogos.ActiveSheet.Columns["claveArea"].Index].Value = "Clave".ToUpper(); Application.DoEvents();
            spCatalogos.ActiveSheet.Columns["claveArea"].Visible = false; Application.DoEvents();

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

        private void CargarAreas()
        { 
             
            //areas.IdEmpresa = 1;
            spCatalogos.DataSource = areas.ObtenerListado(); Application.DoEvents(); 

        }

        private void CargarUsuarios()
        {

            try
            {
                //if (cbEmpresas.Items.Count > 0)
                //{ 
                usuariosAreas.IdEmpresa = 1; // Convert.ToInt32(cbEmpresas.SelectedValue.ToString());
                spAdministrar.DataSource = usuariosAreas.ObtenerListadoPorEmpresa();
                FormatearSpread();
                FormatearSpreadUsuarios();
                //}
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
                
        private void ControlarSpreadEnter(FarPoint.Win.Spread.FpSpread spread)
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
            spAdministrar.ActiveSheet.ColumnHeader.Rows[0].Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold); Application.DoEvents();
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

        private void GuardarEditarUsuariosEnter()
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

        private void GuardarEditarUsuarios()
        {

            string empresa = cbEmpresas.SelectedValue.ToString();
            usuarios.IdEmpresa = Convert.ToInt32(empresa);
            usuarios.EliminarTodo();
            for (int fila = 0; fila < spAdministrar.ActiveSheet.Rows.Count; fila++)
            {  
                string numero = spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["numero"].Index].Text;
                string nombre = spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["nombre"].Index].Text;
                string contrasena = Logica.Funciones.ValidarLetra(spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["contrasena"].Index].Value);
                string nivel = spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["nivel"].Index].Text;
                bool accesoTotal = Convert.ToBoolean(spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["accesoTotal"].Index].Value);
                string idArea = spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["idArea"].Index].Text;
                if (!string.IsNullOrEmpty(empresa) && !string.IsNullOrEmpty(numero) && !string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(contrasena) && !string.IsNullOrEmpty(nivel) && !string.IsNullOrEmpty(idArea))
                {
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
            MessageBox.Show("Guardado correcto.", "Correcto.", MessageBoxButtons.OK);
            CargarUsuarios();
            ReiniciarControles();

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
            if ((idEmpresa > 0) && (idUsuario > 0))
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

        private void EliminarUsuariosEnter()
        {

            int fila = spAdministrar.ActiveSheet.ActiveRowIndex;
            string empresa = cbEmpresas.SelectedValue.ToString();
            string numero = spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["numero"].Index].Text;
            if (!string.IsNullOrEmpty(empresa) && !string.IsNullOrEmpty(numero))
            {
                usuarios.IdEmpresa = Logica.Funciones.ValidarNumero(empresa);
                usuarios.Id = Logica.Funciones.ValidarNumero(numero);
                usuarios.Eliminar();
            }

        }

        private void EliminarUsuarios() 
        {

            if ((MessageBox.Show("Confirmas que deseas eliminar todo?", "Confirmación.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                string empresa = cbEmpresas.SelectedValue.ToString(); 
                if (!string.IsNullOrEmpty(empresa))
                {
                    usuarios.IdEmpresa = Logica.Funciones.ValidarNumero(empresa); 
                    usuarios.EliminarTodo();
                    CargarUsuarios();
                }
            }

        }

        private void EliminarBloqueoUsuarios()
        {

            int filaProgramas = spProgramas.ActiveSheet.ActiveRowIndex;
            int filaAdministrar = spAdministrar.ActiveSheet.ActiveRowIndex;
            int idEmpresa = Convert.ToInt32(cbEmpresas.SelectedValue.ToString());
            int idUsuario = Convert.ToInt32(spAdministrar.ActiveSheet.Cells[filaAdministrar, spAdministrar.ActiveSheet.Columns["numero"].Index].Text);
            int idModulo = Convert.ToInt32(spProgramas.ActiveSheet.Cells[filaProgramas, spProgramas.ActiveSheet.Columns["idModulo"].Index].Text);
            int idPrograma = Convert.ToInt32(spProgramas.ActiveSheet.Cells[filaProgramas, spProgramas.ActiveSheet.Columns["id"].Index].Text);
            int idSubPrograma = 0;
            if ((idEmpresa > 0) && (idUsuario > 0))
            {
                bloqueoUsuarios.IdEmpresa = idEmpresa;
                bloqueoUsuarios.IdUsuario = idUsuario;
                bloqueoUsuarios.IdModulo = idModulo;
                bloqueoUsuarios.IdPrograma = idPrograma;
                bloqueoUsuarios.IdSubPrograma = idSubPrograma;
                bloqueoUsuarios.Eliminar();
            }

        }

        #endregion

        #region Enumeraciones

        public enum TipoControl
        { 
        
            Usuarios = 1, 
            Empresas = 2,
            Programas = 3

        }

        #endregion 

    }
}
