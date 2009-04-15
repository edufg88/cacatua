using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Libreria
{
    public class ENMensaje : InterfazEN
    {
        private int id;
        private ENUsuario emisor;
        private string texto;
        private DateTime fecha;
        private ENUsuario receptor;

        public ENMensaje()
        {
            id = 0;
            emisor = new ENUsuario();
            receptor = new ENUsuario();
            fecha = DateTime.Now;
            texto = "";
        }

        /*
        public ENMensaje(int id)
        {
            ENMensaje aux = MensajeCAD.Instancia.ObtenerMensaje(id);

            if (aux == null)
            {
                aux = new ENMensaje();
            }

            this.id = aux.id;
            this.emisor = aux.emisor;
            this.texto = aux.texto;
            this.fecha = aux.fecha;
            this.receptor = aux.receptor;
        }
        */

        public ENMensaje(string emisor, string texto, DateTime fecha, string receptor)
        {
            ENUsuario em = ENUsuario.Obtener(emisor);
            ENUsuario rec = ENUsuario.Obtener(receptor);

            this.id = 0;
            this.emisor = em;
            this.receptor = rec;
            this.texto = texto;
            this.Fecha = fecha;
        }

        public static ENMensaje Obtener(int id)
        {
            ENMensaje aux = null;
            aux = MensajeCAD.Instancia.ObtenerMensaje(id);

            return aux;
        }

        public static ENMensaje Obtener(string usuario, bool emisor)
        {
            ENMensaje aux = null;
            aux = MensajeCAD.Instancia.ObtenerMensaje(usuario, emisor);

            return aux;
        }

        public static ArrayList Obtener()
        {
            return MensajeCAD.Instancia.ObtenerMensajes();
        }

        /*
        public bool Obtener(int id)
        {
            ENMensaje aux = new ENMensaje();
            aux = MensajeCAD.Instancia.ObtenerMensaje(id);

            if (aux != null)
            {
                this.id = aux.id;
                this.emisor = aux.emisor;
                this.texto = aux.texto;
                this.fecha = aux.fecha;
                this.receptor = aux.receptor;

                return true;
            }
            else
            {
                return false;
            }
        }*/
        /*
        public bool Obtener(string nombre, bool emisor)
        {
            ENMensaje aux = null;
            aux = MensajeCAD.Instancia.ObtenerMensaje(nombre, emisor);

            this.id = aux.id;
            this.emisor = aux.emisor;
            this.texto = aux.texto;
            this.fecha = aux.fecha;
            this.receptor = aux.receptor;

            if (aux == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }*/

        override public bool Actualizar()
        {
            return MensajeCAD.Instancia.Actualizar(this);
        }

        override public bool Guardar()
        {
            return MensajeCAD.Instancia.GuardarMensaje(emisor.Usuario, texto, fecha, receptor.Usuario);
        }

        override public bool Borrar()
        {
            return MensajeCAD.Instancia.BorrarMensaje(id);
        }

        public static bool Borrar(int pid)
        {
            return MensajeCAD.Instancia.BorrarMensaje(pid);
        }

        public void BorrarFirmas()
        {
            MensajeCAD.Instancia.BorrarMensajes();
        }

        public ArrayList Buscar(string emisor, string receptor, DateTime fecha)
        {
            return MensajeCAD.Instancia.BuscarMensaje(emisor, receptor, fecha);
        }

        public int Cantidad()
        {
            return MensajeCAD.Instancia.CantidadMensajes();
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
