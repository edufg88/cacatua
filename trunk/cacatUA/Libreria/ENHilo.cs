using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Libreria
{
    public class ENHilo : InterfazEN
    {
        private int id;
	    private String titulo;
	    private String texto;
	    private ENUsuario autor;
	    private DateTime fecha;
        private ENCategoria categoria;
        private ArrayList respuestas;

        /// <summary>
        /// Constructor por defecto. Crea un hilo vacío.
        /// </summary>
        public ENHilo ()
        {
            id = 0;
            titulo = "";
            texto = "";
            autor = null;
            fecha = new DateTime();
            categoria = null;
            respuestas = null;
        }

        public ENHilo(int id)
        {
            Obtener(id);
        }

        public ENHilo(String titulo, String texto, ENUsuario autor, DateTime fecha, ENCategoria categoria)
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
            return HiloCAD.Instancia.Obtener();
        }

        override public bool Obtener(int id)
        {
            ENHilo auxiliar = HiloCAD.Instancia.Obtener(id);
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
        override public bool Guardar()
        {
            return HiloCAD.Instancia.Guardar(this);
        }

        override public bool Borrar()
        {
            return HiloCAD.Instancia.Borrar(this);
        }

        public static bool Borrar(int id)
        {
            return HiloCAD.Instancia.Borrar(id);
        }

        override public bool Actualizar()
        {
            return HiloCAD.Instancia.Actualizar(this);
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

        public ENUsuario Autor
        {
            get { return autor; }
            set { autor = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public ENCategoria Categoria
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
