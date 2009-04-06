using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

namespace Libreria
{
    sealed class PeticionCAD
    {

        private static readonly PeticionCAD instancia = new PeticionCAD();
        static string cadenaConexion;

        public static PeticionCAD Instancia
        {
            get { return instancia; }
        }


        private PeticionCAD()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["cacatua"].ConnectionString;
        }

        public static ArrayList GetSinContestar()
        {
            ArrayList peticiones = new ArrayList();
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "SELECT * FROM peticiones where respuesta is NULL";
                
                SqlDataReader reader = comando.ExecuteReader();
                // Recorremos el reader y vamos insertando en el array list
                while (reader.Read())
                {
                    peticiones.Add(obtenerDatos(reader));
                }
            }
            return peticiones;
        }

        private static ENPeticion obtenerDatos(SqlDataReader reader)
        {
            ENPeticion peticion = new ENPeticion();
            peticion.Id = int.Parse(reader["id"].ToString());
            peticion.Asunto = reader["asunto"].ToString();
            peticion.Texto = reader["texto"].ToString();
            peticion.Usuario = int.Parse(reader["usuario"].ToString());
            peticion.Respuesta = reader["respuesta"].ToString();
            
            return peticion;
        }

        public static ArrayList GetContestadas()
        {
            ArrayList peticiones = new ArrayList();
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "SELECT * FROM peticiones where respuesta is not NULL";

                SqlDataReader reader = comando.ExecuteReader();
                // Recorremos el reader y vamos insertando en el array list
                while (reader.Read())
                {
                    peticiones.Add(obtenerDatos(reader));
                }
            }
            return peticiones;
        }

        public static ENPeticion GetPeticion(int id)
        {
            ENPeticion peticion = new ENPeticion();
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "SELECT * FROM peticiones where id=" + id;
                //comando.Parameters.AddWithValue("@idpet", id);

                SqlDataReader reader = comando.ExecuteReader();
                
                while (reader.Read())
                {
                    peticion=obtenerDatos(reader);
                }
            }
            return peticion;
        }

        public static bool ActualizarPeticion(ENPeticion peticion)
        {
            int resultado = 0;
            bool actualizada = false;
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                // Abrimos la conexión
                conexion.Open();
                // Creamos el comando
                SqlCommand comando = new SqlCommand();
                // Le asignamos la conexión al comando
                comando.Connection = conexion;
                comando.CommandText = "UPDATE peticiones " +
                    "SET respuesta = @respuesta " +
                    "WHERE id = @id";
                comando.Parameters.AddWithValue("@respuesta", peticion.Respuesta);
                comando.Parameters.AddWithValue("@id", peticion.Id);
                resultado = comando.ExecuteNonQuery();
                if (resultado == 1)
                    actualizada = true;
            }
            return actualizada;
        }

        public static void BorrarPeticion(int id)
        {
            ENPeticion peticion = new ENPeticion();
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "DELETE FROM peticiones where id=" + id;
               
                SqlDataReader reader = comando.ExecuteReader();
            }
        }
    }
}
