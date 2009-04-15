using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Libreria
{
    public class ENImagen : InterfazEN
    {
        private int id;
        private string titulo;
        private string descripcion;
        private ENUsuario usuario;
        private string archivo;
        private DateTime fecha;

        public ENImagen()
        {
            id = 0;
            titulo = "";
            descripcion = "";
            archivo = "";
            fecha = DateTime.Now;
        }

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
        }

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

        public static ArrayList Obtener()
        {
            return ImagenCAD.Instancia.ObtenerImagenes();
        }

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
        }

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
        }

        override public bool Actualizar()
        {
            return ImagenCAD.Instancia.Actualizar(this);
        }

        override public bool Guardar()
        {
            return ImagenCAD.Instancia.GuardarImagen(titulo, descripcion, usuario.Usuario, archivo, fecha);
        }

        override public bool Borrar()
        {
            return ImagenCAD.Instancia.BorrarImagen(id);
        }

        public static bool Borrar(int pid)
        {
            return ImagenCAD.Instancia.BorrarImagen(pid);
        }

        public void BorrarImagenes()
        {
            ImagenCAD.Instancia.BorrarImagenes();
        }

        public ArrayList Buscar(string titulo, string usuario)
        {
            return ImagenCAD.Instancia.BuscarImagen(titulo, usuario);
        }

        public ArrayList Buscar(int usuario)
        {
            return ImagenCAD.Instancia.BuscarImagen(usuario);
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
