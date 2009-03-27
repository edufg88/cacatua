using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Libreria
{
    public class ENCategoriaCRUD
    {
        private int id;
        private String nombre;
        private String descripcion;
        private int padre;

        public ENCategoriaCRUD(int id, String nombre, String descripcion, int padre)
        {
            this.id = id;
            this.nombre = nombre;
            this.padre = padre;
            this.descripcion = descripcion;
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
