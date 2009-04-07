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

        public ArrayList GetSinContestar()
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

        private ENPeticion obtenerDatos(SqlDataReader reader)
        {
            ENPeticion peticion = new ENPeticion();
            peticion.Id = int.Parse(reader["id"].ToString());
            peticion.Asunto = reader["asunto"].ToString();
            peticion.Texto = reader["texto"].ToString();
            ENUsuario us = new ENUsuario(int.Parse(reader["usuario"].ToString()));
            peticion.Usuario = us;
            Console.WriteLine(us.Usuario);
            peticion.Respuesta = reader["respuesta"].ToString();
            peticion.Fecha = DateTime.Parse(reader["fecha"].ToString());
            
            return peticion;
        }

        public ArrayList GetContestadas()
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

        public ENPeticion GetPeticion(int id)
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

        public bool ActualizarPeticion(ENPeticion peticion)
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

        public bool BorrarPeticion(int id)
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
            return true;
        }

        public ArrayList Obtener(string asunto,string texto,int usuario)
        {
            ArrayList peticiones = null;

            
            SqlConnection conexion = null;
            try
            {
                // Creamos y abrimos la conexión.
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();

                // Componemos la cadena de la sentencia.
                string sentencia = "select * from peticiones";
                string condiciones = " where respuesta is NULL";

                if (asunto != "")
                {
                    if (condiciones == "")
                    {
                        condiciones += " where asunto like '%" + @asunto + "%'";
                    }
                    else
                    {
                        condiciones += " and asunto like '%" + @asunto + "%'";
                    }
                }
                if (texto != "")
                {
                    if (condiciones == "")
                    {
                        condiciones += " where texto like '%" + @texto + "%'";
                    }
                    else
                    {
                        condiciones += " and texto like '%" + @texto + "%'";
                    }
                }
                if (usuario != 0)
                {
                    if (condiciones == "")
                    {
                        condiciones += " where usuario="+@usuario;
                    }
                    else
                    {
                        condiciones += " and usuario="+@usuario;
                    }
                }

                sentencia = sentencia + condiciones;
                Console.WriteLine(sentencia);
                // Asignamos la cadena de sentencia y establecemos los parámetros.
                SqlCommand comando = new SqlCommand(sentencia, conexion);

                if (asunto != "")
                    comando.Parameters.AddWithValue("@asunto", asunto);

                if (asunto != "")
                    comando.Parameters.AddWithValue("@texto", texto);

                if (asunto != "")
                    comando.Parameters.AddWithValue("@usuario", usuario);

                // Realizamos la consulta.
                SqlDataReader dataReader = comando.ExecuteReader();

                // Insertamos todas las filas extraidas en el vector.
                peticiones = new ArrayList();
                while (dataReader.Read())
                {
                    ENPeticion peticion = obtenerDatos(dataReader);
                    peticiones.Add(peticion);
                }

                // Cerramos la consulta.
                dataReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ArrayList Peticion.Obtener() " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return peticiones;
        }
    }
}
