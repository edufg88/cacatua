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
    // Componente de Acceso a Datos para relacionarse con la BD 'mensaje'
    sealed class MensajeCAD
    {
        private static readonly MensajeCAD instancia = new MensajeCAD();
        private String cadenaConexion;

        // Devuelve la instancia única de la clase
        public static MensajeCAD Instancia
        {
            get { return(instancia); }
        }

        // El constructor privado crea la cadena de conexión
        private MensajeCAD()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["cacatua"].ConnectionString;
        }

        // Extrae los datos de un objeto DataReader y los almacena en un 
        // ENMensaje que devuelve
        public ENMensaje ObtenerDatos(SqlDataReader dr)
        {
            ENMensaje mensaje = new ENMensaje();

            mensaje.Id = int.Parse(dr["id"].ToString());

            UsuarioCAD usuarioCAD = new UsuarioCAD();
            mensaje.Emisor = usuarioCAD.ObtenerUsuario(int.Parse(dr["emisor"].ToString()));
            mensaje.Receptor = usuarioCAD.ObtenerUsuario(int.Parse(dr["receptor"].ToString()));
            mensaje.Texto = dr["texto"].ToString();
            mensaje.Fecha = DateTime.Parse(dr["fecha"].ToString());
            mensaje.Leido = int.Parse(dr["leido"].ToString()); ;

            return (mensaje);
        }

        // Devuelve una determinada mensaje a partir de un id
        public ENMensaje ObtenerMensaje(int id)
        {
            ENMensaje mensaje = null;

            try
            {
                SqlConnection conexion = new SqlConnection(cadenaConexion);
                conexion.Open(); // Abrimos la conexión
                SqlCommand comando = new SqlCommand(); // Creamos un SqlCommand
                comando.Connection = conexion; // Asignamos la cadena de conexión
                comando.CommandText = "SELECT * FROM mensajes where id = @id"; // Asignamos la sentencia SQL
                comando.Parameters.AddWithValue("@id", id);

                // Creamo un objeto DataReader
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    // Extraemos la información del DataReader y la almacenamos
                    // en un objeto ENMensaje
                    mensaje = ObtenerDatos(dr);
                }

                conexion.Close();
            }
            catch (SqlException)
            {
                // throw new CADException (“Error en la consulta de clientes por ciudad: " + clienteID, sqlex );
                Console.Write("Excepcion obtener mensaje");
            }

            return mensaje;
        }

        public ArrayList ObtenerMensajes(string nombre, bool emisor)
        {
            ENMensaje mensaje = null;

            // Obtenemos el usuario por nombre para obtener su id
            ENUsuario usuario = ENUsuario.Obtener(nombre);
            ArrayList mensajes = new ArrayList();
            try
            {
                SqlConnection conexion = new SqlConnection(cadenaConexion);
                conexion.Open(); // Abrimos la conexión
                SqlCommand comando = new SqlCommand(); // Creamos un SqlCommand
                comando.Connection = conexion; // Asignamos la cadena de conexión

                // Asignamos la sentencia SQL
                if (emisor)
                {
                    comando.CommandText = "SELECT * FROM mensajes where emisor = @usuario";
                }
                else 
                {
                    comando.CommandText = "SELECT * FROM mensajes where receptor = @usuario";
                }
                comando.Parameters.AddWithValue("@usuario", usuario.Id);

                // Creamo un objeto DataReader
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    // Extraemos la información del DataReader y la almacenamos
                    // en un objeto ENMensaje
                    mensaje = ObtenerDatos(dr);
                    mensajes.Add(mensaje);
                }

                conexion.Close();
            }
            catch (SqlException)
            {
                Console.Write("Excepcion obtener mensaje por nombre de usuario");
            }

            return mensajes;
        }

        public ArrayList Cantidad(string nombre)
        {
            ArrayList mensajes = new ArrayList();

            // Obtenemos el usuario por nombre para obtener su id
            ENUsuario usuario = ENUsuario.Obtener(nombre);

            try
            {
                SqlConnection conexion = new SqlConnection(cadenaConexion);
                conexion.Open(); // Abrimos la conexión
                SqlCommand comando = new SqlCommand(); // Creamos un SqlCommand
                comando.Connection = conexion; // Asignamos la cadena de conexión
                comando.CommandText = "SELECT * FROM mensajes where receptor = @usuario";
                comando.Parameters.AddWithValue("@usuario", usuario.Id);

                // Creamo un objeto DataReader
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    // Extraemos la información del DataReader y la almacenamos
                    // en un objeto ENMensaje
                    ENMensaje mensaje = null;
                    mensaje = ObtenerDatos(dr);
                    mensajes.Add(mensaje);
                }

                conexion.Close();
            }
            catch (SqlException)
            {
                Console.Write("Excepcion obtener mensaje por nombre de usuario");
            }

            return mensajes;
        }

        public ArrayList ObtenerMensajes(string nombre, bool orden, string ordenar, int pagina, int cantidad)
        {
            bool existe = false;
            ArrayList mensajes = new ArrayList();
            // Obtenemos el usuario por nombre para obtener su id
            ENUsuario usuario = ENUsuario.Obtener(nombre);

            int filaInicio = (pagina - 1) * cantidad + 1;
            int filaFinal = filaInicio - 1 + cantidad;
            try
            {
                SqlConnection conexion = new SqlConnection(cadenaConexion);
                conexion.Open(); // Abrimos la conexión
                SqlCommand comando = new SqlCommand(); // Creamos un SqlCommand
                comando.Connection = conexion; // Asignamos la cadena de conexión
                comando.CommandText = "SELECT * FROM (SELECT id,emisor,texto,fecha,receptor, ROW_NUMBER() OVER (ORDER BY " + ordenar;
                if (orden == true)
                    comando.CommandText += " ASC";
                else
                    comando.CommandText += " DESC";
                comando.CommandText += ") as row FROM mensajes where receptor = @usuario) as alias WHERE row >= @filaInicio and row <= @filaFinal";
                comando.Parameters.AddWithValue("@usuario", usuario.Id);
                comando.Parameters.AddWithValue("@filaInicio", filaInicio);
                comando.Parameters.AddWithValue("@filaFinal", filaFinal);
                // Creamo un objeto DataReader
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    // Extraemos la información del DataReader y la almacenamos
                    // en un objeto ENMensaje
                    ENMensaje mensaje = null;
                    mensaje = ObtenerDatos(dr);
                    mensajes.Add(mensaje);
                    existe = true;
                }

                conexion.Close();
            }
            catch (SqlException)
            {
                Console.Write("Excepcion obtener mensaje por nombre de usuario");
            }
            if (existe)
                return mensajes;
            else
                return null;
        }

        // Devuelve la lista de mensajes
        public ArrayList ObtenerMensajes()
        {
            ArrayList mensajes = new ArrayList();
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "SELECT * FROM mensajes";
                SqlDataReader dr = comando.ExecuteReader();
                // Generamos el ArrayList a partir del DataReader
                while (dr.Read())
                {
                    ENMensaje mensaje = ObtenerDatos(dr);
                    mensajes.Add(mensaje);
                }

                conexion.Close();
            }
            catch (SqlException)
            {
                Console.Write("Excepción obtener mensajes");
            }
        
            return mensajes;
        }

        // Borra todas las mensajes
        public void BorrarMensajes()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "DELETE FROM mensajes";
                comando.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                Console.Write("Excepción borrando todas las mensajes");
            }
        }

        // Borra una mensaje dado un determinado id
        public bool BorrarMensaje(int id)
        {
            bool borrado = false;
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "DELETE FROM mensajes where id = @id";
                comando.Parameters.AddWithValue("@id", id);

                if ((comando.ExecuteNonQuery()) == 1) // Comprobamos cuantas filas se borran
                {
                    borrado = true;
                }

                conexion.Close();
            }
            catch (SqlException)
            {
                Console.Write("Excepcion borrar mensajes");
            }

            return (borrado);
        }

        public bool GuardarMensaje(string emisor, string texto, string receptor)
        {
            bool guardado = false;
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            
            // Obtenemos los usuarios por nombre para obtener su id
            ENUsuario em = ENUsuario.Obtener(emisor);
            ENUsuario rec = ENUsuario.Obtener(receptor);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();

                comando.Connection = conexion;
                comando.CommandText = "INSERT INTO " +
                    "mensajes (emisor, texto, receptor) " +
                    "VALUES (@emisor, @texto, @receptor)";
                comando.Parameters.AddWithValue("@emisor", em.Id);
                comando.Parameters.AddWithValue("@texto", texto);
                comando.Parameters.AddWithValue("@receptor", rec.Id);
                
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

        public ArrayList BuscarMensaje(string emisor, string receptor, DateTime fecha)
        {
            bool usarEmisor = false;
            bool usarReceptor = false;
            bool usarFecha = false;
            string cadenaFecha = "";
           
            // Obtenemos los usuarios por nombre para obtener su id
            ENUsuario em = ENUsuario.Obtener(emisor);
            ENUsuario rec = ENUsuario.Obtener(receptor);

            if (emisor != "")
            {
                usarEmisor = true;
            }
            if (receptor != "")
            {
                usarReceptor = true;
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
            ArrayList mensajes = new ArrayList();

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();

                comando.Connection = conexion;

                comando.CommandText = "SELECT * FROM mensajes WHERE ";
                
                if (usarEmisor)
                {
                    comando.CommandText += "(emisor = @emisor) ";
                    comando.Parameters.AddWithValue("@emisor", em.Id);
                }
                if (usarReceptor)
                { 
                    if (usarEmisor)
                    {
                        comando.CommandText += "AND ";
                    }
                    comando.CommandText += "(receptor = @receptor) ";
                    comando.Parameters.AddWithValue("@receptor", rec.Id);
                }

                if (usarFecha)
                {
                    if (usarEmisor || usarReceptor)
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
                    ENMensaje mensaje = ObtenerDatos(dr);
                    mensajes.Add(mensaje);
                }

                conexion.Close();
            }
            catch (SqlException sqlex)
            {
                Console.Write("Excepcion buscar mensaje" + sqlex.Message);
            }

            return mensajes;
        }

        public bool Actualizar(ENMensaje mensaje)
        {
            bool actualizado = false;

            SqlConnection conexion = null;
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();

                string sentencia = "update mensajes set emisor = @emisor, receptor = @receptor, texto = @texto, fecha = @fecha, leido = @leido where id = @id";

                SqlCommand comando = new SqlCommand(sentencia, conexion);
                comando.Parameters.AddWithValue("@emisor", mensaje.Emisor.Id);
                comando.Parameters.AddWithValue("@receptor", mensaje.Receptor.Id);
                comando.Parameters.AddWithValue("@texto", mensaje.Texto);
                comando.Parameters.AddWithValue("@fecha", mensaje.Fecha);
                comando.Parameters.AddWithValue("@id", mensaje.Id);
                comando.Parameters.AddWithValue("@leido", mensaje.Leido);

                if (comando.ExecuteNonQuery() == 1)
                {
                    actualizado = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar un mensaje" + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return actualizado;
        }

        public int CantidadMensajes(int receptor)
        {
            SqlConnection conexion = null;
            int cantidad = 0;

            try
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                string sentencia = "SELECT COUNT(*) FROM mensajes WHERE receptor = @receptor";           

                SqlCommand comando = new SqlCommand(sentencia, conexion);
                comando.Parameters.AddWithValue("@receptor", receptor);

                cantidad = int.Parse(comando.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al contar mensajes " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return cantidad;
        }

        public int CantidadMensajesEnviados(int emisor)
        {
            SqlConnection conexion = null;
            int cantidad = 0;

            try
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                string sentencia = "SELECT COUNT(*) FROM mensajes WHERE emisor = @emisor";

                SqlCommand comando = new SqlCommand(sentencia, conexion);
                comando.Parameters.AddWithValue("@emisor", emisor);

                cantidad = int.Parse(comando.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al contar mensajes " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return cantidad;
        }
    }
}
