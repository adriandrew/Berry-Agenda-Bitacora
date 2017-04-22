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

        public List<Areas> ObtenerListadoPorId()
        {

            List<Areas> lista = new List<Areas>();
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionCatalogo;
                comando.CommandText = "SELECT * FROM Areas WHERE Id = @id";
                comando.Parameters.AddWithValue("@id", this.id);
                BaseDatos.conexionCatalogo.Open();
                SqlDataReader dataReader = default(SqlDataReader);
                dataReader = comando.ExecuteReader();
                Areas areas = new Areas();
                while ((dataReader.Read()))
                {
                    areas = new Areas();
                    areas.id = Convert.ToInt32(dataReader["Id"]);
                    areas.nombre = dataReader["Nombre"].ToString();
                    areas.clave = dataReader["Clave"].ToString();
                    lista.Add(areas);
                }
                BaseDatos.conexionCatalogo.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conexionCatalogo.Close();
            }

        }

        public List<Areas> ObtenerListado()
        {

            List<Areas> lista = new List<Areas>();
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionCatalogo;
                comando.CommandText = "SELECT * FROM Areas";
                BaseDatos.conexionCatalogo.Open();
                SqlDataReader dataReader = default(SqlDataReader);
                dataReader = comando.ExecuteReader();
                Areas areas = new Areas();
                while ((dataReader.Read()))
                {
                    areas = new Areas();
                    areas.id = Convert.ToInt32(dataReader["Id"]);
                    areas.nombre = dataReader["Nombre"].ToString();
                    areas.clave = dataReader["Clave"].ToString();
                    lista.Add(areas);
                }
                BaseDatos.conexionCatalogo.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conexionCatalogo.Close();
            }

        }

    }
}
