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


public partial class generalUsuario : WebCacatUA.InterfazWeb
{
    private ENUsuario u;

    protected void Page_Load(object sender, EventArgs e)
    {
        extraerParametros();

        if (u != null)
        {
            // Comprobamos si es una petición nueva o el resultado de un evento del usuario.
            if (!Page.IsPostBack)
            {
                cargarGaleria(); // Cargamos las últimas imágenes y las últimas firmas
                cargarFirmas();
            }
        }
        else
        {
            Response.Redirect("usuarios.aspx");
        }
    }

    private void cargarGaleria()
    {
        ArrayList Imagenes = ENImagen.Obtener(u.Id, 1, 8);
        Table_galeria.Controls.Clear();
        int cont = 0;

        TableRow fila = new TableRow();
        TableRow fila2 = new TableRow();
        foreach (ENImagen imagen in Imagenes)
        {
            if (imagen != null)
            {
                // Columna de la imágen activa del usuario
                TableCell c1 = new TableCell();
                c1.CssClass = "columnaGaleria";
                Label l1 = new Label();
                if (imagen.Id == -1) // Comprobamos si tiene imagen activa el usuario
                {
                    l1.Text = "<img src=\"imagenes/sinImagen.png\" alt=\"Foto de usuario\" width=\"60\" height=\"60\" class=\"imagen\" />";
                }
                else
                {
                    l1.Text = "<img src=\"imagenes/" + imagen.Id + ".jpg\" width=\"100\" height=\"60\" alt=\"Foto de usuario\" class=\"imagen\" />";
                }
                Panel p1 = new Panel();
                p1.Controls.Add(l1);
                c1.Controls.Add(p1);

                if (cont < 4)
                {
                    fila.Controls.Add(c1);
                    Table_galeria.Controls.Add(fila);
                }
                else
                {
                    fila2.Controls.Add(c1);
                    Table_galeria.Controls.Add(fila2);
                }
                cont++;
            }
        }
    }

    private void cargarFirmas()
    {
        ArrayList Firmas = ENFirma.ObtenerFirmas(u.Usuario, 1, 10);
        Table_firmas.Controls.Clear();

        foreach (ENFirma firma in Firmas)
        {
            if (firma != null)
            {
                // Fila con la info de la firma y su fecha
                TableCell celda1 = new TableCell();
                celda1.CssClass = "infoFirma";
                Label emisor = new Label();
                Label fecha = new Label();
                emisor.Text = "<a href=\"generalUsuario.aspx?usuario=" + firma.Emisor.Usuario + "\">" + firma.Emisor.Usuario + "</a>";
                fecha.Text = firma.Fecha.ToString();
                emisor.CssClass = "emisorFirma";
                fecha.CssClass = "fechaFirma";
                celda1.Controls.Add(emisor);
                celda1.Controls.Add(fecha);
                TableRow fila = new TableRow();
                fila.Cells.Add(celda1);
                Table_firmas.Rows.Add(fila);

                // Fila con el texto de la firma
                TableCell celda2 = new TableCell();
                celda2.CssClass = "contenidoFirma";
                Label texto = new Label();
                texto.Text = firma.Texto.ToString();
                texto.CssClass = "textoFirma";
                celda2.Controls.Add(texto);
                TableRow fila2 = new TableRow();
                fila2.Cells.Add(celda2);
                Table_firmas.Rows.Add(fila2);
            }
        }
    }

    /// <summary>
    /// Extraemos el usuario y el modo ("normal" o "editar").
    /// </summary>
    private void extraerParametros()
    {
        // Intentamos extraer el usuario según el nombre recibido en los parámetros.
        u = null;
        try
        {
            u = ENUsuario.Obtener(Request["usuario"].ToString());
        }
        catch (Exception) { }

        // Si no lo hemos extraido de ninguna forma, lo intentamos desde la sessión.
        if (u == null)
        {
            try
            {
                u = ENUsuario.Obtener(Session["usuario"].ToString());
            }
            catch (Exception) { }
        }
    }


    protected void LinkButton_infoFirmas_Click(object sender, EventArgs e)
    {
        if (Session["usuario"] != null)
            Response.Redirect("firmas.aspx?usuario=" + Session["usuario"]);
        else if (Request["usuario"].ToString() != "")
        {
            Response.Redirect("firmas.aspx?usuario=" + Request["usuario"].ToString());
        }
        else
        {
            Response.Redirect("usuarios.aspx");
        }
    }
    protected void LinkButton_infoGaleria_Click(object sender, EventArgs e)
    {
        if (Session["usuario"] != null)
            Response.Redirect("galeria.aspx?usuario=" + Session["usuario"]);
        else if (Request["usuario"].ToString() != "")
        {
            Response.Redirect("galeria.aspx?usuario=" + Request["usuario"].ToString());
        }
        else
        {
            Response.Redirect("usuarios.aspx");
        }
    }
}