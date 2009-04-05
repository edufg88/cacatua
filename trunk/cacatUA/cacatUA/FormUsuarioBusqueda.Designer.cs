namespace cacatUA
{
    partial class FormUsuarioBusqueda
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
            this.tableLayoutPanel_buscar = new System.Windows.Forms.TableLayoutPanel();
            this.panel_nombreUsuario = new System.Windows.Forms.Panel();
            this.textBox_nombreUsuario = new System.Windows.Forms.TextBox();
            this.label_nombreUsuario = new System.Windows.Forms.Label();
            this.panel_email = new System.Windows.Forms.Panel();
            this.textBox_email = new System.Windows.Forms.TextBox();
            this.label_email = new System.Windows.Forms.Label();
            this.panel_fechaIngreso = new System.Windows.Forms.Panel();
            this.dateTimePicker_fechaIngreso = new System.Windows.Forms.DateTimePicker();
            this.label_fechaIngreso = new System.Windows.Forms.Label();
            this.panel_buscar = new System.Windows.Forms.Panel();
            this.button_buscar = new System.Windows.Forms.Button();
            this.tableLayoutPanel_buscar.SuspendLayout();
            this.panel_nombreUsuario.SuspendLayout();
            this.panel_email.SuspendLayout();
            this.panel_fechaIngreso.SuspendLayout();
            this.panel_buscar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_buscar
            // 
            this.tableLayoutPanel_buscar.ColumnCount = 1;
            this.tableLayoutPanel_buscar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_buscar.Controls.Add(this.panel_nombreUsuario, 0, 0);
            this.tableLayoutPanel_buscar.Controls.Add(this.panel_email, 0, 1);
            this.tableLayoutPanel_buscar.Controls.Add(this.panel_fechaIngreso, 0, 2);
            this.tableLayoutPanel_buscar.Controls.Add(this.panel_buscar, 0, 3);
            this.tableLayoutPanel_buscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_buscar.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_buscar.Name = "tableLayoutPanel_buscar";
            this.tableLayoutPanel_buscar.RowCount = 4;
            this.tableLayoutPanel_buscar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_buscar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_buscar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_buscar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_buscar.Size = new System.Drawing.Size(765, 150);
            this.tableLayoutPanel_buscar.TabIndex = 0;
            // 
            // panel_nombreUsuario
            // 
            this.panel_nombreUsuario.Controls.Add(this.textBox_nombreUsuario);
            this.panel_nombreUsuario.Controls.Add(this.label_nombreUsuario);
            this.panel_nombreUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_nombreUsuario.Location = new System.Drawing.Point(3, 3);
            this.panel_nombreUsuario.Name = "panel_nombreUsuario";
            this.panel_nombreUsuario.Size = new System.Drawing.Size(759, 24);
            this.panel_nombreUsuario.TabIndex = 0;
            // 
            // textBox_nombreUsuario
            // 
            this.textBox_nombreUsuario.Location = new System.Drawing.Point(147, 4);
            this.textBox_nombreUsuario.Name = "textBox_nombreUsuario";
            this.textBox_nombreUsuario.Size = new System.Drawing.Size(263, 20);
            this.textBox_nombreUsuario.TabIndex = 9;
            this.textBox_nombreUsuario.Text = "Edu";
            // 
            // label_nombreUsuario
            // 
            this.label_nombreUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label_nombreUsuario.AutoSize = true;
            this.label_nombreUsuario.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label_nombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_nombreUsuario.Location = new System.Drawing.Point(3, 4);
            this.label_nombreUsuario.Name = "label_nombreUsuario";
            this.label_nombreUsuario.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label_nombreUsuario.Size = new System.Drawing.Size(138, 20);
            this.label_nombreUsuario.TabIndex = 8;
            this.label_nombreUsuario.Text = "Nombre de usuario: ";
            // 
            // panel_email
            // 
            this.panel_email.Controls.Add(this.textBox_email);
            this.panel_email.Controls.Add(this.label_email);
            this.panel_email.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_email.Location = new System.Drawing.Point(3, 33);
            this.panel_email.Name = "panel_email";
            this.panel_email.Size = new System.Drawing.Size(759, 24);
            this.panel_email.TabIndex = 1;
            // 
            // textBox_email
            // 
            this.textBox_email.Location = new System.Drawing.Point(147, 3);
            this.textBox_email.Name = "textBox_email";
            this.textBox_email.Size = new System.Drawing.Size(263, 20);
            this.textBox_email.TabIndex = 15;
            this.textBox_email.Text = "usuario@cacatua.org";
            // 
            // label_email
            // 
            this.label_email.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label_email.AutoSize = true;
            this.label_email.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_email.Location = new System.Drawing.Point(3, 1);
            this.label_email.Name = "label_email";
            this.label_email.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label_email.Size = new System.Drawing.Size(57, 20);
            this.label_email.TabIndex = 14;
            this.label_email.Text = "E-mail: ";
            // 
            // panel_fechaIngreso
            // 
            this.panel_fechaIngreso.Controls.Add(this.dateTimePicker_fechaIngreso);
            this.panel_fechaIngreso.Controls.Add(this.label_fechaIngreso);
            this.panel_fechaIngreso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_fechaIngreso.Location = new System.Drawing.Point(3, 63);
            this.panel_fechaIngreso.Name = "panel_fechaIngreso";
            this.panel_fechaIngreso.Size = new System.Drawing.Size(759, 24);
            this.panel_fechaIngreso.TabIndex = 2;
            // 
            // dateTimePicker_fechaIngreso
            // 
            this.dateTimePicker_fechaIngreso.Location = new System.Drawing.Point(147, 3);
            this.dateTimePicker_fechaIngreso.Name = "dateTimePicker_fechaIngreso";
            this.dateTimePicker_fechaIngreso.Size = new System.Drawing.Size(263, 20);
            this.dateTimePicker_fechaIngreso.TabIndex = 16;
            // 
            // label_fechaIngreso
            // 
            this.label_fechaIngreso.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label_fechaIngreso.AutoSize = true;
            this.label_fechaIngreso.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label_fechaIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_fechaIngreso.Location = new System.Drawing.Point(3, 0);
            this.label_fechaIngreso.Name = "label_fechaIngreso";
            this.label_fechaIngreso.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label_fechaIngreso.Size = new System.Drawing.Size(126, 20);
            this.label_fechaIngreso.TabIndex = 15;
            this.label_fechaIngreso.Text = "Fecha de ingreso: ";
            // 
            // panel_buscar
            // 
            this.panel_buscar.Controls.Add(this.button_buscar);
            this.panel_buscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_buscar.Location = new System.Drawing.Point(3, 93);
            this.panel_buscar.Name = "panel_buscar";
            this.panel_buscar.Size = new System.Drawing.Size(759, 54);
            this.panel_buscar.TabIndex = 3;
            // 
            // button_buscar
            // 
            this.button_buscar.Location = new System.Drawing.Point(335, 19);
            this.button_buscar.Name = "button_buscar";
            this.button_buscar.Size = new System.Drawing.Size(75, 23);
            this.button_buscar.TabIndex = 12;
            this.button_buscar.Text = "Buscar";
            this.button_buscar.UseVisualStyleBackColor = true;
            this.button_buscar.Click += new System.EventHandler(this.button_buscar_Click);
            // 
            // FormUsuarioBusqueda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel_buscar);
            this.Name = "FormUsuarioBusqueda";
            this.Size = new System.Drawing.Size(765, 150);
            this.Load += new System.EventHandler(this.FormUsuarioBusqueda_Load);
            this.tableLayoutPanel_buscar.ResumeLayout(false);
            this.panel_nombreUsuario.ResumeLayout(false);
            this.panel_nombreUsuario.PerformLayout();
            this.panel_email.ResumeLayout(false);
            this.panel_email.PerformLayout();
            this.panel_fechaIngreso.ResumeLayout(false);
            this.panel_fechaIngreso.PerformLayout();
            this.panel_buscar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_buscar;
        private System.Windows.Forms.Panel panel_nombreUsuario;
        private System.Windows.Forms.TextBox textBox_nombreUsuario;
        private System.Windows.Forms.Label label_nombreUsuario;
        private System.Windows.Forms.Panel panel_email;
        private System.Windows.Forms.TextBox textBox_email;
        private System.Windows.Forms.Label label_email;
        private System.Windows.Forms.Panel panel_fechaIngreso;
        private System.Windows.Forms.Panel panel_buscar;
        private System.Windows.Forms.DateTimePicker dateTimePicker_fechaIngreso;
        private System.Windows.Forms.Label label_fechaIngreso;
        private System.Windows.Forms.Button button_buscar;
    }
}
