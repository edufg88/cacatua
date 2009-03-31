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


        public ENGruposCRUD()
        {
        }

        public ENGruposCRUD(int id, string nombre, string descripcion, DateTime fecha, ArrayList usuarios)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.fecha = fecha;
            this.usuarios = usuarios;
            this.numUsuarios = 0;
        }

        public void crearGrupo()
        {

        }

        public void actualizarGrupo()
        {

        }

        public void borrarGrupo()
        {

        }

        public void obtenerGrupos()
        {

        }

        /*public int NumUsuarios()
        {
        }*/


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
