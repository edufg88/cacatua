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

public partial class firmas : WebCacatUA.InterfazWeb
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["usuario"] != null)
        {
            string usuario = Request.QueryString["usuario"];
            Label_usuario.Text = usuario;
            ObtenerFirmas(usuario);
        }
    }

    public void ObtenerFirmas(string usuario)
    {
        ENUsuario user=ENUsuario.Obtener(usuario);
        ArrayList Firmas = ENFirma.ObtenerFirmas(user.Usuario,false);
        Panel_firmas.Controls.Clear();
        HtmlTable tabla = new HtmlTable();
        HtmlTableRow fila = new HtmlTableRow();
        HtmlTableCell celdax = new HtmlTableCell();
        HtmlTableCell celday = new HtmlTableCell();
        HtmlTableCell celdaz = new HtmlTableCell();
        Label firm = new Label();
        Label fech = new Label();
        Label usuarios = new Label();
        firm.Text = "Firma";
        fech.Text = "Fecha";
        usuarios.Text = "Usuarios";
        celdax.Controls.Add(usuarios);
        celday.Controls.Add(fech);
        celdaz.Controls.Add(firm);
        fila.Cells.Add(celdax);
        fila.Cells.Add(celday);
        fila.Cells.Add(celdaz);
        tabla.Rows.Add(fila);
        if (Firmas == null)
        {
            HtmlTableRow fila1 = new HtmlTableRow();
            HtmlTableCell celda = new HtmlTableCell();
            Label nofirmas = new Label();
            nofirmas.Text="Este usuario no tiene firmas";
            celda.Controls.Add(nofirmas);
            fila.Cells.Add(celda);
            tabla.Rows.Add(fila1);
        }
        else
        {
            foreach (ENFirma firma in Firmas)
            {
                HtmlTableRow fila2 = new HtmlTableRow();
                HtmlTableCell celda1 = new HtmlTableCell();
                HtmlTableCell celda2 = new HtmlTableCell();
                HtmlTableCell celda3 = new HtmlTableCell();
                HyperLink link = new HyperLink();
                Label texto = new Label();
                Label fecha = new Label();
                link.Text = firma.Emisor.Usuario;
                link.NavigateUrl = "usuario.aspx?usuario=" + firma.Emisor.Usuario;
                texto.Text = firma.Texto;
                fecha.Text = firma.Fecha.ToString();
                celda1.Controls.Add(link);
                celda2.Controls.Add(fecha);
                celda3.Controls.Add(texto);
                fila2.Cells.Add(celda1);
                fila2.Cells.Add(celda2);
                fila2.Cells.Add(celda3);
                tabla.Rows.Add(fila2);
            }
            Panel_firmas.Controls.Add(tabla);
        }
    }

    protected void Button_firmar_Click(object sender, EventArgs e)
    {
        Panel_firmar.Visible = true;
    }

    protected void Button_enviar_Click(object sender, EventArgs e)
    {
        string emisor = Session["usuario"].ToString();
        string receptor = Request.QueryString["usuario"];
        ENFirma firma = new ENFirma(emisor, TextBox_firmar.Text, DateTime.Now, receptor);
        firma.Guardar();
        Panel_firmar.Visible = false;
        ObtenerFirmas(receptor);
    }

    protected void Button_limpiar_Click(object sender, EventArgs e)
    {
        TextBox_firmar.Text = "";
    }
}

