using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Libreria
{
    public class ENChatMensaje : InterfazEN
    {
        private int id;
        private ENUsuario usuario;
        private string mensaje;
        private DateTime fecha;
        private ChatMensajeCAD chatMensajeCAD;

        public ENChatMensaje()
        {
            id = 0;
            usuario = null;
            mensaje = "";
            fecha = DateTime.Now;
            chatMensajeCAD = new ChatMensajeCAD();
        }

        override public bool Guardar()
        {
            return chatMensajeCAD.Guardar(this);
        }

        override public bool Borrar()
        {
            return chatMensajeCAD.Borrar(this);
        }

        override public bool Actualizar()
        {
            return chatMensajeCAD.Actualizar(this);
        }

        public bool BorrarMensajesAntiguos(int maxMensajes, int conservarMensajes)
        {
            return chatMensajeCAD.BorrarMensajesAntiguos(maxMensajes, conservarMensajes);
        }

        public static ArrayList Obtener(ENChatMensaje mensaje)
        {
            ChatMensajeCAD chatMensajeCAD = new ChatMensajeCAD();
            return chatMensajeCAD.Obtener(mensaje);
        }

        public static ENChatMensaje Obtener(int id)
        {
            ChatMensajeCAD chatMensajeCAD = new ChatMensajeCAD();
            return chatMensajeCAD.Obtener(id);
        }

        public static ENChatMensaje Ultimo()
        {
            ChatMensajeCAD chatMensajeCAD = new ChatMensajeCAD();
            return chatMensajeCAD.Ultimo();
        }

        public static int NumMensajes()
        {
            ChatMensajeCAD chatMensajeCAD = new ChatMensajeCAD();
            return chatMensajeCAD.NumMensajes();
        }

        public int Id
        {
            set { id = value; }
            get { return id; }
        }

        public ENUsuario Usuario
        {
            set { usuario = value; }
            get { return usuario; }
        }

        public string Mensaje
        {
            set { mensaje = value; }
            get { return mensaje; }
        }

        public DateTime Fecha
        {
            set { fecha = value; }
            get { return fecha; }
        }

    }
}
