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
    sealed class PeticionCAD
    {

        private static readonly PeticionCAD instancia = new PeticionCAD();
        static string cadenaConexion;

        public static PeticionCAD Instancia
        {
            get { return instancia; }
        }


        private PeticionCAD()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["cacatua"].ConnectionString;
        }

        public ArrayList ObtenerSinContestar()
        {
            ArrayList peticiones = new ArrayList();
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "SELECT * FROM peticiones where respuesta is NULL";

                SqlDataReader reader = comando.ExecuteReader();
                // Recorremos el reader y vamos insertando en el array list
                while (reader.Read())
                {
                    peticiones.Add(obtenerDatos(reader));
                }
            }
            return peticiones;
        }

        private ENPeticion obtenerDatos(SqlDataReader reader)
        {
            ENPeticion peticion = new ENPeticion();
            peticion.Id = int.Parse(reader["id"].ToString());
            peticion.Asunto = reader["asunto"].ToString();
            peticion.Texto = reader["texto"].ToString();
            ENUsuario us = ENUsuario.Obtener(int.Parse(reader["usuario"].ToString()));
            peticion.Usuario = us;
            peticion.Respuesta = reader["respuesta"].ToString();
            peticion.Fecha = DateTime.Parse(reader["fecha"].ToString());

            return peticion;
        }

        public ArrayList ObtenerContestadas()
        {
            ArrayList peticiones = new ArrayList();
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "SELECT * FROM peticiones where respuesta is not NULL";

                SqlDataReader reader = comando.ExecuteReader();
                // Recorremos el reader y vamos insertando en el array list
                while (reader.Read())
                {
                    peticiones.Add(obtenerDatos(reader));
                }
            }
            return peticiones;
        }

        public ArrayList ObtenerTodas()
        {
            ArrayList peticiones = new ArrayList();
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "SELECT * FROM peticiones";

                SqlDataReader reader = comando.ExecuteReader();
                // Recorremos el reader y vamos insertando en el array list
                while (reader.Read())
                {
                    peticiones.Add(obtenerDatos(reader));
                }
            }
            return peticiones;
        }

        public ENPeticion GetPeticion(int id)
        {
            ENPeticion peticion = new ENPeticion();
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "SELECT * FROM peticiones where id=" + id;
                //comando.Parameters.AddWithValue("@idpet", id);

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    peticion = obtenerDatos(reader);
                }
            }
            return peticion;
        }

        public bool ActualizarPeticion(ENPeticion peticion)
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
                comando.CommandText = "UPDATE peticiones " +
                    "SET respuesta = @respuesta " +
                    "WHERE id = @id";
                comando.Parameters.AddWithValue("@respuesta", peticion.Respuesta);
                comando.Parameters.AddWithValue("@id", peticion.Id);
                resultado = comando.ExecuteNonQuery();
                if (resultado == 1)
                    actualizada = true;
            }
            return actualizada;
        }

        public bool BorrarPeticion(int id)
        {
            ENPeticion peticion = new ENPeticion();
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "DELETE FROM peticiones where id=" + id;

                SqlDataReader reader = comando.ExecuteReader();
            }
            return true;
        }
        /*
        public ArrayList Obtener(string asunto, string texto, int usuario, int mostrar, ref DateTime inicio, ref DateTime final, bool porFecha)
        {
            ArrayList peticiones = null;


            SqlConnection conexion = null;
            try
            {
                // Creamos y abrimos la conexión.
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();

                // Componemos la cadena de la sentencia.
                string sentencia = "select * from peticiones";
                string condiciones = ""; 

                DateTime ini = new DateTime(inicio.Year, inicio.Month, inicio.Day, 0, 0, 0);
                DateTime fin = new DateTime(final.Year, final.Month, final.Day, 23, 59, 59);




                if (mostrar == 1)
                {
                    condiciones += " where respuesta is NULL";
                }
                else
                {
                    if (mostrar == 2)
                    {
                        condiciones += " where respuesta is not NULL";
                    }
                }

                if (asunto != "")
                {
                    if (condiciones == "")
                    {
                        condiciones += " where asunto like '%" + @asunto + "%'";
                    }
                    else
                    {
                        condiciones += " and asunto like '%" + @asunto + "%'";
                    }
                }
                if (texto != "")
                {
                    if (condiciones == "")
                    {
                        condiciones += " where texto like '%" + @texto + "%'";
                    }
                    else
                    {
                        condiciones += " and texto like '%" + @texto + "%'";
                    }
                }
                if (usuario != 0)
                {
                    if (condiciones == "")
                    {
                        condiciones += " where usuario=" + @usuario;
                    }
                    else
                    {
                        condiciones += " and usuario=" + @usuario;
                    }
                }

                if (porFecha)
                {

                    if (condiciones == "")
                    {
                        condiciones += " where fecha between @fechainicio and @fechafin ";
                    }
                    else
                    {
                        condiciones += " and fecha between @fechainicio and @fechafin ";
                    }

                }

                sentencia = sentencia + condiciones;

                // Asignamos la cadena de sentencia y establecemos los parámetros.
                SqlCommand comando = new SqlCommand(sentencia, conexion);

                if (asunto != "")
                    comando.Parameters.AddWithValue("@asunto", asunto);

                if (asunto != "")
                    comando.Parameters.AddWithValue("@texto", texto);

                if (asunto != "")
                    comando.Parameters.AddWithValue("@usuario", usuario);

                if (porFecha)
                {
                    comando.Parameters.AddWithValue("@fechainicio", ini);
                    comando.Parameters.AddWithValue("@fechafin", fin);
                }

               

                // Realizamos la consulta.
                SqlDataReader dataReader = comando.ExecuteReader();

                // Insertamos todas las filas extraidas en el vector.
                peticiones = new ArrayList();
                while (dataReader.Read())
                {
                    ENPeticion peticion = obtenerDatos(dataReader);
                    peticiones.Add(peticion);
                }

                // Cerramos la consulta.
                dataReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ArrayList Peticion.Obtener() " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return peticiones;
        }*/

        public ArrayList Obtener(string asunto, string texto, int usuario, int mostrar, ref DateTime inicio, ref DateTime final, bool porFecha,string propiedadOrdenar, bool ascendente, int pagina, int cantidadPorPagina,ref int resultados)
        {
            ArrayList peticiones = new ArrayList();
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

                // Cálculamos las filas de inicio y fin a partir de la página
                int filaInicio = (pagina - 1) * cantidadPorPagina + 1;
                int filaFinal = filaInicio - 1 + cantidadPorPagina;

                // Formamos dos comandos, uno para obtener el número de resultados total sin paginación y
                // otro para obtener los materiales paginados con toda la información
                string comandoSinPaginacion = "";
                string comandoConPaginacion = "";
                string cadenaComun = "";

                comandoSinPaginacion += "SELECT count(*) as numResultados FROM peticiones";
                comandoConPaginacion += "SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY " + propiedadOrdenar;
                if (ascendente == true)
                    comandoConPaginacion += " ASC";
                else
                    comandoConPaginacion += " DESC";
                comandoConPaginacion += ") as row FROM peticiones";

                DateTime ini = inicio;
                DateTime fin = final;

                if (mostrar == 1)
                {
                    cadenaComun += " where respuesta is NULL";
                }
                else
                {
                    if (mostrar == 2)
                    {
                        cadenaComun += " where respuesta is not NULL";
                    }
                }

                if (asunto != "")
                {
                    if (cadenaComun == "")
                    {
                        cadenaComun += " where asunto like '%" + @asunto + "%'";
                    }
                    else
                    {
                        cadenaComun += " and asunto like '%" + @asunto + "%'";
                    }
                }
                if (texto != "")
                {
                    if (cadenaComun == "")
                    {
                        cadenaComun += " where texto like '%" + @texto + "%'";
                    }
                    else
                    {
                        cadenaComun += " and texto like '%" + @texto + "%'";
                    }
                }
                if (usuario != 0)
                {
                    if (cadenaComun == "")
                    {
                        cadenaComun += " where usuario=" + @usuario;
                    }
                    else
                    {
                        cadenaComun += " and usuario=" + @usuario;
                    }
                }

                if (porFecha)
                {

                    if (cadenaComun == "")
                    {
                        cadenaComun += " where fecha between @fechainicio and @fechafin ";
                    }
                    else
                    {
                        cadenaComun += " and fecha between @fechainicio and @fechafin ";
                    }

                }
                /*
                cadenaComun += "(nombre like @nombre or descripcion like @descripcion) ";
                if (busqueda.Usuario != null)
                {
                    cadenaComun += "and usuario = @usuario ";
                    comando.Parameters.AddWithValue("@usuario", busqueda.Usuario.Id);
                }
                if (busqueda.Categoria != null)
                {
                    cadenaComun += "and categoria = @categoria";
                    comando.Parameters.AddWithValue("@categoria", busqueda.Categoria.Id);
                }
                cadenaComun += " and fecha between @fechaInicio and @fechaFin";
                comando.Parameters.AddWithValue("@fechaInicio", busqueda.FechaInicio);
                comando.Parameters.AddWithValue("@fechaFin", busqueda.FechaFin);
                */
                comandoSinPaginacion += cadenaComun;
                comandoConPaginacion += cadenaComun;
                comandoConPaginacion += " ) as alias WHERE row >= @filaInicio and row <= @filaFinal";

                // Obtenemos los resultados con paginación
                comando.CommandText = comandoConPaginacion;
                if (asunto != "")
                    comando.Parameters.AddWithValue("@asunto", asunto);

                if (asunto != "")
                    comando.Parameters.AddWithValue("@texto", texto);

                if (asunto != "")
                    comando.Parameters.AddWithValue("@usuario", usuario);

                if (porFecha)
                {
                    comando.Parameters.AddWithValue("@fechainicio", ini);
                    comando.Parameters.AddWithValue("@fechafin", fin);
                }
                comando.Parameters.AddWithValue("@filaInicio", filaInicio);
                comando.Parameters.AddWithValue("@filaFinal", filaFinal);
                
                SqlDataReader reader = comando.ExecuteReader();
                // Recorremos el reader y vamos insertando en el array list
                while (reader.Read())
                {
                    ENPeticion peticion = obtenerDatos(reader);
                    peticiones.Add(peticion);
                }

                // Obtenemos los resultados sin paginación
                comando.CommandText = comandoSinPaginacion;
                reader.Close();
                reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    // Guardamos los resultados de la búsqueda
                    resultados = int.Parse(reader["numResultados"].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("<ENPeticion::Obtener> " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return peticiones;
        }

        public int ObtenerNumeroPeticiones()
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
                comando.CommandText = "SELECT count(*) numero FROM peticiones";
                

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    n = int.Parse(reader["numero"].ToString());
                }

                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Numero de peticiones: " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return n;
            
        }

        public int ObtenerNumeroPeticionesSinContestar()
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
                comando.CommandText = "SELECT count(*) numero FROM peticiones where respuesta is NULL";


                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    n = int.Parse(reader["numero"].ToString());
                }

                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Numero de peticiones: " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return n;

        }

        public string ObtenerUltimaPeticion()
        {

            string texto = "";
            SqlConnection conexion = null;
            try
            {
                // Creamos la conexion
                conexion = new SqlConnection(cadenaConexion);
                // Abrimos la conexión
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "SELECT texto FROM peticiones order by fecha";


                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    texto = reader["texto"].ToString();
                }

                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Numero de peticiones: " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return texto;

        }

    }
}
