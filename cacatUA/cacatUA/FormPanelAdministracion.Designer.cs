namespace cacatUA
{
    partial class FormPanelAdministracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPanelAdministracion));
            this.button_general = new System.Windows.Forms.Button();
            this.button_foro = new System.Windows.Forms.Button();
            this.button_peticiones = new System.Windows.Forms.Button();
            this.button_grupos = new System.Windows.Forms.Button();
            this.button_materiales = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_usuarios = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_general
            // 
            this.button_general.Location = new System.Drawing.Point(12, 156);
            this.button_general.Name = "button_general";
            this.button_general.Size = new System.Drawing.Size(75, 23);
            this.button_general.TabIndex = 1;
            this.button_general.Text = "General";
            this.button_general.UseVisualStyleBackColor = true;
            this.button_general.Click += new System.EventHandler(this.button_general_Click);
            // 
            // button_foro
            // 
            this.button_foro.Location = new System.Drawing.Point(12, 307);
            this.button_foro.Name = "button_foro";
            this.button_foro.Size = new System.Drawing.Size(75, 22);
            this.button_foro.TabIndex = 4;
            this.button_foro.Text = "Foro";
            this.button_foro.UseVisualStyleBackColor = true;
            this.button_foro.Click += new System.EventHandler(this.button_foro_Click);
            // 
            // button_peticiones
            // 
            this.button_peticiones.Location = new System.Drawing.Point(12, 336);
            this.button_peticiones.Name = "button_peticiones";
            this.button_peticiones.Size = new System.Drawing.Size(75, 22);
            this.button_peticiones.TabIndex = 5;
            this.button_peticiones.Text = "Peticiones";
            this.button_peticiones.UseVisualStyleBackColor = true;
            this.button_peticiones.Click += new System.EventHandler(this.button_peticiones_Click);
            // 
            // button_grupos
            // 
            this.button_grupos.Location = new System.Drawing.Point(12, 365);
            this.button_grupos.Name = "button_grupos";
            this.button_grupos.Size = new System.Drawing.Size(75, 22);
            this.button_grupos.TabIndex = 6;
            this.button_grupos.Text = "Grupos";
            this.button_grupos.UseVisualStyleBackColor = true;
            this.button_grupos.Click += new System.EventHandler(this.button_grupos_Click);
            // 
            // button_materiales
            // 
            this.button_materiales.Image = ((System.Drawing.Image)(resources.GetObject("button_materiales.Image")));
            this.button_materiales.Location = new System.Drawing.Point(12, 247);
            this.button_materiales.Name = "button_materiales";
            this.button_materiales.Size = new System.Drawing.Size(184, 50);
            this.button_materiales.TabIndex = 3;
            this.button_materiales.UseVisualStyleBackColor = true;
            this.button_materiales.Click += new System.EventHandler(this.button_materiales_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::cacatUA.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(210, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(528, 109);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // button_usuarios
            // 
            this.button_usuarios.FlatAppearance.BorderSize = 0;
            this.button_usuarios.Image = global::cacatUA.Properties.Resources.usuarios;
            this.button_usuarios.Location = new System.Drawing.Point(12, 185);
            this.button_usuarios.Name = "button_usuarios";
            this.button_usuarios.Size = new System.Drawing.Size(184, 56);
            this.button_usuarios.TabIndex = 0;
            this.button_usuarios.UseVisualStyleBackColor = true;
            this.button_usuarios.Click += new System.EventHandler(this.button_usuarios_Click);
            // 
            // FormPanelAdministracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 523);
            this.Controls.Add(this.button_grupos);
            this.Controls.Add(this.button_peticiones);
            this.Controls.Add(this.button_foro);
            this.Controls.Add(this.button_materiales);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_general);
            this.Controls.Add(this.button_usuarios);
            this.Name = "FormPanelAdministracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel de administración";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_usuarios;
        private System.Windows.Forms.Button button_general;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_materiales;
        private System.Windows.Forms.Button button_foro;
        private System.Windows.Forms.Button button_peticiones;
        private System.Windows.Forms.Button button_grupos;


    }
}