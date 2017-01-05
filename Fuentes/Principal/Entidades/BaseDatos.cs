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

            this.CadenaConexionInformacion = string.Format("Data Source=SYS21ALIEN03-PC\\SQLEXPRESS;Initial Catalog={0};User Id=AdminBerry;Password=@berry", this.CadenaConexionInformacion);
            conexionInformacion.ConnectionString = this.CadenaConexionInformacion;
            //Data Source=SYS21ALIEN03-PC\SQLEXPRESS;Initial Catalog=INFORMACION;User ID=adminberry
        }
        
    }
    
}
