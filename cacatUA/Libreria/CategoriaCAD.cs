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
    sealed class CategoriaCAD
    {
        
        private String cadenaConexion;        
        private static readonly CategoriaCAD instancia = new CategoriaCAD();
        
        public static CategoriaCAD Instancia
        {
            get { return instancia; }
        }

        private CategoriaCAD()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["cacatua"].ConnectionString;
        }

        private ENCategoria obtenerDatos(SqlDataReader reader)
        {
            ENCategoria categoria = new ENCategoria();
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

        public ENCategoria Obtener(int id)
        {
            ENCategoria categoria = null;

            SqlConnection conexion = null;
            try
            {
                // Creamos la conexion
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión
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
            catch (Exception ex)
            {
                Console.WriteLine("Obtener(ENCategoria): " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return categoria;
        }

        public bool Crear(ENCategoria categoria)
        {
            int resultado = 0;
            bool creada = false;
            SqlConnection conexion = null;
            try
            {
                // Creamos la conexion
                conexion = new SqlConnection(cadenaConexion);
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
            catch (Exception ex)
            {
                Console.WriteLine("Crear(ENCategoria): " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return creada;
        }

        public bool Actualizar(ENCategoria categoria)
        {
            int resultado = 0;
            bool actualizada = false;
            SqlConnection conexion = null;

            try
            {
                // Creamos la conexion
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión
                conexion.Open();
                // Creamos el comando
                SqlCommand comando = new SqlCommand();
                // Le asignamos la conexión al comando
                comando.Connection = conexion;
                if (categoria.Padre == 0) {
                    comando.CommandText = "UPDATE CATEGORIAS " +
                        "SET nombre = @nombre,descripcion = @descripcion,padre = NULL " +
                        "WHERE id = @id";
                    comando.Parameters.AddWithValue("@nombre", categoria.Nombre);
                    comando.Parameters.AddWithValue("@descripcion", categoria.Descripcion);
                    comando.Parameters.AddWithValue("@id", categoria.Id);
                }
                else
                {
                    comando.CommandText = "UPDATE CATEGORIAS " +
                        "SET nombre = @nombre,descripcion = @descripcion,padre = @padre " +
                        "WHERE id = @id";
                    comando.Parameters.AddWithValue("@nombre", categoria.Nombre);
                    comando.Parameters.AddWithValue("@descripcion", categoria.Descripcion);
                    comando.Parameters.AddWithValue("@padre", categoria.Padre);
                    comando.Parameters.AddWithValue("@id", categoria.Id);
                }
                resultado = comando.ExecuteNonQuery();
                if (resultado == 1)
                    actualizada = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Actualizar(ENCategoria): " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return actualizada;
        }

        public bool Borrar(ENCategoria categoria)
        {
            int resultado = 0;
            bool borrada = false;
            SqlConnection conexion = null;

            try
            {
                // Creamos la conexion
                conexion = new SqlConnection(cadenaConexion);
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
            catch (Exception ex)
            {
                Console.WriteLine("Borrar(ENCategoria): " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return borrada;
        }

        public ArrayList ObtenerSuperiores()
        {
            ArrayList categorias = new ArrayList();
            
            SqlConnection conexion = null;
            try
            {
                // Creamos la conexion
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión
                conexion.Open();
                string cadenaComando = "SELECT * FROM CATEGORIAS where padre is NULL";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                // Recorremos el reader y vamos insertando en el array list
                while (reader.Read())
                {
                    ENCategoria categoria = obtenerDatos(reader);
                    categorias.Add(categoria);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ObtenerSuperiores(ENCategoria): " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return categorias;
        }

        public ArrayList HijosDe(ENCategoria padre)
        {
            ArrayList hijos = new ArrayList();
            SqlConnection conexion = null;
            try
            {
                // Creamos la conexion
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "SELECT * FROM CATEGORIAS where padre = @idpadre";
                comando.Parameters.AddWithValue("@idpadre", padre.Id);

                SqlDataReader reader = comando.ExecuteReader();
                // Recorremos el reader y vamos insertando en el array list
                while (reader.Read())
                {
                    ENCategoria categoria = obtenerDatos(reader);
                    hijos.Add(categoria);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("HijosDe(ENCategoria): " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return hijos;
        }

        public ArrayList UsuariosSuscritosA(ENCategoria categoria)
        {
            ArrayList usuarios = new ArrayList();
            SqlConnection conexion = null;
            try
            {
                // Creamos la conexion
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "SELECT usuario FROM SUSCRIPCIONES where categoria = @idcat";
                comando.Parameters.AddWithValue("@idcat", categoria.Id);
                SqlDataReader reader = comando.ExecuteReader();
                // Recorremos el reader y vamos insertando en el array list
                while (reader.Read())
                {
                    ENUsuario usuario = ENUsuario.Obtener(int.Parse(reader["usuario"].ToString()));
                    usuarios.Add(usuario);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("UsuariosSuscritosA(ENCategoria): " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return usuarios;
        }

        public int NumHilosEn(ENCategoria categoria)
        {
            int n = 0;
            SqlConnection conexion = null;
            try
            {
                // Creamos la conexion
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión
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
            catch (Exception ex)
            {
                Console.WriteLine("NumHilosEn(ENCategoria): " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return n;
        }

        public int NumMaterialesEn(ENCategoria categoria)
        {
            int n = 0;
            SqlConnection conexion = null;
            try
            {
                // Creamos la conexion
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión
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
            catch (Exception ex)
            {
                Console.WriteLine("NumMaterialesEn(ENCategoria): " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return n;
        }

        public int NumCategorias()
        {
            int n = 0;
            SqlConnection conexion = null;
            try
            {
                // Creamos la conexion
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión
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
            catch (Exception ex)
            {
                Console.WriteLine("NumCategorias(ENCategoria): " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return n;
        }

        public bool AñadirSuscripcion(ENCategoria categoria, ENUsuario usuario)
        {
            int resultado = 0;
            bool añadido = false;
            SqlConnection conexion = null;
            try
            {
                // Creamos la conexion
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión
                conexion.Open();
                // Creamos el comando
                SqlCommand comando = new SqlCommand();
                // Le asignamos la conexión al comando
                comando.Connection = conexion;
                comando.CommandText = "INSERT INTO " +
                                          "SUSCRIPCIONES (categoria,usuario) " +
                                          "VALUES (@categoria,@usuario)";
                comando.Parameters.AddWithValue("@categoria", categoria.Id);
                comando.Parameters.AddWithValue("@usuario", usuario.Id);
 
                resultado = comando.ExecuteNonQuery();
                if (resultado == 1)
                    añadido = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("AñadirSuscripcion(ENCategoria): " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return añadido;
        }

        public bool QuitarSuscripcion(ENCategoria categoria, ENUsuario usuario)
        {
            int resultado = 0;
            bool quitado = false;
            SqlConnection conexion = null;
            try
            {
                // Creamos la conexion
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión
                conexion.Open();
                // Creamos el comando
                SqlCommand comando = new SqlCommand();
                // Le asignamos la conexión al comando
                comando.Connection = conexion;
                comando.CommandText = "DELETE FROM SUSCRIPCIONES " +
                                      "WHERE usuario = @usuario and categoria = @categoria";
                comando.Parameters.AddWithValue("@categoria", categoria.Id);
                comando.Parameters.AddWithValue("@usuario", usuario.Id);

                resultado = comando.ExecuteNonQuery();
                if (resultado == 1)
                    quitado = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("QuitarSuscripcion(ENCategoria): " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return quitado;
        }
    }
}
