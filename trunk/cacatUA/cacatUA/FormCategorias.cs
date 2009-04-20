using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Libreria;

namespace cacatUA
{

    public partial class FormCategorias : InterfazForm
    {
        private enum EstadoFormulario { NINGUNO = 0, CREACION = 1, EDICION = 2 };
        private ENCategoria seleccionada;
        private ENCategoria enrutada;
        private TreeNode sel;
        private TreeNode enr;
        private String ultimoMensaje = "";
        int numPagina;
        int totalPaginas;

        /// <summary>
        /// Indica el estado del formulario.
        /// </summary>
        EstadoFormulario estado;

        public FormCategorias()
        {
            InitializeComponent();
        }

        private void FormCategorias_Load(object sender, EventArgs e)
        {

            //Resetear
            treeViewCategorias.Nodes.Clear();

            foreach (ENCategoria categoria in ENCategoria.CategoriasSuperiores())
            {
                MeterEnArbol(categoria, treeViewCategorias.Nodes);
            }

            textBox_Descripcion.Clear();
            textBox_Nombre.Clear();
            textBox_Ruta.Clear();

            //Bloquear la parte de informacion
            groupBox_Informacion.Enabled = false;
        }
        
        /// <summary>
        /// Introduce una categoria en una coleccion de nodos de arbol.
        /// </summary>
        private void MeterEnArbol(ENCategoria cat, TreeNodeCollection coleccion) {
            TreeNode nodo = new TreeNode();
            nodo.Name = cat.Id.ToString();
            nodo.Text = cat.Nombre;
            coleccion.Add(nodo);
            
            foreach (ENCategoria c in cat.ObtenerHijos())
            {
                MeterEnArbol(c, nodo.Nodes);
            }
        }

        private void treeViewCategorias_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //Activar la parte de informacion
            groupBox_Informacion.Enabled = true;

            if (estado == EstadoFormulario.NINGUNO)
            {
                if (seleccionada == null)
                {
                    FormPanelAdministracion.Instancia.MostrarToolTip();
                }
                //Obtenemos la instancia de la Categoria seleccionada
                seleccionada = ENCategoria.Obtener(int.Parse(treeViewCategorias.SelectedNode.Name));

                //Num pagina
                numPagina = 1;

                //Llevar datos a los controles
                textBox_Nombre.Text = seleccionada.Nombre;
                textBox_Descripcion.Text = seleccionada.Descripcion;
                textBox_Ruta.Text = seleccionada.Ruta();
                textBox_nHilos.Text = seleccionada.NumHilos().ToString();
                textBox_nMateriales.Text = seleccionada.NumMateriales().ToString();

                //Llenamos el ComboBox de las paginas
                totalPaginas = ((seleccionada.NumSuscritos()-1)/10)+1;
                comboBox_pagina.Items.Clear();
                for (int i = 1; i <= totalPaginas; i++)
                    comboBox_pagina.Items.Add(i);
                rellenarGridUsuarios(seleccionada);

                // TreeNode seleccionado
                sel = treeViewCategorias.SelectedNode;

            }
            else
            {
                //Obtenemos la instancia de la Categoria seleccionada
                enrutada = ENCategoria.Obtener(int.Parse(treeViewCategorias.SelectedNode.Name));
                textBox_Ruta.Text = enrutada.NombreCompleto();
                
                // TreeNode seleccionado para enrutar
                enr = treeViewCategorias.SelectedNode;
            }
        }

        /// <summary>
        /// Rellena el dataGridView de los usuarios suscritos.
        /// </summary>
        /// <param name="categoria">Categoria asociada.</param>
        private void rellenarGridUsuarios(ENCategoria categoria)
        {
            int desde = ((numPagina-1)*10)+1;
            int hasta = (numPagina*10);
            int total = seleccionada.NumSuscritos();

            if (hasta > total)
                hasta = total;

            if (total > 0)
                label_UsuariosSuscritos.Text = "Mostrando " + desde.ToString() + "-" + hasta.ToString() + " de " + total.ToString() + " usuarios suscritos:";
            else
                label_UsuariosSuscritos.Text = "Esta categoria no tiene usuarios sucritos.";
            dataGridView_Usuarios.Rows.Clear();
            foreach (ENUsuario u in categoria.UsuariosSuscritos(numPagina))
            {
                dataGridView_Usuarios.Rows.Add(u.Id, u.Usuario, u.Nombre);
            }

            //Detalles de la paginacion
            comboBox_pagina.SelectedIndex = comboBox_pagina.Items.IndexOf(numPagina);
            if (numPagina == totalPaginas)
                button_Siguiente.Enabled = false;

            if (numPagina == 1)
                button_Anterior.Enabled = false;
        }

