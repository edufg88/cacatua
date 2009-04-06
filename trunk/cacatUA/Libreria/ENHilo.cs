﻿using System;
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
        }

        /// <summary>
        /// Crea un hilo obteniéndolo desde la base de datos según el identificador indicado
        /// en los parámetros.
        /// </summary>
        /// <param name="id">Identificador (id) del hilo que se va a crear.</param>
        public ENHilo(int id)
        {
            Obtener(id);
        }

        /// <summary>
        /// Constructor sobrecargado que crea un hilo con los parámetros indicados. Hasta que no se guarde
        /// el hilo, su identificador es 0.
        /// </summary>
        /// <param name="titulo">Título del hilo.</param>
        /// <param name="texto">Texto del hilo.</param>
        /// <param name="autor">Autor del hilo.</param>
        /// <param name="categoria">Categoría del hilo.</param>
        public ENHilo(String titulo, String texto, ENUsuario autor, ENCategoria categoria)
        {
            id = 0;
            this.titulo = titulo;
            this.texto = texto;
            this.autor = autor;
            this.fecha = DateTime.Now;
            this.categoria = categoria;
        }

        /// <summary>
        /// Obtiene una lista con todos los hilos del foro.
        /// </summary>
        /// <returns>Devuelve una lista de hilos (ArrayList de ENHilo).</returns>
        public static ArrayList Obtener()
        {
            return HiloCAD.Instancia.Obtener();
        }

        /// <summary>
        /// Obtiene una lista de hilos (ArrayList de ENHilo) indicando el número de página y la cantidad de
        /// hilos por página. También es necesario especificar el identificador (id) del hilo desde el que se
        /// va a empezar a contar.
        /// </summary>
        /// <param name="pagina">Número de página.</param>
        /// <param name="cantidad">Cantidad de hilos en cada página.</param>
        /// <param name="ultimoId">Identificador del último hilo que se devolvió.</param>
        /// <returns>Devuelve una lista de hilos (ArrayList de ENHilo).</returns>
        public static ArrayList Obtener(int pagina, int cantidad, int ultimoId)
        {
            return HiloCAD.Instancia.Obtener(pagina, cantidad, ultimoId);
        }

        /// <summary>
        /// Obtiene una lista de hilos (ArrayList de ENHilo) según un filtro de búsqueda. Es necesario
        /// indicar un número de página, la cantidad de elementos por página y un identificador desde el que se van a 
        /// obtener los hilos.
        /// Sólo devuelve aquellos hilos que coincidan con el título especificado, texto especificado, etc.
        /// Si se especifican con cadena vacía, todos los hilos son coincidentes.
        /// </summary>
        /// <param name="pagina">Número de página.</param>
        /// <param name="cantidad">Cantidad de hilos en cada página.</param>
        /// <param name="ultimoId">Identificador del último hilo que se devolvió.</param>
        /// <param name="titulo">Título para el filtro de búsqueda.</param>
        /// <param name="texto">Texto para el filtro de búsqueda.</param>
        /// <param name="autor">Autor para el filtro de búsqueda.</param>
        /// <param name="fechaInicio">Fecha de inicio par el filtro de búsqueda.</param>
        /// <param name="fechaFin">Fecha de fin para el filtro de búsqueda.</param>
        /// <param name="categoria">Categoria para el filtro de búsqueda.</param>
        /// <returns>Devuelve una lista de hilos (ArrayList de ENHilo).</returns>
        public static ArrayList Obtener(int pagina, int cantidad, int ultimoId, String titulo, String texto
            , ref ENUsuario autor, ref DateTime fechaInicio, ref DateTime fechaFin, ref ENCategoria categoria)
        {
            return HiloCAD.Instancia.Obtener(pagina, cantidad, ultimoId, titulo, texto, ref autor,
                ref fechaInicio, ref fechaFin, ref categoria);
        }

        /// <summary>
        /// Extrae el hilo que se corresponde al identificador desde la base de datos
        /// y lo asigna al ENHilo que invocó el método.
        /// </summary>
        /// <param name="id">Identificador del hilo que se va a extraer desde la base de datos.</param>
        /// <returns>Devuelve verdadero si se ha obtenido correctamente.</returns>
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
                return true;
            }
            else
            {
                this.id = 0;
            }
            return false;
        }

        /// <summary>
        /// Obtiene un hilo desde la base de datos. Si no se encuentra el hilo especificado,
        /// devuelve un objeto nulo (null).
        /// </summary>
        /// <param name="id">Identificador del hilo que se quiere obtener.</param>
        /// <returns>Devuelve un hilo si existe, o un valor nulo (null) si no existe.</returns>
        public static ENHilo Obtener2(int id)
        {
            return HiloCAD.Instancia.Obtener(id);
        }

        /// <summary>
        /// Guarda el nuevo hilo en la base de datos.
        /// Este método sólo tiene sentido utilizarlo si 'id' es 0. En otro caso, tendría
        /// que utilizarse el método Actualizar.
        /// </summary>
        /// <returns>Devuelve verdadero si se ha guardado correctamente.</returns>
        override public bool Guardar()
        {
            int id = 0;
            if (HiloCAD.Instancia.Guardar(this, out id))
            {
                this.id = id;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Borra el hilo desde la base de datos. Una vez eliminado, el objeto que invocó
        /// el método será como un hilo que todavía no se ha guardado.
        /// </summary>
        /// <returns>Devuelve verdadero si se ha borrado correctamente.</returns>
        override public bool Borrar()
        {
            if (HiloCAD.Instancia.Borrar(id))
            {
                id = 0;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Borra el hilo desde la base de datos. Una vez eliminado, el objeto que invocó
        /// el método será como un hilo que todavía no se ha guardado.
        /// </summary>
        /// <returns>Devuelve verdadero si se ha borrado correctamente.</returns>
        public static bool Borrar(int id)
        {
            if (HiloCAD.Instancia.Borrar(id))
            {
                id = 0;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Guarda los cambios del hilo en la base de datos.
        /// </summary>
        /// <returns>Devuelve verdadero si se ha actualizado correctamente.</returns>
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
            get { return null; }
            //get { RespuestaCAD.Instancia.Obtener(this); }
        }

        public int NumRespuestas
        {
            get { return 0; }
            //get { RespuestaCAD.Instancia.NumRespuestas(this); }
        }
    }
}