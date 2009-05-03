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


public partial class grupo : WebCacatUA.InterfazWeb
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id;
        if (Request.QueryString["id"] != "")
        {
            id = int.Parse(Request.QueryString["id"]);
            ObtenerDatos(id);
        }
    }

    private void ObtenerDatos(int id)
    {
        ENGrupos grupo = ENGrupos.Obtener(id);

        Label_nombre.Text = grupo.Nombre;
        Label_Desc.Text = grupo.Descripcion;

        Panel_miembros.Controls.Clear();
        HtmlTable tabla = new HtmlTable();
        foreach (ENUsuario usuario in grupo.Usuarios)
        {
            HtmlTableRow fila = new HtmlTableRow();
            HtmlTableCell celda = new HtmlTableCell();
            HyperLink link = new HyperLink();
            link.Text = usuario.Usuario;
            link.NavigateUrl = "usuario.aspx?usuario=" + usuario.Usuario;
            celda.Controls.Add(link);
            fila.Cells.Add(celda);
            tabla.Rows.Add(fila);
        }
        Panel_miembros.Controls.Add(tabla);
    }
}