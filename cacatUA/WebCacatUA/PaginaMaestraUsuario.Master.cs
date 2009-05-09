using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libreria;

namespace WebCacatUA
{
    public partial class PaginaMaestraUsuario : System.Web.UI.MasterPage
    {
        private ENUsuario usuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            extraerParametros();

            if (usuario != null)
            {
                actualizarDatosUsuario();
                actualizarSeccionEncuestas();
                actualizarSeccionGrupos();
            }
            else
            {
                Response.Redirect("usuarios.aspx");
            }            
        }

        private void actualizarSeccionEncuestas()
        {
            ArrayList grupos = ENGrupos.Obtener(usuario);

            Label label = new Label();
            label.Text = "No está apuntado a ningún grupo.";
            label.CssClass = "ya veremos que class";

            Panel_gruposUsuario.Controls.Add(label);
            if (grupos != null)
            {
                if (grupos.Count > 0)
                {
                    label.CssClass = "ya veremos que class";

                    Panel_gruposUsuario.Controls.Clear();
                    foreach (ENGrupos i in grupos)
                    {
                        HyperLink enlace = new HyperLink();
                        enlace.Text = i.Nombre + " (" + i.NumUsuarios + " " + "miembros" + ")";
                        enlace.NavigateUrl = "grupo.aspx?id=" + i.Id;
                        Panel_gruposUsuario.Controls.Add(enlace);
                    }
                }
            }
        }

        private void actualizarSeccionGrupos()
        {

        }

        /// <summary>
        /// Actualizamos la columna izquierda con los datos del usuario, así como los
        /// enlaces que llevan a cada una de las secciones.
        /// </summary>
        private void actualizarDatosUsuario()
        {
            Label_nombreUsuario.Text = usuario.Usuario;

            HyperLink_datosUsuario.NavigateUrl = "usuario.aspx?usuario=" + usuario.Usuario;
            HyperLink_datosUsuario.Text = "Datos del usuario";

            HyperLink_encuestasUsuario.NavigateUrl = "encuestas.aspx?usuario=" + usuario.Usuario;
            HyperLink_encuestasUsuario.Text = "Encuestas" + " (" + usuario.CantidadEncuestas() + ")";

            HyperLink_firmasUsuario.NavigateUrl = "firmas.aspx?usuario=" + usuario.Usuario;
            HyperLink_firmasUsuario.Text = "Firmas" + " (" + usuario.CantidadFirmas() + ")";

            HyperLink_galeriaUsuario.NavigateUrl = "galeria.aspx?usuario=" + usuario.Usuario;
            HyperLink_galeriaUsuario.Text = "Galería de fotos" + " (" + usuario.CantidadImagenes() + ")";

            // Sólo mostramos el enlace a los mensajes privados si hay un usuario en la sessión
            // y coincide con el usuario que se está visualizando.
            HyperLink_mensajesUsuario.Visible = false;
            if (Session["usuario"] != null)
            {
                if (ENUsuario.Obtener(Session["usuario"].ToString()).Id == usuario.Id)
                {
                    HyperLink_mensajesUsuario.NavigateUrl = "mensajes.aspx?usuario=" + usuario.Usuario;
                    HyperLink_mensajesUsuario.Text = "Mensajes privados " + " (" + usuario.CantidadMensajes() + ")";
                    HyperLink_mensajesUsuario.Visible = true;
                }
            }

            // Sólo mostramos el enlace para enviar un mensaje si estás identificado pero no eres tu mismo.
            HyperLink_enviarMensajeUsuario.Visible = false;
            if (Session["usuario"] != null)
            {
                if (ENUsuario.Obtener(Session["usuario"].ToString()).Id != usuario.Id)
                {
                    HyperLink_enviarMensajeUsuario.NavigateUrl = "enviarmensaje.aspx?usuario=" + usuario.Usuario;
                    HyperLink_enviarMensajeUsuario.Visible = true;
                }
            }
        }

        private void extraerParametros()
        {
            // Intentamos extraer el usuario según el nombre recibido en los parámetros.
            usuario = null;
            try
            {
                usuario = ENUsuario.Obtener(Request["usuario"].ToString());
            }
            catch (Exception) { }

            // Si no hemos extraido ninguno, lo intentamos extraer según el id.
            if (usuario == null)
            {
                try
                {
                    usuario = ENUsuario.Obtener(int.Parse(Request["id"].ToString()));
                }
                catch (Exception) { }
            }

            // Si no lo hemos extraido de ninguna forma, lo intentamos desde la sessión.
            if (usuario == null)
            {
                try
                {
                    usuario = ENUsuario.Obtener(Session["usuario"].ToString());
                }
                catch (Exception) { }
            }
        }
    }
}
