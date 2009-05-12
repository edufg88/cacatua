using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Libreria
{
    public class ENGrupos : InterfazEN
    {
        private GruposCAD grupoCAD;
        private string nombre;
        private string descripcion;
        private DateTime fecha;
        private int id;
        private ArrayList usuarios;
        int numUsuarios;

        /// <summary>
        /// Constructor por defecto, crea un grupo vacío.
        /// </summary>
        public ENGrupos()
        {
            grupoCAD = new GruposCAD();
            id = 0;
            nombre = "";
            descripcion = "";
            fecha = new DateTime();
            usuarios = new ArrayList();
            numUsuarios = 0;
        }

        /// <summary>
        /// Constructor sobrecargado que crea un grupo segun el nombre y la fecha.
        /// </summary>
        /// <param name="nombre">Nombre del grupo.</param>
        /// <param name="fecha">Fecha en que se creó el grupo.</param>
        public ENGrupos(string nombre, DateTime fecha)
        {
            grupoCAD = new GruposCAD();
            this.nombre = nombre;
            this.fecha = fecha;
            id = 0;
            descripcion = "";
            usuarios = new ArrayList();
            numUsuarios = 0;
        }

        /// <summary>
        /// Constructor sobrecargado que crea un grupo con los parámetros indicado.
        /// </summary>
        /// <param name="nombre">Nombre del grupo.</param>
        /// <param name="descripcion">Descripción del grupo.</param>
        /// <param name="fecha">Fecha de creación del grupo.</param>
        /// <param name="usuarios">Lista de los usuarios miembros del grupo.</param>
        public ENGrupos(string nombre, string descripcion, DateTime fecha, ArrayList usuarios)
        {
            grupoCAD = new GruposCAD();
            id = 0;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.fecha = fecha;
            if (usuarios.Count > 0)
            {
                this.usuarios = usuarios;
            }
            else this.usuarios=new ArrayList();
            this.numUsuarios = usuarios.Count;
        }

        /// <summary>
        /// Guarda un grupo en la base de datos.
        /// </summary>
        /// <returns>Devuelve verdadero si se ha guardado correctamente.</returns>
        override public bool Guardar()
        {
            return grupoCAD.Guardar(this);
        }

        /// <summary>
        /// Actualiza con los nuevos datos un grupo ya existente en la base de datos.
        /// </summary>
        /// <returns>Devuelve verdadero si se ha actualizado correctamente.</returns>
        override public bool Actualizar()
        {
            return grupoCAD.Actualizar(this);
        }

        /// <summary>
        /// Borra un grupo de la base de datos.
        /// </summary>
        /// <returns>Devuelve verdadero si se ha borrado correctamente.</returns>
        override public bool Borrar()
        {
            return grupoCAD.Borrar(this);
        }

        /// <summary>
        /// Dada una id obtiene el grupo correspondiente a esa id.
        /// </summary>
        /// <param name="id">id del grupo que buscamos.</param>
        /// <returns>Devuelve el grupo correspondiente a la id.</returns>
        public static ENGrupos Obtener(int id)
        {
            GruposCAD grupoCAD = new GruposCAD();
            return grupoCAD.Obtener(id);
        }

        /// <summary>
        /// Obtiene todos los grupos existentes en la base de datos.
        /// </summary>
        /// <returns>Devuelve una lista de grupos.</returns>
        public static ArrayList Obtener()
        {
            GruposCAD grupoCAD = new GruposCAD();
            return grupoCAD.ObtenerTodos();
        }

        /// <summary>
        /// Obtiene los grupos a los que pertenece un usuario.
        /// Realiza una consulta a la base de datos.
        /// </summary>
        /// <param name="usuario">Usuario del que se van a obtener los grupos.</param>
        /// <returns>Devuelve una lista de grupos.</returns>
        public static ArrayList Obtener(ENUsuario usuario)
        {
            GruposCAD grupoCAD = new GruposCAD();
            return grupoCAD.Obtener(usuario);
        }

        /// <summary>
        /// Borra un usuario miembro de un grupo.
        /// </summary>
        /// <param name="usuario">id del usuario a borrar.</param>
        /// <returns>Devuelve verdadero si se ha borrado el miembro correctamente.</returns>
        public bool BorrarMiembro(int usuario)
        {
            return grupoCAD.BorrarUsuario(usuario, id);
        }

        /// <summary>
        /// Inserta un usuario a un grupo.
        /// </summary>
        /// <param name="usuario">id del usuario a insertar.</param>
        /// <returns>Devuelve verdadero si se ha insertado el miembro correctamente</returns>
        public bool InsertarMiembro(int usuario)
        {
            return grupoCAD.InsertarUsuario(usuario, id);
        }

        /// <summary>
        /// Busca los grupos acordes a los parámetros.
        /// </summary>
        /// <param name="cantidad">Cantidad de grupos en cada página.</param>
        /// <param name="ultimo">Último grupo que se devolvió.</param>
        /// <param name="orden">Indica si es un filtro ascendente o descendente.</param>
        /// <param name="min">Cantidad minima de usuarios.</param>
        /// <param name="max">Cantidad máxima de usuarios.</param>
        /// <param name="fechafin">Fecha de fin para el filtro de búsqueda.</param>
        /// <param name="usuario">usuario del cual queremos saber sus grupos.</param>
        /// <returns>Devuelve un array con los gurpos encontrados segun el filtro de búsqueda.</returns>
        public ArrayList Buscar(string ordenar,int pagina,int cantidad,bool orden,int min, int max,DateTime fechafin,ref ENUsuario usuario)
        {
            return grupoCAD.Buscar(ordenar, pagina, cantidad, orden, min, max, this, fechafin, ref usuario);
        }

        /// <summary>
        /// Calcula la cantidad de grupos en la base de datos.
        /// </summary>
        /// <returns>Devuelve un entero con la cantidad</returns>
        public static int NumGrupos()
        {
            GruposCAD grupoCAD = new GruposCAD();
            return grupoCAD.NumGrupos();
        }

        /// <summary>
        /// Obtiene el último grupo insertado en la base de datos.
        /// </summary>
        /// <returns>Devuelve el ultimo grupo insertado.</returns>
        public static ENGrupos Ultimo()
        {
            GruposCAD grupoCAD = new GruposCAD();
            return grupoCAD.Ultimo();
        }

        /// <summary>
        /// Calcula la cantidad de usuarios que se obtendran de una búsqueda.
        /// </summary>
        /// <param name="min">Cantidad minima de usuarios.</param>
        /// <param name="max">Cantidad máxima de usuarios.</param>
        /// <param name="fechafin">Fecha de fin para el filtro de búsqueda.</param>
        /// <param name="usuario">usuario del cual queremos saber sus grupos.</param>
        /// <returns>Devuelve un entero con el número de grupos.</returns>
        public int Cantidad(int min, int max, DateTime fechafin, ref ENUsuario usuario)
        {
            ArrayList Cantidad = grupoCAD.Buscar(min, max, this, fechafin, ref usuario);
            return Cantidad.Count;
        }

        public bool Existe()
        {
            return grupoCAD.Existe(nombre);
        }

        /// <summary>
        /// Nombre del grupo.
        /// </summary>
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        /// <summary>
        /// Descripción del grupo.
        /// </summary>
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        /// <summary>
        /// Id del grupo.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// Fecha de creación del grupo.
        /// </summary>
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        /// <summary>
        /// Lista con los usuarios pertenecientes al grupo.
        /// </summary>
        public ArrayList Usuarios
        {
            get { return usuarios; }
            set { usuarios = value; }
        }
        /// <summary>
        /// Cantidad de usuarios del grupo.
        /// </summary>
        public int NumUsuarios
        {
            get { return numUsuarios; }
            set { numUsuarios = value; }
        }
    }
}
