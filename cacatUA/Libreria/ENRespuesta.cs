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
        private ENHilo hilo;

        public ENRespuesta()
        {
            id = 0;
            texto = "";
            autor = null;
            hilo = null;
            fecha = new DateTime();
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
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

        public ENHilo Hilo
        {
            get { return hilo; }
            set { hilo = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
    }
}
