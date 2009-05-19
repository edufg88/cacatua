using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using Libreria;

namespace cacatUA
{
    sealed public partial class FormPanelAdministracion : Form
    {
        private static readonly FormPanelAdministracion instancia = new FormPanelAdministracion();

        // Pilas que utiliza la navegación para almacenar los formularios y el estado de los botones.
        private Stack<InterfazForm> pilaFormularios;
        private Stack<string> pilaBotonVolverStr;
        private Stack<bool> pilaBotonVolver;
        private Stack<string> pilaBotonCancelarStr;
        private Stack<bool> pilaBotonCancelar;

        // Formularios originales. Uno de cada.
        private FormMateriales formMateriales = null;
        private FormUsuarios formUsuarios = null;
        private FormForo formForo = null;
        private FormGrupos formGrupos = null;
        private FormCategorias formCategorias = null;
        private FormPeticiones formPeticiones = null;
        private FormGeneral formGeneral = null;

        private ENUsuario usuario = null;
        private bool flechaIluminada;

        /// <summary>
        /// Permite obtener la única instancia de esta clase.
        /// </summary>
        public static FormPanelAdministracion Instancia
        {
            get { return instancia; }
        }

        public FormMateriales InstanciaFormMateriales
        {
            get { return formMateriales; }
        }

        public ENUsuario Usuario
        {
            get { return usuario; }
            set
            {
                usuario = value;
                if (usuario != null)
                    label_conectado.Text = "Conectado como " + usuario.Usuario;
            }
        }


        /// <summary>
        /// Constructor por defecto. Privado para no permitir más de una instancia de esta clase.
        /// </summary>
        private FormPanelAdministracion()
        {
            InitializeComponent();

            pilaFormularios = new Stack<InterfazForm>();
            pilaBotonVolverStr = new Stack<string>();
            pilaBotonVolver = new Stack<bool>();
            pilaBotonCancelarStr = new Stack<string>();
            pilaBotonCancelar = new Stack<bool>();

            formGeneral = new FormGeneral();
            formMateriales = new FormMateriales();
            formUsuarios = new FormUsuarios();
            formForo = new FormForo();
            formGrupos = new FormGrupos();
            formCategorias = new FormCategorias();
            formPeticiones = new FormPeticiones();
            formGeneral = new FormGeneral();

            flechaIluminada = false;
            timer1.Tick += new EventHandler(alterna_flecha_Tick);

            DesapilarTodos();
            Apilar(formGeneral, "General", false, false, "", "");
        }

        void alterna_(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void FormPanelAdministracion_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void button_usuarios_Click(object sender, EventArgs e)
        {
            DesapilarTodos();
            Apilar(formUsuarios, "Usuarios", false, false, "", "");
        }

        private void button_foro_Click(object sender, EventArgs e)
        {
            DesapilarTodos();
            Apilar(formForo, "Foro", false, false, "", "");
        }

        private void button_peticiones_Click(object sender, EventArgs e)
        {
            DesapilarTodos();
            Apilar(formPeticiones, "Peticiones", false, false, "", "");
        }

        private void button_grupos_Click(object sender, EventArgs e)
        {
            DesapilarTodos();
            Apilar(formGrupos, "Grupos", false, false, "", "");
        }

        private void button_materiales_Click(object sender, EventArgs e)
        {
            DesapilarTodos();
            Apilar(formMateriales, "Materiales", false, false, "", "");
        }

        private void button_general_Click(object sender, EventArgs e)
        {
            DesapilarTodos();
            Apilar(formGeneral, "General", false, false, "", "");
        }

        private void button_categorias_Click(object sender, EventArgs e)
        {
            DesapilarTodos();
            Apilar(formCategorias, "Categorías", false, false, "", "");
        }

        private void button_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }







        /// <summary>
        /// Apila un formulario en la pila y lo muestra en el panel principal. Se debe indicar una descripción
        /// para el formulario que se mostrará en forma de "migas de pan" para mostrar la
        /// ruta de secuencia de la pila.
        /// </summary>
        /// <param name="formulario">Formulario que se va a mostrar.</param>
        /// <param name="descripcion">Texto descriptivo para el formulario.</param>
        /// <param name="volver">Indica si el nuevo formulario permite el botón de volver.</param>
        /// <param name="cancelar">Indica si el nuevo formulario permite el botón de cancelar.</param>
        /// <param name="volverStr">Mensaje que aparece en el tooltip para el botón volver.</param>
        /// <param name="cancelarStr">Mensaje que aparece en el tooltip para el botón cancelar.</param>
        public void Apilar(InterfazForm formulario, string descripcion, bool volver, bool cancelar, string volverStr, string cancelarStr)
        {
            // Mostramos el texto en las 'migas de pan' de la navegación.
            Button button = new Button();
            button.AutoSize = true;
            button.Enabled = false;
            toolTip1.SetToolTip(button, "Retroceder hasta este punto cancelando todas las tareas sin terminar");
            button.Click += new System.EventHandler(button_navegacion_Click);
            button.Text = descripcion;
            if (flowLayoutPanel_navegacion.Controls.Count > 0)
                flowLayoutPanel_navegacion.Controls[flowLayoutPanel_navegacion.Controls.Count - 1].Enabled = true;
            flowLayoutPanel_navegacion.Controls.Add(button);

            pilaFormularios.Push(formulario);
            pilaBotonVolver.Push(volver);
            pilaBotonVolverStr.Push(volverStr);
            pilaBotonCancelar.Push(cancelar);
            pilaBotonCancelarStr.Push(cancelarStr);
            MostrarCima();
        }

