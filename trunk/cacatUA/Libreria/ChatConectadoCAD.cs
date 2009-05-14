using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

namespace Libreria
{
    public class ChatConectadoCAD
    {
        private String cadenaConexion;

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public ChatConectadoCAD()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["cacatua"].ConnectionString;
        }

        private void escribir(string cadena)
        {
            const string fic = @"C:\log.txt";
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fic, true);
            sw.WriteLine(cadena);
            sw.Close();
        }

        public bool Guardar(ENChatConectado conectado)
        {
            bool correcto = false;
            SqlConnection conexion = null;
            try
            {
                // Creamos y abrimos la conexión.
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();

                // Creamos el comando.
                SqlCommand comando = new SqlCommand();

                // Le asignamos la conexión al comando.
                comando.Connection = conexion;
                comando.CommandText = "INSERT INTO conectados(usuario) VALUES (@usuario)";
                comando.Parameters.AddWithValue("@usuario", conectado.Usuario.Id);

                if (comando.ExecuteNonQuery() == 1)
                    correcto = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("<ChatCAD::GuardarConectado> " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return correcto;
        }

        public bool Actualizar(ENChatConectado conectado)
        {
            bool correcto = false;
            SqlConnection conexion = null;
            try
            {
                // Creamos y abrimos la conexión.
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();

                // Creamos el comando.
                SqlCommand comando = new SqlCommand();

                // Le asignamos la conexión al comando.
                comando.Connection = conexion;
                comando.CommandText = "UPDATE conectados SET fecha = GETDATE() WHERE usuario = @usuario";
                comando.Parameters.AddWithValue("@usuario", conectado.Usuario.Id);

                if (comando.ExecuteNonQuery() == 1)
                {
                    correcto = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("<ChatCAD::ActualizarConectado> " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return correcto;
        }

        public bool Borrar(ENChatConectado conectado)
        {
            bool correcto = false;
            SqlConnection conexion = null;
            try
            {
                // Creamos y abrimos la conexión.
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();

                // Creamos el comando.
                SqlCommand comando = new SqlCommand();

                // Le asignamos la conexión al comando.
                comando.Connection = conexion;
                comando.CommandText = "DELETE FROM conectados WHERE usuario = @usuario)";
                comando.Parameters.AddWithValue("@usuario", conectado.Usuario.Id);

                if (comando.ExecuteNonQuery() == 1)
                    correcto = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("<ChatCAD::BorrarConectado> " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return correcto;
        }

        public int NumConectados()
        {
            int numConectados = 0;
            SqlConnection conexion = null;
            try
            {
                // Creamos y abrimos la conexión.
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();

                // Creamos el comando.
                SqlCommand comando = new SqlCommand();

                // Le asignamos la conexión al comando.
                comando.Connection = conexion;
                comando.CommandText = "SELECT COUNT(*) as numConectados FROM conectados";

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                    numConectados = int.Parse(reader["numConectados"].ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("<ChatCAD::NumConectados> " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
            return numConectados;
        }

        public ArrayList Obtener()
        {
            ArrayList conectados = new ArrayList();
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

                string cadenaComando = "SELECT * FROM conectados";
                comando.CommandText = cadenaComando;

                SqlDataReader reader = comando.ExecuteReader();
                // Recorremos el reader y vamos insertando en el array list
                while (reader.Read())
                {
                    ENChatConectado conectado = ObtenerDatos(reader);
                    conectados.Add(conectado);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("<ChatCAD::Obtener> " + ex.Message);
            }
            finally
            {
                BorrarDesconectados();
                if (conexion != null)
                    conexion.Close();
            }
            return conectados;
        }

        public ENChatConectado ObtenerDatos(SqlDataReader reader)
        {
            ENChatConectado conectado = new ENChatConectado();
            try
            {
                conectado.Usuario = ENUsuario.Obtener(int.Parse(reader["usuario"].ToString()));
                conectado.Fecha = (DateTime)reader["fecha"];
            }
            catch (Exception e)
            {
                Console.WriteLine("<ENChat::ObtenerDatosConectado> " + e.Message);
                conectado = null;
            }
            return conectado;
        }

        public void BorrarDesconectados()
        {
            SqlConnection conexion = null;
            try
            {
                // Creamos y abrimos la conexión.
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();

                // Creamos el comando.
                SqlCommand comando = new SqlCommand();

                // Le asignamos la conexión al comando.
                comando.Connection = conexion;
                comando.CommandText = "DELETE FROM conectados where DATEDIFF(ss, fecha, GETDATE()) > 10;";

                int cantidadBorrados = comando.ExecuteNonQuery();
                escribir("cantidad borrados: " + cantidadBorrados);
            }
            catch (Exception ex)
            {
                Console.WriteLine("<ChatCAD::BorrarDesconectados> " + ex.Message);
            }
            finally
            {
                escribir("acabo de borrar");
                if (conexion != null)
                    conexion.Close();
            }
        }
    }
}
