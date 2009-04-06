﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Libreria
{
    public class ENFirma : InterfazEN
    {
        private int id;
        private ENUsuario emisor;
        private string texto;
        private DateTime fecha;
        private ENUsuario receptor;

        public ENFirma()
        {
            id = 0;
            emisor = new ENUsuario();
            receptor = new ENUsuario();
            fecha = DateTime.Now;
            texto = "";
        }

        public ENFirma(int id)
        {
            ENFirma aux = FirmaCAD.Instancia.ObtenerFirma(id);

            if (aux == null)
            {
                aux = new ENFirma();
            }

            this.id = aux.id;
            this.emisor = aux.emisor;
            this.texto = aux.texto;
            this.fecha = aux.fecha;
            this.receptor = aux.receptor;
        }

        public static ArrayList Obtener()
        {
            return FirmaCAD.Instancia.ObtenerFirmas();
        }

        override public bool Obtener(int id)
        {
            ENFirma aux = new ENFirma();
            FirmaCAD.Instancia.ObtenerFirma(id);

            if (aux != null)
            {
                this.id = aux.id;
                this.emisor = aux.emisor;
                this.texto = aux.texto;
                this.fecha = aux.fecha;
                this.receptor = aux.receptor;

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Obtener(string nombre, bool emisor)
        {
            ENFirma aux = null;
            aux = FirmaCAD.Instancia.ObtenerFirma(nombre, emisor);

            this.id = aux.id;
            this.emisor = aux.emisor;
            this.texto = aux.texto;
            this.fecha = aux.fecha;
            this.receptor = aux.receptor;

            if (aux == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        override public bool Actualizar()
        {
            throw new NotImplementedException();
        }

        override public bool Guardar()
        {
            //return FirmaCAD.Instancia.GuardarFirma(emisor, texto, fecha, receptor);
            return true;
        }

        override public bool Borrar()
        {
            return FirmaCAD.Instancia.BorrarFirma(id);
        }

        public static bool Borrar(int pid)
        {
            return FirmaCAD.Instancia.BorrarFirma(pid);
        }

        public void BorrarUsuarios()
        {
            FirmaCAD.Instancia.BorrarFirmas();
        }

        public static ArrayList Buscar(string emisor, string receptor, DateTime fecha)
        {
            return FirmaCAD.Instancia.BuscarFirma(emisor, receptor, fecha);
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public ENUsuario Emisor
        {
            get { return emisor; }
            set { emisor = value; }
        }
        public string Texto
        {
            get { return texto; }
            set { texto = value; }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public ENUsuario Receptor
        {
            get { return receptor; }
            set { receptor = value; }
        }
    }
}
