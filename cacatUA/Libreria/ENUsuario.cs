using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;

namespace Libreria
{
    public class ENUsuario : InterfazEN
    {
        const int maxTamUsuario = 15;
        const int minTamUsuario = 3;
        const int minTamContrasena = 5;
        const int maxTamNombre = 15;
        const int minTamNombre = 3;
        const int maxTamAdicional = 50;
        const int minTamPregunta = 3;
        const int maxTamPregunta = 50;
        const int maxTamTextoFirma = 100;
        const int minTamTituloImagen = 3;
        const int maxTamTituloImagen = 15;
        const int maxTamDescripcionImagen = 30;

        private int id;
        private string usuario;
        private string contrasena;
        private string nombre;
        private string dni;
        private string correo;
        private string adicional;
        private DateTime fechaingreso;
        private bool activo;

        // Constructor por defecto. Crea un usuario vacío
        public ENUsuario()
        {
            id = 0;
            usuario = "";
            contrasena = "";
            nombre = "";
            dni = "";
            correo = "";
            adicional = "";
            activo = false;
            fechaingreso = DateTime.Now; // La fecha de ingreso es siempre la actual
        }

        public static ArrayList Obtener()
        {
            return UsuarioCAD.Instancia.ObtenerUsuarios();
        }

        public static ENUsuario Obtener(int id)
        {
            ENUsuario aux = null;
            aux = UsuarioCAD.Instancia.ObtenerUsuario(id);

            return aux;
        }

        public static ENUsuario Obtener(string us)
        {
            ENUsuario aux = null;
            aux = UsuarioCAD.Instancia.ObtenerUsuario(us);

            return aux;
        }

        // Constructor sobrecargado. Sólo con el id del usuario.
        /*
        public ENUsuario(int id)
        {
            ENUsuario aux = UsuarioCAD.Instancia.ObtenerUsuario(id);

            if (aux == null)
            {
                aux = new ENUsuario();
            }
            this.id = aux.id;
            this.usuario = aux.Usuario;
            this.contrasena = aux.Contrasena;
            this.nombre = aux.Nombre;
            this.dni = aux.Dni;
            this.correo = aux.Correo;
            this.activo = aux.Activo;
            this.adicional = aux.Adicional;
            this.fechaingreso = aux.Fechaingreso;
        }*/
        /*
        // Constructor sobrecargado. Sólo con el nombre de usuario.
        public ENUsuario(string usuario)
        {
            ENUsuario aux = UsuarioCAD.Instancia.ObtenerUsuario(usuario);

            if (aux == null)
            {
                aux = new ENUsuario();
            }
            this.id = aux.id;
            this.usuario = aux.Usuario;
            this.contrasena = aux.Contrasena;
            this.nombre = aux.Nombre;
            this.dni = aux.Dni;
            this.correo = aux.Correo;
            this.activo = aux.Activo;
            this.adicional = aux.Adicional;
            this.fechaingreso = aux.Fechaingreso;
        }*/

        // Constructor sobrecargado (recibe todos los datos menos el id del usuario y la fecha de ingreso)
        public ENUsuario(string usuario, string contrasena, string nombre, string dni, string correo, bool activo, string adicional)
        {
            this.usuario = usuario;
            this.contrasena = contrasena;
            this.nombre = nombre;
            this.dni = dni;
            this.correo = correo;
            this.activo = activo;
            this.adicional = adicional;
            this.fechaingreso = DateTime.Now;
        }

        // Recibe un campo y en función de éste, valida si el dato es correcto
        public static string ValidarFormulario(string campo, string dato)
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

                case "pregunta":
                    if (dato.Length > maxTamAdicional)
                    {
                        error = "El campo pregunta puede tener " + maxTamPregunta.ToString() + " caracteres como máximo";
                    }
                    else if (dato.Length < minTamPregunta)
                    {
                        error = "El campo pregunta debe tener " + minTamPregunta.ToString() + " caracteres como mínimo";
                    }
                    break;

                case "textoFirma":
                    if (dato.Length > maxTamTextoFirma)
                    {
                        error = "El campo texto puede tener " + maxTamTextoFirma.ToString() + " caracteres como máximo";
                    }
                    break;

                case "tituloImagen":
                    if (dato.Length > maxTamTituloImagen)
                    {
                        error = "El campo título puede tener " + maxTamTituloImagen.ToString() + " caracteres como máximo";                    
                    }
                    else if (dato.Length < minTamTituloImagen)
                    {
                        error = "El campo título debe tener " + minTamTituloImagen.ToString() + " caracteres como mínimo";                    
                    }
                    break;

                case "descripcionImagen":
                    if (dato.Length > maxTamDescripcionImagen)
                    {
                        error = "El campo descripción puede tener " + maxTamDescripcionImagen.ToString() + " caracteres como máximo";                    
                    }
                    break;

            }

            return (error);
        }

        /*
        public bool Obtener(int id)
        {
            ENUsuario aux = new ENUsuario();
            UsuarioCAD.Instancia.ObtenerUsuario(id);

            if (aux != null)
            {
                this.id = aux.id;
                this.usuario = aux.usuario;
                this.contrasena = aux.contrasena;
                this.nombre = aux.nombre;
                this.dni = aux.dni;
                this.correo = aux.correo;
                this.adicional = aux.adicional;
                this.fechaingreso = aux.fechaingreso;
                this.activo = aux.activo;

                return true;
            }
            else
            {
                return false;
            }
        }*/

        /*
        public bool Obtener(string nombre)
        {
            ENUsuario aux = null;
            aux = UsuarioCAD.Instancia.ObtenerUsuario(nombre);

            this.id = aux.id;
            this.usuario = aux.usuario;
            this.contrasena = aux.contrasena;
            this.nombre = aux.nombre;
            this.dni = aux.dni;
            this.correo = aux.correo;
            this.adicional = aux.adicional;
            this.fechaingreso = aux.fechaingreso;
            this.activo = aux.activo;

            if (aux == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }*/

        override public bool Actualizar()
        {
            return UsuarioCAD.Instancia.Actualizar(this);
        }

        override public bool Guardar()
        {
            return UsuarioCAD.Instancia.CrearUsuario(usuario, contrasena, nombre, dni, correo, fechaingreso, activo, adicional);
        }

        public bool GuardarAdmin()
        {
            return UsuarioCAD.Instancia.CrearAdmin(id);
        }

        override public bool Borrar()
        {
            return UsuarioCAD.Instancia.BorrarUsuario(id);
        }

        public bool BorrarAdmin()
        {
            return UsuarioCAD.Instancia.BorrarAdmin(id);
        }

        public static bool Borrar(int pid)
        {
            return UsuarioCAD.Instancia.BorrarUsuario(pid);
        }

        public void BorrarUsuarios()
        {
            UsuarioCAD.Instancia.BorrarUsuarios();
        }

        public static ArrayList Buscar(string nombreUsuario, string email, DateTime fechaIngreso)
        {
            return UsuarioCAD.Instancia.BuscarUsuario(nombreUsuario, email, fechaIngreso);
        }

        public bool EsAdministrador()
        {
            return UsuarioCAD.Instancia.EsAdministrador(this.id);
        }

        public int CantidadEncuestas()
        {
            return EncuestaCAD.Instancia.CantidadEncuestas();
        }

        public int CantidadFirmas()
        {
            return FirmaCAD.Instancia.CantidadFirmas();
        }

        public int CantidadMensajes()
        {
            return MensajeCAD.Instancia.CantidadMensajes();
        }

        public int CantidadImagenes()
        {
            return ImagenCAD.Instancia.CantidadImagenes();
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
