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
    private int totalResultados;
    private ENCategoria categoria;
    private ENUsuario usuario;
    private bool orden;
    private string ordenar;
    private string busqueda;

    private void escribir(string cadena)
    {
        const string fic = @"C:\log.txt";     
        System.IO.StreamWriter sw = new System.IO.StreamWriter(fic, true);
        sw.WriteLine(cadena);
        sw.Close();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        extraerParametros();

        if (!Page.IsPostBack)
        {
            actualizarPaginacion();
            actualizarOrdenacion();
            actualizarBusqueda();
        }

        mostrarHilos();
        mostrarMigas();
        mostrarCategorias();
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

    private void actualizarOrdenacion()
    {
        Label_ordenarPor.Text = Resources.I18N.OrdenarPor + ": ";
        DropDownList_ordenar.Items.Add(new ListItem(Resources.I18N.titulominusculas, "titulo"));
        DropDownList_ordenar.Items.Add(new ListItem(Resources.I18N.fechacreacion, "fechacreacion"));
        DropDownList_ordenar.Items.Add(new ListItem(Resources.I18N.fecharespuesta, "fecharespuesta"));
        DropDownList_ordenar.Items.Add(new ListItem(Resources.I18N.respuestasminusculas, "respuestas"));
        DropDownList_ordenar.Items.Add(new ListItem(Resources.I18N.visitasminusculas, "visitas"));

        DropDownList_ordenar.SelectedIndex = 2;
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

    private void actualizarBusqueda()
    {
        TextBox_filtroBusqueda.Text = busqueda;
    }

    /// <summary>
    /// Muestra las categorías de la categoría padre en la navegación izquierda.
    /// </summary>
    private void mostrarCategorias()
    {
        ArrayList categorias = null;
        if (categoria != null)
        {
            categorias = categoria.ObtenerHijos();
        }
        else
        {
            categorias = ENCategoria.CategoriasSuperiores();
        }

        Panel_categorias.Controls.Clear();
        foreach (ENCategoria c in categorias)
        {
            HyperLink labelCategoria = new HyperLink();
            labelCategoria.CssClass = "categoriaForo";
            labelCategoria.Text = c.Nombre;
            labelCategoria.ID = "categoria" + c.Id;
            labelCategoria.NavigateUrl = calcularRuta(1, cantidad, busqueda, ordenar, orden, usuario, c);

            Panel_categorias.Controls.Add(labelCategoria);
        }

        if (Panel_categorias.Controls.Count == 0)
        {
            Label sinCategorias = new Label();
            sinCategorias.Text = Resources.I18N.NoHayCategorias;
            sinCategorias.CssClass = "categoriaForo";
            Panel_categorias.Controls.Add(sinCategorias);
        }
    }

    /// <summary>
    /// Construye el recorrido que ha seguido el usuario al pinchar en las categorías.
    /// </summary>
    private void mostrarMigas()
    {
        Label_migas.Controls.Clear();
        HyperLink labelCategoria = null;
        Label labelSeparador = null;

        if (categoria != null)
        {
            ENCategoria categoriaAux = categoria;
            do
            {
                if (Label_migas.Controls.Count > 0)
                {
                    labelSeparador = new Label();
                    labelSeparador.Text = " > ";
                    Label_migas.Controls.AddAt(0, labelSeparador);
                }
                labelCategoria = new HyperLink();
                labelCategoria.CssClass = "categoriaMigaForo";
                labelCategoria.Text = categoriaAux.Nombre;
                labelCategoria.NavigateUrl = calcularRuta(1, cantidad, busqueda, ordenar, orden, usuario, categoriaAux);
                Label_migas.Controls.AddAt(0, labelCategoria);

                categoriaAux = ENCategoria.Obtener(categoriaAux.Padre);
            }
            while (categoriaAux != null);
        }

        if (Label_migas.Controls.Count > 0)
        {
            labelSeparador = new Label();
            labelSeparador.Text = " > ";
            Label_migas.Controls.AddAt(0, labelSeparador);
        }
        labelCategoria = new HyperLink();
        labelCategoria.CssClass = "categoriaMigaForo";
        labelCategoria.Text = Resources.I18N.Foro;
        labelCategoria.NavigateUrl = calcularRuta(1, cantidad, busqueda, ordenar, orden, usuario, (ENCategoria) null);
        Label_migas.Controls.AddAt(0, labelCategoria);

        labelSeparador = new Label();
        labelSeparador.Text = Resources.I18N.EstasAqui + ": ";
        Label_migas.Controls.AddAt(0, labelSeparador);
    }

    /// <summary>
    /// Muestra los hilos obtenidos según los parámetros.
    /// </summary>
    private void mostrarHilos()
    {
        if (totalResultados > 0)
            Label_mostrandoForo.Text = "Resultados " + ((pagina - 1) * cantidad + 1) + " - " + Math.Min(pagina * cantidad, totalResultados) + " de " + totalResultados + " hilos encontrados.";
        else
            Label_mostrandoForo.Text = "No hay resultados con estas condiciones de búsqueda.";

        Table_hilosForo.Controls.Clear();
        insertarCabecera();

        DateTime fechaInicio = DateTime.Now;
        DateTime fechaFin = fechaInicio;

        ArrayList hilos = ENHilo.Obtener(cantidad, pagina, ordenar, orden, busqueda, busqueda, ref usuario, ref fechaInicio, ref fechaFin, ref categoria);
        if (hilos != null)
        {
            foreach (ENHilo i in hilos)
            {
                // Columna del título y del creado.
                TableCell c1 = new TableCell();
                c1.CssClass = "columna1HiloForo";
                Label l1 = new Label();
                l1.Text = "<a href=\"hilo.aspx?id=" + i.Id + "\" class=\"enlaceHiloForo\">" + i.Titulo + "</a>";
                Panel p1 = new Panel();
                p1.CssClass = "tituloHiloForo";
                p1.Controls.Add(l1);
                c1.Controls.Add(p1);
                Label l2 = new Label();
                l2.Text = Resources.I18N.creadoPor +" <a href=\"usuario.aspx?id=" + i.Autor.Id + "\" class=\"autorForo\">" + i.Autor.Usuario + "</a>, " + i.Fecha;
                Panel p2 = new Panel();
                p2.CssClass = "creadoHiloForo";
                p2.Controls.Add(l2);
                c1.Controls.Add(p2);

                // Columna del número de respuestas.
                TableCell c2 = new TableCell();
                c2.CssClass = "columna2HiloForo";
                Label l3 = new Label();
                l3.Text = i.NumRespuestas.ToString();
                Panel p3 = new Panel();
                p3.CssClass = "respuestasHiloForo";
                p3.Controls.Add(l3);
                c2.Controls.Add(p3);

                // Columna del número de visitas.
                TableCell c3 = new TableCell();
                c3.CssClass = "columna3HiloForo";
                Label l4 = new Label();
                l4.Text = i.NumVisitas.ToString();
                Panel p4 = new Panel();
                p4.CssClass = "visitasHiloForo";
                p4.Controls.Add(l4);
                c3.Controls.Add(p4);

                // Columna con la última respuesta.
                TableCell c4 = new TableCell();
                c4.CssClass = "columna4HiloForo";
                Label l5 = new Label();
                if (i.NumRespuestas > 0)
                    l5.Text = Resources.I18N.por + " <a href=\"usuario.aspx?id=" + i.AutorUltimaRespuesta.Id + "\" class=\"autorRespuesta\">" + i.AutorUltimaRespuesta.Usuario + "</a><br />" + i.FechaUltimaRespuesta;
                else
                    l5.Text = Resources.I18N.nadie;
                Panel p5 = new Panel();
                p5.CssClass = "ultimaRespuestaHiloForo";
                p5.Controls.Add(l5);
                c4.Controls.Add(p5);

                // Insertamos las columnas en la fila e insertamos la fila en la tabla.
                TableRow fila = new TableRow();
                fila.CssClass = "hiloForo";
                fila.Controls.Add(c1);
                fila.Controls.Add(c2);
                fila.Controls.Add(c3);
                fila.Controls.Add(c4);
                Table_hilosForo.Controls.Add(fila);
            }
        }
        else
        {
            Label_mostrandoForo.Text = "null";
        }
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

        cantidad = 10; // debería ser común para todas secciones, debería estar en la sesión este valor y lo ideal es que se pudiera cambiar (pero pasando...)
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

        ordenar = "fecharespuesta";
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


        DateTime fechaInicio = DateTime.Now;
        DateTime fechaFin = fechaInicio;

        totalResultados = ENHilo.Cantidad(busqueda, busqueda, ref usuario, ref fechaInicio, ref fechaFin, ref categoria);
    }

    /// <summary>
    /// Inserta la primera fila de la tabla, que es la cabecera.
    /// </summary>
    private void insertarCabecera()
    {
                // Columna del título y del creado.
                TableCell c1 = new TableCell();
                c1.CssClass = "columna1HiloForo cabeceraForo";
                Label l1 = new Label();
                l1.Text = Resources.I18N.Hilos;
                Panel p1 = new Panel();
                p1.CssClass = "tituloHiloForo";
                p1.Controls.Add(l1);
                c1.Controls.Add(p1);

                // Columna del número de respuestas.
                TableCell c2 = new TableCell();
                c2.CssClass = "columna2HiloForo cabeceraForo";
                Label l3 = new Label();
                l3.Text = Resources.I18N.Respuestas;
                Panel p3 = new Panel();
                p3.CssClass = "respuestasHiloForo";
                p3.Controls.Add(l3);
                c2.Controls.Add(p3);

                // Columna del número de visitas.
                TableCell c3 = new TableCell();
                c3.CssClass = "columna3HiloForo cabeceraForo";
                Label l4 = new Label();
                l4.Text = Resources.I18N.Visitas;
                Panel p4 = new Panel();
                p4.CssClass = "visitasHiloForo";
                p4.Controls.Add(l4);
                c3.Controls.Add(p4);

                // Columna con la última respuesta.
                TableCell c4 = new TableCell();
                c4.CssClass = "columna4HiloForo cabeceraForo";
                Label l5 = new Label();
                l5.Text = Resources.I18N.UltimaRespuesta;
                Panel p5 = new Panel();
                p5.CssClass = "ultimaRespuestaHiloForo";
                p5.Controls.Add(l5);
                c4.Controls.Add(p5);

                // Insertamos las columnas en la fila e insertamos la fila en la tabla.
                TableRow fila = new TableRow();
                fila.CssClass = "hiloForo";
                fila.Controls.Add(c1);
                fila.Controls.Add(c2);
                fila.Controls.Add(c3);
                fila.Controls.Add(c4);
                Table_hilosForo.Controls.Add(fila);
    }

    /// <summary>
    /// Calcula la ruta de parámetros para introducir en un enlace.
    /// Los parámetros que se procesan son los propios atributos de la clase, por lo
    /// que no es necesario pasarle atributos al método.
    /// </summary>
    /// <returns></returns>
    private string calcularRuta()
    {
        return calcularRuta(pagina, cantidad, busqueda, ordenar, orden, usuario, categoria);
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
    private string calcularRuta(int pagina, int cantidad, string busqueda, string ordenar, bool ascendente, ENUsuario usuario, ENCategoria categoria)
    {
        string ruta = "";

        // Comprobamos el valor de cada parámetro y lo introducimos si no es su valor por defecto.
        if (pagina != 1)
            ruta += "&pagina=" + pagina;
        if (cantidad != 10)
            ruta += "&cantidad=" + cantidad;
        if (busqueda != "")
            ruta += "&busqueda=" + busqueda;
        if (ordenar != "" && ordenar != "fecharespuesta")
            ruta += "&ordenar=" + ordenar;
        if (ascendente)
            ruta += "&orden=ascendente";
        if (usuario != null)
            ruta += "&usuario=" + usuario.Id;
        if (categoria != null)
            ruta += "&categoria=" + categoria.Id;

        // Si hemos insertado algún parámetro, introducimos un "?" y quitamos el primer "&".
        if (ruta != "")
            ruta = "?" + ruta.Substring(1);

        // Por último, introducimos el nombre del fichero al comienzo.
        ruta = "foro.aspx" + ruta;

        return ruta;
    }

    protected void Button_buscar_Click(object sender, EventArgs e)
    {
        busqueda = TextBox_filtroBusqueda.Text;
        Response.Redirect(calcularRuta());
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

    protected void Button_crearHiloForo_Click(object sender, EventArgs e)
    {
        if (categoria != null)
            Response.Redirect("crearhilo.aspx?categoria=" + categoria.Id);
        else
            Response.Redirect("crearhilo.aspx");
    }
}
