using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Entidades
{
   public class BaseDatos
    {

        private string cadenaConexionInformacion; 
        public static SqlConnection conexionInformacion = new SqlConnection(); 
        public string CadenaConexionInformacion
        {
            get { return cadenaConexionInformacion; }
            set { cadenaConexionInformacion = value; }
        } 
          //public static SqlConnection conexionPrincipal = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionPrincipal"].ConnectionString);
            
        public void AbrirConexionInformacion()
        {

            this.CadenaConexionInformacion = string.Format("Data Source=.\\SQLEXPRESS;Initial Catalog={0};Integrated Security=True;Connect Timeout=30", this.CadenaConexionInformacion);
            conexionInformacion.ConnectionString = this.CadenaConexionInformacion;

        }
        
    }
    
}
