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
            comentario.Imagen = ENImagen.Obtener(dr["imagen"].ToString());
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
    }
}
