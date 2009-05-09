using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

namespace Libreria
{
    /// <summary>
    /// Clase singleton que realiza el acceso a la base de datos para manipular las categorias.
    /// </summary>
    sealed class CategoriaCAD
    {        
        private String cadenaConexion;        
        private static readonly CategoriaCAD instancia = new CategoriaCAD();

        /// <summary>
        /// Obtiene la única instancia de la clase CategoriasCAD. Si es la primera vez
        /// que se invoca el método, se crea el objeto; si no, sólo se devuelve la referencia
        /// al objeto que ya fue creado anteriormente.
        /// </summary>
        /// <returns>Devuelve una referencia a la única instancia de la clase.</returns>
        public static CategoriaCAD Instancia
        {
            get { return instancia; }
        }
        /// <summary>
        /// Constructor en el ámbito privado de la clase para no permitir 
        /// más de una instancia.
        /// </summary>
        private CategoriaCAD()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["cacatua"].ConnectionString;
        }

        /// <summary>
        /// Crea una categoria a partir de una fila de la consulta a la base de datos.
        /// </summary>
        /// <param name="reader">Contenedor de una fila de la base de datos</param>
        /// <returns>Devuelve un objeto ENCategoria instanciado.</returns>
        private ENCategoria obtenerDatos(SqlDataReader reader)
        {
            ENCategoria categoria = new ENCategoria();
            categoria.Id = int.Parse(reader["id"].ToString());
            categoria.Nombre = reader["nombre"].ToString();
            categoria.Descripcion = reader["descripcion"].ToString();
            if (reader["padre"].ToString() != "")
            {
                categoria.Padre = int.Parse(reader["padre"].ToString());
            }
            else
            {
                categoria.Padre = 0;
            }
            return categoria;
        }

