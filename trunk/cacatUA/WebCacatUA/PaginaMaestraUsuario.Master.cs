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
        private ENUsuario uSesion;

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

        private void actualizarSeccionGrupos()
        {
            ArrayList grupos = ENGrupos.Obtener(usuario);

            Label label = new Label();
            label.Text = Resources.I18N.NoEstaApuntadoNingunGrupo + ".";
            label.CssClass = "noGrupoUsuario";
            Panel_gruposUsuario.Controls.Add(label);

            if (grupos != null)
            {
                if (grupos.Count > 0)
                {
                    Panel_gruposUsuario.Controls.Clear();
                    foreach (ENGrupos i in grupos)
                    {
                        HyperLink enlace = new HyperLink();
                        enlace.Text = i.Nombre + " (" + i.NumUsuarios + " " + Resources.I18N.miembros + ")";
                        enlace.NavigateUrl = "grupo.aspx?usuario="+usuario.Usuario+"&id=" + i.Id;
                        enlace.CssClass = "grupoUsuario";
                        Panel_gruposUsuario.Controls.Add(enlace);
                    }
                }
            }
        }

        private void actualizarSeccionEncuestas()
        {
            ENEncuesta mostrar = usuario.EncuestaActiva();

            if (mostrar != null)
            {
                if (mostrar.HaVotado(uSesion))
                {
                    Label l1 = new Label();
                    l1.Text = mostrar.Pregunta;
                    Panel_encuesta.Controls.Add(l1);
                    int totalVotos = mostrar.NumVotos();

                    foreach (OpcionEncuesta opc in mostrar.Opciones())
                    {
                        //Salto de linea (si, es lo peor)
                        Label br = new Label();
                        br.Text = "<br/>";
                        Panel_encuesta.Controls.Add(br);

                        int opcionVotos = opc.NumVotos();

                        Label l2 = new Label();
                        l2.Text = opc.Opcion + ": " + opcionVotos.ToString() + " (" + ((opcionVotos * 100)/totalVotos).ToString() + "%)";
                        Panel_encuesta.Controls.Add(l2);
                    }

                    Label l3 = new Label();
                    l3.Text = "<br/>Total votos: " + totalVotos.ToString();
                    Panel_encuesta.Controls.Add(l3);
                }
                else
                {
                    Label l1 = new Label();
                    l1.Text = mostrar.Pregunta;
                    Panel_encuesta.Controls.Add(l1);

                    foreach (OpcionEncuesta opc in mostrar.Opciones())
                    {
                        //Salto de linea (si, es lo peor)
                        Label br = new Label();
                        br.Text = "<br/>";
                        Panel_encuesta.Controls.Add(br);


                        RadioButton rb1 = new RadioButton();
                        rb1.Text = opc.Opcion;
                        rb1.ID = opc.Id.ToString();
                        rb1.GroupName = "Encuesta";
                        rb1.CheckedChanged += new System.EventHandler(CheckBox_votaropcion_Click);
                        rb1.AutoPostBack = true;
                        if (uSesion == null)
                            rb1.Enabled = false;
                        Panel_encuesta.Controls.Add(rb1);
                    }
                    if (uSesion == null)
                    {
                        Label l3 = new Label();
                        l3.Text = "<br/>Necesitas estar registrado para votar.";
                        Panel_encuesta.Controls.Add(l3);
                    }
                }
            }
            else
            {
                Label l1 = new Label();
                l1.Text = "No hay encuestas activas.";
                Panel_encuesta.Controls.Add(l1);
            }

        }

        protected void CheckBox_votaropcion_Click(object sender, EventArgs e)
        {

            CheckBox pulsado = (CheckBox)sender;
            try
            {
                int idopcion = int.Parse(pulsado.ID.ToString());
                ENEncuesta.Votar(uSesion, ENEncuesta.ObtenerOpcion(idopcion));
            }
            catch (Exception) { }

            Response.Redirect(Request.Url.ToString());
        }

        /// <summary>
        /// Actualizamos la columna izquierda con los datos del usuario, así como los
        /// enlaces que llevan a cada una de las secciones.
        /// </summary>
        private void actualizarDatosUsuario()
        {
            Label_nombreUsuario.Text = usuario.Usuario;

            if (usuario.Imagen != -1)
                Image_fotoUsuario.ImageUrl = "galeria/" + usuario.Imagen + ".jpg";

            HyperLink_datosUsuario.NavigateUrl = "usuario.aspx?usuario=" + usuario.Usuario;
            HyperLink_datosUsuario.Text = Resources.I18N.DatosUsuario;

            HyperLink_encuestasUsuario.NavigateUrl = "encuestas.aspx?usuario=" + usuario.Usuario;
            HyperLink_encuestasUsuario.Text = Resources.I18N.Encuestas + " (" + usuario.CantidadEncuestas() + ")";

            HyperLink_firmasUsuario.NavigateUrl = "firmas.aspx?usuario=" + usuario.Usuario;
            HyperLink_firmasUsuario.Text = Resources.I18N.Firmas + " (" + usuario.CantidadFirmas() + ")";

            HyperLink_galeriaUsuario.NavigateUrl = "galeria.aspx?usuario=" + usuario.Usuario;
            HyperLink_galeriaUsuario.Text = Resources.I18N.GaleriaFotos + " (" + usuario.CantidadImagenes() + ")";

            // Sólo mostramos el enlace a los mensajes privados si hay un usuario en la sessión
            // y coincide con el usuario que se está visualizando.
            HyperLink_mensajesUsuario.Visible = false;
            if (Session["usuario"] != null)
            {
                if (ENUsuario.Obtener(Session["usuario"].ToString()).Id == usuario.Id)
                {
                    HyperLink_mensajesUsuario.NavigateUrl = "mensajes.aspx?usuario=" + usuario.Usuario;
                    HyperLink_mensajesUsuario.Text = Resources.I18N.MensajesPrivados + " (" + usuario.CantidadMensajes() + ")";
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

            // Extraemoe el usuario de la sesion
            uSesion = null;
            try
            {
                uSesion = ENUsuario.Obtener(Session["usuario"].ToString());
            }
            catch (Exception) { }

            // Intentamos extraer el usuario según el nombre recibido en los parámetros.
            usuario = null;
            try
            {
                usuario = ENUsuario.Obtener(Request["usuario"].ToString());
            }
            catch (Exception) { }

            // Si no esta en el request, usamos el de sesion
            if (usuario == null)
            {
                try
                {
                    usuario = uSesion;
                }
                catch (Exception) { }
            }
        }
    }
}
