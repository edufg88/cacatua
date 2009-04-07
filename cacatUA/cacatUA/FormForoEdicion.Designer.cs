namespace cacatUA
{
    partial class FormForoEdicion
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel6 = new System.Windows.Forms.Panel();
            this.linkLabel_respuestas = new System.Windows.Forms.LinkLabel();
            this.textBox_respuestas = new System.Windows.Forms.TextBox();
            this.label_respuestas = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dateTimePicker_fecha = new System.Windows.Forms.DateTimePicker();
            this.label_fechaCreacion = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBox_texto = new System.Windows.Forms.TextBox();
            this.label_texto = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button_seleccionarCategoria = new System.Windows.Forms.Button();
            this.textBox_categoria = new System.Windows.Forms.TextBox();
            this.label_categoria = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_seleccionarUsuario = new System.Windows.Forms.Button();
            this.textBox_autor = new System.Windows.Forms.TextBox();
            this.label_autor = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.label_id = new System.Windows.Forms.Label();
            this.textBox_titulo = new System.Windows.Forms.TextBox();
            this.label_titulo = new System.Windows.Forms.Label();
            this.tableLayoutPanel_secundario = new System.Windows.Forms.TableLayoutPanel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.button_descartarCambios = new System.Windows.Forms.Button();
            this.button_guardarCambios = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel_secundario.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.linkLabel_respuestas);
            this.panel6.Controls.Add(this.textBox_respuestas);
            this.panel6.Controls.Add(this.label_respuestas);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 180);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(889, 30);
            this.panel6.TabIndex = 7;
            // 
            // linkLabel_respuestas
            // 
            this.linkLabel_respuestas.AutoSize = true;
            this.linkLabel_respuestas.Location = new System.Drawing.Point(192, 8);
            this.linkLabel_respuestas.Name = "linkLabel_respuestas";
            this.linkLabel_respuestas.Size = new System.Drawing.Size(113, 13);
            this.linkLabel_respuestas.TabIndex = 0;
            this.linkLabel_respuestas.TabStop = true;
            this.linkLabel_respuestas.Text = "Ver respuestas del hilo";
            this.linkLabel_respuestas.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_respuestas_LinkClicked);
            // 
            // textBox_respuestas
            // 
            this.textBox_respuestas.Location = new System.Drawing.Point(125, 5);
            this.textBox_respuestas.Name = "textBox_respuestas";
            this.textBox_respuestas.ReadOnly = true;
            this.textBox_respuestas.Size = new System.Drawing.Size(59, 20);
            this.textBox_respuestas.TabIndex = 3;
            this.textBox_respuestas.TabStop = false;
            // 
            // label_respuestas
            // 
            this.label_respuestas.AutoSize = true;
            this.label_respuestas.Location = new System.Drawing.Point(16, 8);
            this.label_respuestas.Name = "label_respuestas";
            this.label_respuestas.Size = new System.Drawing.Size(91, 13);
            this.label_respuestas.TabIndex = 0;
            this.label_respuestas.Text = "Nº de respuestas:";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dateTimePicker_fecha);
            this.panel5.Controls.Add(this.label_fechaCreacion);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 150);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(889, 30);
            this.panel5.TabIndex = 5;
            // 
            // dateTimePicker_fecha
            // 
            this.dateTimePicker_fecha.Location = new System.Drawing.Point(125, 5);
            this.dateTimePicker_fecha.Name = "dateTimePicker_fecha";
            this.dateTimePicker_fecha.Size = new System.Drawing.Size(235, 20);
            this.dateTimePicker_fecha.TabIndex = 0;
            this.dateTimePicker_fecha.ValueChanged += new System.EventHandler(this.formulario_Modificado);
            // 
            // label_fechaCreacion
            // 
            this.label_fechaCreacion.AutoSize = true;
            this.label_fechaCreacion.Location = new System.Drawing.Point(16, 8);
            this.label_fechaCreacion.Name = "label_fechaCreacion";
            this.label_fechaCreacion.Size = new System.Drawing.Size(99, 13);
            this.label_fechaCreacion.TabIndex = 0;
            this.label_fechaCreacion.Text = "Fecha de creación:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.textBox_texto);
            this.panel4.Controls.Add(this.label_texto);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 90);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(889, 60);
            this.panel4.TabIndex = 4;
            // 
            // textBox_texto
            // 
            this.textBox_texto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_texto.Location = new System.Drawing.Point(125, 6);
            this.textBox_texto.Multiline = true;
            this.textBox_texto.Name = "textBox_texto";
            this.textBox_texto.Size = new System.Drawing.Size(729, 49);
            this.textBox_texto.TabIndex = 0;
            this.textBox_texto.TextChanged += new System.EventHandler(this.formulario_Modificado);
            // 
            // label_texto
            // 
            this.label_texto.AutoSize = true;
            this.label_texto.Location = new System.Drawing.Point(16, 8);
            this.label_texto.Name = "label_texto";
            this.label_texto.Size = new System.Drawing.Size(37, 13);
            this.label_texto.TabIndex = 0;
            this.label_texto.Text = "Texto:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button_seleccionarCategoria);
            this.panel3.Controls.Add(this.textBox_categoria);
            this.panel3.Controls.Add(this.label_categoria);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 60);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(889, 30);
            this.panel3.TabIndex = 3;
            // 
            // button_seleccionarCategoria
            // 
            this.button_seleccionarCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_seleccionarCategoria.BackColor = System.Drawing.SystemColors.Window;
            this.button_seleccionarCategoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_seleccionarCategoria.FlatAppearance.BorderSize = 0;
            this.button_seleccionarCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_seleccionarCategoria.Image = global::cacatUA.Properties.Resources.seleccionar1;
            this.button_seleccionarCategoria.Location = new System.Drawing.Point(833, 6);
            this.button_seleccionarCategoria.Name = "button_seleccionarCategoria";
            this.button_seleccionarCategoria.Size = new System.Drawing.Size(20, 18);
            this.button_seleccionarCategoria.TabIndex = 143;
            this.button_seleccionarCategoria.TabStop = false;
            this.toolTip1.SetToolTip(this.button_seleccionarCategoria, "Haz clic para seleccionar una categoría de la lista");
            this.button_seleccionarCategoria.UseVisualStyleBackColor = false;
            this.button_seleccionarCategoria.Click += new System.EventHandler(this.button_seleccionarCategoria_Click);
            // 
            // textBox_categoria
            // 
            this.textBox_categoria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_categoria.Location = new System.Drawing.Point(125, 5);
            this.textBox_categoria.Name = "textBox_categoria";
            this.textBox_categoria.ReadOnly = true;
            this.textBox_categoria.Size = new System.Drawing.Size(729, 20);
            this.textBox_categoria.TabIndex = 0;
            this.textBox_categoria.TextChanged += new System.EventHandler(this.formulario_Modificado);
            // 
            // label_categoria
            // 
            this.label_categoria.AutoSize = true;
            this.label_categoria.Location = new System.Drawing.Point(16, 8);
            this.label_categoria.Name = "label_categoria";
            this.label_categoria.Size = new System.Drawing.Size(57, 13);
            this.label_categoria.TabIndex = 0;
            this.label_categoria.Text = "Categoría:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button_seleccionarUsuario);
            this.panel2.Controls.Add(this.textBox_autor);
            this.panel2.Controls.Add(this.label_autor);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 30);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(889, 30);
            this.panel2.TabIndex = 2;
            // 
            // button_seleccionarUsuario
            // 
            this.button_seleccionarUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_seleccionarUsuario.BackColor = System.Drawing.SystemColors.Window;
            this.button_seleccionarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_seleccionarUsuario.FlatAppearance.BorderSize = 0;
            this.button_seleccionarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_seleccionarUsuario.Image = global::cacatUA.Properties.Resources.seleccionar1;
            this.button_seleccionarUsuario.Location = new System.Drawing.Point(833, 6);
            this.button_seleccionarUsuario.Name = "button_seleccionarUsuario";
            this.button_seleccionarUsuario.Size = new System.Drawing.Size(20, 18);
            this.button_seleccionarUsuario.TabIndex = 144;
            this.button_seleccionarUsuario.TabStop = false;
            this.toolTip1.SetToolTip(this.button_seleccionarUsuario, "Haz clic para seleccionar un usuario de la lista");
            this.button_seleccionarUsuario.UseVisualStyleBackColor = false;
            this.button_seleccionarUsuario.Click += new System.EventHandler(this.button_seleccionarUsuario_Click);
            // 
            // textBox_autor
            // 
            this.textBox_autor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_autor.Location = new System.Drawing.Point(125, 5);
            this.textBox_autor.Name = "textBox_autor";
            this.textBox_autor.Size = new System.Drawing.Size(729, 20);
            this.textBox_autor.TabIndex = 0;
            this.textBox_autor.TextChanged += new System.EventHandler(this.formulario_Modificado);
            // 
            // label_autor
            // 
            this.label_autor.AutoSize = true;
            this.label_autor.Location = new System.Drawing.Point(16, 8);
            this.label_autor.Name = "label_autor";
            this.label_autor.Size = new System.Drawing.Size(35, 13);
            this.label_autor.TabIndex = 0;
            this.label_autor.Text = "Autor:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox_id);
            this.panel1.Controls.Add(this.label_id);
            this.panel1.Controls.Add(this.textBox_titulo);
            this.panel1.Controls.Add(this.label_titulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(889, 30);
            this.panel1.TabIndex = 1;
            // 
            // textBox_id
            // 
            this.textBox_id.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_id.Location = new System.Drawing.Point(805, 5);
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.ReadOnly = true;
            this.textBox_id.Size = new System.Drawing.Size(49, 20);
            this.textBox_id.TabIndex = 4;
            this.textBox_id.TabStop = false;
            // 
            // label_id
            // 
            this.label_id.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_id.AutoSize = true;
            this.label_id.Location = new System.Drawing.Point(778, 8);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(21, 13);
            this.label_id.TabIndex = 3;
            this.label_id.Text = "ID:";
            // 
            // textBox_titulo
            // 
            this.textBox_titulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_titulo.Location = new System.Drawing.Point(125, 5);
            this.textBox_titulo.Name = "textBox_titulo";
            this.textBox_titulo.Size = new System.Drawing.Size(624, 20);
            this.textBox_titulo.TabIndex = 0;
            this.textBox_titulo.TextChanged += new System.EventHandler(this.formulario_Modificado);
            // 
            // label_titulo
            // 
            this.label_titulo.AutoSize = true;
            this.label_titulo.Location = new System.Drawing.Point(16, 8);
            this.label_titulo.Name = "label_titulo";
            this.label_titulo.Size = new System.Drawing.Size(38, 13);
            this.label_titulo.TabIndex = 0;
            this.label_titulo.Text = "Título:";
            // 
            // tableLayoutPanel_secundario
            // 
            this.tableLayoutPanel_secundario.ColumnCount = 1;
            this.tableLayoutPanel_secundario.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_secundario.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel_secundario.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel_secundario.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel_secundario.Controls.Add(this.panel4, 0, 3);
            this.tableLayoutPanel_secundario.Controls.Add(this.panel5, 0, 4);
            this.tableLayoutPanel_secundario.Controls.Add(this.panel6, 0, 5);
            this.tableLayoutPanel_secundario.Controls.Add(this.panel7, 0, 6);
            this.tableLayoutPanel_secundario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_secundario.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_secundario.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_secundario.Name = "tableLayoutPanel_secundario";
            this.tableLayoutPanel_secundario.RowCount = 7;
            this.tableLayoutPanel_secundario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_secundario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_secundario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_secundario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel_secundario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_secundario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_secundario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_secundario.Size = new System.Drawing.Size(889, 240);
            this.tableLayoutPanel_secundario.TabIndex = 6;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.button_descartarCambios);
            this.panel7.Controls.Add(this.button_guardarCambios);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 210);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(889, 30);
            this.panel7.TabIndex = 8;
            // 
            // button_descartarCambios
            // 
            this.button_descartarCambios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_descartarCambios.Location = new System.Drawing.Point(732, 3);
            this.button_descartarCambios.Name = "button_descartarCambios";
            this.button_descartarCambios.Size = new System.Drawing.Size(121, 23);
            this.button_descartarCambios.TabIndex = 1;
            this.button_descartarCambios.Text = "Descartar cambios";
            this.button_descartarCambios.UseVisualStyleBackColor = true;
            this.button_descartarCambios.Click += new System.EventHandler(this.button_descartarCambios_Click);
            // 
            // button_guardarCambios
            // 
            this.button_guardarCambios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_guardarCambios.Location = new System.Drawing.Point(616, 3);
            this.button_guardarCambios.Name = "button_guardarCambios";
            this.button_guardarCambios.Size = new System.Drawing.Size(110, 23);
            this.button_guardarCambios.TabIndex = 0;
            this.button_guardarCambios.Text = "Guardar cambios";
            this.button_guardarCambios.UseVisualStyleBackColor = true;
            this.button_guardarCambios.Click += new System.EventHandler(this.button_guardarCambios_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FormForoEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel_secundario);
            this.Name = "FormForoEdicion";
            this.Size = new System.Drawing.Size(889, 240);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel_secundario.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.LinkLabel linkLabel_respuestas;
        private System.Windows.Forms.TextBox textBox_respuestas;
        private System.Windows.Forms.Label label_respuestas;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DateTimePicker dateTimePicker_fecha;
        private System.Windows.Forms.Label label_fechaCreacion;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBox_texto;
        private System.Windows.Forms.Label label_texto;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button_seleccionarCategoria;
        private System.Windows.Forms.TextBox textBox_categoria;
        private System.Windows.Forms.Label label_categoria;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_seleccionarUsuario;
        private System.Windows.Forms.TextBox textBox_autor;
        private System.Windows.Forms.Label label_autor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_id;
        private System.Windows.Forms.Label label_id;
        private System.Windows.Forms.TextBox textBox_titulo;
        private System.Windows.Forms.Label label_titulo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_secundario;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button button_guardarCambios;
        private System.Windows.Forms.Button button_descartarCambios;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolTip toolTip1;

    }
}
