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
        private string cadenaConexionCatalogo;
        public static SqlConnection conexionInformacion = new SqlConnection();
        public static SqlConnection conexionCatalogo = new SqlConnection(); 

        public string CadenaConexionInformacion
        {
            get { return cadenaConexionInformacion; }
            set { cadenaConexionInformacion = value; }
        }
        public string CadenaConexionCatalogo
        {
            get { return cadenaConexionCatalogo; }
            set { cadenaConexionCatalogo = value; }
        } 
          //public static SqlConnection conexionPrincipal = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionPrincipal"].ConnectionString);
            
        public void AbrirConexionInformacion()
        {

            this.CadenaConexionInformacion = string.Format("Data Source=SYS21ALIEN03-PC\\SQLEXPRESS;Initial Catalog={0};User Id=AdminBerry;Password=@berry", this.CadenaConexionInformacion);
            conexionInformacion.ConnectionString = this.CadenaConexionInformacion; 

        }

        public void AbrirConexionCatalogo()
        {

            this.cadenaConexionCatalogo = string.Format("Data Source=SYS21ALIEN03-PC\\SQLEXPRESS;Initial Catalog={0};User Id=AdminBerry;Password=@berry", this.cadenaConexionCatalogo);
            conexionCatalogo.ConnectionString = this.cadenaConexionCatalogo; 

        }
 
    }
    
}
