namespace cacatUA
{
    partial class FormGrupo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGrupo));
            this.groupBoxDescripcion = new System.Windows.Forms.GroupBox();
            this.richTextBoxDesc = new System.Windows.Forms.RichTextBox();
            this.textBoxCreadorGrupo = new System.Windows.Forms.TextBox();
            this.labelCreadorGrupo = new System.Windows.Forms.Label();
            this.textBoxNombreGrupo = new System.Windows.Forms.TextBox();
            this.labelNombreGrupo = new System.Windows.Forms.Label();
            this.listBoxUsuarioGrupo = new System.Windows.Forms.ListBox();
            this.buttonUsuario = new System.Windows.Forms.Button();
            this.groupBoxComponentes = new System.Windows.Forms.GroupBox();
            this.panelAgregar = new System.Windows.Forms.Panel();
            this.listBoxUsuarios = new System.Windows.Forms.ListBox();
            this.buttonAgregar = new System.Windows.Forms.Button();
            this.buttonBorrar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBoxDescripcion.SuspendLayout();
            this.groupBoxComponentes.SuspendLayout();
            this.panelAgregar.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxDescripcion
            // 
            this.groupBoxDescripcion.Controls.Add(this.richTextBoxDesc);
            this.groupBoxDescripcion.Controls.Add(this.textBoxCreadorGrupo);
            this.groupBoxDescripcion.Controls.Add(this.labelCreadorGrupo);
            this.groupBoxDescripcion.Controls.Add(this.textBoxNombreGrupo);
            this.groupBoxDescripcion.Controls.Add(this.labelNombreGrupo);
            this.groupBoxDescripcion.Location = new System.Drawing.Point(44, 25);
            this.groupBoxDescripcion.Name = "groupBoxDescripcion";
            this.groupBoxDescripcion.Size = new System.Drawing.Size(714, 176);
            this.groupBoxDescripcion.TabIndex = 25;
            this.groupBoxDescripcion.TabStop = false;
            this.groupBoxDescripcion.Text = "Descripción del Grupo:";
            // 
            // richTextBoxDesc
            // 
            this.richTextBoxDesc.Location = new System.Drawing.Point(356, 19);
            this.richTextBoxDesc.Name = "richTextBoxDesc";
            this.richTextBoxDesc.ReadOnly = true;
            this.richTextBoxDesc.Size = new System.Drawing.Size(304, 140);
            this.richTextBoxDesc.TabIndex = 16;
            this.richTextBoxDesc.Text = "";
            // 
            // textBoxCreadorGrupo
            // 
            this.textBoxCreadorGrupo.Location = new System.Drawing.Point(123, 101);
            this.textBoxCreadorGrupo.Name = "textBoxCreadorGrupo";
            this.textBoxCreadorGrupo.ReadOnly = true;
            this.textBoxCreadorGrupo.Size = new System.Drawing.Size(191, 20);
            this.textBoxCreadorGrupo.TabIndex = 21;
            // 
            // labelCreadorGrupo
            // 
            this.labelCreadorGrupo.AutoSize = true;
            this.labelCreadorGrupo.Location = new System.Drawing.Point(21, 101);
            this.labelCreadorGrupo.Name = "labelCreadorGrupo";
            this.labelCreadorGrupo.Size = new System.Drawing.Size(96, 13);
            this.labelCreadorGrupo.TabIndex = 18;
            this.labelCreadorGrupo.Text = "Creador del Grupo:";
            // 
            // textBoxNombreGrupo
            // 
            this.textBoxNombreGrupo.Location = new System.Drawing.Point(123, 46);
            this.textBoxNombreGrupo.Name = "textBoxNombreGrupo";
            this.textBoxNombreGrupo.ReadOnly = true;
            this.textBoxNombreGrupo.Size = new System.Drawing.Size(191, 20);
            this.textBoxNombreGrupo.TabIndex = 20;
            // 
            // labelNombreGrupo
            // 
            this.labelNombreGrupo.AutoSize = true;
            this.labelNombreGrupo.Location = new System.Drawing.Point(21, 53);
            this.labelNombreGrupo.Name = "labelNombreGrupo";
            this.labelNombreGrupo.Size = new System.Drawing.Size(96, 13);
            this.labelNombreGrupo.TabIndex = 19;
            this.labelNombreGrupo.Text = "Nombre del Grupo:";
            // 
            // listBoxUsuarioGrupo
            // 
            this.listBoxUsuarioGrupo.FormattingEnabled = true;
            this.listBoxUsuarioGrupo.Items.AddRange(new object[] {
            "Jose",
            "Juan",
            "Tomas",
            "Perico"});
            this.listBoxUsuarioGrupo.Location = new System.Drawing.Point(24, 33);
            this.listBoxUsuarioGrupo.Name = "listBoxUsuarioGrupo";
            this.listBoxUsuarioGrupo.Size = new System.Drawing.Size(268, 160);
            this.listBoxUsuarioGrupo.TabIndex = 23;
            // 
            // buttonUsuario
            // 
            this.buttonUsuario.Location = new System.Drawing.Point(164, 209);
            this.buttonUsuario.Name = "buttonUsuario";
            this.buttonUsuario.Size = new System.Drawing.Size(75, 23);
            this.buttonUsuario.TabIndex = 24;
            this.buttonUsuario.Text = "Ver";
            this.buttonUsuario.UseVisualStyleBackColor = true;
            this.buttonUsuario.Click += new System.EventHandler(this.buttonUsuario_Click);
            // 
            // groupBoxComponentes
            // 
            this.groupBoxComponentes.Controls.Add(this.button1);
            this.groupBoxComponentes.Controls.Add(this.panelAgregar);
            this.groupBoxComponentes.Controls.Add(this.listBoxUsuarioGrupo);
            this.groupBoxComponentes.Controls.Add(this.buttonUsuario);
            this.groupBoxComponentes.Location = new System.Drawing.Point(44, 207);
            this.groupBoxComponentes.Name = "groupBoxComponentes";
            this.groupBoxComponentes.Size = new System.Drawing.Size(714, 247);
            this.groupBoxComponentes.TabIndex = 28;
            this.groupBoxComponentes.TabStop = false;
            this.groupBoxComponentes.Text = "Componentes:";
            // 
            // panelAgregar
            // 
            this.panelAgregar.Controls.Add(this.listBoxUsuarios);
            this.panelAgregar.Controls.Add(this.buttonAgregar);
            this.panelAgregar.Controls.Add(this.buttonBorrar);
            this.panelAgregar.Location = new System.Drawing.Point(312, 19);
            this.panelAgregar.Name = "panelAgregar";
            this.panelAgregar.Size = new System.Drawing.Size(396, 213);
            this.panelAgregar.TabIndex = 30;
            this.panelAgregar.Visible = false;
            // 
            // listBoxUsuarios
            // 
            this.listBoxUsuarios.FormattingEnabled = true;
            this.listBoxUsuarios.Items.AddRange(new object[] {
            "Andres",
            "Pepe",
            "Pablo"});
            this.listBoxUsuarios.Location = new System.Drawing.Point(95, 14);
            this.listBoxUsuarios.Name = "listBoxUsuarios";
            this.listBoxUsuarios.Size = new System.Drawing.Size(272, 160);
            this.listBoxUsuarios.TabIndex = 29;
            // 
            // buttonAgregar
            // 
            this.buttonAgregar.Location = new System.Drawing.Point(13, 32);
            this.buttonAgregar.Name = "buttonAgregar";
            this.buttonAgregar.Size = new System.Drawing.Size(43, 38);
            this.buttonAgregar.TabIndex = 27;
            this.buttonAgregar.Text = "<-";
            this.buttonAgregar.UseVisualStyleBackColor = true;
            this.buttonAgregar.Click += new System.EventHandler(this.buttonAgregar_Click);
            // 
            // buttonBorrar
            // 
            this.buttonBorrar.Image = ((System.Drawing.Image)(resources.GetObject("buttonBorrar.Image")));
            this.buttonBorrar.Location = new System.Drawing.Point(13, 102);
            this.buttonBorrar.Name = "buttonBorrar";
            this.buttonBorrar.Size = new System.Drawing.Size(43, 38);
            this.buttonBorrar.TabIndex = 28;
            this.buttonBorrar.UseVisualStyleBackColor = true;
            this.buttonBorrar.Click += new System.EventHandler(this.buttonBorrar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(57, 209);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 31;
            this.button1.Text = "Provisional";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 466);
            this.Controls.Add(this.groupBoxComponentes);
            this.Controls.Add(this.groupBoxDescripcion);
            this.Name = "FormGrupo";
            this.Text = "Grupo";
            this.groupBoxDescripcion.ResumeLayout(false);
            this.groupBoxDescripcion.PerformLayout();
            this.groupBoxComponentes.ResumeLayout(false);
            this.panelAgregar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxDescripcion;
        private System.Windows.Forms.RichTextBox richTextBoxDesc;
        private System.Windows.Forms.TextBox textBoxCreadorGrupo;
        private System.Windows.Forms.Label labelCreadorGrupo;
        private System.Windows.Forms.TextBox textBoxNombreGrupo;
        private System.Windows.Forms.Label labelNombreGrupo;
        private System.Windows.Forms.ListBox listBoxUsuarioGrupo;
        private System.Windows.Forms.Button buttonUsuario;
        private System.Windows.Forms.GroupBox groupBoxComponentes;
        private System.Windows.Forms.ListBox listBoxUsuarios;
        private System.Windows.Forms.Button buttonBorrar;
        private System.Windows.Forms.Button buttonAgregar;
        private System.Windows.Forms.Panel panelAgregar;
        private System.Windows.Forms.Button button1;
    }
}