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
    private ENUsuario user = null;
    private int pagina;
    private int cantidad;
    private int totalResultados;

    protected void Page_Load(object sender, EventArgs e)
    {
        extraerParametros();
        if (user != null)
        {
            cantidad = 5;
            if (!Page.IsPostBack)
            {
                actualizarPaginacion();
            }
            ObtenerFirmas();
        }
        else
        {
            Response.Redirect("usuarios.aspx");
        }

        // Comprobamos que sólo puedas firmar si estas identificado y además que no te firmes a ti mismo
        if (Session["usuario"] == null)
        {
            Button_firmar.Visible = false;
        }
        else if (Request["usuario"].ToString() != "")
        {
            if (Session["usuario"].ToString() == Request["usuario"].ToString())
                Button_firmar.Visible = false;
            else
                Button_firmar.Visible = true;
        }

        TextBox_firmar.Focus();
    }

    /// <summary>
    /// Inserta la primera fila de la tabla, que es la cabecera.
    /// </summary>
    private void insertarCabecera()
    {
        // Columna de usuarios
        TableCell c1 = new TableCell();
        c1.CssClass = "columna1Firmas cabeceraFirmas";
        Label l1 = new Label();
        l1.Text = Resources.I18N.De;
        Panel p1 = new Panel();
        p1.CssClass = "tituloGrupos";
        p1.Controls.Add(l1);
        c1.Controls.Add(p1);

        // Columna de fecha
        TableCell c2 = new TableCell();
        c2.CssClass = "columna2Firmas cabeceraFirmas";
        Label l3 = new Label();
        l3.Text = Resources.I18N.Fecha;
        Panel p3 = new Panel();
        p3.Controls.Add(l3);
        c2.Controls.Add(p3);

        // Columna De
        TableCell c3 = new TableCell();
        c3.CssClass = "columna3Firmas cabeceraFirmas";
        Label l4 = new Label();
        l4.Text = Resources.I18N.Texto;
        Panel p4 = new Panel();
        p4.Controls.Add(l4);
        c3.Controls.Add(p4);

        // Insertamos las columnas en la fila e insertamos la fila en la tabla.
        TableRow fila = new TableRow();
        fila.Controls.Add(c1);
        fila.Controls.Add(c2);
        fila.Controls.Add(c3);
        Table_firmas.Controls.Add(fila);
    }

    public void ObtenerFirmas()
    {
        ArrayList Firmas = ENFirma.ObtenerFirmas(user.Usuario, pagina, cantidad);
        Table_firmas.Controls.Clear();

        //insertarCabecera();

        if (totalResultados < 1)
        {
            Label_mostrandoFirmas.Text = Resources.I18N.NoFirmas;
        }
        else
        {
            Label_mostrandoFirmas.Text = Resources.I18N.Viendo + " " + ((pagina - 1) * cantidad + 1) + " - " + Math.Min(pagina * cantidad, totalResultados) + " " + Resources.I18N.Deminuscula + " " + totalResultados + " " + Resources.I18N.FirmasMin + ".";
            foreach (ENFirma firma in Firmas)
            {
                TableRow fila = new TableRow();

                // Celda con la imagen del usuario
                TableCell celda1 = new TableCell();
                celda1.RowSpan = 2;
                celda1.CssClass = "columna1Firmas";
                Label l1 = new Label();
                if (firma.Emisor.Imagen == -1) // Comprobamos si tiene imagen activa el usuario
                {
                    l1.Text = "<img src=\"imagenes/sinImagen.png\" alt=\"Foto de usuario\"/>";
                }
                else
                {
                    l1.Text = "<img src=\"galeria/" + firma.Emisor.Imagen.ToString() + ".jpg\" width=\"150\" height=\"100\" alt=\"Foto de usuario\"/>";
                }
                celda1.Controls.Add(l1);

                // Celda con 2 filas para la información de la fila
                TableCell celda2 = new TableCell();
                celda2.CssClass = "columna2Firmas";

                HyperLink link = new HyperLink();
                link.Text = firma.Emisor.Usuario;
                link.NavigateUrl = "usuario.aspx?usuario=" + firma.Emisor.Usuario;                
                Label fecha = new Label();
                fecha.Text = " @ " + firma.Fecha.ToString();

                celda2.Controls.Add(link);
                celda2.Controls.Add(fecha);

                TableCell celda2b = new TableCell();
                // Sólo podemos borrar si estamos identificados y en nuestras firmas
                if (Session["usuario"] != null)
                {
                    if (Request["usuario"].ToString() != "")
                    {
                        if (Session["usuario"].ToString() == Request["usuario"].ToString())
                        {
                            celda2b.CssClass = "columna2bFirmas";

                            LinkButton borrar = new LinkButton();
                            borrar.CssClass = "linkButton";
                            borrar.Text = Resources.I18N.Borrar;
                            borrar.Click += new EventHandler(borrar_click);
                            borrar.Attributes["id_firma"] = firma.Id.ToString();

                            LinkButton responder = new LinkButton();
                            responder.CssClass = "linkButton";
                            responder.Text = Resources.I18N.Responder;
                            responder.Click += new EventHandler(responder_click);
                            responder.Attributes["emisor"] = firma.Emisor.Usuario.ToString();

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
                celda3.CssClass = "columna3Firmas";
                Label texto = new Label();
                texto.Text = "<p>" + firma.Texto + "</p>";
                celda3.Controls.Add(texto);
                fila2.Cells.Add(celda3);
                
                Table_firmas.Rows.Add(fila);
                Table_firmas.Rows.Add(fila2);
            }
        }
    }

    protected void borrar_click(object sender, EventArgs e)
    {
        if (sender is LinkButton)
        {
            LinkButton aux = (LinkButton)sender;
            // Borramos la firma seleccionada
            ENFirma.Borrar(int.Parse(aux.Attributes["id_firma"]));

            if (user != null)
            {
                Response.Redirect("firmas.aspx?usuario=" + user.Usuario);
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
                Response.Redirect("firmas.aspx?usuario=" + aux.Attributes["emisor"].ToString());
            }
            else
            {
                Response.Redirect("usuarios.aspx");
            }
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
        ObtenerFirmas();
    }

    protected void Button_limpiar_Click(object sender, EventArgs e)
    {
        TextBox_firmar.Text = "";
    }

    private void actualizarPaginacion()
    {

        Button_paginaAnterior.Enabled = false;
        Button_paginaAnterior2.Enabled = false;
        Button_paginaSiguiente.Enabled = false;
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

        user = null;
        try
        {
            user = ENUsuario.Obtener(Request["usuario"].ToString());
        }
        catch (Exception) { }

        if (user != null)
            totalResultados = ENFirma.Cantidad(user.Usuario);
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
        return calcularRuta(pagina, cantidad);
    }

    /// <summary>
    /// Calcula la ruta de parámetros para introducir en un enlace.
    /// Si los parámetros toman valores por defecto, no los añade.
    /// </summary>
    /// <param name="pagina">Número de página.</param>
    /// <returns>Devuelve la cadena de caracteres.</returns>
    private string calcularRuta(int pagina, int cantidad)
    {
        string ruta = "";

        // Comprobamos el valor de cara parámetro y lo introducimos si no es su valor por defecto.
        if (pagina != 1)
            ruta += "&pagina=" + pagina;

        // Por último, introducimos el nombre del fichero al comienzo.
        ruta = "firmas.aspx?usuario=" + user.Usuario + ruta;

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

    protected void DropDownList_pagina2_SelectedIndexChanged(object sender, EventArgs e)
    {
        pagina = int.Parse(DropDownList_pagina2.SelectedValue);
        Response.Redirect(calcularRuta());
    }
}

