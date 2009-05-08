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
    // Componente de Acceso a Datos para relacionarse con la BD 'imagenes'
    sealed class ImagenCAD
    {
        private static readonly ImagenCAD instancia = new ImagenCAD();
        private String cadenaConexion;

        // Devuelve la instancia única de la clase
        public static ImagenCAD Instancia
        {
            get { return(instancia); }
        }

        // El constructor privado crea la cadena de conexión
        private ImagenCAD()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["cacatua"].ConnectionString;
        }

        // Extrae los datos de un objeto DataReader y los almacena en un 
        // ENImagen que devuelve
        public ENImagen ObtenerDatos(SqlDataReader dr)
        {
            ENImagen imagen = new ENImagen();
          
            imagen.Id = int.Parse(dr["id"].ToString());
            imagen.Titulo = dr["titulo"].ToString();
            imagen.Descripcion = dr["descripcion"].ToString();
            imagen.Usuario = ENUsuario.Obtener(int.Parse(dr["usuario"].ToString()));
            imagen.Archivo = dr["archivo"].ToString();
            imagen.Fecha = DateTime.Parse(dr["fecha"].ToString());

            return (imagen);
        }

        // Devuelve una determinada firma a partir de un id
        public ENImagen ObtenerImagen(int id)
        {
            ENImagen imagen = null;

            try
            {
                SqlConnection conexion = new SqlConnection(cadenaConexion);
                conexion.Open(); // Abrimos la conexión
                SqlCommand comando = new SqlCommand(); // Creamos un SqlCommand
                comando.Connection = conexion; // Asignamos la cadena de conexión
                comando.CommandText = "SELECT * FROM imagenes where id = @id"; // Asignamos la sentencia SQL
                comando.Parameters.AddWithValue("@id", id);

                // Creamo un objeto DataReader
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    // Extraemos la información del DataReader y la almacenamos
                    // en un objeto ENImagen
                    imagen = ObtenerDatos(dr);
                }

                conexion.Close();
            }
            catch (SqlException)
            {
                Console.Write("Excepcion obtener imagen");
            }

            return imagen;
        }

        public ENImagen ObtenerImagen(string titulo)
        {
            ENImagen imagen = null;

            try
            {
                SqlConnection conexion = new SqlConnection(cadenaConexion);
                conexion.Open(); // Abrimos la conexión
                SqlCommand comando = new SqlCommand(); // Creamos un SqlCommand
                comando.Connection = conexion; // Asignamos la cadena de conexión
                comando.CommandText = "SELECT * FROM imagenes where titulo = @titulo"; // Asignamos la sentencia SQL
                comando.Parameters.AddWithValue("@titulo", titulo);

                // Creamo un objeto DataReader
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    // Extraemos la información del DataReader y la almacenamos
                    // en un objeto ENImagen
                    imagen = ObtenerDatos(dr);
                }

                conexion.Close();
            }
            catch (SqlException)
            {
                Console.Write("Excepcion obtener imagen por titulo");
            }

            return imagen;
        }

        // Devuelve la lista de imagenes
        public ArrayList ObtenerImagenes()
        {
            ArrayList imagenes = new ArrayList();
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "SELECT * FROM imagenes";
                SqlDataReader dr = comando.ExecuteReader();
                // Generamos el ArrayList a partir del DataReader
                while (dr.Read())
                {
                    ENImagen imagen = ObtenerDatos(dr);
                    imagenes.Add(imagen);
                }

                conexion.Close();
            }
            catch (SqlException)
            {
                Console.Write("Excepción obtener imagenes");
            }

            return imagenes;
        }

        public ArrayList ObtenerPorUsuario(int id)
        {
            ArrayList imagenes = new ArrayList();
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "SELECT * FROM imagenes WHERE usuario=" + id;
                SqlDataReader dr = comando.ExecuteReader();
                // Generamos el ArrayList a partir del DataReader
                while (dr.Read())
                {
                    ENImagen imagen = ObtenerDatos(dr);
                    imagenes.Add(imagen);
                }

                conexion.Close();
            }
            catch (SqlException)
            {
                Console.Write("Excepción obtener imagenes");
            }

            return imagenes;
        }

        // Borra todas las imagenes
        public void BorrarImagenes()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "DELETE FROM imagenes";
                comando.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                Console.Write("Excepción borrando todas las imagenes");
            }
        }




        // Borra una imagen dado un determinado id
        public bool BorrarImagen(int id)
        {
            bool borrado = false;
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "DELETE FROM imagenes where id = @id";
                comando.Parameters.AddWithValue("@id", id);

                if ((comando.ExecuteNonQuery()) == 1) // Comprobamos cuantas filas se borran
                {
                    borrado = true;
                }

                conexion.Close();
            }
            catch (SqlException)
            {
                Console.Write("Excepcion borrar una imagen por id");
            }

            return (borrado);
        }

        public bool GuardarImagen(string titulo, string descripcion, string usuario, string archivo)
        {
            bool guardado = false;
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            // Obtenemos los usuarios por nombre para obtener su id
            ENUsuario autor = ENUsuario.Obtener(usuario);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();

                comando.Connection = conexion;
                comando.CommandText = "INSERT INTO " +
                    "imagenes (titulo, descripcion, usuario, archivo) " +
                    "VALUES (@titulo, @descripcion, @usuario, @archivo)";
                comando.Parameters.AddWithValue("@titulo", titulo);
                comando.Parameters.AddWithValue("@descripcion", descripcion);
                comando.Parameters.AddWithValue("@usuario", autor.Id);
                comando.Parameters.AddWithValue("@archivo", archivo);

                if (comando.ExecuteNonQuery() == 1)
                {
                    guardado = true;
                }

                conexion.Close();
            }
            catch (SqlException)
            {
                Console.Write("Excepcion guardar imagen");
            }

            return (guardado);
        }

        public ArrayList BuscarImagen(string titulo, string usuario)
        {
            bool usarTitulo = false;
            bool usarUsuario = false;

            // Obtenemos los usuarios por nombre para obtener su id
            ENUsuario autor = ENUsuario.Obtener(usuario);
            
            if (titulo != "")
            {
                usarTitulo = true;
            }
            if (usuario != "")
            {
                usarUsuario = true;
            }

            SqlConnection conexion = new SqlConnection(cadenaConexion);
            ArrayList imagenes = new ArrayList();

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();

                comando.Connection = conexion;

                comando.CommandText = "SELECT * FROM imagenes WHERE ";

                if (usarTitulo)
                {
                    comando.CommandText += "(titulo = @titulo) ";
                    comando.Parameters.AddWithValue("@titulo", titulo);
                }
                if (usarUsuario)
                {
                    if (usarTitulo)
                    {
                        comando.CommandText += "AND ";
                    }
                    comando.CommandText += "(usuario = @usuario) ";
                    comando.Parameters.AddWithValue("@usuario", autor.Id);
                }                

                SqlDataReader dr = comando.ExecuteReader();
                // Generamos el ArrayList a partir del DataReader
                while (dr.Read())
                {
                    ENImagen imagen = ObtenerDatos(dr);
                    imagenes.Add(imagen);
                }

                conexion.Close();
            }
            catch (SqlException sqlex)
            {
                Console.Write("Excepcion buscar imagen" + sqlex.Message);
            }

            return imagenes;
        }

        public ArrayList BuscarImagen(int usuario)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            ArrayList imagenes = new ArrayList();

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "SELECT * FROM imagenes WHERE usuario = @usuario";
                comando.Parameters.AddWithValue("@usuario", usuario);
                SqlDataReader dr = comando.ExecuteReader();
                // Generamos el ArrayList a partir del DataReader
                while (dr.Read())
                {
                    ENImagen imagen = ObtenerDatos(dr);
                    imagenes.Add(imagen);
                }
            }
            catch (SqlException ex)
            {
                Console.Write("Error al buscar imagen por usuario " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }

            return (imagenes);
        }

        public bool Actualizar(ENImagen imagen)
        {
            bool actualizado = false;

            SqlConnection conexion = null;
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();

                string sentencia = "update imagenes set titulo = @titulo, descripcion = @descripcion, fecha = @fecha, usuario = @usuario, archivo = @archivo where id = @id";

                SqlCommand comando = new SqlCommand(sentencia, conexion);
                comando.Parameters.AddWithValue("@titulo", imagen.Titulo);
                comando.Parameters.AddWithValue("@descripcion", imagen.Descripcion);
                comando.Parameters.AddWithValue("@fecha", imagen.Fecha);
                comando.Parameters.AddWithValue("@usuario", imagen.Usuario.Id);
                comando.Parameters.AddWithValue("@archivo", imagen.Archivo);
                comando.Parameters.AddWithValue("@id", imagen.Id);

                if (comando.ExecuteNonQuery() == 1)
                {
                    actualizado = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar una imagen" + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return actualizado;
        }

        public int CantidadImagenes(int usuario)
        {
            SqlConnection conexion = null;
            int cantidad = 0;

            try
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                string sentencia = "SELECT COUNT(*) FROM imagenes WHERE usuario = @usuario";

                SqlCommand comando = new SqlCommand(sentencia, conexion);
                comando.Parameters.AddWithValue("@usuario", usuario);

                cantidad = int.Parse(comando.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al contar imágenes " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return cantidad;
        }

        public ArrayList Obtener(int usuario,int pagina, int cantidadPorPagina)
        {
            ArrayList imagenes = new ArrayList();
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
                
                string comandoConPaginacion = "";
                string cadenaComun = "";

                comandoConPaginacion += "SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY " + "fecha DESC";
                
                comandoConPaginacion += ") as row FROM imagenes";

                if (usuario != 0)
                {
                    if (cadenaComun == "")
                    {
                        cadenaComun += " where usuario=" + @usuario;
                    }
                    else
                    {
                        cadenaComun += " and usuario=" + @usuario;
                    }
                }

               
                comandoConPaginacion += cadenaComun;
                comandoConPaginacion += " ) as alias WHERE row >= @filaInicio and row <= @filaFinal";

                // Obtenemos los resultados con paginación
                comando.CommandText = comandoConPaginacion;
                
                
                comando.Parameters.AddWithValue("@filaInicio", filaInicio);
                comando.Parameters.AddWithValue("@filaFinal", filaFinal);

                SqlDataReader reader = comando.ExecuteReader();
                // Recorremos el reader y vamos insertando en el array list
                while (reader.Read())
                {
                    ENImagen imagen = ObtenerDatos(reader);
                    imagenes.Add(imagen);
                }

                
            }
            catch (Exception ex)
            {
                Console.WriteLine("<ENImagen::Obtener> " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return imagenes;
        }

        public int ObtenerNumeroImagenes(int usuario)
        {
            int num = 0;
            try
            {
                SqlConnection conexion = new SqlConnection(cadenaConexion);
                conexion.Open(); // Abrimos la conexión
                SqlCommand comando = new SqlCommand(); // Creamos un SqlCommand
                comando.Connection = conexion; // Asignamos la cadena de conexión
                comando.CommandText = "SELECT count(*) numero FROM imagenes where usuario=" + usuario; // Asignamos la sentencia SQL
                

                // Creamo un objeto DataReader
                SqlDataReader dr = comando.ExecuteReader();
                
                if (dr.Read())
                {
                    num= int.Parse(dr["numero"].ToString());
                }

                conexion.Close();
            }
            catch (SqlException)
            {
                Console.Write("Excepcion obtener imagen por titulo");
            }

            return num;
        }
    }
}
