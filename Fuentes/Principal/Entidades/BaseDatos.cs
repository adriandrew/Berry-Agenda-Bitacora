using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlServerCe;

namespace Entidades
{
   public class BaseDatos
    {
        
        private string cadenaConexionPrincipal;
        private string cadenaConexionInformacion;
        private string cadenaConexionCatalogo;
        public static SqlCeConnection conexionPrincipal = new SqlCeConnection();
        public static SqlConnection conexionInformacion = new SqlConnection();
        public static SqlConnection conexionCatalogo = new SqlConnection(); 

        public string CadenaConexionPrincipal
        {
            get { return cadenaConexionPrincipal; }
            set { cadenaConexionPrincipal = value; }
        } 
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
            
        public void AbrirConexionPrincipal()
        { 

            //this.cadenaConexionPrincipal = string.Format("Data Source=.\\SQLEXPRESS;AttachDbFilename={0};Integrated Security=True;Connect Timeout=1", this.cadenaConexionPrincipal); Es para los que sean mdf, que se necesiten adjuntar.
            this.cadenaConexionPrincipal = string.Format("Data Source={0};", this.cadenaConexionPrincipal); 
            conexionPrincipal.ConnectionString = this.cadenaConexionPrincipal; 

        }

        public void AbrirConexionInformacion()
        {
            
            this.CadenaConexionInformacion = string.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3}", Logica.DatosEmpresaPrincipal.instanciaSql, this.CadenaConexionInformacion, Logica.DatosEmpresaPrincipal.usuarioSql, Logica.DatosEmpresaPrincipal.contrasenaSql);
            conexionInformacion.ConnectionString = this.CadenaConexionInformacion; 

        }

        public void AbrirConexionCatalogo()
        {

            this.cadenaConexionCatalogo = string.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3}", Logica.DatosEmpresaPrincipal.instanciaSql, this.cadenaConexionCatalogo, Logica.DatosEmpresaPrincipal.usuarioSql, Logica.DatosEmpresaPrincipal.contrasenaSql);
            conexionCatalogo.ConnectionString = this.cadenaConexionCatalogo; 

        }

    }
    
}
