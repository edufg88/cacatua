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

public partial class foro : WebCacatUA.InterfazWeb
{
    private int pagina;
    private int cantidad;
    private ENCategoria categoria;
    private bool orden;
    private string ordenar;
    private string busqueda;

    protected void Page_Load(object sender, EventArgs e)
    {
        extraerParametros();

        Label1.Text = "Página: " + pagina;
    }

    /// <summary>
    /// Extramos los parámetros de la URL.
    /// La página actual, la columna de ordenador, si es ascendente o descendente, el filtro de búsqueda ...
    /// </summary>
    private void extraerParametros()
    {
        pagina = 1;
        try
        {
            pagina = int.Parse(Request["pagina"].ToString());
        }
        catch (Exception) { }

        cantidad = 5; // debería ser común para todas secciones, debería estar en la sesión este valor y lo ideal es que se pudiera cambiar (pero pasando...)

        orden = true;
        try
        {
            if (Request["orden"].ToString() == "descendente")
                orden = false;
        }
        catch (Exception) { }

        ordenar = "";
        try
        {
            ordenar = Request["ordenar"].ToString();
        }
        catch (Exception) { }

        busqueda = "";
        try
        {
            busqueda = Request["busqueda"].ToString();
        }
        catch (Exception) { }


    }
}
