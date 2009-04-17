using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;

namespace Libreria
{
    /// <summary>
    /// Clase que representa la entidad Usuario
    /// </summary>
    public class ENUsuario : InterfazEN
    {
        // Constantes de tamaño para los distintos campos del formulario
        const int maxTamUsuario = 15;
        const int minTamUsuario = 3;
        const int minTamContrasena = 5;
        const int maxTamNombre = 15;
        const int minTamNombre = 3;
        const int maxTamAdicional = 200;
        const int minTamPregunta = 3;
        const int maxTamPregunta = 50;
        const int maxTamTextoFirma = 1000;
        const int minTamTituloImagen = 3;
        const int maxTamTituloImagen = 20;
        const int maxTamDescripcionImagen = 50;

        /// <summary>
        /// Id del usuario
        /// </summary>
        private int id;
        /// <summary>
        /// Nombre de usuario
        /// </summary>
        private string usuario;
        /// <summary>
        /// Contraseña del usuario
        /// </summary>
        private string contrasena;
        /// <summary>
        /// Nombre de pila del usuario
        /// </summary>
        private string nombre;
        /// <summary>
        /// DNI del usuario
        /// </summary>
        private string dni;
        /// <summary>
        /// Email del usuario
        /// </summary>
        private string correo;
        /// <summary>
        /// Información adiciional del usuario
        /// </summary>
        private string adicional;
        /// <summary>
        /// Fecha de ingreso del usuario
        /// </summary>
        private DateTime fechaingreso;
        /// <summary>
        /// Indica si el usuario está activo o no
        /// </summary>
        private bool activo;

        /// <summary>
        /// Constructor por defecto de la clase. Crea un usuario vacío
        /// </summary>
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
            fechaingreso = DateTime.Now; 
        }

        /// <summary>
        /// Obtiene los usuario de la BD
        /// </summary>
        /// <returns>Devuelve un ArrayList con el resultado</returns>
        public static ArrayList Obtener()
        {
            return UsuarioCAD.Instancia.ObtenerUsuarios();
        }

        /// <summary>
        /// Obtiene un usuario a partir de su id
        /// </summary>
        /// <param name="id">Recibe el id del usuario</param>
        /// <returns>Devuelve el usuario con el id recibido</returns>
        public static ENUsuario Obtener(int id)
        {
            ENUsuario aux = null;
            aux = UsuarioCAD.Instancia.ObtenerUsuario(id);

            return aux;
        }

        /// <summary>
        /// Obtiene un usuario a partir de su nombre de usuario
        /// </summary>
        /// <param name="us">Recibe el nombre de usuario del usuario en cuestión</param>
        /// <returns>Devuelve el usuario con el nombre de usuario recibido</returns>
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

        
        /// <summary>
        /// Constructor sobrecargado
        /// </summary>
        /// <param name="usuario">Nombre de usuario</param>
        /// <param name="contrasena">Contraseña</param>
        /// <param name="nombre">Nombre de pila</param>
        /// <param name="dni">DNI</param>
        /// <param name="correo">Email</param>
        /// <param name="activo">Indica si el usuario está activo o no</param>
        /// <param name="adicional">Información adicional</param>
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

        /// <summary>
        /// Valida individualmente cada uno de los campos de los formularios relacionados con el usuario
        /// </summary>
        /// <param name="campo">Indica que campo se valida</param>
        /// <param name="dato">Dato en cuestión a validar</param>
        /// <returns>Devuelve un string con el error generado</returns>
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

        /// <summary>
        /// Actualiza la BD con el usuario actual
        /// </summary>
        /// <returns>Devuelve true si la operación se ha realizado correctamente, false en caso contrario</returns>
        override public bool Actualizar()
        {
            return UsuarioCAD.Instancia.Actualizar(this);
        }

        /// <summary>
        /// Inserta en la BD el usuario actual
        /// </summary>
        /// <returns></returns>
        override public bool Guardar()
        {
            return UsuarioCAD.Instancia.CrearUsuario(usuario, contrasena, nombre, dni, correo, fechaingreso, activo, adicional);
        }

