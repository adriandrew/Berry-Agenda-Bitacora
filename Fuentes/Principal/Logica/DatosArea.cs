using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Logica
{
    public class DatosArea
    {
         
        private int id;
        private string nombre; 
        private string clave;

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }
        public string Clave
        {
            get { return this.clave; }
            set { this.clave = value; }
        }

        public void ObtenerParametrosInformacionArea()
        {

            string[] parametros = Environment.GetCommandLineArgs().ToArray();
            if ((parametros.Length > 1)) {
	            int numeracion = 26;
	            this.Id = Convert.ToInt32(parametros[numeracion].Replace("|", " ")); numeracion += 1;
                this.Nombre = parametros[numeracion].Replace("|", " "); numeracion += 1;
                this.Clave = parametros[numeracion].Replace("|", " "); numeracion += 1; 
            }

        }
    }
}
