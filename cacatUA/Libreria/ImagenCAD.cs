﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;

namespace Libreria
{
    // Clase singleton
    // Componente de Acceso a Datos para relacionarse con la BD 'imagenes'
    sealed class ImagenCAD
    {
        private static readonly ImagenCAD instancia = new ImagenCAD();
        private String cadenaConexion;

        // Devuelve la instancia única de la clase
        public static ImagenCAD Instancia
        {
            get { return(instancia); }
        }

        // El constructor privado crea la cadena de conexión
        private ImagenCAD()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["cacatua"].ConnectionString;
        }

        // Extrae los datos de un objeto DataReader y los almacena en un 
        // ENImagen que devuelve
        public ENImagen ObtenerDatos(SqlDataReader dr)
        {
            ENImagen imagen = new ENImagen();
          
            imagen.Id = int.Parse(dr["id"].ToString());
            imagen.Titulo = dr["titulo"].ToString();
            imagen.Descripcion = dr["descripcion"].ToString();
            imagen.Usuario = ENUsuario.Obtener(int.Parse(dr["usuario"].ToString()));
            imagen.Archivo = dr["archivo"].ToString();
            imagen.Fecha = DateTime.Parse(dr["fecha"].ToString());

            return (imagen);
        }

        // Devuelve una determinada firma a partir de un id
        public ENImagen ObtenerImagen(int id)
        {
            ENImagen imagen = null;

            try
            {
                SqlConnection conexion = new SqlConnection(cadenaConexion);
                conexion.Open(); // Abrimos la conexión
                SqlCommand comando = new SqlCommand(); // Creamos un SqlCommand
                comando.Connection = conexion; // Asignamos la cadena de conexión
                comando.CommandText = "SELECT * FROM imagenes where id = @id"; // Asignamos la sentencia SQL
                comando.Parameters.AddWithValue("@id", id);

                // Creamo un objeto DataReader
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    // Extraemos la información del DataReader y la almacenamos
                    // en un objeto ENImagen
                    imagen = ObtenerDatos(dr);
                }

                conexion.Close();
            }
            catch (SqlException)
            {
                Console.Write("Excepcion obtener imagen");
            }

