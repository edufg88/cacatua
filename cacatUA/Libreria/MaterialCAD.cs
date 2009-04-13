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
    /// <summary>
    /// Clase singleton que realiza el acceso a la base de datos para manipular los materiales.
    /// </summary>
    sealed class MaterialCAD
    {
        private static readonly MaterialCAD instancia = new MaterialCAD();
        private String cadenaConexion;

        /// <summary>
        /// Obtiene la única instancia de la clase HiloCAD. Si es la primera vez
        /// que se invoca el método, se crea el objeto; si no, sólo se devuelve la referencia
        /// al objeto que ya fue creado anteriormente.
        /// </summary>
        /// <returns>Devuelve una referencia a la única instancia de la clase.</returns>
        public static MaterialCAD Instancia
        {
            get { return instancia; }
        }


        /// <summary>
        /// Constructor en el ámbito privado de la clase para no permitir más
        /// de una instancia.
        /// </summary>
        private MaterialCAD()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["cacatua"].ConnectionString;
        }

        public bool Guardar(ENMaterial material)
        {
            bool correcto = false;
            SqlConnection conexion = null;
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión.
                conexion.Open();

                // Creamos el comando.
                SqlCommand comando = new SqlCommand();

                // Le asignamos la conexión al comando.
                comando.Connection = conexion;
                comando.CommandText = "INSERT INTO " +
                    "Materiales(nombre,descripcion,usuario,categoria,archivo,tamaño,referencia) " +
                    "VALUES (@nombre,@descripcion,@usuario,@categoria,@archivo,@tamaño,@referencia)";
                comando.Parameters.AddWithValue("@nombre", material.Nombre);
                comando.Parameters.AddWithValue("@descripcion", material.Descripcion);
                comando.Parameters.AddWithValue("@usuario", material.Usuario.Id);
                comando.Parameters.AddWithValue("@categoria", getIdCategoria(material.Categoria));
                comando.Parameters.AddWithValue("@archivo", material.Archivo);
                comando.Parameters.AddWithValue("@tamaño", material.Tamaño);
                comando.Parameters.AddWithValue("@referencia", material.Referencia);
                if (comando.ExecuteNonQuery() == 1)
                    correcto = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ENMaterial::Guardar(ENMaterial material) " + ex.Message);
                //throw ex;
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return correcto;
        }

        public ArrayList obtener()
        {
            ArrayList materiales = new ArrayList();
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                string cadenaComando = "SELECT * FROM vistaMateriales";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                // Recorremos el reader y vamos insertando en el array list objetos del tipo ENMaterialCRUD
                while (reader.Read())
                {
                    ENMaterial material = obtenerDatos(reader);
                    materiales.Add(material);
                }
            }
            return materiales;
        }

        public ArrayList Obtener(string filtroBusqueda, ENUsuario usuario, string categoria, DateTime fechaInicio, DateTime fechaFin)
        {
            ArrayList materiales = new ArrayList();
            SqlConnection conexion = null;
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión.
                conexion.Open();

                // Creamos el comando.
                SqlCommand comando = new SqlCommand();

                // Le asignamos la conexión al comando.
                comando.Connection = conexion;

                Console.WriteLine("nombre: " + filtroBusqueda);
                string cadenaComando = "SELECT * FROM vistaMateriales WHERE "
                    + "(nombre like @nombre or descripcion like @descripcion) ";
                if (usuario != null && usuario.Nombre != "")
                    cadenaComando += "and usuario = @usuario ";
                if (categoria != "")
                    cadenaComando += "and categoria = @categoria";
                /*
                if (fechaInicio <= fechaFin)
                {
                    comando.Parameters.AddWithValue("@fechainicio", fechaInicio);
                    comando.Parameters.AddWithValue("@fechafin", fechaFin);
                }
                */

                comando.CommandText = cadenaComando;
                comando.Parameters.AddWithValue("@nombre","%" + filtroBusqueda + "%");
                comando.Parameters.AddWithValue("@descripcion","%" + filtroBusqueda + "%");
                if(usuario != null)
                    comando.Parameters.AddWithValue("@usuario", usuario.Id);
                comando.Parameters.AddWithValue("@categoria", getIdCategoria(categoria));

                Console.WriteLine(comando.CommandText);
                
                SqlDataReader reader = comando.ExecuteReader();
                // Recorremos el reader y vamos insertando en el array list
                while (reader.Read())
                {
                    ENMaterial material = obtenerDatos(reader);
                    materiales.Add(material);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ENMaterial::Obtener(string filtroBusqueda, string usuario, string categoria, DateTime fechaInicio, DateTime fechaFin)) " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return materiales;
        }

        public bool existeUsuario(string nombre)
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

        private int getIdUsuario(string nombre)
        {
            int idUsuario = -1;
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                // Abrimos la conexión
                conexion.Open();
                // Creamos el comando
                SqlCommand comando = new SqlCommand();
                // Le asignamos la conexión al comando
                comando.Connection = conexion;
                comando.CommandText = "SELECT id FROM usuarios where nombre = @nombre";
                comando.Parameters.AddWithValue("@nombre", nombre);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    idUsuario = int.Parse(reader["id"].ToString());
                }
            }
            return idUsuario;
        }

        private int getIdCategoria(string nombre)
        {
            int idCategoria = -1;
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                // Abrimos la conexión
                conexion.Open();
                // Creamos el comando
                SqlCommand comando = new SqlCommand();
                // Le asignamos la conexión al comando
                comando.Connection = conexion;
                comando.CommandText = "SELECT id FROM categorias where nombre = @nombre";
                comando.Parameters.AddWithValue("@nombre", nombre);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    idCategoria = int.Parse(reader["id"].ToString());
                }
            }
            return idCategoria;
        }

        private ENMaterial obtenerDatos(SqlDataReader reader)
        {
            ENMaterial material = new ENMaterial();
            material.Id = int.Parse(reader["id"].ToString());
            material.Nombre = reader["nombre"].ToString();
            material.Descripcion = reader["descripcion"].ToString();
            //material.Fecha = reader["fecha"].ToString();
            material.Usuario = new ENUsuario(int.Parse(reader["usuario"].ToString()));
            material.Categoria = reader["categoria"].ToString();
            material.Archivo = reader["archivo"].ToString();
            material.Tamaño = int.Parse(reader["tamaño"].ToString());
            material.Descargas = int.Parse(reader["descargas"].ToString());
            material.Puntuacion = int.Parse(reader["puntuacion"].ToString());
            material.Votos = int.Parse(reader["votos"].ToString());
            material.Referencia = reader["referencia"].ToString();
            return material;
        }

        private ComentarioMaterial ObtenerDatosComentario(SqlDataReader reader)
        {
            ComentarioMaterial comentario = new ComentarioMaterial();
            comentario.Id = int.Parse(reader["id"].ToString());
            comentario.Texto = reader["texto"].ToString();
            comentario.Fecha = (DateTime)reader["fecha"];
            comentario.Usuario = new ENUsuario(int.Parse(reader["usuario"].ToString()));
            comentario.Material = ENMaterial.Obtener(int.Parse(reader["material"].ToString()));
            return comentario;
        }

        public ENMaterial obtener(int id)
        {
            ENMaterial material = null;
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                // Abrimos la conexión
                conexion.Open();
                // Creamos el comando
                SqlCommand comando = new SqlCommand();

                // Le asignamos la conexión al comando
                comando.Connection = conexion;
                /*
                string cadenaComando = "select materiales.*,count(*) votos, avg(puntuacion)valoracion "
                    + "from materiales, materialesvotos where materiales.id = materialesvotos.material and materiales.id = @id "
                    + "group by materiales.id, materiales.nombre,materiales.descripcion,materiales.fecha,materiales.usuario,"
                    + "materiales.categoria,materiales.archivo,materiales.tamaño,materiales.descargas,materiales.idioma,"
                    + "materiales.referencia";
                 */
                string cadenaComando = "SELECT * FROM vistaMateriales where id = @id";
                comando.CommandText = cadenaComando;
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                // Recorremos el reader y vamos insertando en el array list objetos del tipo ENMaterialCRUD
                if (reader.Read())
                    material = obtenerDatos(reader);
            }
            return material;
        }

        public bool Borrar(int id)
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

        public ArrayList ObtenerComentarios(ENMaterial material)
        {
            ArrayList comentarios = new ArrayList();
            SqlConnection conexion = null;
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión.
                conexion.Open();

                // Creamos el comando.
                SqlCommand comando = new SqlCommand();

                // Le asignamos la conexión al comando.
                comando.Connection = conexion;

                string cadenaComando = "SELECT * FROM materialescomentarios WHERE material = @material";
                comando.CommandText = cadenaComando;
                comando.Parameters.AddWithValue("@material", material.Id);

                SqlDataReader reader = comando.ExecuteReader();
                // Recorremos el reader y vamos insertando en el array list
                while (reader.Read())
                {
                    ComentarioMaterial comentario = ObtenerDatosComentario(reader);
                    comentarios.Add(comentario);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("<ENMaterial::ObtenerComentarios> " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return comentarios;
        }

        public ComentarioMaterial ObtenerComentario(int id)
        {
            ComentarioMaterial comentario = null;
            SqlConnection conexion = null;
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión.
                conexion.Open();

                // Creamos el comando.
                SqlCommand comando = new SqlCommand();

                // Le asignamos la conexión al comando.
                comando.Connection = conexion;

                string cadenaComando = "SELECT * FROM materialescomentarios WHERE id = @id";
                comando.CommandText = cadenaComando;
                comando.Parameters.AddWithValue("@id", id);        

                SqlDataReader reader = comando.ExecuteReader();
                // Recorremos el reader y vamos insertando en el array list
                if (reader.Read())
                    comentario = ObtenerDatosComentario(reader);
            }
            catch (Exception ex)
            {
                Console.WriteLine("<ENMaterial::ObtenerComentarios> " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return comentario;
        }

        public bool GuardarComentario(ComentarioMaterial comentario)
        {
            bool correcto = false;
            SqlConnection conexion = null;
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión.
                conexion.Open();

                // Creamos el comando.
                SqlCommand comando = new SqlCommand();

                // Le asignamos la conexión al comando.
                comando.Connection = conexion;
                comando.CommandText = "INSERT INTO " +
                    "materialescomentarios(texto,fecha,usuario,material) " +
                    "VALUES (@texto,@fecha,@usuario,@material)";
                comando.Parameters.AddWithValue("@texto", comentario.Texto);
                comando.Parameters.AddWithValue("@fecha", comentario.Fecha);
                comando.Parameters.AddWithValue("@usuario", comentario.Usuario.Id);
                comando.Parameters.AddWithValue("@material", comentario.Material.Id);
                if (comando.ExecuteNonQuery() == 1)
                    correcto = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ENMaterial::Guardar(ENMaterial material) " + ex.Message);
                //throw ex;
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return correcto;
        }

        public bool BorrarComentario(ComentarioMaterial comentario)
        {
            bool borrado = false;
            SqlConnection conexion = null;
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión.
                conexion.Open();

                // Creamos el comando.
                SqlCommand comando = new SqlCommand();

                // Le asignamos la conexión al comando.
                comando.Connection = conexion;
                comando.CommandText = "DELETE FROM materialescomentarios WHERE id = @id";
                comando.Parameters.AddWithValue("@id", comentario.Id);
                if (comando.ExecuteNonQuery() == 1)
                    borrado = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ENMaterial::Guardar(ENMaterial material) " + ex.Message);
                //throw ex;
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return borrado;
        }

        public bool ActualizarComentario(ComentarioMaterial comentario)
        {
            bool correcto = false;
            SqlConnection conexion = null;
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión.
                conexion.Open();

                // Creamos el comando.
                SqlCommand comando = new SqlCommand();

                // Le asignamos la conexión al comando.
                comando.Connection = conexion;
                comando.CommandText = "UPDATE materialescomentarios SET texto = @texto, fecha = @fecha, " +
                    "usuario = @usuario, material = @material WHERE id = @id";
                comando.Parameters.AddWithValue("@texto", comentario.Texto);
                comando.Parameters.AddWithValue("@fecha", comentario.Fecha);
                comando.Parameters.AddWithValue("@usuario", comentario.Usuario.Id);
                comando.Parameters.AddWithValue("@material", comentario.Material.Id);
                comando.Parameters.AddWithValue("@id", comentario.Id);
                if (comando.ExecuteNonQuery() == 1)
                    correcto = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ENMaterial::Guardar(ENMaterial material) " + ex.Message);
                //throw ex;
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return correcto;
        }
    }
}
/*
comando.Parameters["@Date"].Value = DateTime.Now.ToString();
comando.Parameters.Add("@From", SqlDbType.NVarChar);
myCmd.Parameters["@From"].Value = msgFrom.Value;
myCmd.Parameters.Add("@Mail", SqlDbType.NVarChar);
myCmd.Parameters["@Mail"].Value = msgEmail.Value;
*/