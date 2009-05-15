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

namespace WebCacatUA
{
    public partial class chat : InterfazWeb
    {
        private void escribir(string cadena)
        {
            const string fic = @"C:\log.txt";
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fic, true);
            sw.WriteLine(cadena);
            sw.Close();
        }

        /// <summary>
        /// Almacena el nombre del usuario (ó "" si no está identificado). Cuando se reciben los mensajes
        /// sólo se añaden los que no coincidan con el nombre del usuario.
        /// </summary>
        public string NombreUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Inicializamos algunos controles y variables.
                NombreUsuario = "";
                TextBox_mensaje.Focus();

                // Deshabilitamoms la inserción si no está identificado.
                TextBox_mensaje.Enabled = false;
                Button_enviar.Enabled = false;
                if (Session["usuario"] != null)
                {
                    TextBox_mensaje.Enabled = true;
                    Button_enviar.Enabled = true;
                }

                // Nos logueamos en el chat
                if (Session["usuario"] != null)
                {
                    // Obtenemos el usuario de la sesión
                    ENUsuario usuario = ENUsuario.Obtener(Session["usuario"].ToString());
                    NombreUsuario = usuario.Usuario;
                    // Nos logueamos 
                    ENChatConectado conectado = new ENChatConectado();
                    conectado.Usuario = usuario;
                    conectado.Guardar();
                }
                ActualizarChat();
            }
        }

        private void ActualizarChat()
        {
            try
            {
                ENChatConectado conectado = new ENChatConectado();
                conectado.Usuario = ENUsuario.Obtener(Session["usuario"].ToString());
                conectado.Actualizar();
            }
            catch (Exception) { }

            // Comprobamos cual es el último mensaje
            ENChatMensaje ultimoMensaje = ENChatMensaje.Obtener(int.Parse(Label_ultimoMensaje.Text));
            if (ultimoMensaje == null)
            {
                // Obtenemos el último mensaje que hay en la bd
                ultimoMensaje = ENChatMensaje.Ultimo();
                if (ultimoMensaje != null)
                {
                    Label_ultimoMensaje.Text = ultimoMensaje.Id.ToString();
                }
            }
            else
            {
                // Extraemos los últimos mensajes y los introducimos en el TextBox.
                ArrayList mensajes = ENChatMensaje.Obtener(ultimoMensaje);
                foreach (ENChatMensaje mensaje in mensajes)
                {
                    string aux = mensaje.Usuario.Usuario + ": " + mensaje.Mensaje + "\n";
                    TextBox_mensajes.Text += aux;
                }

                // Si había mensajes nuevos, nos guardamos el ID del último y
                // Copiamos el contenido del TextBox_mensajes al Panel_mensajes dándole formato.
                if (mensajes.Count > 0)
                {
                    ENChatMensaje mensaje = (ENChatMensaje)mensajes[mensajes.Count-1];
                    Label_ultimoMensaje.Text = mensaje.Id.ToString();
               
                    Label label = new Label();
                    label.Text = "<div class=\"mensajeChat\"><span class=\"autorMensajeChat\">";
                    label.Text += TextBox_mensajes.Text.Replace("\n", "</span></div><div class=\"mensajeChat\"><span class=\"autorMensajeChat\">");
                    label.Text += "</span></div>";
                    label.Text = label.Text.Replace(":", ": </span><span class=\"textoMensajeChat\">");
                    Panel_mensajes.Controls.Add(label);
                    UpdatePanel1.Update();
                }
            }

            // Mostramos los usuarios que hay conectados
            ArrayList conectados = ENChatConectado.Obtener();
            ListBox_usuarios.Items.Clear();
            foreach (ENChatConectado conectado in conectados)
            {
                ListItem item = new ListItem(conectado.Usuario.Usuario);
                ListBox_usuarios.Items.Add(conectado.Usuario.Usuario);
            }
        }

        protected void actualizarChat(object sender, EventArgs e)
        {
            ActualizarChat();
        }

        protected void Button_enviar_Click(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                // Obtenemos el usuario de la sesión
                ENUsuario usuario = ENUsuario.Obtener(Session["usuario"].ToString());
                // Enviamos el menaje
                ENChatMensaje mensaje = new ENChatMensaje();
                mensaje.Usuario = usuario;
                string msj = TextBox_textoEnviado.Text;
                msj = msj.Replace("\n", "");
                msj = msj.Replace(":", "");
                msj = msj.Replace("\\", "");
                msj = msj.Replace("<", "");
                msj = msj.Replace("\"", "");
                msj = msj.Replace("'", "");
                msj = msj.Replace(">", "");
                mensaje.Mensaje = msj;
                if (msj != "")
                    mensaje.Guardar();
            }
        }
    }
}
