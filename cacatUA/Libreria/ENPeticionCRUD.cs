using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Libreria
{
    public class ENPeticionCRUD
    {
        private int id;
        private string asunto;
        private string texto;
        private ENUsuarioCRUD usuario;
        private DateTime fecha;
        private bool contestada;

        ENPeticionCRUD()
        {
            id = 0;
            asunto = "";
            texto = "";
            contestada = false;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Asunto
        {
            get { return asunto; }
            set { asunto = value; }
        }
        public string Texto
        {
            get { return texto; }
            set { texto = value; }
        }
        public ENUsuarioCRUD Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public bool Contestada
        {
            get { return contestada; }
            set { contestada = true; }
        }
    }
}