        /// <summary>
        /// Obtiene una categoria a partir de un identificador.
        /// </summary>
        /// <param name="id">Entero que identifica a la categoria buscada.</param>
        /// <returns>Devuelve el objeto si existe, en caso contrario 'null'</returns>
        public ENCategoria Obtener(int id)
        {
            ENCategoria categoria = null;

            SqlConnection conexion = null;
            try
            {
                // Creamos la conexion
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "SELECT * FROM CATEGORIAS where id = @idcat";
                comando.Parameters.AddWithValue("@idcat", id);

                SqlDataReader reader = comando.ExecuteReader();
                // Recorremos el reader y vamos insertando en el array list
                while (reader.Read())
                {
                    categoria = obtenerDatos(reader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepción en el método Obtener(id): ");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return categoria;
        }

        /// <summary>
        /// Crea una categoria en la base de datos.
        /// </summary>
        /// <param name="categoria">Categoria a insertar en la base de datos.</param>
        /// <param name="id">Identificador que tomara valor al crear el objeto.</param>
        /// <returns>Devuelve 'true' si el objeto se ha creado correctamente.</returns>
        public bool Crear(ENCategoria categoria, out int id)
        {
            id = 0;
            bool creada = false;
            SqlConnection conexion = null;
            try
            {

                // Creamos la conexion
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión
                conexion.Open();
                // Creamos el comando
                SqlCommand comando = new SqlCommand();
                // Le asignamos la conexión al comando
                comando.Connection = conexion;

                if (categoria.Padre == 0)
                {
                    comando.CommandText = "BEGIN TRAN " +
                                          "INSERT INTO " +
                                          "CATEGORIAS (nombre,descripcion) " +
                                          "VALUES (@nombre,@descripcion); " +
                                          "select max(id) as id from CATEGORIAS; " + 
                                          "COMMIT TRAN";
                    comando.Parameters.AddWithValue("@nombre", categoria.Nombre);
                    comando.Parameters.AddWithValue("@descripcion", categoria.Descripcion);
                }
                else
                {
                    comando.CommandText = "BEGIN TRAN " + 
                                          "INSERT INTO " +
                                          "CATEGORIAS (nombre,descripcion,padre) " +
                                          "VALUES (@nombre,@descripcion,@padre); " +
                                          "select max(id) as id from CATEGORIAS; " + 
                                          "COMMIT TRAN";
                    comando.Parameters.AddWithValue("@nombre", categoria.Nombre);
                    comando.Parameters.AddWithValue("@descripcion", categoria.Descripcion);
                    comando.Parameters.AddWithValue("@padre", categoria.Padre);
                }

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    creada = true;
                    id = int.Parse(reader["id"].ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepción en el método Crear(categoria,id): ");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return creada;
        }

        /// <summary>
        /// Actualiza una categoria en la base de datos.
        /// </summary>
        /// <param name="categoria">Categoria a actualizar en la base de datos.</param>
        /// <returns>Devuelve 'true' si el objeto se ha actualizado correctamente.</returns>
        public bool Actualizar(ENCategoria categoria)
        {
            int resultado = 0;
            bool actualizada = false;
            SqlConnection conexion = null;

            try
            {
                // Creamos la conexion
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión
                conexion.Open();
                // Creamos el comando
                SqlCommand comando = new SqlCommand();
                // Le asignamos la conexión al comando
                comando.Connection = conexion;
                if (categoria.Padre == 0) {
                    comando.CommandText = "UPDATE CATEGORIAS " +
                        "SET nombre = @nombre,descripcion = @descripcion,padre = NULL " +
                        "WHERE id = @id";
                    comando.Parameters.AddWithValue("@nombre", categoria.Nombre);
                    comando.Parameters.AddWithValue("@descripcion", categoria.Descripcion);
                    comando.Parameters.AddWithValue("@id", categoria.Id);
                }
                else
                {
                    comando.CommandText = "UPDATE CATEGORIAS " +
                        "SET nombre = @nombre,descripcion = @descripcion,padre = @padre " +
                        "WHERE id = @id";
                    comando.Parameters.AddWithValue("@nombre", categoria.Nombre);
                    comando.Parameters.AddWithValue("@descripcion", categoria.Descripcion);
                    comando.Parameters.AddWithValue("@padre", categoria.Padre);
                    comando.Parameters.AddWithValue("@id", categoria.Id);
                }
                resultado = comando.ExecuteNonQuery();
                if (resultado == 1)
                    actualizada = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepción en el método Actualizar(categoria): ");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return actualizada;
        }

        /// <summary>
        /// Borrar una categoria de la base de datos.
        /// </summary>
        /// <param name="categoria">Categoria a borrar en la base de datos.</param>
        /// <returns>Devuelve 'true' si el objeto se ha borrado correctamente.</returns>
        public bool Borrar(ENCategoria categoria)
        {
            int resultado = 0;
            bool borrada = false;
            SqlConnection conexion = null;

            try
            {
                // Creamos la conexion
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión
                conexion.Open();
                // Creamos el comando
                SqlCommand comando = new SqlCommand();
                // Le asignamos la conexión al comando
                comando.Connection = conexion;
                comando.CommandText = "DELETE FROM CATEGORIAS " +
                    "WHERE id = @id";
                comando.Parameters.AddWithValue("@id", categoria.Id);
                resultado = comando.ExecuteNonQuery();
                if (resultado == 1)
                    borrada = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepción en el método Borrar(categoria): ");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return borrada;
        }

        /// <summary>
        /// Obtiene el conjunto de categorias superiores (no tienen padre).
        /// </summary>
        /// <returns>Lista que contiene los objetos que son categorias superiores.</returns>
        public ArrayList ObtenerSuperiores()
        {
            ArrayList categorias = new ArrayList();
            
            SqlConnection conexion = null;
            try
            {
                // Creamos la conexion
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión
                conexion.Open();
                string cadenaComando = "SELECT * FROM CATEGORIAS where padre is NULL";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                // Recorremos el reader y vamos insertando en el array list
                while (reader.Read())
                {
                    ENCategoria categoria = obtenerDatos(reader);
                    categorias.Add(categoria);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepción en el método ObtenerSuperiores(): ");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return categorias;
        }

        /// <summary>
        /// Obtiene las categorias que son hijas de otra.
        /// </summary>
        /// <param name="padre">Categoria padre.</param>
        /// <returns>Lista que contiene los objetos que son hijos del parámetro.</returns>
        public ArrayList HijosDe(ENCategoria padre)
        {
            ArrayList hijos = new ArrayList();
            SqlConnection conexion = null;
            try
            {
                // Creamos la conexion
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "SELECT * FROM CATEGORIAS where padre = @idpadre";
                comando.Parameters.AddWithValue("@idpadre", padre.Id);

                SqlDataReader reader = comando.ExecuteReader();
                // Recorremos el reader y vamos insertando en el array list
                while (reader.Read())
                {
                    ENCategoria categoria = obtenerDatos(reader);
                    hijos.Add(categoria);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepción en el método HijosDe(categoria): ");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return hijos;
        }

        /// <summary>
        /// Obtiene la descendencia completa de una categoría.
        /// Es una especie de cola. Se recorre la cola hasta llegar al final pero por cada elemento de la cola se le añaden sus hijos.
        /// Sería un recorrido por niveles del árbol de categorías.
        /// </summary>
        /// <param name="padre">Categoría que va a ser examinada para sacar su descendencia.</param>
        /// <returns>Devuelve una lista con la lista de ENCategoria (recorrido por niveles).</returns>
        public ArrayList DescendenciaDe(ENCategoria padre)
        {
            ArrayList descendencia = HijosDe(padre);

            for (int i = 0; i < descendencia.Count; i++)
            {
                descendencia.AddRange(HijosDe((ENCategoria) descendencia[i]));
            }
            return descendencia;
        }

        /// <summary>
        /// Obtiene todos los usuarios suscritos a una categoria.
        /// </summary>
        /// <param name="categoria">Categoria de la que queremos los usuarios suscritos.</param>
        /// <returns>Lista de usuarios suscritos a la categoria determinada.</returns>
        public ArrayList UsuariosSuscritosA(ENCategoria categoria, int numPagina)
        {
            ArrayList usuarios = new ArrayList();
            SqlConnection conexion = null;
            try
            {
                // Creamos la conexion
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                int desde = ((numPagina - 1) * 10) + 1;
                int hasta = numPagina * 10;
                comando.CommandText = "SELECT usuario FROM (" +
                                      "SELECT *, ROW_NUMBER() OVER (ORDER BY usuario) " +
                                      "as fila FROM SUSCRIPCIONES WHERE categoria = @idcat) " +
                                      "as alias WHERE fila >= " + desde.ToString() + " and fila <= " + hasta.ToString() + 
                                      " ORDER BY usuario asc";            
                comando.Parameters.AddWithValue("@idcat", categoria.Id);
                SqlDataReader reader = comando.ExecuteReader();
                // Recorremos el reader y vamos insertando en el array list
                while (reader.Read())
                {
                    ENUsuario usuario = ENUsuario.Obtener(int.Parse(reader["usuario"].ToString()));
                    usuarios.Add(usuario);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepción en el método UsuariosSuscritosA(categoria): ");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return usuarios;
        }


        /// <summary>
        /// Obtiene el número de usuarios suscritos a una determinada categoria.
        /// </summary>
        /// <param name="cat">Categoria asociada</param>
        /// <returns>Entero que indica el número de usuarios suscritos a la categoria.</returns>
        public int NumSuscritos(ENCategoria categoria)
        {
            int n = 0;
            SqlConnection conexion = null;
            try
            {
                // Creamos la conexion
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "SELECT count(*) numero " +
                                      "FROM SUSCRIPCIONES " +
                                      "WHERE categoria = @idcat";
                comando.Parameters.AddWithValue("@idcat", categoria.Id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    n = int.Parse(reader["numero"].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepción en el método NumSuscritos(categoria): ");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return n;
        }

        /// <summary>
        /// Obtiene el número de hilos asociados a una categoria.
        /// </summary>
        /// <param name="categoria">Categoría asociada.</param>
        /// <returns>Entero que indica el número de hilos.</returns>
        public int NumHilosEn(ENCategoria categoria)
        {
            int n = 0;
            SqlConnection conexion = null;
            try
            {
                // Creamos la conexion
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "SELECT count(*) numero FROM HILOS where categoria = @idcat";
                comando.Parameters.AddWithValue("@idcat", categoria.Id);

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    n = int.Parse(reader["numero"].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepción en el método NumHilos(): ");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return n;
        }

        /// <summary>
        /// Obtiene el número de materiales asociados a una categoria.
        /// </summary>
        /// <param name="categoria">Categoría asociada.</param>
        /// <returns>Entero que indica el número de materiales.</returns>
        public int NumMaterialesEn(ENCategoria categoria)
        {
            int n = 0;
            SqlConnection conexion = null;
            try
            {
                // Creamos la conexion
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "SELECT count(*) numero FROM MATERIALES where categoria = @idcat";
                comando.Parameters.AddWithValue("@idcat", categoria.Id);

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    n = int.Parse(reader["numero"].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepción en el método NumMateriales(): ");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return n;
        }

        /// <summary>
        /// Obtiene el numero de categorias totales en la base de datos.
        /// </summary>
        /// <returns>Entero que indica el número de categorias.</returns>
        public int NumCategorias()
        {
            int n = 0;
            SqlConnection conexion = null;
            try
            {
                // Creamos la conexion
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "SELECT count(*) numero FROM CATEGORIAS";

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    n = int.Parse(reader["numero"].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepción en el método NumCategorias(): ");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return n;
        }

        public bool EstaSuscritoA(ENUsuario usuario, ENCategoria categoria)
        {
            int resultado = 0;
            bool retorno = false;
            SqlConnection conexion = null;

            try
            {
                // Creamos la conexion
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión
                conexion.Open();
                // Creamos el comando
                SqlCommand comando = new SqlCommand();
                // Le asignamos la conexión al comando
                comando.Connection = conexion;
                comando.CommandText = "SELECT count(*) numero FROM SUSCRIPCIONES " +
                    "WHERE categoria = @categoria and usuario = @usuario";
                comando.Parameters.AddWithValue("@usuario", usuario.Id);
                comando.Parameters.AddWithValue("@categoria", categoria.Id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    resultado = int.Parse(reader["numero"].ToString());
                }
                if (resultado == 1)
                    retorno = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepción en el método EstaSuscritoA(usuario,categoria): ");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return retorno;
        }

        /// <summary>
        /// Suscribe un usuario a una categoria.
        /// </summary>
        /// <param name="categoria">Categoria a la que suscribir.</param>
        /// <param name="usuario">Usuario a suscribir.</param>
        /// <returns>'true' si el usuario se ha suscrito correctamente.</returns>
        public bool AñadirSuscripcion(ENCategoria categoria, ENUsuario usuario)
        {
            int resultado = 0;
            bool añadido = false;
            SqlConnection conexion = null;
            try
            {
                // Creamos la conexion
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión
                conexion.Open();
                // Creamos el comando
                SqlCommand comando = new SqlCommand();
                // Le asignamos la conexión al comando
                comando.Connection = conexion;
                comando.CommandText = "INSERT INTO " +
                                          "SUSCRIPCIONES (categoria,usuario) " +
                                          "VALUES (@categoria,@usuario)";
                comando.Parameters.AddWithValue("@categoria", categoria.Id);
                comando.Parameters.AddWithValue("@usuario", usuario.Id);
 
                resultado = comando.ExecuteNonQuery();
                if (resultado == 1)
                    añadido = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepción en el método AñadirSuscripcion(): ");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return añadido;
        }

        /// <summary>
        /// Insuscribe un usuario a una categoria.
        /// </summary>
        /// <param name="categoria">Categoria a la que insuscribir.</param>
        /// <param name="usuario">Usuario a insuscribir.</param>
        /// <returns>'true' si el usuario se ha insuscrito correctamente.</returns>
        public bool QuitarSuscripcion(ENCategoria categoria, ENUsuario usuario)
        {
            int resultado = 0;
            bool quitado = false;
            SqlConnection conexion = null;
            try
            {
                // Creamos la conexion
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión
                conexion.Open();
                // Creamos el comando
                SqlCommand comando = new SqlCommand();
                // Le asignamos la conexión al comando
                comando.Connection = conexion;
                comando.CommandText = "DELETE FROM SUSCRIPCIONES " +
                                      "WHERE usuario = @usuario and categoria = @categoria";
                comando.Parameters.AddWithValue("@categoria", categoria.Id);
                comando.Parameters.AddWithValue("@usuario", usuario.Id);

                resultado = comando.ExecuteNonQuery();
                if (resultado == 1)
                    quitado = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepción en el método QuitarSuscripcion(): ");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return quitado;
        }

        public ArrayList CategoriasDe(ENUsuario usuario)
        {
            ArrayList categorias = new ArrayList();
            
            SqlConnection conexion = null;
            try
            {
                // Creamos la conexion
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión
                conexion.Open();
                string  cadenaComando = "SELECT * FROM CATEGORIAS where id IN (";
                        cadenaComando += "SELECT categoria FROM SUSCRIPCIONES where usuario = @usuario";
                        cadenaComando += ")";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                comando.Parameters.AddWithValue("@usuario", usuario.Id);
                SqlDataReader reader = comando.ExecuteReader();
                // Recorremos el reader y vamos insertando en el array list
                while (reader.Read())
                {
                    ENCategoria categoria = obtenerDatos(reader);
                    categorias.Add(categoria);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepción en el método CategoriasDe(usuario): ");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return categorias;
        }
    }
}
