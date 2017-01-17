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
         
    }
}
