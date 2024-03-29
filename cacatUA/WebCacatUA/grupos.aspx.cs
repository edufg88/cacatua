﻿using System;
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

public partial class grupos : WebCacatUA.InterfazWeb
{
    private int pagina;
    private int cantidad;
    private int totalResultados;
    private bool orden;
    private string ordenar;
    private string busqueda;
    private ENGrupos grupo = null;
    private DateTime fechaFin = DateTime.Now;
    private ENUsuario usuario = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        grupo = new ENGrupos();
        extraerParametros();

        if (!Page.IsPostBack)
        {
            actualizarPaginacion();
            actualizarOrdenacion();
            actualizarBusqueda();
            TextBox_filtroBusqueda.Focus();
        }
        mostrarGrupos();
        if (Session["usuario"] == null)
            Button_crearGrupos.Visible = false;
        else
            Button_crearGrupos.Visible = true;
    }

    /// <summary>
    /// Inserta la primera fila de la tabla, que es la cabecera.
    /// </summary>
    private void insertarCabecera()
    {
        // Columna del título y del creado.
        TableCell c1 = new TableCell();
        c1.CssClass = "columna1Grupos cabeceraGrupos";
        Label l1 = new Label();
        l1.Text = Resources.I18N.Nombre;
        Panel p1 = new Panel();
        p1.CssClass = "tituloGrupos";
        p1.Controls.Add(l1);
        c1.Controls.Add(p1);

        // Columna del número de respuestas.
        TableCell c2 = new TableCell();
        c2.CssClass = "columna2Grupos cabeceraGrupos";
        Label l3 = new Label();
        l3.Text = Resources.I18N.Descripcion;
        Panel p3 = new Panel();
        p3.Controls.Add(l3);
        c2.Controls.Add(p3);

        // Columna del número de visitas.
        TableCell c3 = new TableCell();
        c3.CssClass = "columna3Grupos cabeceraGrupos";
        Label l4 = new Label();
        l4.Text = Resources.I18N.Fecha;
        Panel p4 = new Panel();
        p4.Controls.Add(l4);
        c3.Controls.Add(p4);

        // Columna con la última respuesta.
        TableCell c4 = new TableCell();
        c4.CssClass = "columna4Grupos cabeceraGrupos";
        Label l5 = new Label();
        l5.Text = Resources.I18N.NUsuarios;
        Panel p5 = new Panel();
        p5.Controls.Add(l5);
        c4.Controls.Add(p5);

        // Insertamos las columnas en la fila e insertamos la fila en la tabla.
        TableRow fila = new TableRow();
        fila.Controls.Add(c1);
        fila.Controls.Add(c2);
        fila.Controls.Add(c3);
        fila.Controls.Add(c4);
        Table_grupos.Controls.Add(fila);
    }

    private void mostrarGrupos()
    {
        if (ordenar == "Número de Usuarios")
            ordenar = "numUsuarios";
        ArrayList Grupos = grupo.Buscar(ordenar,pagina,cantidad,orden,0,0,fechaFin,ref usuario);
        
        Table_grupos.Controls.Clear();
        insertarCabecera();

        if (totalResultados > 0)
        {
            Label_mostrandoGrupos.Text = Resources.I18N.Resultados + " " + ((pagina - 1) * cantidad + 1) + " - " + Math.Min(pagina * cantidad, totalResultados) + " " + Resources.I18N.Deminuscula + " " + totalResultados + " " + Resources.I18N.GruposMin + " " + Resources.I18N.EncontradosMin + ".";

            foreach (ENGrupos group in Grupos)
            {
                TableRow fila2 = new TableRow();
                TableCell celda1 = new TableCell();
                celda1.CssClass = "columna1Grupos";
                TableCell celda2 = new TableCell();
                celda2.CssClass = "columna2Grupos";
                TableCell celda3 = new TableCell();
                celda3.CssClass = "columna3Grupos";
                TableCell celda4 = new TableCell();
                celda4.CssClass = "columna4Grupos";
                HyperLink link = new HyperLink();
                Label texto = new Label();
                Label fecha = new Label();
                Label numUsuarios = new Label();
                link.Text = group.Nombre;
                link.NavigateUrl = "grupo.aspx?id=" + group.Id;
                texto.Text = group.Descripcion;
                fecha.Text = group.Fecha.ToString();
                numUsuarios.Text = group.NumUsuarios.ToString();
                celda1.Controls.Add(link);
                celda2.Controls.Add(texto);
                celda3.Controls.Add(fecha);
                celda4.Controls.Add(numUsuarios);
                fila2.Cells.Add(celda1);
                fila2.Cells.Add(celda2);
                fila2.Cells.Add(celda3);
                fila2.Cells.Add(celda4);
                Table_grupos.Rows.Add(fila2);
            }
        }
        else
        {
           Label_mostrandoGrupos.Text = Resources.I18N.SinResultados;
           Panel_resultados.Visible = false;
        }
    }

    /// <summary>
    /// Calcula la cantidad de páginas según la cantidad de resultados que se están mostrando
    /// y los resultados totales y actualiza los ComboBox para que muestre la cantidad correcta.
    /// También marca la página actual como seleccionada.
    /// </summary>
    private void actualizarPaginacion()
    {
        Label_cantidadPagina2.Text = Resources.I18N.CantidadPorPagina + ": ";

        Button_paginaAnterior2.Enabled = false;
        Button_paginaSiguiente2.Enabled = false;
        if (cantidad > 0)
        {
            // Calculamos la cantidad de páginas y la insertamos en el ComboBox.
            DropDownList_pagina2.Items.Clear();
            int cantidadPaginas = (int)Math.Ceiling(totalResultados / (float)cantidad);
            for (int i = 1; i < cantidadPaginas + 1; i++)
            {
                ListItem p = new ListItem(i.ToString(), i.ToString());
                DropDownList_pagina2.Items.Add(p);
            }

            // Comprobamos que la página no se exceda del rango y la marcamos como seleccionada.
            if (pagina > cantidadPaginas) pagina = cantidadPaginas;
            if (pagina < 1) pagina = 1;
            DropDownList_pagina2.SelectedIndex = pagina - 1;

            // Según los límites de la página actual, habilitamos o no los botones de navegación.
            if (cantidadPaginas > pagina) 
            {
                Button_paginaSiguiente2.Enabled = true;
            }
            if (pagina > 1) 
            {
                Button_paginaAnterior2.Enabled = true;
            }

            // Seleccionamos la cantidad de resultados por página que haya marcada.
            for (int i = 0; i < DropDownList_cantidadPagina2.Items.Count; i++)
            {
                if (DropDownList_cantidadPagina2.Items[i].Value == cantidad.ToString())
                {
                    DropDownList_cantidadPagina2.SelectedIndex = i;
                    break;
                }
            }
        }
    }

    private void actualizarOrdenacion()
    {
        Label_ordenarPor.Text = Resources.I18N.OrdenarPor + ": ";
        DropDownList_ordenar.Items.Add(new ListItem(Resources.I18N.Nombre, "nombre"));
        DropDownList_ordenar.Items.Add(new ListItem(Resources.I18N.Fecha, "fecha"));
        DropDownList_ordenar.Items.Add(new ListItem(Resources.I18N.NUsuarios, "Número de Usuarios"));

        DropDownList_ordenar.SelectedIndex = 0;
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

        orden = true;
        try
        {
            if (Request["orden"].ToString() == "descendente")
                orden = false;
        }
        catch (Exception) { }

        ordenar = "nombre";
        try
        {
            ordenar = Request["ordenar"].ToString();
            if (ordenar == "numUsuarios")
            {
                ordenar = "Número de Usuarios";
            }
        }
        catch (Exception) { }

        busqueda = "";
        try
        {
            busqueda = Request["busqueda"].ToString();
        }
        catch (Exception) { }


        DateTime fechaInicio = new DateTime(2008, 9, 1);

        grupo.Nombre = busqueda;
        grupo.Fecha = fechaInicio;

        ENUsuario usuario = null;

        totalResultados = grupo.Cantidad(0,0,fechaFin,ref usuario);
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
    /// <returns>Devuelve la cadena de caracteres.</returns>
    private string calcularRuta(int pagina, int cantidad, string busqueda, string ordenar, bool ascendente)
    {
        string ruta = "";

        // Comprobamos el valor de cada parámetro y lo introducimos si no es su valor por defecto.
        if (pagina != 1)
            ruta += "&pagina=" + pagina;
        if (cantidad != 10)
            ruta += "&cantidad=" + cantidad;
        if (busqueda != "")
            ruta += "&busqueda=" + busqueda;
        if (ordenar != "" && ordenar != "nombre")
            ruta += "&ordenar=" + ordenar;
        if (!ascendente)
            ruta += "&orden=descendente";

        // Si hemos insertado algún parámetro, introducimos un "?" y quitamos el primer "&".
        if (ruta != "")
            ruta = "?" + ruta.Substring(1);

        // Por último, introducimos el nombre del fichero al comienzo.
        ruta = "grupos.aspx" + ruta;

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
        if (DropDownList_ordenar.SelectedValue == "Número de Usuarios")
            ordenar = "numUsuarios";
        else
            ordenar = DropDownList_ordenar.SelectedValue;
        Response.Redirect(calcularRuta());
    }

    protected void Button_crearGrupos_Click(object sender, EventArgs e)
    {
        Response.Redirect("creargrupo.aspx");
    }
}

