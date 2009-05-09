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


        /// <summary>
        /// Constructor por defecto
        /// </summary>

        public ENCategoria()
        {
            id = 0;
        }

        /// <summary>
        /// Constructor a partir de una id. 
        /// El objeto se instancia si dicha id esta en la base de datos
        /// </summary>
        /// <param name="id">Identificador de la categoria</param>
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

        /// <summary>
        /// Constructor con datos, usualmente para despues guardarlo en la base de datos.
        /// </summary>
        /// <param name="nombre">Nombre de la categoria</param>
        /// <param name="descripcion">Descripcion de la categoria</param>
        /// <param name="padre">Entero que identifica al padre de esta categoria</param>
        public ENCategoria(String nombre, String descripcion, int padre)
        {
            this.nombre = nombre;
            this.padre = padre;
            this.descripcion = descripcion;
        }

        /// <summary>
        /// Metodo que copia los datos de una categoria al objeto que llama.
        /// </summary>
        /// <param name="copia">Objeto ENCategoria a copiar</param>
        public void Copiar(ENCategoria copia)
        {
            id = copia.Id;
            nombre = copia.Nombre;
            descripcion = copia.Descripcion;
            padre = copia.Padre;
        }


        /// <summary>
        /// Guarda el objeto en la base de datos.
        /// </summary>
        /// <returns>Devuelve 'true' si el objeto se ha guardado correctamente.</returns>

        override public bool Guardar()
        {
            return CategoriaCAD.Instancia.Crear(this,out id);
        }

        /// <summary>
        /// Actualiza el objeto en la base de datos.
        /// </summary>
        /// <returns>Devuelve 'true' si el objeto se ha actualizado correctamente.</returns>
        override public bool Actualizar()
        {
            return CategoriaCAD.Instancia.Actualizar(this);
        }

        /// <summary>
        /// Metodo encargado de borrar el objeto de la base de datos.
        /// Antes de borrar el objeto en concreto se encarga de borrar los descendientes.
        /// </summary>
        /// <returns>Devuelve 'true' si el objeto se ha borrado correctamente.</returns>
        override public bool Borrar() {
            foreach (ENCategoria c in ObtenerHijos()) 
            {
                if(!c.Borrar()) {
                    return false;
                }
            }
            return CategoriaCAD.Instancia.Borrar(this);
        }

        /// <summary>
        /// Metodo que obtiene el nombre completo (ruta + nombre) de la categoria.
        /// </summary>
        /// <returns>Devuelve una cadena con el nombre completo</returns>

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

        /// <summary>
        /// Metodo encargo de obtener la ruta (de donde viene) de la categoria.
        /// Se apoya en otros metodos, ya que la ruta es igual al nombre completo del padre.
        /// </summary>
        /// <returns>Devuelve una cadena con la ruta del objeto</returns>
        public String Ruta()
        {
            if (id != 0)
                return new ENCategoria(padre).NombreCompleto();
            else
                return "";
        }

        public bool EsSuperior()
        {
            if (padre > 0)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Metodo que obtiene una lista compuesta por todos los hijos de esta categoria.
        /// </summary>
        /// <returns>Devuelve la lista de ENCategoria hijos.</returns>
        public ArrayList ObtenerHijos()
        {
            return CategoriaCAD.Instancia.HijosDe(this);
        }

        /// <summary>
        /// Obtiene todas las categorías que desciendan del objeto que invoca el método.
        /// Se recorre el árbol de categorías por niveles obteniendo una listas compuesta.
        /// </summary>
        /// <returns>Devuelve una lista de ENCategoria que son descendientes de la categoría padre.</returns>
        public ArrayList ObtenerDescendencia()
        {
            return CategoriaCAD.Instancia.DescendenciaDe(this);
        }

        /// <summary>
        /// Metodo que obtiene una lista compuesta por todos los usuarios suscritos a la categoria.
        /// </summary>
        /// <returns>Devuelve la lista de ENUsuario suscritos.</returns>
        public ArrayList UsuariosSuscritos(int numPagina)
        {
            return CategoriaCAD.Instancia.UsuariosSuscritosA(this,numPagina);
        }

        /// <summary>
        /// Metodo que devuelve cuantos materiales hay actualmente en la base de datos asociados a esta categoria.
        /// </summary>
        /// <returns>Entero que indica el número de materiales.</returns>
        public int NumMateriales()
        {
            return CategoriaCAD.Instancia.NumMaterialesEn(this);
        }


        /// <summary>
        /// Metodo que devuelve cuantos hilos hay actualmente en la base de datos asociados a esta categoria.
        /// </summary>
        /// <returns>Entero que indica el número de hilos.</returns>
        public int NumHilos()
        {
            return CategoriaCAD.Instancia.NumHilosEn(this);
        }

        /// <summary>
        /// Metodo encargado de comprobar si la categoria que llama es descendiente de otra.
        /// Para comprobarlo nos basamos en la ruta actual y la del padre (recursivamente) y el nombre completo de la categoria parámetro.
        /// </summary>
        /// <param name="cat">Objeto ENCategoria a comprobar si la categoria que llama es desciende de él.</param>
        /// <returns>Devuelve 'true' si es descendiente.</returns>
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

        /// <summary>
        /// Suscribe un usuario a esta categoria y a todos sus descendientes (recursivamente).
        /// </summary>
        /// <param name="usuario">Objeto ENUsuario a suscribir.</param>
        /// <returns>Devuelve 'true' si el usuario ha sido suscrito correctamente.</returns>
        public bool SuscribirUsuario(ENUsuario usuario)
        {
            if (CategoriaCAD.Instancia.AñadirSuscripcion(this, usuario))
            {
                foreach (ENCategoria c in ObtenerHijos())
                {
                    if (!c.SuscribirUsuario(usuario))
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Insuscribe un usuario de esta categoria y de todos sus descendientes (recursivamente).
        /// </summary>
        /// <param name="usuario">Objeto ENUsuario a insuscribir.</param>
        /// <returns>Devuelve 'true' si el usuario ha sido insuscrito correctamente.</returns>
        public bool InsuscribirUsuario(ENUsuario usuario)
        {
            return CategoriaCAD.Instancia.QuitarSuscripcion(this, usuario);
        }


        /// <summary>
        /// Obtiene el número de usuarios suscritos a la categoría.
        /// </summary>
        /// <returns>Entero que indica el número de usuarios suscritos.</returns>
        public int NumSuscritos()
        {
            return CategoriaCAD.Instancia.NumSuscritos(this);
        }

        /// <summary>
        /// Método estático que obtiene una categoria de la base de datos a partir de su identificador.
        /// </summary>
        /// <param name="id">Entero que identifica la categoria a buscar.</param>
        /// <returns>Devuelve un objeto ENCategoria instanciado.</returns>

        public static ENCategoria Obtener(int id)
        {
            return CategoriaCAD.Instancia.Obtener(id);
        }

        /// <summary>
        /// Método estático que obtiene las categorias superiores (sin padre).
        /// </summary>
        /// <returns>Devuelve una lista con los objeto ENCategoria que son categoria superior.</returns>
        public static ArrayList CategoriasSuperiores()
        {
            return CategoriaCAD.Instancia.ObtenerSuperiores();
        }

        /// <summary>
        /// Método estático que obtiene el número de categorias creadas.
        /// </summary>
        /// <returns>Devuelve un entero que indica el número de categorias.</returns>
        public static int NumCategorias()
        {
            return CategoriaCAD.Instancia.NumCategorias();
        }

        /// <summary>
        /// Comprueba si un usuario esta suscrito a una categoria.
        /// </summary>
        /// <param name="usuario">Usuario a comprobar</param>
        /// <returns></returns>
        public bool EstaSuscrito(ENUsuario usuario)
        {
            return CategoriaCAD.Instancia.EstaSuscritoA(usuario, this);
        }

        /// <summary>
        /// Identificador de la categoria.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Nombre de la categoria.
        /// </summary>
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        /// <summary>
        /// Descripcion de la categoria.
        /// </summary>
        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        /// <summary>
        /// Identificador del padre.
        /// </summary>
        public int Padre
        {
            get { return padre; }
            set { padre = value; }
        }
    }
}