            return imagen;
        }

        public ENImagen ObtenerImagen(string titulo)
        {
            ENImagen imagen = null;

            try
            {
                SqlConnection conexion = new SqlConnection(cadenaConexion);
                conexion.Open(); // Abrimos la conexión
                SqlCommand comando = new SqlCommand(); // Creamos un SqlCommand
                comando.Connection = conexion; // Asignamos la cadena de conexión
                comando.CommandText = "SELECT * FROM imagenes where titulo = @titulo"; // Asignamos la sentencia SQL
                comando.Parameters.AddWithValue("@titulo", titulo);

                // Creamo un objeto DataReader
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    // Extraemos la información del DataReader y la almacenamos
                    // en un objeto ENImagen
                    imagen = ObtenerDatos(dr);
                }

                conexion.Close();
            }
            catch (SqlException)
            {
                Console.Write("Excepcion obtener imagen por titulo");
            }

            return imagen;
        }

        // Devuelve la lista de imagenes
        public ArrayList ObtenerImagenes()
        {
            ArrayList imagenes = new ArrayList();
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "SELECT * FROM imagenes";
                SqlDataReader dr = comando.ExecuteReader();
                // Generamos el ArrayList a partir del DataReader
                while (dr.Read())
                {
                    ENImagen imagen = ObtenerDatos(dr);
                    imagenes.Add(imagen);
                }

                conexion.Close();
            }
            catch (SqlException)
            {
                Console.Write("Excepción obtener imagenes");
            }

            return imagenes;
        }

        // Borra todas las imagenes
        public void BorrarImagenes()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "DELETE FROM imagenes";
                comando.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                Console.Write("Excepción borrando todas las imagenes");
            }
        }

        // Borra una imagen dado un determinado id
        public bool BorrarImagen(int id)
        {
            bool borrado = false;
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "DELETE FROM imagenes where id = @id";
                comando.Parameters.AddWithValue("@id", id);

                if ((comando.ExecuteNonQuery()) == 1) // Comprobamos cuantas filas se borran
                {
                    borrado = true;
                }

                conexion.Close();
            }
            catch (SqlException)
            {
                Console.Write("Excepcion borrar una imagen por id");
            }

            return (borrado);
        }

        public bool GuardarImagen(string titulo, string descripcion, string usuario, string archivo, DateTime fecha)
        {
            bool guardado = false;
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            // Obtenemos los usuarios por nombre para obtener su id
            ENUsuario autor = ENUsuario.Obtener(usuario);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();

                comando.Connection = conexion;
                comando.CommandText = "INSERT INTO " +
                    "imagenes (titulo, descripcion, usuario, archivo, fecha) " +
                    "VALUES (@titulo, @descripcion, @usuario, @archivo, @fecha)";
                comando.Parameters.AddWithValue("@titulo", titulo);
                comando.Parameters.AddWithValue("@descripcion", descripcion);
                comando.Parameters.AddWithValue("@usuario", autor.Id);
                comando.Parameters.AddWithValue("@archivo", archivo);
                comando.Parameters.AddWithValue("@fecha", fecha);

                if (comando.ExecuteNonQuery() == 1)
                {
                    guardado = true;
                }

                conexion.Close();
            }
            catch (SqlException)
            {
                Console.Write("Excepcion guardar imagen");
            }

            return (guardado);
        }

        public ArrayList BuscarImagen(string titulo, string usuario)
        {
            bool usarTitulo = false;
            bool usarUsuario = false;

            // Obtenemos los usuarios por nombre para obtener su id
            ENUsuario autor = ENUsuario.Obtener(usuario);
            
            if (titulo != "")
            {
                usarTitulo = true;
            }
            if (usuario != "")
            {
                usarUsuario = true;
            }

            SqlConnection conexion = new SqlConnection(cadenaConexion);
            ArrayList imagenes = new ArrayList();

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();

                comando.Connection = conexion;

                comando.CommandText = "SELECT * FROM imagenes WHERE ";

                if (usarTitulo)
                {
                    comando.CommandText += "(titulo = @titulo) ";
                    comando.Parameters.AddWithValue("@titulo", titulo);
                }
                if (usarUsuario)
                {
                    if (usarTitulo)
                    {
                        comando.CommandText += "AND ";
                    }
                    comando.CommandText += "(usuario = @usuario) ";
                    comando.Parameters.AddWithValue("@usuario", autor.Id);
                }                

                SqlDataReader dr = comando.ExecuteReader();
                // Generamos el ArrayList a partir del DataReader
                while (dr.Read())
                {
                    ENImagen imagen = ObtenerDatos(dr);
                    imagenes.Add(imagen);
                }

                conexion.Close();
            }
            catch (SqlException sqlex)
            {
                Console.Write("Excepcion buscar imagen" + sqlex.Message);
            }

            return imagenes;
        }

        public ArrayList BuscarImagen(int usuario)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            ArrayList imagenes = new ArrayList();

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "SELECT * FROM imagenes WHERE usuario = @usuario";
                comando.Parameters.AddWithValue("@usuario", usuario);
                SqlDataReader dr = comando.ExecuteReader();
                // Generamos el ArrayList a partir del DataReader
                while (dr.Read())
                {
                    ENImagen imagen = ObtenerDatos(dr);
                    imagenes.Add(imagen);
                }
            }
            catch (SqlException ex)
            {
                Console.Write("Error al buscar imagen por usuario " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }

            return (imagenes);
        }

        public bool Actualizar(ENImagen imagen)
        {
            bool actualizado = false;

            SqlConnection conexion = null;
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();

                string sentencia = "update imagenes set titulo = @titulo, descripcion = @descripcion, fecha = @fecha, usuario = @usuario, archivo = @archivo where id = @id";

                SqlCommand comando = new SqlCommand(sentencia, conexion);
                comando.Parameters.AddWithValue("@titulo", imagen.Titulo);
                comando.Parameters.AddWithValue("@descripcion", imagen.Descripcion);
                comando.Parameters.AddWithValue("@fecha", imagen.Fecha);
                comando.Parameters.AddWithValue("@usuario", imagen.Usuario.Id);
                comando.Parameters.AddWithValue("@archivo", imagen.Archivo);
                comando.Parameters.AddWithValue("@id", imagen.Id);

                if (comando.ExecuteNonQuery() == 1)
                {
                    actualizado = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar una imagen" + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return actualizado;
        }

        public int CantidadImagenes(int usuario)
        {
            SqlConnection conexion = null;
            int cantidad = 0;

            try
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                string sentencia = "SELECT COUNT(*) FROM imagenes WHERE usuario = @usuario";

                SqlCommand comando = new SqlCommand(sentencia, conexion);
                comando.Parameters.AddWithValue("@usuario", usuario);

                cantidad = int.Parse(comando.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al contar imágenes " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return cantidad;
        }
    }
}
