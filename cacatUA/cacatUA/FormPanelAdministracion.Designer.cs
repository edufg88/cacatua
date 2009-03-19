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
            this.button_foro = new System.Windows.Forms.Button();
            this.button_peticiones = new System.Windows.Forms.Button();
            this.button_grupos = new System.Windows.Forms.Button();
            this.tableLayoutPanel_botones = new System.Windows.Forms.TableLayoutPanel();
            this.button_categorias = new System.Windows.Forms.Button();
            this.button_general = new System.Windows.Forms.Button();
            this.button_usuarios = new System.Windows.Forms.Button();
            this.button_materiales = new System.Windows.Forms.Button();
            this.buttonSalir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel_botones.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_foro
            // 
            this.button_foro.FlatAppearance.BorderSize = 0;
            this.button_foro.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
            this.button_foro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.button_foro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button_foro.Image = global::cacatUA.Properties.Resources.foro;
            this.button_foro.Location = new System.Drawing.Point(3, 138);
            this.button_foro.Name = "button_foro";
            this.button_foro.Size = new System.Drawing.Size(190, 39);
            this.button_foro.TabIndex = 3;
            this.button_foro.UseVisualStyleBackColor = true;
            this.button_foro.Click += new System.EventHandler(this.button_foro_Click);
            // 
            // button_peticiones
            // 
            this.button_peticiones.FlatAppearance.BorderSize = 0;
            this.button_peticiones.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
            this.button_peticiones.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.button_peticiones.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button_peticiones.Image = global::cacatUA.Properties.Resources.peticiones;
            this.button_peticiones.Location = new System.Drawing.Point(3, 183);
            this.button_peticiones.Name = "button_peticiones";
            this.button_peticiones.Size = new System.Drawing.Size(190, 39);
            this.button_peticiones.TabIndex = 4;
            this.button_peticiones.UseVisualStyleBackColor = true;
            this.button_peticiones.Click += new System.EventHandler(this.button_peticiones_Click);
            // 
            // button_grupos
            // 
            this.button_grupos.FlatAppearance.BorderSize = 0;
            this.button_grupos.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
            this.button_grupos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.button_grupos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button_grupos.Image = global::cacatUA.Properties.Resources.personas;
            this.button_grupos.Location = new System.Drawing.Point(3, 228);
            this.button_grupos.Name = "button_grupos";
            this.button_grupos.Size = new System.Drawing.Size(190, 39);
            this.button_grupos.TabIndex = 5;
            this.button_grupos.UseVisualStyleBackColor = true;
            this.button_grupos.Click += new System.EventHandler(this.button_grupos_Click);
            // 
            // tableLayoutPanel_botones
            // 
            this.tableLayoutPanel_botones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tableLayoutPanel_botones.ColumnCount = 1;
            this.tableLayoutPanel_botones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_botones.Controls.Add(this.button_categorias, 0, 6);
            this.tableLayoutPanel_botones.Controls.Add(this.button_general, 0, 0);
            this.tableLayoutPanel_botones.Controls.Add(this.button_usuarios, 0, 1);
            this.tableLayoutPanel_botones.Controls.Add(this.button_materiales, 0, 2);
            this.tableLayoutPanel_botones.Controls.Add(this.button_grupos, 0, 5);
            this.tableLayoutPanel_botones.Controls.Add(this.button_foro, 0, 3);
            this.tableLayoutPanel_botones.Controls.Add(this.button_peticiones, 0, 4);
            this.tableLayoutPanel_botones.Controls.Add(this.buttonSalir, 0, 7);
            this.tableLayoutPanel_botones.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel_botones.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_botones.Name = "tableLayoutPanel_botones";
            this.tableLayoutPanel_botones.RowCount = 8;
            this.tableLayoutPanel_botones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel_botones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel_botones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel_botones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel_botones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel_botones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel_botones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel_botones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_botones.Size = new System.Drawing.Size(197, 548);
            this.tableLayoutPanel_botones.TabIndex = 1;
            // 
            // button_categorias
            // 
            this.button_categorias.FlatAppearance.BorderSize = 0;
            this.button_categorias.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
            this.button_categorias.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.button_categorias.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button_categorias.Image = global::cacatUA.Properties.Resources.categorias;
            this.button_categorias.Location = new System.Drawing.Point(3, 273);
            this.button_categorias.Name = "button_categorias";
            this.button_categorias.Size = new System.Drawing.Size(190, 39);
            this.button_categorias.TabIndex = 6;
            this.button_categorias.UseVisualStyleBackColor = true;
            this.button_categorias.Click += new System.EventHandler(this.button_categorias_Click);
            // 
            // button_general
            // 
            this.button_general.FlatAppearance.BorderSize = 0;
            this.button_general.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
            this.button_general.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.button_general.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button_general.Image = global::cacatUA.Properties.Resources.general;
            this.button_general.Location = new System.Drawing.Point(3, 3);
            this.button_general.Name = "button_general";
            this.button_general.Size = new System.Drawing.Size(190, 39);
            this.button_general.TabIndex = 0;
            this.button_general.UseVisualStyleBackColor = true;
            this.button_general.Click += new System.EventHandler(this.button_general_Click);
            // 
            // button_usuarios
            // 
            this.button_usuarios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_usuarios.FlatAppearance.BorderSize = 0;
            this.button_usuarios.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
            this.button_usuarios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.button_usuarios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button_usuarios.Image = global::cacatUA.Properties.Resources.usuarios;
            this.button_usuarios.Location = new System.Drawing.Point(3, 48);
            this.button_usuarios.Name = "button_usuarios";
            this.button_usuarios.Size = new System.Drawing.Size(190, 39);
            this.button_usuarios.TabIndex = 1;
            this.button_usuarios.UseVisualStyleBackColor = true;
            this.button_usuarios.Click += new System.EventHandler(this.button_usuarios_Click);
            // 
            // button_materiales
            // 
            this.button_materiales.FlatAppearance.BorderSize = 0;
            this.button_materiales.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
            this.button_materiales.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.button_materiales.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button_materiales.Image = global::cacatUA.Properties.Resources.materiales;
            this.button_materiales.Location = new System.Drawing.Point(3, 93);
            this.button_materiales.Name = "button_materiales";
            this.button_materiales.Size = new System.Drawing.Size(190, 39);
            this.button_materiales.TabIndex = 2;
            this.button_materiales.UseVisualStyleBackColor = true;
            this.button_materiales.Click += new System.EventHandler(this.button_materiales_Click);
            // 
            // buttonSalir
            // 
            this.buttonSalir.FlatAppearance.BorderSize = 0;
            this.buttonSalir.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
            this.buttonSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.buttonSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonSalir.Image = global::cacatUA.Properties.Resources.salir;
            this.buttonSalir.Location = new System.Drawing.Point(3, 318);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(190, 39);
            this.buttonSalir.TabIndex = 7;
            this.buttonSalir.UseVisualStyleBackColor = true;
            this.buttonSalir.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMinSize = new System.Drawing.Size(630, 0);
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(197, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 548);
            this.panel1.TabIndex = 0;
            // 
            // FormPanelAdministracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 548);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel_botones);
            this.Name = "FormPanelAdministracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel de administración";
            this.Load += new System.EventHandler(this.FormPanelAdministracion_Load);
            this.tableLayoutPanel_botones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_usuarios;
        private System.Windows.Forms.Button button_general;
        private System.Windows.Forms.Button button_materiales;
        private System.Windows.Forms.Button button_foro;
        private System.Windows.Forms.Button button_peticiones;
        private System.Windows.Forms.Button button_grupos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_botones;
        private System.Windows.Forms.Button button_categorias;
        private System.Windows.Forms.Button buttonSalir;
        private System.Windows.Forms.Panel panel1;


    }
}