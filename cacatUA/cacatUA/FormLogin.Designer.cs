namespace cacatUA
{
    partial class FormLogin
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_usuario = new System.Windows.Forms.TextBox();
            this.textBox_contraseña = new System.Windows.Forms.TextBox();
            this.button_conectar = new System.Windows.Forms.Button();
            this.button_salir = new System.Windows.Forms.Button();
            this.label_error = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 324);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Contraseña:";
            // 
            // textBox_usuario
            // 
            this.textBox_usuario.Location = new System.Drawing.Point(157, 294);
            this.textBox_usuario.Name = "textBox_usuario";
            this.textBox_usuario.Size = new System.Drawing.Size(158, 20);
            this.textBox_usuario.TabIndex = 0;
            // 
            // textBox_contraseña
            // 
            this.textBox_contraseña.Location = new System.Drawing.Point(157, 321);
            this.textBox_contraseña.Name = "textBox_contraseña";
            this.textBox_contraseña.PasswordChar = '*';
            this.textBox_contraseña.Size = new System.Drawing.Size(158, 20);
            this.textBox_contraseña.TabIndex = 1;
            // 
            // button_conectar
            // 
            this.button_conectar.Location = new System.Drawing.Point(90, 366);
            this.button_conectar.Name = "button_conectar";
            this.button_conectar.Size = new System.Drawing.Size(106, 23);
            this.button_conectar.TabIndex = 2;
            this.button_conectar.Text = "Conectar";
            this.button_conectar.UseVisualStyleBackColor = true;
            this.button_conectar.Click += new System.EventHandler(this.button_conectar_Click);
            // 
            // button_salir
            // 
            this.button_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_salir.Location = new System.Drawing.Point(209, 366);
            this.button_salir.Name = "button_salir";
            this.button_salir.Size = new System.Drawing.Size(106, 23);
            this.button_salir.TabIndex = 3;
            this.button_salir.Text = "Salir";
            this.button_salir.UseVisualStyleBackColor = true;
            this.button_salir.Click += new System.EventHandler(this.button_salir_Click);
            // 
            // label_error
            // 
            this.label_error.AutoSize = true;
            this.label_error.ForeColor = System.Drawing.Color.Red;
            this.label_error.Location = new System.Drawing.Point(154, 265);
            this.label_error.Name = "label_error";
            this.label_error.Size = new System.Drawing.Size(93, 13);
            this.label_error.TabIndex = 4;
            this.label_error.Text = "Acceso incorrecto";
            this.label_error.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::cacatUA.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(13, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(388, 237);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FormLogin
            // 
            this.AcceptButton = this.button_conectar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_salir;
            this.ClientSize = new System.Drawing.Size(415, 401);
            this.Controls.Add(this.label_error);
            this.Controls.Add(this.button_salir);
            this.Controls.Add(this.button_conectar);
            this.Controls.Add(this.textBox_contraseña);
            this.Controls.Add(this.textBox_usuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ventana de acceso";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_usuario;
        private System.Windows.Forms.TextBox textBox_contraseña;
        private System.Windows.Forms.Button button_conectar;
        private System.Windows.Forms.Button button_salir;
        private System.Windows.Forms.Label label_error;
    }
}

