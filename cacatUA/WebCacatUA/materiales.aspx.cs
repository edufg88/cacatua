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

public partial class materiales : WebCacatUA.InterfazWeb
{
    protected void Page_Load(object sender, EventArgs e)
    {
        foreach (ENCategoria categoria in ENCategoria.CategoriasSuperiores())
        {
            Response.Write(categoria.Nombre);
        }
    }
}
