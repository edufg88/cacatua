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
        /// Obtiene una entidad de negocio Hilo desde una lectura de la base de datos.
        /// </summary>
        /// <param name="dataReader">Lectura de la base de datos desde la que se genera el ENHilo.</param>
        /// <returns>Devuelve un ENHilo.</returns>
        private ENRespuesta obtenerDatos(SqlDataReader dataReader)
        {
            ENRespuesta respuesta = new ENRespuesta();
            respuesta.Id = int.Parse(dataReader["id"].ToString());
            respuesta.Autor = new ENUsuario(int.Parse(dataReader["autor"].ToString()));
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
            return null;
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
                comando.CommandText = "select * from respuesta where id = @id";
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
                Console.WriteLine("ENRespuesta RespuestaCAD.Obtener(ind id) " + ex.Message);
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
            id = 0;
            return false;
        }

        public bool Borrar (int id)
        {
            return false;
        }

        public bool Actualizar(ENRespuesta respuesta)
        {
            return false;
        }
    }
}
