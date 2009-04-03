using System;
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
    class RespuestaCAD
    {
        private static RespuestaCAD instancia = null;
        private string cadenaConexion;

        /// <summary>
        /// Obtiene la única instancia de la clase RespuestaCAD. Si es la primera vez
        /// que se invoca el método, se crea el objeto; si no, sólo se devuelve la referencia
        /// al objeto que ya fue creado anteriormente.
        /// </summary>
        /// <returns>Devuelve una referencia a la única instancia de la clase.</returns>
        public static RespuestaCAD GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new RespuestaCAD();
            }
            return instancia;
        }

        /// <summary>
        /// Constructor en el ámbito privado de la clase para no permitir más
        /// de una instancia.
        /// </summary>
        private RespuestaCAD()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["cacatua"].ConnectionString;
        }
    }
}
