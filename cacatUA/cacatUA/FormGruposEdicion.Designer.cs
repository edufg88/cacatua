namespace cacatUA
{
    partial class FormGruposEdicion
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
            this.tableLayoutPanel_secundario = new System.Windows.Forms.TableLayoutPanel();
            this.panel_nombre = new System.Windows.Forms.Panel();
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.label_id = new System.Windows.Forms.Label();
            this.textBox_nombre = new System.Windows.Forms.TextBox();
            this.label_nombre = new System.Windows.Forms.Label();
            this.panel_descripcion = new System.Windows.Forms.Panel();
            this.textBox_descripcion = new System.Windows.Forms.TextBox();
            this.label_descripcion = new System.Windows.Forms.Label();
            this.panel_fecha = new System.Windows.Forms.Panel();
            this.dateTimePicker_fecha = new System.Windows.Forms.DateTimePicker();
            this.label_fecha = new System.Windows.Forms.Label();
            this.panel_usuarios = new System.Windows.Forms.Panel();
            this.button_verUsuario = new System.Windows.Forms.Button();
            this.button_addUsuario = new System.Windows.Forms.Button();
            this.button_borrar = new System.Windows.Forms.Button();
            this.listBox_usuarios = new System.Windows.Forms.ListBox();
            this.label_usuarios = new System.Windows.Forms.Label();
            this.panel_numUsuarios = new System.Windows.Forms.Panel();
            this.textBox_numUsuarios = new System.Windows.Forms.TextBox();
            this.label_numUsuarios = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_descartarCambios = new System.Windows.Forms.Button();
            this.button_guardar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel_secundario.SuspendLayout();
            this.panel_nombre.SuspendLayout();
            this.panel_descripcion.SuspendLayout();
            this.panel_fecha.SuspendLayout();
            this.panel_usuarios.SuspendLayout();
            this.panel_numUsuarios.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_secundario
            // 
            this.tableLayoutPanel_secundario.ColumnCount = 1;
            this.tableLayoutPanel_secundario.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_secundario.Controls.Add(this.panel_nombre, 0, 0);
            this.tableLayoutPanel_secundario.Controls.Add(this.panel_descripcion, 0, 1);
            this.tableLayoutPanel_secundario.Controls.Add(this.panel_fecha, 0, 2);
            this.tableLayoutPanel_secundario.Controls.Add(this.panel_usuarios, 0, 4);
            this.tableLayoutPanel_secundario.Controls.Add(this.panel_numUsuarios, 0, 3);
            this.tableLayoutPanel_secundario.Controls.Add(this.panel1, 0, 5);
            this.tableLayoutPanel_secundario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_secundario.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_secundario.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_secundario.Name = "tableLayoutPanel_secundario";
            this.tableLayoutPanel_secundario.RowCount = 6;
            this.tableLayoutPanel_secundario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_secundario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_secundario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_secundario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_secundario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_secundario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel_secundario.Size = new System.Drawing.Size(899, 309);
            this.tableLayoutPanel_secundario.TabIndex = 99;
            // 
            // panel_nombre
            // 
            this.panel_nombre.Controls.Add(this.textBox_id);
            this.panel_nombre.Controls.Add(this.label_id);
            this.panel_nombre.Controls.Add(this.textBox_nombre);
            this.panel_nombre.Controls.Add(this.label_nombre);
            this.panel_nombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_nombre.Location = new System.Drawing.Point(0, 0);
            this.panel_nombre.Margin = new System.Windows.Forms.Padding(0);
            this.panel_nombre.Name = "panel_nombre";
            this.panel_nombre.Size = new System.Drawing.Size(899, 30);
            this.panel_nombre.TabIndex = 1;
            // 
            // textBox_id
            // 
            this.textBox_id.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_id.Location = new System.Drawing.Point(806, 5);
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.ReadOnly = true;
            this.textBox_id.Size = new System.Drawing.Size(57, 20);
            this.textBox_id.TabIndex = 0;
            // 
            // label_id
            // 
            this.label_id.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_id.AutoSize = true;
            this.label_id.Location = new System.Drawing.Point(779, 8);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(21, 13);
            this.label_id.TabIndex = 147;
            this.label_id.Text = "ID:";
            // 
            // textBox_nombre
            // 
            this.textBox_nombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_nombre.Location = new System.Drawing.Point(124, 5);
            this.textBox_nombre.Name = "textBox_nombre";
            this.textBox_nombre.Size = new System.Drawing.Size(638, 20);
            this.textBox_nombre.TabIndex = 1;
            this.textBox_nombre.TextChanged += new System.EventHandler(this.textBox_Modificado);
            // 
            // label_nombre
            // 
            this.label_nombre.AutoSize = true;
            this.label_nombre.Location = new System.Drawing.Point(16, 8);
            this.label_nombre.Name = "label_nombre";
            this.label_nombre.Size = new System.Drawing.Size(47, 13);
            this.label_nombre.TabIndex = 0;
            this.label_nombre.Text = "Nombre:";
            // 
            // panel_descripcion
            // 
            this.panel_descripcion.Controls.Add(this.textBox_descripcion);
            this.panel_descripcion.Controls.Add(this.label_descripcion);
            this.panel_descripcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_descripcion.Location = new System.Drawing.Point(0, 30);
            this.panel_descripcion.Margin = new System.Windows.Forms.Padding(0);
            this.panel_descripcion.Name = "panel_descripcion";
            this.panel_descripcion.Size = new System.Drawing.Size(899, 93);
            this.panel_descripcion.TabIndex = 4;
            // 
            // textBox_descripcion
            // 
            this.textBox_descripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_descripcion.Location = new System.Drawing.Point(125, 6);
            this.textBox_descripcion.Multiline = true;
            this.textBox_descripcion.Name = "textBox_descripcion";
            this.textBox_descripcion.Size = new System.Drawing.Size(738, 84);
            this.textBox_descripcion.TabIndex = 2;
            this.textBox_descripcion.TextChanged += new System.EventHandler(this.textBox_Modificado);
            // 
            // label_descripcion
            // 
            this.label_descripcion.AutoSize = true;
            this.label_descripcion.Location = new System.Drawing.Point(16, 8);
            this.label_descripcion.Name = "label_descripcion";
            this.label_descripcion.Size = new System.Drawing.Size(66, 13);
            this.label_descripcion.TabIndex = 0;
            this.label_descripcion.Text = "Descripción:";
            // 
            // panel_fecha
            // 
            this.panel_fecha.Controls.Add(this.dateTimePicker_fecha);
            this.panel_fecha.Controls.Add(this.label_fecha);
            this.panel_fecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_fecha.Location = new System.Drawing.Point(0, 123);
            this.panel_fecha.Margin = new System.Windows.Forms.Padding(0);
            this.panel_fecha.Name = "panel_fecha";
            this.panel_fecha.Size = new System.Drawing.Size(899, 30);
            this.panel_fecha.TabIndex = 5;
            // 
            // dateTimePicker_fecha
            // 
            this.dateTimePicker_fecha.CustomFormat = "dddd, dd \'de\' MMMM \'de\' yyyy, H:mm:ss";
            this.dateTimePicker_fecha.Enabled = false;
            this.dateTimePicker_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_fecha.Location = new System.Drawing.Point(125, 5);
            this.dateTimePicker_fecha.Name = "dateTimePicker_fecha";
            this.dateTimePicker_fecha.ShowUpDown = true;
            this.dateTimePicker_fecha.Size = new System.Drawing.Size(250, 20);
            this.dateTimePicker_fecha.TabIndex = 3;
            this.dateTimePicker_fecha.ValueChanged += new System.EventHandler(this.textBox_Modificado);
            // 
            // label_fecha
            // 
            this.label_fecha.AutoSize = true;
            this.label_fecha.Location = new System.Drawing.Point(16, 8);
            this.label_fecha.Name = "label_fecha";
            this.label_fecha.Size = new System.Drawing.Size(99, 13);
            this.label_fecha.TabIndex = 0;
            this.label_fecha.Text = "Fecha de creación:";
            // 
            // panel_usuarios
            // 
            this.panel_usuarios.Controls.Add(this.button_verUsuario);
            this.panel_usuarios.Controls.Add(this.button_addUsuario);
            this.panel_usuarios.Controls.Add(this.button_borrar);
            this.panel_usuarios.Controls.Add(this.listBox_usuarios);
            this.panel_usuarios.Controls.Add(this.label_usuarios);
            this.panel_usuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_usuarios.Location = new System.Drawing.Point(0, 183);
            this.panel_usuarios.Margin = new System.Windows.Forms.Padding(0);
            this.panel_usuarios.Name = "panel_usuarios";
            this.panel_usuarios.Size = new System.Drawing.Size(899, 93);
            this.panel_usuarios.TabIndex = 9;
            // 
            // button_verUsuario
            // 
            this.button_verUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_verUsuario.FlatAppearance.BorderSize = 0;
            this.button_verUsuario.Location = new System.Drawing.Point(460, 10);
            this.button_verUsuario.Name = "button_verUsuario";
            this.button_verUsuario.Size = new System.Drawing.Size(100, 25);
            this.button_verUsuario.TabIndex = 15;
            this.button_verUsuario.Text = "Ver usuario";
            this.toolTip1.SetToolTip(this.button_verUsuario, "Añadir un miembro al grupo");
            this.button_verUsuario.UseVisualStyleBackColor = true;
            this.button_verUsuario.Click += new System.EventHandler(this.button_verUsuario_Click);
            // 
            // button_addUsuario
            // 
            this.button_addUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_addUsuario.FlatAppearance.BorderSize = 0;
            this.button_addUsuario.Location = new System.Drawing.Point(460, 38);
            this.button_addUsuario.Name = "button_addUsuario";
            this.button_addUsuario.Size = new System.Drawing.Size(100, 25);
            this.button_addUsuario.TabIndex = 13;
            this.button_addUsuario.Text = "Añadir usuario";
            this.toolTip1.SetToolTip(this.button_addUsuario, "Añadir un miembro al grupo");
            this.button_addUsuario.UseVisualStyleBackColor = true;
            this.button_addUsuario.Click += new System.EventHandler(this.button_addUsuario_Click);
            // 
            // button_borrar
            // 
            this.button_borrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_borrar.FlatAppearance.BorderSize = 0;
            this.button_borrar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_borrar.Location = new System.Drawing.Point(460, 66);
            this.button_borrar.Name = "button_borrar";
            this.button_borrar.Size = new System.Drawing.Size(100, 25);
            this.button_borrar.TabIndex = 14;
            this.button_borrar.Tag = "";
            this.button_borrar.Text = "Quitar usuario";
            this.toolTip1.SetToolTip(this.button_borrar, "Borrar miembro del grupo");
            this.button_borrar.UseVisualStyleBackColor = true;
            this.button_borrar.Click += new System.EventHandler(this.button_borrar_Click);
            // 
            // listBox_usuarios
            // 
            this.listBox_usuarios.ColumnWidth = 50;
            this.listBox_usuarios.FormattingEnabled = true;
            this.listBox_usuarios.Location = new System.Drawing.Point(125, 10);
            this.listBox_usuarios.Name = "listBox_usuarios";
            this.listBox_usuarios.Size = new System.Drawing.Size(320, 82);
            this.listBox_usuarios.TabIndex = 4;
            this.listBox_usuarios.DoubleClick += new System.EventHandler(this.listBox_usuarios_DoubleClick);
            // 
            // label_usuarios
            // 
            this.label_usuarios.AutoSize = true;
            this.label_usuarios.Location = new System.Drawing.Point(16, 10);
            this.label_usuarios.Name = "label_usuarios";
            this.label_usuarios.Size = new System.Drawing.Size(51, 13);
            this.label_usuarios.TabIndex = 0;
            this.label_usuarios.Text = "Usuarios:";
            // 
            // panel_numUsuarios
            // 
            this.panel_numUsuarios.Controls.Add(this.textBox_numUsuarios);
            this.panel_numUsuarios.Controls.Add(this.label_numUsuarios);
            this.panel_numUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_numUsuarios.Location = new System.Drawing.Point(0, 153);
            this.panel_numUsuarios.Margin = new System.Windows.Forms.Padding(0);
            this.panel_numUsuarios.Name = "panel_numUsuarios";
            this.panel_numUsuarios.Size = new System.Drawing.Size(899, 30);
            this.panel_numUsuarios.TabIndex = 10;
            // 
            // textBox_numUsuarios
            // 
            this.textBox_numUsuarios.Enabled = false;
            this.textBox_numUsuarios.Location = new System.Drawing.Point(124, 7);
            this.textBox_numUsuarios.Name = "textBox_numUsuarios";
            this.textBox_numUsuarios.Size = new System.Drawing.Size(100, 20);
            this.textBox_numUsuarios.TabIndex = 1;
            // 
            // label_numUsuarios
            // 
            this.label_numUsuarios.AutoSize = true;
            this.label_numUsuarios.Location = new System.Drawing.Point(16, 10);
            this.label_numUsuarios.Name = "label_numUsuarios";
            this.label_numUsuarios.Size = new System.Drawing.Size(79, 13);
            this.label_numUsuarios.TabIndex = 0;
            this.label_numUsuarios.Text = "Nº de usuarios:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_descartarCambios);
            this.panel1.Controls.Add(this.button_guardar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 276);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(899, 33);
            this.panel1.TabIndex = 11;
            // 
            // button_descartarCambios
            // 
            this.button_descartarCambios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_descartarCambios.Location = new System.Drawing.Point(753, 6);
            this.button_descartarCambios.Name = "button_descartarCambios";
            this.button_descartarCambios.Size = new System.Drawing.Size(110, 23);
            this.button_descartarCambios.TabIndex = 2;
            this.button_descartarCambios.Text = "Descartar cambios";
            this.button_descartarCambios.UseVisualStyleBackColor = true;
            this.button_descartarCambios.Click += new System.EventHandler(this.button_descartarCambios_Click);
            // 
            // button_guardar
            // 
            this.button_guardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_guardar.Location = new System.Drawing.Point(624, 6);
            this.button_guardar.Name = "button_guardar";
            this.button_guardar.Size = new System.Drawing.Size(110, 23);
            this.button_guardar.TabIndex = 3;
            this.button_guardar.Text = "Guardar cambios";
            this.button_guardar.UseVisualStyleBackColor = true;
            this.button_guardar.Click += new System.EventHandler(this.button_guardar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FormGruposEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel_secundario);
            this.Name = "FormGruposEdicion";
            this.Size = new System.Drawing.Size(899, 309);
            this.tableLayoutPanel_secundario.ResumeLayout(false);
            this.panel_nombre.ResumeLayout(false);
            this.panel_nombre.PerformLayout();
            this.panel_descripcion.ResumeLayout(false);
            this.panel_descripcion.PerformLayout();
            this.panel_fecha.ResumeLayout(false);
            this.panel_fecha.PerformLayout();
            this.panel_usuarios.ResumeLayout(false);
            this.panel_usuarios.PerformLayout();
            this.panel_numUsuarios.ResumeLayout(false);
            this.panel_numUsuarios.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_secundario;
        private System.Windows.Forms.Panel panel_nombre;
        private System.Windows.Forms.Label label_nombre;
        private System.Windows.Forms.Panel panel_descripcion;
        private System.Windows.Forms.TextBox textBox_descripcion;
        private System.Windows.Forms.Label label_descripcion;
        private System.Windows.Forms.Panel panel_fecha;
        private System.Windows.Forms.DateTimePicker dateTimePicker_fecha;
        private System.Windows.Forms.Label label_fecha;
        private System.Windows.Forms.Panel panel_usuarios;
        private System.Windows.Forms.ListBox listBox_usuarios;
        private System.Windows.Forms.Label label_usuarios;
        private System.Windows.Forms.Panel panel_numUsuarios;
        private System.Windows.Forms.Label label_numUsuarios;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_descartarCambios;
        private System.Windows.Forms.Button button_guardar;
        private System.Windows.Forms.TextBox textBox_nombre;
        private System.Windows.Forms.TextBox textBox_id;
        private System.Windows.Forms.Label label_id;
        private System.Windows.Forms.Button button_addUsuario;
        private System.Windows.Forms.Button button_borrar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox textBox_numUsuarios;
        private System.Windows.Forms.Button button_verUsuario;
    }
}
