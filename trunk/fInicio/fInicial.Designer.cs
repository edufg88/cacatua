namespace fInicio
{
    partial class fInicio
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fInicio));
            this.logo = new System.Windows.Forms.PictureBox();
            this.bSalir = new System.Windows.Forms.Button();
            this.bEntrar = new System.Windows.Forms.Button();
            this.tbContraseña = new System.Windows.Forms.TextBox();
            this.tbUsuario = new System.Windows.Forms.TextBox();
            this.lUsuario = new System.Windows.Forms.Label();
            this.lContraseña = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // logo
            // 
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.InitialImage = null;
            this.logo.Location = new System.Drawing.Point(83, 12);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(400, 200);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.logo.TabIndex = 0;
            this.logo.TabStop = false;
            this.logo.WaitOnLoad = true;
            // 
            // bSalir
            // 
            this.bSalir.Location = new System.Drawing.Point(469, 333);
            this.bSalir.Name = "bSalir";
            this.bSalir.Size = new System.Drawing.Size(75, 23);
            this.bSalir.TabIndex = 1;
            this.bSalir.Text = "Salir";
            this.bSalir.UseVisualStyleBackColor = true;
            this.bSalir.Click += new System.EventHandler(this.bSalir_Click);
            // 
            // bEntrar
            // 
            this.bEntrar.Location = new System.Drawing.Point(242, 333);
            this.bEntrar.Name = "bEntrar";
            this.bEntrar.Size = new System.Drawing.Size(75, 23);
            this.bEntrar.TabIndex = 2;
            this.bEntrar.Text = "Entrar";
            this.bEntrar.UseVisualStyleBackColor = true;
            this.bEntrar.Click += new System.EventHandler(this.bEntrar_Click);
            // 
            // tbContraseña
            // 
            this.tbContraseña.Location = new System.Drawing.Point(242, 286);
            this.tbContraseña.Name = "tbContraseña";
            this.tbContraseña.Size = new System.Drawing.Size(100, 20);
            this.tbContraseña.TabIndex = 3;
            // 
            // tbUsuario
            // 
            this.tbUsuario.Location = new System.Drawing.Point(242, 244);
            this.tbUsuario.Name = "tbUsuario";
            this.tbUsuario.Size = new System.Drawing.Size(100, 20);
            this.tbUsuario.TabIndex = 4;
            // 
            // lUsuario
            // 
            this.lUsuario.AutoSize = true;
            this.lUsuario.Location = new System.Drawing.Point(183, 247);
            this.lUsuario.Name = "lUsuario";
            this.lUsuario.Size = new System.Drawing.Size(46, 13);
            this.lUsuario.TabIndex = 5;
            this.lUsuario.Text = "Usuario:";
            // 
            // lContraseña
            // 
            this.lContraseña.AutoSize = true;
            this.lContraseña.Location = new System.Drawing.Point(165, 289);
            this.lContraseña.Name = "lContraseña";
            this.lContraseña.Size = new System.Drawing.Size(64, 13);
            this.lContraseña.TabIndex = 6;
            this.lContraseña.Text = "Contraseña:";
            // 
            // fInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 368);
            this.Controls.Add(this.lContraseña);
            this.Controls.Add(this.lUsuario);
            this.Controls.Add(this.tbUsuario);
            this.Controls.Add(this.tbContraseña);
            this.Controls.Add(this.bEntrar);
            this.Controls.Add(this.bSalir);
            this.Controls.Add(this.logo);
            this.Name = "fInicio";
            this.Text = "CacatUA";
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Button bSalir;
        private System.Windows.Forms.Button bEntrar;
        private System.Windows.Forms.TextBox tbContraseña;
        private System.Windows.Forms.TextBox tbUsuario;
        private System.Windows.Forms.Label lUsuario;
        private System.Windows.Forms.Label lContraseña;
    }
}

