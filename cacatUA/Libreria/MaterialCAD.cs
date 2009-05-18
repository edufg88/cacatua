using System;
using System.Collections.Generic;
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
    /// Clase que realiza el acceso a la base de datos para manipular los materiales.
    /// </summary>
    public class MaterialCAD
    {
        private String cadenaConexion;
        private SqlTransaction transaccion;

        /// <summary>
        /// Constructor en el ámbito privado de la clase para no permitir más
        /// de una instancia.
        /// </summary>
        public MaterialCAD()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["cacatua"].ConnectionString;
            transaccion = null;
        }

        /// <summary>
        /// Actualizamos el material en la base de datos con los nuevos cambios
        /// <returns>Devuelve true si si todo ha ido correctamente o false si se produce algún error</returns>
        /// </summary>
        public bool Actualizar(ENMaterial material)
        {
            bool correcto = false;
            if (material != null)
            {
                SqlConnection conexion = null;
                try
                {
                    conexion = new SqlConnection(cadenaConexion);
                    // Abrimos la conexión.
                    conexion.Open();

                    // Creamos el comando.
                    string cadenaComando = "UPDATE materiales SET nombre = @nombre, descripcion = @descripcion," +
                        "usuario = @usuario, categoria = @categoria, tamaño = @tamaño," +
                        "referencia = @referencia, descargas = @descargas WHERE id = @id";
                    SqlCommand comando = new SqlCommand(cadenaComando, conexion);

                    comando.Parameters.AddWithValue("@id", material.Id);
                    comando.Parameters.AddWithValue("@nombre", material.Nombre);
                    comando.Parameters.AddWithValue("@descripcion", material.Descripcion);
                    comando.Parameters.AddWithValue("@usuario", material.Usuario.Id);
                    comando.Parameters.AddWithValue("@categoria", material.Categoria.Id);
                    comando.Parameters.AddWithValue("@tamaño", material.Tamaño);
                    comando.Parameters.AddWithValue("@referencia", material.Referencia);
                    comando.Parameters.AddWithValue("@descargas", material.Descargas);

                    if (comando.ExecuteNonQuery() == 1)
                        correcto = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("<ENMaterial::Actualizar> " + ex.Message);
                }
                finally
                {
                    if (conexion != null)
                        conexion.Close();
                }
            }
            else
                Console.WriteLine("<ENMaterial::Actualizar> material == null");
            return correcto;
        }

        /// <summary>
        /// Crea o guarda el material en la base de datos. En esta función únicamente crea una transacción
        /// y luego hay que llamar a otra función para completar la transacción o cancelarla en función de si
        /// se ha subido bien el material o no.
        /// <returns>Devuelve true si si todo ha ido correctamente o false si se produce algún error</returns>
        /// </summary>
        public bool Guardar(ENMaterial material)
        {
            bool correcto = false;
            if (material != null)
            {
                SqlConnection conexion = null;
                try
                {
                    conexion = new SqlConnection(cadenaConexion);
                    // Abrimos la conexión.
                    conexion.Open();

                    transaccion = conexion.BeginTransaction();

                    // Creamos el comando.
                    string cadenaComando = "INSERT INTO " +
                        "Materiales(nombre,descripcion,usuario,categoria,archivo,tamaño,referencia) " +
                        "VALUES (@nombre,@descripcion,@usuario,@categoria,@archivo,@tamaño,@referencia);";
                    SqlCommand comando = new SqlCommand(cadenaComando, conexion, transaccion);

                    comando.Parameters.AddWithValue("@nombre", material.Nombre);
                    comando.Parameters.AddWithValue("@descripcion", material.Descripcion);
                    comando.Parameters.AddWithValue("@usuario", material.Usuario.Id);
                    comando.Parameters.AddWithValue("@categoria", material.Categoria.Id);
                    comando.Parameters.AddWithValue("@archivo", material.Archivo);
                    comando.Parameters.AddWithValue("@tamaño", material.Tamaño);
                    comando.Parameters.AddWithValue("@referencia", material.Referencia);

                    if (comando.ExecuteNonQuery() == 1)
                        correcto = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("<ENMaterial::Guardar> " + ex.Message);
                    transaccion = null;
                    if (conexion != null)
                        conexion.Close();
                }
            }
            else
                Console.WriteLine("<ENMaterial::Guardar> material == null");
            return correcto;
        }

        /// <summary>
        /// En caso de que cuando estabamos subiendo un nuevo material se produzca algún error, cancelamos
        /// la transacción pendiente y no actualizamos la base de datos.
        /// <returns>Devuelve true si se ha cancelado correctamente la transacción o false en caso contrario.</returns>
        /// </summary>
        public bool CancelarGuardar()
        {
            bool correcto = false;
            try
            {
                if (transaccion != null)
                {
                    transaccion.Rollback();
                    if (transaccion.Connection != null)
                        transaccion.Connection.Close();
                    transaccion = null;
                    correcto = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("<ENMaterial::CancelarGuardar> " + ex.Message);
            }
            return correcto;
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
            int id = -1;
            try
            {
                // Obtenemos el id del material creado
                string cadenaComando = "SELECT MAX(id) as id FROM materiales";
                SqlCommand comando = new SqlCommand(cadenaComando, transaccion.Connection, transaccion);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    id = int.Parse(reader["id"].ToString());
                    // Cerramos el reader
                    reader.Close();

                    // Actualizamos el nombre del archivo a la id
                    cadenaComando = "UPDATE materiales SET archivo = @archivo WHERE id = @id";
                    comando = new SqlCommand(cadenaComando, transaccion.Connection, transaccion);
                    comando.Parameters.AddWithValue("@archivo", id.ToString() + ".zip");
                    comando.Parameters.AddWithValue("@id", id);
                    if (comando.ExecuteNonQuery() != 1)
                    {
                        id = -1;
                        Console.WriteLine("<ENMaterial::CompletarGuardar> ERROR al modificar el nombre del archivo");
                    }

                    // Completamos la transacción
                    transaccion.Commit();
                    ENMaterial material = ENMaterial.Obtener(id);
                    if (material != null)
                    {
                        ArrayList usuarios = material.Categoria.UsuariosSuscritos();
                        foreach (ENUsuario i in usuarios)
                        {
                            ENMensaje mensaje = new ENMensaje();
                            mensaje.Emisor = i;
                            mensaje.Receptor = i;
                            mensaje.Texto = "Se ha añadido un nuevo material a la categoría " + material.Categoria.Nombre
                                + " con el nombre " + material.Nombre;
                            mensaje.Guardar();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("<ENMaterial::CompletarGuardar> " + ex.Message);
            }
            finally
            {                
                if (transaccion.Connection!= null)
                    transaccion.Connection.Close();
                transaccion = null;
            }
            return id;
        }

        /// <summary>
        /// Obtenemos todos los materiales que hay en la base de datos.
        /// </summary>
        public ArrayList Obtener()
        {
            ArrayList materiales = new ArrayList();
            SqlConnection conexion = null;
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión.
                conexion.Open();

                string cadenaComando = "SELECT * FROM vistaMateriales";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ENMaterial material = ObtenerDatos(reader);
                    materiales.Add(material);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("<ENMaterial::Obtener> " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return materiales;
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
        public ArrayList Obtener(string propiedadOrdenar, bool ascendente, int pagina, int cantidadPorPagina, BusquedaMaterial busqueda)
        {
            ArrayList materiales = new ArrayList();
            SqlConnection conexion = null;
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión.
                conexion.Open();

                // Creamos el comando.
                SqlCommand comando = new SqlCommand();

                // Le asignamos la conexión al comando.
                comando.Connection = conexion;

                // Cálculamos las filas de inicio y fin a partir de la página
                int filaInicio = (pagina - 1) * cantidadPorPagina + 1;
                int filaFinal = filaInicio - 1 + cantidadPorPagina;

                // Formamos dos comandos, uno para obtener el número de resultados total sin paginación y
                // otro para obtener los materiales paginados con toda la información
                string comandoSinPaginacion = "";
                string comandoConPaginacion = "";
                string cadenaComun = "";

                comandoSinPaginacion += "SELECT count(*) as numResultados FROM vistaMateriales WHERE ";
                comandoConPaginacion += "SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY " + propiedadOrdenar;
                if (ascendente == true)
                    comandoConPaginacion += " ASC";
                else
                    comandoConPaginacion += " DESC";
                comandoConPaginacion += ") as row FROM vistaMateriales WHERE"; 

                cadenaComun += "(nombre like @nombre or descripcion like @descripcion) ";
                if (busqueda.Usuario != null)
                {
                    cadenaComun += "and usuario = @usuario ";
                    comando.Parameters.AddWithValue("@usuario", busqueda.Usuario.Id);
                }
                if (busqueda.Categoria != null)
                {
                    cadenaComun += "and categoria in (" + busqueda.Categoria.Id.ToString();
                    ArrayList descencientes = busqueda.Categoria.ObtenerDescendencia();
                    foreach (ENCategoria i in descencientes)
                        cadenaComun += "," + i.Id.ToString();
                    cadenaComun += ")";
                    //cadenaComun += "and categoria = @categoria";
                    //comando.Parameters.AddWithValue("@categoria", busqueda.Categoria.Id);
                }
                cadenaComun += " and fecha between @fechaInicio and @fechaFin";
                comando.Parameters.AddWithValue("@fechaInicio", busqueda.FechaInicio);
                comando.Parameters.AddWithValue("@fechaFin", busqueda.FechaFin);

                comandoSinPaginacion += cadenaComun;
                comandoConPaginacion += cadenaComun;
                comandoConPaginacion += " ) as alias WHERE row >= @filaInicio and row <= @filaFinal";

                // Obtenemos los resultados con paginación
                comando.CommandText = comandoConPaginacion;
                comando.Parameters.AddWithValue("@nombre", "%" + busqueda.FiltroBusqueda + "%");
                comando.Parameters.AddWithValue("@descripcion", "%" + busqueda.FiltroBusqueda + "%");
                comando.Parameters.AddWithValue("@filaInicio", filaInicio);
                comando.Parameters.AddWithValue("@filaFinal", filaFinal);
                SqlDataReader reader = comando.ExecuteReader();
                // Recorremos el reader y vamos insertando en el array list
                while (reader.Read())
                {
                    ENMaterial material = ObtenerDatos(reader);
                    materiales.Add(material);
                }

                // Obtenemos los resultados sin paginación
                comando.CommandText = comandoSinPaginacion;
                reader.Close();
                reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    // Guardamos los resultados de la búsqueda
                    busqueda.NumResultados = int.Parse(reader["numResultados"].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("<ENMaterial::Obtener> " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return materiales;
        }

        /// <summary>
        /// Inicializamos un material a partir de los datos del reader.
        /// </summary>
        private ENMaterial ObtenerDatos(SqlDataReader reader)
        {
            ENMaterial material = new ENMaterial();
            try
            {
                material.Id = int.Parse(reader["id"].ToString());
                material.Nombre = reader["nombre"].ToString();
                material.Descripcion = reader["descripcion"].ToString();
                material.Fecha = (DateTime)reader["fecha"];
                material.Usuario = ENUsuario.Obtener(int.Parse(reader["usuario"].ToString()));
                material.Categoria = new ENCategoria(int.Parse(reader["categoria"].ToString()));
                material.Archivo = reader["archivo"].ToString();
                material.Tamaño = int.Parse(reader["tamaño"].ToString());
                material.Descargas = int.Parse(reader["descargas"].ToString());
                material.Puntuacion = int.Parse(reader["puntuacion"].ToString());
                material.Votos = int.Parse(reader["votos"].ToString());
                material.Referencia = reader["referencia"].ToString();
                material.NumComentarios = int.Parse(reader["numComentarios"].ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("<ENMaterial::Obtener> " + e.Message);
                material = null;
            }
            return material;
        }

        /// <summary>
        /// Obtenemos un material a partir de un id.
        /// </summary>
        public ENMaterial Obtener(int id)
        {
            ENMaterial material = null;
            SqlConnection conexion = null;
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión.
                conexion.Open();

                // Creamos el comando.
                SqlCommand comando = new SqlCommand();

                // Le asignamos la conexión al comando.
                comando.Connection = conexion;

                string cadenaComando = "SELECT * FROM vistaMateriales where id = @id";
                comando.CommandText = cadenaComando;
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                // Recorremos el reader y vamos insertando en el array list objetos del tipo ENMaterialCRUD
                if (reader.Read())
                    material = ObtenerDatos(reader);
            }
            catch (Exception ex)
            {
                Console.WriteLine("<ENMaterial::Obtener> " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return material;
        }

        /// <summary>
        /// Borramos el material de la base de datos.
        /// <returns>Devuelve true si si todo ha ido correctamente o false si se produce algún error.</returns>
        /// </summary>
        public bool Borrar(ENMaterial material)
        {
            bool borrado = false;
            SqlConnection conexion = null;
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión.
                conexion.Open();

                // Creamos el comando.
                SqlCommand comando = new SqlCommand();

                // Le asignamos la conexión al comando.
                comando.Connection = conexion;

                string cadenaComando = "DELETE FROM materiales where id = @id";
                comando.CommandText = cadenaComando;
                comando.Parameters.AddWithValue("@id", material.Id);
                if (comando.ExecuteNonQuery() == 1)
                    borrado = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("<ENMaterial::Borrar> " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return borrado;
        }

        /// <sumary>
        /// Votamos el material
        /// </sumary>
        public bool Votar(ENMaterial material, ENUsuario usuario, int puntuacion)
        {
            bool votado = false;
            SqlConnection conexion = null;
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión.
                conexion.Open();

                // Creamos el comando.
                SqlCommand comando = new SqlCommand();

                // Le asignamos la conexión al comando.
                comando.Connection = conexion;

                string cadenaComando = "INSERT INTO materialesvotos(material,usuario,puntuacion) "
                    + "VALUES(@material,@usuario,@puntuacion)";

                comando.CommandText = cadenaComando;
                comando.Parameters.AddWithValue("@material", material.Id);
                comando.Parameters.AddWithValue("@usuario", usuario.Id);
                comando.Parameters.AddWithValue("@puntuacion", puntuacion);

                if (comando.ExecuteNonQuery() == 1)
                    votado = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("<ENMaterial::Votar> " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return votado;
        }

        /// <summary>
        /// Devuelve la puntuación que le ha dado un determinado usuario a un material.
        /// Si no ha votado al material, devuelve 0.
        /// </summary>
        public int PuntuacionUsuario(ENMaterial material, ENUsuario usuario)
        {
            int puntuacion = -1;
            SqlConnection conexion = null;
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión.
                conexion.Open();

                // Creamos el comando.
                SqlCommand comando = new SqlCommand();

                // Le asignamos la conexión al comando.
                comando.Connection = conexion;

                string cadenaComando = "SELECT * FROM materialesvotos WHERE material = @material AND usuario = @usuario";

                comando.CommandText = cadenaComando;
                comando.Parameters.AddWithValue("@material", material.Id);
                comando.Parameters.AddWithValue("@usuario", usuario.Id);

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                    puntuacion = int.Parse(reader["puntuacion"].ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("<ENMaterial::PuntuacionUsuario> " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return puntuacion;
        }

        /// <summary>
        /// Inicializamos un comentario a partir del reader
        /// </summary>
        private ComentarioMaterial ObtenerDatosComentario(SqlDataReader reader)
        {
            ComentarioMaterial comentario = new ComentarioMaterial();
            try
            {
                comentario.Id = int.Parse(reader["id"].ToString());
                comentario.Texto = reader["texto"].ToString();
                comentario.Fecha = (DateTime)reader["fecha"];
                comentario.Usuario = ENUsuario.Obtener(int.Parse(reader["usuario"].ToString()));
                comentario.Material = ENMaterial.Obtener(int.Parse(reader["material"].ToString()));
            }
            catch (Exception e)
            {
                Console.WriteLine("<ENMaterial::ObtenerDatosComentario> " + e.Message);
                comentario = null;
            }
            return comentario;
        }

        /// <summary>
        /// Obtenemos todos los comentarios de un material
        /// </summary>
        public ArrayList ObtenerComentarios(ENMaterial material)
        {
            ArrayList comentarios = new ArrayList();
            SqlConnection conexion = null;
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión.
                conexion.Open();

                // Creamos el comando.
                SqlCommand comando = new SqlCommand();

                // Le asignamos la conexión al comando.
                comando.Connection = conexion;

                string cadenaComando = "SELECT * FROM materialescomentarios WHERE material = @material";
                comando.CommandText = cadenaComando;
                comando.Parameters.AddWithValue("@material", material.Id);

                SqlDataReader reader = comando.ExecuteReader();
                // Recorremos el reader y vamos insertando en el array list
                while (reader.Read())
                {
                    ComentarioMaterial comentario = ObtenerDatosComentario(reader);
                    comentarios.Add(comentario);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("<ENMaterial::ObtenerComentarios> " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return comentarios;
        }


        public ArrayList ObtenerComentarios(ENMaterial material, int pagina, int cantidadPorPagina)
        {
            ArrayList comentarios = new ArrayList();
            SqlConnection conexion = null;
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión.
                conexion.Open();

                // Creamos el comando.
                SqlCommand comando = new SqlCommand();

                // Le asignamos la conexión al comando.
                comando.Connection = conexion;

                // Cálculamos las filas de inicio y fin a partir de la página
                int filaInicio = (pagina - 1) * cantidadPorPagina + 1;
                int filaFinal = filaInicio - 1 + cantidadPorPagina;


                string cadenaComando = "SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY id DESC)"
                    + " as row FROM materialescomentarios WHERE material = @material"
                    + ") as alias WHERE row >= @filaInicio and row <= @filaFinal";

                //string cadenaComando = "SELECT * FROM materialescomentarios WHERE material = @material";
                comando.CommandText = cadenaComando;
                comando.Parameters.AddWithValue("@material", material.Id);
                comando.Parameters.AddWithValue("@filaInicio", filaInicio);
                comando.Parameters.AddWithValue("@filaFinal", filaFinal);

                SqlDataReader reader = comando.ExecuteReader();
                // Recorremos el reader y vamos insertando en el array list
                while (reader.Read())
                {
                    ComentarioMaterial comentario = ObtenerDatosComentario(reader);
                    comentarios.Add(comentario);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("<ENMaterial::ObtenerComentarios> " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return comentarios;
        }

        /// <summary>
        /// Obtenemos el comentario a partir de la id.
        /// </summary>
        public ComentarioMaterial ObtenerComentario(int id)
        {
            ComentarioMaterial comentario = null;
            SqlConnection conexion = null;
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión.
                conexion.Open();

                // Creamos el comando.
                SqlCommand comando = new SqlCommand();

                // Le asignamos la conexión al comando.
                comando.Connection = conexion;

                string cadenaComando = "SELECT * FROM materialescomentarios WHERE id = @id";
                comando.CommandText = cadenaComando;
                comando.Parameters.AddWithValue("@id", id);        

                SqlDataReader reader = comando.ExecuteReader();
                // Recorremos el reader y vamos insertando en el array list
                if (reader.Read())
                    comentario = ObtenerDatosComentario(reader);
            }
            catch (Exception ex)
            {
                Console.WriteLine("<ENMaterial::ObtenerComentario> " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return comentario;
        }

        /// <summary>
        /// Creamos un comentario en la base de datos.
        /// </summary>
        public bool GuardarComentario(ComentarioMaterial comentario)
        {
            bool correcto = false;
            SqlConnection conexion = null;
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión.
                conexion.Open();

                // Creamos el comando.
                SqlCommand comando = new SqlCommand();

                // Le asignamos la conexión al comando.
                comando.Connection = conexion;
                comando.CommandText = "INSERT INTO " +
                    "materialescomentarios(texto,usuario,material) " +
                    "VALUES (@texto,@usuario,@material)";
                comando.Parameters.AddWithValue("@texto", comentario.Texto);
                comando.Parameters.AddWithValue("@usuario", comentario.Usuario.Id);
                comando.Parameters.AddWithValue("@material", comentario.Material.Id);
                if (comando.ExecuteNonQuery() == 1)
                    correcto = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("<ENMaterial::GuardarComentario> " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return correcto;
        }

        /// <summary>
        /// Borramos un comentario de la base de datos.
        /// <returns>Devuelve true si si todo ha ido correctamente o false si se produce algún error.</returns>
        /// </summary>
        public bool BorrarComentario(ComentarioMaterial comentario)
        {
            bool borrado = false;
            SqlConnection conexion = null;
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión.
                conexion.Open();

                // Creamos el comando.
                SqlCommand comando = new SqlCommand();

                // Le asignamos la conexión al comando.
                comando.Connection = conexion;
                comando.CommandText = "DELETE FROM materialescomentarios WHERE id = @id";
                comando.Parameters.AddWithValue("@id", comentario.Id);
                if (comando.ExecuteNonQuery() == 1)
                    borrado = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("<ENMaterial::BorrarComentario> " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return borrado;
        }

        /// <summary>
        /// Guardamos los cambios que se hayan hecho sobre el comentario.
        /// <returns>Devuelve true si si todo ha ido correctamente o false si se produce algún error.</returns>
        /// </summary>
        public bool ActualizarComentario(ComentarioMaterial comentario)
        {
            bool correcto = false;
            SqlConnection conexion = null;
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión.
                conexion.Open();

                // Creamos el comando.
                SqlCommand comando = new SqlCommand();

                // Le asignamos la conexión al comando.
                comando.Connection = conexion;
                comando.CommandText = "UPDATE materialescomentarios SET texto = @texto, fecha = @fecha, " +
                    "usuario = @usuario, material = @material WHERE id = @id";
                comando.Parameters.AddWithValue("@texto", comentario.Texto);
                comando.Parameters.AddWithValue("@fecha", comentario.Fecha);
                comando.Parameters.AddWithValue("@usuario", comentario.Usuario.Id);
                comando.Parameters.AddWithValue("@material", comentario.Material.Id);
                comando.Parameters.AddWithValue("@id", comentario.Id);
                if (comando.ExecuteNonQuery() == 1)
                    correcto = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("<ENMaterial::ActualizarComentario> " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return correcto;
        }

        /// <summary>
        /// Obtenemos el número de materiales total que hay en la base de datos.
        /// </summary>
        public int NumMateriales()
        {
            int cantidad = 0;
            SqlConnection conexion = null;
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();

                string sentencia = "SELECT COUNT(*) as cantidad FROM materiales";

                SqlCommand comando = new SqlCommand(sentencia, conexion);
                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                    cantidad = int.Parse(reader["cantidad"].ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("<ENMaterial::NumMateriales> " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return cantidad;
        }

        /// <summary>
        /// Obtenemos el último material que se ha creado en la base de datos.
        /// </summary>
        public ENMaterial Ultimo()
        {
            ENMaterial material = null;
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            try
            {
                conexion.Open(); // Abrimos la conexión
                SqlCommand comando = new SqlCommand(); // Creamos un SqlCommand
                comando.Connection = conexion; // Asignamos la cadena de conexión
                comando.CommandText = "SELECT * FROM vistaMateriales where id in (select max(id) from vistaMateriales)";

                // Creamo un objeto DataReader
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    // Extraemos la información del DataReader y la almacenamos
                    material = ObtenerDatos(reader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("<ENMaterial::Ultimo> " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return material;
        }
    }

    /// <summary>
    /// Estructura de datos auxiliar que se usa para realizar búsquedas y que nos permite, entre otras
    /// cosas, tener almacenada la última búsqueda que se ha realizado.
    /// </summary>
    public class BusquedaMaterial
    {
        private ENUsuario usuario;
        private ENCategoria categoria;
        private string filtroBusqueda;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private int numResultados;

        public BusquedaMaterial()
        {
            categoria = null;
            usuario = null;
            filtroBusqueda = "";
            numResultados = 0;
            fechaInicio = new DateTime(2008, 9, 1);
            fechaFin = DateTime.Now;
        }

        public ENUsuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public ENCategoria Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        public string FiltroBusqueda
        {
            get { return filtroBusqueda; }
            set { filtroBusqueda = value; }
        }

        public DateTime FechaInicio
        {
            get { return fechaInicio; }
            set { fechaInicio = value; }
        }

        public DateTime FechaFin
        {
            get { return fechaFin; }
            set { fechaFin = value; }
        }

        public int NumResultados
        {
            get { return numResultados; }
            set { numResultados = value; }
        }
    }
}