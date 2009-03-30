namespace cacatUA
{
    partial class FormUsuarioPeticion
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePicker_fecha = new System.Windows.Forms.DateTimePicker();
            this.label_fecha = new System.Windows.Forms.Label();
            this.label_peticionDeUsuario = new System.Windows.Forms.Label();
            this.button_modificar = new System.Windows.Forms.Button();
            this.textBox_texto = new System.Windows.Forms.TextBox();
            this.label_texto = new System.Windows.Forms.Label();
            this.textBox_asunto = new System.Windows.Forms.TextBox();
            this.label_asunto = new System.Windows.Forms.Label();
            this.label_autor = new System.Windows.Forms.Label();
            this.textBox_autor = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dateTimePicker_fecha);
            this.panel1.Controls.Add(this.label_fecha);
            this.panel1.Controls.Add(this.label_peticionDeUsuario);
            this.panel1.Controls.Add(this.button_modificar);
            this.panel1.Controls.Add(this.textBox_texto);
            this.panel1.Controls.Add(this.label_texto);
            this.panel1.Controls.Add(this.textBox_asunto);
            this.panel1.Controls.Add(this.label_asunto);
            this.panel1.Controls.Add(this.label_autor);
            this.panel1.Controls.Add(this.textBox_autor);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(308, 386);
            this.panel1.TabIndex = 2;
            // 
            // dateTimePicker_fecha
            // 
            this.dateTimePicker_fecha.Location = new System.Drawing.Point(6, 147);
            this.dateTimePicker_fecha.Name = "dateTimePicker_fecha";
            this.dateTimePicker_fecha.Size = new System.Drawing.Size(197, 20);
            this.dateTimePicker_fecha.TabIndex = 51;
            // 
            // label_fecha
            // 
            this.label_fecha.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label_fecha.AutoSize = true;
            this.label_fecha.BackColor = System.Drawing.Color.Transparent;
            this.label_fecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_fecha.Location = new System.Drawing.Point(3, 122);
            this.label_fecha.Name = "label_fecha";
            this.label_fecha.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label_fecha.Size = new System.Drawing.Size(44, 20);
            this.label_fecha.TabIndex = 50;
            this.label_fecha.Text = "Fecha:";
            // 
            // label_peticionDeUsuario
            // 
            this.label_peticionDeUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label_peticionDeUsuario.AutoSize = true;
            this.label_peticionDeUsuario.BackColor = System.Drawing.Color.Transparent;
            this.label_peticionDeUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_peticionDeUsuario.Location = new System.Drawing.Point(3, 1);
            this.label_peticionDeUsuario.Name = "label_peticionDeUsuario";
            this.label_peticionDeUsuario.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label_peticionDeUsuario.Size = new System.Drawing.Size(139, 20);
            this.label_peticionDeUsuario.TabIndex = 49;
            this.label_peticionDeUsuario.Text = "Petición de usuario: ";
            // 
            // button_modificar
            // 
            this.button_modificar.Location = new System.Drawing.Point(102, 350);
            this.button_modificar.Name = "button_modificar";
            this.button_modificar.Size = new System.Drawing.Size(75, 23);
            this.button_modificar.TabIndex = 48;
            this.button_modificar.Text = "Modificar";
            this.button_modificar.UseVisualStyleBackColor = true;
            // 
            // textBox_texto
            // 
            this.textBox_texto.Location = new System.Drawing.Point(6, 198);
            this.textBox_texto.Multiline = true;
            this.textBox_texto.Name = "textBox_texto";
            this.textBox_texto.Size = new System.Drawing.Size(294, 143);
            this.textBox_texto.TabIndex = 47;
            this.textBox_texto.Text = "Ayuda no paran de mandarme mensajes con insultos y barbaridades...";
            // 
            // label_texto
            // 
            this.label_texto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label_texto.AutoSize = true;
            this.label_texto.BackColor = System.Drawing.Color.Transparent;
            this.label_texto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_texto.Location = new System.Drawing.Point(3, 173);
            this.label_texto.Name = "label_texto";
            this.label_texto.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label_texto.Size = new System.Drawing.Size(46, 20);
            this.label_texto.TabIndex = 46;
            this.label_texto.Text = "Texto : ";
            // 
            // textBox_asunto
            // 
            this.textBox_asunto.Location = new System.Drawing.Point(6, 99);
            this.textBox_asunto.Name = "textBox_asunto";
            this.textBox_asunto.Size = new System.Drawing.Size(159, 20);
            this.textBox_asunto.TabIndex = 45;
            this.textBox_asunto.Text = "Baloo";
            // 
            // label_asunto
            // 
            this.label_asunto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label_asunto.AutoSize = true;
            this.label_asunto.BackColor = System.Drawing.Color.Transparent;
            this.label_asunto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_asunto.Location = new System.Drawing.Point(3, 72);
            this.label_asunto.Name = "label_asunto";
            this.label_asunto.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label_asunto.Size = new System.Drawing.Size(53, 20);
            this.label_asunto.TabIndex = 44;
            this.label_asunto.Text = "Asunto : ";
            // 
            // label_autor
            // 
            this.label_autor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label_autor.AutoSize = true;
            this.label_autor.BackColor = System.Drawing.Color.Transparent;
            this.label_autor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_autor.Location = new System.Drawing.Point(3, 22);
            this.label_autor.Name = "label_autor";
            this.label_autor.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label_autor.Size = new System.Drawing.Size(44, 20);
            this.label_autor.TabIndex = 43;
            this.label_autor.Text = "Autor : ";
            // 
            // textBox_autor
            // 
            this.textBox_autor.Location = new System.Drawing.Point(6, 49);
            this.textBox_autor.Name = "textBox_autor";
            this.textBox_autor.Size = new System.Drawing.Size(159, 20);
            this.textBox_autor.TabIndex = 42;
            this.textBox_autor.Text = "Peter Mazinger Rufai";
            // 
            // FormUsuarioPeticion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 386);
            this.Controls.Add(this.panel1);
            this.Name = "FormUsuarioPeticion";
            this.Text = "FormUsuarioPeticion";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_fecha;
        private System.Windows.Forms.Label label_fecha;
        private System.Windows.Forms.Label label_peticionDeUsuario;
        private System.Windows.Forms.Button button_modificar;
        private System.Windows.Forms.TextBox textBox_texto;
        private System.Windows.Forms.Label label_texto;
        private System.Windows.Forms.TextBox textBox_asunto;
        private System.Windows.Forms.Label label_asunto;
        private System.Windows.Forms.Label label_autor;
        private System.Windows.Forms.TextBox textBox_autor;
    }
}