using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Libreria
{
    public class ENEncuesta : InterfazEN
    {
        private int id;
        private string pregunta;
        private ENUsuario usuario;
        private DateTime fecha;
        private bool activa;

        public ENEncuesta()
        {
            id = 0;
            pregunta = "";
            activa = false;
        }

        public ENEncuesta(int id)
        {
            ENEncuesta aux = EncuestaCAD.Instancia.ObtenerEncuesta(id);

            if (aux == null)
            {
                aux = new ENEncuesta();
            }

            this.id = aux.id;
            this.pregunta = aux.pregunta;
            this.usuario = aux.usuario;
            this.fecha = aux.fecha;
            this.activa = aux.activa;
        }

        public ENEncuesta(string pregunta, string usuario, DateTime fecha, bool activa)
        {
            this.id = 0;
            ENUsuario us = new ENUsuario(usuario);
            this.usuario = us;
            this.pregunta = pregunta;
            this.fecha = fecha;
            this.activa = activa;
        }

        public static ArrayList Obtener()
        {
            return EncuestaCAD.Instancia.ObtenerEncuestas();
        }

        public bool Obtener(int id)
        {
            ENEncuesta aux = new ENEncuesta();
            aux = EncuestaCAD.Instancia.ObtenerEncuesta(id);

            if (aux != null)
            {
                this.id = aux.id;
                this.pregunta = aux.pregunta;
                this.usuario = aux.usuario;
                this.fecha = aux.fecha;
                this.activa = aux.activa;

                return true;
            }
            else
            {
                return false;
            }
        }

        override public bool Actualizar()
        {
            return EncuestaCAD.Instancia.Actualizar(this);
        }

        override public bool Guardar()
        {
            return EncuestaCAD.Instancia.GuardarEncuesta(pregunta, usuario.Usuario, fecha, activa);
        }

        override public bool Borrar()
        {
            return EncuestaCAD.Instancia.BorrarEncuesta(id);
        }

        public static bool Borrar(int pid)
        {
            return EncuestaCAD.Instancia.BorrarEncuesta(pid);
        }

        public void BorrarEncuestas()
        {
            EncuestaCAD.Instancia.BorrarEncuestas();
        }

        public ArrayList Buscar(string asunto, DateTime fecha)
        {
            return EncuestaCAD.Instancia.BuscarEncuesta(asunto, fecha);
        }

        public ArrayList Buscar(int usuario)
        {
            return EncuestaCAD.Instancia.BuscarEncuesta(usuario);
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
        public ENUsuario Usuario
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
