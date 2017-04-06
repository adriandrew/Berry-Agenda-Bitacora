using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class UsuariosAreas
    {

        private int idEmpresa;
        private int id;
        private string nombre;
        private string contrasena;
        private int nivel;
        private bool accesoTotal;
        private int idArea;
        private string nombreArea;

        public int IdEmpresa
        {
            get { return idEmpresa; }
            set { idEmpresa = value; }
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
        public string Contrasena
        {
            get { return contrasena; }
            set { contrasena = value; }
        }
        public int Nivel
        {
            get { return nivel; }
            set { nivel = value; }
        }
        public bool AccesoTotal
        {
            get { return accesoTotal; }
            set { accesoTotal = value; }
        }
        public int IdArea
        {
            get { return idArea; }
            set { idArea = value; }
        }
        public string NombreArea
        {
            get { return nombreArea; }
            set { nombreArea = value; }
        }

        public List<UsuariosAreas> ObtenerListadoPorEmpresa()
        {

            List<UsuariosAreas> lista = new List<UsuariosAreas>();
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionInformacion;
                comando.CommandText = "SELECT U.*, A.Nombre AS NombreArea FROM Usuarios AS U LEFT JOIN Catalogos.dbo.Areas AS A ON U.IdArea=A.Id WHERE U.IdEmpresa=@idEmpresa";
                comando.Parameters.AddWithValue("@idEmpresa", this.IdEmpresa);
                BaseDatos.conexionInformacion.Open();
                SqlDataReader dataReader = comando.ExecuteReader();
                UsuariosAreas usuarios;
                while (dataReader.Read())
                {
                    usuarios = new UsuariosAreas();
                    usuarios.IdEmpresa = Convert.ToInt32(dataReader["IdEmpresa"].ToString());
                    usuarios.Id = Convert.ToInt32(dataReader["Id"].ToString());
                    usuarios.Nombre = dataReader["Nombre"].ToString();
                    usuarios.Contrasena = dataReader["Contrasena"].ToString();
                    usuarios.Nivel = Convert.ToInt32(dataReader["Nivel"].ToString());
                    usuarios.AccesoTotal = Convert.ToBoolean(dataReader["AccesoTotal"].ToString());
                    usuarios.IdArea = Convert.ToInt32(dataReader["IdArea"].ToString());
                    usuarios.NombreArea = dataReader["NombreArea"].ToString();
                    lista.Add(usuarios);
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
