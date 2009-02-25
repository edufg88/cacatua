using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cacatUA
{
    class Login
    {
        static public bool validarDatos(string usuario, string contraseña)
        {
            // Validamos los datos
            bool correcto = false;
            if (usuario == "cacatua" && contraseña == "123456")
                correcto = true;
            return correcto;
        }
    }
}
