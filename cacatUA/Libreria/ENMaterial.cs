using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Libreria;

namespace Libreria 
{
    public class ENMaterial : InterfazEN
    {
        const int maxTamNombre = 30;
        const int minTamNombre = 5;
        const int maxTamUsuario = 15;
        const int minTamUsuario = 4;
        const int maxTamCategoria = 100;
        const int minTamCategoria = 5;
        const int maxTamArchivo = 100;
        const int minTamArchivo = 5;

        const string msj_blanco = "Este campo no puede dejarse en blanco";

        private int id;
        private string nombre;
        private string descripcion;
        private DateTime fecha;
        private ENUsuario usuario;
        private ENCategoria categoria;
        private string archivo;
        private int tamaño;
        private int descargas;
        private int puntuacion;
        private int votos;
        private string referencia;
        private int numComentarios;

        /// <summary>
        /// Constructor por defecto. Crea un material vacío.
        /// </summary>
        public ENMaterial()
        {
            // Inicializamos
            id = 0;
            nombre = "";
            descripcion = "";
            usuario = null;
            categoria = null;
            archivo = "";
            tamaño = 0;
            descargas = 0;
            puntuacion = 0;
            votos = 0;
            referencia = "";
            numComentarios = 0;
        }

        public static string validarDatos(ENMaterial material, string dato)
        {
            string error = "OK";
            switch (dato)
            {
                case "nombre":
                    {
                        if (material.Nombre == "")
                            error = msj_blanco;
                        else
                        {
                            if (material.Nombre.Length > maxTamNombre || material.Nombre.Length < minTamNombre)
                                error = "Debe tener entre " + minTamNombre + " y " + maxTamNombre + " caracteres";
                        }
                        break;
                    }
                case "usuario":
                    {
                        if (material.Usuario == null)
                            error = "El usuario no está registrado";
                        break;
                    }
                case "categoria":
                    {
                        if (material.Categoria == null)
                            error = "Categoría no válida";
                        break;
                    }
                case "archivo":
                    {
                        if (material.Archivo == "")
                            error = msj_blanco;
                        else
                        {
                            if (material.Archivo.Length > maxTamArchivo || material.Archivo.Length < minTamArchivo)
                                error = "Debe tener entre " + minTamArchivo + " y " + maxTamArchivo + " caracteres";
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return error;
        }

        public static ENMaterial Obtener(int id)
        {
            return MaterialCAD.Instancia.Obtener(id);
        }

        override public bool Guardar()
        {
            return MaterialCAD.Instancia.Guardar(this);
        }

        public int CompletarGuardar()
        {
            return MaterialCAD.Instancia.CompletarGuardar();
        }

        public bool CancelarGuardar()
        {
            return MaterialCAD.Instancia.CancelarGuardar();
        }

        override public bool Borrar()
        {
            return true;
            //return HiloCAD.Instancia.Borrar(this);
        }

        public static bool Borrar(int id)
        {
            return true;
            //return HiloCAD.Instancia.Borrar(id);
        }

        override public bool Actualizar()
        {
            return MaterialCAD.Instancia.Actualizar(this);
        }

        public static ArrayList Obtener()
        {
            // Obtenemos del CAD todos los materiales
            return MaterialCAD.Instancia.Obtener();
        }

        public ArrayList ObtenerComentarios()
        {
            // Obtenemos del CAD todos los comentarios del material
            return MaterialCAD.Instancia.ObtenerComentarios(this);
        }

        public static ComentarioMaterial ObtenerComentario(int id)
        {
            return MaterialCAD.Instancia.ObtenerComentario(id);
        }

        public static ArrayList Obtener(string filtroBusqueda, ENUsuario usuario, ENCategoria categoria, DateTime fechaInicio, DateTime fechaFin)
        {
            return MaterialCAD.Instancia.Obtener(filtroBusqueda, usuario, categoria, fechaInicio, fechaFin);
        }

        public bool GuardarComentario(ComentarioMaterial comentario)
        {
            return MaterialCAD.Instancia.GuardarComentario(comentario);
        }

        public bool ActualizarComentario(ComentarioMaterial comentario)
        {
            return MaterialCAD.Instancia.ActualizarComentario(comentario);
        }

        public static bool BorrarComentario(ComentarioMaterial comentario)
        {
            return MaterialCAD.Instancia.BorrarComentario(comentario);
        }

        public bool borrarMaterial()
        {
            return MaterialCAD.Instancia.Borrar(id);
        }

        public static bool borrarMaterial(int id)
        {
            return MaterialCAD.Instancia.Borrar(id);
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public ENUsuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public ENCategoria Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        public string Archivo
        {
            get { return archivo; }
            set { archivo = value; }
        }

        public int Tamaño
        {
            get { return tamaño; }
            set { tamaño = value; }
        }

        public int Descargas
        {
            get { return descargas; }
            set { descargas = value; }
        }

        public int Puntuacion
        {
            get { return puntuacion; }
            set { puntuacion = value; }
        }

        public int Votos
        {
            get { return votos; }
            set { votos = value; }
        }

        public string Referencia
        {
            get { return referencia; }
            set { referencia = value; }
        }

        public int NumComentarios
        {
            get { return numComentarios; }
            set { numComentarios = value; }
        }
    }

    public class ComentarioMaterial
    {
        private int id;
        private string texto;
        private DateTime fecha;
        private ENUsuario usuario;
        private ENMaterial material;

        static int minTamTexto = 1;
        static int maxTamTexto = 1000;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Texto
        {
            get { return texto; }
            set { texto = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public ENUsuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public ENMaterial Material
        {
            get { return material; }
            set { material = value; }
        }

        public static string Validar(ComentarioMaterial comentario, string propiedad)
        {
            string error = "OK";
            switch (propiedad)
            {
                case "texto":
                    {
                        if (comentario.Texto.Length < minTamTexto || comentario.Texto.Length > maxTamTexto)
                            error = "El texto debe tener una longitud entre " + minTamTexto + " y " + maxTamTexto;
                        break;
                    }
                case "usuario":
                    {
                        if (comentario.Usuario == null)
                            error = "Usuario no válido";
                        break;
                    }
                case "material":
                    {
                        if (comentario.Material == null)
                            error = "Material no válido";
                        break;
                    }
            }
            return error;
        }
    }
}
