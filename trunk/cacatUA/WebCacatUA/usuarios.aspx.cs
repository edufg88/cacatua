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

public partial class usuarios : WebCacatUA.InterfazWeb
{
    private int pagina;
    private int cantidad;
    private int totalResultados;   
    private string busqueda;
    private string buscar;
    private string ordenar;
    bool orden;
    ArrayList resultado;

    protected void Page_Load(object sender, EventArgs e)
    {
        extraerParametros();

        if (!Page.IsPostBack)
        {
            actualizarPaginacion();
            actualizarOrdenar();
            actualizarOrden();
            actualizarBuscar();
        }
        
        mostrarUsuarios();
    }

    /// <summary>
    /// Actualiza el valor de la variable ordenar
    /// </summary>
    private void actualizarOrdenar()
    {
        if (DropDownList_ordenar.Items.Count == 0)
        {
            DropDownList_ordenar.Items.Add(new ListItem(Resources.I18N.Usuario, "usuario"));
            DropDownList_ordenar.Items.Add(new ListItem(Resources.I18N.Nombre, "nombre"));
            DropDownList_ordenar.Items.Add(new ListItem(Resources.I18N.FechaIngreso, "fechaIngreso"));
        }

        if (ordenar == "usuario")
            DropDownList_ordenar.SelectedValue = "usuario";
        else if (ordenar == "nombre")
            DropDownList_ordenar.SelectedValue = "nombre";
        else //if (ordenar == "fechaIngreso")
            DropDownList_ordenar.SelectedValue = "fechaIngreso";

    }

    /// <summary>
    /// Actualiza el valor de la variable orden
    /// </summary>
    private void actualizarOrden()
    {
        if (DropDownList_orden.Items.Count == 0)
        {
            DropDownList_orden.Items.Add(new ListItem(Resources.I18N.ascendente, "ascendente"));
            DropDownList_orden.Items.Add(new ListItem(Resources.I18N.descendente, "descendente"));
        }

        if (orden)
            DropDownList_orden.SelectedValue = "ascendente";
        else
            DropDownList_orden.SelectedValue = "descendente";
  
    }

    /// <summary>
    /// Actualiza el valor de la variable buscar
    /// </summary>
    private void actualizarBuscar()
    {
        if (buscar == "usuario")
        {
            RadioButton_usuario.Checked = true;
        }
        else if (buscar == "nombre")
        {
            RadioButton_nombre.Checked = true;
        }
        else //if (buscar == "email")
        {
            RadioButton_correo.Checked = true;
        }
    }

    /// <summary>
    /// Calcula la cantidad de páginas según la cantidad de resultados que se están mostrando
    /// y los resultados totales y actualiza los ComboBox para que muestre la cantidad correcta.
    /// También marca la página actual como seleccionada.
    /// </summary>
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
            if (cantidadPaginas > pagina) Button_paginaSiguiente.Enabled = true;
            if (pagina > 1) Button_paginaAnterior.Enabled = true;

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
    /// Calcula la ruta de parámetros para introducir en un enlace.
    /// Los parámetros que se procesan son los propios atributos de la clase, por lo
    /// que no es necesario pasarle atributos al método.
    /// </summary>
    /// <returns></returns>
    private string calcularRuta()
    {
        return calcularRuta(pagina, cantidad, busqueda, ordenar, orden);
    }

