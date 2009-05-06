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

public partial class hilo : WebCacatUA.InterfazWeb
{
    private int pagina;
    private int cantidad;
    private int totalResultados;
    private ENHilo h;

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

            // Si es la primera vez que entra, incrementamos el número de visitas.
            if (pagina == 1 && cantidad == 10 && h != null)
            {
                h.NumVisitas++;
                h.Actualizar();
            }
        }

        if (h != null)
        {
            mostrarRespuestas();
            mostrarMigas();
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
    /// Construye el recorrido que ha seguido el usuario al pinchar en las categorías.
    /// </summary>
    private void mostrarMigas()
    {
        Label_migas.Controls.Clear();
        HyperLink labelCategoria = null;
        Label labelSeparador = null;

        ENCategoria categoria = h.Categoria;
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
                labelCategoria.CssClass = "categoriaMigaRespuestasHilos";
                labelCategoria.Text = categoriaAux.Nombre;
                labelCategoria.NavigateUrl = "foro.aspx?categoria=" + categoriaAux.Id;
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
        labelCategoria.NavigateUrl = "foro.aspx";
        Label_migas.Controls.AddAt(0, labelCategoria);

        labelSeparador = new Label();
        labelSeparador.Text = Resources.I18N.EstasAqui + ": ";
        Label_migas.Controls.AddAt(0, labelSeparador);
    }

    /// <summary>
    /// Muestra los hilos obtenidos según los parámetros.
    /// </summary>
    private void mostrarRespuestas()
    {
        Label_nombreHilo.Text = h.Titulo;

        if (totalResultados > 0)
            Label_mostrandoRespuestasHilo.Text = "Resultados " + ((pagina - 1) * cantidad + 1) + " - " + Math.Min(pagina * cantidad, totalResultados) + " de " + totalResultados + " respuestas.";
        else
            Label_mostrandoRespuestasHilo.Text = "No hay resultados con estas condiciones de búsqueda.";

        Table_respuestasHilo.Controls.Clear();
        insertarCabecera();

        if (pagina == 1)
        {
            //  Inserto el primer enlace.
        }

        //ArrayList hilos = ENHilo.Obtener(cantidad, pagina, ordenar, orden, busqueda, busqueda, ref usuario, ref fechaInicio, ref fechaFin, ref categoria);
        ArrayList respuestas = ENRespuesta.Obtener(cantidad, pagina, ref h);
        if (respuestas != null)
        {
            int contador = 0;
            foreach (ENRespuesta i in respuestas)
            {
                // Columna del título y del creado.
                TableCell c1 = new TableCell();
                c1.CssClass = "columna1RespuestaHilo cabeceraRespuestaHilo";
                Label l1 = new Label();
                l1.Text = "<a href=\"usuario.aspx?=" + i.Autor.Id + "\">" + i.Autor.Usuario + "</a>";
                l1.Text += "<br />";
                l1.Text += "<br />";
                l1.Text += "Número de respuestas: " + (i.Autor.Respuestas + i.Autor.Hilos);
                l1.Text += "<br />";
                l1.Text += "Fecha de ingreso: " + i.Autor.Fechaingreso;
                l1.Text += "<br />";
                l1.Text += "<br />";
                l1.Text += "<a href=\"enviarmensaje.aspx?usuario=" + i.Autor.Usuario + "\">[sobre]</a>";

                Panel p1 = new Panel();
                p1.CssClass = "usuarioRespuestaHilo";
                p1.Controls.Add(l1);
                c1.Controls.Add(p1);

                // Columna del número de respuestas.
                TableCell c2 = new TableCell();
                c2.CssClass = "columna2RespuestaHilo cabeceraRespuestaHilo";
                Label l3 = new Label();
                l3.Text = i.Texto;
                Panel p3 = new Panel();
                p3.CssClass = "textoRespuestaHilo";
                p3.Controls.Add(l3);
                c2.Controls.Add(p3);

                // Insertamos las columnas en la fila e insertamos la fila en la tabla.
                TableRow fila = new TableRow();
                fila.CssClass = "respuestaHilo";
                if ((contador++)%2==0)
                    fila.CssClass += " filaImparRespuestaHilo";

                fila.Controls.Add(c1);
                fila.Controls.Add(c2);
                Table_respuestasHilo.Controls.Add(fila);
            }
        }
        else
        {
            Label_mostrandoRespuestasHilo.Text = "null";
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

        h = null;
        try
        {
            h = ENHilo.Obtener(int.Parse(Request["id"].ToString()));
        }
        catch (Exception) { }

        if (h != null)
            totalResultados = ENRespuesta.Cantidad(h);
        else
            totalResultados = 0;
    }

    /// <summary>
    /// Inserta la primera fila de la tabla, que es la cabecera.
    /// </summary>
    private void insertarCabecera()
    {
        // Columna del título y del creado.
        TableCell c1 = new TableCell();
        c1.CssClass = "columna1RespuestaHilo cabeceraRespuestasHilo";
        Label l1 = new Label();
        l1.Text = Resources.I18N.Usuario;
        Panel p1 = new Panel();
        p1.CssClass = "usuarioRespuestaHilo";
        p1.Controls.Add(l1);
        c1.Controls.Add(p1);

        // Columna del número de respuestas.
        TableCell c2 = new TableCell();
        c2.CssClass = "columna2RespuestaHilo cabeceraRespuestasHilo";
        Label l3 = new Label();
        l3.Text = Resources.I18N.Respuesta;
        Panel p3 = new Panel();
        p3.CssClass = "textoRespuestaHilo";
        p3.Controls.Add(l3);
        c2.Controls.Add(p3);

        // Insertamos las columnas en la fila e insertamos la fila en la tabla.
        TableRow fila = new TableRow();
        fila.CssClass = "respuestaHilo";
        fila.Controls.Add(c1);
        fila.Controls.Add(c2);
        Table_respuestasHilo.Controls.Add(fila);
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

    protected void Button_crearRespuesta_Click(object sender, EventArgs e)
    {
        /*if (categoria != null)
            Response.Redirect("crearhilo.aspx?categoria=" + categoria.Id);
        else
            Response.Redirect("crearhilo.aspx");*/
    }

    private string calcularRuta()
    {
        string ruta = "";

        // Comprobamos el valor de cada parámetro y lo introducimos si no es su valor por defecto.
        if (pagina != 1)
            ruta += "&pagina=" + pagina;
        if (cantidad != 10)
            ruta += "&cantidad=" + cantidad;

        // Por último, introducimos el nombre del fichero al comienzo.
        ruta = "hilo.aspx?id=" + h.Id + ruta;

        return ruta;
    }
}
