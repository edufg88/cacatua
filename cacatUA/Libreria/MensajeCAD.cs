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
            mensaje.Emisor = UsuarioCAD.Instancia.ObtenerUsuario(int.Parse(dr["emisor"].ToString()));
            mensaje.Receptor = UsuarioCAD.Instancia.ObtenerUsuario(int.Parse(dr["receptor"].ToString()));
            mensaje.Texto = dr["texto"].ToString();
            mensaje.Fecha = DateTime.Parse(dr["fecha"].ToString());

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

        public ENMensaje ObtenerMensaje(string nombre, bool emisor)
        {
            ENMensaje mensaje = null;

            // Obtenemos el usuario por nombre para obtener su id
            ENUsuario usuario = new ENUsuario(nombre);

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
                Console.Write("Excepcion obtener mensaje por nombre de usuario");
            }

            return mensaje;
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

        public bool GuardarMensaje(string emisor, string texto, DateTime fecha, string receptor)
        {
            bool guardado = false;
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            
            // Obtenemos los usuarios por nombre para obtener su id
            ENUsuario em = new ENUsuario(emisor);
            ENUsuario rec = new ENUsuario(receptor);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();

                comando.Connection = conexion;
                comando.CommandText = "INSERT INTO " +
                    "mensajes (emisor, texto, fecha, receptor) " +
                    "VALUES (@emisor, @texto, @fecha, @receptor)";
                comando.Parameters.AddWithValue("@emisor", em.Id);
                comando.Parameters.AddWithValue("@texto", texto);
                comando.Parameters.AddWithValue("@fecha", fecha);
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
            ENUsuario em = new ENUsuario(emisor);
            ENUsuario rec = new ENUsuario(receptor);

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
                }
                if (usarReceptor)
                { 
                    if (usarEmisor)
                    {
                        comando.CommandText += "AND ";
                    }
                    comando.CommandText += "(receptor = @receptor) ";
                }
                
                if (usarFecha)
                {
                    if (usarEmisor || usarReceptor)
                    {
                        comando.CommandText += "AND ";
                    }
                    comando.CommandText += "(fecha = @fecha) ";
                }

                comando.Parameters.AddWithValue("@emisor", em.Id);
                comando.Parameters.AddWithValue("@receptor", rec.Id);
                comando.Parameters.AddWithValue("@fecha", cadenaFecha);

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
    }
}
