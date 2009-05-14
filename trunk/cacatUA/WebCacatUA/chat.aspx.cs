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

        public string NombreUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            NombreUsuario = "";
            TextBox_mensaje.Enabled = false;
            Button_enviar.Enabled = false;
            if (Session["usuario"] != null)
            {
                TextBox_mensaje.Enabled = true;
                Button_enviar.Enabled = true;
            }

            if (!Page.IsPostBack)
            {
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
            catch (Exception)
            {
                escribir("actualizando en chat.aspx.cs");
            }

            // Mostramos los usuarios que hay conectados
            ArrayList conectados = ENChatConectado.Obtener();
            ListBox_usuarios.Items.Clear();
            foreach (ENChatConectado conectado in conectados)
            {
                ListItem item = new ListItem(conectado.Usuario.Usuario);
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
                    string aux = mensaje.Usuario.Usuario + ": " + mensaje.Mensaje + "\n";

                    if (Session["usuario"] != null)
                    {
                        ENUsuario u = ENUsuario.Obtener(Session["usuario"].ToString());
                        if (u != null)
                        {
                            if (mensaje.Usuario.Id != u.Id)
                                TextBox_mensajes.Text += aux;
                        }
                        else
                        {
                            TextBox_mensajes.Text += aux;
                        }
                    }
                    else
                    {
                        TextBox_mensajes.Text += aux;
                    }
                }
                if (mensajes.Count > 0)
                {
                    ENChatMensaje mensaje = (ENChatMensaje)mensajes[mensajes.Count-1];
                    Label_ultimoMensaje.Text = mensaje.Id.ToString();
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
                mensaje.Mensaje = TextBox_textoEnviado.Text;
                mensaje.Guardar();
                TextBox_mensaje.Text = "";
            }
        }
    }
}
