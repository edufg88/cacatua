using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Libreria
{
    /// <summary>
    /// 
    /// </summary>
    class HiloCAD
    {
        private static String cadenaConexion = @"Data Source=COMPUTORO\SQLEXPRESS;Initial Catalog=cacatua;Integrated Security=True;Pooling=False";

        private static ENHiloCRUD obtenerDatos(SqlDataReader dataReader)
        {
            ENHiloCRUD hilo = new ENHiloCRUD();
            hilo.Id = int.Parse(dataReader["id"].ToString());
            hilo.Texto = dataReader["texto"].ToString();
            hilo.Titulo = dataReader["titulo"].ToString();
            hilo.Respuestas = null;
            hilo.Categoria = null;
            hilo.Fecha = DateTime.Now;
            return hilo;
        }

        public static ENHiloCRUD Obtener(int id)
        {
            ENHiloCRUD hilo = null;
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                // Abrimos la conexión.
                conexion.Open();

                // Creamos el comando.
                SqlCommand comando = new SqlCommand();

                // Le asignamos la conexión al comando.
                comando.Connection = conexion;
                comando.CommandText = "select * from hilos where id = @id";
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();

                // Si hay al menos una fila, extraemos los valores de la primera.
                if (reader.Read())
                {
                    hilo = obtenerDatos(reader);
                }
            }
            return hilo;
        }

        public static ArrayList Obtener()
        {
            ArrayList materiales = new ArrayList();
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                string cadenaComando = "select * from hilos";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                SqlDataReader dataReader = comando.ExecuteReader();
                // Insertamos todas las filas extraidas en el vector.
                while (dataReader.Read())
                {
                    ENHiloCRUD material = obtenerDatos(dataReader);
                    materiales.Add(material);
                }
            }
            return materiales;
        }

        public static ArrayList Obtener(int pagina, int cantidad)
        {
            // select * from hilos limit pagina*cantidad, cantidad;
            return null;
        }

        public static ArrayList Obtener(int pagina, int cantidad, String titulo, String texto
            /*, ENUsuarioCRUD autor*/, DateTime fechaInicio, DateTime fechaFin, ENCategoriaCRUD categoria)
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

        public static bool Guardar(ENHiloCRUD hilo)
        {
            // insert into hilos (...) values (...);
            return false;
        }

        public static bool Borrar(ENHiloCRUD hilo)
        {
            return Borrar(hilo.Id);
        }

        public static bool Borrar(int id)
        {
            // delete from hilos where id = id;
            return false;
        }

        public static bool Actualizar(ENHiloCRUD hilo)
        {
            // update hilos set tal tal tal where id = hilo.id;
            return false;
        }
    }
}
