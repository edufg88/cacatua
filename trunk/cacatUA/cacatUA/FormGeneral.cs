using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Libreria;

namespace cacatUA
{
    public partial class FormGeneral : InterfazForm
    {
        private ResumenSistema resumenSistema;
        public FormGeneral()
        {
            InitializeComponent();
            CargarDatos();
        }

        public void CargarDatos()
        {
            resumenSistema = new ResumenSistema();
            propertyGrid_resumenSistema.SelectedObject = resumenSistema;
        }

        private void button_seccionRefrescar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }

    [DefaultPropertyAttribute("Asdfasgasdasd")]
    class ResumenSistema
    {
        private int numHilos;
        private string ultimoHilo;
        private string ultimaRespuesta;

        private int numUsuarios;
        private string ultimoUsuario;

        private int numCategorias;

        private int numMateriales;
        private string ultimoMaterial;

        private int numGrupos;
        private string ultimoGrupo;

        private int numPeticiones;
        private int numPeticionesSinContestar;
        private string ultimaPeticion;

        public ResumenSistema()
        {
            numHilos = ENHilo.Cantidad();
            ENHilo ultimoHiloAux = ENHilo.Ultimo();
            if (ultimoHiloAux != null)
            {
                ultimoHilo = ultimoHiloAux.Titulo;
            }
            else
            {
                ultimoHilo = "";
            }
            ENRespuesta ultimaRespuestaAux = ENRespuesta.Ultimo();
            if (ultimaRespuestaAux != null)
            {
                ultimaRespuesta = ultimaRespuestaAux.Texto;
            }
            else
            {
                ultimaRespuesta = "";
            }

            numUsuarios = ENUsuario.NumUsuarios();
            ENUsuario ultimoUsuarioAux = ENUsuario.Ultimo();
            if (ultimoUsuarioAux != null)
            {
                ultimoUsuario = ultimoUsuarioAux.Usuario;
            }
            else
            {
                ultimoUsuario = "";
            }

            numCategorias = ENCategoria.NumCategorias();

            numMateriales = ENMaterial.NumMateriales();
            ENMaterial ultimoMaterialAux = ENMaterial.Ultimo();
            if (ultimoMaterialAux != null)
            {
                ultimoMaterial = ultimoMaterialAux.Nombre;
            }
            else
            {
                ultimoMaterial = "";
            }


            numGrupos = ENGrupos.NumGrupos() ;
            ENGrupos grupo = ENGrupos.Ultimo();
            if (grupo != null)
            {
                ultimoGrupo = grupo.Nombre;
            }
            else
            {
                ultimoGrupo = "No hay ningun grupo creado";
            }

            numPeticiones = ENPeticion.ObtenerNumeroPeticiones();
            numPeticionesSinContestar = ENPeticion.ObtenerNumeroPeticionesSinContestar();
            ultimaPeticion = ENPeticion.ObtenerUltimaPeticion();
        }

        [CategoryAttribute("Foro"),
        DescriptionAttribute("Cantidad de hilos abiertos en el foro.")]
        public int NumHilos
        {
            get { return numHilos; }
        }

        [CategoryAttribute("Foro"),
        DescriptionAttribute("Título del último hilo abierto en el foro.")]
        public string UltimoHilo
        {
            get { return ultimoHilo; }
        }

        [CategoryAttribute("Foro"),
        DescriptionAttribute("Última respuesta añadida en el foro.")]
        public string UltimaRespuesta
        {
            get { return ultimaRespuesta; }
        }

        [CategoryAttribute("Usuarios"),
        DescriptionAttribute("Cantidad de usuarios registrados.")]
        public int NumUsuarios
        {
            get { return numUsuarios; }
        }

        [CategoryAttribute("Usuarios"),
        DescriptionAttribute("Último usuario registrado.")]
        public string UltimoUsuario
        {
            get { return ultimoUsuario; }
        }

        [CategoryAttribute("Categorías"),
        DescriptionAttribute("Cantidad de categorías.")]
        public int NumCategorias
        {
            get { return numCategorias; }
        }

        [CategoryAttribute("Grupos"),
        DescriptionAttribute("Cantidad de grupos abiertos.")]
        public int NumGrupos
        {
            get { return numGrupos; }
        }

        [CategoryAttribute("Grupos"),
        DescriptionAttribute("Nombre del último que se creó.")]
        public string UltimoGrupo
        {
            get { return ultimoGrupo; }
        }

        [CategoryAttribute("Peticiones"),
        DescriptionAttribute("Cantidad de peticiones sin contestar.")]
        public int NumPeticiones
        {
            get { return numPeticiones; }
        }

        [CategoryAttribute("Peticiones"),
        DescriptionAttribute("Cantidad de peticiones contestadas.")]
        public int NumPeticionesSinContestar
        {
            get { return numPeticionesSinContestar; }
        }

        [CategoryAttribute("Peticiones"),
        DescriptionAttribute("Última petición recibida.")]
        public string UltimaPeticion
        {
            get { return ultimaPeticion; }
        }

        [CategoryAttribute("Materiales"),
        DescriptionAttribute("Cantidad de materiales subidos.")]
        public int NumMateriales
        {
            get { return numMateriales; }
        }

        [CategoryAttribute("Materiales"),
        DescriptionAttribute("Nombre del último material subido.")]
        public string UltimoMaterial
        {
            get { return ultimoMaterial; }
        }

        [BrowsableAttribute(false)]
        public string Asdfasgasdasd // Sólo sirve para evitar que salga alguna fila seleccionada.
        {
            get { return ""; }
        }
    }
}
