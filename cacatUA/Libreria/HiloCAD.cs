﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

namespace Libreria
{
    /// <summary>
    /// Clase singleton que realiza el acceso a la base de datos para manipular los hilos.
    /// </summary>
    sealed class HiloCAD
    {
        private static readonly HiloCAD instancia = new HiloCAD();
        private String cadenaConexion;

        /// <summary>
        /// Obtiene la única instancia de la clase HiloCAD. Si es la primera vez
        /// que se invoca el método, se crea el objeto; si no, sólo se devuelve la referencia
        /// al objeto que ya fue creado anteriormente.
        /// </summary>
        /// <returns>Devuelve una referencia a la única instancia de la clase.</returns>
        public static HiloCAD Instancia
        {
            get { return instancia; }
        }

        /// <summary>
        /// Constructor en el ámbito privado de la clase para no permitir más
        /// de una instancia.
        /// </summary>
        private HiloCAD()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["cacatua"].ConnectionString;
        }

        private ENHilo obtenerDatos(SqlDataReader dataReader)
        {
            ENHilo hilo = new ENHilo();
            hilo.Id = int.Parse(dataReader["id"].ToString());
            hilo.Texto = dataReader["texto"].ToString();
            hilo.Titulo = dataReader["titulo"].ToString();
            hilo.Respuestas = null;
            hilo.Categoria = null;
            hilo.Fecha = DateTime.Now;
            return hilo;
        }

        public ENHilo Obtener(int id)
        {
            ENHilo hilo = null;

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
                comando.CommandText = "select * from hilos where id = @id";
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader dataReader = comando.ExecuteReader();

                // Si hay al menos una fila, extraemos los valores de la primera.
                if (dataReader.Read())
                {
                    hilo = obtenerDatos(dataReader);
                }

                dataReader.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("ENHilo Obtener (ind id)");
            }
            finally
            {
                if (conexion!=null)
                    conexion.Close();
            }

            return hilo;
        }

        public ArrayList Obtener()
        {
            ArrayList materiales = new ArrayList();

            SqlConnection conexion = null;
            try
            {
                new SqlConnection(cadenaConexion);
                conexion.Open();
                string sentencia = "select * from hilos";
                SqlCommand comando = new SqlCommand(sentencia, conexion);
                SqlDataReader dataReader = comando.ExecuteReader();

                // Insertamos todas las filas extraidas en el vector.
                while (dataReader.Read())
                {
                    ENHilo material = obtenerDatos(dataReader);
                    materiales.Add(material);
                }

                dataReader.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("ArrayList Obtener ()");
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return materiales;
        }

        public ArrayList Obtener(int pagina, int cantidad, int ultimoId)
        {
            // select * from hilos limit pagina*cantidad, cantidad;
            return null;
        }

        public ArrayList Obtener(int pagina, int cantidad, int ultimoId, String titulo, String texto
            , ENUsuario autor, DateTime fechaInicio, DateTime fechaFin, ENCategoriaCRUD categoria)
        {
            // select *
            // from hilos
            // where titulo like '%titulo%'
            // and texto like '%texti%'
            // and fecha between fechaInicio at fechaFin
            // and categoria = categoria.id
            // and limit pagina*cantidad, cantidad
            return null;
        }

        public bool Guardar(ENHilo hilo)
        {
            bool insertado = false;
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                string cadenaComando = "insert into hilos (titulo, texto, autor, fechacreacion, categoria) values (@titulo, @texto, 1, '31/03/2009', 1)";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                comando.Parameters.AddWithValue("@titulo", hilo.Titulo);
                comando.Parameters.AddWithValue("@texto", hilo.Texto);
                if (comando.ExecuteNonQuery() == 1)
                    insertado = true;
            }
            return insertado;
        }

        public bool Borrar(ENHilo hilo)
        {
            return Borrar(hilo.Id);
        }

        public bool Borrar(int id)
        {
            bool borrado = false;
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                string cadenaComando = "delete from hilos where id = @id";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                comando.Parameters.AddWithValue("@id", id);
                if (comando.ExecuteNonQuery() == 1)
                    borrado = true;
            }
            return borrado;
        }

        public bool Actualizar(ENHilo hilo)
        {
            // update hilos set tal tal tal where id = hilo.id;
            return false;
        }
    }
}
