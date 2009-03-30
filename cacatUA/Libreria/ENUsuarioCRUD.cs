using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;

namespace Libreria
{
    public class ENUsuarioCRUD
    {
        const int maxTamUsuario = 15;
        const int minTamUsuario = 5;
        //const int maxTamContrasena = 15;
        const int minTamContrasena = 5;
        const int maxTamNombre = 15;
        const int minTamNombre = 5;
        //const int maxTamCorreo = 20;
        //const int minTamCorreo =5;
        const int maxTamAdicional = 50;
        //const int minTamAdicional = 5;

        private int id;
        private string usuario;
        private string contrasena;
        private string nombre;
        private string dni;
        private string correo;
        private string adicional;
        private DateTime fechaingreso;
        private bool activo;

        public ENUsuarioCRUD()
        {
            id = 0;
            usuario = "";
            contrasena = "";
            nombre = "";
            dni = "";
            correo = "";
            adicional = "";
            activo = false;
        }

        public string ValidarFormulario(string campo, string dato)
        {
            string error = "";
            const string campoEnBlanco1 = "El campo ";
            const string campoEnBlanco2 = " no puede dejarse en blanco.";

            switch(campo)
            {
                case "usuario":
                    if (dato == "")
                    {
                        error = campoEnBlanco1 + "campo" + campoEnBlanco2;
                    }
                    else
                    {
                        if (dato.Length < minTamUsuario)
                        {
                            error = "El usuario debe tener " + minTamUsuario.ToString() + " caracteres como mínimo";
                        }
                        else if (dato.Length > maxTamUsuario)
                        {
                            error = "El usuario puede tener " + maxTamUsuario.ToString() + " caracteres como máximo";
                        }
                    }
                    break;

                case "contrasena":
                    if (dato == "")
                    {
                        error = campoEnBlanco1 + "campo" + campoEnBlanco2;
                    }
                    else 
                    {
                        if (dato.Length < minTamContrasena)
                        {
                            error = "La contraseña debe tener " + minTamContrasena.ToString() + " caracteres como mínimo"; 
                        }
                    }
                    break;

                case "nombre":
                    if (dato == "")
                    {
                        error = campoEnBlanco1 + "campo" + campoEnBlanco2;
                    }
                    else
                    {
                        if (dato.Length < minTamNombre)
                        {
                            error = "El nombre debe tener " + minTamNombre.ToString() + " caracteres como mínimo";
                        }
                        else if (dato.Length > maxTamNombre)
                        {
                            error = "El nombre puede tener " + maxTamNombre.ToString() + " caracteres como máximo";
                        }
                    }
                    break;

                case "dni":
                    if (dato == "")
                    {
                        error = campoEnBlanco1 + "campo" + campoEnBlanco2;
                    }
                    else
                    {
                        // Creamos una expresión regular para validar el DNI
                        Regex er = new Regex(@"^\d{8}[a-zA-Z]$");

                        if (!er.IsMatch(dato))
                        {
                            error = "El formato del DNI es incorrecto";
                        }
                    }
                    break;

                case "correo":
                    if (dato == "")
                    {
                        error = campoEnBlanco1 + "campo" + campoEnBlanco2;
                    }
                    else
                    {
                        // Creamos una expresión regular para validar el correo
                        Regex er = new Regex(@"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");

                        if (!er.IsMatch(dato))
                        {
                            error = "El formato del email es incorrecto";
                        }
                    }
                   
                    break;

                case "adicional":
                    // En principio permitimos que el campo se deje en blanco
                    if (dato.Length > maxTamAdicional)
                    {
                        error = "El campo adicional puede tener " + maxTamAdicional.ToString() + " caracteres como máximo";
                    }
                    break;
            }

            return (error);
        }

        public static ArrayList ObtenerUsuarios()
        {
            return UsuarioCAD.ObtenerUsuarios();
        }

        public void CrearUsuario()
        {
            UsuarioCAD.CrearUsuario(usuario, contrasena, nombre, dni, correo, activo, adicional);
        }

        public bool BorrarUsuario()
        {
            return UsuarioCAD.BorrarUsuario(id);
        }

        public static bool BorrarUsuario(int pid)
        {
            return UsuarioCAD.BorrarUsuario(pid);
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        public string Contrasena
        {
            get { return contrasena; }
            set { contrasena = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Dni
        {
            get { return dni; }
            set { dni = value; }
        }
        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }
        public string Adicional
        {
            get { return adicional; }
            set { adicional = value; }
        }
        public DateTime Fechaingreso
        {
            get { return fechaingreso; }
            set { fechaingreso = value; }
        }
        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }
    }
}
