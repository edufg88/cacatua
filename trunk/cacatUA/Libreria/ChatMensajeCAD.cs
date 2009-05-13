using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

namespace Libreria
{
    class ChatMensajeCAD
    {
        private String cadenaConexion;

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public ChatMensajeCAD()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["cacatua"].ConnectionString;
        }

        public bool Guardar(ENChatMensaje chat)
        {
            bool correcto = false;
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
                comando.CommandText = "INSERT INTO chat(usuario,mensaje) VALUES (@usuario,@mensaje)";
                comando.Parameters.AddWithValue("@usuario", chat.Usuario.Id);
                comando.Parameters.AddWithValue("@mensaje", chat.Mensaje);

                if (comando.ExecuteNonQuery() == 1)
                    correcto = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("<ChatCAD::Guardar> " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return correcto;
        }

        public bool BorrarMensajesAntiguos(int maxMensajes, int conservarMensajes)
        {
            bool correcto = false;
            SqlConnection conexion = null;
            try
            {
                // Comprobamos si hay mas de maxMensajes mensajes en la base de datos
                int numMensajes = NumMensajes();
                if (numMensajes > maxMensajes)
                {
                    // Borramos los maxMensajes-20 primeros mensajes
                    ENChatMensaje ultimo = Ultimo();
                    int id = ultimo.Id - conservarMensajes;

                    // Creamos y abrimos la conexión.
                    conexion = new SqlConnection(cadenaConexion);
                    conexion.Open();

                    // Creamos el comando.
                    SqlCommand comando = new SqlCommand();

                    // Le asignamos la conexión al comando.
                    comando.Connection = conexion;
                    comando.CommandText = "DELETE FROM chat WHERE id < @id";
                    comando.Parameters.AddWithValue("@id", id);                
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("<ChatCAD::BorrarMensajesAntiguos> " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return correcto;
        }

        public bool Borrar(ENChatMensaje chat)
        {
            bool correcto = false;
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
                comando.CommandText = "DELETE FROM chat WHERE id = @id";
                comando.Parameters.AddWithValue("@id", chat.Id);

                if (comando.ExecuteNonQuery() == 1)
                    correcto = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("<ChatCAD::Borrar> " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return correcto;
        }

        public bool Actualizar(ENChatMensaje chat)
        {
            bool correcto = false;
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
                comando.CommandText = "UPDATE chat SET usuario = @usuario,fecha = @fecha," 
                    + "mensaje = @mensaje WHERE id = @id";
                comando.Parameters.AddWithValue("@id", chat.Id);

                if (comando.ExecuteNonQuery() == 1)
                    correcto = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("<ChatCAD::Actualizar> " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return correcto;
        }

        /// <summary>
        /// Obtiene todos los mensajes cuyo id sea mayor que el id del mensaje que se le pasa
        /// </summary>
        public ArrayList Obtener(ENChatMensaje mensaje)
        {
            ArrayList mensajes = new ArrayList();
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

                string cadenaComando = "SELECT * FROM chat WHERE id > @id";
                comando.CommandText = cadenaComando;
                comando.Parameters.AddWithValue("@id", mensaje.Id);

                SqlDataReader reader = comando.ExecuteReader();
                // Recorremos el reader y vamos insertando en el array list
                while (reader.Read())
                {
                    ENChatMensaje chat = ObtenerDatos(reader);
                    mensajes.Add(chat);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("<ENChat::Fecha> " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return mensajes;
        }

        public ENChatMensaje Obtener(int id)
        {
            ENChatMensaje mensaje = null;
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

                string cadenaComando = "SELECT * FROM chat WHERE id = @id";
                comando.CommandText = cadenaComando;
                comando.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = comando.ExecuteReader();
                // Recorremos el reader y vamos insertando en el array list
                if (reader.Read())
                {
                    mensaje = ObtenerDatos(reader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("<ENChat::Obtener> " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return mensaje;
        }

        private ENChatMensaje ObtenerDatos(SqlDataReader reader)
        {
            ENChatMensaje chat = new ENChatMensaje();
            try
            {
                chat.Id = int.Parse(reader["id"].ToString());
                chat.Usuario = ENUsuario.Obtener(int.Parse(reader["usuario"].ToString()));
                chat.Mensaje = reader["mensaje"].ToString();
                chat.Fecha = (DateTime)reader["fecha"];
            }
            catch (Exception e)
            {
                Console.WriteLine("<ENChat::ObtenerDatos> " + e.Message);
                chat = null;
            }
            return chat;
        }

        public ENChatMensaje Ultimo()
        {
            ENChatMensaje chat = new ENChatMensaje();
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
                comando.CommandText = "SELECT * FROM chat where id in (select max(id) from chat)";

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                    chat = ObtenerDatos(reader);
            }
            catch (Exception ex)
            {
                Console.WriteLine("<ChatCAD::Ultimo> " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return chat;
        }

        public int NumMensajes()
        {
            int numMensajes = 0;
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
                comando.CommandText = "SELECT COUNT(*) as numMensajes FROM chat";

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                    numMensajes = int.Parse(reader["numMensajes"].ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("<ChatCAD::NumMensajes> " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return numMensajes;
        }
    }
}