    /// <summary>
    /// Calcula la ruta de parámetros para introducir en un enlace.
    /// Si los parámetros toman valores por defecto, no los añade.
    /// </summary>
    /// <param name="pagina">Número de página.</param>
    /// <param name="cantidad">Cantidad de resultados por página.</param>
    /// <param name="busqueda">Filtro de búsqueda.</param>
    /// <param name="ordenar">Campo por el que se ordena.</param>
    /// <param name="ascendente">Indica si es un orden ascendente o descendente.</param>
    /// <param name="usuario">Usuario que es autor del hilo.</param>
    /// <param name="Categoria">Categoría a la que pertenecen los hilos</param>
    /// <returns>Devuelve la cadena de caracteres.</returns>
    private string calcularRuta(int pagina, int cantidad, string busqueda, string ordenar, bool orden)
    {
        string ruta = "";

        // Comprobamos el valor de cada parámetro y lo introducimos si no es su valor por defecto.
        if (pagina != 1)
            ruta += "&pagina=" + pagina;
        if (cantidad != 10)
            ruta += "&cantidad=" + cantidad;
        if (busqueda != "")
            ruta += "&busqueda=" + busqueda;
        if (buscar != "" && buscar != "usuario")
            ruta += "&buscar=" + buscar;
        if (ordenar != "" && ordenar != "usuario")
            ruta += "&ordenar=" + ordenar;
        if (!orden)
            ruta += "&orden=descendente";

        // Si hemos insertado algún parámetro, introducimos un "?" y quitamos el primer "&".
        if (ruta != "")
            ruta = "?" + ruta.Substring(1);

        // Por último, introducimos el nombre del fichero al comienzo.
        ruta = "usuarios.aspx" + ruta;

        return ruta;
    }

    /// <summary>
    /// Extramos los parámetros de la URL.
    /// La página actual, la columna de ordenación, si es ascendente o descendente, el filtro de búsqueda ...
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

        cantidad = 10; 
        try
        {
            cantidad = int.Parse(Request["cantidad"].ToString());
            if (cantidad < 1)
                cantidad = 1;
        }
        catch (Exception) { }

        orden = true;
        try
        {
            if (Request["orden"].ToString() == "descendente")
                orden = false;
        }
        catch (Exception) { }

        buscar = "usuario";
        try
        {
            buscar = Request["buscar"].ToString();
        }
        catch (Exception) { }

        ordenar = "usuario";
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

