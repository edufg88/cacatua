using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Libreria;

namespace cacatUA
{
    sealed public partial class FormPanelAdministracion : Form
    {
        private static readonly FormPanelAdministracion instancia = new FormPanelAdministracion();
        private Stack<InterfazForm> pilaFormularios;
        private Stack<string> pilaBotonVolverStr;
        private Stack<bool> pilaBotonVolver;
        private Stack<string> pilaBotonCancelarStr;
        private Stack<bool> pilaBotonCancelar;

        /// <summary>
        /// Permite obtener la única instancia de esta clase.
        /// </summary>
        public static FormPanelAdministracion Instancia
        {
            get { return instancia; }
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

            FormGeneral form = new FormGeneral();
            DesapilarTodos();
            Apilar(form, "General", false, false, "", "");
        }

        private void FormPanelAdministracion_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void button_usuarios_Click(object sender, EventArgs e)
        {
            FormUsuarios form = new FormUsuarios();
            DesapilarTodos();
            Apilar(form, "Usuarios", false, false, "", "");
        }

        private void button_foro_Click(object sender, EventArgs e)
        {
            FormForo form = new FormForo();
            DesapilarTodos();
            Apilar(form, "Foro", false, false, "", "");
        }

        private void button_peticiones_Click(object sender, EventArgs e)
        {
            FormPeticiones form = new FormPeticiones();
            DesapilarTodos();
            Apilar(form, "Peticiones", false, false, "", "");
        }

        private void button_grupos_Click(object sender, EventArgs e)
        {
            FormGrupos form = new FormGrupos();
            DesapilarTodos();
            Apilar(form, "Grupos", false, false, "", "");
        }

        private void button_materiales_Click(object sender, EventArgs e)
        {
            FormMateriales form = new FormMateriales();
            DesapilarTodos();
            Apilar(form, "Materiales", false, false, "", "");
        }

        private void button_general_Click(object sender, EventArgs e)
        {
            FormGeneral form = new FormGeneral();
            DesapilarTodos();
            Apilar(form, "General", false, false, "", "");
        }

        private void button_categorias_Click(object sender, EventArgs e)
        {
            FormCategorias form = new FormCategorias();
            DesapilarTodos();
            Apilar(form, "Categorías", false, false, "", "");
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
            //button.Enabled = false;
            button.Text = descripcion;
            flowLayoutPanel_navegacion.Controls.Add(button);

            pilaFormularios.Push(formulario);
            pilaBotonVolver.Push(volver);
            pilaBotonVolverStr.Push(volverStr);
            pilaBotonCancelar.Push(cancelar);
            pilaBotonCancelarStr.Push(cancelarStr);
            MostrarCima();
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

            InterfazForm form = pilaFormularios.Peek();
            panel.Controls.Clear();
            panel.Controls.Add(form);
            form.Dock = DockStyle.Fill;
        }

        public void MostrarToolTip()
        {
            toolTip_avanzado.Show(toolTip1.GetToolTip(button_volver), button_volver);
        }

        public bool Volver
        {
            get { return button_volver.Enabled; }
            set { button_volver.Enabled = value; }
        }

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

        public void MensajeEstado(string mensaje)
        {
            toolStripStatusLabel1.Text = mensaje;
        }
    }
}
