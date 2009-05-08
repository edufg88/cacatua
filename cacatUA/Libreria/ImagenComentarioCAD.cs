using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;

namespace Libreria
{
    sealed class ImagenComentarioCAD
    {
        private static readonly ImagenComentarioCAD instancia = new ImagenComentarioCAD();
        private String cadenaConexion;

        // Devuelve la instancia única de la clase
        public static ImagenComentarioCAD Instancia
        {
            get { return(instancia); }
        }

        // El constructor privado crea la cadena de conexión
        private ImagenComentarioCAD()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["cacatua"].ConnectionString;
        }

        public ENImagenComentario ObtenerDatos(SqlDataReader dr)
        {
            ENImagenComentario comentario = new ENImagenComentario();

            comentario.Id = int.Parse(dr["id"].ToString());
            comentario.Texto = dr["texto"].ToString();
            comentario.Imagen = ENImagen.Obtener(int.Parse(dr["imagen"].ToString()));
            comentario.Usuario = ENUsuario.Obtener(int.Parse(dr["usuario"].ToString()));
            comentario.Fecha = DateTime.Parse(dr["fecha"].ToString());

            return (comentario);
        }

        public ArrayList Obtener(int imagen)
        {
            ArrayList comentarios = new ArrayList();
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "SELECT * FROM imagenescomentarios where imagen=" + imagen;
                SqlDataReader dr = comando.ExecuteReader();
                // Generamos el ArrayList a partir del DataReader
                while (dr.Read())
                {
                    ENImagenComentario comentario = ObtenerDatos(dr);
                    comentarios.Add(comentario);
                }

                conexion.Close();
            }
            catch (SqlException)
            {
                Console.Write("Excepción obtener comentarios imagenes");
            }

            return comentarios;
        }

        public bool Guardar(ENImagenComentario comentario)
        {
            bool insertado = false;
            int id = 0;

            if (comentario.Imagen != null && comentario.Usuario != null)
            {
                SqlConnection conexion = null;
                try
                {
                    conexion = new SqlConnection(cadenaConexion);
                    conexion.Open();

                    string cadena0 = "BEGIN TRAN";
                    string cadena1 = "insert into imagenescomentarios (texto, fecha, usuario, imagen) values (@texto, @fecha, @usuario, @imagen);";
                    string cadena2 = "select max(id) as id from imagenescomentarios;";
                    string cadena3 = "COMMIT TRAN";

                    string sentencia = cadena0 + " " + cadena1 + " " + cadena2 + " " + cadena3;

                    SqlCommand comando = new SqlCommand(sentencia, conexion);
                    comando.Parameters.AddWithValue("@texto", comentario.Texto);
                    comando.Parameters.AddWithValue("@fecha", comentario.Fecha);
                    comando.Parameters.AddWithValue("@usuario", comentario.Usuario.Id);
                    comando.Parameters.AddWithValue("@imagen", comentario.Imagen.Id);

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
                    Console.WriteLine("ERROR: void ImagenComentarioCAD.Guardar(ENImagenComentario) " + ex.Message);
                }
                finally
                {
                    if (conexion != null)
                        conexion.Close();
                }
            }

            return insertado;
        
        }

        public ArrayList Obtener(int imagen, int pagina, int cantidadPorPagina)
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

                // Formamos dos comandos, uno para obtener el número de resultados total sin paginación y
                // otro para obtener los materiales paginados con toda la información

                string comandoConPaginacion = "";
                string cadenaComun = "";

                comandoConPaginacion += "SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY " + "fecha DESC";

                comandoConPaginacion += ") as row FROM imagenescomentarios";

                if (imagen != 0)
                {
                    if (cadenaComun == "")
                    {
                        cadenaComun += " where imagen=" + @imagen;
                    }
                    else
                    {
                        cadenaComun += " and imagen=" + @imagen;
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
                    ENImagenComentario comentario = ObtenerDatos(reader);
                    comentarios.Add(comentario);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("<ENImagenComentario::Obtener> " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return comentarios;
        }

        public int ObtenerNumeroComentarios(int imagen)
        {
            int num = 0;
            try
            {
                SqlConnection conexion = new SqlConnection(cadenaConexion);
                conexion.Open(); // Abrimos la conexión
                SqlCommand comando = new SqlCommand(); // Creamos un SqlCommand
                comando.Connection = conexion; // Asignamos la cadena de conexión
                comando.CommandText = "SELECT count(*) numero FROM imagenescomentarios where imagen=" + imagen; // Asignamos la sentencia SQL


                // Creamo un objeto DataReader
                SqlDataReader dr = comando.ExecuteReader();

                if (dr.Read())
                {
                    num = int.Parse(dr["numero"].ToString());
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
