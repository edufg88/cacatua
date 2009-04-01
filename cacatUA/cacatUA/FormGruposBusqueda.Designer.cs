namespace cacatUA
{
    partial class FormGruposBusqueda
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
            this.panel_filtroBusqueda = new System.Windows.Forms.Panel();
            this.textBox_filtroBusqueda = new System.Windows.Forms.TextBox();
            this.label_filtroBusqueda = new System.Windows.Forms.Label();
            this.panel_autor = new System.Windows.Forms.Panel();
            this.button_seleccionarUsuario = new System.Windows.Forms.Button();
            this.textBox_usuario = new System.Windows.Forms.TextBox();
            this.label_usuario = new System.Windows.Forms.Label();
            this.panel_fecha = new System.Windows.Forms.Panel();
            this.dateTimePicker_fecha = new System.Windows.Forms.DateTimePicker();
            this.label_fecha = new System.Windows.Forms.Label();
            this.panel_numUsuarios = new System.Windows.Forms.Panel();
            this.label_y = new System.Windows.Forms.Label();
            this.numericUpDown_numUsuarios2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_numUsuarios1 = new System.Windows.Forms.NumericUpDown();
            this.label_numUsuarios = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_buscar = new System.Windows.Forms.Button();
            this.tableLayoutPanel_secundario.SuspendLayout();
            this.panel_filtroBusqueda.SuspendLayout();
            this.panel_autor.SuspendLayout();
            this.panel_fecha.SuspendLayout();
            this.panel_numUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_numUsuarios2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_numUsuarios1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_secundario
            // 
            this.tableLayoutPanel_secundario.ColumnCount = 1;
            this.tableLayoutPanel_secundario.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_secundario.Controls.Add(this.panel_filtroBusqueda, 0, 0);
            this.tableLayoutPanel_secundario.Controls.Add(this.panel_autor, 0, 1);
            this.tableLayoutPanel_secundario.Controls.Add(this.panel_fecha, 0, 2);
            this.tableLayoutPanel_secundario.Controls.Add(this.panel_numUsuarios, 0, 3);
            this.tableLayoutPanel_secundario.Controls.Add(this.panel1, 0, 4);
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
            this.tableLayoutPanel_secundario.Size = new System.Drawing.Size(791, 154);
            this.tableLayoutPanel_secundario.TabIndex = 99;
            // 
            // panel_filtroBusqueda
            // 
            this.panel_filtroBusqueda.Controls.Add(this.textBox_filtroBusqueda);
            this.panel_filtroBusqueda.Controls.Add(this.label_filtroBusqueda);
            this.panel_filtroBusqueda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_filtroBusqueda.Location = new System.Drawing.Point(0, 0);
            this.panel_filtroBusqueda.Margin = new System.Windows.Forms.Padding(0);
            this.panel_filtroBusqueda.Name = "panel_filtroBusqueda";
            this.panel_filtroBusqueda.Size = new System.Drawing.Size(791, 30);
            this.panel_filtroBusqueda.TabIndex = 0;
            // 
            // textBox_filtroBusqueda
            // 
            this.textBox_filtroBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_filtroBusqueda.Location = new System.Drawing.Point(125, 5);
            this.textBox_filtroBusqueda.Name = "textBox_filtroBusqueda";
            this.textBox_filtroBusqueda.Size = new System.Drawing.Size(606, 20);
            this.textBox_filtroBusqueda.TabIndex = 1;
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
            // panel_autor
            // 
            this.panel_autor.Controls.Add(this.button_seleccionarUsuario);
            this.panel_autor.Controls.Add(this.textBox_usuario);
            this.panel_autor.Controls.Add(this.label_usuario);
            this.panel_autor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_autor.Location = new System.Drawing.Point(0, 30);
            this.panel_autor.Margin = new System.Windows.Forms.Padding(0);
            this.panel_autor.Name = "panel_autor";
            this.panel_autor.Size = new System.Drawing.Size(791, 30);
            this.panel_autor.TabIndex = 2;
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
            this.button_seleccionarUsuario.TabIndex = 145;
            this.button_seleccionarUsuario.UseVisualStyleBackColor = false;
            // 
            // textBox_usuario
            // 
            this.textBox_usuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_usuario.Location = new System.Drawing.Point(125, 5);
            this.textBox_usuario.Name = "textBox_usuario";
            this.textBox_usuario.Size = new System.Drawing.Size(606, 20);
            this.textBox_usuario.TabIndex = 4;
            // 
            // label_usuario
            // 
            this.label_usuario.AutoSize = true;
            this.label_usuario.Location = new System.Drawing.Point(16, 8);
            this.label_usuario.Name = "label_usuario";
            this.label_usuario.Size = new System.Drawing.Size(46, 13);
            this.label_usuario.TabIndex = 0;
            this.label_usuario.Text = "Usuario:";
            // 
            // panel_fecha
            // 
            this.panel_fecha.Controls.Add(this.dateTimePicker_fecha);
            this.panel_fecha.Controls.Add(this.label_fecha);
            this.panel_fecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_fecha.Location = new System.Drawing.Point(0, 60);
            this.panel_fecha.Margin = new System.Windows.Forms.Padding(0);
            this.panel_fecha.Name = "panel_fecha";
            this.panel_fecha.Size = new System.Drawing.Size(791, 30);
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
            // panel_numUsuarios
            // 
            this.panel_numUsuarios.Controls.Add(this.label_y);
            this.panel_numUsuarios.Controls.Add(this.numericUpDown_numUsuarios2);
            this.panel_numUsuarios.Controls.Add(this.numericUpDown_numUsuarios1);
            this.panel_numUsuarios.Controls.Add(this.label_numUsuarios);
            this.panel_numUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_numUsuarios.Location = new System.Drawing.Point(0, 90);
            this.panel_numUsuarios.Margin = new System.Windows.Forms.Padding(0);
            this.panel_numUsuarios.Name = "panel_numUsuarios";
            this.panel_numUsuarios.Size = new System.Drawing.Size(791, 30);
            this.panel_numUsuarios.TabIndex = 10;
            // 
            // label_y
            // 
            this.label_y.AutoSize = true;
            this.label_y.Location = new System.Drawing.Point(263, 10);
            this.label_y.Name = "label_y";
            this.label_y.Size = new System.Drawing.Size(12, 13);
            this.label_y.TabIndex = 1;
            this.label_y.Text = "y";
            // 
            // numericUpDown_numUsuarios2
            // 
            this.numericUpDown_numUsuarios2.Location = new System.Drawing.Point(309, 8);
            this.numericUpDown_numUsuarios2.Name = "numericUpDown_numUsuarios2";
            this.numericUpDown_numUsuarios2.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_numUsuarios2.TabIndex = 0;
            // 
            // numericUpDown_numUsuarios1
            // 
            this.numericUpDown_numUsuarios1.Location = new System.Drawing.Point(125, 8);
            this.numericUpDown_numUsuarios1.Name = "numericUpDown_numUsuarios1";
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
            this.panel1.Controls.Add(this.button_buscar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 120);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(791, 34);
            this.panel1.TabIndex = 11;
            // 
            // button_buscar
            // 
            this.button_buscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_buscar.Location = new System.Drawing.Point(656, 3);
            this.button_buscar.Name = "button_buscar";
            this.button_buscar.Size = new System.Drawing.Size(75, 24);
            this.button_buscar.TabIndex = 4;
            this.button_buscar.Text = "Buscar";
            this.button_buscar.UseVisualStyleBackColor = true;
            // 
            // FormGruposBusqueda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel_secundario);
            this.Name = "FormGruposBusqueda";
            this.Size = new System.Drawing.Size(791, 154);
            this.tableLayoutPanel_secundario.ResumeLayout(false);
            this.panel_filtroBusqueda.ResumeLayout(false);
            this.panel_filtroBusqueda.PerformLayout();
            this.panel_autor.ResumeLayout(false);
            this.panel_autor.PerformLayout();
            this.panel_fecha.ResumeLayout(false);
            this.panel_fecha.PerformLayout();
            this.panel_numUsuarios.ResumeLayout(false);
            this.panel_numUsuarios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_numUsuarios2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_numUsuarios1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_secundario;
        private System.Windows.Forms.Panel panel_filtroBusqueda;
        private System.Windows.Forms.TextBox textBox_filtroBusqueda;
        private System.Windows.Forms.Label label_filtroBusqueda;
        private System.Windows.Forms.Panel panel_autor;
        private System.Windows.Forms.Label label_usuario;
        private System.Windows.Forms.Panel panel_fecha;
        private System.Windows.Forms.DateTimePicker dateTimePicker_fecha;
        private System.Windows.Forms.Label label_fecha;
        private System.Windows.Forms.Panel panel_numUsuarios;
        private System.Windows.Forms.Label label_y;
        private System.Windows.Forms.NumericUpDown numericUpDown_numUsuarios2;
        private System.Windows.Forms.NumericUpDown numericUpDown_numUsuarios1;
        private System.Windows.Forms.Label label_numUsuarios;
        private System.Windows.Forms.TextBox textBox_usuario;
        private System.Windows.Forms.Button button_seleccionarUsuario;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_buscar;
    }
}
