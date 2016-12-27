using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Programas
    {

        private int idEmpresa;
        private int idModulo;
        private int id;
        private string nombre;        

        public int IdEmpresa
        {
            get { return idEmpresa; }
            set { idEmpresa = value; }
        }
        public int IdModulo
        {
            get { return idModulo; }
            set { idModulo = value; }
        }
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

        public List<Programas> ObtenerListadoDeProgramas()
        {

            List<Programas> lista = new List<Programas>();
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionInformacion;
                comando.CommandText = "SELECT * FROM Programas WHERE IdEmpresa=@idEmpresa";
                comando.Parameters.AddWithValue("@idEmpresa", this.IdEmpresa);
                BaseDatos.conexionInformacion.Open();
                SqlDataReader dataReader = comando.ExecuteReader();
                Programas programas;
                while (dataReader.Read())
                {
                    programas = new Programas();
                    programas.IdEmpresa = Convert.ToInt32(dataReader["IdEmpresa"].ToString());
                    programas.IdModulo = Convert.ToInt32(dataReader["IdModulo"].ToString()); 
                    programas.Id = Convert.ToInt32(dataReader["Id"].ToString());
                    programas.Nombre = dataReader["Nombre"].ToString(); 
                    lista.Add(programas);
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
