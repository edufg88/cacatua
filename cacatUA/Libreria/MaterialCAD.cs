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
    public class MaterialCAD
    {
        static string cadenaConexion = "Data Source=PORTATIL\\SQLEXPRESS;Initial Catalog=cacatuaDB;Integrated Security=True;Pooling=False";
        public MaterialCAD()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open();
            Console.WriteLine(conexion.State.ToString());
            /*
            // Insertamos un usuario
            string cadenaComando = "INSERT INTO Materiales(id,nombre,descripcion) VALUES ('2','jose','hola')";
            SqlCommand comando = new SqlCommand(cadenaComando, conexion);
            comando.ExecuteNonQuery();
            */
            conexion.Close();
        }

        public static ArrayList obtenerMateriales()
        {
            ArrayList materiales = new ArrayList(); 
            
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open();     
            
            string cadenaComando = "SELECT * FROM Materiales";
            SqlCommand comando = new SqlCommand(cadenaComando, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            // Recorremos el reader y vamos insertando en el array list objetos del tipo ENMaterialCRUD
            while(reader.Read())
            {
                int id = int.Parse(reader["id"].ToString());
                string nombre = reader["nombre"].ToString();
                string descripcion = reader["descripcion"].ToString();
                // Creamos el material
                ENMaterialCRUD material = new ENMaterialCRUD();
                material.Id = id;
                material.Nombre = nombre;
                material.Descripcion = descripcion;
                materiales.Add(material);
            }
            conexion.Close();
            return materiales;
        }

        public static void crearMaterial(string nombre, string descripcion)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open();
            //string cadenaComando = string.Format("INSERT INTO Materiales(id,nombre,descripcion) VALUES ('6',{0},{1}",nombre,descripcion);
            //string cadenaComando = "INSERT INTO Materiales(id,nombre,descripcion) VALUES ('2','as','lol')";

            SqlCommand comando = new SqlCommand();
            comando.CommandText = "INSERT INTO Materiales(id,nombre,descripcion) " +
              "VALUES ('2', @nombre, @descripcion)";

            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@descripcion", descripcion);

            comando.Connection = conexion;
            
            comando.ExecuteNonQuery();
            
            /*
            comando.Parameters["@Date"].Value = DateTime.Now.ToString();
            comando.Parameters.Add("@From", SqlDbType.NVarChar);
            myCmd.Parameters["@From"].Value = msgFrom.Value;
            myCmd.Parameters.Add("@Mail", SqlDbType.NVarChar);
            myCmd.Parameters["@Mail"].Value = msgEmail.Value;
           */
          
            conexion.Close();
        }
    }
}
