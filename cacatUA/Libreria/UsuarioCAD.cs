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
    public class UsuarioCAD
    {
        static string cadenaConexion = @"Data Source=DESKTOP\SQLEXPRESS;Initial Catalog=cacatuaBD;Integrated Security=True;Pooling=False";

        public UsuarioCAD()
        { 
        
        }

        // Extrae los datos de un objeto DataReader y los almacena en un 
        // ENUsuarioCRUD que devuelve
        private static ENUsuarioCRUD ObtenerDatos(SqlDataReader dr)
        {
            ENUsuarioCRUD usuario = new ENUsuarioCRUD();

            usuario.Id = int.Parse(dr["id"].ToString());
            usuario.Usuario = dr["usuario"].ToString();
            usuario.Contrasena = dr["contrasena"].ToString();
            usuario.Nombre = dr["nombre"].ToString();
            usuario.Dni = dr["dni"].ToString();
            usuario.Correo = dr["correo"].ToString();
            usuario.Adicional = dr["adicional"].ToString();

            /*
            DateTime f = new DateTime();
            usuario.Fechaingreso = dr["fecha"].ToString();
            */

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
        public static ENUsuarioCRUD ObtenerUsuario(int id)
        {
            ENUsuarioCRUD usuario = null;

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
            }
            catch (SqlException sqlex)
            {
                // throw new CADException (“Error en la consulta de clientes por ciudad: " + clienteID, sqlex );
                //MessageBox.Show();
            }

            return usuario;
        }

        // Devuelve la lista de usuarios
        public static ArrayList ObtenerUsuarios()
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
                    ENUsuarioCRUD usuario = ObtenerDatos(dr);
                    usuarios.Add(usuario);
                }
            }
            catch (SqlException sqlex)
            {
                // throw new CADException (“Error en la consulta de clientes por ciudad: " + clienteID, sqlex );
                //MessageBox.Show();
            }
        
            return usuarios;
        }

        // Borra un usuario determinado dado un id
        public static bool BorrarUsuario(int id)
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
            }
            catch (SqlException sqlex)
            {
                // throw new CADException (“Error en la consulta de clientes por ciudad: " + clienteID, sqlex );
                //MessageBox.Show();                
            }

            return (borrado);

        }

        public static void CrearUsuario(string usuario, string contrasena, string nombre, string dni, string correo, bool activo, string adicional)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "INSERT INTO" +
                    "Usuarios ()" +
                    "VALUES ()";
            }
            catch (SqlException sqlex)
            {
                // throw new CADException (“Error en la consulta de clientes por ciudad: " + clienteID, sqlex );
                //MessageBox.Show(); 
            }
        }
    }

}
