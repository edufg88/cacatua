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
            this.tableLayoutPanel_secundario = new System.Windows.Forms.TableLayoutPanel();
            this.panel_nombre = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            this.linkLabel_usuario = new System.Windows.Forms.LinkLabel();
            this.listBox_usuarios = new System.Windows.Forms.ListBox();
            this.label_usuarios = new System.Windows.Forms.Label();
            this.panel_numUsuarios = new System.Windows.Forms.Panel();
            this.numericUpDown_numUsuarios1 = new System.Windows.Forms.NumericUpDown();
            this.label_numUsuarios = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_eliminar = new System.Windows.Forms.Button();
            this.button_guardar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button_seccionCrear = new System.Windows.Forms.Button();
            this.button_borrar = new System.Windows.Forms.Button();
            this.tableLayoutPanel_secundario.SuspendLayout();
            this.panel_nombre.SuspendLayout();
            this.panel_descripcion.SuspendLayout();
            this.panel_fecha.SuspendLayout();
            this.panel_usuarios.SuspendLayout();
            this.panel_numUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_numUsuarios1)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.panel_nombre.Controls.Add(this.textBox1);
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
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(806, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(57, 20);
            this.textBox1.TabIndex = 148;
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
            this.textBox_nombre.TabIndex = 146;
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
            this.dateTimePicker_fecha.Location = new System.Drawing.Point(125, 5);
            this.dateTimePicker_fecha.Name = "dateTimePicker_fecha";
            this.dateTimePicker_fecha.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_fecha.TabIndex = 1;
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
            this.panel_usuarios.Controls.Add(this.tableLayoutPanel1);
            this.panel_usuarios.Controls.Add(this.listBox_usuarios);
            this.panel_usuarios.Controls.Add(this.label_usuarios);
            this.panel_usuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_usuarios.Location = new System.Drawing.Point(0, 183);
            this.panel_usuarios.Margin = new System.Windows.Forms.Padding(0);
            this.panel_usuarios.Name = "panel_usuarios";
            this.panel_usuarios.Size = new System.Drawing.Size(899, 93);
            this.panel_usuarios.TabIndex = 9;
            // 
            // linkLabel_usuario
            // 
            this.linkLabel_usuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel_usuario.AutoSize = true;
            this.linkLabel_usuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabel_usuario.Location = new System.Drawing.Point(3, 0);
            this.linkLabel_usuario.Name = "linkLabel_usuario";
            this.linkLabel_usuario.Size = new System.Drawing.Size(65, 13);
            this.linkLabel_usuario.TabIndex = 4;
            this.linkLabel_usuario.TabStop = true;
            this.linkLabel_usuario.Text = "Ver usuario";
            this.linkLabel_usuario.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_usuario_LinkClicked);
            // 
            // listBox_usuarios
            // 
            this.listBox_usuarios.ColumnWidth = 50;
            this.listBox_usuarios.FormattingEnabled = true;
            this.listBox_usuarios.Items.AddRange(new object[] {
            "Jose",
            "Juan",
            "Andres",
            "Pepe",
            "Tomas"});
            this.listBox_usuarios.Location = new System.Drawing.Point(125, 10);
            this.listBox_usuarios.Name = "listBox_usuarios";
            this.listBox_usuarios.Size = new System.Drawing.Size(320, 82);
            this.listBox_usuarios.TabIndex = 1;
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
            this.panel_numUsuarios.Controls.Add(this.numericUpDown_numUsuarios1);
            this.panel_numUsuarios.Controls.Add(this.label_numUsuarios);
            this.panel_numUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_numUsuarios.Location = new System.Drawing.Point(0, 153);
            this.panel_numUsuarios.Margin = new System.Windows.Forms.Padding(0);
            this.panel_numUsuarios.Name = "panel_numUsuarios";
            this.panel_numUsuarios.Size = new System.Drawing.Size(899, 30);
            this.panel_numUsuarios.TabIndex = 10;
            // 
            // numericUpDown_numUsuarios1
            // 
            this.numericUpDown_numUsuarios1.Location = new System.Drawing.Point(125, 8);
            this.numericUpDown_numUsuarios1.Name = "numericUpDown_numUsuarios1";
            this.numericUpDown_numUsuarios1.ReadOnly = true;
            this.numericUpDown_numUsuarios1.Size = new System.Drawing.Size(113, 20);
            this.numericUpDown_numUsuarios1.TabIndex = 1;
            // 
            // label_numUsuarios
            // 
            this.label_numUsuarios.AutoSize = true;
            this.label_numUsuarios.Location = new System.Drawing.Point(16, 10);
            this.label_numUsuarios.Name = "label_numUsuarios";
            this.label_numUsuarios.Size = new System.Drawing.Size(81, 13);
            this.label_numUsuarios.TabIndex = 0;
            this.label_numUsuarios.Text = "Nº de Usuarios:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_eliminar);
            this.panel1.Controls.Add(this.button_guardar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 276);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(899, 33);
            this.panel1.TabIndex = 11;
            // 
            // button_eliminar
            // 
            this.button_eliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_eliminar.Location = new System.Drawing.Point(753, 6);
            this.button_eliminar.Name = "button_eliminar";
            this.button_eliminar.Size = new System.Drawing.Size(110, 23);
            this.button_eliminar.TabIndex = 2;
            this.button_eliminar.Text = "Descartar cambios";
            this.button_eliminar.UseVisualStyleBackColor = true;
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
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.button_seccionCrear, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.linkLabel_usuario, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_borrar, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(451, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.81818F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.18182F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(71, 87);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // button_seccionCrear
            // 
            this.button_seccionCrear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button_seccionCrear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_seccionCrear.FlatAppearance.BorderSize = 0;
            this.button_seccionCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_seccionCrear.Image = global::cacatUA.Properties.Resources.nuevo;
            this.button_seccionCrear.Location = new System.Drawing.Point(3, 20);
            this.button_seccionCrear.Name = "button_seccionCrear";
            this.button_seccionCrear.Size = new System.Drawing.Size(65, 30);
            this.button_seccionCrear.TabIndex = 13;
            this.button_seccionCrear.UseVisualStyleBackColor = true;
            // 
            // button_borrar
            // 
            this.button_borrar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button_borrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_borrar.FlatAppearance.BorderSize = 0;
            this.button_borrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_borrar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_borrar.Image = global::cacatUA.Properties.Resources.close;
            this.button_borrar.Location = new System.Drawing.Point(3, 56);
            this.button_borrar.Name = "button_borrar";
            this.button_borrar.Size = new System.Drawing.Size(65, 28);
            this.button_borrar.TabIndex = 14;
            this.button_borrar.Tag = "Eliminar hilo seleccionado";
            this.button_borrar.UseVisualStyleBackColor = true;
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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_numUsuarios1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
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
        private System.Windows.Forms.LinkLabel linkLabel_usuario;
        private System.Windows.Forms.ListBox listBox_usuarios;
        private System.Windows.Forms.Label label_usuarios;
        private System.Windows.Forms.Panel panel_numUsuarios;
        private System.Windows.Forms.NumericUpDown numericUpDown_numUsuarios1;
        private System.Windows.Forms.Label label_numUsuarios;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_eliminar;
        private System.Windows.Forms.Button button_guardar;
        private System.Windows.Forms.TextBox textBox_nombre;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label_id;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_seccionCrear;
        private System.Windows.Forms.Button button_borrar;
    }
}
