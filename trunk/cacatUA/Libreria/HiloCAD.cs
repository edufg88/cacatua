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
    sealed class HiloCAD
    {
        private static readonly HiloCAD instancia = new HiloCAD();
        private String cadenaConexion;

        /// <summary>
        /// Obtiene la única instancia de la clase HiloCAD. Si es la primera vez
        /// que se invoca el método, se crea el objeto; si no, sólo se devuelve la referencia
        /// al objeto que ya fue creado anteriormente.
        /// </summary>
        /// <returns>Devuelve una referencia a la única instancia de la clase.</returns>
        public static HiloCAD Instancia
        {
            get { return instancia; }
        }

        /// <summary>
        /// Constructor en el ámbito privado de la clase para no permitir más
        /// de una instancia.
        /// </summary>
        private HiloCAD()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["cacatua"].ConnectionString;
        }

        /// <summary>
        /// Obtiene una entidad de negocio Hilo desde una lectura de la base de datos.
        /// </summary>
        /// <param name="dataReader">Lectura de la base de datos desde la que se genera el ENHilo.</param>
        /// <returns>Devuelve un ENHilo.</returns>
        private ENHilo obtenerDatos(SqlDataReader dataReader)
        {
            ENHilo hilo = new ENHilo();
            hilo.Id = int.Parse(dataReader["id"].ToString());
            hilo.Autor = new ENUsuario(int.Parse(dataReader["autor"].ToString()));
            hilo.Texto = dataReader["texto"].ToString();
            hilo.Titulo = dataReader["titulo"].ToString();
            hilo.Categoria = new ENCategoria(int.Parse(dataReader["categoria"].ToString()));
            hilo.Fecha = (DateTime) dataReader["fechacreacion"];
            return hilo;
        }

        /// <summary>
        /// Obtiene un hilo desde la base de datos según su identificador (id).
        /// </summary>
        /// <param name="id">Identificador (id) del hilo que se va a obtener.</param>
        /// <returns>Devuelve un hilo extraído desde la base de datos. Si falla, devuelve null.</returns>
        public ENHilo Obtener(int id)
        {
            ENHilo hilo = null;

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
                comando.CommandText = "select * from hilos where id = @id";
                comando.Parameters.AddWithValue("@id", id);

                // Realizamos la consulta.
                SqlDataReader dataReader = comando.ExecuteReader();

                // Si hay al menos una fila, extraemos los valores de la primera.
                if (dataReader.Read())
                {
                    hilo = obtenerDatos(dataReader);
                }

                dataReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ENHilo HiloCAD.Obtener(ind id) " + ex.Message);
            }
            finally
            {
                if (conexion!=null)
                    conexion.Close();
            }

            return hilo;
        }

        /// <summary>
        /// Obtiene todos los hilos del foro (lista de ENHilo).
        /// </summary>
        /// <returns>Devuelve una lista de ENHilo con todos los hilos del foro. Si falla, devuelve null.</returns>
        public ArrayList Obtener()
        {
            ArrayList hilos = null;

            SqlConnection conexion = null;
            try
            {
                // Creamos y abrimos la conexión.
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();

                string sentencia = "select * from hilos";
                SqlCommand comando = new SqlCommand(sentencia, conexion);
                SqlDataReader dataReader = comando.ExecuteReader();

                hilos = new ArrayList();

                // Insertamos todas las filas extraidas en el vector.
                while (dataReader.Read())
                {
                    ENHilo hilo = obtenerDatos(dataReader);
                    hilos.Add(hilo);
                }

                dataReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ArrayList HiloCAD.Obtener() " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return hilos;
        }

        /// <summary>
        /// Obtiene una lista de hilos (ArrayList de ENHilo) indicando el número de página y la cantidad de
        /// hilos por página. También es necesario especificar el identificador (id) del hilo desde el que se
        /// va a empezar a contar.
        /// </summary>
        /// <param name="pagina">Número de página.</param>
        /// <param name="cantidad">Cantidad de hilos en cada página.</param>
        /// <param name="ultimoId">Identificador del último hilo que se devolvió.</param>
        /// <returns>Devuelve una lista de hilos (ArrayList de ENHilo). Si falla, devuelve null.</returns>
        public ArrayList Obtener(int pagina, int cantidad, int ultimoId)
        {
            ENUsuario usuario = null;
            ENCategoria categoria = null;
            DateTime fecha = DateTime.Now;
            return Obtener(pagina, cantidad, ultimoId, "", "", ref usuario, ref fecha, ref fecha, ref categoria);
        }

        /// <summary>
        /// Obtiene una lista de hilos (ArrayList de ENHilo) según un filtro de búsqueda. Es necesario
        /// indicar un número de página, la cantidad de elementos por página y un identificador desde el que se van a 
        /// obtener los hilos.
        /// Sólo devuelve aquellos hilos que coincidan con el título especificado, texto especificado, etc.
        /// Si se especifican con cadena vacía, todos los hilos son coincidentes.
        /// </summary>
        /// <param name="pagina">Número de página.</param>
        /// <param name="cantidad">Cantidad de hilos en cada página.</param>
        /// <param name="ultimoId">Identificador del último hilo que se devolvió.</param>
        /// <param name="titulo">Título para el filtro de búsqueda.</param>
        /// <param name="texto">Texto para el filtro de búsqueda.</param>
        /// <param name="autor">Autor para el filtro de búsqueda.</param>
        /// <param name="fechaInicio">Fecha de inicio par el filtro de búsqueda.</param>
        /// <param name="fechaFin">Fecha de fin para el filtro de búsqueda.</param>
        /// <param name="categoria">Categoria para el filtro de búsqueda.</param>
        /// <returns>Devuelve una lista de hilos (ArrayList de ENHilo). Si falla, devuelve null.</returns>
        public ArrayList Obtener(int pagina, int cantidad, int ultimoId, String titulo, String texto
            , ref ENUsuario autor, ref DateTime fechaInicio, ref DateTime fechaFin, ref ENCategoria categoria)
        {
            ArrayList hilos = null;

            SqlConnection conexion = null;
            try
            {
                // Creamos y abrimos la conexión.
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();

                // Componemos la cadena de la sentencia.
                string sentencia = "select * from hilos ";
                if (titulo != "")
                    sentencia += "where (titulo like '%"+@titulo+"%' ";
                else
                    sentencia += "where (titulo like '%' ";
                if (texto != "")
                    sentencia += "or texto like '%"+@texto+"%') ";
                else
                    sentencia += "or texto like '%') ";
                if (autor != null)
                    sentencia += "and autor = @autor ";
                if (fechaInicio != fechaFin)
                    sentencia += "and fechacreacion between @fechainicio and @fechafin ";
                if (categoria != null)
                    sentencia += "and categoria = @categoria ";

                // Asignamos la cadena de sentencia y establecemos los parámetros.
                SqlCommand comando = new SqlCommand(sentencia, conexion);
                if (titulo != "")
                    comando.Parameters.AddWithValue("@titulo", titulo);
                if (texto != "")
                    comando.Parameters.AddWithValue("@texto", texto);
                if (autor != null)
                    comando.Parameters.AddWithValue("@autor", autor.Id);
                if (fechaInicio <= fechaFin)
                {
                    comando.Parameters.AddWithValue("@fechainicio", fechaInicio);
                    comando.Parameters.AddWithValue("@fechafin", fechaFin);
                }
                if (categoria != null)
                    comando.Parameters.AddWithValue("@categoria", categoria.Id);

                // Realizamos la consulta.
                SqlDataReader dataReader = comando.ExecuteReader();

                // Insertamos todas las filas extraidas en el vector.
                hilos = new ArrayList();
                while (dataReader.Read())
                {
                    ENHilo material = obtenerDatos(dataReader);
                    hilos.Add(material);
                }

                // Cerramos la consulta.
                dataReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ArrayList HiloCAD.Obtener() " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return hilos;
        }

        /// <summary>
        /// Guarda el nuevo hilo recibido por los parámetros en la base de datos.
        /// </summary>
        /// <param name="hilo">Hilo que se va a guardar en la base de datos.</param>
        /// <param name="id">Identificador que se le asigna al hilo después de insertarse.</param>
        /// <returns>Devuelve verdadero si se ha introducido correctamente.</returns>
        public bool Guardar(ENHilo hilo, out int id)
        {
            bool insertado = false;
            id = 0;

            if (hilo.Autor != null && hilo.Categoria != null)
            {
                SqlConnection conexion = null;
                try
                {
                    conexion = new SqlConnection(cadenaConexion);
                    conexion.Open();

                    string cadena0 = "BEGIN TRAN";
                    string cadena1 = "insert into hilos (titulo, texto, autor, fechacreacion, categoria) values (@titulo, @texto, @autor, @fechacreacion, @categoria);";
                    string cadena2 = "select max(id) as id from hilos;";
                    string cadena3 = "COMMIT TRAN";

                    string sentencia = cadena0 + " " + cadena1 + " " + cadena2 + " " + cadena3;

                    SqlCommand comando = new SqlCommand(sentencia, conexion);
                    comando.Parameters.AddWithValue("@titulo", hilo.Titulo);
                    comando.Parameters.AddWithValue("@texto", hilo.Texto);
                    comando.Parameters.AddWithValue("@autor", hilo.Autor.Id);
                    comando.Parameters.AddWithValue("@fechacreacion", hilo.Fecha);
                    comando.Parameters.AddWithValue("@categoria", hilo.Categoria.Id);

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
                    Console.WriteLine("bool HiloCAD.Guardar(ENHilo) " + ex.Message);
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
        /// Borra el hilo que se corresponda con el 'id' recibido en los parámetros.
        /// </summary>
        /// <param name="id">Identificador (id) del hilo que se va a borrar desde la base de datos.</param>
        /// <returns>Devuelve verdadero si se ha borrado correctamente.</returns>
        public bool Borrar(int id)
        {
            bool borrado = false;

            SqlConnection conexion = null;
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();

                string cadenaComando = "delete from hilos where id = @id";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                comando.Parameters.AddWithValue("@id", id);

                if (comando.ExecuteNonQuery() == 1)
                    borrado = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("bool HiloCAD.Borrar(int) " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return borrado;
        }

        /// <summary>
        /// Guarda los cambios del hilo recibido en los parámetros. El hilo ya debe existir.
        /// </summary>
        /// <param name="hilo">Hilo que se va a actualizar.</param>
        /// <returns>Devuelve verdadero si se ha guardado correctamente.</returns>
        public bool Actualizar(ENHilo hilo)
        {
            bool actualizado = false;

            if (hilo.Autor != null && hilo.Categoria != null)
            {
                SqlConnection conexion = null;
                try
                {
                    conexion = new SqlConnection(cadenaConexion);
                    conexion.Open();

                    string sentencia = "update hilos set titulo = @titulo, texto = @texto, autor = @autor, fechacreacion = @fechacreacion, categoria = @categoria where id = @id";

                    SqlCommand comando = new SqlCommand(sentencia, conexion);
                    comando.Parameters.AddWithValue("@titulo", hilo.Titulo);
                    comando.Parameters.AddWithValue("@texto", hilo.Texto);
                    comando.Parameters.AddWithValue("@autor", hilo.Autor.Id);
                    comando.Parameters.AddWithValue("@fechacreacion", hilo.Fecha);
                    comando.Parameters.AddWithValue("@categoria", hilo.Categoria.Id);
                    comando.Parameters.AddWithValue("@id", hilo.Id);

                    if (comando.ExecuteNonQuery() == 1)
                    {
                        actualizado = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("bool HiloCAD.Guardar(ENHilo) " + ex.Message);
                }
                finally
                {
                    if (conexion != null)
                        conexion.Close();
                }
            }

            return actualizado;
        }
    }
}
