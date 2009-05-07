using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;

namespace Libreria
{
    // Clase singleton
    // Componente de Acceso a Datos para relacionarse con la BD 'encuestas'
    sealed class EncuestaCAD
    {
        private static readonly EncuestaCAD instancia = new EncuestaCAD();
        private String cadenaConexion;

        // Devuelve la instancia única de la clase
        public static EncuestaCAD Instancia
        {
            get { return(instancia); }
        }

        // El constructor privado crea la cadena de conexión
        private EncuestaCAD()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["cacatua"].ConnectionString;
        }

        // Extrae los datos de un objeto DataReader y los almacena en un 
        // ENEncuesta que devuelve
        public ENEncuesta ObtenerDatos(SqlDataReader dr)
        {
            ENEncuesta encuesta = new ENEncuesta();

            encuesta.Id = int.Parse(dr["id"].ToString());
            encuesta.Pregunta = dr["pregunta"].ToString();
            encuesta.Usuario = UsuarioCAD.Instancia.ObtenerUsuario(int.Parse(dr["usuario"].ToString()));
            encuesta.Fecha = DateTime.Parse(dr["fecha"].ToString());

            if (int.Parse(dr["activa"].ToString()) == 0)
            {
                encuesta.Activa = false;
            }
            else
            {
                encuesta.Activa = true;
            }

            return (encuesta);
        }

        // Devuelve una determinada encuesta a partir de un id
        public ENEncuesta ObtenerEncuesta(int id)
        {
            ENEncuesta encuesta = null;

            try
            {
                SqlConnection conexion = new SqlConnection(cadenaConexion);
                conexion.Open(); // Abrimos la conexión
                SqlCommand comando = new SqlCommand(); // Creamos un SqlCommand
                comando.Connection = conexion; // Asignamos la cadena de conexión
                comando.CommandText = "SELECT * FROM encuestas where id = @id"; // Asignamos la sentencia SQL
                comando.Parameters.AddWithValue("@id", id);

                // Creamo un objeto DataReader
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    // Extraemos la información del DataReader y la almacenamos
                    // en un objeto ENEncuesta
                    encuesta = ObtenerDatos(dr);
                }

                conexion.Close();
            }
            catch (SqlException)
            {
                Console.Write("Excepcion obtener encuesta");
            }

