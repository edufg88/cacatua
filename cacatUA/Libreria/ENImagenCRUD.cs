using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Libreria
{
    public class ENImagenCRUD
    {
        private int id;
        private string titulo;
        private string descripcion;
        private ENUsuario usuario;
        private string archivo;

        ENImagenCRUD()
        {
            id = 0;
            titulo = "";
            descripcion = "";
            archivo = "";
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Titulo
        {
            get { return Titulo; }
            set { titulo = value; }
        }
        public string Descripcion
        {
            get { return Descripcion; }
            set { descripcion = value; }
        }
        public ENUsuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        public string Archivo
        {
            get { return archivo; }
            set { archivo = value; }
        }
    }
}
