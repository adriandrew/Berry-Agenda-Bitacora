using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class EmpresasPrincipal
    {

        private int idEmpresa;
        private bool activa;
        private string instanciaSql;
        private string rutaBd;
        private string usuarioSql; 
        private string contrasenaSql;

        public int IdEmpresa
        {
            get { return this.idEmpresa; }
            set { this.idEmpresa = value; }
        }
        public bool Activa
        {
            get { return this.activa; }
            set { this.activa = value; }
        }
        public string InstanciaSql
        {
            get { return this.instanciaSql; }
            set { this.instanciaSql = value; }
        }
        public string RutaBd
        {
            get { return rutaBd; }
            set { rutaBd = value; }
        }
        public string UsuarioSql
        {
            get { return usuarioSql; }
            set { usuarioSql = value; }
        }
        public string ContrasenaSql
        {
            get { return contrasenaSql; }
            set { contrasenaSql = value; }
        }

        public List<EmpresasPrincipal> ObtenerPredeterminada()
        {

            List<EmpresasPrincipal> lista = new List<EmpresasPrincipal>();
            bool conexionCorrecta = false;
            while (!conexionCorrecta)
            { 
                try
                {
                    SqlCeCommand comando = new SqlCeCommand();
                    comando.Connection = BaseDatos.conexionPrincipal;
                    comando.CommandText = "SELECT * FROM Empresas WHERE Activa='TRUE'";
                    BaseDatos.conexionPrincipal.Open(); 
                    SqlCeDataReader dataReader = default(SqlCeDataReader);
                    dataReader = comando.ExecuteReader();
                    EmpresasPrincipal empresasPrincipal;
                    while ((dataReader.Read()))
                    {
                        empresasPrincipal = new EmpresasPrincipal();
                        empresasPrincipal.IdEmpresa = Convert.ToInt32(dataReader["IdEmpresa"]);
                        empresasPrincipal.Activa = Convert.ToBoolean(dataReader["Activa"].ToString());
                        empresasPrincipal.InstanciaSql = dataReader["InstanciaSql"].ToString();
                        empresasPrincipal.RutaBd = dataReader["RutaBd"].ToString();
                        empresasPrincipal.UsuarioSql = dataReader["UsuarioSql"].ToString();
                        empresasPrincipal.ContrasenaSql = dataReader["ContrasenaSql"].ToString();
                        lista.Add(empresasPrincipal);
                    }
                    BaseDatos.conexionPrincipal.Close();
                    conexionCorrecta = true;
                    //return lista;
                }
                catch (SqlCeException ex)
                {
                    if (ex.NativeError == 25035)
                    {
                        conexionCorrecta = false;
                    }
                    else
                    {
                        conexionCorrecta = true;
                        throw ex;
                    }
                }
                catch(Exception ex)
                {
                    conexionCorrecta = true;
                    throw ex; 
                }
                finally
                {
                    BaseDatos.conexionPrincipal.Close();
                }
            }
            return lista;

        }

    }
}
