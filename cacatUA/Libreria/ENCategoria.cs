using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Libreria
{
    public class ENCategoria
    {
        private int id;
        private String nombre;
        private String descripcion;
        private int padre;

        private CategoriaCAD cad;

        public ENCategoria()
        {
        }

        public ENCategoria(int id, String nombre, String descripcion, int padre)
        {
            this.id = id;
            this.nombre = nombre;
            this.padre = padre;
            this.descripcion = descripcion;
        }

        public bool crear()
        {
            return CategoriaCAD.crearCategoria(this);
        }

        public bool actualizar()
        {
            return CategoriaCAD.actualizarCategoria(this);
        }

        public bool borrar() {
            return CategoriaCAD.borrarCategoria(this);
        }

        public ArrayList obtenerHijos()
        {
            return CategoriaCAD.obtenerHijosDe(this);
        }

        public ArrayList usuariosSuscritos()
        {
            return CategoriaCAD.usuariosSuscritosA(this);
        }

        public int NumMateriales()
        {
            return CategoriaCAD.NumMaterialesEn(this);
        }

        public int NumHilos()
        {
            return CategoriaCAD.NumHilosEn(this);
        }


        //Metodos estaticos de categorias

        public static int NumCategorias()
        {
            return CategoriaCAD.NumCategorias();
        } 

        //Propiedades

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public int Padre
        {
            get { return padre; }
            set { padre = value; }
        }
    }
}
