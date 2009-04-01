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
    public class GruposCAD
    {
        private static String cadenaConexion = ConfigurationManager.ConnectionStrings["cacatua"].ConnectionString;

        private void obtenerUsuarios(SqlDataReader reader, ENGruposCRUD grupo)
        {
            grupo.Usuarios.Add(reader["usuario"].ToString());
            grupo.NumUsuarios++;
        }


        private ENGruposCRUD obtenerDatos(SqlDataReader reader)
        {
            ENGruposCRUD grupo = new ENGruposCRUD();
            grupo.Id = int.Parse(reader["id"].ToString());
            grupo.Nombre = reader["nombre"].ToString();
            grupo.Descripcion = reader["descripcion"].ToString();
            grupo.Fecha = DateTime.Parse(reader["fecha"].ToString());
            return grupo;
        }

        private SqlDataReader buscarUsuarios(string nombre)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                // Creamos el comando
                SqlCommand comando = new SqlCommand();
                // Le asignamos la conexión al comando
                comando.Connection = conexion;
                comando.CommandText = "SELECT usuario FROM miembros where grupo = @grupo";
                comando.Parameters.AddWithValue("@grupo",nombre);
                SqlDataReader readerUsu = comando.ExecuteReader();
                return readerUsu;
            }
        }

        public ArrayList obtenerGrupos()
        {
            ArrayList grupos = new ArrayList();
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                // Creamos el comando
                SqlCommand comando = new SqlCommand();
                // Le asignamos la conexión al comando
                comando.Connection = conexion;
                comando.CommandText = "SELECT * FROM grupos";
                SqlDataReader reader = comando.ExecuteReader();
                // Recorremos el reader y vamos insertando en el array list objetos del tipo ENgruposCRUD
                while (reader.Read())
                {
                    ENGruposCRUD grupo = obtenerDatos(reader);
                    /*SqlDataReader readerUsu = buscarUsuarios(grupo.Nombre);
                    while (readerUsu.Read())
                    {
                        obtenerUsuarios(readerUsu, grupo);
                    }*/
                    grupos.Add(grupo);
                }
            }
            return grupos;
        }

        public ENGruposCRUD obtenerGrupo(int id)
        {
            ENGruposCRUD grupos = null;
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                // Abrimos la conexión
                conexion.Open();
                // Creamos el comando
                SqlCommand comando = new SqlCommand();
                // Le asignamos la conexión al comando
                comando.Connection = conexion;
                comando.CommandText = "SELECT * FROM grupos where id = @id";
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    // Obtenemos la información
                    grupos = obtenerDatos(reader);
                    /*SqlDataReader readerUsu = buscarUsuarios(grupos.Nombre);
                    while (readerUsu.Read())
                    {
                        obtenerUsuarios(readerUsu, grupos);
                    }*/
                }
            }
            return grupos;
        }

        public bool borrarGrupo(int id)
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
                comando.CommandText = "DELETE FROM grupos where id = @id";
                comando.Parameters.AddWithValue("@id", id);
                resultado = comando.ExecuteNonQuery();
                if (resultado == 1)
                    borrado = true;
            }
            return borrado;
        }

        public bool crearGrupo(string nombre, string descripcion, DateTime fecha,ArrayList usuarios)
        {
            int resultado = 0;
            bool creacion = false;
            bool usuario = true;
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                // Abrimos la conexión
                conexion.Open();
                // Creamos el comando
                SqlCommand comando = new SqlCommand();
                // Le asignamos la conexión al comando
                comando.Connection = conexion;
                comando.CommandText = "INSERT INTO " +
                    "grupos(nombre,descripcion,fecha) " +
                    "VALUES (@nombre,@descripcion,@fecha)";
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@descripcion", descripcion);
                comando.Parameters.AddWithValue("@fecha", fecha);
                resultado=comando.ExecuteNonQuery();
                if (usuarios.Count != 0)
                {
                    foreach (Object obj in usuarios)
                    {
                        if (!insertarUsuario(obj.ToString(), nombre))
                        {
                            usuario = false;
                        }
                    }
                }
                if (resultado == 1 && usuario == true)
                {
                    creacion = true;
                }
            }
            return creacion;
        }

        public bool insertarUsuario(string usuario,string grupo)
        {
            int resultado = 0;
            bool insertado = false;
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                // Abrimos la conexión
                conexion.Open();
                // Creamos el comando
                SqlCommand comando = new SqlCommand();
                // Le asignamos la conexión al comando
                comando.Connection = conexion;
                comando.CommandText = "INSERT INTO " +
                    "miembros(usuario,grupo) " +
                    "VALUES (@usuario,@grupo)";
                comando.Parameters.AddWithValue("@usuario", usuario);
                comando.Parameters.AddWithValue("@grupo", grupo);
                resultado=comando.ExecuteNonQuery();
                if (resultado == 1)
                {
                    insertado = true;
                }
            }
            return insertado;
        }

        public bool borrarUsuario(string usuario,string grupo)
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
                comando.CommandText = "DELETE FROM miembros where usuario = @usuario and grupo = @grupo";
                comando.Parameters.AddWithValue("@usuario", usuario);
                comando.Parameters.AddWithValue("@grupo", grupo);
                resultado = comando.ExecuteNonQuery();
                if (resultado == 1)
                    borrado = true;
            }
            return borrado;
        }
    }
}