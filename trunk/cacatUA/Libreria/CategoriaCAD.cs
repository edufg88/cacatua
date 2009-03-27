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
            return new ENCategoriaCRUD(id,"Informatica","Desc. inf.",0);
        }

        public static ArrayList obtenerCategoriasSuperiores()
        {
            ArrayList categorias = new ArrayList();
            categorias.Add(new ENCategoriaCRUD(1,"Informatica","Desc. inf.",0));
            categorias.Add(new ENCategoriaCRUD(2,"Biologia","Desc. bio.",0));
            categorias.Add(new ENCategoriaCRUD(3,"Medicina","Desc. med.",0));
            return categorias;
        }

        public static ArrayList obtenerHijosDe(ENCategoriaCRUD padre)
        {
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
            return new ArrayList();
        }

        public static int NumHilosEn(ENCategoriaCRUD categoria)
        {
            return 4;
        }

        public static int NumMaterialesEn(ENCategoriaCRUD categoria)
        {
            return 2;
        }
    }
}
