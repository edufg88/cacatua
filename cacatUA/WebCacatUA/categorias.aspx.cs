using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Libreria;

namespace WebCacatUA
{
    public partial class categorias : InterfazWeb
    {
        ENUsuario usuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            String u = (String)Session["usuario"];
            if (u != null)
            {
                usuario = ENUsuario.Obtener(u);
                Label_Texto.Text = "Categorias a las que estas suscrito:";
                CargarCategorias();
            }
            else
            {
                Response.Redirect("index.aspx");
            }
        }

        private void CargarCategorias()
        {
            ArrayList categoriasusuario = usuario.Categorias();

            //Ordenamos el ArrayList
            categoriasusuario.Sort(new ENCategoriaComparer());

            foreach (ENCategoria cat in categoriasusuario)
            {
                TableRow fila = new TableRow();

                String cssclass = "celda_categorias";
                if (cat.EsSuperior())
                {
                    cssclass = "celda_categoriaSuperior";
                }
                TableCell c1 = new TableCell();
                c1.CssClass = cssclass;
                Label l1 = new Label();
                l1.Text = cat.NombreCompleto();
                c1.Controls.Add(l1);

                TableCell c2 = new TableCell();
                c2.CssClass = cssclass;
                Button b1 = new Button();
                b1.ID = cat.Id.ToString();
                b1.Text = "Insuscribirse";
                b1.Click += new System.EventHandler(Button_borrarsuscripcion_Click);
                c2.Controls.Add(b1);

                fila.Controls.Add(c1);
                fila.Controls.Add(c2);

                Table_categorias.Controls.Add(fila);
            }
        }

        protected void Button_borrarsuscripcion_Click(object sender, EventArgs e)
        {
            Button pulsado = (Button)sender;
            try
            {
                int idopcion = int.Parse(pulsado.ID.ToString());
                ENCategoria.Obtener(idopcion).InsuscribirUsuario(usuario);
            }
            catch (Exception) { }
            Response.Redirect("categorias.aspx");
        }
    }
}
