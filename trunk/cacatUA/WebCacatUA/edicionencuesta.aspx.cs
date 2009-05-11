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
    public partial class edicionencuesta : InterfazWeb
    {
        ENEncuesta encuesta;

        protected void Page_Load(object sender, EventArgs e)
        {
            String id = (String)Request["id"];
            String u = (String)Session["usuario"];

            if (id != null && u != null)
            {
                int idEnc = int.Parse(id);
                encuesta = ENEncuesta.Obtener(idEnc);

                if (encuesta.DeUsuario(ENUsuario.Obtener(u)))
                {
                    if (!Page.IsPostBack)
                    {
                        CargarEncuesta(false);
                    }
                    else
                    {
                        CargarEncuesta(true);
                    }
                }
                else
                {
                    Response.Redirect("encuestas.aspx");
                }
            }
            else
            {
                Response.Redirect("index.aspx");
            }
        }

        private void CargarEncuesta(bool postback)
        {
            int i = 0;

            if (!postback)
            {
                TextBox_Pregunta.Text = encuesta.Pregunta;
            }
            ArrayList opcArray = encuesta.Opciones();

            if (opcArray.Count > 0)
            {
                TableRow cabeceras = new TableRow();

                TableCell cab1 = new TableCell();
                cab1.CssClass = "celda_cabecera";
                Label label_cab1 = new Label();
                label_cab1.Text = "#";
                cab1.Controls.Add(label_cab1);

                TableCell cab2 = new TableCell();
                cab2.CssClass = "celda_cabecera";
                Label label_cab2 = new Label();
                label_cab2.Text = "Opcion";
                cab2.Controls.Add(label_cab2);

                TableCell cab3 = new TableCell();
                cab3.CssClass = "celda_cabecera";
                Label label_cab3 = new Label();
                label_cab3.Text = "Votos";
                cab3.Controls.Add(label_cab3);

                TableCell cab4 = new TableCell();
                cab4.CssClass = "celda_cabecera";
                Label label_cab4 = new Label();
                label_cab4.Text = "";
                cab4.Controls.Add(label_cab4);

                cabeceras.Controls.Add(cab1);
                cabeceras.Controls.Add(cab2);
                cabeceras.Controls.Add(cab3);
                cabeceras.Controls.Add(cab4);
                Table_encuesta.Controls.Add(cabeceras);

                foreach (OpcionEncuesta opc in encuesta.Opciones())
                {
                    String textoAux;

                    i++;
                    TableRow fila = new TableRow();

                    TableCell c1 = new TableCell();
                    c1.CssClass = "celda_encuestas";
                    Label l1 = new Label();
                    l1.Text = "Opcion " + i.ToString();
                    c1.Controls.Add(l1);

                    TableCell c2 = new TableCell();
                    c2.CssClass = "celda_encuestas";
                    Label l2 = new Label();
                    l2.Text = opc.Opcion;
                    c2.Controls.Add(l2);

                    TableCell c3 = new TableCell();
                    c3.CssClass = "celda_encuestas";
                    Label l3 = new Label();
                    if (encuesta.NumVotos() > 0)
                    {
                        int opcNumVotos = opc.NumVotos();
                        textoAux = opcNumVotos.ToString() + " (" + ((opcNumVotos * 100) / encuesta.NumVotos()).ToString() + "%)";
                    }
                    else
                    {
                        textoAux = "~";
                    }
                    l3.Text = textoAux;
                    c3.Controls.Add(l3);


                    TableCell c4 = new TableCell();
                    c4.CssClass = "celda_encuestas";
                    Button b1 = new Button();
                    b1.CssClass = "boton_encuestas";
                    b1.ID = opc.Id.ToString();
                    b1.Text = "Quitar";
                    b1.Click += new System.EventHandler(this.Button_borraropcion_Click);
                    c4.Controls.Add(b1);

                    fila.Controls.Add(c1);
                    fila.Controls.Add(c2);
                    fila.Controls.Add(c3);
                    fila.Controls.Add(c4);


                    Table_encuesta.Controls.Add(fila);
                }
            }
        }

        protected void Button_crearopcion_Click(object sender, EventArgs e)
        {
            if (TextBox_crearopcion.Text == "")
            {
                //Alert
            }
            else
            {
                OpcionEncuesta nOpcion = new OpcionEncuesta();
                nOpcion.Opcion = TextBox_crearopcion.Text;
                nOpcion.Encuesta = encuesta;
                ENEncuesta.CrearOpcion(nOpcion);
                Response.Redirect("edicionencuesta.aspx?id=" + encuesta.Id);
            }
        }

        protected void Button_borraropcion_Click(object sender, EventArgs e)
        {
            Button pulsado = (Button)sender;
            try
            {
                int idopcion = int.Parse(pulsado.ID.ToString());
                ENEncuesta.BorrarOpcion(ENEncuesta.ObtenerOpcion(idopcion));
            }
            catch (Exception) { }
            Response.Redirect("edicionencuesta.aspx?id=" + encuesta.Id);
        }

        protected void Button_cambiar_Click(object sender, EventArgs e)
        {
            if (TextBox_Pregunta.Text != encuesta.Pregunta)
            {
                encuesta.Pregunta = TextBox_Pregunta.Text;
                encuesta.Actualizar();
                Response.Redirect("edicionencuesta.aspx?id=" + encuesta.Id);
            }
        }
    }
}
