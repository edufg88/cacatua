using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;

namespace Libreria
{
    class ImagenVotoCAD
    {
        private String cadenaConexion;

        // El constructor privado crea la cadena de conexión
        public ImagenVotoCAD()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["cacatua"].ConnectionString;
        }

        public ENImagenVoto ObtenerDatos(SqlDataReader dr)
        {
            ENImagenVoto voto = new ENImagenVoto();

            voto.Imagen = ENImagen.Obtener(int.Parse(dr["imagen"].ToString()));
            voto.Usuario = ENUsuario.Obtener(int.Parse(dr["usuario"].ToString()));
            voto.Valoracion = int.Parse(dr["puntuacion"].ToString());

            return (voto);
        }

        public int ObtenerValoracion(int imagen)
        {
            int total = -1;
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "SELECT avg(puntuacion) as total FROM imagenesvotos where imagen=" + imagen + " group by imagen";
                SqlDataReader dr = comando.ExecuteReader();
                
                while (dr.Read())
                {
                    total = int.Parse(dr["total"].ToString());
                }

                conexion.Close();
            }
            catch (SqlException)
            {
                Console.Write("Excepción obtener votos imagenes");
            }

            return total;
        }
    }
}
