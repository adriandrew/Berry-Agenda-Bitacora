using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Areas
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

        public string ObtenerListadoPorId()
        {

            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionCatalogo;
                comando.CommandText = "SELECT * FROM Areas WHERE Id=@id";
                comando.Parameters.AddWithValue("@id", this.Id);
                BaseDatos.conexionCatalogo.Open();
                SqlDataReader dataReader = default(SqlDataReader);
                dataReader = comando.ExecuteReader(); 
                while ((dataReader.Read()))
                { 
                    this.Id = Convert.ToInt32(dataReader["Id"]);
                    this.Nombre = dataReader["Nombre"].ToString();
                    this.Clave = dataReader["Clave"].ToString(); 
                }
                BaseDatos.conexionCatalogo.Close();
                return this.Id + "|" + this.Nombre + "|" + this.Clave;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
