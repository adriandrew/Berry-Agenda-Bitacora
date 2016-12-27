using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logica
{
    public class DatosEmpresa
    {

        private int numero;
        private string nombre;
        private string descripcion;
        private string domicilio;
        private string localidad;
        private string rfc;
        private string directorio;
        private string logo;
        private bool activa;
        private string equipo;

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public string Domicilio
        {
            get { return domicilio; }
            set { domicilio = value; }
        }
        public string Localidad
        {
            get { return localidad; }
            set { localidad = value; }
        }
        public string Rfc
        {
            get { return rfc; }
            set { rfc = value; }
        }
        public string Directorio
        {
            get { return directorio; }
            set { directorio = value; }
        }
        public string Logo
        {
            get { return logo; }
            set { logo = value; }
        }
        public bool Activa
        {
            get { return activa; }
            set { activa = value; }
        }
        public string Equipo
        {
            get { return equipo; }
            set { equipo = value; }
        }

        public void ObtenerParametrosInformacionEmpresa() 
        {

            string[] parametros = Environment.GetCommandLineArgs();
            //for (int i = 0; i < parametros.Length; i++)
            //{
            //    //MessageBox.Show("Parámetro " + parametros[i]);                
            //} 
            this.Numero = Convert.ToInt32(parametros[0]);
            this.Nombre = parametros[1];
            this.Descripcion = parametros[2];
            this.Domicilio = parametros[3];
            this.Localidad = parametros[4];
            this.Rfc = parametros[5];
            this.Directorio = parametros[6];
            this.Logo = parametros[7];
            this.Activa = Convert.ToBoolean(parametros[8]);
            this.Equipo = parametros[9];

        }

    }
}
