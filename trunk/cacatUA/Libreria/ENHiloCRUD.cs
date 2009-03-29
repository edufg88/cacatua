using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Libreria
{
    public class ENHiloCRUD
    {
        private int id;
	    private String titulo;
	    private String texto;
	    //private ENUsuarioCRUD autor;
	    private DateTime fecha;
        private ENCategoriaCRUD categoria;
        private ArrayList respuestas;

        /// <summary>
        /// Constructor por defecto. Crea un hilo vacío.
        /// </summary>
        public ENHiloCRUD ()
        {
            id = 0;
            titulo = "";
            texto = "";
            //autor = null;
            fecha = new DateTime();
            categoria = null;
            respuestas = null;
        }

        public ENHiloCRUD(int id)
        {
            Obtener(id);
        }

        public ENHiloCRUD(String titulo, String texto/*, ENUsuarioCRUD autor*/, DateTime fecha, ENCategoriaCRUD categoria)
        {
            id = 0;
            this.titulo = titulo;
            this.texto = texto;
            //autor = autor;
            this.fecha = fecha;
            this.categoria = categoria;
            respuestas = null;
        }

        public void Obtener(int id)
        {
            ENHiloCRUD auxiliar = HiloCAD.Obtener(id);
            id = auxiliar.id;
            titulo = auxiliar.titulo;
            texto = auxiliar.texto;
            //autor = auxiliar.autor;
            fecha = auxiliar.fecha;
            categoria = auxiliar.categoria;
            respuestas = auxiliar.respuestas;
        }

        /// <summary>
        /// Este método sólo tiene sentido utilizarlo si 'id' es 0. En otro caso, tendría
        /// que utilizarse el método Actualizar.
        /// </summary>
        public void Guardar()
        {
            HiloCAD.Guardar(this);
        }

        public void Borrar()
        {
            HiloCAD.Borrar(this);
        }

        public void Actualizar()
        {
            HiloCAD.Actualizar(this);
        }


        /// <summary>
        /// Identificador del hilo. Sólo se permite su lectura. Si es 0, significa que no está
        /// almacenado en la base de datos.
        /// </summary>
        public int Id
        {
            get { return id; }
        }

        public String Titulo
        {
            get { return titulo; }
            set { titulo = value; }
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

        public ENCategoriaCRUD Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        public ArrayList Respuestas
        {
            get { return respuestas; }
            set { respuestas = value; }
        }
    }
}
