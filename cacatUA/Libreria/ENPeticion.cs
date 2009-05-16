using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Libreria
{
    public class ENPeticion : InterfazEN
    {
        private int id;
        private string asunto;
        private string texto;
        private string respuesta;
        private ENUsuario usuario;
        private DateTime fecha;
        private bool contestada;
        private PeticionCAD cad = new PeticionCAD();

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

        public static ArrayList ObtenerTodas()
        {
            return PeticionCAD.Instancia.ObtenerTodas();
        }

        public static ArrayList ObtenerSinContestar()
        {
            return PeticionCAD.Instancia.ObtenerSinContestar();
        }

        public static ArrayList ObtenerContestadas()
        {
            return PeticionCAD.Instancia.ObtenerContestadas();
        }

        public static ENPeticion Obtener(int id)
        {
            return PeticionCAD.Instancia.GetPeticion(id);
        }

        override public bool Actualizar()
        {
            return cad.ActualizarPeticion(this);
        }

        override public bool Guardar()
        {
            return cad.GuardarPeticion(this);
        }

        override public bool Borrar()
        {
            return cad.BorrarPeticion(this.id);
        }

        public void Responder(string respuesta)
        {
            this.respuesta = respuesta;
            this.Actualizar();

            String mensaje = "Peticion de asunto: "  + this.asunto;
            mensaje +=  " - Respuesta: " + this.respuesta;
            ENMensaje contestar = new ENMensaje(usuario.Usuario, mensaje, DateTime.Now, usuario.Usuario);
            contestar.Guardar();

        }

        public static ArrayList Obtener(string asunto, string texto, int usuario,int mostrar, ref DateTime inicio,ref DateTime final,bool porFecha,string orden,bool ascendente,int numeroDePagina,int cantidad,ref int resultados)
        {
          
            return PeticionCAD.Instancia.Obtener(asunto, texto, usuario,mostrar,ref inicio,ref final,porFecha,orden,ascendente,numeroDePagina,cantidad,ref resultados);
            
        }

        public static int ObtenerNumeroPeticiones()
        {
            return PeticionCAD.Instancia.ObtenerNumeroPeticiones();
        }

        public static int ObtenerNumeroPeticionesSinContestar()
        {
            return PeticionCAD.Instancia.ObtenerNumeroPeticionesSinContestar();
        }

        public static string ObtenerUltimaPeticion()
        {
            return PeticionCAD.Instancia.ObtenerUltimaPeticion();
        }
    }
}
