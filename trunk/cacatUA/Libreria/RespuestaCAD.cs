using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

namespace Libreria
{
    /// <summary>
    /// Clase singleton que realiza el acceso a la base de datos para manipular los hilos.
    /// </summary>
    sealed class RespuestaCAD
    {
        private static readonly RespuestaCAD instancia = new RespuestaCAD();
        private String cadenaConexion;

        /// <summary>
        /// Obtiene la única instancia de la clase RespuestaCAD. Si es la primera vez
        /// que se invoca el método, se crea el objeto; si no, sólo se devuelve la referencia
        /// al objeto que ya fue creado anteriormente.
        /// </summary>
        /// <returns>Devuelve una referencia a la única instancia de la clase.</returns>
        public static RespuestaCAD Instancia
        {
            get { return instancia; }
        }

        /// <summary>
        /// Constructor en el ámbito privado de la clase para no permitir más
        /// de una instancia.
        /// </summary>
        private RespuestaCAD()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["cacatua"].ConnectionString;
        }

        /// <summary>
        /// Obtiene una entidad de negocio Respuesta desde una lectura de la base de datos.
        /// </summary>
        /// <param name="dataReader">Lectura de la base de datos desde la que se genera el ENRespuesta.</param>
        /// <returns>Devuelve un ENRespuesta.</returns>
        private ENRespuesta obtenerDatos(SqlDataReader dataReader)
        {
            ENRespuesta respuesta = new ENRespuesta();
            respuesta.Id = int.Parse(dataReader["id"].ToString());
            respuesta.Autor = ENUsuario.Obtener(int.Parse(dataReader["autor"].ToString()));
            respuesta.Texto = dataReader["texto"].ToString();
            respuesta.Hilo = ENHilo.Obtener(int.Parse(dataReader["hilo"].ToString()));
            respuesta.Fecha = (DateTime)dataReader["fecha"];
            return respuesta;
        }

