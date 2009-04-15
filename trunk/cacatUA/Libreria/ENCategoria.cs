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
            ENCategoria aux = Obtener(id);
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

        public ENCategoria(String nombre, String descripcion, int padre)
        {
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

        override public bool Guardar()
        {
            return CategoriaCAD.Instancia.Crear(this);
        }

        override public bool Actualizar()
        {
            return CategoriaCAD.Instancia.Actualizar(this);
        }

        override public bool Borrar() {
            return CategoriaCAD.Instancia.Borrar(this);
        }

        //Metodos asociados a las categorias

        public String NombreCompleto()
        {
            if (id != 0)
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
            if (id != 0)
                return new ENCategoria(padre).NombreCompleto();
            else
                return "";
        }

        public ArrayList ObtenerHijos()
        {
            return CategoriaCAD.Instancia.HijosDe(this);
        }

        public ArrayList UsuariosSuscritos()
        {
            return CategoriaCAD.Instancia.UsuariosSuscritosA(this);
        }

        public int NumMateriales()
        {
            return CategoriaCAD.Instancia.NumMaterialesEn(this);
        }

        public int NumHilos()
        {
            return CategoriaCAD.Instancia.NumHilosEn(this);
        }

        public bool EsDescendienteDe(ENCategoria cat)
        {
            if(Ruta() == cat.NombreCompleto()) {
                return true;
            }
            else {
                ENCategoria aux = Obtener(padre);
                if(aux != null)
                    return aux.EsDescendienteDe(cat);
                else
                    return false;
            }
                
        }

        //Metodos relacionados con la tabla suscripcion

        public void SuscribirUsuario(ENUsuario usuario)
        {
            CategoriaCAD.Instancia.AñadirSuscripcion(this, usuario);

            foreach (ENCategoria c in ObtenerHijos())
            {
                c.SuscribirUsuario(usuario);
            }
        }

        public void DessuscribirUsuario(ENUsuario usuario)
        {
            CategoriaCAD.Instancia.QuitarSuscripcion(this, usuario);

            foreach (ENCategoria c in ObtenerHijos())
            {
                c.DessuscribirUsuario(usuario);
            }
        }        

        //Metodos estaticos de categorias

        public static ENCategoria Obtener(int id)
        {
            return CategoriaCAD.Instancia.Obtener(id);
        }

        public static ArrayList CategoriasSuperiores()
        {
            return CategoriaCAD.Instancia.ObtenerSuperiores();
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
