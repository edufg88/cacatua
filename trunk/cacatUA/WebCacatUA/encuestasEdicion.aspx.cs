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
    public partial class encuestasEdicion : System.Web.UI.Page
    {
        ENUsuario usuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            String u = (String)Session["usuario"];
            if (u != null)
            {
                usuario = ENUsuario.Obtener(u);
                Label_Texto.Text = "· Bienvenido " + usuario.Usuario + ", estas son tus encuestas:";
                CargarEncuestas();
            }
            else
            {
                Response.Redirect("index.aspx");
            }
        }

        private void CargarEncuestas()
        {
            ENEncuesta aux = new ENEncuesta();
            foreach (ENEncuesta enc in aux.Buscar(usuario.Id))
            {
                TableRow fila = new TableRow();

                TableCell c1 = new TableCell();
                c1.CssClass = "celda_encuestas";
                Label l1 = new Label();
                l1.Text = enc.Pregunta;
                c1.Controls.Add(l1);

                TableCell c2 = new TableCell();
                c2.CssClass = "celda_encuestas";
                Button b1 = new Button();
                b1.Text = "Editar";
                c2.Controls.Add(b1);

                TableCell c3 = new TableCell();
                c3.CssClass = "celda_encuestas";
                Button b2 = new Button();
                b2.Text = "Editar";
                c3.Controls.Add(b2);

                fila.Controls.Add(c1);
                fila.Controls.Add(c2);
                fila.Controls.Add(c3);

                Table_encuestas.Controls.Add(fila);
            }
            
        }
    }
}
