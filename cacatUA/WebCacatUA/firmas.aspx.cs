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
    ENUsuario user = null;
    private int pagina;
    private int cantidad;
    private int totalResultados;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["usuario"] != null)
        {
            cantidad = 5;
            string usuario = Request.QueryString["usuario"];
            Label_usuario.Text = usuario;
            user = ENUsuario.Obtener(usuario);
            extraerParametros();
            if (!Page.IsPostBack)
            {
                actualizarPaginacion();
            }
            ObtenerFirmas();
        }
        if (Session["usuario"] == null)
            Button_firmar.Visible = false;
        else
            Button_firmar.Visible = true;
    }

    public void ObtenerFirmas()
    {
        ArrayList Firmas = ENFirma.ObtenerFirmas(user.Usuario, pagina, cantidad);
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

        totalResultados = ENFirma.Cantidad(user.Usuario);
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

