using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Libreria
{
    public class ENMaterialCRUD
    {
        // Dispone de un materialCAD para acceder a los datos
        private int id;
        private string nombre;
        private string descripcion;

        public int Id
        {
            get {return id;}
            set { id = value; }
        }

        public string Nombre
        {
            get {return nombre;}
            set { nombre = value; }
        }

        public string Descripcion
        {
            get {return descripcion;}
            set { descripcion = value; }
        }

        public ENMaterialCRUD()
        {
            //materialCAD = new MaterialCAD();
        }

        public static ArrayList obtenerMateriales()
        {
            // Obtenemos del CAD todos los materiales
            return MaterialCAD.obtenerMateriales();
        }

        public void crearMaterial()
        {
            MaterialCAD.crearMaterial(nombre,descripcion);
        }

    }
}
