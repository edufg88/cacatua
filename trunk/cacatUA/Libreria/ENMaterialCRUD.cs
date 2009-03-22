using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Libreria
{
    public class ENMaterialCRUD
    {
        private int id;
        private string nombre;
        private string descripcion;
        private DateTime fecha;
        private string usuario;
        private string categoria;
        private string archivo;
        private int tamaño;
        private int descargas;
        private string idioma;
        private int valoracion;
        private int votos;
        private string referencia;

        public ENMaterialCRUD()
        {
            // Inicializamos
            id = 0;
            nombre = "";
            descripcion = "";
            usuario = "";
            categoria = "";
            archivo = "";
            tamaño = 0;
            descargas = 0;
            idioma = "";
            valoracion = 0;
            votos = 0;
            referencia = "";
            //materialCAD = new MaterialCAD();
        }

        public static ArrayList obtenerMateriales()
        {
            // Obtenemos del CAD todos los materiales
            return MaterialCAD.obtenerMateriales();
        }

        public void crearMaterial()
        {
            MaterialCAD.crearMaterial(nombre,descripcion,usuario,categoria,archivo,tamaño,idioma,referencia);
        }

        public bool borrarMaterial()
        {
            return MaterialCAD.borrarMaterial(id);
        }

        public static bool borrarMaterial(int id)
        {
            return MaterialCAD.borrarMaterial(id);
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        public string Archivo
        {
            get { return archivo; }
            set { archivo = value; }
        }

        public int Tamaño
        {
            get { return tamaño; }
            set { tamaño = value; }
        }

        public int Descargas
        {
            get { return descargas; }
            set { descargas = value; }
        }

        public string Idioma
        {
            get { return idioma; }
            set { idioma = value; }
        }

        public int Valoracion
        {
            get { return valoracion; }
            set { valoracion = value; }
        }

        public int Votos
        {
            get { return votos; }
            set { votos = value; }
        }

        public string Referencia
        {
            get { return referencia; }
            set { referencia = value; }
        }
    }
}
