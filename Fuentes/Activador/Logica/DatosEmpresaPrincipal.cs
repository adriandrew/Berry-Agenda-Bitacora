using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logica
{

    public class DatosEmpresaPrincipal
    { 

        public static int idEmpresa;
        public static bool activa;
        public static string instanciaSql;
        public static string rutaBd;
        public static string usuarioSql;
        public static string contrasenaSql;  

        public static void ObtenerParametrosInformacionEmpresa()
        {

	        string[] parametros = Environment.GetCommandLineArgs().ToArray();
	        if (parametros.Length > 1) {
		        int numeracion = 1;
		        idEmpresa = Funciones.ValidarNumero(parametros[numeracion].Replace("|", " ")); numeracion += 1;
		        activa = Convert.ToBoolean(Funciones.ValidarNumero(parametros[numeracion].Replace("|", " "))); numeracion += 1;
		        instanciaSql = Funciones.ValidarLetra(parametros[numeracion].Replace("|", " ")); numeracion += 1;
		        rutaBd = Funciones.ValidarLetra(parametros[numeracion].Replace("|", " ")); numeracion += 1;
		        usuarioSql = Funciones.ValidarLetra(parametros[numeracion].Replace("|", " ")); numeracion += 1;
		        contrasenaSql = Funciones.ValidarLetra(parametros[numeracion].Replace("|", " ")); numeracion += 1;
	        }

        }

    }

}
