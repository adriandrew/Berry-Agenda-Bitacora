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
         
    }
}
