using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Libreria
{
    public class ENImagenComentario
    {
        private int id;
        private string texto;
        private DateTime fecha;
        private ENUsuario usuario;
        private ENImagen imagen;

        public int Id
        {
            get { return id; }
            set { id = value; }
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
        public ENUsuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        public ENImagen Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }

        public ENImagenComentario()
        {

        }

        public ENImagenComentario(string t,DateTime f,ENUsuario u,ENImagen img)
        {
           
            texto = t;
            fecha = f;
            usuario = u;
            imagen = img;
        }

        public static ArrayList Obtener(int imagen)
        {
            ImagenComentarioCAD i = new ImagenComentarioCAD();
            return i.Obtener(imagen);
        }

        public static bool Guardar(ENImagenComentario comentario)
        {
            ImagenComentarioCAD i = new ImagenComentarioCAD();
            return i.Guardar(comentario);
        }

        public static ArrayList Obtener(int imagen, int pagina, int cantidad)
        {
            ImagenComentarioCAD i = new ImagenComentarioCAD();
            return i.Obtener(imagen, pagina, cantidad);
        }

        public static int ObtenerNumeroImagenes(int imagen)
        {
            ImagenComentarioCAD i = new ImagenComentarioCAD();
            return i.ObtenerNumeroComentarios(imagen);
        }
    }
}
