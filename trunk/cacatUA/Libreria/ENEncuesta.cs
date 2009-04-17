using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Libreria
{
    /// <summary>
    /// Clase que representa la entidad Encuesta
    /// </summary>
    public class ENEncuesta : InterfazEN
    {
        /// <summary>
        /// Id de la encuesta
        /// </summary>
        private int id;

        /// <summary>
        /// Pregunta objeto de la encuesta
        /// </summary>
        private string pregunta;

        /// <summary>
        /// Usuario que realiza la encuesta
        /// </summary>
        private ENUsuario usuario;

        /// <summary>
        /// Fecha de la encuesta
        /// </summary>
        private DateTime fecha;

        /// <summary>
        /// Indica si la encuesta está activa o no
        /// </summary>
        private bool activa;


        /// <summary>
        /// Constructor por defecto de la clase
        /// </summary>
        public ENEncuesta()
        {
            id = 0;
            pregunta = "";
            activa = false;
        }

        /*
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
        }*/


        /// <summary>
        /// Constructor sobrecargado de la clase
        /// </summary>
        /// <param name="pregunta">Pregunta objeto de la encuesta</param>
        /// <param name="usuario">Usuario que realiza la encuesta</param>
        /// <param name="fecha">Fecha de la encuesta</param>
        /// <param name="activa">Indica si la encuesta está activa o no</param>
        public ENEncuesta(string pregunta, string usuario, DateTime fecha, bool activa)
        {
            this.id = 0;
            ENUsuario us = ENUsuario.Obtener(usuario);
            this.usuario = us;
            this.pregunta = pregunta;
            this.fecha = fecha;
            this.activa = activa;
        }

        /// <summary>
        /// Obtiene una encuesta a partir de su id
        /// </summary>
        /// <param name="id">Recibe el id de la encuesta a obtener</param>
        /// <returns>Devuelve la encuesta cuyo id se recibe</returns>
        public static ENEncuesta Obtener(int id)
        {
            ENEncuesta aux = null;
            aux = EncuestaCAD.Instancia.ObtenerEncuesta(id);

            return aux;
        }

        /// <summary>
        /// Obtiene todas las encuestas 
        /// </summary>
        /// <returns></returns>
        public static ArrayList Obtener()
        {
            return EncuestaCAD.Instancia.ObtenerEncuestas();
        }

        /*
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
        }*/

        /// <summary>
        /// Actualiza la BD con la encuesta actual
        /// </summary>
        /// <returns>Devuelve true si la operación se ha realizado correctamente, false en caso contrario</returns>
        override public bool Actualizar()
        {
            return EncuestaCAD.Instancia.Actualizar(this);
        }

        /// <summary>
        /// Inserta la encuesta en la BD
        /// </summary>
        /// <returns>Devuelve true si la operación se ha realizado correctamente, false en caso contrario</returns>
        override public bool Guardar()
        {
            return EncuestaCAD.Instancia.GuardarEncuesta(pregunta, usuario.Usuario, fecha, activa);
        }

        /// <summary>
        /// Borra la encuesta de la BD
        /// </summary>
        /// <returns>Devuelve true si la operación se ha realizado correctamente, false en caso contrario</returns>
        override public bool Borrar()
        {
            return EncuestaCAD.Instancia.BorrarEncuesta(id);
        }

        /// <summary>
        /// Borra la encuesta con un id determinado de la BD
        /// </summary>
        /// <param name="pid">Recibe el id de la encuesta a borrar</param>
        /// <returns>Devuelve true si la operación se ha realizado correctamente, false en caso contrario</returns>
        public static bool Borrar(int pid)
        {
            return EncuestaCAD.Instancia.BorrarEncuesta(pid);
        }

        /// <summary>
        /// Borra todas las encuestas de la BD
        /// </summary>
        public void BorrarEncuestas()
        {
            EncuestaCAD.Instancia.BorrarEncuestas();
        }

        /// <summary>
        /// Busca una determinada encuesta por su pregunta y su fecha
        /// </summary>
        /// <param name="asunto">Pregunta de la encuesta</param>
        /// <param name="fecha">Fecha de la encuesta</param>
        /// <returns>Devuelve un ArrayList con el resultado de la búsqueda</returns>
        public ArrayList Buscar(string asunto, DateTime fecha)
        {
            return EncuestaCAD.Instancia.BuscarEncuesta(asunto, fecha);
        }

        /// <summary>
        /// Busca las encuestas de un determinado usuario
        /// </summary>
        /// <param name="usuario">Usuario de las encuestas</param>
        /// <returns>Devuelve un ArrayList con el resultado de la búsqueda</returns>
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