        private void button_crearCategoria_Click(object sender, EventArgs e)
        {
            //Activar/Desactivar controles
            ActivarEdicion();

            //Para que se produzca el evento AfterSelect en el siguiente click
            treeViewCategorias.SelectedNode = null;

            //Limpiar controles
            textBox_Nombre.Clear();
            textBox_Descripcion.Clear();

            //Controles activados
            enrutada = seleccionada;
            if (enrutada != null)
            {
                textBox_Ruta.Text = enrutada.NombreCompleto().ToString();
                enr = sel;
            }

            //Texto en la barra de estado
            ultimoMensaje = "Creando una nueva categoria - Utilice el panel de la izquierda para establecer la ruta.";
            FormPanelAdministracion.Instancia.MensajeEstado(ultimoMensaje);

            //Cambiamos el estado del formulario
            estado = EstadoFormulario.CREACION;
        }

        private void button_editarCategoria_Click(object sender, EventArgs e)
        {
            if (seleccionada == null)
            {
                MessageBox.Show("Debes seleccionar una categoria.", "Error al editar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (treeViewCategorias.SelectedNode.Level != 0)
                {
                    enrutada = ENCategoria.Obtener(int.Parse(treeViewCategorias.SelectedNode.Parent.Name));
                    enr = treeViewCategorias.SelectedNode.Parent;
                }

                //Activar/Desactivar controles
                ActivarEdicion();

                //Texto en la barra de estado
                ultimoMensaje = "Editando la categoria " + seleccionada.Id + " - Utilice el panel de la izquierda para modificar la ruta.";
                FormPanelAdministracion.Instancia.MensajeEstado(ultimoMensaje);
                
                //Cambiamos el estado del formulario
                estado = EstadoFormulario.EDICION;
            }

            //Para que se produzca el evento AfterSelect en el siguiente click
            treeViewCategorias.SelectedNode = null;
        }

        private void button_borrarCategoria_Click(object sender, EventArgs e)
        {
            if (seleccionada == null)
            {
                MessageBox.Show("Debes seleccionar una categoria.", "Error al borrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("¿Está seguro de borrar esta categoria? (Se borraran los materiales e hilos asociados y las subcategorias)", "Confirmación de borrado.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    if (seleccionada.Borrar())
                    {
                        treeViewCategorias.Nodes.Remove(treeViewCategorias.SelectedNode);
                        ultimoMensaje = "";
                        FormPanelAdministracion.Instancia.MensajeEstado("Categoria borrada correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("Error al borrar categoria.", "Error interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // Limpiar todo el formulario
                textBox_Descripcion.Clear();
                textBox_Nombre.Clear();
                textBox_Ruta.Clear();
                seleccionada = null;
                groupBox_Informacion.Enabled = false;
                treeViewCategorias.SelectedNode = null;
                dataGridView_Usuarios.Rows.Clear();
                label_UsuariosSuscritos.Text = "Usuarios suscritos: ";
                textBox_nHilos.Clear();
                textBox_nMateriales.Clear();
            }           
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            //Booleano que nos sirve para controlar si hay errores que impiden guardar
            bool validado = true;
 
            // Nodo que luego tendra el foco del formulario
            TreeNode nodoSel = null;
 
            //Sea cual sea lo que estemos haciendo, el nombre no se puede dejar vacio
            if(textBox_Nombre.Text == "") {
                validado = false;
                errorProvider_Categorias.SetError(textBox_Nombre, "Debes indicar un nombre");
            }
            else {
                //Comprobar accion a realizar
                if (estado == EstadoFormulario.EDICION)
                {
                    //Actualizando
                  
                    seleccionada.Nombre = textBox_Nombre.Text;
                    seleccionada.Descripcion = textBox_Descripcion.Text;

                    if (enrutada != null)
                    {               
                        if (enrutada.EsDescendienteDe(seleccionada) || enrutada.Id == seleccionada.Id)
                        {
                            errorProvider_Categorias.SetError(button_LimpiarRuta, "Una categoria no puede ser hija de sí misma o de un descendiente.");
                            validado = false;
                        }
                        seleccionada.Padre = enrutada.Id;
                    }

                    if (validado)
                    {
                        if (!seleccionada.Actualizar())
                        {
                            MessageBox.Show("Error al actualizar categoria.", "Error interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            ultimoMensaje = "";
                            FormPanelAdministracion.Instancia.MensajeEstado("Categoria actualizada correctamente.");
                            
                            sel.Text = seleccionada.Nombre;
                            sel.Remove();

                            if (enr != null)
                                enr.Nodes.Add(sel);
                            else
                                treeViewCategorias.Nodes.Add(sel);
                        }

                        nodoSel = sel;
                    }
                }
                else
                {
                    //Creando
                    int padre = 0;

                    //Crear objeto y almacenarlo en la BBDD
                    if (enrutada != null)
                    {
                        padre = enrutada.Id;
                    }


                    ENCategoria nCategoria = new ENCategoria(textBox_Nombre.Text, textBox_Descripcion.Text, padre);

                    if (!nCategoria.Guardar())
                    {
                        MessageBox.Show("Error al crear categoria.", "Error interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        ultimoMensaje = "";
                        FormPanelAdministracion.Instancia.MensajeEstado("Categoria creada correctamente.");

                        //Creamos el nodo de la nueva categoria
                        TreeNode nodo = new TreeNode();
                        nodo.Name = nCategoria.Id.ToString();
                        nodo.Text = nCategoria.Nombre;
                        if (enr != null)
                            enr.Nodes.Add(nodo);
                        else
                            treeViewCategorias.Nodes.Add(nodo);

                        nodoSel = nodo;
                    }
                }
            }

            if (validado)
            {
               //Activar/Desactivar controles
               DesactivarEdicion();

                //Volvemos al estado inicial
                enrutada = null;
                enr = null;
                estado = EstadoFormulario.NINGUNO;
                treeViewCategorias.SelectedNode = nodoSel; 
                treeViewCategorias.Focus();
            }
        }

        private void button_noGuardar_Click(object sender, EventArgs e)
        {
            //Activar/Desactivar controles
            DesactivarEdicion();
            if (seleccionada != null)
            {
                textBox_Descripcion.Text = seleccionada.Descripcion;
                textBox_Nombre.Text = seleccionada.Nombre;
                textBox_Ruta.Text = seleccionada.Ruta();
            }
            else
            {
                textBox_Descripcion.Clear();
                textBox_Nombre.Clear();
                textBox_Ruta.Clear();
            }

            FormPanelAdministracion.Instancia.MensajeEstado("");
            enrutada = null;
            enr = null;
            estado = EstadoFormulario.NINGUNO;

            if (sel != null)
            {
                treeViewCategorias.SelectedNode = sel;
                treeViewCategorias.Focus();
            }
        }

        /// <summary>
        /// Realiza los cambios necesarios en el formulario para
        /// activar la edición de una categoria.
        /// </summary>
        private void ActivarEdicion()
        {
            label_FuncionArbol.Text = "Seleccione una categoria para formar la ruta:";
            button_LimpiarRuta.Visible = true;

            textBox_Descripcion.ReadOnly = false;
            textBox_Nombre.ReadOnly = false;
            textBox_Ruta.BackColor = SystemColors.Window;
            button_Guardar.Visible = true;
            button_noGuardar.Visible = true;   
        }

        /// <summary>
        /// Realiza los cambios necesarios en el formulario para
        /// desactivar la edición de una categoria.
        /// </summary>
        private void DesactivarEdicion()
        {
            label_FuncionArbol.Text = "Seleccione una categoria para más informacion:";
            button_LimpiarRuta.Visible = false;
            errorProvider_Categorias.Clear();

            textBox_Descripcion.ReadOnly = true;
            textBox_Nombre.ReadOnly = true;
            textBox_Ruta.ReadOnly = true;
            textBox_Ruta.BackColor = SystemColors.Control;
            button_Guardar.Visible = false;
            button_noGuardar.Visible = false;
        }

        private void linkLabel_verHilos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormPanelAdministracion.Instancia.Apilar(new FormForo(seleccionada), "Viendo hilos", true, false, "Volver a categorías", "");
        }


        private void linkLabel_verMateriales_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormPanelAdministracion.Instancia.Apilar(FormPanelAdministracion.Instancia.InstanciaFormMateriales, "Viendo materiales", true, false, "Volver a categorías", "");
            FormPanelAdministracion.Instancia.InstanciaFormMateriales.BuscarPorCategoria(seleccionada);
        }

        private void button_verUsuario_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection filas = dataGridView_Usuarios.SelectedRows;
            if (filas.Count > 0)
            {
                int usuario = int.Parse(filas[0].Cells[0].Value.ToString());
                FormPanelAdministracion.Instancia.Apilar(new FormUsuarios(ENUsuario.Obtener(usuario)), "Viendo usuario", true, false, "Volver a categorías", "");
            }
            else
            {
                MessageBox.Show("Debes seleccionar un usuario.", "Error de navegación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_AñadirUsuario_Click(object sender, EventArgs e)
        {
            FormPanelAdministracion.Instancia.Apilar(new FormUsuarios(), "Seleccionando usuario", true, true, "Seleccionar usuario", "");
        }

        private void button_LimpiarRuta_Click(object sender, EventArgs e)
        {
            textBox_Ruta.Text = "";
            enrutada = new ENCategoria();
            enr = null;
        }


        private void button_quitarUsuario_Click(object sender, EventArgs e)
        {
            if (dataGridView_Usuarios.SelectedRows.Count > 0)
            {
                string texto = "";

                if (dataGridView_Usuarios.SelectedRows.Count == 1)
                    texto = "¿Está seguro de que desea insuscribir este usuario?";
                else
                    texto = "¿Está seguro de que desea insuscribir estos usuarios?";

                if (DialogResult.Yes == MessageBox.Show(texto, "Ventana de confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
                {
                    DataGridViewSelectedRowCollection filas = dataGridView_Usuarios.SelectedRows;

                    foreach (DataGridViewRow i in filas)
                    {
                        // Se borra de la lista y de la base de datos.
                        ENUsuario usuario = ENUsuario.Obtener(int.Parse(i.Cells[0].Value.ToString()));
                        if (!seleccionada.InsuscribirUsuario(usuario))
                        {
                            MessageBox.Show("Error al insuscribir al usuario: " + usuario.Id, "Error de insuscripción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            FormPanelAdministracion.Instancia.MensajeEstado("Usuario/s insuscrito/s correctamente.");
                            treeViewCategorias.SelectedNode = sel;
                            treeViewCategorias.Focus();
                            numPagina = 1;
                            rellenarGridUsuarios(seleccionada);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay ningún usuario sleccionado.", "Error de insuscripción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void FormCategorias_VisibleChanged(object sender, EventArgs e)
        {
            FormPanelAdministracion.Instancia.MensajeEstado(ultimoMensaje);
            if (sel != null)
            {
                treeViewCategorias.SelectedNode = sel;
                treeViewCategorias.Focus();
            }
        }

        /// <summary>
        /// Envia el objeto seleccionado en este formulario para la navegación.
        /// </summary>
        override public Object Enviar()
        {
            return seleccionada;
        }

        /// <summary>
        /// Recibe un objeto de otro formulario tras la navegación.
        /// </summary>
        /// <param name="objeto">Objeto recibido.</param>
        public override void Recibir(Object objeto)
        {
            if (objeto != null)
            {
                if (objeto is ENUsuario && seleccionada != null)
                {
                        ENUsuario u = (ENUsuario)objeto;

                        if (seleccionada.SuscribirUsuario(u))
                        {
                            dataGridView_Usuarios.Rows.Add(u.Id, u.Usuario, u.Nombre);
                            ultimoMensaje = "";
                            FormPanelAdministracion.Instancia.MensajeEstado(u.Usuario.ToString() + " suscrito correctamente.");
                            treeViewCategorias.SelectedNode = sel;
                            treeViewCategorias.Focus();
                            numPagina = 1;
                            rellenarGridUsuarios(seleccionada);
                        }
                        else
                            MessageBox.Show("No ha sido posible suscribir a este usuario.", "Error de suscripción", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void button_Anterior_Click(object sender, EventArgs e)
        {
            if (numPagina == totalPaginas)
                button_Siguiente.Enabled = true;

            numPagina--;
            rellenarGridUsuarios(seleccionada);
        }

        private void button_Siguiente_Click(object sender, EventArgs e)
        {
            if(numPagina == 1)
                button_Anterior.Enabled = true;

            numPagina++;
            rellenarGridUsuarios(seleccionada);
        }

        private void comboBox_pagina_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (numPagina == 1)
                button_Anterior.Enabled = true;
            if (numPagina == totalPaginas)
                button_Siguiente.Enabled = true;

            numPagina = int.Parse(comboBox_pagina.SelectedItem.ToString());


            rellenarGridUsuarios(seleccionada);
        }
    }
}
