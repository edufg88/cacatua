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
    sealed class GruposCAD
    {
        private static readonly GruposCAD instancia = new GruposCAD();
        private String cadenaConexion;

        public static GruposCAD Instancia
        {
            get { return instancia; }
        }

        private GruposCAD()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["cacatua"].ConnectionString;
        }

        /// <summary>
        /// Añade al grupo un usuario
        /// </summary>
        /// <param name="user">La ID del usuario en tipo string</param>
        /// <param name="grupo">El grupos que deseamos saber sus usuarios</param>
        private void obtenerUsuario(string user, ENGrupos grupo)
        {
            ENUsuario usuario = ENUsuario.Obtener(int.Parse(user));
            grupo.Usuarios.Add(usuario);
            grupo.NumUsuarios++;
        }

        /// <summary>
        /// Obtiene los datos de un grupo a partir de un reader
        /// </summary>
        /// <param name="reader">DataReader del que obtendremos los datos</param>
        /// <returns>Un grupo con los datos obtenidos</returns>
        private ENGrupos obtenerDatos(SqlDataReader reader)
        {
            ENGrupos grupo = new ENGrupos();
            grupo.Id = int.Parse(reader["id"].ToString());
            grupo.Nombre = reader["nombre"].ToString();
            grupo.Descripcion = reader["descripcion"].ToString();
            grupo.Fecha = DateTime.Parse(reader["fecha"].ToString());
            return grupo;
        }

        /// <summary>
        /// Busca todos los usuarios miembros de un grupo en la DB 
        /// </summary>
        /// <param name="grupo">ID del Grupo que queremos saber sus usuarios</param>
        /// <returns>Un ArrayList con todos los usuarios de grupo</returns>
        private ArrayList buscarUsuarios(int grupo)
        {
            ArrayList usuarios = new ArrayList();
            SqlConnection conexion = null;
            try
            {
                // Creamos y abrimos la conexión.
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                // Creamos el comando
                SqlCommand comando = new SqlCommand();
                // Le asignamos la conexión al comando
                comando.Connection = conexion;
                comando.CommandText = "SELECT usuario FROM miembros where grupo = @grupo";
                comando.Parameters.AddWithValue("@grupo",grupo);
                SqlDataReader readerUsu = comando.ExecuteReader();
                while (readerUsu.Read())
                {
                    usuarios.Add(readerUsu["usuario"].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en ENGrupos.buscarUsuarios():" + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return usuarios;
        }

        /// <summary>
        /// Devuelve todos los grupos que hay en la base de datos
        /// </summary>
        /// <returns>ArrayList con todos los grupos de la DB</returns>
        public ArrayList ObtenerTodos()
        {
            ArrayList grupos = new ArrayList();
            ArrayList usuarios = new ArrayList();
            SqlConnection conexion = null;
            try
            {
                // Creamos y abrimos la conexión.
                conexion = new SqlConnection(cadenaConexion);
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
                    ENGrupos grupo = obtenerDatos(reader);
                    usuarios = buscarUsuarios(grupo.Id);
                    foreach (string ob in usuarios)
                    {
                        obtenerUsuario(ob, grupo);
                    }
                    grupos.Add(grupo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en ENGrupos.ObtenerTodos():" + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return grupos;
        }

        /// <summary>
        /// Busca un grupo en la DB con el nombre que desees para ver si existe.
        /// </summary>
        /// <param name="nombre">Nombre del grupo que queremos buscar</param>
        /// <returns>Booleano para indicar si existe ese grupo</returns>
        public bool Existe(string nombre)
        {
            bool encontrado = false;
            SqlConnection conexion = null;
            try
            {
                // Creamos y abrimos la conexión.
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                // Creamos el comando
                SqlCommand comando = new SqlCommand();
                // Le asignamos la conexión al comando
                comando.Connection = conexion;
                comando.CommandText = "SELECT * FROM grupos where nombre = @nombre";
                comando.Parameters.AddWithValue("@nombre", nombre);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    encontrado = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en ENGrupos.Existe():" + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return encontrado;
        }

        /// <summary>
        /// Devuelve un grupos con la id indicada por parametro
        /// </summary>
        /// <param name="id">Id del grupo que se desea buscar</param>
        /// <returns></returns>
        public ENGrupos Obtener(int id)
        {
            ENGrupos grupos = null;
            ArrayList usuarios = new ArrayList();
            SqlConnection conexion = null;
            try
            {
                // Creamos y abrimos la conexión.
                conexion = new SqlConnection(cadenaConexion);
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
                    usuarios = buscarUsuarios(grupos.Id);
                    foreach (string ob in usuarios)
                    {
                        obtenerUsuario(ob, grupos);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en ENGrupos.Obtener():" + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return grupos;
        }

        /// <summary>
        /// Borra un grupo de la base de datos
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public bool Borrar(ENGrupos grupo)
        {
            int resultado = 0;
            bool borrado = false;
            SqlConnection conexion = null;
            try
            {
                // Creamos y abrimos la conexión.
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                // Creamos el comando
                SqlCommand comando = new SqlCommand();
                // Le asignamos la conexión al comando
                comando.Connection = conexion;
                comando.CommandText = "DELETE FROM grupos where id = @id";
                comando.Parameters.AddWithValue("@id", grupo.Id);
                resultado = comando.ExecuteNonQuery();
                if (resultado == 1)
                    borrado = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en ENGrupos.Borrar():" + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return borrado;
        }

        /// <summary>
        /// Cambia los datos de un grupo en la DB
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public bool Actualizar(ENGrupos grupo)
        {
            int resultado = 0;
            bool actualizado = false;
            SqlConnection conexion = null;
            try
            {
                // Creamos y abrimos la conexión.
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                // Creamos el comando
                SqlCommand comando = new SqlCommand();
                // Le asignamos la conexión al comando
                comando.Connection = conexion;
                comando.CommandText = "UPDATE grupos SET nombre = @nombre , descripcion = @descripcion "+ 
                    "where id = @id";
                comando.Parameters.AddWithValue("@id",grupo.Id);
                comando.Parameters.AddWithValue("@nombre",grupo.Nombre);
                comando.Parameters.AddWithValue("@descripcion",grupo.Descripcion);
                //Actualizar usuarios
                resultado = comando.ExecuteNonQuery();
                if (resultado == 1)
                    actualizado = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en ENGrupos.Actualizar():" + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return actualizado;
        }

        /// <summary>
        /// Inserta un grupo en la DB
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public bool Guardar(ENGrupos grupo)
        {
            int resultado = 0;
            bool guardado = false;
            bool usuario = true;
            SqlConnection conexion = null;
            if (!Existe(grupo.Nombre))
            {
                try
                {
                    // Creamos y abrimos la conexión.
                    conexion = new SqlConnection(cadenaConexion);
                    conexion.Open();
                    // Creamos el comando
                    SqlCommand comando = new SqlCommand();
                    // Le asignamos la conexión al comando
                    comando.Connection = conexion;
                    comando.CommandText = "INSERT INTO " +
                        "grupos(nombre,descripcion,fecha) " +
                        "VALUES (@nombre,@descripcion,@fecha)";
                    comando.Parameters.AddWithValue("@nombre", grupo.Nombre);
                    comando.Parameters.AddWithValue("@descripcion", grupo.Descripcion);
                    comando.Parameters.AddWithValue("@fecha", grupo.Fecha);
                    resultado = comando.ExecuteNonQuery();
                    if (grupo.NumUsuarios != 0)
                    {
                        foreach (Object obj in grupo.Usuarios)
                        {
                            if (!InsertarUsuario(obj.ToString(), grupo.Id))
                            {
                                usuario = false;
                            }
                        }
                    }
                    if (resultado == 1 && usuario == true)
                    {
                        guardado = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en ENGrupos.Guardar():" + ex.Message);
                }
                finally
                {
                    if (conexion != null)
                        conexion.Close();
                }
            }
            
            return guardado;
        }

        /// <summary>
        /// Inserta en la DB los usuarios de un Grupo
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public bool InsertarUsuario(string usuario,int grupo)
        {
            int resultado = 0;
            bool insertado = false;
            SqlConnection conexion = null;
            try
            {
                // Creamos y abrimos la conexión.
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
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
            catch (Exception ex)
            {
                Console.WriteLine("Error en ENGrupos.Insertarusuario():" + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return insertado;
        }

        /// <summary>
        /// Borra un usuario miembro de un grupo.
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public bool BorrarUsuario(int usuario,int grupo)
        {
            int resultado = 0;
            bool borrado = false;
            SqlConnection conexion = null;
            try
            {
                // Abrimos la conexión
                conexion = new SqlConnection(cadenaConexion);
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
            catch (Exception ex)
            {
                Console.WriteLine("Error en ENGrupos.BorrarUsuario(): " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return borrado;
        }

        /// <summary>
        /// Busca los grupos acordes a los parámetros.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public ArrayList Buscar(int min, int max,ENGrupos grupo,DateTime fechafin, ref ENUsuario usuario)
        {
            ArrayList grupos = new ArrayList();
            SqlConnection conexion = null;
            try
            {
                // Creamos y abrimos la conexión.
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                // Creamos el comando
                /*string fechadesde=grupo.Fecha.ToShortDateString();
                string fechahasta = fechafin.ToShortDateString();*/
                string comand="SELECT id,nombre,descripcion,fecha FROM grupos LEFT OUTER JOIN miembros ON id=grupo WHERE fecha between @fechainicio and @fechafin";
                if (grupo.Nombre != "")
                {
                    comand+=" AND nombre like'%"+@grupo.Nombre+"%'";
                }
                if (usuario != null)
                {
                    comand+=" AND usuario=@usuario";
                }
                if (max!=0 && min == max )
                {
                    comand += " AND (SELECT COUNT(*) FROM miembros WHERE grupo = id GROUP BY grupo) = @min";
                }
                else if(max!=0)
                {
                    comand += " AND (SELECT COUNT(*) FROM miembros WHERE grupo = id GROUP BY grupo) BETWEEN @min AND @max";
                }
                comand += " GROUP BY id,nombre,descripcion,fecha";
                SqlCommand comando = new SqlCommand(comand, conexion);
                comando.Parameters.AddWithValue("@fechainicio", grupo.Fecha);
                comando.Parameters.AddWithValue("@fechafin", fechafin);
                if (grupo.Nombre != "")
                {
                    comando.Parameters.AddWithValue("@nombre", grupo.Nombre);
                }
                if (usuario != null)
                {
                    comando.Parameters.AddWithValue("@usuario", usuario.Id);
                }
                if (max != 0 && min == max)
                {
                    comando.Parameters.AddWithValue("@min", min);
                }
                else if (max != 0)
                {
                    comando.Parameters.AddWithValue("@min", min);
                    comando.Parameters.AddWithValue("@max", max);
                }
                /*if (autor != null)
                    comando.Parameters.AddWithValue("@autor", autor.Id);*/

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ENGrupos aux = Obtener(int.Parse(reader["id"].ToString()));
                    grupos.Add(aux);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ArrayList ENGrupos.Buscar():" + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return grupos;
        }
    }
}