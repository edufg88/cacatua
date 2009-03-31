using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Libreria
{
    class PeticionCAD
    {
        public static ArrayList getSinContestar()
        {
            ArrayList a = new ArrayList();

            ENPeticionCRUD p1 = new ENPeticionCRUD(1, "categoria IB", "No existe la categoria IB", false, 2);
            a.Add(p1);
            ENPeticionCRUD p2 = new ENPeticionCRUD(2, "error material", "No funciona el material ¿?", false, 1);
            a.Add(p2);

            return a;
        }

        public static ArrayList getContestadas()
        {
            ArrayList a = new ArrayList();

            ENPeticionCRUD p1 = new ENPeticionCRUD(1, "categoria DPAA", "No existe la categoria DPAA", true, 2);
            a.Add(p1);
          

            return a;
        }
    }
}
