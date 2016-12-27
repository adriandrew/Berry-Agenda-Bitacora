using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class BloqueoUsuarios
    {

        private int idEmpresa;
        private int idUsuario;        
        private int idModulo;
        private int idPrograma;
        private int idSubPrograma;

        public int IdEmpresa
        {
            get { return idEmpresa; }
            set { idEmpresa = value; }
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
        public int IdPrograma
        {
            get { return idPrograma; }
            set { idPrograma = value; }
        }
        public int IdSubPrograma
        {
            get { return idSubPrograma; }
            set { idSubPrograma = value; }
        }

        public void Guardar()
        {

            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionInformacion;
                comando.CommandText = "INSERT INTO BloqueoUsuarios (IdEmpresa, IdUsuario, IdModulo, IdPrograma, IdSubPrograma) VALUES (@idEmpresa, @idUsuario, @idModulo, @idPrograma, @idSubPrograma)";
                comando.Parameters.AddWithValue("@idEmpresa", this.IdEmpresa);
                comando.Parameters.AddWithValue("@idUsuario", this.IdUsuario);
                comando.Parameters.AddWithValue("@idModulo", this.IdModulo);
                comando.Parameters.AddWithValue("@idPrograma", this.IdPrograma);
                comando.Parameters.AddWithValue("@idSubPrograma", this.IdSubPrograma);
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
                comando.CommandText = "DELETE FROM BloqueoUsuarios WHERE IdEmpresa=@idEmpresa AND IdUsuario=@idUsuario AND IdModulo=@idModulo AND IdPrograma=@idPrograma AND IdSubPrograma=@idSubPrograma";
                comando.Parameters.AddWithValue("@idEmpresa", this.IdEmpresa);
                comando.Parameters.AddWithValue("@idUsuario", this.IdUsuario);
                comando.Parameters.AddWithValue("@idModulo", this.IdModulo);
                comando.Parameters.AddWithValue("@idPrograma", this.IdPrograma);
                comando.Parameters.AddWithValue("@idSubPrograma", this.IdSubPrograma);
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

        public bool Obtener()
        {

            try
            {
                bool resultado = false;
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionInformacion;
                comando.CommandText = "SELECT * FROM BloqueoUsuarios WHERE IdEmpresa=@idEmpresa AND IdUsuario=@idUsuario AND IdModulo=@idModulo AND IdPrograma=@idPrograma";
                comando.Parameters.AddWithValue("@idEmpresa", this.IdEmpresa);
                comando.Parameters.AddWithValue("@idUsuario", this.IdUsuario);
                comando.Parameters.AddWithValue("@idModulo", this.IdModulo);
                comando.Parameters.AddWithValue("@idPrograma", this.IdPrograma);
                BaseDatos.conexionInformacion.Open();
                SqlDataReader dataReader = comando.ExecuteReader();
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

        public bool ValidarPorNumero()
        {

            try
            {
                bool resultado = false;
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionInformacion;
                comando.CommandText = "SELECT * FROM BloqueoUsuarios WHERE IdEmpresa=@idEmpresa AND IdUsuario=@idUsuario AND IdModulo=@idModulo AND IdPrograma=@idPrograma";
                comando.Parameters.AddWithValue("@idEmpresa", this.IdEmpresa);
                comando.Parameters.AddWithValue("@idUsuario", this.IdUsuario);
                comando.Parameters.AddWithValue("@idModulo", this.IdModulo);
                comando.Parameters.AddWithValue("@idPrograma", this.IdPrograma);
                BaseDatos.conexionInformacion.Open();
                SqlDataReader dataReader = comando.ExecuteReader();
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

    }
}
