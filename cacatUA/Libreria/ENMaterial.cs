using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Libreria;

namespace Libreria 
{
    /// <remarks>
    /// Clase que representa a una entidad del tipo material. En ella guardamos todos los datos del material y
    /// además ofrece una serie de métodos para poder obtener el material de la base de datos, actualizarlo, crear
    /// uno nuevo, borrarlo, etc.
    /// </remarks>
    public class ENMaterial : InterfazEN
    {
        const int maxTamNombre = 30;
        const int minTamNombre = 5;
        const int maxTamArchivo = 100;
        const int minTamArchivo = 5;
        const int maxTamReferencia = 100;
        const int minTamReferencia = 5;

        private int id;
        private string nombre;
        private string descripcion;
        private DateTime fecha;
        private ENUsuario usuario;
        private ENCategoria categoria;
        private string archivo;
        private int tamaño;
        private int descargas;
        private int puntuacion;
        private int votos;
        private string referencia;
        private int numComentarios;

        /// <summary>
        /// Constructor por defecto. Crea un material vacío.
        /// </summary>
        public ENMaterial()
        {
            // Inicializamos
            id = 0;
            nombre = "";
            descripcion = "";
            usuario = null;
            categoria = null;
            archivo = "";
            tamaño = 0;
            descargas = 0;
            puntuacion = 0;
            votos = 0;
            referencia = "";
            numComentarios = 0;
        }

