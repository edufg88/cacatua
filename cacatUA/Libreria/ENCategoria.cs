using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Libreria
{
    public class ENCategoria : InterfazEN
    {
        private int id;
        private String nombre;
        private String descripcion;
        private int padre;


        //Constructores
        public ENCategoria()
        {
            id = 0;
        }

        public ENCategoria(int id)
        {
            ENCategoria aux = ObtenerCategoria(id);
            if (aux != null)
            {
                this.id = aux.Id;
                nombre = aux.Nombre;
                descripcion = aux.Descripcion;
                padre = aux.Padre;
            }
            else
            {
                this.id = 0;
            }
        }

        public ENCategoria(int id, String nombre, String descripcion, int padre)
        {
            this.id = id;
            this.nombre = nombre;
            this.padre = padre;
            this.descripcion = descripcion;
        }

        public void Copiar(ENCategoria copia)
        {
            id = copia.Id;
            nombre = copia.Nombre;
            descripcion = copia.Descripcion;
            padre = copia.Padre;
        }


        //Metodos heredados de InterfazEN
        public override bool Obtener(int id)
        {
            ENCategoria aux = ObtenerCategoria(id);
            if (aux != null)
            {
                this.id = aux.Id;
                nombre = aux.Nombre;
                descripcion = aux.Descripcion;
                padre = aux.Padre;
                return true;
            }
            else
            {
                this.id = 0;
                return false;
            }

        }

        override public bool Guardar()
        {
            return CategoriaCAD.Instancia.crearCategoria(this);
        }

        override public bool Actualizar()
        {
            return CategoriaCAD.Instancia.actualizarCategoria(this);
        }

        override public bool Borrar() {
            return CategoriaCAD.Instancia.borrarCategoria(this);
        }

        //Metodos asociados
        public bool Instanciada()
        {
            if (id != 0)
                return true;
            else
                return false;
        }

        public String NombreCompleto()
        {
            if (Instanciada())
            {
                if (padre == 0)
                {
                    return nombre;
                }
                else
                {
                    return Ruta() + "/" + nombre;
                }
            }
            else
            {
                return "";
            }
        }

        public String Ruta()
        {
            if (Instanciada())
                return new ENCategoria(padre).NombreCompleto();
            else
                return "";
        }

        public ArrayList obtenerHijos()
        {
            return CategoriaCAD.Instancia.obtenerHijosDe(this);
        }

        public ArrayList usuariosSuscritos()
        {
            return CategoriaCAD.Instancia.usuariosSuscritosA(this);
        }

        public int NumMateriales()
        {
            return CategoriaCAD.Instancia.NumMaterialesEn(this);
        }

        public int NumHilos()
        {
            return CategoriaCAD.Instancia.NumHilosEn(this);
        }


        //Metodos estaticos de categorias

        public static ENCategoria ObtenerCategoria(int id)
        {
            return CategoriaCAD.Instancia.obtenerCategoria(id);
        }

        public static ArrayList CategoriasSuperiores()
        {
            return CategoriaCAD.Instancia.obtenerCategoriasSuperiores();
        }

        public static int NumCategorias()
        {
            return CategoriaCAD.Instancia.NumCategorias();
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
