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
    // Clase singleton
    // Componente de Acceso a Datos para relacionarse con la BD 'usuarios'
    sealed class UsuarioCAD
    {
        private static readonly UsuarioCAD instancia = new UsuarioCAD();
        private String cadenaConexion;
        
        // Devuelve la instancia única de la clase
        public static UsuarioCAD Instancia
        {
            get { return(instancia); }
        }

        // El constructor privado crea la cadena de conexión
        private UsuarioCAD()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["cacatua"].ConnectionString;
        }

        // Extrae los datos de un objeto DataReader y los almacena en un 
        // ENUsuario que devuelve
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
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
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
                    // en un objeto ENUsuario
                    usuario = ObtenerDatos(dr);
                }

                conexion.Close();
            }
            catch (SqlException ex)
            {
                Console.Write("Excepcion obtener usuario " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }

            return usuario;
        }

        public ENUsuario ObtenerUsuario(string nombre)
        {
            ENUsuario usuario = null;
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open(); // Abrimos la conexión
                SqlCommand comando = new SqlCommand(); // Creamos un SqlCommand
                comando.Connection = conexion; // Asignamos la cadena de conexión
                comando.CommandText = "SELECT * FROM usuarios where usuario LIKE @usuario"; // Asignamos la sentencia SQL
                comando.Parameters.AddWithValue("@usuario", "%" + nombre + "%");

                // Creamo un objeto DataReader
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    // Extraemos la información del DataReader y la almacenamos
                    // en un objeto ENUsuarioCRUD
                    usuario = ObtenerDatos(dr);
                }
            }
            catch (SqlException)
            {
                // throw new CADException (“Error en la consulta de clientes por ciudad: " + clienteID, sqlex );
                Console.Write("Excepcion obtener usuario por nombre");
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
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
                comando.CommandText = "SELECT * FROM usuarios";
                SqlDataReader dr = comando.ExecuteReader();
                // Generamos el ArrayList a partir del DataReader
                while (dr.Read())
                {
                    ENUsuario usuario = ObtenerDatos(dr);
                    usuarios.Add(usuario);
                }
            }
            catch (SqlException ex)
            {
                Console.Write("Excepción obtener usuarios " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
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
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
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
            }
            catch (SqlException)
            {
                // throw new CADException (“Error en la consulta de clientes por ciudad: " + clienteID, sqlex );
                //MessageBox.Show();   
                Console.Write("Excepcion borrar");
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }

            return (borrado);
        }

        public bool Actualizar(ENUsuario usuario)
        {
            bool actualizado = false;

            SqlConnection conexion = null;
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();

                string sentencia = "update usuarios set usuario = @usuario, contrasena = @contrasena, nombre = @nombre, correo = @correo, dni = @dni, adicional = @adicional, fechaingreso = @fechaingreso, activo = @activo where id = @id";

                SqlCommand comando = new SqlCommand(sentencia, conexion);
                comando.Parameters.AddWithValue("@usuario", usuario.Usuario);
                comando.Parameters.AddWithValue("@contrasena", usuario.Contrasena);
                comando.Parameters.AddWithValue("@nombre", usuario.Nombre);
                comando.Parameters.AddWithValue("@dni", usuario.Dni);
                comando.Parameters.AddWithValue("@correo", usuario.Correo);
                comando.Parameters.AddWithValue("@fechaingreso", usuario.Fechaingreso);
                comando.Parameters.AddWithValue("@adicional", usuario.Adicional);
                comando.Parameters.AddWithValue("@activo", usuario.Activo);
                comando.Parameters.AddWithValue("@id", usuario.Id);

                if (comando.ExecuteNonQuery() == 1)
                {
                    actualizado = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar un usuario" + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return actualizado;
        }

        public bool CrearAdmin(int usuario)
        {
            bool creado = false;
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            SqlCommand comando = new SqlCommand();

            try
            {
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandText = "INSERT INTO administradores (usuario) VALUES (@usuario)";
                comando.Parameters.AddWithValue("@usuario", usuario);

                if (comando.ExecuteNonQuery() == 1)
                {
                    creado = true;
                }
            }
            catch (SqlException ex)
            {
                Console.Write("Error al insertar en administradores " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();        
                }
            }

            return (creado);
        }

        public bool BorrarAdmin(int usuario)
        {
            bool borrado = false;
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            SqlCommand comando = new SqlCommand();

            try
            {
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandText = "DELETE FROM administradores WHERE usuario = @usuario";
                comando.Parameters.AddWithValue("@usuario", usuario);

                if (comando.ExecuteNonQuery() == 1)
                {
                    borrado = true;
                }
            }
            catch (SqlException ex)
            {
                Console.Write("Error al borrar en administradores " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }

            return (borrado);
        }
            
        public bool CrearUsuario(string usuario, string contrasena, string nombre, string dni, string correo, DateTime fechaingreso, bool activo, string adicional)
        {
            bool creado = false;
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

                if (comando.ExecuteNonQuery() == 1)
                {
                    creado = true;
                }
            }
            catch (SqlException ex)
            {
                Console.Write("Excepcion insertar " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }

            return (creado);
        }

        public ArrayList BuscarUsuario(string nombreUsuario, string correo, DateTime fechaIngreso)
        {
            bool usarUsuario = false;
            bool usarCorreo = false;
            bool usarFecha = false;
            string cadenaFecha = "";

            if (nombreUsuario != "")
            {
                usarUsuario = true;
            }
            if (correo != "")
            {
                usarCorreo = true;
            }            
            if (fechaIngreso.Date != DateTime.Now.Date)
            {
                usarFecha = true;

                // Generamos una cadena a partir de la fecha
                cadenaFecha += fechaIngreso.Day;
                cadenaFecha += "/";
                cadenaFecha += fechaIngreso.Month;
                cadenaFecha += "/";
                cadenaFecha += fechaIngreso.Year;
            }

            SqlConnection conexion = new SqlConnection(cadenaConexion);
            ArrayList usuarios = new ArrayList();

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();

                comando.Connection = conexion;

                comando.CommandText = "SELECT * FROM usuarios WHERE ";

                if (usarUsuario)
                {
                    comando.CommandText += "(usuario LIKE @usuario) ";
                }
                if (usarCorreo)
                {
                    if (usarUsuario)
                    {
                        comando.CommandText += "AND ";
                    }
                    comando.CommandText += "(correo LIKE @correo) ";
                }

                if (usarFecha)
                {
                    if (usarUsuario || usarCorreo)
                    {
                        comando.CommandText += "AND ";
                    }
                    comando.CommandText += "(fechaingreso = @fechaingreso) ";
                }

                comando.Parameters.AddWithValue("@usuario", "%" + nombreUsuario + "%");
                comando.Parameters.AddWithValue("@correo", "%" + correo + "%");
                comando.Parameters.AddWithValue("@fechaingreso", cadenaFecha);

                SqlDataReader dr = comando.ExecuteReader();
                // Generamos el ArrayList a partir del DataReader
                while (dr.Read())
                {
                    ENUsuario usuario = ObtenerDatos(dr);
                    usuarios.Add(usuario);
                }
            }
            catch (SqlException sqlex)
            {
                Console.Write("Excepcion buscar" + sqlex.Message);
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }

            return usuarios;
        }

        public bool EsAdministrador(int id)
        {
            bool esAdmin = false;
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "SELECT count(*) FROM administradores where usuario = @id";
                comando.Parameters.AddWithValue("@id", id);
                int cantidad = int.Parse(comando.ExecuteScalar().ToString());
                // Comprobamos si hemos obtenido algun resultado
                if (cantidad == 1)
                {
                    esAdmin = true;
                }
            }
            catch (SqlException ex)
            {
                Console.Write("Excepcion EsAdmin " + ex.Message);
            }
            finally 
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }

            return (esAdmin);
        }
    }
}
