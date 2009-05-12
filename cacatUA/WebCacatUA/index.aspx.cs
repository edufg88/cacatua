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

public partial class index : WebCacatUA.InterfazWeb
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Obtenemos las respuestas.
        ArrayList materiales = ENMaterial.Obtener("fecha", false, 1, 5, new BusquedaMaterial());

        if (materiales != null)
        {
            foreach (ENMaterial i in materiales)
            {
                Label_ultimosMateriales.Text += "<a href=\"mostrarMaterial.aspx?id=" + i.Id + "\">" + i.Nombre + "</a><br />";
            }
        }

        if (Label_ultimosMateriales.Text == "")
        {

        }

        // Obtenemos los hilos.
        ENUsuario autor = null;
        ENCategoria categoria = null;
        DateTime fecha = DateTime.Now;

        ArrayList hilos = ENHilo.Obtener(5, 1, "fecharespuesta", false, "", "", ref autor, ref fecha, ref fecha, ref categoria);

        if (hilos != null)
        {
            foreach (ENHilo i in hilos)
            {
                Label_ultimosHilos.Text += "<a href=\"hilo.aspx?id=" + i.Id + "\">"+ i.Titulo + "</a><br />";
            }
        }

        if (Label_ultimosHilos.Text == "")
        {

        }

        // Obtenemos los hilos.
        ArrayList usuarios = ENUsuario.Obtener(1, 10);

        if (hilos != null)
        {
            foreach (ENUsuario i in usuarios)
            {
                Label_ultimosUsuarios.Text += "<a href=\"usuario.aspx?id=" + i.Id + "\">" + i.Usuario + "</a><br />";
            }
        }

        if (Label_ultimosUsuarios.Text == "")
        {

        }
    }
}
