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
    public class CategoriaCAD
    {
        static string cadenaConexion = ConfigurationManager.ConnectionStrings["cacatua"].ConnectionString;

        public static ENCategoriaCRUD obtenerCategoria(int id)
        {
            ENCategoriaCRUD categoria = new ENCategoriaCRUD();
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "SELECT * FROM CATEGORIAS where id = @idcat";
                comando.Parameters.AddWithValue("@idcat", id);

                SqlDataReader reader = comando.ExecuteReader();
                // Recorremos el reader y vamos insertando en el array list
                while (reader.Read())
                {
                    categoria = obtenerDatos(reader);
                }
            }
            return categoria;
        }

        public static ENCategoriaCRUD obtenerDatos(SqlDataReader reader)
        {
            ENCategoriaCRUD categoria = new ENCategoriaCRUD();
            categoria.Id = int.Parse(reader["id"].ToString());
            categoria.Nombre = reader["nombre"].ToString();
            categoria.Descripcion = reader["descripcion"].ToString();
            if (reader["padre"].ToString() != "")
            {
                categoria.Padre = int.Parse(reader["padre"].ToString());
            }
            else
            {
                categoria.Padre = 0;
            }
            return categoria;
        }


        public static bool crearCategoria(ENCategoriaCRUD categoria)
        {
            int resultado = 0;
            bool creada = false;
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                // Abrimos la conexión
                conexion.Open();
                // Creamos el comando
                SqlCommand comando = new SqlCommand();
                // Le asignamos la conexión al comando
                comando.Connection = conexion;
                if (categoria.Padre == 0)
                {
                    comando.CommandText = "INSERT INTO " +
                                          "CATEGORIAS (nombre,descripcion) " +
                                          "VALUES (@nombre,@descripcion)";
                    comando.Parameters.AddWithValue("@nombre", categoria.Nombre);
                    comando.Parameters.AddWithValue("@descripcion", categoria.Descripcion);
                }
                else
                {
                    comando.CommandText = "INSERT INTO " +
                                          "CATEGORIAS (nombre,descripcion,padre) " +
                                          "VALUES (@nombre,@descripcion,@padre)";
                    comando.Parameters.AddWithValue("@nombre", categoria.Nombre);
                    comando.Parameters.AddWithValue("@descripcion", categoria.Descripcion);
                    comando.Parameters.AddWithValue("@padre", categoria.Padre);
                }

                resultado = comando.ExecuteNonQuery();
                if (resultado == 1)
                    creada = true;
            }
            return creada;
        }

        public static bool actualizarCategoria(ENCategoriaCRUD categoria)
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
                comando.CommandText = "UPDATE CATEGORIAS " +
                    "SET nombre = @nombre,descripcion = @descripcion " +
                    "WHERE id = @id";
                comando.Parameters.AddWithValue("@nombre", categoria.Nombre);
                comando.Parameters.AddWithValue("@descripcion", categoria.Descripcion);
                comando.Parameters.AddWithValue("@id", categoria.Id);
                resultado = comando.ExecuteNonQuery();
                if (resultado == 1)
                    actualizada = true;
            }
            return actualizada;
        }

        public static bool borrarCategoria(ENCategoriaCRUD categoria)
        {
            int resultado = 0;
            bool borrada = false;
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                // Abrimos la conexión
                conexion.Open();
                // Creamos el comando
                SqlCommand comando = new SqlCommand();
                // Le asignamos la conexión al comando
                comando.Connection = conexion;
                comando.CommandText = "DELETE FROM CATEGORIAS " +
                    "WHERE id = @id";
                comando.Parameters.AddWithValue("@id", categoria.Id);
                resultado = comando.ExecuteNonQuery();
                if (resultado == 1)
                    borrada = true;
            }
            return borrada;
        }

        public static ArrayList obtenerCategoriasSuperiores()
        {
            ArrayList categorias = new ArrayList();
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                string cadenaComando = "SELECT * FROM CATEGORIAS where padre is NULL";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                // Recorremos el reader y vamos insertando en el array list
                while (reader.Read())
                {
                    ENCategoriaCRUD categoria = obtenerDatos(reader);
                    categorias.Add(categoria);
                }
            }
            return categorias;
        }

        public static ArrayList obtenerHijosDe(ENCategoriaCRUD padre)
        {
            ArrayList hijos = new ArrayList();
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "SELECT * FROM CATEGORIAS where padre = @idpadre";
                comando.Parameters.AddWithValue("@idpadre", padre.Id);

                SqlDataReader reader = comando.ExecuteReader();
                // Recorremos el reader y vamos insertando en el array list
                while (reader.Read())
                {
                    ENCategoriaCRUD categoria = obtenerDatos(reader);
                    hijos.Add(categoria);
                }
            }
            return hijos;
        }

        public static ArrayList usuariosSuscritosA(ENCategoriaCRUD categoria)
        {
            ArrayList usuarios = new ArrayList();
            /*using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "SELECT * FROM USUARIO WHERE id IN (" +
                                        "SELECT usuario FROM SUSCRITOACATEGORIA where categoria = @idcat)";
                comando.Parameters.AddWithValue("@idcat", categoria.Id);
                SqlDataReader reader = comando.ExecuteReader();
                // Recorremos el reader y vamos insertando en el array list
                while (reader.Read())
                {
                    ENUsuarioCRUD usuario = ENUsuarioCRUD.ObtenerDatos(reader);
                    usuarios.Add(usuario);
                }
            }*/
            return usuarios;
        }

        public static int NumHilosEn(ENCategoriaCRUD categoria)
        {
            int n = 0;
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "SELECT count(*) numero FROM HILOS where categoria = @idcat";
                comando.Parameters.AddWithValue("@idcat", categoria.Id);

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    n = int.Parse(reader["numero"].ToString());
                }
            }
            return n;
        }

        public static int NumMaterialesEn(ENCategoriaCRUD categoria)
        {
            int n = 0;
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "SELECT count(*) numero FROM MATERIALES where categoria = @idcat";
                comando.Parameters.AddWithValue("@idcat", categoria.Id);

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    n = int.Parse(reader["numero"].ToString());
                }
            }
            return n;
        }

        public static int NumCategorias()
        {
            int n = 0;
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "SELECT count(*) numero FROM CATEGORIAS";

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    n = int.Parse(reader["numero"].ToString());
                }
            }
            return n;
        }
    }
}
