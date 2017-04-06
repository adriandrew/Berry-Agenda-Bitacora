using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logica
{
    public class DatosEmpresa
    {

        private int id;
        private string nombre;
        private string descripcion;
        private string domicilio;
        private string localidad;
        private string rfc;
        private string directorio;
        private string logo;
        private bool activa;
        private string equipo;

        public int Id 
        {
            get { return id; }
            set { id = value; }
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
	        if (parametros.Length > 1) {
                int numeracion = 8;
                this.Id = Convert.ToInt32(parametros[numeracion].Replace("|", " ")); numeracion += 1;
                this.Nombre = parametros[numeracion].Replace("|", " "); numeracion += 1;
                this.Descripcion = parametros[numeracion].Replace("|", " "); numeracion += 1;
                this.Domicilio = parametros[numeracion].Replace("|", " "); numeracion += 1;
                this.Localidad = parametros[numeracion].Replace("|", " "); numeracion += 1;
                this.Rfc = parametros[numeracion].Replace("|", " "); numeracion += 1;
                this.Directorio = parametros[numeracion].Replace("|", " "); numeracion += 1;
                this.Logo = parametros[numeracion].Replace("|", " "); numeracion += 1;
                this.Activa = Convert.ToBoolean(parametros[numeracion].Replace("|", " ")); numeracion += 1;
                this.Equipo = parametros[numeracion].Replace("|", " "); numeracion += 1;
            }

        }

    }
}
