using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Libreria
{
    public class MaterialCAD
    {
        static string cadenaConexion = "Data Source=PORTATIL\\SQLEXPRESS;Initial Catalog=cacatuaDB;Integrated Security=True;Pooling=False";
        
        public MaterialCAD()
        {

        }

        public static bool existeUsuario(string nombre)
        {
            bool existe = false;
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                // Abrimos la conexión
                conexion.Open();
                // Creamos el comando
                SqlCommand comando = new SqlCommand();
                // Le asignamos la conexión al comando
                comando.Connection = conexion;
                comando.CommandText = "SELECT * FROM usuarios where nombre = @nombre";
                comando.Parameters.AddWithValue("@nombre", nombre);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    existe = true;
                }
            }
            return existe;
        }

        private static ENMaterialCRUD obtenerDatos(SqlDataReader reader)
        {
            ENMaterialCRUD material = new ENMaterialCRUD();
            material.Id = int.Parse(reader["id"].ToString());
            material.Nombre = reader["nombre"].ToString();
            material.Descripcion = reader["descripcion"].ToString();
            //material.Fecha = reader["fecha"].ToString();
            material.Usuario = reader["usuario"].ToString();
            material.Categoria = reader["categoria"].ToString();
            material.Archivo = reader["archivo"].ToString();
            material.Tamaño = int.Parse(reader["tamaño"].ToString());
            material.Descargas = int.Parse(reader["descargas"].ToString());
            material.Idioma = reader["idioma"].ToString();
            material.Valoracion = int.Parse(reader["valoracion"].ToString());
            material.Votos = int.Parse(reader["votos"].ToString());
            material.Referencia = reader["referencia"].ToString();
            return material;
        }

        public static ArrayList obtenerMateriales()
        {
            ArrayList materiales = new ArrayList();
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                string cadenaComando = "SELECT * FROM Materiales";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                // Recorremos el reader y vamos insertando en el array list objetos del tipo ENMaterialCRUD
                while (reader.Read())
                {
                    ENMaterialCRUD material = obtenerDatos(reader);
                    materiales.Add(material);
                }
            }
            return materiales;
        }


        public static ENMaterialCRUD obtenerMaterial(int id)
        {
            ENMaterialCRUD material = null;
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                // Abrimos la conexión
                conexion.Open();
                // Creamos el comando
                SqlCommand comando = new SqlCommand();
                // Le asignamos la conexión al comando
                comando.Connection = conexion;
                comando.CommandText = "SELECT * FROM materiales where id = @id";
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    // Obtenemos la información
                    material = obtenerDatos(reader);
                }
            }
            return material;
        }

        public static bool borrarMaterial(int id)
        {
            int resultado = 0;
            bool borrado = false;
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                // Abrimos la conexión
                conexion.Open();
                // Creamos el comando
                SqlCommand comando = new SqlCommand();
                // Le asignamos la conexión al comando
                comando.Connection = conexion;
                comando.CommandText = "DELETE FROM materiales where id = @id";
                comando.Parameters.AddWithValue("@id", id);
                resultado = comando.ExecuteNonQuery();
                if (resultado == 1)
                    borrado = true;
            }
            return borrado;
        }

        public static void crearMaterial(string nombre, string descripcion, string usuario, string categoria, 
            string archivo, int tamaño, string idioma, string referencia)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                // Abrimos la conexión
                conexion.Open();
                // Creamos el comando
                SqlCommand comando = new SqlCommand();
                // Le asignamos la conexión al comando
                comando.Connection = conexion;
                comando.CommandText = "INSERT INTO " +
                    "Materiales(nombre,descripcion,usuario,categoria,archivo,tamaño,idioma,referencia) " +
                    "VALUES (@nombre,@descripcion,@usuario,@categoria,@archivo,@tamaño,@idioma,@referencia)";
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@descripcion", descripcion);
                comando.Parameters.AddWithValue("@usuario", usuario);
                comando.Parameters.AddWithValue("@categoria", categoria);
                comando.Parameters.AddWithValue("@archivo", archivo);
                comando.Parameters.AddWithValue("@tamaño", tamaño);
                comando.Parameters.AddWithValue("@idioma", idioma);
                comando.Parameters.AddWithValue("@referencia", referencia);
                comando.ExecuteNonQuery();
            }
            /*
            comando.Parameters["@Date"].Value = DateTime.Now.ToString();
            comando.Parameters.Add("@From", SqlDbType.NVarChar);
            myCmd.Parameters["@From"].Value = msgFrom.Value;
            myCmd.Parameters.Add("@Mail", SqlDbType.NVarChar);
            myCmd.Parameters["@Mail"].Value = msgEmail.Value;
           */
        }
    }
}
