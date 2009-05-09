using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using Libreria;
namespace WebCacatUA
{
    public partial class mostrarMaterial : WebCacatUA.InterfazWeb
    {
        private ENMaterial material;
        private ENUsuario usuario;

        private int cantidadPorPagina;
        public int CantidadPorPagina
        {
            get { return cantidadPorPagina; }
            set { cantidadPorPagina = value; }
        }

        private int pagina;
        public int Pagina
        {
            get { return pagina; }
            set { pagina = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                material = null;
                // Recibimos el id del material que hay que mostrar
                if (Request.Params["id"] != null)
                {
                    int id = int.Parse(Request.Params["id"].ToString());
                    material = ENMaterial.Obtener(id);
                }
                else
                {
                    // Volvemos a la página de materiales
                    Response.Redirect("materiales.aspx?categoria=0");
                }

                // Obtenemos la página selecciona
                pagina = int.Parse(DropDownList_pagina.Text.ToString());
                cantidadPorPagina = int.Parse(DropDownList_cantidadPorPagina.Text.ToString());

                MostrarMaterial();

                // Comprobamos si el usuario está logueado
                if (Session["usuario"] == null)
                {
                    // No está logueado
                    TextBox_comentario.Enabled = false;
                    Button1.Enabled = false;
                    Panel_mensajeError.Visible = true;
                    Label_mensajeError.Text = Resources.I18N.DebesIdentificarte;
                    Panel_votar.Visible = false;
                }
                else
                    usuario = ENUsuario.Obtener(Session["usuario"].ToString());

                // Comprobamos si el usuario puede votar
                if (Panel_votar.Visible == true)
                {
                    int puntuacion = material.PuntuacionUsuario(usuario);
                    if (puntuacion != -1)
                    {  
                        // No Puede votar
                        Panel_votar.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        private bool MostrarMaterial()
        {
            bool mostrado = false;
            if (material != null)
            {
                // Actualizamos la navegación
                actualizarNavegacion(material.Categoria);
                Label_nombre.Text = material.Nombre;
                Label_descripcion.Text = material.Descripcion;
                Label_fecha.Text = material.Fecha.ToString();
                Label_tamaño.Text = ENMaterial.convertirTamaño(material.Tamaño);
                HyperLink_usuario.Text = material.Usuario.Usuario;
                HyperLink_usuario.NavigateUrl = "usuario.aspx?id=" + material.Usuario.Id.ToString();
                Label_descargas.Text = material.Descargas.ToString();
                Label_valoracion.Text = material.Puntuacion.ToString();
                Label_votos.Text = " (" + material.Votos.ToString() + " " + Resources.I18N.Votos + ")";
                HyperLink_descargar.NavigateUrl = "descargar.aspx?id=" + material.Id;
                Label_referencia.Text = material.Referencia;
                // Comprobamos si ese usuario tiene otros materiales

                BusquedaMaterial busqueda = new BusquedaMaterial();
                busqueda.Usuario = material.Usuario;
                ArrayList materiales = ENMaterial.Obtener("fecha", true, 1, 1, busqueda);
                int numResultados = busqueda.NumResultados;
                if (numResultados > 0)
                {
                    HyperLink_otrosMateriales.Text = "Más materiales (" + numResultados.ToString() + ")";
                    HyperLink_otrosMateriales.NavigateUrl = "materiales.aspx?usuario=" + material.Usuario.Id.ToString();
                }
                else
                {
                    HyperLink_otrosMateriales.Text = "";
                }
                
                // Mostramos los comentarios
                MostrarComentarios();
                mostrado = true;
            }
            return mostrado;
        }

        private void MostrarComentarios()
        {

            Panel_comentarios.Controls.Clear();

            HtmlTable tabla = new HtmlTable();
            tabla.ID = "tabla_mostrarComentatios";

            ActualizarPaginacion(material.NumComentarios);

            ArrayList comentarios = material.ObtenerComentarios(pagina, cantidadPorPagina);
            foreach (ComentarioMaterial comentario in comentarios)
            {
                HtmlTableRow fila = new HtmlTableRow();
                HtmlTableCell celda = new HtmlTableCell();
                Control control = Page.LoadControl("comentarioMaterial.ascx");
                WebCacatUA.comentarioMaterial controlComentario = (WebCacatUA.comentarioMaterial)control;
                controlComentario.inicializar(comentario);
                celda.Controls.Add(controlComentario);
                fila.Cells.Add(celda);
                
                // Cambiamos el color de la fila
                if (tabla.Rows.Count % 2 == 0)
                    fila.BgColor = "#dcd9cd";
                else
                    fila.BgColor = Color.White.Name;
                tabla.Rows.Add(fila);
            }
            Panel_comentarios.Controls.Add(tabla);
        }

        public void ActualizarPaginacion(int totalResultados)
        {
            if (totalResultados > 0)
            {
                int paginas = (int)Math.Ceiling(totalResultados / (float)CantidadPorPagina);
                // Añadimos las páginas al combo box
                string paginaActual = pagina.ToString();

                DropDownList_pagina.Items.Clear();

                for (int i = 1; i <= paginas; i++)
                    DropDownList_pagina.Items.Add(i.ToString());

                if (paginas < int.Parse(paginaActual))
                {
                    pagina = 1;
                    DropDownList_pagina.Text = "1";
                }
                else
                    DropDownList_pagina.Text = paginaActual;

                int inicial = (pagina - 1) * CantidadPorPagina + 1;
                int final = inicial - 1 + CantidadPorPagina;
                if (final > totalResultados) final = totalResultados;

                Label_resultados.Text = "Resultados " + inicial + " a " + final + " de " + totalResultados;

                if (DropDownList_pagina.Text == "1")
                    Button_anterior.Enabled = false;
                else
                    Button_anterior.Enabled = true;

                if (DropDownList_pagina.Text == paginas.ToString())
                    Button_siguiente.Enabled = false;
                else
                    Button_siguiente.Enabled = true;
            }
            else
            {
                paginacion_mostrarMaterial.Visible = false;
                resultados_mostrarMaterial.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //<%= Resources.I18N.DebesIdentificarte %>  
            // Validamos el comentario
            ComentarioMaterial comentario = new ComentarioMaterial();
            comentario.Usuario = usuario;
            comentario.Material = material;
            comentario.Texto = TextBox_comentario.Text;
            if (comentario.Texto.Length > ComentarioMaterial.maxTamTexto || comentario.Texto.Length < ComentarioMaterial.minTamTexto)
            {
                Panel_mensajeError.Visible = true;
                Label_mensajeError.Text = "Debe tener entre " + ComentarioMaterial.minTamTexto + " y " + ComentarioMaterial.maxTamTexto + " caracteres";
                Button1.Focus();
            }
            else
            {
                Panel_mensajeError.Visible = false;
                material.GuardarComentario(comentario);
                TextBox_comentario.Text = "";
                MostrarComentarios();
            }
        }

        private void actualizarNavegacion(ENCategoria categoria)
        {
            Label_ruta.Controls.Clear();
            HyperLink link = new HyperLink();
            link.Text = Resources.I18N.Materiales;
            link.NavigateUrl = "materiales.aspx?categoria=0";
            Label_ruta.Controls.Add(link);
            if (categoria != null)
                añadirRuta(categoria);
            Label label = new Label();
            label.Text = " > ";
            Label_ruta.Controls.Add(label);
            link = new HyperLink();
            link.Text = material.Nombre;
            link.NavigateUrl = "mostrarMaterial.aspx?id=" + material.Id.ToString();
            Label_ruta.Controls.Add(link);
        }

        private void añadirRuta(ENCategoria categoria)
        {
            // Añadimos primero la ruta del padre
            ENCategoria padre = ENCategoria.Obtener(categoria.Padre);
            if (padre != null)
            {
                // Obtenemos la ruta del padre
                añadirRuta(padre);
            }
            // Hemos llegado a la raíz
            Label label = new Label();
            label.Text = " > ";
            Label_ruta.Controls.Add(label);
            HyperLink link = new HyperLink();
            link.Text = categoria.Nombre;
            link.NavigateUrl = "materiales.aspx?categoria=" + categoria.Id.ToString();
            Label_ruta.Controls.Add(link);
        }

        protected void Button_votar_Click(object sender, EventArgs e)
        {
            int puntuacion = int.Parse(DropDownList_votar.SelectedValue);
            // Obtenemos el usuario que vota
            ENUsuario usuario = ENUsuario.Obtener(Session["usuario"].ToString());
            if(usuario != null)
            {
                // Guardamos el voto en la base de datos
                material.Votar(usuario, puntuacion);
                // Ocultamos el panel de votación
                Panel_votar.Visible = false;
            }
        }
    }
}
