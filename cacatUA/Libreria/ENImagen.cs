﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Libreria
{
    /// <summary>
    /// Clase que representa la entidad Imagen
    /// </summary>
    public class ENImagen : InterfazEN
    {

        private ImagenCAD imagen = new ImagenCAD();

        /// <summary>
        /// Id de la imagen
        /// </summary>
        private int id;
        /// <summary>
        /// Título de la imagen
        /// </summary>
        private string titulo;
        /// <summary>
        /// Descripción de la imagen
        /// </summary>
        private string descripcion;
        /// <summary>
        /// Usuario de la imagen
        /// </summary>
        private ENUsuario usuario;
        /// <summary>
        /// Ruta del fichero imagen
        /// </summary>
        private string archivo;
        /// <summary>
        /// Fecha de la imagen
        /// </summary>
        private DateTime fecha;

        /// <summary>
        /// Constructor por defecto de la clase
        /// </summary>
        public ENImagen()
        {
            id = 0;
            titulo = "";
            descripcion = "";
            archivo = "";
            fecha = DateTime.Now;
        }

        /*
        public ENImagen(int id)
        {
            ENImagen aux = ImagenCAD.Instancia.ObtenerImagen(id);

            if (aux == null)
            {
                aux = new ENImagen();
            }

            this.id = aux.id;
            this.titulo = aux.titulo;
            this.descripcion = aux.descripcion;
            this.usuario = aux.usuario;
            this.archivo = aux.archivo;
            this.fecha = aux.fecha;
        }*/

        /// <summary>
        /// Constructor sobrecargado de la clase
        /// </summary>
        /// <param name="titulo">Título de la imagen</param>
        /// <param name="descripcion">Descripción de la imagen</param>
        /// <param name="usuario">Usuario</param>
        /// <param name="archivo">Ruta del fichero</param>
        /// <param name="fecha">Fecha</param>
        public ENImagen(string titulo, string descripcion, string usuario, string archivo, DateTime fecha)
        {
            ENUsuario autor = ENUsuario.Obtener(usuario);

            this.id = 0;
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.usuario = autor;
            this.archivo = archivo;
            this.fecha = fecha;
        }

        /// <summary>
        /// Obtiene una imagen a partir del id
        /// </summary>
        /// <param name="id">Recibe el id de la imagen</param>
        /// <returns>Devuelve la imagen del id recibido</returns>
        public static ENImagen Obtener(int id)
        {
            ImagenCAD i = new ImagenCAD();
            ENImagen aux = i.ObtenerImagen(id);

            return aux;
        }

        /// <summary>
        /// Obtiene una imagen a partir del título
        /// </summary>
        /// <param name="titulo">Título de la imagen</param>
        /// <returns>Devuelve la imagen del titulo recibido</returns>
        public static ENImagen Obtener(string titulo)
        {
            ImagenCAD i = new ImagenCAD();
            ENImagen aux = i.ObtenerImagen(titulo);
            
            return aux;
        }

        /// <summary>
        /// Obtiene las imágenes de la BD
        /// </summary>
        /// <returns>Devuelve un ArrayList con el resultado</returns>
        public static ArrayList Obtener()
        {
            ImagenCAD i = new ImagenCAD();
            return i.ObtenerImagenes();
        }

        public static ArrayList ObtenerPorUsuario(int id)
        {
            ImagenCAD i = new ImagenCAD();
            return i.ObtenerPorUsuario(id);
        }

        /*
        public bool Obtener(int id)
        {
            ENImagen aux = new ENImagen();
            aux = ImagenCAD.Instancia.ObtenerImagen(id);

            if (aux != null)
            {
                this.id = aux.id;
                this.titulo = aux.titulo;
                this.descripcion = aux.descripcion;
                this.usuario = aux.usuario;
                this.archivo = aux.archivo;
                this.fecha = aux.fecha;

                return true;
            }
            else
            {
                return false;
            }
        }*/

        /*
        public bool Obtener(string titulo)
        {
            ENImagen aux = null;
            aux = ImagenCAD.Instancia.ObtenerImagen(titulo);

            this.id = aux.id;
            this.titulo = aux.titulo;
            this.descripcion = aux.descripcion;
            this.usuario = aux.usuario;
            this.archivo = aux.archivo;
            this.fecha = aux.fecha;

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
        /// Actualiza la BD con la imagen actual
        /// </summary>
        /// <returns>Devuelve true si la operación se ha realizado correctamente, false en caso contrario</returns>
        override public bool Actualizar()
        {
            return imagen.Actualizar(this);
        }

        /// <summary>
        /// Inserta la imagen actual en la BD
        /// </summary>
        /// <returns>Devuelve true si la operación se ha realizado correctamente, false en caso contrario</returns>
        override public bool Guardar()
        {
            return imagen.GuardarImagen(titulo, descripcion, usuario.Usuario, archivo);
        }

        /// <summary>
        /// Borra la imagen actual de la BD
        /// </summary>
        /// <returns>Devuelve true si la operación se ha realizado correctamente, false en caso contrario</returns>
        override public bool Borrar()
        {
            return imagen.BorrarImagen(id);
        }

        /// <summary>
        /// Borra una imagen con determinado id
        /// </summary>
        /// <param name="pid">Recibe el id de la imagen a borrar</param>
        /// <returns>Devuelve true si la operación se ha realizado correctamente, false en caso contrario</returns>
        public static bool Borrar(int pid)
        {
            ImagenCAD i = new ImagenCAD();
            return i.BorrarImagen(pid);
        }

        /// <summary>
        /// Borra todas las imágenes de la BD
        /// </summary>
        public void BorrarImagenes()
        {
            imagen.BorrarImagenes();
        }

        /// <summary>
        /// Busca una determinada imagen
        /// </summary>
        /// <param name="titulo">Título</param>
        /// <param name="usuario">Usuario</param>
        /// <returns>Devuelve el ArrayList con el resultado</returns>
        public ArrayList Buscar(string titulo, string usuario)
        {
            return imagen.BuscarImagen(titulo, usuario);
        }
        
        /// <summary>
        /// Obtiene las imágenes de un determinado usuario
        /// </summary>
        /// <param name="usuario">Usuario de las imágenes</param>
        /// <returns>Devuelve un ArrayList con el resultado</returns>
        public ArrayList Buscar(int usuario)
        {
            return imagen.BuscarImagen(usuario);
        }

        public static ArrayList Obtener(int usuario,int pagina,int cantidad)
        {
            ImagenCAD i = new ImagenCAD();
            return i.Obtener(usuario,pagina,cantidad);
        }

        public static int ObtenerNumeroImagenes(int usuario)
        {
            ImagenCAD i = new ImagenCAD();
            return i.ObtenerNumeroImagenes(usuario);
        }

        public static int Siguiente(int id,int usuario)
        {
            ImagenCAD i = new ImagenCAD();
            int resultado = i.Siguiente(id, usuario);

            if (resultado == -1)
            {
                return id;
            }
            else
            {
                return resultado;
            }

        }

        public static int Anterior(int id, int usuario)
        {
            ImagenCAD i = new ImagenCAD();
            int resultado = i.Anterior(id, usuario);

            if (resultado == -1)
            {
                return id;
            }
            else
            {
                return resultado;
            }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public ENUsuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        public string Archivo
        {
            get { return archivo; }
            set { archivo = value; }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
    }
}
