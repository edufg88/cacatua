using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Libreria
{
    /// <summary>
    /// Clase que representa la entidad Mensaje
    /// </summary>
    public class ENMensaje : InterfazEN
    {
        private MensajeCAD mensajeCAD;
        /// <summary>
        /// Id del mensaje
        /// </summary>
        private int id;
        /// <summary>
        /// Emisor del mensaje
        /// </summary>
        private ENUsuario emisor;
        /// <summary>
        /// Texto del mensaje
        /// </summary>
        private string texto;
        /// <summary>
        /// Fecha del mensaje
        /// </summary>
        private DateTime fecha;
        /// <summary>
        /// Receptor del mensaje
        /// </summary>
        private ENUsuario receptor;
        /// <summary>
        /// Indica si el mensaje está leido o no
        /// </summary>
        private int leido;

        /// <summary>
        /// Constructor por defecto de la clase
        /// </summary>
        public ENMensaje()
        {
            mensajeCAD = new MensajeCAD();
            id = 0;
            emisor = new ENUsuario();
            receptor = new ENUsuario();
            fecha = DateTime.Now;
            texto = "";
            leido = 0;
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

        /// <summary>
        /// Constructor sobrecargado de la clase
        /// </summary>
        /// <param name="emisor">Emisor</param>
        /// <param name="texto">Texto</param>
        /// <param name="fecha">Fecha</param>
        /// <param name="receptor">Receptor</param>
        public ENMensaje(string emisor, string texto, DateTime fecha, string receptor)
        {
            ENUsuario em = ENUsuario.Obtener(emisor);
            ENUsuario rec = ENUsuario.Obtener(receptor);
            mensajeCAD = new MensajeCAD();

            this.id = 0;
            this.emisor = em;
            this.receptor = rec;
            this.texto = texto;
            this.Fecha = fecha;
        }

        /// <summary>
        /// Obtiene un mensaje a partir de su id
        /// </summary>
        /// <param name="id">Recibe el id del mensaje a obtener</param>
        /// <returns>Devuelve el mensaje con la id recibida</returns>
        public static ENMensaje Obtener(int id)
        {
            ENMensaje aux = null;
            MensajeCAD mensajeCAD = new MensajeCAD();
            aux = mensajeCAD.ObtenerMensaje(id);

            return aux;
        }

        /// <summary>
        /// Obtiene un mensaje a partir de su emisor o receptor
        /// </summary>
        /// <param name="usuario">Usuario del mensaje</param>
        /// <param name="emisor">Indica si es emisor o no</param>
        /// <returns>Devuelve el mensaje</returns>
        public static ArrayList Obtener(string usuario, bool emisor)
        {
            MensajeCAD mensajeCAD = new MensajeCAD();
            return mensajeCAD.ObtenerMensajes(usuario, emisor);
        }

        /// <summary>
        /// Obtiene todos los mensajes de la BD
        /// </summary>
        /// <returns>Devuelve un ArrayList con el resultado</returns>
        public static ArrayList Obtener()
        {
            MensajeCAD mensajeCAD = new MensajeCAD();
            return mensajeCAD.ObtenerMensajes();
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

        /// <summary>
        /// Actualiza la BD con el mensaje actual
        /// </summary>
        /// <returns>Devuelve true si la operación se ha realizado correctamente, false en caso contrario</returns>
        override public bool Actualizar()
        {
            return mensajeCAD.Actualizar(this);
        }

        /// <summary>
        /// Inserta el mensaje actual en la BD
        /// </summary>
        /// <returns>Devuelve true si la operación se ha realizado correctamente, false en caso contrario</returns>
        override public bool Guardar()
        {
            return mensajeCAD.GuardarMensaje(emisor.Usuario, texto, receptor.Usuario);
        }

        /// <summary>
        /// Borra el mensaje actual de la BD
        /// </summary>
        /// <returns>Devuelve true si la operación se ha realizado correctamente, false en caso contrario</returns>
        override public bool Borrar()
        {
            return mensajeCAD.BorrarMensaje(id);
        }

        /// <summary>
        /// Borra un mensaje con un determinado id
        /// </summary>
        /// <param name="pid">Recibe el id del mensaje a borrar</param>
        /// <returns>Devuelve true si la operación se ha realizado correctamente, false en caso contrario</returns>
        public static bool Borrar(int pid)
        {
            MensajeCAD mensajeCAD = new MensajeCAD();
            return mensajeCAD.BorrarMensaje(pid);
        }

        /// <summary>
        /// Borra todos los mensajes de la BD
        /// </summary>
        public void BorrarMensajes()
        {
            mensajeCAD.BorrarMensajes();
        }

        /// <summary>
        /// Busca un determinado mensaje en la BD
        /// </summary>
        /// <param name="emisor">Emisor</param>
        /// <param name="receptor">Receptor</param>
        /// <param name="fecha">Fecha</param>
        /// <returns>Devuelve un ArrayList con el resultado</returns>
        public ArrayList Buscar(string emisor, string receptor, DateTime fecha)
        {
            return mensajeCAD.BuscarMensaje(emisor, receptor, fecha);
        }

        public static int Cantidad(string usuario)
        {
            MensajeCAD mensajeCAD = new MensajeCAD();
            return mensajeCAD.Cantidad(usuario).Count;
        }

        public static ArrayList ObtenerMensajes(string usuario, bool orden, string ordenar, int pagina, int cantidad)
        {
            MensajeCAD mensajeCAD = new MensajeCAD();
            return mensajeCAD.ObtenerMensajes(usuario, orden, ordenar, pagina, cantidad);
        }

        public int CantidadMensajes(int id)
        {
            return mensajeCAD.CantidadMensajes(id);
        }

        public int CantidadMensajesEnviados(int id)
        {
            return mensajeCAD.CantidadMensajesEnviados(id);
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

        public int Leido
        {
            get { return leido; }
            set { leido = value; }
        }

    }
}
