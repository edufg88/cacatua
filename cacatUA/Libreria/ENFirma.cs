using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Libreria
{
    /// <summary>
    /// Clase que representa la entidad Firma
    /// </summary>
    public class ENFirma : InterfazEN
    {
        /// <summary>
        /// ID de la firma
        /// </summary>
        private int id;
        /// <summary>
        /// Puntero al usuario emisor
        /// </summary>
        private ENUsuario emisor;
        /// <summary>
        /// Texto de la firma
        /// </summary>
        private string texto;
        /// <summary>
        /// Fecha de creación de la fecha
        /// </summary>
        private DateTime fecha;
        /// <summary>
        /// Puntero al usuario receptor
        /// </summary>
        private ENUsuario receptor;

        /// <summary>
        /// Constructor por defecto. Crea una firma vacía
        /// </summary>
        public ENFirma()
        {
            id = 0;
            emisor = new ENUsuario();
            receptor = new ENUsuario();
            fecha = DateTime.Now;
            texto = "";
        }

        /*
        public ENFirma(int id)
        {
            ENFirma aux = FirmaCAD.Instancia.ObtenerFirma(id);

            if (aux == null)
            {
                aux = new ENFirma();
            }

            this.id = aux.id;
            this.emisor = aux.emisor;
            this.texto = aux.texto;
            this.fecha = aux.fecha;
            this.receptor = aux.receptor;
        }*/

        /// <summary>
        /// Constructor sobrecargado
        /// </summary>
        /// <param name="emisor">Emisor de la firma</param>
        /// <param name="texto">Texto de la firma</param>
        /// <param name="fecha">Fecha de la firma</param>
        /// <param name="receptor">Receptor de la firma</param>
        public ENFirma(string emisor, string texto, DateTime fecha, string receptor)
        {
            ENUsuario em = ENUsuario.Obtener(emisor);
            ENUsuario rec = ENUsuario.Obtener(receptor);

            this.id = 0;
            this.emisor = em;
            this.receptor = rec;
            this.texto = texto;
            this.Fecha = fecha;
        }

        /// <summary>
        /// Obtiene una firma a partir de su ID
        /// </summary>
        /// <param name="id">Recibe el id de la firma en cuestión</param>
        /// <returns>Devuelve una firma si existe el id, null en caso contrario</returns>
        public static ENFirma Obtener(int id)
        {
            ENFirma aux = null;
            aux = FirmaCAD.Instancia.ObtenerFirma(id);

            return aux;
        }

        /// <summary>
        /// Obtiene una firma a partir del emisor o receptor
        /// </summary>
        /// <param name="usuario">Usuario de la firma</param>
        /// <param name="emisor">Indica si el usuario es emisor o no</param>
        /// <returns>Devuelve una firma si existe una firma con el usuario recibido, null en caso contrario</returns>
        public static ENFirma Obtener(string usuario, bool emisor)
        {
            ENFirma aux = null;
            aux = FirmaCAD.Instancia.ObtenerFirma(usuario, emisor);

            return aux;
        }

        public static ArrayList ObtenerFirmas(string usuario, bool emisor)
        {
            return FirmaCAD.Instancia.ObtenerFirmas(usuario, emisor);
        }

        /// <summary>
        /// Obtiene todas las firmas
        /// </summary>
        /// <returns>Devuelve un ArrayList con todas las firmas</returns>
        public static ArrayList Obtener()
        {
            return FirmaCAD.Instancia.ObtenerFirmas();
        }

        /*
        public bool Obtener(int id)
        {
            ENFirma aux = new ENFirma();
            aux = FirmaCAD.Instancia.ObtenerFirma(id);

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
            ENFirma aux = null;
            aux = FirmaCAD.Instancia.ObtenerFirma(nombre, emisor);

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
        /// Actualiza la BD con la firma actual
        /// </summary>
        /// <returns>Devuelve true si se ha realizado correctamente, false en caso contrario</returns>
        override public bool Actualizar()
        {
            return FirmaCAD.Instancia.Actualizar(this);
        }

        /// <summary>
        /// Inserta la firma en la BD
        /// </summary>
        /// <returns>Devuelve true si se ha realizado correctamente, false en caso contrario</returns>
        override public bool Guardar()
        {
            return FirmaCAD.Instancia.GuardarFirma(emisor.Usuario, texto, receptor.Usuario);
        }

        /// <summary>
        /// Borra la firma de la BD
        /// </summary>
        /// <returns>Devuelve true si se ha realizado correctamente, false en caso contrario</returns>
        override public bool Borrar()
        {
            return FirmaCAD.Instancia.BorrarFirma(id);
        }

        /// <summary>
        /// Borra la firma con un id determinado de la BD
        /// </summary>
        /// <param name="pid">Recibe el id de la firma a borrar</param>
        /// <returns>Devuelve true si la operación se ha realizado correctamente, false en caso contrario</returns>
        public static bool Borrar(int pid)
        {
            return FirmaCAD.Instancia.BorrarFirma(pid);
        }

        /// <summary>
        /// Borra todas las firmas de la BD
        /// </summary>
        public void BorrarFirmas()
        {
            FirmaCAD.Instancia.BorrarFirmas();
        }

        /// <summary>
        /// Busca una firma o firmas con determinados parámetros
        /// </summary>
        /// <param name="emisor">Emisor de la firma</param>
        /// <param name="receptor">Receptor de la firma</param>
        /// <param name="fecha">Fecha de la firma</param>
        /// <returns></returns>
        public ArrayList Buscar(string emisor, string receptor, DateTime fecha)
        {
            return FirmaCAD.Instancia.BuscarFirma(emisor, receptor, fecha);
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
