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

        private static ENUsuarioCRUD ObtenerDatos(SqlDataReader dr)
        {
            ENUsuarioCRUD usuario = new ENUsuarioCRUD();

            // Aquí el código

            return (usuario);
        }
    }

}
