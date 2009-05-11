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
    public partial class encuestas : InterfazWeb
    {
        ENUsuario usuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            String u = (String)Session["usuario"];
            if (u != null)
            {
                usuario = ENUsuario.Obtener(u);
                Label_Texto.Text = "En tu página sólo se mostrará la encuesta activa más reciente.";
                CargarEncuestas();
            }
            else
            {
                Response.Redirect("index.aspx");
            }
        }

        private void CargarEncuestas()
        {
            ArrayList arrayEncuestas = (new ENEncuesta()).Buscar(usuario.Id);

            if (arrayEncuestas.Count > 0)
            {
                TableRow cabeceras = new TableRow();

                TableCell cab1 = new TableCell();
                cab1.CssClass = "celda_cabecera";
                Label label_cab1 = new Label();
                label_cab1.Text = Resources.I18N.CabeceraEdicionEncuestasPregunta.ToString();
                cab1.Controls.Add(label_cab1);

                TableCell cab2 = new TableCell();
                cab2.CssClass = "celda_cabecera";
                Label label_cab2 = new Label();
                label_cab2.Text = "";
                cab2.Controls.Add(label_cab2);

                TableCell cab3 = new TableCell();
                cab3.CssClass = "celda_cabecera";
                Label label_cab3 = new Label();
                label_cab3.Text = "";
                cab3.Controls.Add(label_cab3);

                TableCell cab4 = new TableCell();
                cab4.CssClass = "celda_cabecera";
                Label label_cab4 = new Label();
                label_cab4.Text = "";
                cab4.Controls.Add(label_cab4);

                TableCell cab5 = new TableCell();
                cab5.CssClass = "celda_cabecera";
                Label label_cab5 = new Label();
                label_cab5.Text = Resources.I18N.CabeceraEdicionEncuestasFecha.ToString();
                cab5.Controls.Add(label_cab5);

                cabeceras.Controls.Add(cab1);
                cabeceras.Controls.Add(cab2);
                cabeceras.Controls.Add(cab3);
                cabeceras.Controls.Add(cab4);
                cabeceras.Controls.Add(cab5);
                Table_encuestas.Controls.Add(cabeceras);

                foreach (ENEncuesta enc in arrayEncuestas)
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
                    b1.PostBackUrl = "edicionencuesta.aspx?id=" + enc.Id.ToString();
                    b1.CssClass = "boton_encuestas";
                    b1.Text = "Editar";
                    c2.Controls.Add(b1);

                    TableCell c3 = new TableCell();
                    c3.CssClass = "celda_encuestas";
                    Button b2 = new Button();
                    b2.PostBackUrl = "borrarencuesta.aspx?id=" + enc.Id.ToString();
                    b2.CssClass = "boton_encuestas";
                    b2.Text = "Borrar";
                    c3.Controls.Add(b2);

                    TableCell c4 = new TableCell();
                    c4.CssClass = "celda_encuestas";
                    Button b3 = new Button();
                    b3.CssClass = "boton_encuestas";
                    b3.PostBackUrl = "estadoencuesta.aspx?id=" + enc.Id.ToString();
                    if (enc.Activa)
                        b3.Text = "Desactivar";
                    else
                        b3.Text = "Activar";
                    c4.Controls.Add(b3);

                    TableCell c5 = new TableCell();
                    c5.CssClass = "celda_encuestas";
                    Label l2 = new Label();
                    l2.Text = enc.Fecha.ToShortDateString();
                    c5.Controls.Add(l2);

                    fila.Controls.Add(c1);
                    fila.Controls.Add(c2);
                    fila.Controls.Add(c3);
                    fila.Controls.Add(c4);
                    fila.Controls.Add(c5);

                    Table_encuestas.Controls.Add(fila);
                }
            }
        }
            
        protected void Button_crearencuesta_Click(object sender, EventArgs e)
        {
            ENEncuesta nueva = new ENEncuesta("Nueva encuesta",usuario.Usuario, DateTime.Now, false);
            nueva.Guardar();
            Response.Redirect("encuestas.aspx");
        }

    }
}
