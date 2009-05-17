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
using System.Text.RegularExpressions;


public partial class usuario : WebCacatUA.InterfazWeb
{
    private ENUsuario u;
    private bool editar;
    public string ocultar = "style=\"display: none\"";

    protected void Page_Load(object sender, EventArgs e)
    {
        extraerParametros();

        if (u != null)
        {
            // Comprobamos si es una petición nueva o el resultado de un evento del usuario.
            if (!Page.IsPostBack)
            {
                mostrarUsuario();

                if (editar)
                    modoEditar();
                else
                    modoNormal();

                limpiarErrores();
            }
        }
        else
        {
            Response.Redirect("usuarios.aspx");
        } 
    }

    /// <summary>
    /// Oculta todos los errores.
    /// </summary>
    private void limpiarErrores()
    {
        Label_contrasenaError.Text = "";
        Label_contrasenaAnteriorError.Text = "";
        Label_correoElectronicoError.Text = "";
        Label_dniError.Text = "";
        Label_informacionAdicionalError.Text = "";
        Label_nombreCompletoError.Text = "";
        Label_nombreUsuarioError.Text = "";
    }

    /// <summary>
    /// Mostramos el formulario para editarlo.
    /// </summary>
    private void modoEditar()
    {
        ocultar = "";
        HyperLink_editar.Visible = false;
        Button_cancelar.OnClientClick = "window.location='usuario.aspx?usuario=" + u.Usuario + "'; return false;";
        TextBox_contrasena.ReadOnly = false;
        TextBox_contrasena2.ReadOnly = false;
        TextBox_contrasenaAnterior.ReadOnly = false;
        TextBox_correoElectronico.ReadOnly = false;
        TextBox_dni.ReadOnly = false;
        TextBox_informacionAdicional.ReadOnly = false;
        TextBox_nombreCompleto.ReadOnly = false;
    }

    /// <summary>
    /// Mostramos el formulario para visualizarlo.
    /// </summary>
    private void modoNormal()
    {
        Button_cancelar.Visible = false;
        Button_guardar.Visible = false;

        // Sólo mostramos el botón editar si somos nosotros mismos.
        HyperLink_editar.Visible = false;
        if (Session["usuario"] != null)
        {
            if (u.Usuario == Session["usuario"].ToString())
            {
                HyperLink_editar.NavigateUrl = "usuario.aspx?usuario=" + u.Usuario + "&modo=editar";
                HyperLink_editar.Visible = true;
            }
        }
    }

    /// <summary>
    /// Actualiza los campos del usuario.
    /// </summary>
    private void mostrarUsuario()
    {
        TextBox_nombreUsuario.Text = u.Usuario;
        TextBox_nombreCompleto.Text = u.Nombre;
        TextBox_correoElectronico.Text = u.Correo;
        TextBox_dni.Text = u.Dni;
        TextBox_informacionAdicional.Text = u.Adicional;
    }

    /// <summary>
    /// Extraemos el usuario y el modo ("normal" o "editar").
    /// </summary>
    private void extraerParametros()
    {
        // Intentamos extraer el usuario según el nombre recibido en los parámetros.
        u = null;
        try
        {
            u = ENUsuario.Obtener(Request["usuario"].ToString());
        }
        catch (Exception) { }

        // Si no lo hemos extraido de ninguna forma, lo intentamos desde la sessión.
        if (u == null)
        {
            try
            {
                u = ENUsuario.Obtener(Session["usuario"].ToString());
            }
            catch (Exception) { }
        }


        // Sólo establecemos el modo editar si se ha indicado en los parámetros y si
        // el usuario que está visualizándose coincide con el de la sesión.
        editar = false;
        try
        {
            if (Request["modo"].ToString() == "editar")
            {
                if (u.Usuario == Session["usuario"].ToString())
                {
                    editar = true;
                }
            }
        }
        catch (Exception) { }
    }

    /// <summary>
    /// Comprueba cada uno de los campos comprobando su longitud y contenido.
    /// </summary>
    /// <returns></returns>
    private bool validarFormulario()
    {
        bool correcto = true;

        // Nombre completo.
        if (TextBox_nombreCompleto.Text.Length < 3 || TextBox_nombreCompleto.Text.Length >= 50)
        {
            Label_nombreCompletoError.Text = Resources.I18N.NombreCompletoNumeroCaracteres;
            correcto = false;
        }

        // Información adicional.
        if (TextBox_informacionAdicional.Text.Length >= 5000)
        {
            Label_informacionAdicionalError.Text = Resources.I18N.InformacionAdicionalNumeroCaracteres;
            correcto = false;
        }

        // Información adicional.
        if (TextBox_dni.Text.Length >= 20)
        {
            Label_dniError.Text = Resources.I18N.DNINumeroCaracteres;
            correcto = false;
        }

        // Correo electrónico.
        Regex email = new Regex(@"^[a-zA-Z0-9_-]{2,}@[a-zA-Z0-9_-]{2,}\.[a-zA-Z]{2,4}(\.[a-zA-Z]{2,4})?$");
        if (!email.IsMatch(TextBox_correoElectronico.Text) && TextBox_correoElectronico.Text.Length > 0)
        {
            Label_correoElectronicoError.Text = Resources.I18N.CorreoElectronicoNoValida;
            correcto = false;
        }

        // Contraseña.
        if (TextBox_contrasenaAnterior.Text != "" || TextBox_contrasena.Text != "" || TextBox_contrasena2.Text != "")
        {
            if (TextBox_contrasenaAnterior.Text != u.Contrasena)
            {
                Label_contrasenaAnteriorError.Text = Resources.I18N.ContrasenaActualIncorrecta;
                correcto = false;
            }
            else
            {
                if (TextBox_contrasena.Text != TextBox_contrasena2.Text)
                {
                    Label_contrasenaError.Text = Resources.I18N.ContrasenasNoCoinciden;
                    correcto = false;
                }
                else
                {
                    if (TextBox_contrasena.Text != "")
                    {
                        if (TextBox_contrasena.Text != filtrarCadena(TextBox_contrasena.Text))
                        {
                            Label_contrasenaError.Text = Resources.I18N.ContrasenasLetrasNumero;
                            correcto = false;
                        }
                        else
                        {
                            if (TextBox_contrasena.Text.Length < 1 || TextBox_contrasena.Text.Length >= 20)
                            {
                                Label_contrasenaError.Text = Resources.I18N.ContrasenaNumeroCaracteres;
                                correcto = false;
                            }
                        }
                    }
                }
            }
        }

        return correcto;
    }

    protected void Button_guardar_Click(object sender, EventArgs e)
    {
        if (editar)
        {
            limpiarErrores();

            TextBox_nombreCompleto.Text = filtrarCadena(TextBox_nombreCompleto.Text);
            TextBox_informacionAdicional.Text = filtrarCadena(TextBox_informacionAdicional.Text);
            TextBox_dni.Text = filtrarCadena(TextBox_dni.Text);
            TextBox_correoElectronico.Text = filtrarCadena(TextBox_correoElectronico.Text);

            if (validarFormulario())
            {
                u.Nombre = TextBox_nombreCompleto.Text;
                u.Correo = TextBox_correoElectronico.Text;
                u.Dni = TextBox_dni.Text;
                u.Adicional = TextBox_informacionAdicional.Text;
                if (TextBox_contrasena.Text != "")
                    u.Contrasena = TextBox_contrasena.Text;

                if (u.Actualizar())
                {
                    Response.Redirect("usuario.aspx");
                }
            }
        }
    }
}