            return encuesta;
        }

        // Devuelve la lista de encuestas
        public ArrayList ObtenerEncuestas()
        {
            ArrayList encuestas = new ArrayList();
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "SELECT * FROM encuestas";
                SqlDataReader dr = comando.ExecuteReader();
                // Generamos el ArrayList a partir del DataReader
                while (dr.Read())
                {
                    ENEncuesta encuesta = ObtenerDatos(dr);
                    encuestas.Add(encuesta);
                }

                conexion.Close();
            }
            catch (SqlException)
            {
                Console.Write("Excepción obtener encuestas");
            }
        
            return encuestas;
        }

        // Borra todas las encuestas
        public void BorrarEncuestas()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "DELETE FROM encuestas";
                comando.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                Console.Write("Excepción borrando todas las encuestas");
            }
        }

        // Borra una encuesta dado un determinado id
        public bool BorrarEncuesta(int id)
        {
            bool borrado = false;
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "DELETE FROM encuestas where id = @id";
                comando.Parameters.AddWithValue("@id", id);

                if ((comando.ExecuteNonQuery()) == 1) // Comprobamos cuantas filas se borran
                {
                    borrado = true;
                }

                conexion.Close();
            }
            catch (SqlException)
            {
                Console.Write("Excepcion borrar encuestas");
            }

            return (borrado);
        }

        public bool GuardarEncuesta(string pregunta, string usuario, bool activa)
        {
            bool guardado = false;
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            
            // Obtenemos los usuarios por nombre para obtener su id
            ENUsuario us = ENUsuario.Obtener(usuario);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();

                comando.Connection = conexion;
                comando.CommandText = "INSERT INTO " +
                    "encuestas (pregunta, usuario, activa) " +
                    "VALUES (@pregunta, @usuario, @activa) ";
                comando.Parameters.AddWithValue("@pregunta", pregunta);
                comando.Parameters.AddWithValue("@usuario", us.Id);
                comando.Parameters.AddWithValue("@activa", activa);
                
                if (comando.ExecuteNonQuery() == 1)
                {
                    guardado = true;
                }

                conexion.Close();
            }
            catch (SqlException)
            {
                Console.Write("Excepcion guardar fecha");
            }

            return (guardado);
        }

        public ArrayList BuscarEncuesta(int usuario)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            ArrayList encuestas = new ArrayList();

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "SELECT * FROM encuestas WHERE usuario = @usuario";
                comando.Parameters.AddWithValue("@usuario", usuario);
                SqlDataReader dr = comando.ExecuteReader();
                // Generamos el ArrayList a partir del DataReader
                while (dr.Read())
                {
                    ENEncuesta encuesta = ObtenerDatos(dr);
                    encuestas.Add(encuesta);
                }
            }
            catch (SqlException ex)
            {
                Console.Write("Error al buscar encuesta por usuario " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }

            return (encuestas);
        }

        public ArrayList BuscarEncuesta(string asunto, DateTime fecha)
        {
            bool usarAsunto = false;
            bool usarFecha = false;
            string cadenaFecha = "";
   
            if (asunto != "")
            {
                usarAsunto = true;
            }
            if (fecha.Date != DateTime.Now.Date)
            {
                usarFecha = true;

                // Generamos una cadena a partir de la fecha
                cadenaFecha += fecha.Day;
                cadenaFecha += "/";
                cadenaFecha += fecha.Month;
                cadenaFecha += "/";
                cadenaFecha += fecha.Year;
            }

            SqlConnection conexion = new SqlConnection(cadenaConexion);
            ArrayList encuestas = new ArrayList();

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();

                comando.Connection = conexion;

                comando.CommandText = "SELECT * FROM encuestas WHERE ";
                
                if (usarAsunto)
                {
                    comando.CommandText += "(pregunta = @pregunta) ";
                    comando.Parameters.AddWithValue("@pregunta", asunto);
                }

                if (usarFecha)
                {
                    if (usarAsunto)
                    {
                        comando.CommandText += "AND ";
                    }
                    comando.CommandText += "(fecha = @fecha) ";
                    comando.Parameters.AddWithValue("@fecha", cadenaFecha);
                }                

                SqlDataReader dr = comando.ExecuteReader();
                // Generamos el ArrayList a partir del DataReader
                while (dr.Read())
                {
                    ENEncuesta encuesta = ObtenerDatos(dr);
                    encuestas.Add(encuesta);
                }

                conexion.Close();
            }
            catch (SqlException sqlex)
            {
                Console.Write("Excepcion buscar encuesta" + sqlex.Message);
            }

            return encuestas;
        }

        public bool Actualizar(ENEncuesta encuesta)
        {
            bool actualizado = false;

            SqlConnection conexion = null;
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();

                string sentencia = "update encuestas set pregunta = @pregunta, usuario = @usuario, fecha = @fecha, activa = @activa where id = @id";

                SqlCommand comando = new SqlCommand(sentencia, conexion);
                comando.Parameters.AddWithValue("@pregunta", encuesta.Pregunta);
                comando.Parameters.AddWithValue("@usuario", encuesta.Usuario.Id);
                comando.Parameters.AddWithValue("@fecha", encuesta.Fecha);
                comando.Parameters.AddWithValue("@activa", encuesta.Activa);
                comando.Parameters.AddWithValue("@id", encuesta.Id);

                if (comando.ExecuteNonQuery() == 1)
                {
                    actualizado = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar una encuesta" + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return actualizado;
        }

        public int CantidadEncuestas(int usuario)
        {
            SqlConnection conexion = null;
            int cantidad = 0;

            try
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                string sentencia = "SELECT COUNT(*) FROM encuestas WHERE usuario = @usuario";

                SqlCommand comando = new SqlCommand(sentencia, conexion);
                comando.Parameters.AddWithValue("@usuario", usuario);

                cantidad = int.Parse(comando.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al contar encuestas " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return cantidad;
        }

        public OpcionEncuesta ObtenerDatosOpcion(SqlDataReader dr)
        {
            int id = int.Parse(dr["id"].ToString());
            String opcion  = dr["opcion"].ToString();
            ENEncuesta encuesta = ENEncuesta.Obtener(int.Parse(dr["encuesta"].ToString()));
            return (new OpcionEncuesta(id,opcion,encuesta));
        }

        public OpcionEncuesta ObtenerOpcion(int id) 
        {
            SqlConnection conexion = null;
            OpcionEncuesta opcion = null;

            try {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                string sentencia = "SELECT * FROM opciones WHERE id = @id";
                SqlCommand comando = new SqlCommand(sentencia, conexion);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                // Recorremos el reader y vamos insertando en el array list
                while (reader.Read())
                {
                    opcion = ObtenerDatosOpcion(reader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ObtenerOpcion(int): " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return opcion;
        }

        public bool CrearOpcion(OpcionEncuesta opcion) 
        {
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

                comando.CommandText = "BEGIN TRAN " +
                                      "INSERT INTO " +
                                      "OPCIONES (opcion,encuesta) " +
                                      "VALUES (@opcion,@encuesta); " +
                                      "select max(id) as id from OPCIONES; " +
                                      "COMMIT TRAN";
                comando.Parameters.AddWithValue("@opcion", opcion.Opcion);
                comando.Parameters.AddWithValue("@encuesta", opcion.Encuesta.Id);


                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    creada = true;
                    opcion.Id = int.Parse(reader["id"].ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepción en el método Crear(opcion): ");
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

        public bool ActualizarOpcion(OpcionEncuesta opcion)
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
                comando.CommandText = "UPDATE OPCIONES " +
                    "SET opcion = @opcion " +
                    "WHERE id = @id";
                comando.Parameters.AddWithValue("@opcion", opcion.Opcion);
                comando.Parameters.AddWithValue("@id", opcion.Id);
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
   
        public bool BorrarOpcion(OpcionEncuesta opcion) 
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
                comando.CommandText = "DELETE FROM OPCIONES " +
                    "WHERE id = @id";
                comando.Parameters.AddWithValue("@id", opcion.Id);
                resultado = comando.ExecuteNonQuery();
                if (resultado == 1)
                    borrada = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepción en el método Borrar(opcion): ");
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

        public bool VotarOpcion(ENUsuario usuario, OpcionEncuesta opcion) 
        {
            bool votada = false;
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
                                      "OPCIONESVOTOS (usuario,opcion) " +
                                      "VALUES (@usuario,@opcion); ";
                comando.Parameters.AddWithValue("@opcion", opcion.Id);
                comando.Parameters.AddWithValue("@usuario", usuario.Id);


                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    votada = true;
                    opcion.Id = int.Parse(reader["id"].ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepción en el método Crear(opcion): ");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return votada;
        }
        
    }
}
