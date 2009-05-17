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
                Label l1 = new Label();
                l1.Text = mostrar.Pregunta;
                l1.CssClass = "preguntaEncuesta";
                Panel_encuesta.Controls.Add(l1);

                if (uSesion == null || mostrar.HaVotado(uSesion))
                {
                    int totalVotos = mostrar.NumVotos();

                    Table table = new Table();

                    foreach (OpcionEncuesta opc in mostrar.Opciones())
                    {
                        TableRow tr = new TableRow();

                        if (totalVotos != 0)
                        {
                            TableCell tc1 = new TableCell();
                            tc1.CssClass = "celdaOpcion";
                            Label lopcion = new Label();
                            lopcion.Text = opc.Opcion + ": ";
                            tc1.Controls.Add(lopcion);

                            TableCell tc2 = new TableCell();
                            Label lvotos = new Label();
                            int opcionVotos = opc.NumVotos();
                            lvotos.Text = opcionVotos.ToString() + " (" + ((opcionVotos * 100) / totalVotos).ToString() + "%)";
                            tc2.Controls.Add(lvotos);

                            tr.Controls.Add(tc1);
                            tr.Controls.Add(tc2);
                            table.Controls.Add(tr);
                        }
                        else
                        {
                            Label l2 = new Label();
                            l2.Text = opc.Opcion;
                            Panel_encuesta.Controls.Add(l2);
                        }                        
                    }

                    if(totalVotos != 0)
                        Panel_encuesta.Controls.Add(table);

                    Label l3 = new Label();
                    l3.CssClass = "totalVotos";
                    l3.Text = "<br/><strong>" + Resources.I18N.TotalVotos + ":</strong> " + totalVotos.ToString();
                    Panel_encuesta.Controls.Add(l3);

                    if (uSesion == null)
                    {
                        Label l4 = new Label();
                        l4.CssClass = "loginVotar";
                        l4.Text = "<br/><br/>" + Resources.I18N.LoginParaVotar;
                        Panel_encuesta.Controls.Add(l4);
                    }
                }
                else
                {
                    foreach (OpcionEncuesta opc in mostrar.Opciones())
                    {
                        //Salto de linea (si, es lo peor)
                        Label br = new Label();
                        br.Text = "<br/>";
                        Panel_encuesta.Controls.Add(br);


                        RadioButton rb1 = new RadioButton();
                        rb1.CssClass = "opcionEncuesta";
                        rb1.Text = opc.Opcion;
                        rb1.ID = opc.Id.ToString();
                        rb1.GroupName = "Encuesta";
                        rb1.CheckedChanged += new System.EventHandler(CheckBox_votaropcion_Click);
                        rb1.AutoPostBack = true;
                        if (uSesion == null)
                            rb1.Enabled = false;
                        Panel_encuesta.Controls.Add(rb1);
                    }
                }
            }
            else
            {
                Label l1 = new Label();
                l1.Text = Resources.I18N.NoEncuestasActivas;
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

            ENImagen imagenUsuario = ENImagen.Obtener(usuario.Imagen);
            if (imagenUsuario != null)
                Image_fotoUsuario.ImageUrl = "galeria/" + imagenUsuario.Archivo;

            HyperLink_tablonUsuario.NavigateUrl = "generalUsuario.aspx?usuario=" + usuario.Usuario;
            HyperLink_tablonUsuario.Text = Resources.I18N.TablonUsuario;

            HyperLink_datosUsuario.NavigateUrl = "usuario.aspx?usuario=" + usuario.Usuario;
            HyperLink_datosUsuario.Text = Resources.I18N.DatosUsuario;

            HyperLink_encuestasUsuario.NavigateUrl = "encuestas.aspx?usuario=" + usuario.Usuario;
            HyperLink_encuestasUsuario.Text = Resources.I18N.Encuestas + " (" + usuario.CantidadEncuestas() + ")";

            HyperLink_firmasUsuario.NavigateUrl = "firmas.aspx?usuario=" + usuario.Usuario;
            HyperLink_firmasUsuario.Text = Resources.I18N.Firmas + " (" + usuario.CantidadFirmas() + ")";

            HyperLink_galeriaUsuario.NavigateUrl = "galeria.aspx?usuario=" + usuario.Usuario;
            HyperLink_galeriaUsuario.Text = Resources.I18N.GaleriaFotos + " (" + usuario.CantidadImagenes() + ")";

            // Sólo mostramos el enlace a los mensajes privados y encuestas si hay un usuario en la sessión
            // y coincide con el usuario que se está visualizando.
            HyperLink_mensajesUsuario.Visible = false;
            HyperLink_encuestasUsuario.Visible = false;
            HyperLink_categoriaUsuario.Visible = false;
            if (Session["usuario"] != null)
            {
                if (ENUsuario.Obtener(Session["usuario"].ToString()).Id == usuario.Id)
                {
                    HyperLink_mensajesUsuario.NavigateUrl = "mensajes.aspx?usuario=" + usuario.Usuario;
                    HyperLink_mensajesUsuario.Text = Resources.I18N.MensajesPrivados + " (" + usuario.CantidadMensajes() + ")";
                    HyperLink_mensajesUsuario.Visible = true;

                    HyperLink_encuestasUsuario.NavigateUrl = "encuestas.aspx?usuario=" + usuario.Usuario;
                    HyperLink_encuestasUsuario.Text = Resources.I18N.Encuestas + " (" + usuario.CantidadEncuestas() + ")";
                    HyperLink_encuestasUsuario.Visible = true;

                    HyperLink_categoriaUsuario.NavigateUrl = "categorias.aspx?usuario=" + usuario.Usuario;
                    HyperLink_categoriaUsuario.Text = Resources.I18N.CategoriasSuscritas;
                    HyperLink_categoriaUsuario.Visible = true;
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
