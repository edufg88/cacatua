using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Libreria
{
    public class ENImagenVoto
    {
        private ENUsuario usuario;
        private ENImagen imagen;
        private int valoracion;

        public int Valoracion
        {
            get { return valoracion; }
            set { valoracion = value; }
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

        public ENImagenVoto()
        {

        }

        public ENImagenVoto(ENUsuario u,ENImagen i,int v)
        {
            usuario = u;
            imagen = i;
            valoracion = v;
        }

        public static int ObtenerValoracion(int imagen)
        {
            ImagenVotoCAD i = new ImagenVotoCAD();
            return i.ObtenerValoracion(imagen);
        }
        public static int ObtenerValoracionUsuario(int imagen,string usuario)
        {
            ImagenVotoCAD i = new ImagenVotoCAD();
            ENUsuario us = ENUsuario.Obtener(usuario);
            return i.ObtenerValoracionUsuario(imagen,us.Id);
        }

        public bool Guardar()
        {
            ImagenVotoCAD i = new ImagenVotoCAD();
            return i.Guardar(this); ;
        }

    }
}
