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
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        private int pagina = 1;
        private int cantidad = 0;
        private int numComentarios = 0;
        private int cantidadPaginas = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["imagen"] != null)
            {
                int cantidadPorPaginaSuperior = int.Parse(DropDownList_cantidadPorPaginaSuperior.Text.ToString());

                cantidad = cantidadPorPaginaSuperior;

                if (DropDownList_cantidadPorPaginaSuperior.Text == null)
                {
                    pagina = 1;
                }
                else
                {
                    pagina = int.Parse(DropDownList_paginaSuperior.Text);
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

                ListItem item = new ListItem();
                DropDownList_paginaSuperior.Items.Clear();

                for (int k = 1; k <= cantidadPaginas || k==1; k++)
                {
                    DropDownList_paginaInferior.Items.Add(k.ToString());
                    DropDownList_paginaSuperior.Items.Add(k.ToString());
                }
                DropDownList_paginaInferior.Text = pagina.ToString(); ;
                DropDownList_paginaSuperior.Text = pagina.ToString();

                int id = int.Parse(Request.Params["imagen"].ToString());

                ENImagen i = ENImagen.Obtener(id);

                labelTitulo.Text = i.Titulo;
                labelFecha.Text = "Imagen tomada el: " + i.Fecha;
                labelUsuario.Text = "Imagen de: " + i.Usuario.Nombre;
                imagenPrincipal.ImageUrl = "/galeria/" + i.Id + ".jpg";
                labelDescripcion.Text = i.Descripcion;

                
                ArrayList comentarios = new ArrayList();

                
                comentarios = ENImagenComentario.Obtener(i.Id,pagina,cantidad);
                //comentarios = ENImagenComentario.Obtener(i.Id);

                TableRow r = new TableRow();
                TableRow r1 = new TableRow();
                TableCell c = new TableCell();
                TableCell c1 = new TableCell();
                TableCell c2 = new TableCell();
                Table t = new Table();
                Table t1 = new Table();
                ENImagenComentario comen = new ENImagenComentario();

                LinkButton enlace1 = new LinkButton();
                enlace1.Text = "Anterior";
                enlace1.PostBackUrl = "/galeriaDetalle.aspx?imagen=" + ENImagen.Siguiente(i.Id,i.Usuario.Id) + "#tituloImagen";

                LinkButton enlace2 = new LinkButton();
                enlace2.Text = "Borrar";
                enlace2.PostBackUrl = "";

                LinkButton enlace3 = new LinkButton();
                enlace3.Text = "Siguiente";
                enlace3.PostBackUrl = "/galeriaDetalle.aspx?imagen=" + ENImagen.Anterior(i.Id, i.Usuario.Id) + "#tituloImagen";

                TableCell a1 = new TableCell();
                //TableCell a2 = new TableCell();
                TableCell a3 = new TableCell();

                a1.Controls.Add(enlace1);
                a1.Attributes.Add("align", "left");
                r.Controls.Add(a1);
                //a2.Controls.Add(enlace2);
                //a2.Attributes.Add("align", "center");
                //r.Controls.Add(a2);
                a3.Controls.Add(enlace3);
                a3.Attributes.Add("align", "right");
                r.Controls.Add(a3);
                tablaNavegarImagenes.Attributes.Add("width", "600px");
                tablaNavegarImagenes.Controls.Add(r);

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

                    c1.Controls.Add(new LiteralControl("<img src=\"/imagenes/sinImagen.png\"/>"));
                    c1.Attributes.Add("width", "100px");
                    
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
                    tablaComentarios.Controls.Add(r1);


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

            ENImagenComentario com = new ENImagenComentario(TextBoxComentario.Text, DateTime.Now, ENUsuario.Obtener(6), ENImagen.Obtener(int.Parse(Request.Params["imagen"].ToString())));

            ENImagenComentario.Guardar(com);

            Response.Redirect("/galeriaDetalle.aspx?imagen=" + Request.Params["imagen"]);

        }
    }
}
