using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Libreria
{
    class ENRespuestaCRUD
    {
        private int id;
        private String texto;
        //private ENUsuarioCRUD autor;
        private DateTime fecha;

        public ENRespuestaCRUD()
        {
            id = 0;
            texto = "";
            //autor = null;
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

        /*public ENUsuarioCRUD Autor
        {
            get { return autor; }
            set { autor = value; }
        }*/

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
    }
}