        private void button_navegacion_Click(object sender, EventArgs e)
        {
            // Desapilamos hasta que el último control coincida con el control que invocó el método.
            while (flowLayoutPanel_navegacion.Controls[flowLayoutPanel_navegacion.Controls.Count-1]!=(Control) sender)
            {
                Desapilar(false);
            }
        }

        /// <summary>
        /// Elimina el formulario que se encuentre en la cima.
        /// Se debe indicar si se quiere obtener "algo" de este formulario. Por ejemplo, este algo podría ser
        /// un ENUsuario o una ENCategoria, dependiendo del formulario.
        /// FormUsuario y FormCategoria deben asegurarse de guardar el objecto seleccionado en ObjetoSeleccionado,
        /// que sería privado para acceder desde fuera. Ademmás, como todos los objetos heredan de Object, no 
        /// tenemos problemas para implementar el poliformismo.
        /// </summary>
        /// <param name="obtener">
        /// Indica si se quiere obtener algún objecto (Object) del formulario antes de desapilarse definitivamente.
        /// </param>
        public void Desapilar(bool obtener)
        {
            InterfazForm formulario = pilaFormularios.Pop();
            pilaBotonVolver.Pop();
            pilaBotonVolverStr.Pop();
            pilaBotonCancelar.Pop();
            pilaBotonCancelarStr.Pop();
            MostrarCima();
            if (obtener == true)
            {
                pilaFormularios.Peek().Recibir(formulario.Enviar());
            }

            if (flowLayoutPanel_navegacion.Controls.Count > 0)
            {
                Control control = flowLayoutPanel_navegacion.Controls[flowLayoutPanel_navegacion.Controls.Count - 1];
                flowLayoutPanel_navegacion.Controls.Remove(control);
            }

            if (flowLayoutPanel_navegacion.Controls.Count > 0)
            {
                flowLayoutPanel_navegacion.Controls[flowLayoutPanel_navegacion.Controls.Count - 1].Enabled = false;
            }
        }

        /// <summary>
        /// Elimina el historial de navegación.
        /// </summary>
        public void DesapilarTodos()
        {
            pilaFormularios.Clear();
            pilaBotonVolver.Clear();
            pilaBotonVolverStr.Clear();
            pilaBotonCancelar.Clear();
            pilaBotonCancelarStr.Clear();
            button_cancelar.Enabled = false;
            button_volver.Enabled = false;
            flowLayoutPanel_navegacion.Controls.Clear();
        }

        /// <summary>
        /// Añade el formulario que se encuentre en la cima de la pila al panel principal.
        /// </summary>
        private void MostrarCima()
        {
            button_volver.Enabled = pilaBotonVolver.Peek();
            button_cancelar.Enabled = pilaBotonCancelar.Peek();
            toolTip1.SetToolTip(button_volver, pilaBotonVolverStr.Peek());
            toolTip1.SetToolTip(button_cancelar, pilaBotonCancelarStr.Peek());

            OcultarToolTip();

            InterfazForm form = pilaFormularios.Peek();
            panel.Controls.Clear();
            panel.Controls.Add(form);
            form.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Obliga a que aparezca un tooltip (el que es un globo) en el botón "volver".
        /// </summary>
        public void MostrarToolTip()
        {
            //toolTip_avanzado.Show(toolTip1.GetToolTip(button_volver), button_volver, 30, 30);
            if (button_volver.Enabled)
                timer1.Start();
        }

        /// <summary>
        /// Oculta el tooltip (el que es un globo) del botón "volver".
        /// </summary>
        public void OcultarToolTip()
        {
            //toolTip_avanzado.Hide(button_volver);
            timer1.Stop();
            if (flechaIluminada)
            {
                FlechaApagada();
            }
        }

        /// <summary>
        /// Modifica el estado del botón volver.
        /// </summary>
        public bool Volver
        {
            get { return button_volver.Enabled; }
            set { button_volver.Enabled = value; }
        }

        /// <summary>
        /// Modifica el estado del botón cancelar.
        /// </summary>
        public bool Cancelar
        {
            get { return button_cancelar.Enabled; }
            set { button_cancelar.Enabled = value; }
        }

        private void button_volver_Click(object sender, EventArgs e)
        {
            Desapilar(true);
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            Desapilar(false);
        }

        /// <summary>
        /// Permite establecer un texto en la barra de estado. Por ejemplo, en vez de salir un MessageBox
        /// cuando se crea ALGO, se establece un mensaje que diga "ALGO creado correctamente".
        /// </summary>
        /// <param name="mensaje">Cadena de texto con el mensaje.</param>
        public void MensajeEstado(string mensaje)
        {
            toolStripStatusLabel1.Text = mensaje;
        }

        private void flowLayoutPanel_navegacion_ControlAdded(object sender, ControlEventArgs e)
        {
            ((FlowLayoutPanel)sender).AutoScrollPosition = new Point(20, 20);
        }

        private void FormPanelAdministracion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.OK != MessageBox.Show ("¿Está seguro de que desea salir?", "Ventana de confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
            {
                e.Cancel = true;
            }
        }

        private void alterna_flecha_Tick(object sender, EventArgs e)
        {
            if (flechaIluminada)
            {
                FlechaApagada();
            }
            else
            {
                FlechaIluminada();
            }
        }

        public void FlechaIluminada()
        {
            button_volver.Image = global::cacatUA.Properties.Resources.volveriluminado;
            flechaIluminada = true;
        }

        public void FlechaApagada()
        {
            button_volver.Image = global::cacatUA.Properties.Resources.volver;
            flechaIluminada = false;
        }
    }
}
