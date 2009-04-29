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
    private ENUsuario usuario;
    private bool orden;
    private string ordenar;
    private string busqueda;


    protected void Page_Load(object sender, EventArgs e)
    {
        extraerParametros();

        Label1.Text = "Página: " + pagina;
        Label2.Text = "";

        DateTime fechaInicio = DateTime.Now;
        DateTime fechaFin = fechaInicio;

        usuario = null;
        categoria = null;

        ArrayList hilos = ENHilo.Obtener(cantidad, pagina, ordenar, orden, busqueda, busqueda, ref usuario, ref fechaInicio, ref fechaFin, ref categoria);
        if (hilos != null)
        {
            for (int i = 0; i < hilos.Count; i++)
            {
                Label2.Text += ((ENHilo)hilos[i]).Id.ToString() + " " + ((ENHilo)hilos[i]).Titulo.ToString() + @"<br />";
            }
        }
        else
        {
            Label2.Text = "null";
        }
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

        cantidad = 10; // debería ser común para todas secciones, debería estar en la sesión este valor y lo ideal es que se pudiera cambiar (pero pasando...)
        try
        {
            cantidad = int.Parse(Request["cantidad"].ToString());
        }
        catch (Exception) { }

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

        categoria = null;
        try
        {
            categoria = ENCategoria.Obtener(int.Parse(Request["categoria"].ToString()));
        }
        catch (Exception) { }

        usuario = null;
        try
        {
            usuario = ENUsuario.Obtener(int.Parse(Request["usuario"].ToString()));
        }
        catch (Exception) { }


    }
}
