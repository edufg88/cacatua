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
        if (Session["usuario"] != null && Request.QueryString["usuario"] != null)
        {
            if (Session["usuario"].ToString() == Request.QueryString["usuario"].ToString())
            {
                extraerParametros();
                if (user != null)
                {
                    if (!Page.IsPostBack)
                    {
                        actualizarPaginacion();
                        actualizarOrdenacion();
                    }

                    ObtenerMensajes();
                }
            }
            else
            {
                Response.Redirect("usuario.aspx");
            }
        }
        else
        {
            Response.Redirect("usuarios.aspx");
        }
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

    /// <summary>
    /// Inserta la primera fila de la tabla, que es la cabecera.
    /// </summary>
    private void insertarCabecera()
    {
        // Columna Leído
        TableCell c1 = new TableCell();
        c1.CssClass = "columna1Mensajes cabeceraMensajes";
        Label l1 = new Label();
        l1.Text = Resources.I18N.Leído;
        Panel p1 = new Panel();
        p1.CssClass = "tituloGrupos";
        p1.Controls.Add(l1);
        c1.Controls.Add(p1);

        // Columna De
        TableCell c2 = new TableCell();
        c2.CssClass = "columna2Mensajes cabeceraMensajes";
        Label l3 = new Label();
        l3.Text = Resources.I18N.De;
        Panel p3 = new Panel();
        p3.Controls.Add(l3);
        c2.Controls.Add(p3);

        // Columna Fecha
        TableCell c3 = new TableCell();
        c3.CssClass = "columna3Mensajes cabeceraMensajes";
        Label l4 = new Label();
        l4.Text = Resources.I18N.Fecha;
        Panel p4 = new Panel();
        p4.Controls.Add(l4);
        c3.Controls.Add(p4);

        // Columna Mensaje
        TableCell c4 = new TableCell();
        c4.CssClass = "columna4Mensajes cabeceraMensajes";
        Label l5 = new Label();
        l5.Text = Resources.I18N.Mensaje;
        Panel p5 = new Panel();
        p5.Controls.Add(l5);
        c4.Controls.Add(p5);

        // Insertamos las columnas en la fila e insertamos la fila en la tabla.
        TableRow fila = new TableRow();
        fila.Controls.Add(c1);
        fila.Controls.Add(c2);
        fila.Controls.Add(c3);
        fila.Controls.Add(c4);
        Table_mensajes.Controls.Add(fila);
    }

    private void ObtenerMensajes()
    {
        string ordenarpor = "";
        if (ordenar == "De")
        {
            ordenarpor = "emisor";
        }
        else
        {
            ordenarpor = ordenar;
        }
        ArrayList mensajes = ENMensaje.ObtenerMensajes(user.Usuario, orden,ordenarpor,pagina,cantidad);
        Table_mensajes.Controls.Clear();

        //insertarCabecera();
        if (totalResultados >= 1)
        {
            Label_mostrandoMensajes.Text = Resources.I18N.Viendo + " " + ((pagina - 1) * cantidad + 1) + " - " + Math.Min(pagina * cantidad, totalResultados) + " " + Resources.I18N.Deminuscula + " " + totalResultados + " " + Resources.I18N.MensajesMin;
            foreach (ENMensaje mensaje in mensajes)
            {
                TableRow fila = new TableRow();

                // Celda con la imagen del usuario
                TableCell celda1 = new TableCell();
                celda1.RowSpan = 2;
                celda1.CssClass = "columna1Mensajes";
                Label l1 = new Label();
                if (mensaje.Emisor.Imagen == -1) // Comprobamos si tiene imagen activa el usuario
                {
                    l1.Text = "<img src=\"imagenes/sinImagen.png\" alt=\"Foto de usuario\"/>";
                }
                else
                {
                    l1.Text = "<img src=\"galeria/" + mensaje.Emisor.Imagen.ToString() + ".jpg\" width=\"150\" height=\"100\" alt=\"Foto de usuario\"/>";
                }
                celda1.Controls.Add(l1);

                // Celda con 2 filas para la información de la fila
                TableCell celda2 = new TableCell();
                celda2.CssClass = "columna2Mensajes";
                HyperLink link = new HyperLink();
                link.Text = mensaje.Emisor.Usuario;
                link.NavigateUrl = "usuario.aspx?usuario=" + mensaje.Emisor.Usuario;
                Label fecha = new Label();
                fecha.Text = " @ " + mensaje.Fecha.ToString();

                Label leido = new Label();
                leido.CssClass = "leido";
                leido.Text = Resources.I18N.Leído + ":  ";
                CheckBox leer = new CheckBox();
                leer.CssClass = "leer";
                leer.AutoPostBack = true;
                leer.CheckedChanged += new EventHandler(ComentarioLeido);
                leer.Attributes["id_mensaje"] = mensaje.Id.ToString();
                // Activamos o desactivamos según este leido
                if (mensaje.Leido == 1)
                {
                    // Desactivamos
                    leer.Checked = true;
                    leer.Enabled = false;
                }
                
                celda2.Controls.Add(link);
                celda2.Controls.Add(fecha);
                celda2.Controls.Add(leido);
                celda2.Controls.Add(leer);

                TableCell celda2b = new TableCell();
                // Sólo podemos borrar si estamos identificados y en nuestras firmas
                if (Session["usuario"] != null)
                {
                    if (Request["usuario"].ToString() != "")
                    {
                        if (Session["usuario"].ToString() == Request["usuario"].ToString())
                        {
                            celda2b.CssClass = "columna2bMensajes";

                            LinkButton borrar = new LinkButton();
                            borrar.CssClass = "linkButton";
                            borrar.Text = Resources.I18N.Borrar;
                            borrar.Click += new EventHandler(borrar_click);
                            borrar.Attributes["id_mensaje"] = mensaje.Id.ToString();

                            LinkButton responder = new LinkButton();
                            responder.CssClass = "linkButton";
                            responder.Text = Resources.I18N.Responder;
                            responder.Click += new EventHandler(responder_click);
                            responder.Attributes["emisor"] = mensaje.Emisor.Usuario.ToString();

                            celda2b.Controls.Add(borrar);
                            celda2b.Controls.Add(responder);
                        }
                    }
                }

                fila.Cells.Add(celda1);
                fila.Cells.Add(celda2);
                fila.Cells.Add(celda2b);

                TableRow fila2 = new TableRow();
                TableCell celda3 = new TableCell();
                celda3.CssClass = "columna3Mensajes";
                Label texto = new Label();
                texto.Text = "<p>" + mensaje.Texto + "</p>";
                celda3.Controls.Add(texto);
                fila2.Cells.Add(celda3);

                Table_mensajes.Rows.Add(fila);
                Table_mensajes.Rows.Add(fila2);

            }
        }
        else
        {
            Label_mostrandoMensajes.Text = Resources.I18N.NoMensajes;
            Panel_resultados.Visible = false;
        }
    }

    protected void borrar_click(object sender, EventArgs e)
    {
        if (sender is LinkButton)
        {
            LinkButton aux = (LinkButton)sender;
            // Borramos el mensaje seleccionado
            ENMensaje.Borrar(int.Parse(aux.Attributes["id_mensaje"]));

            if (user != null)
            {
                Response.Redirect("mensajes.aspx?usuario=" + user.Usuario);
            }
            else
            {
                Response.Redirect("usuarios.aspx");
            }
        }
    }

    protected void responder_click(object sender, EventArgs e)
    {
        if (sender is LinkButton)
        {
            LinkButton aux = (LinkButton)sender;

            if (user != null && aux.Attributes["emisor"].ToString() != "")
            {
                Response.Redirect("enviarmensaje.aspx?usuario=" + aux.Attributes["emisor"].ToString());
            }
            else
            {
                Response.Redirect("usuarios.aspx");
            }
        }
    }

    protected void ComentarioLeido(object sender, EventArgs e)
    {
        if (sender is CheckBox)
        {
            CheckBox aux = (CheckBox)sender;
            aux.Enabled = false;
            // Guardamos en la base de datos que ha leido el material
            ENMensaje mensaje = ENMensaje.Obtener(int.Parse(aux.Attributes["id_mensaje"]));
            mensaje.Leido = 1;
            mensaje.Actualizar();
        }
    }

    private void actualizarPaginacion()
    {
        Label_cantidadPagina.Text = Resources.I18N.CantidadPorPagina + ": ";

        Button_paginaAnterior.Enabled = false;
        Button_paginaSiguiente.Enabled = false;

        if (cantidad > 0)
        {
            // Calculamos la cantidad de páginas y la insertamos en el ComboBox.
            DropDownList_pagina.Items.Clear();
            int cantidadPaginas = (int)Math.Ceiling(totalResultados / (float)cantidad);
            for (int i = 1; i < cantidadPaginas + 1; i++)
            {
                ListItem p = new ListItem(i.ToString(), i.ToString());
                DropDownList_pagina.Items.Add(p);
            }

            // Comprobamos que la página no se exceda del rango y la marcamos como seleccionada.
            if (pagina > cantidadPaginas) pagina = cantidadPaginas;
            if (pagina < 1) pagina = 1;
            DropDownList_pagina.SelectedIndex = pagina - 1;

            // Según los límites de la página actual, habilitamos o no los botones de navegación.
            if (cantidadPaginas > pagina)
            {
                Button_paginaSiguiente.Enabled = true;
            }
            if (pagina > 1)
            {
                Button_paginaAnterior.Enabled = true;
            }

            // Seleccionamos la cantidad de resultados por página que haya marcada.
            for (int i = 0; i < DropDownList_cantidadPagina.Items.Count; i++)
            {
                if (DropDownList_cantidadPagina.Items[i].Value == cantidad.ToString())
                {
                    DropDownList_cantidadPagina.SelectedIndex = i;
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

        user = null;
        try
        {
            user = ENUsuario.Obtener(Request["usuario"].ToString());
        }
        catch (Exception) { }

        if (user != null)
            totalResultados = ENMensaje.Cantidad(user.Usuario);
        else
            totalResultados = 0;
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

