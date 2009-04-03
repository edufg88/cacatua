using System;
using System.Collections.Generic;
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
    public class UsuarioCAD
    {
        //static string cadenaConexion = @"Data Source=DESKTOP\SQLEXPRESS;Initial Catalog=cacatuaBD;Integrated Security=True;Pooling=False";
        private static String cadenaConexion = ConfigurationManager.ConnectionStrings["cacatua"].ConnectionString;
        
        public UsuarioCAD()
        {
        }

        // Extrae los datos de un objeto DataReader y los almacena en un 
        // ENUsuarioCRUD que devuelve
        public ENUsuario ObtenerDatos(SqlDataReader dr)
        {
            ENUsuario usuario = new ENUsuario();

            usuario.Id = int.Parse(dr["id"].ToString());
            usuario.Usuario = dr["usuario"].ToString();
            usuario.Contrasena = dr["contrasena"].ToString();
            usuario.Nombre = dr["nombre"].ToString();
            usuario.Dni = dr["dni"].ToString();
            usuario.Correo = dr["correo"].ToString();
            usuario.Adicional = dr["adicional"].ToString();

            usuario.Fechaingreso = DateTime.Parse(dr["fechaingreso"].ToString());

            if (int.Parse(dr["activo"].ToString()) == 0)
            {
                usuario.Activo = false;
            }
            else
            {
                usuario.Activo = true;
            }

            return (usuario);
        }

        // Devuelve un determinado usuario a partir de un id
        public ENUsuario ObtenerUsuario(int id)
        {
            ENUsuario usuario = null;

            try
            {
                SqlConnection conexion = new SqlConnection(cadenaConexion);
                conexion.Open(); // Abrimos la conexión
                SqlCommand comando = new SqlCommand(); // Creamos un SqlCommand
                comando.Connection = conexion; // Asignamos la cadena de conexión
                comando.CommandText = "SELECT * FROM usuarios where id = @id"; // Asignamos la sentencia SQL
                comando.Parameters.AddWithValue("@id", id);

                // Creamo un objeto DataReader
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    // Extraemos la información del DataReader y la almacenamos
                    // en un objeto ENUsuarioCRUD
                    usuario = ObtenerDatos(dr);
                }

                conexion.Close();
            }
            catch (SqlException)
            {
                // throw new CADException (“Error en la consulta de clientes por ciudad: " + clienteID, sqlex );
                Console.Write("Excepcion obtener usuario");
            }

            return usuario;
        }

        // Devuelve la lista de usuarios
        public ArrayList ObtenerUsuarios()
        {
            ArrayList usuarios = new ArrayList();
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "SELECT * FROM Usuarios";
                SqlDataReader dr = comando.ExecuteReader();
                // Generamos el ArrayList a partir del DataReader
                while (dr.Read())
                {
                    ENUsuario usuario = ObtenerDatos(dr);
                    usuarios.Add(usuario);
                }

                conexion.Close();
            }
            catch (SqlException)
            {
                // throw new CADException (“Error en la consulta de clientes por ciudad: " + clienteID, sqlex );
                //MessageBox.Show("error", "error");
                Console.Write("Excepción obtener usuarios");
            }
        
            return usuarios;
        }
        // Borra todos los usuarios
        public void BorrarUsuarios()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "DELETE FROM usuarios";
                comando.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                Console.Write("Excepción borrando todos los usuarios");
            }
        }

        // Borra un usuario determinado dado un id
        public bool BorrarUsuario(int id)
        {
            bool borrado = false;
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "DELETE FROM usuarios where id = @id";
                comando.Parameters.AddWithValue("@id", id);

                if ((comando.ExecuteNonQuery()) == 1) // Comprobamos cuantas filas se borran
                {
                    borrado = true;
                }

                conexion.Close();
            }
            catch (SqlException)
            {
                // throw new CADException (“Error en la consulta de clientes por ciudad: " + clienteID, sqlex );
                //MessageBox.Show();   
                Console.Write("Excepcion borrar");
            }

            return (borrado);
        }

        public void CrearUsuario(string usuario, string contrasena, string nombre, string dni, string correo, DateTime fechaingreso, bool activo, string adicional)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();

                comando.Connection = conexion;
                comando.CommandText = "INSERT INTO " +
                    "usuarios (usuario, contrasena, nombre, dni, correo, adicional, fechaingreso, activo) " +
                    "VALUES (@usuario, @contrasena, @nombre, @dni, @correo, @adicional, @fechaingreso, @activo)";
                comando.Parameters.AddWithValue("@usuario", usuario);
                comando.Parameters.AddWithValue("@contrasena", contrasena);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@dni", dni);
                comando.Parameters.AddWithValue("@correo", correo);
                comando.Parameters.AddWithValue("@adicional", adicional);
                comando.Parameters.AddWithValue("@fechaingreso", fechaingreso);
                comando.Parameters.AddWithValue("@activo", activo);
                comando.ExecuteNonQuery();

                conexion.Close();
            }
            catch (SqlException)
            {
                // throw new CADException (“Error en la consulta de clientes por ciudad: " + clienteID, sqlex );
                //MessageBox.Show(); 
                Console.Write("Excepcion insertar");
            }
        }
    }

}