        /// <summary>
        /// Obtiene las respuestas de un hilo. Si el hilo no tiene respuestas, se obtiene una lista
        /// de longitud 0. Si ocurre un error, devuelve una lista nula.
        /// </summary>
        /// <param name="hilo">Hilo del que se van a obtener sus respuestas.</param>
        /// <returns>
        /// Devuelve una lista de respuestas (ArrayList de ENRespuesta). Si ocurre un error, esta
        /// lista es null; si no, es una lista con 0 o más elementos.
        /// </returns>
        public ArrayList Obtener (ENHilo hilo)
        {
            ArrayList respuestas = null;

            SqlConnection conexion = null;
            try
            {
                // Creamos y abrimos la conexión.
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();

                string sentencia = "select * from respuestas where hilo = @id";
                SqlCommand comando = new SqlCommand(sentencia, conexion);
                comando.Parameters.AddWithValue("@id", hilo.Id);
                SqlDataReader dataReader = comando.ExecuteReader();

                respuestas = new ArrayList();

                // Insertamos todas las filas extraidas en el vector.
                while (dataReader.Read())
                {
                    respuestas.Add(obtenerDatos(dataReader));
                }

                dataReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ArrayList RespuestaCAD.Obtener(ENHilo) " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return respuestas;
        }

        /// <summary>
        /// Obtiene una respuesta según el identificador indicado.
        /// </summary>
        /// <param name="id">Identificador de la respuesta que se va a obtener.</param>
        /// <returns>Devuelve la respuesta del identificador seleccionado. Si falla, devuelve null.</returns>
        public ENRespuesta Obtener(int id)
        {
            ENRespuesta respuesta = null;

            SqlConnection conexion = null;
            try
            {
                // Creamos y abrimos la conexión.
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();

                // Creamos el comando.
                SqlCommand comando = new SqlCommand();

                // Le asignamos la conexión al comando.
                comando.Connection = conexion;
                comando.CommandText = "select * from respuestas where id = @id";
                comando.Parameters.AddWithValue("@id", id);

                // Realizamos la consulta.
                SqlDataReader dataReader = comando.ExecuteReader();

                // Si hay al menos una fila, extraemos los valores de la primera.
                if (dataReader.Read())
                {
                    respuesta = obtenerDatos(dataReader);
                }

                dataReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ENRespuesta RespuestaCAD.Obtener(int id) " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return respuesta;
        }

        /// <summary>
        /// Guarda una nueva respuesta en la base de datos. Se supone que esta respuesta no existe en la base de datos.
        /// </summary>
        /// <param name="respuesta">Respuesta que se va a insertar.</param>
        /// <param name="id">Identificador que se le asignará a esta respuesta después de insertarse.</param>
        /// <returns>Devuelve verdadero si se ha insertado correctamente.</returns>
        public bool Guardar (ENRespuesta respuesta, out int id)
        {
            bool insertado = false;
            id = 0;

            if (respuesta.Autor != null && respuesta.Hilo != null)
            {
                SqlConnection conexion = null;
                try
                {
                    conexion = new SqlConnection(cadenaConexion);
                    conexion.Open();

                    string cadena0 = "BEGIN TRAN";
                    string cadena1 = "insert into respuestas (texto, autor, hilo) values (@texto, @autor, @hilo);";
                    string cadena2 = "select max(id) as id from respuestas;";
                    string cadena3 = "COMMIT TRAN";

                    string sentencia = cadena0 + " " + cadena1 + " " + cadena2 + " " + cadena3;

                    SqlCommand comando = new SqlCommand(sentencia, conexion);
                    comando.Parameters.AddWithValue("@texto", respuesta.Texto);
                    comando.Parameters.AddWithValue("@autor", respuesta.Autor.Id);
                    comando.Parameters.AddWithValue("@hilo", respuesta.Hilo.Id);

                    SqlDataReader dataReader = comando.ExecuteReader();

                    if (dataReader.Read())
                    {
                        insertado = true;
                        id = int.Parse(dataReader["id"].ToString());
                    }

                    dataReader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("bool RespuestaCAD.Guardar(ENRespuesta, out int) " + ex.Message);
                }
                finally
                {
                    if (conexion != null)
                        conexion.Close();
                }
            }

            return insertado;
        }

        /// <summary>
        /// Borra una respuesta de la base de datos dado su identificador.
        /// </summary>
        /// <param name="id">Identificador de la respuesta que se va a borrar.</param>
        /// <returns>
        /// Devuelve verdadero si se ha borrado con éxito o falso si no se ha borrado.
        /// Es posible que no se borre si no existía.
        /// </returns>
        public bool Borrar (int id)
        {
            bool borrado = false;

            SqlConnection conexion = null;
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();

                string cadenaComando = "delete from respuestas where id = @id";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                comando.Parameters.AddWithValue("@id", id);

                if (comando.ExecuteNonQuery() == 1)
                    borrado = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("bool RespuestaCAD.Borrar(int) " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return borrado;
        }

        /// <summary>
        /// Actualiza una respuesta que ya está creada en la base de datos.
        /// </summary>
        /// <param name="respuesta">Respuesta que se va a actualizar.</param>
        /// <returns>Devuelve verdadero si la respuesta ya existía y ha sido actualizada correctamente. Falso en caso contrario.</returns>
        public bool Actualizar(ENRespuesta respuesta)
        {
            bool actualizado = false;

            if (respuesta.Autor != null && respuesta.Hilo != null)
            {
                SqlConnection conexion = null;
                try
                {
                    conexion = new SqlConnection(cadenaConexion);
                    conexion.Open();

                    string sentencia = "update respuestas set texto = @texto, autor = @autor where id = @id and hilo = @hilo";

                    SqlCommand comando = new SqlCommand(sentencia, conexion);
                    comando.Parameters.AddWithValue("@texto", respuesta.Texto);
                    comando.Parameters.AddWithValue("@autor", respuesta.Autor.Id);
                    comando.Parameters.AddWithValue("@hilo", respuesta.Hilo.Id);
                    comando.Parameters.AddWithValue("@id", respuesta.Id);

                    if (comando.ExecuteNonQuery() == 1)
                    {
                        actualizado = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("bool RespuestaCAD.Actualizar(ENRespuesta) " + ex.Message);
                }
                finally
                {
                    if (conexion != null)
                        conexion.Close();
                }
            }

            return actualizado;
        }

        /// <summary>
        /// Realiza una consulta a la base de datos para obtener la cantidad de 
        /// respuestas que hay en total en todo el foro.
        /// </summary>
        /// <returns>Devuelve un valor entero con la cantidad de hilos del foro.</returns>
        public int Cantidad()
        {
            ENHilo hilo = null;
            return Cantidad(hilo);
        }

        /// <summary>
        /// Realiza una consulta a la base de datos para obtener la cantidad de respuestas totales
        /// de un hilo.
        /// </summary>
        /// <returns>Devuelve un valor entero con la cantidad de respuestas del hilo.</returns>
        public int Cantidad(ENHilo hilo)
        {
            int cantidad = 0;
            SqlConnection conexion = null;
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();

                string sentencia = "select count(*) as cantidad from respuestas where 1=1";
                if (hilo != null)
                    sentencia += " and hilo = @hilo";

                SqlCommand comando = new SqlCommand(sentencia, conexion);
                if (hilo != null)
                    comando.Parameters.AddWithValue("@hilo", hilo.Id);

                SqlDataReader dataReader = comando.ExecuteReader();

                if (dataReader.Read())
                {
                    cantidad = int.Parse(dataReader["cantidad"].ToString());
                }

                dataReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("int RespuestaCAD.Cantidad(ENHilo) " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return cantidad;
        }

        /// <summary>
        /// Obtiene la última respuesta de la base de datos.
        /// </summary>
        /// <returns>Devuelve la última respuesta insertada en la base de datos. Si falla, devuelve null.</returns>
        public ENRespuesta Ultimo()
        {
            ENHilo hilo = null;
            return Ultimo(hilo);
        }

        public ENRespuesta Ultimo(ENHilo hilo)
        {
            ENRespuesta respuesta = null;

            SqlConnection conexion = null;
            try
            {
                // Creamos y abrimos la conexión.
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();

                // Creamos el comando.
                SqlCommand comando = new SqlCommand();

                // Le asignamos la conexión al comando.
                comando.Connection = conexion;
                comando.CommandText = "select * from respuestas where id in (select max(id) from respuestas)";
                if (hilo!=null)
                {
                    comando.CommandText += " and hilo = @hilo";
                    comando.Parameters.AddWithValue("@hilo", hilo.Id);
                }

                // Realizamos la consulta.
                SqlDataReader dataReader = comando.ExecuteReader();

                // Si hay al menos una fila, extraemos los valores de la primera.
                if (dataReader.Read())
                {
                    respuesta = obtenerDatos(dataReader);
                }

                dataReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ENRespuesta RespuestaCAD.Ultimo(ENHilo) " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return respuesta;
        }
    }
}
