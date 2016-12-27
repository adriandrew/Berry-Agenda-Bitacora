using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Modulos
    {

        int id;
        string nombre;
        string prefijo;

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
        public string Prefijo
        {
            get { return prefijo; }
            set { prefijo = value; }
        }

        public List<Modulos> ObtenerListado()
        {

            List<Modulos> lista = new List<Modulos>();
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionInformacion;
                comando.CommandText = "SELECT * FROM Modulos"; 
                BaseDatos.conexionInformacion.Open();
                SqlDataReader dataReader = comando.ExecuteReader();
                Modulos modulos;
                while (dataReader.Read())
                {
                    modulos = new Modulos();
                    modulos.Id = Convert.ToInt32(dataReader["Id"].ToString());
                    modulos.Nombre = dataReader["Nombre"].ToString();
                    modulos.Prefijo = dataReader["Prefijo"].ToString();
                    lista.Add(modulos);
                }
                BaseDatos.conexionInformacion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conexionInformacion.Close();
            }

        }

        public List<Modulos> ObtenerListadoPorId()
        {

            List<Modulos> lista = new List<Modulos>();
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionInformacion;
                comando.CommandText = "SELECT * FROM Modulos WHERE Id=@id";
                comando.Parameters.AddWithValue("@id", this.Id);
                BaseDatos.conexionInformacion.Open();
                SqlDataReader dataReader = comando.ExecuteReader();
                Modulos modulos;
                while (dataReader.Read())
                {
                    modulos = new Modulos();
                    modulos.Id = Convert.ToInt32(dataReader["Id"].ToString());
                    modulos.Nombre = dataReader["Nombre"].ToString();
                    modulos.Prefijo = dataReader["Prefijo"].ToString();
                    lista.Add(modulos);
                }
                BaseDatos.conexionInformacion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conexionInformacion.Close();
            }

        }

    }
}
