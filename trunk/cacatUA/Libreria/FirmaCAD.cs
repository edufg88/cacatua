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
    // Componente de Acceso a Datos para relacionarse con la BD 'firmas'
    sealed class FirmaCAD
    {
        private static readonly FirmaCAD instancia = new FirmaCAD();
        private String cadenaConexion;

        // Devuelve la instancia única de la clase
        public static FirmaCAD Instancia
        {
            get { return(instancia); }
        }

        // El constructor privado crea la cadena de conexión
        private FirmaCAD()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["cacatua"].ConnectionString;
        }

        // Extrae los datos de un objeto DataReader y los almacena en un 
        // ENFirma que devuelve
        public ENFirma ObtenerDatos(SqlDataReader dr)
        {
            ENFirma firma = new ENFirma();

            firma.Id = int.Parse(dr["id"].ToString());
            firma.Emisor = UsuarioCAD.Instancia.ObtenerUsuario(int.Parse(dr["emisor"].ToString()));
            firma.Receptor = UsuarioCAD.Instancia.ObtenerUsuario(int.Parse(dr["receptor"].ToString()));
            firma.Texto = dr["texto"].ToString();
            firma.Fecha = DateTime.Parse(dr["fecha"].ToString());

            return (firma);
        }

        // Devuelve una determinada firma a partir de un id
        public ENFirma ObtenerFirma(int id)
        {
            ENFirma firma = null;

            try
            {
                SqlConnection conexion = new SqlConnection(cadenaConexion);
                conexion.Open(); // Abrimos la conexión
                SqlCommand comando = new SqlCommand(); // Creamos un SqlCommand
                comando.Connection = conexion; // Asignamos la cadena de conexión
                comando.CommandText = "SELECT * FROM firmas where id = @id"; // Asignamos la sentencia SQL
                comando.Parameters.AddWithValue("@id", id);

                // Creamo un objeto DataReader
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    // Extraemos la información del DataReader y la almacenamos
                    // en un objeto ENFirma
                    firma = ObtenerDatos(dr);
                }

                conexion.Close();
            }
            catch (SqlException)
            {
                Console.Write("Excepcion obtener firma");
            }

            return firma;
        }

        public ENFirma ObtenerFirma(string nombre, bool emisor)
        {
            ENFirma firma = null;

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
                    comando.CommandText = "SELECT * FROM firmas where emisor = @usuario";
                }
                else 
                {
                    comando.CommandText = "SELECT * FROM firmas where receptor = @usuario";
                }
                comando.Parameters.AddWithValue("@usuario", usuario.Id);

                // Creamo un objeto DataReader
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    // Extraemos la información del DataReader y la almacenamos
                    // en un objeto ENFirma
                    firma = ObtenerDatos(dr);
                }

                conexion.Close();
            }
            catch (SqlException)
            {
                Console.Write("Excepcion obtener firma por nombre de usuario");
            }

            return firma;
        }

        // Devuelve la lista de firmas
        public ArrayList ObtenerFirmas()
        {
            ArrayList firmas = new ArrayList();
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "SELECT * FROM firmas";
                SqlDataReader dr = comando.ExecuteReader();
                // Generamos el ArrayList a partir del DataReader
                while (dr.Read())
                {
                    ENFirma firma = ObtenerDatos(dr);
                    firmas.Add(firma);
                }

                conexion.Close();
            }
            catch (SqlException)
            {
                Console.Write("Excepción obtener firmas");
            }
        
            return firmas;
        }

        // Borra todas las firmas
        public void BorrarFirmas()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "DELETE FROM firmas";
                comando.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                Console.Write("Excepción borrando todas las firmas");
            }
        }

        // Borra una firma dado un determinado id
        public bool BorrarFirma(int id)
        {
            bool borrado = false;
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "DELETE FROM firmas where id = @id";
                comando.Parameters.AddWithValue("@id", id);

                if ((comando.ExecuteNonQuery()) == 1) // Comprobamos cuantas filas se borran
                {
                    borrado = true;
                }

                conexion.Close();
            }
            catch (SqlException)
            {
                Console.Write("Excepcion borrar firmas");
            }

            return (borrado);
        }

        public bool GuardarFirma(string emisor, string texto, DateTime fecha, string receptor)
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
                    "firmas (emisor, texto, fecha, receptor) " +
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

        public ArrayList BuscarFirma(string emisor, string receptor, DateTime fecha)
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
            ArrayList firmas = new ArrayList();

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();

                comando.Connection = conexion;

                comando.CommandText = "SELECT * FROM firmas WHERE ";
                
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
                    ENFirma firma = ObtenerDatos(dr);
                    firmas.Add(firma);
                }

                conexion.Close();
            }
            catch (SqlException sqlex)
            {
                Console.Write("Excepcion buscar firma" + sqlex.Message);
            }

            return firmas;
        }

        public bool Actualizar(ENFirma firma)
        {
            bool actualizado = false;

            SqlConnection conexion = null;
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();

                string sentencia = "update firmas set emisor = @emisor, receptor = @receptor, texto = @texto, fecha = @fecha  where id = @id";
                
                SqlCommand comando = new SqlCommand(sentencia, conexion);
                comando.Parameters.AddWithValue("@emisor", firma.Emisor.Id);
                comando.Parameters.AddWithValue("@receptor", firma.Receptor.Id);
                comando.Parameters.AddWithValue("@texto", firma.Texto);
                comando.Parameters.AddWithValue("@fecha", firma.Fecha);
                comando.Parameters.AddWithValue("@id", firma.Id);

                if (comando.ExecuteNonQuery() == 1)
                {
                    actualizado = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar una firma" + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return actualizado;
        }
    }
}
