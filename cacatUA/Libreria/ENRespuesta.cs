using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Libreria
{
    public class ENRespuesta : InterfazEN
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

        /// <summary>
        /// Obtiene las respuestas de un hilo. Si el hilo no tiene respuestas, se obtiene una lista
        /// de longitud 0. Si ocurre un error, devuelve una lista nula.
        /// </summary>
        /// <param name="hilo">Hilo del que se van a obtener sus respuestas.</param>
        /// <returns>
        /// Devuelve una lista de respuestas (ArrayList de ENRespuesta). Si ocurre un error, esta
        /// lista es null; si no, es una lista con 0 o más elementos.
        /// </returns>
        public static ArrayList Obtener(ENHilo hilo)
        {
            return RespuestaCAD.Instancia.Obtener(hilo);
        }

        /// <summary>
        /// Obtiene las respuestas de un hilo. Si el hilo no tiene respuestas, se obtiene una lista
        /// de longitud 0. Si ocurre un error, devuelve una lista nula.
        /// </summary>
        /// <param name="hilo">Hilo del que se van a obtener sus respuestas.</param>
        /// <returns>
        /// Devuelve una lista de respuestas (ArrayList de ENRespuesta). Si ocurre un error, esta
        /// lista es null; si no, es una lista con 0 o más elementos.
        /// </returns>
        public static ArrayList Obtener(int cantidad, int pagina, ref ENHilo hilo)
        {
            return RespuestaCAD.Instancia.Obtener(cantidad, pagina, ref hilo);
        }

        /// <summary>
        /// Obtiene una respuesta según el identificador indicado.
        /// </summary>
        /// <param name="id">Identificador de la respuesta que se va a obtener.</param>
        /// <returns>Devuelve la respuesta del identificador seleccionado. Si falla, devuelve null.</returns>
        public static ENRespuesta Obtener(int id)
        {
            return RespuestaCAD.Instancia.Obtener(id);
        }

        /// <summary>
        /// Guarda una nueva respuesta en la base de datos. Se supone que esta respuesta no existe en la base de datos.
        /// </summary>
        /// <returns>Devuelve verdadero si se ha insertado correctamente.</returns>
        override public bool Guardar()
        {
            int id = 0;
            if (RespuestaCAD.Instancia.Guardar(this, out id))
            {
                this.id = id;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Borra la respuesta de la base de datos.
        /// </summary>
        /// <returns>
        /// Devuelve verdadero si se ha borrado con éxito o falso si no se ha borrado.
        /// Es posible que no se borre si no existía.
        /// </returns>
        override public bool Borrar()
        {
            if (RespuestaCAD.Instancia.Borrar(id))
            {
                id = 0;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Borra la respuesta de la base de datos.
        /// </summary>
        /// <param name="id">Identificador de la respuesta que se va a borrar.</param>
        /// <returns>
        /// Devuelve verdadero si se ha borrado con éxito o falso si no se ha borrado.
        /// Es posible que no se borre si no existía.
        /// </returns>
        public static bool Borrar(int id)
        {
            if (RespuestaCAD.Instancia.Borrar(id))
            {
                id = 0;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Actualiza una respuesta que ya está creada en la base de datos.
        /// </summary>
        /// <returns>Devuelve verdadero si la respuesta ya existía y ha sido actualizada correctamente. Falso en caso contrario.</returns>
        override public bool Actualizar()
        {
            return RespuestaCAD.Instancia.Actualizar(this);
        }

        /// <summary>
        /// Realiza una consulta a la base de datos para obtener la cantidad de 
        /// respuestas que hay en total en todo el foro.
        /// </summary>
        /// <returns>Devuelve un valor entero con la cantidad de hilos del foro.</returns>
        public static int Cantidad()
        {
            return RespuestaCAD.Instancia.Cantidad();
        }

        /// <summary>
        /// Realiza una consulta a la base de datos para obtener la cantidad de respuestas totales
        /// de un hilo.
        /// </summary>
        /// <returns>Devuelve un valor entero con la cantidad de respuestas del hilo.</returns>
        public static int Cantidad(ENHilo hilo)
        {
            return RespuestaCAD.Instancia.Cantidad(hilo);
        }

        /// <summary>
        /// Realiza una consulta a la base de datos para extraer las respuestas totales
        /// que ha hecho un usuario.
        /// </summary>
        /// <param name="usuario">Usuario del que se van a conocer sus respuestas.</param>
        /// <returns>Devuelve un valor entero con la cantidad de respuestas.</returns>
        public static int Cantidad(ENUsuario usuario)
        {
            return RespuestaCAD.Instancia.Cantidad(usuario);
        }

        /// <summary>
        /// Obtiene la última respuesta de la base de datos.
        /// </summary>
        /// <returns>Devuelve la última respuesta insertada en la base de datos. Si falla, devuelve null.</returns>
        public static ENRespuesta Ultimo()
        {
            return RespuestaCAD.Instancia.Ultimo();
        }

        public ENRespuesta Ultimo(ENHilo hilo)
        {
            return RespuestaCAD.Instancia.Ultimo(hilo);
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