        /// <summary>
        /// Inserta en la tabla 'administradores' el usuario actual
        /// </summary>
        /// <returns>Devuelve true si la operación se ha realizado correctamente, false en caso contrario</returns>
        public bool GuardarAdmin()
        {
            return UsuarioCAD.Instancia.CrearAdmin(id);
        }

        /// <summary>
        /// Borra de la BD el usuario actual
        /// </summary>
        /// <returns>Devuelve true si la operación se ha realizado correctamente, false en caso contrario</returns>
        override public bool Borrar()
        {
            return UsuarioCAD.Instancia.BorrarUsuario(id);
        }

        /// <summary>
        /// Borra el usuario actual de la tabla 'administradores'
        /// </summary>
        /// <returns>Devuelve true si la operación se ha realizado correctamente, false en caso contrario</returns>
        public bool BorrarAdmin()
        {
            return UsuarioCAD.Instancia.BorrarAdmin(id);
        }

        /// <summary>
        /// Borra de la BD un usuario con determinado id
        /// </summary>
        /// <param name="pid">Recibe el id del usuario a borrar</param>
        /// <returns>Devuelve true si la operación se ha realizado correctamente, false en caso contrario</returns>
        public static bool Borrar(int pid)
        {
            return UsuarioCAD.Instancia.BorrarUsuario(pid);
        }

        /// <summary>
        /// Borra todos los usuarios de la BD
        /// </summary>
        public void BorrarUsuarios()
        {
            UsuarioCAD.Instancia.BorrarUsuarios();
        }

        /// <summary>
        /// Busca un determinado usuario en la BD
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario</param>
        /// <param name="email">Email</param>
        /// <param name="fechaIngreso">Fecha de ingreso</param>
        /// <returns>Devuelve un ArrayList con el resultado de la búsqueda</returns>
        public static ArrayList Buscar(string nombreUsuario, string email, DateTime fechaIngreso)
        {
            return UsuarioCAD.Instancia.BuscarUsuario(nombreUsuario, email, fechaIngreso);
        }

        /// <summary>
        /// Indica si el usuario actual es administrador o no
        /// </summary>
        /// <returns>Devuelve true si es administrador, false en caso contrario</returns>
        public bool EsAdministrador()
        {
            return UsuarioCAD.Instancia.EsAdministrador(this.id);
        }

        /// <summary>
        /// Comprueba cuántos usuarios (administradores o no, activos o inactivos) hay en la base de datos.
        /// </summary>
        /// <returns>Devuelve la cantidad de usuarios totales que hay en la base de datos.</returns>
        public static int NumUsuarios()
        {
            return UsuarioCAD.Instancia.NumUsuarios();
        }

        /// <summary>
        /// Obtiene el último usuario insertado en la base de datos.
        /// </summary>
        /// <returns>Devuelve la entidad de negocio del último usuario registrado en la base de datos.</returns>
        public static ENUsuario Ultimo()
        {
            return UsuarioCAD.Instancia.Ultimo();
        }

        /// <summary>
        /// Devuelve el número de encuestas del usuario actual
        /// </summary>
        /// <returns>Devuelve el número de encustas</returns>
        public int CantidadEncuestas()
        {
            return EncuestaCAD.Instancia.CantidadEncuestas(this.id);
        }

        /// <summary>
        /// Devuelve el número de firmas del usuario actual
        /// </summary>
        /// <returns>Devuelve el número de firmas</returns>
        public int CantidadFirmas()
        {
            return FirmaCAD.Instancia.CantidadFirmas(this.id);
        }

        /// <summary>
        /// Devuelve el número de mensajes del usuario actual
        /// </summary>
        /// <returns>Devuelve el número de mensajes</returns>
        public int CantidadMensajes()
        {
            return MensajeCAD.Instancia.CantidadMensajes(this.id);
        }

        /// <summary>
        /// Devuelve el número de imágenes del usuario actual
        /// </summary>
        /// <returns>Devuelve el número de imágenes</returns>
        public int CantidadImagenes()
        {
            return ImagenCAD.Instancia.CantidadImagenes(this.id);
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
