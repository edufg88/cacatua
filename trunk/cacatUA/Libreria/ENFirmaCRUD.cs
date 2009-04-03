using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Libreria
{
    public class ENFirmaCRUD
    {
        private int id;
        private ENUsuario emisor;
        private string texto;
        private DateTime fecha;
        private ENUsuario receptor;

        ENFirmaCRUD()
        {
            id = 0;
            texto = "";
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public ENUsuario Emisor
        {
            get { return emisor; }
            set { emisor = value; }
        }
        public string Texto
        {
            get { return texto; }
            set { texto = value; }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public ENUsuario Receptor
        {
            get { return receptor; }
            set { receptor = value; }
        }
    }
}
