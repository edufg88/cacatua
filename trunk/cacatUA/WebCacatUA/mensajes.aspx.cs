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

public partial class mensajes : WebCacatUA.InterfazWeb
{
    private int pagina;
    private int cantidad;
    private int totalResultados;
    private bool orden;
    private string ordenar;
    private ENUsuario user;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["usuario"].ToString() != "")
        {
            string usuario = Request.QueryString["usuario"].ToString();
            user = ENUsuario.Obtener(usuario);
        }

        extraerParametros();
        if (!Page.IsPostBack)
        {
            actualizarPaginacion();
            actualizarOrdenacion();
        }
        ObtenerMensajes();
    }

    private void actualizarOrdenacion()
    {
        Label_ordenarPor.Text = Resources.I18N.OrdenarPor + ": ";
        DropDownList_ordenar.Items.Add(new ListItem(Resources.I18N.autormensaje, "De"));
        DropDownList_ordenar.Items.Add(new ListItem(Resources.I18N.Fecha, "Fecha"));

        DropDownList_ordenar.SelectedIndex = 1;
        for (int i = 0; i < DropDownList_ordenar.Items.Count; i++)
            if (DropDownList_ordenar.Items[i].Value == ordenar)
                DropDownList_ordenar.SelectedIndex = i;

        DropDownList_orden.Items.Add(new ListItem(Resources.I18N.ascendente, "ascendente"));
        DropDownList_orden.Items.Add(new ListItem(Resources.I18N.descendente, "descendente"));
        if (orden)
            DropDownList_orden.SelectedIndex = 0;
        else
            DropDownList_orden.SelectedIndex = 1;
    }

    private void ObtenerMensajes()
    {
        string ordenarpor = "";
        Label_mostrandoMensajes.Text = "Viendo " + ((pagina - 1) * cantidad + 1) + " - " + Math.Min(pagina * cantidad, totalResultados) + " de " + totalResultados + " mensajes privados.";
        if (ordenar == "De")
        {
            ordenarpor = "emisor";
        }
        else
        {
            ordenarpor = ordenar;
        }
        ArrayList mensajes = ENMensaje.ObtenerMensajes(user.Usuario, orden,ordenarpor,pagina,cantidad);
        Panel_mensajes.Controls.Clear();
        HtmlTable tabla = new HtmlTable();
        if (mensajes == null)
        {
            HtmlTableRow fila1 = new HtmlTableRow();
            HtmlTableCell celda = new HtmlTableCell();
            Label nofirmas = new Label();
            nofirmas.Text = "No tengo mensajes privados";
            celda.Controls.Add(nofirmas);
            fila1.Cells.Add(celda);
            tabla.Rows.Add(fila1);
            Panel_mensajes.Controls.Add(tabla);
        }
        else
        {
            HtmlTableRow fila = new HtmlTableRow();
            HtmlTableCell celdax = new HtmlTableCell();
            HtmlTableCell celday = new HtmlTableCell();
            HtmlTableCell celdaz = new HtmlTableCell();
            Label men = new Label();
            Label fech = new Label();
            Label usuarios = new Label();
            men.Text = Resources.I18N.Mensaje;
            fech.Text = Resources.I18N.Fecha;
            usuarios.Text = Resources.I18N.autormensaje;
            celdax.Controls.Add(usuarios);
            celday.Controls.Add(fech);
            celdaz.Controls.Add(men);
            fila.Cells.Add(celdax);
            fila.Cells.Add(celday);
            fila.Cells.Add(celdaz);
            tabla.Rows.Add(fila);
            foreach (ENMensaje mensaje in mensajes)
            {
                HtmlTableRow fila2 = new HtmlTableRow();
                HtmlTableCell celda1 = new HtmlTableCell();
                HtmlTableCell celda2 = new HtmlTableCell();
                HtmlTableCell celda3 = new HtmlTableCell();
                HyperLink link = new HyperLink();
                Label texto = new Label();
                Label fecha = new Label();
                link.Text = mensaje.Emisor.Usuario;
                link.NavigateUrl = "usuario.aspx?usuario=" + mensaje.Emisor.Usuario;
                texto.Text = mensaje.Texto;
                fecha.Text = mensaje.Fecha.ToString();
                celda1.Controls.Add(link);
                celda2.Controls.Add(fecha);
                celda3.Controls.Add(texto);
                fila2.Cells.Add(celda1);
                fila2.Cells.Add(celda2);
                fila2.Cells.Add(celda3);
                tabla.Rows.Add(fila2);
            }
            Panel_mensajes.Controls.Add(tabla);
        }
    }

    private void actualizarPaginacion()
    {
        Label_cantidadPagina.Text = Resources.I18N.CantidadPorPagina + ": ";
        Label_cantidadPagina2.Text = Resources.I18N.CantidadPorPagina + ": ";

        Button_paginaAnterior.Enabled = false;
        Button_paginaSiguiente.Enabled = false;
        Button_paginaAnterior2.Enabled = false;
        Button_paginaSiguiente2.Enabled = false;
        if (cantidad > 0)
        {
            // Calculamos la cantidad de páginas y la insertamos en el ComboBox.
            DropDownList_pagina.Items.Clear();
            DropDownList_pagina2.Items.Clear();
            int cantidadPaginas = (int)Math.Ceiling(totalResultados / (float)cantidad);
            for (int i = 1; i < cantidadPaginas + 1; i++)
            {
                ListItem p = new ListItem(i.ToString(), i.ToString());
                DropDownList_pagina.Items.Add(p);
                DropDownList_pagina2.Items.Add(p);
            }

            // Comprobamos que la página no se exceda del rango y la marcamos como seleccionada.
            if (pagina > cantidadPaginas) pagina = cantidadPaginas;
            if (pagina < 1) pagina = 1;
            DropDownList_pagina.SelectedIndex = pagina - 1;
            DropDownList_pagina2.SelectedIndex = pagina - 1;

            // Según los límites de la página actual, habilitamos o no los botones de navegación.
            if (cantidadPaginas > pagina)
            {
                Button_paginaSiguiente.Enabled = true;
                Button_paginaSiguiente2.Enabled = true;
            }
            if (pagina > 1)
            {
                Button_paginaAnterior.Enabled = true;
                Button_paginaAnterior2.Enabled = true;
            }

            // Seleccionamos la cantidad de resultados por página que haya marcada.
            for (int i = 0; i < DropDownList_cantidadPagina.Items.Count; i++)
            {
                if (DropDownList_cantidadPagina.Items[i].Value == cantidad.ToString())
                {
                    DropDownList_cantidadPagina.SelectedIndex = i;
                    DropDownList_cantidadPagina2.SelectedIndex = i;
                    break;
                }
            }
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
            if (pagina < 1)
                pagina = 1;
        }
        catch (Exception) { }

        cantidad = 5; // debería ser común para todas secciones, debería estar en la sesión este valor y lo ideal es que se pudiera cambiar (pero pasando...)
        try
        {
            cantidad = int.Parse(Request["cantidad"].ToString());
            if (cantidad < 1)
                cantidad = 1;
        }
        catch (Exception) { }

        orden = false;
        try
        {
            if (Request["orden"].ToString() == "ascendente")
                orden = true;
        }
        catch (Exception) { }

        ordenar = "Fecha";
        try
        {
            if (Request["ordenar"].ToString() == "emisor")
                ordenar = "De";
        }
        catch (Exception) { }

        totalResultados = ENMensaje.Cantidad(user.Usuario);
    }

    /// <summary>
    /// Calcula la ruta de parámetros para introducir en un enlace.
    /// Los parámetros que se procesan son los propios atributos de la clase, por lo
    /// que no es necesario pasarle atributos al método.
    /// </summary>
    /// <returns></returns>
    private string calcularRuta()
    {
        return calcularRuta(pagina, cantidad, ordenar, orden);
    }

    /// <summary>
    /// Calcula la ruta de parámetros para introducir en un enlace.
    /// Si los parámetros toman valores por defecto, no los añade.
    /// </summary>
    /// <param name="pagina">Número de página.</param>
    /// <param name="cantidad">Cantidad de resultados por página.</param>
    /// <param name="ordenar">Campo por el que se ordena.</param>
    /// <param name="ascendente">Indica si es un orden ascendente o descendente.</param>
    /// <returns>Devuelve la cadena de caracteres.</returns>
    private string calcularRuta(int pagina, int cantidad,string ordenar, bool ascendente)
    {
        string ruta = "";

        // Comprobamos el valor de cara parámetro y lo introducimos si no es su valor por defecto.
        if (pagina != 1)
            ruta += "&pagina=" + pagina;
        if (cantidad != 5)
            ruta += "&cantidad=" + cantidad;
        if (ordenar != "" && ordenar != "Fecha")
            ruta += "&ordenar=emisor";
        if (ascendente)
            ruta += "&orden=ascendente";

        // Por último, introducimos el nombre del fichero al comienzo.
        ruta = "mensajes.aspx?usuario=" + user.Usuario + ruta;

        return ruta;
    }

    protected void Button_paginaAnterior_Click(object sender, EventArgs e)
    {
        pagina--;
        Response.Redirect(calcularRuta());
    }

    protected void Button_paginaSiguiente_Click(object sender, EventArgs e)
    {
        pagina++;
        Response.Redirect(calcularRuta());
    }

    protected void DropDownList_pagina_SelectedIndexChanged(object sender, EventArgs e)
    {
        pagina = int.Parse(DropDownList_pagina.SelectedValue);
        Response.Redirect(calcularRuta());
    }

    protected void DropDownList_cantidadPagina_SelectedIndexChanged(object sender, EventArgs e)
    {
        cantidad = int.Parse(DropDownList_cantidadPagina.SelectedValue);
        pagina = 1;
        Response.Redirect(calcularRuta());
    }

    protected void DropDownList_pagina2_SelectedIndexChanged(object sender, EventArgs e)
    {
        pagina = int.Parse(DropDownList_pagina2.SelectedValue);
        Response.Redirect(calcularRuta());
    }

    protected void DropDownList_cantidadPagina2_SelectedIndexChanged(object sender, EventArgs e)
    {
        cantidad = int.Parse(DropDownList_cantidadPagina2.SelectedValue);
        pagina = 1;
        Response.Redirect(calcularRuta());
    }


    protected void DropDownList_orden_SelectedIndexChanged(object sender, EventArgs e)
    {
        pagina = 1;
        if (DropDownList_orden.SelectedValue == "ascendente")
            orden = true;
        else
            orden = false;
        Response.Redirect(calcularRuta());
    }

    protected void DropDownList_ordenar_SelectedIndexChanged(object sender, EventArgs e)
    {
        pagina = 1;
        ordenar = DropDownList_ordenar.SelectedValue;
        Response.Redirect(calcularRuta());
    }
}

