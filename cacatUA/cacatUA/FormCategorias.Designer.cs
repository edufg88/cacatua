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
            this.components = new System.ComponentModel.Container();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_FuncionArbol = new System.Windows.Forms.Label();
            this.groupBox_Informacion = new System.Windows.Forms.GroupBox();
            this.dataGridView_Usuarios = new System.Windows.Forms.DataGridView();
            this.DataGridViewColumno_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewColumno_Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewColumno_Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linkLabel_verMateriales = new System.Windows.Forms.LinkLabel();
            this.textBox_nMateriales = new System.Windows.Forms.TextBox();
            this.textBox_nHilos = new System.Windows.Forms.TextBox();
            this.linkLabel_verHilos = new System.Windows.Forms.LinkLabel();
            this.label_nMateriales = new System.Windows.Forms.Label();
            this.label_nHilos = new System.Windows.Forms.Label();
            this.button_AñadirUsuario = new System.Windows.Forms.Button();
            this.button_quitarUsuario = new System.Windows.Forms.Button();
            this.button_verUsuario = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox_Administracion = new System.Windows.Forms.GroupBox();
            this.button_LimpiarRuta = new System.Windows.Forms.Button();
            this.label_Descripcion = new System.Windows.Forms.Label();
            this.label_Ruta = new System.Windows.Forms.Label();
            this.textBox_Ruta = new System.Windows.Forms.TextBox();
            this.label_Nombre = new System.Windows.Forms.Label();
            this.textBox_Nombre = new System.Windows.Forms.TextBox();
            this.textBox_Descripcion = new System.Windows.Forms.TextBox();
            this.button_noGuardar = new System.Windows.Forms.Button();
            this.button_Guardar = new System.Windows.Forms.Button();
            this.button_crearCategoria = new System.Windows.Forms.Button();
            this.button_editarCategoria = new System.Windows.Forms.Button();
            this.button_borrarCategoria = new System.Windows.Forms.Button();
            this.treeViewCategorias = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.errorProvider_Categorias = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip_Categorias = new System.Windows.Forms.ToolTip(this.components);
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox_Informacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Usuarios)).BeginInit();
            this.groupBox_Administracion.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_Categorias)).BeginInit();
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
            this.panel1.Controls.Add(this.label_FuncionArbol);
            this.panel1.Controls.Add(this.groupBox_Informacion);
            this.panel1.Controls.Add(this.groupBox_Administracion);
            this.panel1.Controls.Add(this.treeViewCategorias);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.panel1.Location = new System.Drawing.Point(3, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(808, 490);
            this.panel1.TabIndex = 31;
            // 
            // label_FuncionArbol
            // 
            this.label_FuncionArbol.AutoSize = true;
            this.label_FuncionArbol.Location = new System.Drawing.Point(12, 24);
            this.label_FuncionArbol.Name = "label_FuncionArbol";
            this.label_FuncionArbol.Size = new System.Drawing.Size(234, 13);
            this.label_FuncionArbol.TabIndex = 15;
            this.label_FuncionArbol.Text = "Seleccione una categoria para más informacion:";
            // 
            // groupBox_Informacion
            // 
            this.groupBox_Informacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Informacion.Controls.Add(this.dataGridView_Usuarios);
            this.groupBox_Informacion.Controls.Add(this.linkLabel_verMateriales);
            this.groupBox_Informacion.Controls.Add(this.textBox_nMateriales);
            this.groupBox_Informacion.Controls.Add(this.textBox_nHilos);
            this.groupBox_Informacion.Controls.Add(this.linkLabel_verHilos);
            this.groupBox_Informacion.Controls.Add(this.label_nMateriales);
            this.groupBox_Informacion.Controls.Add(this.label_nHilos);
            this.groupBox_Informacion.Controls.Add(this.button_AñadirUsuario);
            this.groupBox_Informacion.Controls.Add(this.button_quitarUsuario);
            this.groupBox_Informacion.Controls.Add(this.button_verUsuario);
            this.groupBox_Informacion.Controls.Add(this.label3);
            this.groupBox_Informacion.Enabled = false;
            this.groupBox_Informacion.Location = new System.Drawing.Point(284, 253);
            this.groupBox_Informacion.Name = "groupBox_Informacion";
            this.groupBox_Informacion.Size = new System.Drawing.Size(507, 218);
            this.groupBox_Informacion.TabIndex = 14;
            this.groupBox_Informacion.TabStop = false;
            this.groupBox_Informacion.Text = "Otra información";
            // 
            // dataGridView_Usuarios
            // 
            this.dataGridView_Usuarios.AllowUserToAddRows = false;
            this.dataGridView_Usuarios.AllowUserToDeleteRows = false;
            this.dataGridView_Usuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Usuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Usuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataGridViewColumno_Id,
            this.DataGridViewColumno_Usuario,
            this.DataGridViewColumno_Nombre});
            this.dataGridView_Usuarios.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.dataGridView_Usuarios.Location = new System.Drawing.Point(30, 131);
            this.dataGridView_Usuarios.Name = "dataGridView_Usuarios";
            this.dataGridView_Usuarios.ReadOnly = true;
            this.dataGridView_Usuarios.RowHeadersVisible = false;
            this.dataGridView_Usuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Usuarios.Size = new System.Drawing.Size(332, 76);
            this.dataGridView_Usuarios.TabIndex = 157;
            // 
            // DataGridViewColumno_Id
            // 
            this.DataGridViewColumno_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DataGridViewColumno_Id.FillWeight = 15F;
            this.DataGridViewColumno_Id.HeaderText = "ID";
            this.DataGridViewColumno_Id.Name = "DataGridViewColumno_Id";
            this.DataGridViewColumno_Id.ReadOnly = true;
            // 
            // DataGridViewColumno_Usuario
            // 
            this.DataGridViewColumno_Usuario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DataGridViewColumno_Usuario.FillWeight = 35F;
            this.DataGridViewColumno_Usuario.HeaderText = "Usuario";
            this.DataGridViewColumno_Usuario.Name = "DataGridViewColumno_Usuario";
            this.DataGridViewColumno_Usuario.ReadOnly = true;
            // 
            // DataGridViewColumno_Nombre
            // 
            this.DataGridViewColumno_Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DataGridViewColumno_Nombre.FillWeight = 50F;
            this.DataGridViewColumno_Nombre.HeaderText = "Nombre";
            this.DataGridViewColumno_Nombre.Name = "DataGridViewColumno_Nombre";
            this.DataGridViewColumno_Nombre.ReadOnly = true;
            // 
            // linkLabel_verMateriales
            // 
            this.linkLabel_verMateriales.AutoSize = true;
            this.linkLabel_verMateriales.Location = new System.Drawing.Point(262, 69);
            this.linkLabel_verMateriales.Name = "linkLabel_verMateriales";
            this.linkLabel_verMateriales.Size = new System.Drawing.Size(73, 13);
            this.linkLabel_verMateriales.TabIndex = 156;
            this.linkLabel_verMateriales.TabStop = true;
            this.linkLabel_verMateriales.Text = "Ver materiales";
            this.toolTip_Categorias.SetToolTip(this.linkLabel_verMateriales, "Ver los materiales asociados a esta categoria.");
            this.linkLabel_verMateriales.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_verMateriales_LinkClicked);
            // 
            // textBox_nMateriales
            // 
            this.textBox_nMateriales.Location = new System.Drawing.Point(188, 66);
            this.textBox_nMateriales.Name = "textBox_nMateriales";
            this.textBox_nMateriales.ReadOnly = true;
            this.textBox_nMateriales.Size = new System.Drawing.Size(40, 20);
            this.textBox_nMateriales.TabIndex = 155;
            // 
            // textBox_nHilos
            // 
            this.textBox_nHilos.Location = new System.Drawing.Point(188, 32);
            this.textBox_nHilos.Name = "textBox_nHilos";
            this.textBox_nHilos.ReadOnly = true;
            this.textBox_nHilos.Size = new System.Drawing.Size(40, 20);
            this.textBox_nHilos.TabIndex = 154;
            // 
            // linkLabel_verHilos
            // 
            this.linkLabel_verHilos.AutoSize = true;
            this.linkLabel_verHilos.Location = new System.Drawing.Point(262, 35);
            this.linkLabel_verHilos.Name = "linkLabel_verHilos";
            this.linkLabel_verHilos.Size = new System.Drawing.Size(47, 13);
            this.linkLabel_verHilos.TabIndex = 153;
            this.linkLabel_verHilos.TabStop = true;
            this.linkLabel_verHilos.Text = "Ver hilos";
            this.toolTip_Categorias.SetToolTip(this.linkLabel_verHilos, "Ver los hilos asociados a esta categoria.");
            this.linkLabel_verHilos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_verHilos_LinkClicked);
            // 
            // label_nMateriales
            // 
            this.label_nMateriales.AutoSize = true;
            this.label_nMateriales.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_nMateriales.Location = new System.Drawing.Point(27, 69);
            this.label_nMateriales.Name = "label_nMateriales";
            this.label_nMateriales.Size = new System.Drawing.Size(137, 13);
            this.label_nMateriales.TabIndex = 152;
            this.label_nMateriales.Text = "Número de materiales: ";
            // 
            // label_nHilos
            // 
            this.label_nHilos.AutoSize = true;
            this.label_nHilos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_nHilos.Location = new System.Drawing.Point(27, 35);
            this.label_nHilos.Name = "label_nHilos";
            this.label_nHilos.Size = new System.Drawing.Size(106, 13);
            this.label_nHilos.TabIndex = 151;
            this.label_nHilos.Text = "Número de hilos: ";
            // 
            // button_AñadirUsuario
            // 
            this.button_AñadirUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_AñadirUsuario.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_AñadirUsuario.Location = new System.Drawing.Point(380, 162);
            this.button_AñadirUsuario.Name = "button_AñadirUsuario";
            this.button_AñadirUsuario.Size = new System.Drawing.Size(100, 25);
            this.button_AñadirUsuario.TabIndex = 149;
            this.button_AñadirUsuario.Text = "Añadir usuario";
            this.toolTip_Categorias.SetToolTip(this.button_AñadirUsuario, "Suscribir un usuario a esta categoria.");
            this.button_AñadirUsuario.UseVisualStyleBackColor = true;
            this.button_AñadirUsuario.Click += new System.EventHandler(this.button_AñadirUsuario_Click);
            // 
            // button_quitarUsuario
            // 
            this.button_quitarUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_quitarUsuario.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_quitarUsuario.Location = new System.Drawing.Point(380, 193);
            this.button_quitarUsuario.Name = "button_quitarUsuario";
            this.button_quitarUsuario.Size = new System.Drawing.Size(100, 25);
            this.button_quitarUsuario.TabIndex = 148;
            this.button_quitarUsuario.Text = "Quitar usuario";
            this.toolTip_Categorias.SetToolTip(this.button_quitarUsuario, "Borrar la suscripción del usuario en esta categoria.");
            this.button_quitarUsuario.UseVisualStyleBackColor = true;
            this.button_quitarUsuario.Click += new System.EventHandler(this.button_quitarUsuario_Click);
            // 
            // button_verUsuario
            // 
            this.button_verUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_verUsuario.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_verUsuario.Location = new System.Drawing.Point(380, 131);
            this.button_verUsuario.Name = "button_verUsuario";
            this.button_verUsuario.Size = new System.Drawing.Size(100, 25);
            this.button_verUsuario.TabIndex = 147;
            this.button_verUsuario.Text = "Ver usuario";
            this.toolTip_Categorias.SetToolTip(this.button_verUsuario, "Ver el usuario seleccionado.");
            this.button_verUsuario.UseVisualStyleBackColor = true;
            this.button_verUsuario.Click += new System.EventHandler(this.button_verUsuario_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(27, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 150;
            this.label3.Text = "Usuarios suscritos:";
            // 
            // groupBox_Administracion
            // 
            this.groupBox_Administracion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Administracion.Controls.Add(this.button_LimpiarRuta);
            this.groupBox_Administracion.Controls.Add(this.label_Descripcion);
            this.groupBox_Administracion.Controls.Add(this.label_Ruta);
            this.groupBox_Administracion.Controls.Add(this.textBox_Ruta);
            this.groupBox_Administracion.Controls.Add(this.label_Nombre);
            this.groupBox_Administracion.Controls.Add(this.textBox_Nombre);
            this.groupBox_Administracion.Controls.Add(this.textBox_Descripcion);
            this.groupBox_Administracion.Controls.Add(this.button_noGuardar);
            this.groupBox_Administracion.Controls.Add(this.button_Guardar);
            this.groupBox_Administracion.Controls.Add(this.button_crearCategoria);
            this.groupBox_Administracion.Controls.Add(this.button_editarCategoria);
            this.groupBox_Administracion.Controls.Add(this.button_borrarCategoria);
            this.groupBox_Administracion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox_Administracion.Location = new System.Drawing.Point(284, 24);
            this.groupBox_Administracion.Name = "groupBox_Administracion";
            this.groupBox_Administracion.Size = new System.Drawing.Size(507, 212);
            this.groupBox_Administracion.TabIndex = 3;
            this.groupBox_Administracion.TabStop = false;
            this.groupBox_Administracion.Text = "Administración";
            // 
            // button_LimpiarRuta
            // 
            this.button_LimpiarRuta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button_LimpiarRuta.Location = new System.Drawing.Point(380, 54);
            this.button_LimpiarRuta.Name = "button_LimpiarRuta";
            this.button_LimpiarRuta.Size = new System.Drawing.Size(52, 23);
            this.button_LimpiarRuta.TabIndex = 149;
            this.button_LimpiarRuta.Text = "Limpiar";
            this.button_LimpiarRuta.UseVisualStyleBackColor = true;
            this.button_LimpiarRuta.Visible = false;
            this.button_LimpiarRuta.Click += new System.EventHandler(this.button_LimpiarRuta_Click);
            // 
            // label_Descripcion
            // 
            this.label_Descripcion.AutoSize = true;
            this.label_Descripcion.Location = new System.Drawing.Point(20, 85);
            this.label_Descripcion.Name = "label_Descripcion";
            this.label_Descripcion.Size = new System.Drawing.Size(66, 13);
            this.label_Descripcion.TabIndex = 147;
            this.label_Descripcion.Text = "Descripcion:";
            // 
            // label_Ruta
            // 
            this.label_Ruta.AutoSize = true;
            this.label_Ruta.Location = new System.Drawing.Point(20, 59);
            this.label_Ruta.Name = "label_Ruta";
            this.label_Ruta.Size = new System.Drawing.Size(36, 13);
            this.label_Ruta.TabIndex = 54;
            this.label_Ruta.Text = "Ruta: ";
            // 
            // textBox_Ruta
            // 
            this.textBox_Ruta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Ruta.Location = new System.Drawing.Point(100, 56);
            this.textBox_Ruta.Name = "textBox_Ruta";
            this.textBox_Ruta.ReadOnly = true;
            this.textBox_Ruta.Size = new System.Drawing.Size(267, 20);
            this.textBox_Ruta.TabIndex = 53;
            // 
            // label_Nombre
            // 
            this.label_Nombre.AutoSize = true;
            this.label_Nombre.Location = new System.Drawing.Point(20, 33);
            this.label_Nombre.Name = "label_Nombre";
            this.label_Nombre.Size = new System.Drawing.Size(47, 13);
            this.label_Nombre.TabIndex = 48;
            this.label_Nombre.Text = "Nombre:";
            // 
            // textBox_Nombre
            // 
            this.textBox_Nombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Nombre.Location = new System.Drawing.Point(100, 30);
            this.textBox_Nombre.Name = "textBox_Nombre";
            this.textBox_Nombre.ReadOnly = true;
            this.textBox_Nombre.Size = new System.Drawing.Size(267, 20);
            this.textBox_Nombre.TabIndex = 0;
            // 
            // textBox_Descripcion
            // 
            this.textBox_Descripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Descripcion.Location = new System.Drawing.Point(23, 107);
            this.textBox_Descripcion.Multiline = true;
            this.textBox_Descripcion.Name = "textBox_Descripcion";
            this.textBox_Descripcion.ReadOnly = true;
            this.textBox_Descripcion.Size = new System.Drawing.Size(409, 62);
            this.textBox_Descripcion.TabIndex = 1;
            // 
            // button_noGuardar
            // 
            this.button_noGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_noGuardar.Location = new System.Drawing.Point(350, 175);
            this.button_noGuardar.Name = "button_noGuardar";
            this.button_noGuardar.Size = new System.Drawing.Size(82, 24);
            this.button_noGuardar.TabIndex = 3;
            this.button_noGuardar.Text = "Cancelar";
            this.button_noGuardar.UseVisualStyleBackColor = true;
            this.button_noGuardar.Visible = false;
            this.button_noGuardar.Click += new System.EventHandler(this.button_noGuardar_Click);
            // 
            // button_Guardar
            // 
            this.button_Guardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Guardar.Location = new System.Drawing.Point(258, 175);
            this.button_Guardar.Name = "button_Guardar";
            this.button_Guardar.Size = new System.Drawing.Size(82, 24);
            this.button_Guardar.TabIndex = 2;
            this.button_Guardar.Text = "Guardar";
            this.button_Guardar.UseVisualStyleBackColor = true;
            this.button_Guardar.Visible = false;
            this.button_Guardar.Click += new System.EventHandler(this.button_Guardar_Click);
            // 
            // button_crearCategoria
            // 
            this.button_crearCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_crearCategoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_crearCategoria.FlatAppearance.BorderSize = 0;
            this.button_crearCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_crearCategoria.Image = global::cacatUA.Properties.Resources.nuevo;
            this.button_crearCategoria.Location = new System.Drawing.Point(465, 10);
            this.button_crearCategoria.Name = "button_crearCategoria";
            this.button_crearCategoria.Size = new System.Drawing.Size(36, 36);
            this.button_crearCategoria.TabIndex = 7;
            this.button_crearCategoria.Tag = "Crear categoria";
            this.toolTip_Categorias.SetToolTip(this.button_crearCategoria, "Crear una nueva categoria.");
            this.button_crearCategoria.UseVisualStyleBackColor = true;
            this.button_crearCategoria.Click += new System.EventHandler(this.button_crearCategoria_Click);
            // 
            // button_editarCategoria
            // 
            this.button_editarCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_editarCategoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_editarCategoria.FlatAppearance.BorderSize = 0;
            this.button_editarCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_editarCategoria.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_editarCategoria.Image = global::cacatUA.Properties.Resources.tool;
            this.button_editarCategoria.Location = new System.Drawing.Point(465, 47);
            this.button_editarCategoria.Name = "button_editarCategoria";
            this.button_editarCategoria.Size = new System.Drawing.Size(36, 36);
            this.button_editarCategoria.TabIndex = 8;
            this.button_editarCategoria.Tag = "Modificar categoria seleccionada";
            this.toolTip_Categorias.SetToolTip(this.button_editarCategoria, "Modificar la categoria seleccionada.");
            this.button_editarCategoria.UseVisualStyleBackColor = true;
            this.button_editarCategoria.Click += new System.EventHandler(this.button_editarCategoria_Click);
            // 
            // button_borrarCategoria
            // 
            this.button_borrarCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_borrarCategoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_borrarCategoria.FlatAppearance.BorderSize = 0;
            this.button_borrarCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_borrarCategoria.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_borrarCategoria.Image = global::cacatUA.Properties.Resources.close;
            this.button_borrarCategoria.Location = new System.Drawing.Point(465, 85);
            this.button_borrarCategoria.Name = "button_borrarCategoria";
            this.button_borrarCategoria.Size = new System.Drawing.Size(36, 36);
            this.button_borrarCategoria.TabIndex = 9;
            this.button_borrarCategoria.Tag = "Borrar categoria seleccionada";
            this.toolTip_Categorias.SetToolTip(this.button_borrarCategoria, "Borrar la categoria seleccionada.");
            this.button_borrarCategoria.UseVisualStyleBackColor = true;
            this.button_borrarCategoria.Click += new System.EventHandler(this.button_borrarCategoria_Click);
            // 
            // treeViewCategorias
            // 
            this.treeViewCategorias.AllowDrop = true;
            this.treeViewCategorias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewCategorias.Location = new System.Drawing.Point(6, 54);
            this.treeViewCategorias.Name = "treeViewCategorias";
            this.treeViewCategorias.PathSeparator = "/";
            this.treeViewCategorias.Size = new System.Drawing.Size(261, 417);
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
            // errorProvider_Categorias
            // 
            this.errorProvider_Categorias.ContainerControl = this;
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
            this.panel1.PerformLayout();
            this.groupBox_Informacion.ResumeLayout(false);
            this.groupBox_Informacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Usuarios)).EndInit();
            this.groupBox_Administracion.ResumeLayout(false);
            this.groupBox_Administracion.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_Categorias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox_Administracion;
        private System.Windows.Forms.TreeView treeViewCategorias;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_editarCategoria;
        private System.Windows.Forms.Button button_borrarCategoria;
        private System.Windows.Forms.Button button_crearCategoria;
        private System.Windows.Forms.Button button_noGuardar;
        private System.Windows.Forms.Button button_Guardar;
        private System.Windows.Forms.TextBox textBox_Descripcion;
        private System.Windows.Forms.TextBox textBox_Nombre;
        private System.Windows.Forms.Label label_Nombre;
        private System.Windows.Forms.Label label_Ruta;
        private System.Windows.Forms.TextBox textBox_Ruta;
        private System.Windows.Forms.Label label_Descripcion;
        private System.Windows.Forms.GroupBox groupBox_Informacion;
        private System.Windows.Forms.DataGridView dataGridView_Usuarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewColumno_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewColumno_Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewColumno_Nombre;
        private System.Windows.Forms.LinkLabel linkLabel_verMateriales;
        private System.Windows.Forms.TextBox textBox_nMateriales;
        private System.Windows.Forms.TextBox textBox_nHilos;
        private System.Windows.Forms.LinkLabel linkLabel_verHilos;
        private System.Windows.Forms.Label label_nMateriales;
        private System.Windows.Forms.Label label_nHilos;
        private System.Windows.Forms.Button button_AñadirUsuario;
        private System.Windows.Forms.Button button_quitarUsuario;
        private System.Windows.Forms.Button button_verUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider_Categorias;
        private System.Windows.Forms.ToolTip toolTip_Categorias;
        private System.Windows.Forms.Label label_FuncionArbol;
        private System.Windows.Forms.Button button_LimpiarRuta;


    }
}
