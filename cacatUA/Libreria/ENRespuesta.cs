using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Libreria
{
    class ENRespuesta
    {
        private int id;
        private String texto;
        private ENUsuario autor;
        private DateTime fecha;

        public ENRespuesta()
        {
            id = 0;
            texto = "";
            autor = null;
            fecha = new DateTime();
        }

        public int Id
        {
            get { return id; }
        }

        public String Texto
        {
            get { return texto; }
            set { texto = value; }
        }

        public ENUsuario Autor
        {
            get { return autor; }
            set { autor = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
    }
}
