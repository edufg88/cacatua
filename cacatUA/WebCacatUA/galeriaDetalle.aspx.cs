using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using Libreria;

namespace WebCacatUA
{
    public partial class Formulario_web1 : InterfazWeb
    {
        private int pagina = 1;
        private int cantidad = 5;
        private int numComentarios = 0;
        private int cantidadPaginas = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["imagen"] != null)
            {
                

                Label_cantidadPorPaginaAnterior.Visible = false;
                int cantidadPorPaginaSuperior = int.Parse(DropDownList_cantidadPorPaginaSuperior.Text.ToString());
                int cantidadPorPaginaInferior = int.Parse(DropDownList_cantidadPorPaginaInferior.Text.ToString());
                
                int paginaInferior = int.Parse(DropDownList_paginaInferior.Text.ToString());
                int paginaSuperior = int.Parse(DropDownList_paginaSuperior.Text.ToString());

                // Comprobamos si ha cambiado la página
                if (paginaInferior != paginaSuperior)
                {
                    // Ha cambiado
                    if (int.Parse(Hidden_paginaAnterior.Value.ToString()) == paginaSuperior)
                        pagina = paginaInferior;
                    else
                        pagina = paginaSuperior;
                }
                else
                    pagina = paginaSuperior;
                Hidden_paginaAnterior.Value = pagina.ToString();

                // Comprobamos si ha cambiado la cantidad por página
                if (cantidadPorPaginaInferior != cantidadPorPaginaSuperior)
                {
                    // Ha cambiado
                    pagina = 1;
                    DropDownList_paginaInferior.Text = "1";
                    DropDownList_paginaSuperior.Text = "1";
                    if (int.Parse(Label_cantidadPorPaginaAnterior.Text) == cantidadPorPaginaSuperior)
                        cantidad = cantidadPorPaginaInferior;
                    else
                        cantidad = cantidadPorPaginaSuperior;
                }
                else
                        cantidad = cantidadPorPaginaSuperior;

                Label_cantidadPorPaginaAnterior.Text = cantidad.ToString();
                DropDownList_cantidadPorPaginaInferior.Text = cantidad.ToString();
                DropDownList_cantidadPorPaginaSuperior.Text = cantidad.ToString();

                if(Session["usuario"]!=null){
                    int votos = ENImagenVoto.ObtenerValoracion(int.Parse(Request.Params["imagen"]));
                    if (votos < 0)
                    {
                        Label_valoracion.Text = Resources.I18N.SinValoracion;
                    }
                    else
                    {
                        Label_valoracion.Text = Resources.I18N.Valoracion + ": " + votos;
                    }

                    int voto = ENImagenVoto.ObtenerValoracionUsuario(int.Parse(Request.Params["imagen"]), Session["usuario"].ToString());
                    
                    if (voto < 0)
                    {
                        Boton_valorar.Visible = true;
                        DropDownList_valoracion.Visible = true;
                    }
                    else
                    {
                        Boton_valorar.Visible = false;
                        DropDownList_valoracion.Visible = false;
                    }
                }

                numComentarios = ENImagenComentario.ObtenerNumeroImagenes(int.Parse(Request.Params["imagen"]));

                if (numComentarios % cantidad == 0)
                {
                    cantidadPaginas =  numComentarios/cantidad;
                }
                else
                {
                    cantidadPaginas = (numComentarios / cantidad)+1;
                }

                if (pagina == 1)
                {
                    Button_anteriorSuperior.Enabled = false;
                    Button1.Enabled = false;
                }
                else
                {
                    Button_anteriorSuperior.Enabled = true;
                    Button1.Enabled = true;
                }

                if (pagina == cantidadPaginas)
                {
                    Button_siguienteSuperior.Enabled = false;
                    Button2.Enabled = false;
                }
                else
                {
                    Button_siguienteSuperior.Enabled = true;
                    Button2.Enabled = true;
                }
                

                ListItem item = new ListItem();
                DropDownList_paginaSuperior.Items.Clear();
                DropDownList_paginaInferior.Items.Clear();

                for (int k = 1; k <= cantidadPaginas || k==1; k++)
                {
                    DropDownList_paginaInferior.Items.Add(k.ToString());
                    DropDownList_paginaSuperior.Items.Add(k.ToString());
                }
                

                int id = int.Parse(Request.Params["imagen"].ToString());

                ENImagen i = ENImagen.Obtener(id);
                ENUsuario us = null;
                if (Session["usuario"] != null)
                {
                    us = ENUsuario.Obtener(Session["usuario"].ToString());
                    TextBoxComentario.Enabled = true;
                    botonComentar.Enabled = true;

                }
                else
                {
                    TextBoxComentario.Enabled = false;
                    botonComentar.Enabled = true;

                }

                labelTitulo.Text = i.Titulo;
                labelFecha.Text = Resources.I18N.ImagenSubidaEl + " " + i.Fecha;
                labelUsuario.Text = Resources.I18N.ImagenDe + " " + i.Usuario.Usuario;
                imagenPrincipal.ImageUrl = "/galeria/" + i.Archivo;
                labelDescripcion.Text = i.Descripcion;

                
                ArrayList comentarios = new ArrayList();

                
                comentarios = ENImagenComentario.Obtener(i.Id,pagina,cantidad);
                

                if (comentarios.Count != 0)
                {
                    DropDownList_paginaInferior.Text = pagina.ToString();
                    DropDownList_paginaSuperior.Text = pagina.ToString();
                }

                TableRow r = new TableRow();
                TableRow r1 = new TableRow();
                TableCell c = new TableCell();
                TableCell c1 = new TableCell();
                TableCell c2 = new TableCell();
                Table t = new Table();
                Table t1 = new Table();
                Table t2 = new Table();
                ENImagenComentario comen = new ENImagenComentario();
                TableRow rcomentario = new TableRow();
                TableCell ccomentario = new TableCell();

                LinkButton enlace1 = new LinkButton();
                enlace1.Text = Resources.I18N.Anterior;
                enlace1.PostBackUrl = "/galeriaDetalle.aspx?imagen=" + ENImagen.Siguiente(i.Id,i.Usuario.Id) + "#tituloImagen";

                LinkButton enlace2 = new LinkButton();
                enlace2.Text = Resources.I18N.Borrar;
                enlace2.PostBackUrl = "/galeriaBorrar.aspx?imagen=" + Request.Params["imagen"].ToString();

                LinkButton enlace4 = new LinkButton();
                enlace4.Text = Resources.I18N.Editar;
                enlace4.PostBackUrl = "/galeriaEditar.aspx?imagen=" + Request.Params["imagen"].ToString();

                LinkButton enlace3 = new LinkButton();
                enlace3.Text = Resources.I18N.Siguiente;
                enlace3.PostBackUrl = "/galeriaDetalle.aspx?imagen=" + ENImagen.Anterior(i.Id, i.Usuario.Id) + "#tituloImagen";

                TableCell a1 = new TableCell();
                TableCell a2 = new TableCell();
                TableCell a4 = new TableCell();
                if (us != null && us.Id == i.Usuario.Id)
                {
                    a2 = new TableCell();
                    a4 = new TableCell();
                }
                TableCell a3 = new TableCell();

                a1.Controls.Add(enlace1);
                a1.Attributes.Add("align", "left");
                r.Controls.Add(a1);
                if (us != null && us.Id == i.Usuario.Id)
                {
                    a2.Controls.Add(enlace2);
                    a2.Attributes.Add("align", "center");
                    r.Controls.Add(a2);

                    a4.Controls.Add(enlace4);
                    a4.Attributes.Add("align", "center");
                    r.Controls.Add(a4);

                    Boton_seleccionarFoto.Visible = true;
                }
                else
                {
                    Boton_seleccionarFoto.Visible = false;
                }
                a3.Controls.Add(enlace3);
                a3.Attributes.Add("align", "right");
                r.Controls.Add(a3);
                tablaNavegarImagenes.Attributes.Add("width", "600px");
                tablaNavegarImagenes.Controls.Add(r);

                if (comentarios.Count == 0)
                {
                    Panel_comentarios.Visible = false;
                }
                else
                {
                    Panel_comentarios.Visible = true;
                }

                ENImagen imagenusuario = new ENImagen();

                for (int j = 0; j < comentarios.Count; j++)
                {
                    c = new TableCell();
                    c1 = new TableCell();
                    c2 = new TableCell();
                    r = new TableRow();
                    r1 = new TableRow();
                    t = new Table();
                    t1 = new Table();
                    
                    comen = (ENImagenComentario)comentarios[j];
                    if (comen.Usuario.Imagen > 0)
                    {
                        imagenusuario = ENImagen.Obtener(comen.Usuario.Imagen);
                        if (imagenusuario != null)
                        {
                            c1.Controls.Add(new LiteralControl("<img src=\"/galeria/" + imagenusuario.Archivo + "\" width=\"100px\"/>"));
                            c1.Attributes.Add("width", "100px");
                        }
                        else
                        {
                            c1.Controls.Add(new LiteralControl("<img src=\"/imagenes/sinImagen.png\"/>"));
                            c1.Attributes.Add("width", "100px");
                        }
                    }
                    else
                    {
                        c1.Controls.Add(new LiteralControl("<img src=\"/imagenes/sinImagen.png\"/>"));
                        c1.Attributes.Add("width", "100px");
                    }

                    
                    c.Controls.Add(new LiteralControl(comen.Usuario.Usuario));
                    r.Controls.Add(c);
                    c = new TableCell();
                    c.Controls.Add(new LiteralControl(comen.Fecha.ToString()));
                    c.Attributes.Add("align", "right");
                    r.Controls.Add(c);
                    t1.Attributes.Add("width", "100%");
                    t1.Controls.Add(r);
                    c = new TableCell();
                    r = new TableRow();
                    c.Controls.Add(t1);
                    r.Controls.Add(c);
                    t.Controls.Add(r);
                    c = new TableCell();
                    r = new TableRow();
                    c.Controls.Add(new LiteralControl("<br/>"));
                    r.Controls.Add(c);
                    t.Controls.Add(r);
                    c = new TableCell();
                    r = new TableRow();
                    c.Controls.Add(new LiteralControl(comen.Texto));
                    r.Controls.Add(c);
                    t.Controls.Add(r);
                    c = new TableCell();
                    r = new TableRow();
                    c.Controls.Add(new LiteralControl("<br/>"));
                    r.Controls.Add(c);
                    t.Controls.Add(r);
                    t.Attributes.Add("width", "100%");
                    c2.Controls.Add(t);
                    r1.Controls.Add(c1);
                    r1.Controls.Add(c2);
                    t2 = new Table();
                    t2.Controls.Add(r1);
                    rcomentario = new TableRow();
                    ccomentario = new TableCell();
                    ccomentario.Controls.Add(new LiteralControl("<div class=\"comentario\">"));
                    ccomentario.Controls.Add(t2);
                    ccomentario.Controls.Add(new LiteralControl("</div>"));                    
                    rcomentario.Controls.Add(ccomentario);
                    tablaComentarios.Controls.Add(rcomentario);

                }

                if (Session["usuario"] == null)
                {
                    TextBoxComentario.Enabled = false;
                    botonComentar.Enabled = false;
                }
                {
                    TextBoxComentario.Enabled = true;
                    botonComentar.Enabled = true;
                }
            }
            else
            {
                Response.Redirect("/galeria.aspx");
            }

        }

        public void guardarComentario(Object sender, EventArgs e)
        {

            ENImagenComentario com = new ENImagenComentario(TextBoxComentario.Text, DateTime.Now, ENUsuario.Obtener(Session["usuario"].ToString()), ENImagen.Obtener(int.Parse(Request.Params["imagen"].ToString())));

            ENImagenComentario.Guardar(com);

            Response.Redirect("/galeriaDetalle.aspx?imagen=" + Request.Params["imagen"]);

        }

        public void cambioCantidadSuperior(Object sender, EventArgs e)
        {
            int cantidad = int.Parse(DropDownList_cantidadPorPaginaSuperior.Text.ToString());
            DropDownList_cantidadPorPaginaInferior.Text = cantidad.ToString();
        }

        public void cambioCantidadInferior(Object sender, EventArgs e)
        {
            int cant = int.Parse(DropDownList_cantidadPorPaginaInferior.Text.ToString());
            cantidad = cant;
            DropDownList_cantidadPorPaginaSuperior.Text = cant.ToString();
        }

        public void borrarImagen(Object sender, EventArgs e)
        {
            Response.Redirect("/galeriaUpload.aspx");
        }

        public void seleccionarFoto(Object sender, EventArgs e)
        {
            if (Session["usuario"] != null && Request.Params["imagen"] != null)
            {
                ENUsuario usuario = ENUsuario.Obtener(Session["usuario"].ToString());
                if (usuario != null)
                {
                    ENImagen imagen = ENImagen.Obtener(int.Parse(Request.Params["imagen"]));
                    usuario.Imagen = imagen.Id;
                    usuario.Actualizar();
                    Response.Redirect("/galeriaDetalle.aspx?imagen=" + Request.Params["imagen"]);
                }
            }
        }

        public void valorarFoto(Object sender, EventArgs e)
        {
            if (Session["usuario"] != null && Request.Params["imagen"] != null)
            {
                ENUsuario usuario = ENUsuario.Obtener(Session["usuario"].ToString());
                if (usuario != null){
                
                    int puntuacion = int.Parse(DropDownList_valoracion.Text);

                    ENImagen imagen = ENImagen.Obtener(int.Parse(Request.Params["imagen"]));
                    ENImagenVoto voto = new ENImagenVoto(usuario, imagen, puntuacion);
                    voto.Guardar();
                    
                    Response.Redirect("/galeriaDetalle.aspx?imagen=" + Request.Params["imagen"]);
                }
            }
        }

    }
}
