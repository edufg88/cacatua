using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Libreria
{
    public class ENGrupos : InterfazEN
    {
        private string nombre;
        private string descripcion;
        private DateTime fecha;
        private int id;
        private ArrayList usuarios;
        int numUsuarios;

        public ENGrupos()
        {
            id = 0;
            nombre = "";
            descripcion = "";
            fecha = new DateTime();
            usuarios = new ArrayList();
            numUsuarios = 0;
        }

        public ENGrupos(string nombre, string descripcion, DateTime fecha)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.fecha = fecha;
        }

        public ENGrupos(string nombre, string descripcion, DateTime fecha, ArrayList usuarios)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.fecha = fecha;
            if (usuarios.Count > 0)
            {
                this.usuarios = usuarios;
            }
            else this.usuarios=new ArrayList();
            this.numUsuarios = usuarios.Count;
        }

        override public bool Guardar()
        {
            return GruposCAD.Instancia.Guardar(this);
        }

        override public bool Actualizar()
        {
            return GruposCAD.Instancia.Actualizar(this);
        }

        override public bool Borrar()
        {
            return GruposCAD.Instancia.Borrar(this);
        }

        public static ENGrupos Obtener(int id)
        {
            return GruposCAD.Instancia.Obtener(id);
        }

        public static ArrayList Obtener()
        {
            return GruposCAD.Instancia.ObtenerTodos();
        }

        public bool BorrarMiembro(int usuario)
        {
            return GruposCAD.Instancia.BorrarUsuario(usuario,id);
        }

        public bool InsertarMiembro(int usuario)
        {
            return GruposCAD.Instancia.BorrarUsuario(usuario, id);
        }

        public ArrayList Buscar(int min, int max,DateTime fechafin,ref ENUsuario usuario)
        {
            return GruposCAD.Instancia.Buscar(min,max,this,fechafin,ref usuario);
        }

        public static int NumGrupos()
        {
            return GruposCAD.Instancia.NumGrupos();
        }

        public static ENGrupos Ultimo()
        {
            return GruposCAD.Instancia.Ultimo();
        }

        //Propiedades
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
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public ArrayList Usuarios
        {
            get { return usuarios; }
            set { usuarios = value; }
        }
        public int NumUsuarios
        {
            get { return numUsuarios; }
            set { numUsuarios = value; }
        }
    }
}
