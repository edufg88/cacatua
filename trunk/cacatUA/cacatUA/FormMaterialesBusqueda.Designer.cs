namespace cacatUA
{
    partial class FormMaterialesBusqueda
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button_seleccionarUsuario = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.textBox_usuario = new System.Windows.Forms.TextBox();
            this.label_autor = new System.Windows.Forms.Label();
            this.textBox_filtroBusqueda = new System.Windows.Forms.TextBox();
            this.button_buscar = new System.Windows.Forms.Button();
            this.label_filtroBusqueda = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel_secundario = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button_seleccionarCategoria = new System.Windows.Forms.Button();
            this.textBox_categoria = new System.Windows.Forms.TextBox();
            this.label_categoria = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dateTimePicker_fechaFin = new System.Windows.Forms.DateTimePicker();
            this.label_hasta = new System.Windows.Forms.Label();
            this.dateTimePicker_fechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label_mostrarDesde = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button_limpiar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.tableLayoutPanel_secundario.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_seleccionarUsuario
            // 
            this.button_seleccionarUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_seleccionarUsuario.BackColor = System.Drawing.SystemColors.Window;
            this.button_seleccionarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_seleccionarUsuario.FlatAppearance.BorderSize = 0;
            this.button_seleccionarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_seleccionarUsuario.Image = global::cacatUA.Properties.Resources.seleccionar1;
            this.button_seleccionarUsuario.Location = new System.Drawing.Point(709, 6);
            this.button_seleccionarUsuario.Name = "button_seleccionarUsuario";
            this.button_seleccionarUsuario.Size = new System.Drawing.Size(20, 18);
            this.button_seleccionarUsuario.TabIndex = 144;
            this.button_seleccionarUsuario.UseVisualStyleBackColor = false;
            this.button_seleccionarUsuario.Click += new System.EventHandler(this.seleccionarUsuario);
            // 
            // textBox_usuario
            // 
            this.textBox_usuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_usuario.Location = new System.Drawing.Point(125, 5);
            this.textBox_usuario.Name = "textBox_usuario";
            this.textBox_usuario.Size = new System.Drawing.Size(605, 20);
            this.textBox_usuario.TabIndex = 2;
            // 
            // label_autor
            // 
            this.label_autor.AutoSize = true;
            this.label_autor.Location = new System.Drawing.Point(16, 8);
            this.label_autor.Name = "label_autor";
            this.label_autor.Size = new System.Drawing.Size(46, 13);
            this.label_autor.TabIndex = 0;
            this.label_autor.Text = "Usuario:";
            // 
            // textBox_filtroBusqueda
            // 
            this.textBox_filtroBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_filtroBusqueda.Location = new System.Drawing.Point(125, 5);
            this.textBox_filtroBusqueda.Name = "textBox_filtroBusqueda";
            this.textBox_filtroBusqueda.Size = new System.Drawing.Size(605, 20);
            this.textBox_filtroBusqueda.TabIndex = 1;
            // 
            // button_buscar
            // 
            this.button_buscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_buscar.Location = new System.Drawing.Point(573, 4);
            this.button_buscar.Name = "button_buscar";
            this.button_buscar.Size = new System.Drawing.Size(75, 23);
            this.button_buscar.TabIndex = 0;
            this.button_buscar.Text = "Buscar";
            this.button_buscar.UseVisualStyleBackColor = true;
            this.button_buscar.Click += new System.EventHandler(this.buscarMaterial);
            // 
            // label_filtroBusqueda
            // 
            this.label_filtroBusqueda.AutoSize = true;
            this.label_filtroBusqueda.Location = new System.Drawing.Point(16, 8);
            this.label_filtroBusqueda.Name = "label_filtroBusqueda";
            this.label_filtroBusqueda.Size = new System.Drawing.Size(97, 13);
            this.label_filtroBusqueda.TabIndex = 0;
            this.label_filtroBusqueda.Text = "Filtro de búsqueda:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox_filtroBusqueda);
            this.panel1.Controls.Add(this.label_filtroBusqueda);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(765, 30);
            this.panel1.TabIndex = 0;
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
            this.tableLayoutPanel_secundario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_secundario.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_secundario.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_secundario.Name = "tableLayoutPanel_secundario";
            this.tableLayoutPanel_secundario.RowCount = 5;
            this.tableLayoutPanel_secundario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_secundario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_secundario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_secundario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_secundario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_secundario.Size = new System.Drawing.Size(765, 150);
            this.tableLayoutPanel_secundario.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button_seleccionarUsuario);
            this.panel2.Controls.Add(this.textBox_usuario);
            this.panel2.Controls.Add(this.label_autor);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 30);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(765, 30);
            this.panel2.TabIndex = 2;
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
            this.panel3.Size = new System.Drawing.Size(765, 30);
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
            this.button_seleccionarCategoria.Location = new System.Drawing.Point(709, 6);
            this.button_seleccionarCategoria.Name = "button_seleccionarCategoria";
            this.button_seleccionarCategoria.Size = new System.Drawing.Size(20, 18);
            this.button_seleccionarCategoria.TabIndex = 143;
            this.button_seleccionarCategoria.UseVisualStyleBackColor = false;
            this.button_seleccionarCategoria.Click += new System.EventHandler(this.seleccionarCategoria);
            // 
            // textBox_categoria
            // 
            this.textBox_categoria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_categoria.Location = new System.Drawing.Point(125, 5);
            this.textBox_categoria.Name = "textBox_categoria";
            this.textBox_categoria.ReadOnly = true;
            this.textBox_categoria.Size = new System.Drawing.Size(605, 20);
            this.textBox_categoria.TabIndex = 2;
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
            // panel4
            // 
            this.panel4.Controls.Add(this.dateTimePicker_fechaFin);
            this.panel4.Controls.Add(this.label_hasta);
            this.panel4.Controls.Add(this.dateTimePicker_fechaInicio);
            this.panel4.Controls.Add(this.label_mostrarDesde);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 90);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(765, 30);
            this.panel4.TabIndex = 6;
            // 
            // dateTimePicker_fechaFin
            // 
            this.dateTimePicker_fechaFin.CustomFormat = "dddd, dd \'de\' MMMM \'de\' yyyy, H:mm:ss";
            this.dateTimePicker_fechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_fechaFin.Location = new System.Drawing.Point(429, 5);
            this.dateTimePicker_fechaFin.Name = "dateTimePicker_fechaFin";
            this.dateTimePicker_fechaFin.ShowUpDown = true;
            this.dateTimePicker_fechaFin.Size = new System.Drawing.Size(250, 20);
            this.dateTimePicker_fechaFin.TabIndex = 3;
            // 
            // label_hasta
            // 
            this.label_hasta.AutoSize = true;
            this.label_hasta.Location = new System.Drawing.Point(386, 9);
            this.label_hasta.Name = "label_hasta";
            this.label_hasta.Size = new System.Drawing.Size(33, 13);
            this.label_hasta.TabIndex = 2;
            this.label_hasta.Text = "hasta";
            // 
            // dateTimePicker_fechaInicio
            // 
            this.dateTimePicker_fechaInicio.CustomFormat = "dddd, dd \'de\' MMMM \'de\' yyyy, H:mm:ss";
            this.dateTimePicker_fechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_fechaInicio.Location = new System.Drawing.Point(125, 5);
            this.dateTimePicker_fechaInicio.Name = "dateTimePicker_fechaInicio";
            this.dateTimePicker_fechaInicio.ShowUpDown = true;
            this.dateTimePicker_fechaInicio.Size = new System.Drawing.Size(250, 20);
            this.dateTimePicker_fechaInicio.TabIndex = 1;
            // 
            // label_mostrarDesde
            // 
            this.label_mostrarDesde.AutoSize = true;
            this.label_mostrarDesde.Location = new System.Drawing.Point(16, 8);
            this.label_mostrarDesde.Name = "label_mostrarDesde";
            this.label_mostrarDesde.Size = new System.Drawing.Size(74, 13);
            this.label_mostrarDesde.TabIndex = 0;
            this.label_mostrarDesde.Text = "Mostrar desde";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.button_limpiar);
            this.panel5.Controls.Add(this.button_buscar);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 120);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(765, 30);
            this.panel5.TabIndex = 7;
            // 
            // button_limpiar
            // 
            this.button_limpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_limpiar.Location = new System.Drawing.Point(654, 4);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(75, 23);
            this.button_limpiar.TabIndex = 8;
            this.button_limpiar.Text = "Limpiar";
            this.button_limpiar.UseVisualStyleBackColor = true;
            this.button_limpiar.Click += new System.EventHandler(this.limpiarFormulario);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FormMaterialesBusqueda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel_secundario);
            this.Name = "FormMaterialesBusqueda";
            this.Size = new System.Drawing.Size(765, 150);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel_secundario.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_seleccionarUsuario;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox textBox_usuario;
        private System.Windows.Forms.Label label_autor;
        private System.Windows.Forms.TextBox textBox_filtroBusqueda;
        private System.Windows.Forms.Button button_buscar;
        private System.Windows.Forms.Label label_filtroBusqueda;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_secundario;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button_seleccionarCategoria;
        private System.Windows.Forms.TextBox textBox_categoria;
        private System.Windows.Forms.Label label_categoria;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DateTimePicker dateTimePicker_fechaFin;
        private System.Windows.Forms.Label label_hasta;
        private System.Windows.Forms.DateTimePicker dateTimePicker_fechaInicio;
        private System.Windows.Forms.Label label_mostrarDesde;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button button_limpiar;

    }
}
