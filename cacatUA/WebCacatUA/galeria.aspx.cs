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
    public partial class Formulario_web11 : InterfazWeb
    {
        private ENImagen imagen = null;
        private int pagina = 1;
        private int numPaginas = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            ArrayList fotos = new ArrayList();
            if (Request.Params["usuario"] == null)
            {
                Response.Redirect("/index.aspx");
            }
            int n = ENImagen.ObtenerNumeroImagenes(ENUsuario.Obtener(Request.Params["usuario"]).Id);

            int paginacion = 10;

            if ( n % paginacion == 0)
            {
                numPaginas = n / paginacion;
            }
            else
            {
                numPaginas = (n / paginacion) + 1;
            }

            if (Request.Params["usuario"] != null)
            {
                ENUsuario us = ENUsuario.Obtener(Request.Params["usuario"]);
                Label_nombreUsuario.Text += " " + Request.Params["usuario"];

                if (Request.Params["pag"] != null)
                {
                    pagina = int.Parse(Request.Params["pag"]);
                    fotos = ENImagen.Obtener(us.Id, int.Parse(Request.Params["pag"]), paginacion);
                }
                else
                {
                    fotos = ENImagen.Obtener(us.Id, 1, paginacion);
                }
            }
            else
            {
                fotos = ENImagen.Obtener();
            }

            tablaImagenes.Attributes.Add("widht", "100%");
            TableRow r = new TableRow();
            TableCell c = new TableCell();


            tablaImagenes.Attributes.Add("text-align", "left;");
            LinkButton ant = new LinkButton();
            ant.Text = "Anteriores";
            if (pagina == 1)
            {
                ant.Visible = false;
            }
            else
            {
                ant.Visible = true;
            }
            ant.PostBackUrl = "/galeria.aspx?usuario=" + Request.Params["usuario"] + "&pag=" + (pagina-1) + "#comienzoGaleria";
            ant.ID = "anteriorPagina";
            c.Controls.Add(ant);
            c.Attributes.Add("align", "left");
            r.Controls.Add(c);
            c = new TableCell();
            LinkButton sig = new LinkButton();
            sig.Text = "Siguientes";
            if (pagina == numPaginas || numPaginas==0)
            {
                sig.Visible = false;
            }
            else
            {
                sig.Visible = true;
            }
            sig.PostBackUrl = "/galeria.aspx?usuario=" + Request.Params["usuario"] + "&pag=" + (pagina + 1) + "#comienzoGaleria";
            sig.ID = "siguientePagina";
            c.Controls.Add(sig);
            c.Attributes.Add("align", "right");
            r.Controls.Add(c);
            tablaPaginacion.Controls.Add(r);
            c = new TableCell();
            r = new TableRow();

            int cont=1;
            foreach(ENImagen i in fotos)
            {
                if (cont == 1)
                {
                    imagen = i;
                }                        
                c = new TableCell();
                c.Controls.Add(new LiteralControl("<img onclick=\"funcion('" + i.Archivo + "'," + i.Id +")\" height=\"38px\" src=\"/galeria/"+ i.Archivo + "\" alt=\"" + i.Titulo + "\" />"));
                r.Controls.Add(c);

                if(cont%10==0)
                {
                    tablaImagenes.Controls.Add(r);
                    r = new TableRow();
                }

                cont++;
                
            }
            
            r.Controls.Add(c);

            tablaImagenes.Controls.Add(r);

            Response.Write("<script type=\"text/javascript\" language=\"javascript\">id=\"\";</script>");
            Response.Write("<script type=\"text/javascript\" language=\"javascript\">archivo=\"\";</script>");

            if (fotos.Count > 0)
            {
                
                ENImagen img = (ENImagen)fotos[0];
                Response.Write("<script type=\"text/javascript\" language=\"javascript\">id=" + img.Id + ";</script>");
                Response.Write("<script type=\"text/javascript\" language=\"javascript\">archivo='" + img.Archivo + "';</script>");
            }
            else{
                Label lab = new Label();
                lab.Text = Resources.I18N.NoHayImagenes;
                panelImagenPrincipal.Controls.Add(lab);

                
            }

            if (Session["usuario"] != null && Request.Params["usuario"] != null)
            {
                if (Session["usuario"].ToString() == Request.Params["usuario"].ToString())
                {
                    subirImagen.Visible = true;
                }
                else
                {
                    subirImagen.Visible = false;
                }
            }
            else
            {
                subirImagen.Visible = false;
            }

            

        }

        void siguiente(object sender, EventArgs e)
        {
            pagina++;
            Response.Redirect("/galeria.aspx?usuario=" + Request.Params["usuario"] + "&pag=" + pagina);

        }


    }
}