        /// <summary>
        /// Valida una propidad de un material.
        /// </summary>
        /// <param name="comentario">Material que vamos a validar.</param>
        /// <param name="propiedad">Nombre de la propiedad a validar.</param>
        /// <returns>Devuelve "OK" si es válida o un mensaje de error personalizado.</returns>
        public static string validarDatos(ENMaterial material, string dato)
        {
            string error = "OK";
            switch (dato)
            {
                case "nombre":
                    {
                        if (material.Nombre.Length > maxTamNombre || material.Nombre.Length < minTamNombre)
                            error = "Debe tener entre " + minTamNombre + " y " + maxTamNombre + " caracteres";
                        break;
                    }
                case "usuario":
                    {
                        if (material.Usuario == null)
                            error = "El usuario no está registrado";
                        break;
                    }
                case "categoria":
                    {
                        if (material.Categoria == null)
                            error = "Categoría no válida";
                        break;
                    }
                case "archivo":
                    {
                        if (material.Archivo.Length > maxTamArchivo || material.Archivo.Length < minTamArchivo)
                            error = "Debe tener entre " + minTamArchivo + " y " + maxTamArchivo + " caracteres";
                        break;
                    }
                case "referencia":
                    {
                        if (material.Referencia != "")
                        {
                            if (material.Referencia.Length > maxTamReferencia || material.Referencia.Length < minTamReferencia)
                                error = "Debe tener entre " + minTamReferencia + " y " + maxTamReferencia + " caracteres";
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return error;
        }

        /// <summary>
        /// Convierte el tamaño a un entero a partir de un string con la medida.
        /// </summary>
        public static int convertirTamaño(string strTamaño)
        {
            int tamaño = 0;          
            if (strTamaño != "")
            {
                bool bytes = false;
                // Comprobamos si está expresado en bytes
                if (strTamaño.LastIndexOf("bytes") > 0)
                    bytes = true;
                // Quitamos la medida
                strTamaño = strTamaño.Remove(strTamaño.IndexOf(' '));
                strTamaño.Trim();
                tamaño = int.Parse(strTamaño);
                if (bytes == false)
                    tamaño *= 1024;
            }
            return tamaño;
        }

        /// <summary>
        /// A partir de un entero con el tamaño, le añade la medida al final.
        /// </summary>
        public static string convertirTamaño(int tamaño)
        {
            string strTamaño = "";
            if (tamaño < 1024)
            {
                // Expresamos en bytes
                strTamaño = tamaño.ToString() + " bytes";
            }
            else
            {
                // Convertimos a kbytes
                tamaño = tamaño / 1024;
                strTamaño = tamaño.ToString() + " KB";
            }
            return strTamaño;
        }

        /// <summary>
        /// Obtiene un material a partir de la id.
        /// </summary>
        public static ENMaterial Obtener(int id)
        {
            return MaterialCAD.Instancia.Obtener(id);
        }

        /// <summary>
        /// Obtenemos todos los materiales que hay en la base de datos
        /// </summary>
        public static ArrayList Obtener()
        {
            return MaterialCAD.Instancia.Obtener();
        }

        /// <summary>
        /// Realizamos una búsqueda mediante paginación y devolvemos todos los materiales que encontremos.
        /// <param name="propiedadOrdenar">Propiedad por la que vamos a ordenar los resultados de la búsqueda.</param>
        /// <param name="ascendente">Indica si la búsqueda se realiza en orden ascendente o descedente.</param>
        /// <param name="pagina">Número de página que queremos mostrar.</param>
        /// <param name="cantidadPorPagina">Cantidad de materiales que mostramos por página. A partir de este dato
        /// y la página que queremos mostrar, podemos cálcular la fila inicial y final para realizar la búsqueda.</param>
        /// <param name="busqueda">Estructura de datos donde almacenamos todos los parámetros que vamos a indicar en la búsqueda.</param>
        /// </summary>
        public static ArrayList Obtener(string propiedadOrdenar, bool ascendente, int pagina, int cantidadPorPagina, BusquedaMaterial busqueda)
        {
            return MaterialCAD.Instancia.Obtener(propiedadOrdenar, ascendente, pagina, cantidadPorPagina, busqueda);
        }

        /// <summary>
        /// Crea o guarda el material en la base de datos. En esta función únicamente crea una transacción
        /// y luego hay que llamar a otra función para completar la transacción o cancelarla en función de si
        /// se ha subido bien el material o no.
        /// <returns>Devuelve true si se ha podido guardar correctamente o false en caso contrario.</returns>
        /// </summary>
        override public bool Guardar()
        {
            return MaterialCAD.Instancia.Guardar(this);
        }

        /// <summary>
        /// Completa la operación de guardar el material.
        /// Se necesita esta función porque cuando se crea un nuevo material, primero lo que se hace es 
        /// subir el archivo al servidor y en caso de que se suba con éxito se guarda en la base de datos.
        /// Sin embargo, se nos presenta un problema: cuando subimos el fichero se debe comprimir y guardar con el nombre del id del material y no
        /// sabemos este id hasta que no guardemos el material en la base de datos.
        /// Para solucionar esto hacemos una transacción, es decir, cuando llamamos a la función Guardar creamos una
        /// transacción y guardamos el material en la base de datos. Una vez subido el material, si se ha subido correctamente,
        /// llamamos a esta función. En esta función, antes de hacer commit de la transacción, obtenenemos el id del
        /// último material insertado, que es el nuestro. A continuación, actualizamos el nombre del archivo por el id
        /// del material y la extensión ".zip" y finalmente hacemos commit de la transacción.
        /// <returns>Devuelve el id del material para poder comprimir con ese nombre.</returns>
        /// </summary>
        public int CompletarGuardar()
        {
            return MaterialCAD.Instancia.CompletarGuardar();
        }

        /// <summary>
        /// En caso de que cuando estabamos subiendo un nuevo material se produzca algún error, cancelamos
        /// la transacción pendiente y no actualizamos la base de datos.
        /// <returns>Devuelve true si se ha cancelado correctamente la transacción o false en caso contrario.</returns>
        /// </summary>
        public bool CancelarGuardar()
        {
            return MaterialCAD.Instancia.CancelarGuardar();
        }

        /// <summary>
        /// Borramos el material de la base de datos.
        /// <returns>Devuelve true si se ha podido borrar el material o false en caso contrario.</returns>
        /// </summary>
        override public bool Borrar()
        {
            return MaterialCAD.Instancia.Borrar(this);
        }

        /// <summary>
        /// Actualizamos el material en la base de datos con los cambios que se hayan realizado.
        /// <returns>Devuelve true si se ha podido actualizar el material o false en caso contrario.</returns>
        /// </summary>
        override public bool Actualizar()
        {
            return MaterialCAD.Instancia.Actualizar(this);
        }

        /// <summary>
        /// Obtenemos todos los comentarios que tenga el material.
        /// </summary>
        public ArrayList ObtenerComentarios()
        {
            return MaterialCAD.Instancia.ObtenerComentarios(this);
        }

        /// <summary>
        /// Obtenemos el comentario que tenga esa id.
        /// </summary>
        public static ComentarioMaterial ObtenerComentario(int id)
        {
            return MaterialCAD.Instancia.ObtenerComentario(id);
        }

        /// <summary>
        /// Creamos / guardamos un nuevo comentario en la base de datos.
        /// <returns>Devuelve true si se ha podido crear el material o false en caso contrario.</returns>
        /// </summary>
        public bool GuardarComentario(ComentarioMaterial comentario)
        {
            return MaterialCAD.Instancia.GuardarComentario(comentario);
        }

        /// <summary>
        /// Actualizamos el comentario en la base de datos con los cambios realizados.
        /// <returns>Devuelve true si se ha podido actualizar el material o false en caso contrario.</returns>
        /// </summary>
        public bool ActualizarComentario(ComentarioMaterial comentario)
        {
            return MaterialCAD.Instancia.ActualizarComentario(comentario);
        }

        /// <summary>
        /// Borramos el comentario de la base de datos.
        /// <returns>Devuelve true si se ha podido borrar el material o false en caso contrario.</returns>
        /// </summary>
        public static bool BorrarComentario(ComentarioMaterial comentario)
        {
            return MaterialCAD.Instancia.BorrarComentario(comentario);
        }

        /// <summary>
        /// Obtiene el número de materiales total que hay en la base de datos.
        /// </summary>
        public static int NumMateriales()
        {
            return MaterialCAD.Instancia.NumMateriales();
        }

        /// <summary>
        /// Obtiene el último material creado en la base de datos.
        /// </summary>
        public static ENMaterial Ultimo()
        {
            return MaterialCAD.Instancia.Ultimo();
        }

        /// <summary>
        /// Identificador único del material.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Nombre descriptivo del material.
        /// </summary>
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        /// <summary>
        /// Descripción larga del material.
        /// </summary>
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        /// <summary>
        /// Fecha en la que se creo el material.
        /// </summary>
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        /// <summary>
        /// Usuario que creo el material.
        /// </summary>
        public ENUsuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        /// <summary>
        /// Categoría a la que pertenece el material.
        /// </summary>
        public ENCategoria Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        /// <summary>
        /// Ruta relativa del archivo. Cuando se sube por primera vez el archivo
        /// se guarda la ruta absoluta del archivo, pero cuando se sube al servidor
        /// se guarda la ruta relativa donde aparece el id del material y la extensión ".zip".
        /// </summary>
        public string Archivo
        {
            get { return archivo; }
            set { archivo = value; }
        }

        /// <summary>
        /// Tamaño del archivo expresado en bytes. Cuando se muestra el tamaño se hará una conversión
        /// dependiendo del tamaño a MB,KB o lo que corresponda.
        /// </summary>
        public int Tamaño
        {
            get { return tamaño; }
            set { tamaño = value; }
        }

        /// <summary>
        /// Número de veces que se ha descargado el material.
        /// </summary>
        public int Descargas
        {
            get { return descargas; }
            set { descargas = value; }
        }

        /// <summary>
        /// Puntuación que tiene el material a partir de la media de los votos de los usuarios.
        /// </summary>
        public int Puntuacion
        {
            get { return puntuacion; }
            set { puntuacion = value; }
        }

        /// <summary>
        /// Número de veces que se ha votado el material (un usuario sólo puede votar una vez).
        /// </summary>
        public int Votos
        {
            get { return votos; }
            set { votos = value; }
        }

        /// <summary>
        /// Lugar de donde se ha sacado la información del material.
        /// </summary>
        public string Referencia
        {
            get { return referencia; }
            set { referencia = value; }
        }

        /// <summary>
        /// Número de comentarios que tiene el material.
        /// </summary>
        public int NumComentarios
        {
            get { return numComentarios; }
            set { numComentarios = value; }
        }
    }

    /// <remarks>
    /// Para los comentarios que se hacen de cada material necesitamos una estructura auxiliar donde guardamos
    /// la información del comentario, como la id, el texto, la fecha, el usuario que hace el comentario, etc.
    /// Como un comentario es propiedad del material no usamos una entidad aparte, si no que incluimos la clase
    /// dentro de la entidad de material y usamos el cad de material.
    /// </remarks>
    public class ComentarioMaterial
    {
        private int id;
        private string texto;
        private DateTime fecha;
        private ENUsuario usuario;
        private ENMaterial material;

        static int minTamTexto = 1;
        static int maxTamTexto = 1000;

        /// <summary>
        /// Identificador único del comentario.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Texto que contiene el comentario.
        /// </summary>
        public string Texto
        {
            get { return texto; }
            set { texto = value; }
        }

        /// <summary>
        /// Fecha en que se realizó el comentario.
        /// </summary>
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        /// <summary>
        /// Uusuario que realizó el comentario.
        /// </summary>
        public ENUsuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        /// <summary>
        /// Material al que pertenece el comentario.
        /// </summary>
        public ENMaterial Material
        {
            get { return material; }
            set { material = value; }
        }

        /// <summary>
        /// Valida una propidad de un comentario.
        /// </summary>
        /// <param name="comentario">Comentario que vamos a validar.</param>
        /// <param name="propiedad">Nombre de la propiedad a validar.</param>
        /// <returns>Devuelve "OK" si es válida o un mensaje de error personalizado.</returns>
        public static string Validar(ComentarioMaterial comentario, string propiedad)
        {
            string error = "OK";
            switch (propiedad)
            {
                case "texto":
                    {
                        if (comentario.Texto.Length < minTamTexto || comentario.Texto.Length > maxTamTexto)
                            error = "El texto debe tener una longitud entre " + minTamTexto + " y " + maxTamTexto;
                        break;
                    }
                case "usuario":
                    {
                        if (comentario.Usuario == null)
                            error = "Usuario no válido";
                        break;
                    }
                case "material":
                    {
                        if (comentario.Material == null)
                            error = "Material no válido";
                        break;
                    }
            }
            return error;
        }
    }
}
