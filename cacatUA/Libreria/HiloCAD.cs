using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Libreria
{
    /// <summary>
    /// 
    /// </summary>
    class HiloCAD
    {
        private static String conexion = @"Data Source=COMPUTORO\SQLEXPRESS;Initial Catalog=cacatua;Integrated Security=True;Pooling=False";

        public static ENHiloCRUD Obtener(int id)
        {
            // select * from hilos where id = id;
            return null;
        }

        public static ArrayList Obtener()
        {
            // select * from hilos;
            return null;
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

        public static void Guardar(ENHiloCRUD hilo)
        {
            // insert into hilos (...) values (...);
        }

        public static void Borrar(ENHiloCRUD hilo)
        {
            // delete from hilos where id = hilo.id;
        }

        public static void Borrar(int id)
        {
            // delete from hilos where id = id;
        }

        public static void Actualizar(ENHiloCRUD hilo)
        {
            // update hilos set tal tal tal where id = hilo.id;
        }
    }
}
