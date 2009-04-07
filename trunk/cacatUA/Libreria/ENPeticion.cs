using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Libreria
{
    public class ENPeticion
    {
        private int id;
        private string asunto;
        private string texto;
        private string respuesta;
        private ENUsuario usuario;
        private DateTime fecha;
        private bool contestada;

        public ENPeticion()
        {
            id = 0;
            asunto = "";
            texto = "";
            contestada = false;
        }

        public ENPeticion(int i,string a,string t,bool c,ENUsuario u)
        {
            id = i;
            asunto = a;
            texto = t;
            contestada = c;
            usuario = u;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Asunto
        {
            get { return asunto; }
            set { asunto = value; }
        }
        public string Texto
        {
            get { return texto; }
            set { texto = value; }
        }
        public string Respuesta
        {
            get { return respuesta; }
            set { respuesta = value; }
        }
        public ENUsuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public bool Contestada
        {
            get { return contestada; }
            set { contestada = true; }
        }

        public static ArrayList GetSinContestar()
        {
            return PeticionCAD.GetSinContestar();
        }

        public static ArrayList GetContestadas()
        {
            return PeticionCAD.GetContestadas();
        }

        public static ENPeticion GetPeticion(int id)
        {
            return PeticionCAD.GetPeticion(id);
        }

        public static bool ActualizarPeticion(ENPeticion p)
        {
            return PeticionCAD.ActualizarPeticion(p);
        }

        public static void BorrarPeticion(int id)
        {
            PeticionCAD.BorrarPeticion(id);
        }

        public static ArrayList Obtener(string asunto, string texto, int usuario)
        {
            return PeticionCAD.Obtener(asunto, texto, usuario);
        }
    }
}
