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
                imagenPrincipal.ImageUrl = "/imagenes/" + i.Id +".jpg";
                labelDescripcion.Text = i.Descripcion;

                ArrayList comentarios = new ArrayList();

                
                
            }

        }
    }
}
