using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Libreria
{
    public class ENEncuestaCRUD
    {
        private int id;
        private string pregunta;
        private ENUsuarioCRUD usuario;
        private DateTime fecha;
        private bool activa;

        ENEncuestaCRUD()
        {
            id = 0;
            pregunta = "";
            activa = false;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Pregunta
        {
            get { return pregunta; }
            set { pregunta = value; }
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
        public bool Activa
        {
            get { return activa; }
            set { activa = value; }
        }

    }
}
