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

            foreach (ENCategoria cat in categoriasusuario)
            {
                TableRow fila = new TableRow();

                TableCell c1 = new TableCell();
                c1.CssClass = "celda_categoria";
                Label l1 = new Label();
                l1.Text = cat.NombreCompleto();
                c1.Controls.Add(l1);

                TableCell c2 = new TableCell();
                c2.CssClass = "celda_categoria";
                Button b1 = new Button();
                //b1.ID = opc.Id.ToString();
                b1.Text = "Insuscribirse";
                //b1.Click += new System.EventHandler(Button_borraropcion_Click);
                c2.Controls.Add(b1);

                fila.Controls.Add(c1);
                fila.Controls.Add(c2);

                Table_categorias.Controls.Add(fila);
            }
        }
    }
}
