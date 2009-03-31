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
	    private ENUsuarioCRUD autor;
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
            autor = null;
            fecha = new DateTime();
            categoria = null;
            respuestas = null;
        }

        public ENHiloCRUD(int id)
        {
            Obtener(id);
        }

        public ENHiloCRUD(String titulo, String texto, ENUsuarioCRUD autor, DateTime fecha, ENCategoriaCRUD categoria)
        {
            id = 0;
            this.titulo = titulo;
            this.texto = texto;
            this.autor = autor;
            this.fecha = fecha;
            this.categoria = categoria;
            respuestas = null;
        }

        public static ArrayList Obtener()
        {
            return HiloCAD.Obtener();
        }

        public bool Obtener(int id)
        {
            ENHiloCRUD auxiliar = HiloCAD.Obtener(id);
            if (auxiliar != null)
            {
                this.id = auxiliar.id;
                titulo = auxiliar.titulo;
                texto = auxiliar.texto;
                autor = auxiliar.autor;
                fecha = auxiliar.fecha;
                categoria = auxiliar.categoria;
                respuestas = auxiliar.respuestas;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Este método sólo tiene sentido utilizarlo si 'id' es 0. En otro caso, tendría
        /// que utilizarse el método Actualizar.
        /// </summary>
        public bool Guardar()
        {
            return HiloCAD.Guardar(this);
        }

        public bool Borrar()
        {
            return HiloCAD.Borrar(this);
        }

        public static bool Borrar(int id)
        {
            return HiloCAD.Borrar(id);
        }

        public bool Actualizar()
        {
            return HiloCAD.Actualizar(this);
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
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

        public ENUsuarioCRUD Autor
        {
            get { return autor; }
            set { autor = value; }
        }

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
