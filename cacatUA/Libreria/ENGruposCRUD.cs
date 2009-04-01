using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Libreria
{
    public class ENGruposCRUD
    {
        private string nombre;
        private string descripcion;
        private DateTime fecha;
        private int id;
        private ArrayList usuarios;
        int numUsuarios;
        GruposCAD grupos;

        public ENGruposCRUD()
        {
            id = 0;
            nombre = "";
            descripcion = "";
            fecha = new DateTime();
            usuarios = new ArrayList();
            numUsuarios = 0;
            grupos = new GruposCAD();
        }

        public ENGruposCRUD(int id)
        {
            grupos = new GruposCAD();
            ENGruposCRUD grupo=grupos.obtenerGrupo(id);
            this.id = grupo.id;
            this.nombre = grupo.nombre;
            this.descripcion = grupo.descripcion;
            this.fecha = grupo.fecha;
            this.usuarios = grupo.usuarios;
            this.numUsuarios = grupo.numUsuarios;
            
        }

        public ENGruposCRUD(ENGruposCRUD grupo)
        {
            this.id = grupo.id;
            this.nombre = grupo.nombre;
            this.descripcion = grupo.descripcion;
            this.fecha = grupo.fecha;
            this.usuarios = grupo.usuarios;
            this.numUsuarios = grupo.numUsuarios;
        }

        public ENGruposCRUD(string nombre, string descripcion, DateTime fecha, ArrayList usuarios)
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
            grupos=new GruposCAD();
        }

        public bool crearGrupo()
        {
            return grupos.crearGrupo(nombre, descripcion, fecha, usuarios);
        }

        public void actualizarGrupo()
        {

        }

        public bool borrarGrupo()
        {
            return grupos.borrarGrupo(id);
        }

        public ArrayList obtenerGrupos()
        {
            return grupos.obtenerGrupos();
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
