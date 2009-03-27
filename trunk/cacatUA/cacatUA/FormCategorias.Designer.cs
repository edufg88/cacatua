namespace cacatUA
{
    partial class FormCategorias
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel6 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.button_Seleccionar = new System.Windows.Forms.Button();
            this.groupBox_Categoria = new System.Windows.Forms.GroupBox();
            this.linkLabel_verMateriales = new System.Windows.Forms.LinkLabel();
            this.textBox_nMateriales = new System.Windows.Forms.TextBox();
            this.textBox_nHilos = new System.Windows.Forms.TextBox();
            this.linkLabel_verHilos = new System.Windows.Forms.LinkLabel();
            this.label_nMateriales = new System.Windows.Forms.Label();
            this.label_nHilos = new System.Windows.Forms.Label();
            this.textBox_Raiz = new System.Windows.Forms.TextBox();
            this.textBox_descripcion = new System.Windows.Forms.TextBox();
            this.button_noGuardar = new System.Windows.Forms.Button();
            this.button_Guardar = new System.Windows.Forms.Button();
            this.button_crearSubcategoria = new System.Windows.Forms.Button();
            this.butto_editarCategoria = new System.Windows.Forms.Button();
            this.button_borrarCategoria = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button_quitarUsuario = new System.Windows.Forms.Button();
            this.button_verUsuario = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.treeViewCategorias = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox_Categoria.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(5)))), ((int)(((byte)(160)))));
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.label8);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(808, 25);
            this.panel6.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.label8.Size = new System.Drawing.Size(76, 19);
            this.label8.TabIndex = 7;
            this.label8.Text = "Categorías";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button_Cancelar);
            this.panel1.Controls.Add(this.button_Seleccionar);
            this.panel1.Controls.Add(this.groupBox_Categoria);
            this.panel1.Controls.Add(this.treeViewCategorias);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.panel1.Location = new System.Drawing.Point(3, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(808, 490);
            this.panel1.TabIndex = 31;
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Cancelar.Location = new System.Drawing.Point(675, 450);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(116, 24);
            this.button_Cancelar.TabIndex = 17;
            this.button_Cancelar.Text = "Cancelar";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Visible = false;
            // 
            // button_Seleccionar
            // 
            this.button_Seleccionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Seleccionar.Enabled = false;
            this.button_Seleccionar.Location = new System.Drawing.Point(542, 450);
            this.button_Seleccionar.Name = "button_Seleccionar";
            this.button_Seleccionar.Size = new System.Drawing.Size(116, 24);
            this.button_Seleccionar.TabIndex = 16;
            this.button_Seleccionar.Text = "Seleccionar";
            this.button_Seleccionar.UseVisualStyleBackColor = true;
            this.button_Seleccionar.Visible = false;
            // 
            // groupBox_Categoria
            // 
            this.groupBox_Categoria.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Categoria.Controls.Add(this.linkLabel_verMateriales);
            this.groupBox_Categoria.Controls.Add(this.textBox_nMateriales);
            this.groupBox_Categoria.Controls.Add(this.textBox_nHilos);
            this.groupBox_Categoria.Controls.Add(this.linkLabel_verHilos);
            this.groupBox_Categoria.Controls.Add(this.label_nMateriales);
            this.groupBox_Categoria.Controls.Add(this.label_nHilos);
            this.groupBox_Categoria.Controls.Add(this.textBox_Raiz);
            this.groupBox_Categoria.Controls.Add(this.textBox_descripcion);
            this.groupBox_Categoria.Controls.Add(this.button_noGuardar);
            this.groupBox_Categoria.Controls.Add(this.button_Guardar);
            this.groupBox_Categoria.Controls.Add(this.button_crearSubcategoria);
            this.groupBox_Categoria.Controls.Add(this.butto_editarCategoria);
            this.groupBox_Categoria.Controls.Add(this.button_borrarCategoria);
            this.groupBox_Categoria.Controls.Add(this.button8);
            this.groupBox_Categoria.Controls.Add(this.button_quitarUsuario);
            this.groupBox_Categoria.Controls.Add(this.button_verUsuario);
            this.groupBox_Categoria.Controls.Add(this.label3);
            this.groupBox_Categoria.Controls.Add(this.listBox1);
            this.groupBox_Categoria.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox_Categoria.Location = new System.Drawing.Point(284, 24);
            this.groupBox_Categoria.Name = "groupBox_Categoria";
            this.groupBox_Categoria.Size = new System.Drawing.Size(507, 411);
            this.groupBox_Categoria.TabIndex = 3;
            this.groupBox_Categoria.TabStop = false;
            this.groupBox_Categoria.Text = "Categoria";
            // 
            // linkLabel_verMateriales
            // 
            this.linkLabel_verMateriales.AutoSize = true;
            this.linkLabel_verMateriales.Location = new System.Drawing.Point(255, 225);
            this.linkLabel_verMateriales.Name = "linkLabel_verMateriales";
            this.linkLabel_verMateriales.Size = new System.Drawing.Size(73, 13);
            this.linkLabel_verMateriales.TabIndex = 45;
            this.linkLabel_verMateriales.TabStop = true;
            this.linkLabel_verMateriales.Text = "Ver materiales";
            // 
            // textBox_nMateriales
            // 
            this.textBox_nMateriales.Location = new System.Drawing.Point(181, 222);
            this.textBox_nMateriales.Name = "textBox_nMateriales";
            this.textBox_nMateriales.ReadOnly = true;
            this.textBox_nMateriales.Size = new System.Drawing.Size(40, 20);
            this.textBox_nMateriales.TabIndex = 44;
            // 
            // textBox_nHilos
            // 
            this.textBox_nHilos.Location = new System.Drawing.Point(181, 188);
            this.textBox_nHilos.Name = "textBox_nHilos";
            this.textBox_nHilos.ReadOnly = true;
            this.textBox_nHilos.Size = new System.Drawing.Size(40, 20);
            this.textBox_nHilos.TabIndex = 43;
            // 
            // linkLabel_verHilos
            // 
            this.linkLabel_verHilos.AutoSize = true;
            this.linkLabel_verHilos.Location = new System.Drawing.Point(255, 191);
            this.linkLabel_verHilos.Name = "linkLabel_verHilos";
            this.linkLabel_verHilos.Size = new System.Drawing.Size(47, 13);
            this.linkLabel_verHilos.TabIndex = 42;
            this.linkLabel_verHilos.TabStop = true;
            this.linkLabel_verHilos.Text = "Ver hilos";
            // 
            // label_nMateriales
            // 
            this.label_nMateriales.AutoSize = true;
            this.label_nMateriales.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_nMateriales.Location = new System.Drawing.Point(20, 225);
            this.label_nMateriales.Name = "label_nMateriales";
            this.label_nMateriales.Size = new System.Drawing.Size(137, 13);
            this.label_nMateriales.TabIndex = 41;
            this.label_nMateriales.Text = "Número de materiales: ";
            // 
            // label_nHilos
            // 
            this.label_nHilos.AutoSize = true;
            this.label_nHilos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_nHilos.Location = new System.Drawing.Point(20, 191);
            this.label_nHilos.Name = "label_nHilos";
            this.label_nHilos.Size = new System.Drawing.Size(106, 13);
            this.label_nHilos.TabIndex = 40;
            this.label_nHilos.Text = "Número de hilos: ";
            // 
            // textBox_Raiz
            // 
            this.textBox_Raiz.Location = new System.Drawing.Point(26, 30);
            this.textBox_Raiz.Name = "textBox_Raiz";
            this.textBox_Raiz.ReadOnly = true;
            this.textBox_Raiz.Size = new System.Drawing.Size(389, 20);
            this.textBox_Raiz.TabIndex = 39;
            // 
            // textBox_descripcion
            // 
            this.textBox_descripcion.Location = new System.Drawing.Point(26, 59);
            this.textBox_descripcion.Multiline = true;
            this.textBox_descripcion.Name = "textBox_descripcion";
            this.textBox_descripcion.ReadOnly = true;
            this.textBox_descripcion.Size = new System.Drawing.Size(389, 62);
            this.textBox_descripcion.TabIndex = 38;
            // 
            // button_noGuardar
            // 
            this.button_noGuardar.Enabled = false;
            this.button_noGuardar.Location = new System.Drawing.Point(333, 136);
            this.button_noGuardar.Name = "button_noGuardar";
            this.button_noGuardar.Size = new System.Drawing.Size(82, 24);
            this.button_noGuardar.TabIndex = 37;
            this.button_noGuardar.Text = "Cancelar";
            this.button_noGuardar.UseVisualStyleBackColor = true;
            this.button_noGuardar.Click += new System.EventHandler(this.button_noGuardar_Click);
            // 
            // button_Guardar
            // 
            this.button_Guardar.Enabled = false;
            this.button_Guardar.Location = new System.Drawing.Point(221, 136);
            this.button_Guardar.Name = "button_Guardar";
            this.button_Guardar.Size = new System.Drawing.Size(82, 24);
            this.button_Guardar.TabIndex = 36;
            this.button_Guardar.Text = "Guardar";
            this.button_Guardar.UseVisualStyleBackColor = true;
            // 
            // button_crearSubcategoria
            // 
            this.button_crearSubcategoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_crearSubcategoria.FlatAppearance.BorderSize = 0;
            this.button_crearSubcategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_crearSubcategoria.Image = global::cacatUA.Properties.Resources.nuevo;
            this.button_crearSubcategoria.Location = new System.Drawing.Point(445, 30);
            this.button_crearSubcategoria.Name = "button_crearSubcategoria";
            this.button_crearSubcategoria.Size = new System.Drawing.Size(36, 36);
            this.button_crearSubcategoria.TabIndex = 35;
            this.button_crearSubcategoria.Tag = "Crear subcategoria";
            this.button_crearSubcategoria.UseVisualStyleBackColor = true;
            this.button_crearSubcategoria.Click += new System.EventHandler(this.button_crearSubcategoria_Click);
            // 
            // butto_editarCategoria
            // 
            this.butto_editarCategoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butto_editarCategoria.FlatAppearance.BorderSize = 0;
            this.butto_editarCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butto_editarCategoria.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butto_editarCategoria.Image = global::cacatUA.Properties.Resources.tool;
            this.butto_editarCategoria.Location = new System.Drawing.Point(445, 70);
            this.butto_editarCategoria.Name = "butto_editarCategoria";
            this.butto_editarCategoria.Size = new System.Drawing.Size(36, 36);
            this.butto_editarCategoria.TabIndex = 33;
            this.butto_editarCategoria.Tag = "Modificar categoria seleccionada";
            this.butto_editarCategoria.UseVisualStyleBackColor = true;
            // 
            // button_borrarCategoria
            // 
            this.button_borrarCategoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_borrarCategoria.FlatAppearance.BorderSize = 0;
            this.button_borrarCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_borrarCategoria.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_borrarCategoria.Image = global::cacatUA.Properties.Resources.close;
            this.button_borrarCategoria.Location = new System.Drawing.Point(445, 112);
            this.button_borrarCategoria.Name = "button_borrarCategoria";
            this.button_borrarCategoria.Size = new System.Drawing.Size(36, 36);
            this.button_borrarCategoria.TabIndex = 34;
            this.button_borrarCategoria.Tag = "Borrar categoria seleccionada";
            this.button_borrarCategoria.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button8.Location = new System.Drawing.Point(381, 350);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(100, 25);
            this.button8.TabIndex = 17;
            this.button8.Text = "Añadir usuario";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button_quitarUsuario
            // 
            this.button_quitarUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_quitarUsuario.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_quitarUsuario.Location = new System.Drawing.Point(381, 319);
            this.button_quitarUsuario.Name = "button_quitarUsuario";
            this.button_quitarUsuario.Size = new System.Drawing.Size(100, 25);
            this.button_quitarUsuario.TabIndex = 16;
            this.button_quitarUsuario.Text = "Quitar usuario";
            this.button_quitarUsuario.UseVisualStyleBackColor = true;
            // 
            // button_verUsuario
            // 
            this.button_verUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_verUsuario.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_verUsuario.Location = new System.Drawing.Point(381, 288);
            this.button_verUsuario.Name = "button_verUsuario";
            this.button_verUsuario.Size = new System.Drawing.Size(100, 25);
            this.button_verUsuario.TabIndex = 15;
            this.button_verUsuario.Text = "Ver usuario";
            this.button_verUsuario.UseVisualStyleBackColor = true;
            this.button_verUsuario.Click += new System.EventHandler(this.button_verUsuario_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(20, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Usuarios suscritos:";
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(23, 288);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(344, 108);
            this.listBox1.TabIndex = 13;
            // 
            // treeViewCategorias
            // 
            this.treeViewCategorias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewCategorias.Location = new System.Drawing.Point(6, 24);
            this.treeViewCategorias.Name = "treeViewCategorias";
            this.treeViewCategorias.PathSeparator = "/";
            this.treeViewCategorias.Size = new System.Drawing.Size(261, 411);
            this.treeViewCategorias.TabIndex = 13;
            this.treeViewCategorias.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewCategorias_AfterSelect);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(814, 527);
            this.tableLayoutPanel1.TabIndex = 35;
            // 
            // FormCategorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormCategorias";
            this.Size = new System.Drawing.Size(814, 527);
            this.Load += new System.EventHandler(this.FormCategorias_Load);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox_Categoria.ResumeLayout(false);
            this.groupBox_Categoria.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_Seleccionar;
        private System.Windows.Forms.GroupBox groupBox_Categoria;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button_quitarUsuario;
        private System.Windows.Forms.Button button_verUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TreeView treeViewCategorias;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.Button butto_editarCategoria;
        private System.Windows.Forms.Button button_borrarCategoria;
        private System.Windows.Forms.Button button_crearSubcategoria;
        private System.Windows.Forms.Button button_noGuardar;
        private System.Windows.Forms.Button button_Guardar;
        private System.Windows.Forms.TextBox textBox_descripcion;
        private System.Windows.Forms.TextBox textBox_Raiz;
        private System.Windows.Forms.TextBox textBox_nMateriales;
        private System.Windows.Forms.TextBox textBox_nHilos;
        private System.Windows.Forms.LinkLabel linkLabel_verHilos;
        private System.Windows.Forms.Label label_nMateriales;
        private System.Windows.Forms.Label label_nHilos;
        private System.Windows.Forms.LinkLabel linkLabel_verMateriales;


    }
}
