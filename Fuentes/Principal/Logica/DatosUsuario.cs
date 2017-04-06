using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logica
{
    public class DatosUsuario
    {
        
        private int idEmpresa;
        private int id;
        private string nombre;
        private string contrasena;
        private int nivel;
        private bool accesoTotal;
        private int idArea;

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

        public void ObtenerParametrosInformacionUsuario()
        {

	        string[] parametros = Environment.GetCommandLineArgs().ToArray();
	        if ((parametros.Length > 1)) {
		        int numeracion = 19;
		        this.Id = Convert.ToInt32(parametros[numeracion].Replace("|", " ")); numeracion += 1;
                this.Nombre = parametros[numeracion].Replace("|", " "); numeracion += 1;
                this.Contrasena = parametros[numeracion].Replace("|", " "); numeracion += 1;
                this.Nivel = Convert.ToInt32(parametros[numeracion].Replace("|", " ")); numeracion += 1;
                this.AccesoTotal = Convert.ToBoolean(parametros[numeracion].Replace("|", " ")); numeracion += 1;
                this.IdArea = Convert.ToInt32(parametros[numeracion].Replace("|", " ")); numeracion += 1;
	        }

        }

    }
}