        totalResultados = ENUsuario.Cantidad(busqueda, buscar, ordenar, orden);
    }

    /// <summary>
    /// Muestra en una tabla la información de los usuarios
    /// </summary>
    private void mostrarUsuarios()
    {
        resultado = ENUsuario.BuscarWeb(busqueda, buscar, ordenar, orden, pagina, cantidad);

        foreach (ENUsuario us in resultado)
        {
            if (us != null)
            {
                // Columna de la imágen activa del usuario
                TableCell c1 = new TableCell();
                c1.CssClass = "columna1Usuarios";
                Label l1 = new Label();
                if (us.Imagen == -1) // Comprobamos si tiene imagen activa el usuario
                {
                    l1.Text = "<img src=\"imagenes/sinImagen.png\" alt=\"Foto de usuario\"/>";
                }
                else
                {
                    l1.Text = "<img src=\"galeria/" + us.Imagen.ToString() + ".jpg\" width=\"150\" height=\"100\" alt=\"Foto de usuario\"/>";
                }
                Panel p1 = new Panel();
                p1.Controls.Add(l1);
                c1.Controls.Add(p1);

                // Columna de datos personales
                TableCell c2 = new TableCell();
                c2.CssClass = "columna2Usuarios";
                Label l2 = new Label();
                l2.Text = "<p><span class=\"tituloDato\">" + Resources.I18N.Usuario + ": </span><a href=\"usuario.aspx?usuario=" + us.Usuario + "\" class=\"usuario\">" + us.Usuario + "</a></p>";
                l2.CssClass = "usuario";
                Label l3 = new Label();
                l3.Text = "<p><span class=\"tituloDato\">" + Resources.I18N.Nombre + ": </span>" + us.Nombre + "</p>";
                l3.CssClass = "datoMenor";
                Label l4 = new Label();
                l4.Text = "<p><span class=\"tituloDato\">" + Resources.I18N.CorreoElectronico + ": </span>" + us.Correo + "</p>";
                l4.CssClass = "datoMenor";
                Label l5 = new Label();
                l5.Text = "<p><span class=\"tituloDato\">" + Resources.I18N.FechaIngreso + ": </span>" + us.Fechaingreso.Day.ToString() + "/" + us.Fechaingreso.Month.ToString() + "/" + us.Fechaingreso.Year.ToString() + "</p>";
                l5.CssClass = "datoMenor";
                Label l6 = new Label();
                l6.Text = "<p><span class=\"tituloDato\">" + Resources.I18N.InformacionAdicional + ": </span>" + us.Adicional + "</p>";
                l6.CssClass = "datoMenor";
                Panel p2 = new Panel();
                p2.Controls.Add(l2);
                p2.Controls.Add(l3);
                p2.Controls.Add(l4);
                p2.Controls.Add(l5);
                p2.Controls.Add(l6);
                c2.Controls.Add(p2);

                // Columna de información adicional
                TableCell c3 = new TableCell();
                c3.CssClass = "columna3Usuarios";
                Label l7 = new Label();
                l7.Text = "<p><span class=\"tituloDato\">" + Resources.I18N.CantidadImagenes + ": </span>" + us.CantidadImagenes().ToString() + "</p>";
                l7.CssClass = "datoMenor";
                Label l8 = new Label();
                l8.Text = "<p><span class=\"tituloDato\">" + Resources.I18N.CantidadFirmas + ": </span>" + us.CantidadFirmas().ToString() + "</p>";
                l8.CssClass = "datoMenor";
                Label l9 = new Label();
                l9.Text = "<p><span class=\"tituloDato\">" + Resources.I18N.CantidadEncuestas + ": </span>" + us.CantidadEncuestas().ToString() + "</p><br/>";
                l9.CssClass = "datoMenor";
                Label l10 = new Label();
                l10.Text = "<a href=\"\" class=\"enlaceMenor\">" + Resources.I18N.MensajePrivado + "</a>";
                Panel p3 = new Panel();
                p3.Controls.Add(l7);
                p3.Controls.Add(l8);
                p3.Controls.Add(l9);
                p3.Controls.Add(l10);
                c3.Controls.Add(p3);

                // Insertamos las columnas en la fila e insertamos la fila en la tabla.
                TableRow fila = new TableRow();
                fila.Controls.Add(c1);
                fila.Controls.Add(c2);
                fila.Controls.Add(c3);
                Table_usuarios.Controls.Add(fila);
            }
        }
    }

    /// <summary>
    /// Analiza los formularios extrayendo los datos de búsqueda
    /// </summary>
    private void obtenerDatosBusqueda()
    { 
        busqueda = TextBox_filtroBusqueda.Text;
        if (RadioButton_usuario.Checked == true)
        {
            buscar = "usuario";
        }
        else if (RadioButton_nombre.Checked == true)
        {
            buscar = "nombre";
        }
        else
        {
            buscar = "email";
        }
        ordenar = DropDownList_ordenar.SelectedValue;
        if (DropDownList_orden.SelectedValue == "ascendente")
            orden = true;
        else
            orden = false;
    }

    protected void Button_buscar_Click(object sender, EventArgs e)
    {
        obtenerDatosBusqueda();
        Response.Redirect(calcularRuta());
    }
    protected void DropDownList_ordenar_SelectedIndexChanged(object sender, EventArgs e)
    {
        pagina = 1;
        ordenar = DropDownList_ordenar.SelectedValue;
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

    protected void DropDownList_cantidadPagina_SelectedIndexChanged(object sender, EventArgs e)
    {
        cantidad = int.Parse(DropDownList_cantidadPagina.SelectedValue);
        pagina = 1;
        Response.Redirect(calcularRuta());
    }
    protected void Button_paginaAnterior_Click(object sender, EventArgs e)
    {
        pagina--;
        Response.Redirect(calcularRuta());
    }
    protected void DropDownList_pagina_SelectedIndexChanged(object sender, EventArgs e)
    {
        pagina = int.Parse(DropDownList_pagina.SelectedValue);
        Response.Redirect(calcularRuta());
    }
    protected void Button_paginaSiguiente_Click(object sender, EventArgs e)
    {
        pagina++;
        Response.Redirect(calcularRuta());
    }

    public int Pagina
    {
        get { return pagina; }
        set { pagina = value; }
    }
    public int Cantidad
    {
        get { return cantidad; }
        set { cantidad = value; }
    }
    public int TotalResultados
    {
        get { return totalResultados; }
        set { totalResultados = value; }
    }
    public string Busqueda
    {
        get { return busqueda; }
        set { busqueda = value; }
    }
}
