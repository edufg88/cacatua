﻿using System;
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
        private Stack<UserControl> pilaFormularios;
        private Stack<bool> pilaBotonVolver;
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
            pilaFormularios = new Stack<UserControl>();
            pilaBotonVolver = new Stack<bool>();
            pilaBotonCancelar = new Stack<bool>(30);

            FormGeneral form = new FormGeneral();
            DesapilarTodos();
            Apilar(form, "General", false, false);
        }

        private void FormPanelAdministracion_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void button_usuarios_Click(object sender, EventArgs e)
        {
            FormUsuarios form = new FormUsuarios();
            DesapilarTodos();
            Apilar(form, "Usuarios", false, false);
        }

        private void button_foro_Click(object sender, EventArgs e)
        {
            FormForo form = new FormForo();
            DesapilarTodos();
            Apilar(form, "Foro", false, false);
        }

        private void button_peticiones_Click(object sender, EventArgs e)
        {
            FormPeticiones form = new FormPeticiones();
            DesapilarTodos();
            Apilar(form, "Peticiones", false, false);
        }

        private void button_grupos_Click(object sender, EventArgs e)
        {
            FormGrupos form = new FormGrupos();
            DesapilarTodos();
            Apilar(form, "Grupos", false, false);
        }

        private void button_materiales_Click(object sender, EventArgs e)
        {
            FormMateriales form = new FormMateriales();
            DesapilarTodos();
            Apilar(form, "Materiales", false, false);
        }

        private void button_general_Click(object sender, EventArgs e)
        {
            FormGeneral form = new FormGeneral();
            DesapilarTodos();
            Apilar(form, "General", false, false);
        }

        private void button_categorias_Click(object sender, EventArgs e)
        {
            FormCategorias form = new FormCategorias();
            DesapilarTodos();
            Apilar(form, "Categorías", false, false);
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
        public void Apilar(UserControl formulario, string descripcion, bool volver, bool cancelar)
        {
            // Mostramos el texto en las 'migas de pan' de la navegación.
            Button button = new Button();
            button.AutoSize = true;
            button.Enabled = false;
            button.Text = descripcion;
            flowLayoutPanel_navegacion.Controls.Add(button);

            pilaFormularios.Push(formulario);
            pilaBotonVolver.Push(volver);
            pilaBotonCancelar.Push(cancelar);
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
            UserControl formulario = pilaFormularios.Pop();
            pilaBotonVolver.Pop();
            pilaBotonCancelar.Pop();
            MostrarCima();
            if (obtener == true)
            {
                //Object ultimo_usuario_o_categoria = formulario.ObjetoSeleccionado;
            }

            if (flowLayoutPanel_navegacion.Controls.Count > 0)
            {
                Control control = flowLayoutPanel_navegacion.Controls[flowLayoutPanel_navegacion.Controls.Count - 1];
                flowLayoutPanel_navegacion.Controls.Remove(control);
            }
        }

        public void DesapilarTodos()
        {
            pilaFormularios.Clear();
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
            UserControl form = pilaFormularios.Peek();
            panel.Controls.Clear();
            panel.Controls.Add(form);
            form.Dock = DockStyle.Fill;
        }

        private void button_volver_Click(object sender, EventArgs e)
        {
            Desapilar(true);
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            Desapilar(false);
        }
    }
}