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
    public partial class chat : System.Web.UI.Page
    {
        private void escribir(string cadena)
        {
            const string fic = @"C:\log.txt";
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fic, true);
            sw.WriteLine(cadena);
            sw.Close();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Nos logueamos en el chat
                if (Session["usuario"] != null)
                {
                    // Obtenemos el usuario de la sesión
                    ENUsuario usuario = ENUsuario.Obtener(Session["usuario"].ToString());
                    // Nos logueamos 
                    ENChatConectado conectado = new ENChatConectado();
                    conectado.Usuario = usuario;
                    conectado.Guardar();
                }
            }
        }

        private void ActualizarChat()
        {
            // Mostramos los usuarios que hay conectados
            ArrayList conectados = ENChatConectado.Obtener();
            foreach (ENChatConectado conectado in conectados)
            {
                ListItem item = new ListItem(conectado.Usuario.Usuario);
                if(ListBox_usuarios.Items.Contains(item) == false)
                    ListBox_usuarios.Items.Add(conectado.Usuario.Usuario);
            }

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
                ArrayList mensajes = ENChatMensaje.Obtener(ultimoMensaje);
                foreach (ENChatMensaje mensaje in mensajes)
                {
                    Label label = new Label();
                    label.Text = mensaje.Usuario.Usuario + ": ";
                    label.Text += mensaje.Mensaje;
                    label.Text += "<br />";
                    Panel_mensajes.Controls.Add(label);

                }
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
                mensaje.Mensaje = TextBox_mensaje.Text;
                mensaje.Guardar();
                TextBox_mensaje.Text = "";
                
            }
        }
    }
}
