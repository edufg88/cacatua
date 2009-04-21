using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Libreria;

namespace cacatUA
{
    class Login
    {
        static public bool validarDatos(string usuario, string contraseña)
        {
            // Validamos los datos
            bool correcto = false;
            ENUsuario enusuario = ENUsuario.Obtener(usuario);
            if (enusuario != null)
            {
                //if (usuario.Contrasena == sha1(contraseña))
                if (enusuario.Contrasena == contraseña)
                {
                    if (enusuario.EsAdministrador())
                        correcto = true;
                }
            }
            return correcto;
        }
    }
}
