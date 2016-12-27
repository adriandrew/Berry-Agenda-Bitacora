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
    public partial class AdministrarEmpresas : Form
    {

        Entidades.Empresas empresas = new Entidades.Empresas();

        #region Eventos

        public AdministrarEmpresas()
        {
            InitializeComponent();
        }

        private void Empresas_Load(object sender, EventArgs e)
        {

            Centrar();
            CargarEmpresas();
            FormatearSpread();

        }

        private void spEmpresas_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {

            PredeterminarEmpresa();

        }

        private void AdministrarEmpresas_FormClosed(object sender, FormClosedEventArgs e)
        {

            new Principal().Show();

        }

        #endregion

        #region Metodos Privados

        private void Centrar()
        {

            this.CenterToScreen();

        }

        private void CargarEmpresas()
        {
             
            spEmpresas.DataSource = empresas.ObtenerListado();            

        }

        private void FormatearSpread()
        {

            FarPoint.Win.Spread.CellType.TextCellType tipoTexto = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType tipoEntero = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType tipoDoble = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.PercentCellType tipoPorcentaje = new FarPoint.Win.Spread.CellType.PercentCellType();
            FarPoint.Win.Spread.CellType.DateTimeCellType tipoHora = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            spEmpresas.ActiveSheetIndex = 0;
            spEmpresas.ActiveSheet.ColumnHeader.Rows[0].Height = 30;
            spEmpresas.ActiveSheet.GrayAreaBackColor = Color.White;
            spEmpresas.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            spEmpresas.Font = new Font("microsoft sans serif", 12, FontStyle.Bold);
            spEmpresas.ActiveSheet.Columns[0].Tag = "numero";
            spEmpresas.ActiveSheet.Columns[1].Tag = "nombre";
            spEmpresas.ActiveSheet.Columns[2].Tag = "descripcion";
            spEmpresas.ActiveSheet.Columns[3].Tag = "domicilio";
            spEmpresas.ActiveSheet.Columns[4].Tag = "localidad";
            spEmpresas.ActiveSheet.Columns[5].Tag = "rfc";
            spEmpresas.ActiveSheet.Columns[6].Tag = "directorio";
            spEmpresas.ActiveSheet.Columns[7].Tag = "logo";
            spEmpresas.ActiveSheet.Columns[8].Tag = "activa";
            spEmpresas.ActiveSheet.Columns[9].Tag = "equipo";
            spEmpresas.ActiveSheet.Columns["numero"].Width = 50;
            spEmpresas.ActiveSheet.Columns["nombre"].Width = 220;
            spEmpresas.ActiveSheet.Columns["descripcion"].Width = 220;
            spEmpresas.ActiveSheet.Columns["domicilio"].Width = 120;
            spEmpresas.ActiveSheet.Columns["localidad"].Width = 120;
            spEmpresas.ActiveSheet.Columns["rfc"].Width = 115;
            spEmpresas.ActiveSheet.Columns["directorio"].Width = 150;
            spEmpresas.ActiveSheet.Columns["logo"].Width = 130;
            spEmpresas.ActiveSheet.Columns["activa"].Width = 130;
            spEmpresas.ActiveSheet.Columns["equipo"].Width = 100;
            spEmpresas.ActiveSheet.ColumnHeader.Cells[0, spEmpresas.ActiveSheet.Columns["numero"].Index].Value = "No.".ToUpper();
            spEmpresas.ActiveSheet.ColumnHeader.Cells[0, spEmpresas.ActiveSheet.Columns["nombre"].Index].Value = "Nombre".ToUpper();
            spEmpresas.ActiveSheet.ColumnHeader.Cells[0, spEmpresas.ActiveSheet.Columns["descripcion"].Index].Value = "Descripcion".ToUpper();
            spEmpresas.ActiveSheet.ColumnHeader.Cells[0, spEmpresas.ActiveSheet.Columns["domicilio"].Index].Value = "Domicilio".ToUpper();
            spEmpresas.ActiveSheet.ColumnHeader.Cells[0, spEmpresas.ActiveSheet.Columns["localidad"].Index].Value = "Localidad".ToUpper();
            spEmpresas.ActiveSheet.ColumnHeader.Cells[0, spEmpresas.ActiveSheet.Columns["rfc"].Index].Value = "Rfc".ToUpper();
            spEmpresas.ActiveSheet.ColumnHeader.Cells[0, spEmpresas.ActiveSheet.Columns["activa"].Index].Value = "Predeterminada".ToUpper();
            spEmpresas.ActiveSheet.Columns["directorio"].Visible = false;
            spEmpresas.ActiveSheet.Columns["logo"].Visible = false;
            spEmpresas.ActiveSheet.Columns["equipo"].Visible = false;

        }

        // TODO: pendiente.
        private void PredeterminarEmpresa()
        {

            string numero = spEmpresas.ActiveSheet.Cells[spEmpresas.ActiveSheet.ActiveRowIndex, spEmpresas.ActiveSheet.Columns["numero"].Index].Text;
            if (!string.IsNullOrEmpty(numero))
            {
                empresas.Id = Convert.ToInt32(numero);
                empresas.Predeterminar();
                this.Hide();            
                new Principal().Show();
            }

        }
        
        #endregion


    }
}
