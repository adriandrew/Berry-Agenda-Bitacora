using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Registros
    {
         
        private int idEmpresa;
        private int idArea;
        private int idUsuario;
        private int idModulo;
        private string nombreEquipo;
        private bool esSesionIniciada;

        public int IdEmpresa
        {
            get { return idEmpresa; }
            set { idEmpresa = value; }
        }
        public int IdArea
        {
            get { return idArea; }
            set { idArea = value; }
        }
        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }
        public int IdModulo
        {
            get { return idModulo; }
            set { idModulo = value; }
        }
        public string NombreEquipo
        {
            get { return nombreEquipo; }
            set { nombreEquipo = value; }
        }
        public bool EsSesionIniciada
        {
            get { return esSesionIniciada; }
            set { esSesionIniciada = value; }
        }
        
        public void Guardar()
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionInformacion;
                comando.CommandText = "INSERT INTO Registros (IdEmpresa, IdArea, IdUsuario, IdModulo, NombreEquipo, EsSesionIniciada) VALUES (@idEmpresa, @idArea, @idUsuario, @idModulo, @nombreEquipo, @esSesionIniciada)";
                comando.Parameters.AddWithValue("@idEmpresa", this.IdEmpresa);
                comando.Parameters.AddWithValue("@idArea", this.IdArea);
                comando.Parameters.AddWithValue("@idUsuario", this.IdUsuario);
                comando.Parameters.AddWithValue("@idModulo", this.IdModulo);
                comando.Parameters.AddWithValue("@nombreEquipo", this.NombreEquipo);
                comando.Parameters.AddWithValue("@esSesionIniciada", this.EsSesionIniciada);
                BaseDatos.conexionInformacion.Open();
                comando.ExecuteNonQuery();
                BaseDatos.conexionInformacion.Close();
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

        public void Editar()
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionInformacion;
                comando.CommandText = "UPDATE Registros SET IdUsuario=@idUsuario, IdArea=@idArea, IdModulo=@idModulo, EsSesionIniciada=@esSesionIniciada WHERE IdEmpresa=@idEmpresa AND NombreEquipo=@nombreEquipo";
                comando.Parameters.AddWithValue("@idEmpresa", this.IdEmpresa);
                comando.Parameters.AddWithValue("@idArea", this.IdArea);
                comando.Parameters.AddWithValue("@idUsuario", this.IdUsuario);
                comando.Parameters.AddWithValue("@idModulo", this.IdModulo);
                comando.Parameters.AddWithValue("@nombreEquipo", this.NombreEquipo);
                comando.Parameters.AddWithValue("@esSesionIniciada", this.EsSesionIniciada);
                BaseDatos.conexionInformacion.Open();
                comando.ExecuteNonQuery();
                BaseDatos.conexionInformacion.Close();
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

        public void EditarSoloSesion()
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionInformacion;
                comando.CommandText = "UPDATE Registros SET EsSesionIniciada=@esSesionIniciada WHERE IdEmpresa=@idEmpresa AND NombreEquipo=@nombreEquipo";
                comando.Parameters.AddWithValue("@idEmpresa", this.IdEmpresa); 
                comando.Parameters.AddWithValue("@nombreEquipo", this.NombreEquipo);
                comando.Parameters.AddWithValue("@esSesionIniciada", this.EsSesionIniciada);
                BaseDatos.conexionInformacion.Open();
                comando.ExecuteNonQuery();
                BaseDatos.conexionInformacion.Close();
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

        public void Eliminar()
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionInformacion;
                comando.CommandText = "DELETE FROM Registros WHERE IdEmpresa=@idEmpresa AND NombreEquipo=@nombreEquipo";
                comando.Parameters.AddWithValue("@idEmpresa", this.IdEmpresa);
                comando.Parameters.AddWithValue("@nombreEquipo", this.NombreEquipo);
                BaseDatos.conexionInformacion.Open();
                comando.ExecuteNonQuery();
                BaseDatos.conexionInformacion.Close();
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

        public bool ValidarPorIdEmpresaYNombreEquipo()
        {

            try
            {
                bool resultado = false;
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionInformacion;
                comando.CommandText = "SELECT * FROM Registros WHERE IdEmpresa=@idEmpresa AND NombreEquipo=@nombreEquipo";
                comando.Parameters.AddWithValue("@idEmpresa", this.IdEmpresa);
                comando.Parameters.AddWithValue("@nombreEquipo", this.NombreEquipo);
                BaseDatos.conexionInformacion.Open();
                SqlDataReader dataReader = default(SqlDataReader);
                dataReader = comando.ExecuteReader();
                if (dataReader.HasRows)
                {
                    resultado = true;
                }
                else
                {
                    resultado = false;
                }
                BaseDatos.conexionInformacion.Close();
                return resultado;
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

        public bool ValidarSesionPorIdEmpresayNombreEquipo()
        {

            try
            {
                bool resultado = false;
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionInformacion;
                comando.CommandText = "SELECT * FROM Registros WHERE IdEmpresa=@idEmpresa AND NombreEquipo=@nombreEquipo";
                comando.Parameters.AddWithValue("@idEmpresa", this.IdEmpresa);
                comando.Parameters.AddWithValue("@nombreEquipo", this.NombreEquipo);
                BaseDatos.conexionInformacion.Open();
                SqlDataReader dataReader = default(SqlDataReader);
                dataReader = comando.ExecuteReader();
                while (dataReader.Read())
                { 
                    resultado = Convert.ToBoolean(dataReader["EsSesionIniciada"].ToString()); 
                }
                BaseDatos.conexionInformacion.Close();
                return resultado;
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

        public List<Registros> ObtenerPorIdEmpresayNombreEquipo()
        {

            List<Registros> lista = new List<Registros>();
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionInformacion;
                comando.CommandText = "SELECT * FROM Registros WHERE IdEmpresa=@idEmpresa AND NombreEquipo=@nombreEquipo";
                comando.Parameters.AddWithValue("@idEmpresa", this.IdEmpresa);
                comando.Parameters.AddWithValue("@nombreEquipo", this.NombreEquipo);
                BaseDatos.conexionInformacion.Open();
                SqlDataReader dataReader = default(SqlDataReader);
                dataReader = comando.ExecuteReader();
                Registros registro = new Registros();
                while (dataReader.Read())
                {
                    registro = new Registros();
                    registro.idEmpresa = Convert.ToInt32(dataReader["IdEmpresa"]);
                    registro.idArea = Convert.ToInt32(dataReader["IdArea"]);
                    registro.idUsuario = Convert.ToInt32(dataReader["IdUsuario"]);
                    registro.idModulo = Convert.ToInt32(dataReader["IdModulo"]);
                    registro.nombreEquipo = dataReader["NombreEquipo"].ToString();
                    registro.esSesionIniciada = Convert.ToBoolean(dataReader["EsSesionIniciada"].ToString());
                    lista.Add(registro);
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
