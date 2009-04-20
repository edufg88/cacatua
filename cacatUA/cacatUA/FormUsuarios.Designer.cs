namespace cacatUA
{
    partial class FormUsuarios
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel_principal = new System.Windows.Forms.TableLayoutPanel();
            this.panel_cabecera = new System.Windows.Forms.Panel();
            this.label_usuarios = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel_opciones = new System.Windows.Forms.Panel();
            this.button_seccionCrear = new System.Windows.Forms.Button();
            this.button_seccionBuscar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel_cabeceraSeccion1 = new System.Windows.Forms.Panel();
            this.label_seccion1 = new System.Windows.Forms.Label();
            this.panel_contenedor = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel_cabeceraSeccion2 = new System.Windows.Forms.Panel();
            this.label_seccion2 = new System.Windows.Forms.Label();
            this.panel_DataGridViewUsuarios = new System.Windows.Forms.Panel();
            this.label_cantidadPagina = new System.Windows.Forms.Label();
            this.comboBox_cantidadPorPagina = new System.Windows.Forms.ComboBox();
            this.button_paginaSiguiente = new System.Windows.Forms.Button();
            this.button_paginaAnterior = new System.Windows.Forms.Button();
            this.comboBox_pagina = new System.Windows.Forms.ComboBox();
            this.dataGridView_usuarios = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contrasena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.correo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adicional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaingreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_editarUsuario = new System.Windows.Forms.Button();
            this.button_borrarUsuario = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label_resultados = new System.Windows.Forms.Label();
            this.tableLayoutPanel_principal.SuspendLayout();
            this.panel_cabecera.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel_opciones.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel_cabeceraSeccion1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel_cabeceraSeccion2.SuspendLayout();
            this.panel_DataGridViewUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_usuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_principal
            // 
            this.tableLayoutPanel_principal.ColumnCount = 1;
            this.tableLayoutPanel_principal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_principal.Controls.Add(this.panel_cabecera, 0, 0);
            this.tableLayoutPanel_principal.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel_principal.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel_principal.Controls.Add(this.panel_contenedor, 0, 3);
            this.tableLayoutPanel_principal.Controls.Add(this.panel5, 0, 4);
            this.tableLayoutPanel_principal.Controls.Add(this.panel_DataGridViewUsuarios, 0, 5);
            this.tableLayoutPanel_principal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_principal.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_principal.Name = "tableLayoutPanel_principal";
            this.tableLayoutPanel_principal.RowCount = 7;
            this.tableLayoutPanel_principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel_principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel_principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.tableLayoutPanel_principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel_principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_principal.Size = new System.Drawing.Size(838, 500);
            this.tableLayoutPanel_principal.TabIndex = 0;
            // 
            // panel_cabecera
            // 
            this.panel_cabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panel_cabecera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_cabecera.Controls.Add(this.label_usuarios);
            this.panel_cabecera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_cabecera.Location = new System.Drawing.Point(3, 3);
            this.panel_cabecera.Name = "panel_cabecera";
            this.panel_cabecera.Size = new System.Drawing.Size(832, 24);
            this.panel_cabecera.TabIndex = 31;
            // 
            // label_usuarios
            // 
            this.label_usuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label_usuarios.AutoSize = true;
            this.label_usuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_usuarios.ForeColor = System.Drawing.Color.White;
            this.label_usuarios.Location = new System.Drawing.Point(3, 0);
            this.label_usuarios.Name = "label_usuarios";
            this.label_usuarios.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.label_usuarios.Size = new System.Drawing.Size(64, 19);
            this.label_usuarios.TabIndex = 7;
            this.label_usuarios.Text = "Usuarios";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel_opciones);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 39);
            this.panel2.TabIndex = 32;
            // 
            // panel_opciones
            // 
            this.panel_opciones.Controls.Add(this.button_seccionCrear);
            this.panel_opciones.Controls.Add(this.button_seccionBuscar);
            this.panel_opciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_opciones.Location = new System.Drawing.Point(0, 0);
            this.panel_opciones.Margin = new System.Windows.Forms.Padding(0);
            this.panel_opciones.Name = "panel_opciones";
            this.panel_opciones.Size = new System.Drawing.Size(832, 39);
            this.panel_opciones.TabIndex = 2;
            // 
            // button_seccionCrear
            // 
            this.button_seccionCrear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_seccionCrear.FlatAppearance.BorderSize = 0;
            this.button_seccionCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_seccionCrear.Image = global::cacatUA.Properties.Resources.nuevo;
            this.button_seccionCrear.Location = new System.Drawing.Point(39, 2);
            this.button_seccionCrear.Name = "button_seccionCrear";
            this.button_seccionCrear.Size = new System.Drawing.Size(36, 36);
            this.button_seccionCrear.TabIndex = 1;
            this.toolTip1.SetToolTip(this.button_seccionCrear, "Seleccionar el panel de creación de usuario");
            this.button_seccionCrear.UseVisualStyleBackColor = true;
            this.button_seccionCrear.Click += new System.EventHandler(this.button_seccionCrear_Click);
            // 
            // button_seccionBuscar
            // 
            this.button_seccionBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_seccionBuscar.FlatAppearance.BorderSize = 0;
            this.button_seccionBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_seccionBuscar.Image = global::cacatUA.Properties.Resources.buscar1;
            this.button_seccionBuscar.Location = new System.Drawing.Point(3, 2);
            this.button_seccionBuscar.Name = "button_seccionBuscar";
            this.button_seccionBuscar.Size = new System.Drawing.Size(36, 36);
            this.button_seccionBuscar.TabIndex = 0;
            this.toolTip1.SetToolTip(this.button_seccionBuscar, "Seleccionar el panel de búsqueda de usuario");
            this.button_seccionBuscar.UseVisualStyleBackColor = true;
            this.button_seccionBuscar.Click += new System.EventHandler(this.button_seccionBuscar_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel_cabeceraSeccion1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 78);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(832, 29);
            this.panel3.TabIndex = 33;
            // 
            // panel_cabeceraSeccion1
            // 
            this.panel_cabeceraSeccion1.BackColor = System.Drawing.Color.LightGray;
            this.panel_cabeceraSeccion1.Controls.Add(this.label_seccion1);
            this.panel_cabeceraSeccion1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_cabeceraSeccion1.Location = new System.Drawing.Point(0, 0);
            this.panel_cabeceraSeccion1.Name = "panel_cabeceraSeccion1";
            this.panel_cabeceraSeccion1.Size = new System.Drawing.Size(832, 29);
            this.panel_cabeceraSeccion1.TabIndex = 3;
            // 
            // label_seccion1
            // 
            this.label_seccion1.AutoSize = true;
            this.label_seccion1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_seccion1.Location = new System.Drawing.Point(13, 8);
            this.label_seccion1.Name = "label_seccion1";
            this.label_seccion1.Size = new System.Drawing.Size(63, 13);
            this.label_seccion1.TabIndex = 0;
            this.label_seccion1.Text = "Búsqueda";
            // 
            // panel_contenedor
            // 
            this.panel_contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_contenedor.Location = new System.Drawing.Point(3, 113);
            this.panel_contenedor.Name = "panel_contenedor";
            this.panel_contenedor.Size = new System.Drawing.Size(832, 234);
            this.panel_contenedor.TabIndex = 34;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel_cabeceraSeccion2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 353);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(832, 29);
            this.panel5.TabIndex = 35;
            // 
            // panel_cabeceraSeccion2
            // 
            this.panel_cabeceraSeccion2.BackColor = System.Drawing.Color.LightGray;
            this.panel_cabeceraSeccion2.Controls.Add(this.label_resultados);
            this.panel_cabeceraSeccion2.Controls.Add(this.label_seccion2);
            this.panel_cabeceraSeccion2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_cabeceraSeccion2.Location = new System.Drawing.Point(0, 0);
            this.panel_cabeceraSeccion2.Name = "panel_cabeceraSeccion2";
            this.panel_cabeceraSeccion2.Size = new System.Drawing.Size(832, 29);
            this.panel_cabeceraSeccion2.TabIndex = 4;
            // 
            // label_seccion2
            // 
            this.label_seccion2.AutoSize = true;
            this.label_seccion2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_seccion2.Location = new System.Drawing.Point(13, 8);
            this.label_seccion2.Name = "label_seccion2";
            this.label_seccion2.Size = new System.Drawing.Size(147, 13);
            this.label_seccion2.TabIndex = 0;
            this.label_seccion2.Text = "Resultados de búsqueda";
            // 
            // panel_DataGridViewUsuarios
            // 
            this.panel_DataGridViewUsuarios.Controls.Add(this.label_cantidadPagina);
            this.panel_DataGridViewUsuarios.Controls.Add(this.comboBox_cantidadPorPagina);
            this.panel_DataGridViewUsuarios.Controls.Add(this.button_paginaSiguiente);
            this.panel_DataGridViewUsuarios.Controls.Add(this.button_paginaAnterior);
            this.panel_DataGridViewUsuarios.Controls.Add(this.comboBox_pagina);
            this.panel_DataGridViewUsuarios.Controls.Add(this.dataGridView_usuarios);
            this.panel_DataGridViewUsuarios.Controls.Add(this.button_editarUsuario);
            this.panel_DataGridViewUsuarios.Controls.Add(this.button_borrarUsuario);
            this.panel_DataGridViewUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_DataGridViewUsuarios.Location = new System.Drawing.Point(3, 388);
            this.panel_DataGridViewUsuarios.Name = "panel_DataGridViewUsuarios";
            this.panel_DataGridViewUsuarios.Size = new System.Drawing.Size(832, 89);
            this.panel_DataGridViewUsuarios.TabIndex = 36;
            // 
            // label_cantidadPagina
            // 
            this.label_cantidadPagina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_cantidadPagina.AutoSize = true;
            this.label_cantidadPagina.Location = new System.Drawing.Point(4, 62);
            this.label_cantidadPagina.Name = "label_cantidadPagina";
            this.label_cantidadPagina.Size = new System.Drawing.Size(105, 13);
            this.label_cantidadPagina.TabIndex = 13;
            this.label_cantidadPagina.Text = "Cantidad por página:";
            // 
            // comboBox_cantidadPorPagina
            // 
            this.comboBox_cantidadPorPagina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox_cantidadPorPagina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_cantidadPorPagina.FormattingEnabled = true;
            this.comboBox_cantidadPorPagina.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50",
            "55",
            "60",
            "65",
            "70",
            "75",
            "80",
            "85",
            "90",
            "95",
            "100",
            "110",
            "120",
            "130",
            "140",
            "150",
            "160",
            "170",
            "180",
            "190",
            "200",
            "250",
            "300"});
            this.comboBox_cantidadPorPagina.Location = new System.Drawing.Point(112, 58);
            this.comboBox_cantidadPorPagina.Name = "comboBox_cantidadPorPagina";
            this.comboBox_cantidadPorPagina.Size = new System.Drawing.Size(45, 21);
            this.comboBox_cantidadPorPagina.TabIndex = 14;
            this.comboBox_cantidadPorPagina.SelectionChangeCommitted += new System.EventHandler(this.comboBox_cantidadPorPagina_SelectionChangeCommitted);
            // 
            // button_paginaSiguiente
            // 
            this.button_paginaSiguiente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_paginaSiguiente.Location = new System.Drawing.Point(707, 57);
            this.button_paginaSiguiente.Name = "button_paginaSiguiente";
            this.button_paginaSiguiente.Size = new System.Drawing.Size(75, 23);
            this.button_paginaSiguiente.TabIndex = 17;
            this.button_paginaSiguiente.Text = "Siguiente";
            this.button_paginaSiguiente.UseVisualStyleBackColor = true;
            this.button_paginaSiguiente.Click += new System.EventHandler(this.button_paginaSiguiente_Click);
            // 
            // button_paginaAnterior
            // 
            this.button_paginaAnterior.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_paginaAnterior.Location = new System.Drawing.Point(574, 57);
            this.button_paginaAnterior.Name = "button_paginaAnterior";
            this.button_paginaAnterior.Size = new System.Drawing.Size(75, 23);
            this.button_paginaAnterior.TabIndex = 15;
            this.button_paginaAnterior.Text = "Anterior";
            this.button_paginaAnterior.UseVisualStyleBackColor = true;
            this.button_paginaAnterior.Click += new System.EventHandler(this.button_paginaAnterior_Click);
            // 
            // comboBox_pagina
            // 
            this.comboBox_pagina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_pagina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_pagina.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30"});
            this.comboBox_pagina.Location = new System.Drawing.Point(655, 58);
            this.comboBox_pagina.Name = "comboBox_pagina";
            this.comboBox_pagina.Size = new System.Drawing.Size(46, 21);
            this.comboBox_pagina.TabIndex = 16;
            this.comboBox_pagina.SelectionChangeCommitted += new System.EventHandler(this.comboBox_pagina_SelectionChangeCommitted);
            // 
            // dataGridView_usuarios
            // 
            this.dataGridView_usuarios.AllowUserToAddRows = false;
            this.dataGridView_usuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_usuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_usuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_usuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.usuario,
            this.contrasena,
            this.nombre,
            this.dni,
            this.correo,
            this.adicional,
            this.fechaingreso,
            this.activo});
            this.dataGridView_usuarios.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_usuarios.Name = "dataGridView_usuarios";
            this.dataGridView_usuarios.RowHeadersVisible = false;
            this.dataGridView_usuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_usuarios.Size = new System.Drawing.Size(779, 44);
            this.dataGridView_usuarios.TabIndex = 2;
            this.dataGridView_usuarios.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_usuarios_CellMouseClick);
            this.dataGridView_usuarios.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_usuarios_CellMouseDoubleClick);
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // usuario
            // 
            this.usuario.HeaderText = "Usuario";
            this.usuario.Name = "usuario";
            this.usuario.ReadOnly = true;
            // 
            // contrasena
            // 
            this.contrasena.HeaderText = "Contraseña";
            this.contrasena.Name = "contrasena";
            this.contrasena.ReadOnly = true;
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // dni
            // 
            this.dni.HeaderText = "DNI";
            this.dni.Name = "dni";
            this.dni.ReadOnly = true;
            // 
            // correo
            // 
            this.correo.HeaderText = "Correo";
            this.correo.Name = "correo";
            this.correo.ReadOnly = true;
            // 
            // adicional
            // 
            this.adicional.HeaderText = "Adicional";
            this.adicional.Name = "adicional";
            this.adicional.ReadOnly = true;
            // 
            // fechaingreso
            // 
            this.fechaingreso.HeaderText = "Fecha de ingreso";
            this.fechaingreso.Name = "fechaingreso";
            this.fechaingreso.ReadOnly = true;
            // 
            // activo
            // 
            this.activo.HeaderText = "Activo";
            this.activo.Name = "activo";
            this.activo.ReadOnly = true;
            // 
            // button_editarUsuario
            // 
            this.button_editarUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_editarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_editarUsuario.FlatAppearance.BorderSize = 0;
            this.button_editarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_editarUsuario.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_editarUsuario.Image = global::cacatUA.Properties.Resources.tool;
            this.button_editarUsuario.Location = new System.Drawing.Point(788, 3);
            this.button_editarUsuario.Name = "button_editarUsuario";
            this.button_editarUsuario.Size = new System.Drawing.Size(36, 36);
            this.button_editarUsuario.TabIndex = 12;
            this.button_editarUsuario.Tag = "Modificar hilo seleccionado";
            this.toolTip1.SetToolTip(this.button_editarUsuario, "Editar el usuario seleccionado");
            this.button_editarUsuario.UseVisualStyleBackColor = true;
            this.button_editarUsuario.Click += new System.EventHandler(this.button_editarUsuario_Click);
            // 
            // button_borrarUsuario
            // 
            this.button_borrarUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_borrarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_borrarUsuario.FlatAppearance.BorderSize = 0;
            this.button_borrarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_borrarUsuario.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_borrarUsuario.Image = global::cacatUA.Properties.Resources.close;
            this.button_borrarUsuario.Location = new System.Drawing.Point(788, 40);
            this.button_borrarUsuario.Name = "button_borrarUsuario";
            this.button_borrarUsuario.Size = new System.Drawing.Size(36, 36);
            this.button_borrarUsuario.TabIndex = 11;
            this.button_borrarUsuario.Tag = "Eliminar hilo seleccionado";
            this.toolTip1.SetToolTip(this.button_borrarUsuario, "Borrar el usuario seleccionado");
            this.button_borrarUsuario.UseVisualStyleBackColor = true;
            this.button_borrarUsuario.Click += new System.EventHandler(this.button_borrarUsuario_Click);
            // 
            // label_resultados
            // 
            this.label_resultados.AutoSize = true;
            this.label_resultados.Location = new System.Drawing.Point(166, 8);
            this.label_resultados.Name = "label_resultados";
            this.label_resultados.Size = new System.Drawing.Size(214, 13);
            this.label_resultados.TabIndex = 37;
            this.label_resultados.Text = "(mostrando 0 - 0 de 0 usuarios encontrados)";
            // 
            // FormUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel_principal);
            this.Name = "FormUsuarios";
            this.Size = new System.Drawing.Size(838, 500);
            this.tableLayoutPanel_principal.ResumeLayout(false);
            this.panel_cabecera.ResumeLayout(false);
            this.panel_cabecera.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel_opciones.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel_cabeceraSeccion1.ResumeLayout(false);
            this.panel_cabeceraSeccion1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel_cabeceraSeccion2.ResumeLayout(false);
            this.panel_cabeceraSeccion2.PerformLayout();
            this.panel_DataGridViewUsuarios.ResumeLayout(false);
            this.panel_DataGridViewUsuarios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_usuarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_principal;
        private System.Windows.Forms.Panel panel_cabecera;
        private System.Windows.Forms.Label label_usuarios;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel_opciones;
        private System.Windows.Forms.Button button_seccionCrear;
        private System.Windows.Forms.Button button_seccionBuscar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel_cabeceraSeccion1;
        private System.Windows.Forms.Label label_seccion1;
        private System.Windows.Forms.Panel panel_contenedor;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel_DataGridViewUsuarios;
        private System.Windows.Forms.DataGridView dataGridView_usuarios;
        private System.Windows.Forms.Panel panel_cabeceraSeccion2;
        private System.Windows.Forms.Label label_seccion2;
        private System.Windows.Forms.Button button_borrarUsuario;
        private System.Windows.Forms.Button button_editarUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn contrasena;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn dni;
        private System.Windows.Forms.DataGridViewTextBoxColumn correo;
        private System.Windows.Forms.DataGridViewTextBoxColumn adicional;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaingreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn activo;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label_cantidadPagina;
        private System.Windows.Forms.ComboBox comboBox_cantidadPorPagina;
        private System.Windows.Forms.Button button_paginaSiguiente;
        private System.Windows.Forms.Button button_paginaAnterior;
        private System.Windows.Forms.ComboBox comboBox_pagina;
        private System.Windows.Forms.Label label_resultados;
    }
}
