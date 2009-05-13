using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Libreria;

namespace Libreria
{
    public class ENChatConectado : InterfazEN
    {
        private ENUsuario usuario;
        private DateTime fecha;
        private ChatConectadoCAD chatConectadoCAD;

        public ENChatConectado()
        {
            usuario = null;
            fecha = DateTime.Now;
            chatConectadoCAD = new ChatConectadoCAD();
        }

        override public bool Guardar()
        {
            return chatConectadoCAD.Guardar(this);
        }

        override public bool Borrar()
        {
            return chatConectadoCAD.Borrar(this);
        }

        override public bool Actualizar()
        {
            return chatConectadoCAD.Actualizar(this);
        }

        public static int NumConectados()
        {
            ChatConectadoCAD chatConectadoCAD = new ChatConectadoCAD();
            return chatConectadoCAD.NumConectados();
        }

        public static ArrayList Obtener()
        {
            ChatConectadoCAD chatConectadoCAD = new ChatConectadoCAD();
            return chatConectadoCAD.Obtener();
        }

        public static void BorrarDesconectados()
        {
            ChatConectadoCAD chatConectadoCAD = new ChatConectadoCAD();
            chatConectadoCAD.BorrarDesconectados();
        }

        public ENUsuario Usuario
        {
            set { usuario = value; }
            get { return usuario; }
        }

        public DateTime Fecha
        {
            set { fecha = value; }
            get { return fecha; }
        }
    }
}
