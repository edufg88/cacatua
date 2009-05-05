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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["imagen"] != null)
            {
                int id = int.Parse(Request.Params["imagen"].ToString());
                ENImagen i = ENImagen.Obtener(id);

                labelTitulo.Text = i.Titulo;
                labelFecha.Text = "Imagen tomada el: " + i.Fecha;
                labelUsuario.Text = "Imagen de: " + i.Usuario.Nombre;
                imagenPrincipal.ImageUrl = "/galeria/" + i.Id +".jpg";
                labelDescripcion.Text = i.Descripcion;

                ArrayList comentarios = new ArrayList();

                comentarios = ENImagenComentario.Obtener(i.Id);

                TableRow r = new TableRow();
                TableCell c = new TableCell();
                ENImagenComentario comen = new ENImagenComentario();

                for (int j = 0; j < comentarios.Count; j++)
                {
                    comen= (ENImagenComentario)comentarios[j];

                    c.Controls.Add(new LiteralControl(comen.Usuario.Usuario));
                    r.Controls.Add(c);
                    c = new TableCell();
                    c.Controls.Add(new LiteralControl(comen.Fecha.ToString()));
                    c.Attributes.Add("align", "right");
                    r.Controls.Add(c);
                    tablaComentarios.Controls.Add(r);
                    c = new TableCell();
                    r = new TableRow();
                    c.Controls.Add(new LiteralControl(comen.Texto));
                    r.Controls.Add(c);
                    tablaComentarios.Controls.Add(r);
                    c = new TableCell(); 
                    r = new TableRow();
                    r = new TableRow();
                    c.Controls.Add(new LiteralControl("<br/>"));
                    r.Controls.Add(c);
                    tablaComentarios.Controls.Add(r);
                    c = new TableCell();
                    r = new TableRow();


                }
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
