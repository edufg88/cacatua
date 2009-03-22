using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Libreria
{
    public class ENMaterialCRUD
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
        private string usuario;
        private string categoria;
        private string archivo;
        private int tamaño;
        private int descargas;
        private string idioma;
        private int valoracion;
        private int votos;
        private string referencia;

        public ENMaterialCRUD()
        {
            // Inicializamos
            id = 0;
            nombre = "";
            descripcion = "";
            usuario = "";
            categoria = "";
            archivo = "";
            tamaño = 0;
            descargas = 0;
            idioma = "";
            valoracion = 0;
            votos = 0;
            referencia = "";
            //materialCAD = new MaterialCAD();
        }

        public string validarDato(string dato)
        {
            string error = "OK";
            switch (dato)
            {
                case "nombre":
                    {
                        if (nombre == "")
                            error = msj_blanco;
                        else
                        {
                            if (nombre.Length > maxTamNombre || nombre.Length < minTamNombre)
                                error = "Debe tener entre " + minTamNombre + " y " + maxTamNombre + " caracteres";
                        }
                        break;
                    }
                case "usuario":
                    {
                        if (usuario == "")
                            error = msj_blanco;
                        else
                        {
                            if (usuario.Length > maxTamUsuario || usuario.Length < minTamUsuario)
                                error = "Debe tener entre " + minTamUsuario + " y " + maxTamUsuario + " caracteres";
                            else
                            {
                                // Comprobamos si el usuario existe en la base de datos
                                bool existe = MaterialCAD.existeUsuario(usuario);
                                if(existe == false)
                                    error = "El usuario " + usuario + " no está registrado";
                            }
                        }
                        break;
                    }
                case "categoria":
                    {
                        if (categoria == "")
                            error = msj_blanco;
                        else
                        {
                            if (categoria.Length > maxTamCategoria || categoria.Length < minTamCategoria)
                                error = "Debe tener entre " + minTamCategoria + " y " + maxTamCategoria + " caracteres";
                        }
                        break;
                    }
                case "archivo":
                    {
                        if (archivo == "")
                            error = msj_blanco;
                        else
                        {
                            if (archivo.Length > maxTamArchivo || archivo.Length < minTamArchivo)
                                error = "Debe tener entre " + minTamArchivo + " y " + maxTamArchivo + " caracteres";
                        }
                        break;
                    }
            }
            return error;
        }

        public static ArrayList obtenerMateriales()
        {
            // Obtenemos del CAD todos los materiales
            return MaterialCAD.obtenerMateriales();
        }

        public void crearMaterial()
        {
            MaterialCAD.crearMaterial(nombre,descripcion,usuario,categoria,archivo,tamaño,idioma,referencia);
        }

        public bool borrarMaterial()
        {
            return MaterialCAD.borrarMaterial(id);
        }

        public static bool borrarMaterial(int id)
        {
            return MaterialCAD.borrarMaterial(id);
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

        public string Usuario
        {
            get { return usuario; }
            set
            {
                usuario = value;
            }
        }

        public string Categoria
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

        public string Idioma
        {
            get { return idioma; }
            set { idioma = value; }
        }

        public int Valoracion
        {
            get { return valoracion; }
            set { valoracion = value; }
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
    }
}
