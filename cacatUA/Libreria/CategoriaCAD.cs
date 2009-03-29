using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Libreria
{
    public class CategoriaCAD
    {
        public static ENCategoriaCRUD obtenerCategoria(int id)
        {
            //select * from CATEGORIAS where id = @id
            return new ENCategoriaCRUD(id,"Informatica","Desc. inf.",0);
        }

        public static ArrayList obtenerCategoriasSuperiores()
        {
            //select * from CATEGORIAS where padre = null
            ArrayList categorias = new ArrayList();
            categorias.Add(new ENCategoriaCRUD(1,"Informatica","Desc. inf.",0));
            categorias.Add(new ENCategoriaCRUD(2,"Biologia","Desc. bio.",0));
            categorias.Add(new ENCategoriaCRUD(3,"Medicina","Desc. med.",0));
            return categorias;
        }

        public static ArrayList obtenerHijosDe(ENCategoriaCRUD padre)
        {
            //select * from CATEGORIAS where padre = padre.id
            ArrayList hijos = new ArrayList();
            if (padre.Id == 1 || padre.Id == 2 || padre.Id == 3)
            {
                hijos.Add(new ENCategoriaCRUD(4, "Primero", "Primer curso", 1));
                hijos.Add(new ENCategoriaCRUD(4, "Segundo", "Segundo curso", 1));
                hijos.Add(new ENCategoriaCRUD(4, "Tercero", "Tercer curso", 1));
            }
            return hijos;
        }

        public static ArrayList usuariosSuscritosA(ENCategoriaCRUD categoria)
        {
            //select usuario from SUSCRITOACATEGORIA where categoria = categoria.id
            ArrayList usuarios = new ArrayList();
            usuarios.Add("Jorge");
            usuarios.Add("Antonio");
            usuarios.Add("Juan");
            return usuarios;
        }

        public static int NumHilosEn(ENCategoriaCRUD categoria)
        {
            //select count(*) from HILOS where categoria = categoria.id
            return 4;
        }

        public static int NumMaterialesEn(ENCategoriaCRUD categoria)
        {
            //select count(*) from MATERIALES where categoria = categoria.id
            return 2;
        }
    }
}
