namespace cacatUA
{
    partial class FormMaterialesComentarios
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
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label_id = new System.Windows.Forms.Label();
            this.textBox_usuario = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_seleccionarUsuario = new System.Windows.Forms.Button();
            this.label_autor = new System.Windows.Forms.Label();
            this.tableLayoutPanel_secundario = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textBox_texto = new System.Windows.Forms.TextBox();
            this.label_texto = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dateTimePicker_fecha = new System.Windows.Forms.DateTimePicker();
            this.label_fechaCreacion = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.button_accion2 = new System.Windows.Forms.Button();
            this.button_accion1 = new System.Windows.Forms.Button();
            this.panel_contenedor = new System.Windows.Forms.Panel();
            this.button_editar = new System.Windows.Forms.Button();
            this.tableLayoutPanel_principal = new System.Windows.Forms.TableLayoutPanel();
            this.panel_cabecera = new System.Windows.Forms.Panel();
            this.label_comentarioMaterial = new System.Windows.Forms.Label();
            this.panel_opciones = new System.Windows.Forms.Panel();
            this.button_crear = new System.Windows.Forms.Button();
            this.panel_cabeceraSeccion1 = new System.Windows.Forms.Panel();
            this.label_modo = new System.Windows.Forms.Label();
            this.panel_cabeceraSeccion2 = new System.Windows.Forms.Panel();
            this.label_seccion2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_borrar = new System.Windows.Forms.Button();
            this.dataGridView_comentarios = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn_texto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn_usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn_fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel_secundario.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel_contenedor.SuspendLayout();
            this.tableLayoutPanel_principal.SuspendLayout();
            this.panel_cabecera.SuspendLayout();
            this.panel_opciones.SuspendLayout();
            this.panel_cabeceraSeccion1.SuspendLayout();
            this.panel_cabeceraSeccion2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_comentarios)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_id
            // 
            this.textBox_id.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_id.Location = new System.Drawing.Point(767, 5);
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.ReadOnly = true;
            this.textBox_id.Size = new System.Drawing.Size(49, 20);
            this.textBox_id.TabIndex = 4;
            this.textBox_id.TabStop = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // label_id
            // 
            this.label_id.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_id.AutoSize = true;
            this.label_id.Location = new System.Drawing.Point(740, 8);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(21, 13);
            this.label_id.TabIndex = 3;
            this.label_id.Text = "ID:";
            // 
            // textBox_usuario
            // 
            this.textBox_usuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_usuario.Location = new System.Drawing.Point(125, 5);
            this.textBox_usuario.Name = "textBox_usuario";
            this.textBox_usuario.Size = new System.Drawing.Size(586, 20);
            this.textBox_usuario.TabIndex = 0;
            this.textBox_usuario.TextChanged += new System.EventHandler(this.formularioModificado);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button_seleccionarUsuario);
            this.panel2.Controls.Add(this.textBox_id);
            this.panel2.Controls.Add(this.label_id);
            this.panel2.Controls.Add(this.textBox_usuario);
            this.panel2.Controls.Add(this.label_autor);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(851, 30);
            this.panel2.TabIndex = 1;
            // 
            // button_seleccionarUsuario
            // 
            this.button_seleccionarUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_seleccionarUsuario.BackColor = System.Drawing.SystemColors.Window;
            this.button_seleccionarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_seleccionarUsuario.FlatAppearance.BorderSize = 0;
            this.button_seleccionarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_seleccionarUsuario.Image = global::cacatUA.Properties.Resources.seleccionar1;
            this.button_seleccionarUsuario.Location = new System.Drawing.Point(690, 6);
            this.button_seleccionarUsuario.Name = "button_seleccionarUsuario";
            this.button_seleccionarUsuario.Size = new System.Drawing.Size(20, 18);
            this.button_seleccionarUsuario.TabIndex = 144;
            this.button_seleccionarUsuario.TabStop = false;
            this.toolTip.SetToolTip(this.button_seleccionarUsuario, "Haz clic para seleccionar un usuario de la lista");
            this.button_seleccionarUsuario.UseVisualStyleBackColor = false;
            this.button_seleccionarUsuario.Click += new System.EventHandler(this.seleccionarUsuario);
            // 
            // label_autor
            // 
            this.label_autor.AutoSize = true;
            this.label_autor.Location = new System.Drawing.Point(16, 8);
            this.label_autor.Name = "label_autor";
            this.label_autor.Size = new System.Drawing.Size(46, 13);
            this.label_autor.TabIndex = 0;
            this.label_autor.Text = "Usuario:";
            // 
            // tableLayoutPanel_secundario
            // 
            this.tableLayoutPanel_secundario.ColumnCount = 1;
            this.tableLayoutPanel_secundario.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_secundario.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel_secundario.Controls.Add(this.panel5, 0, 1);
            this.tableLayoutPanel_secundario.Controls.Add(this.panel6, 0, 2);
            this.tableLayoutPanel_secundario.Controls.Add(this.panel8, 0, 3);
            this.tableLayoutPanel_secundario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_secundario.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_secundario.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_secundario.Name = "tableLayoutPanel_secundario";
            this.tableLayoutPanel_secundario.RowCount = 4;
            this.tableLayoutPanel_secundario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_secundario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel_secundario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_secundario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_secundario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_secundario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_secundario.Size = new System.Drawing.Size(851, 150);
            this.tableLayoutPanel_secundario.TabIndex = 7;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.textBox_texto);
            this.panel5.Controls.Add(this.label_texto);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 30);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(851, 60);
            this.panel5.TabIndex = 4;
            // 
            // textBox_texto
            // 
            this.textBox_texto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_texto.Location = new System.Drawing.Point(125, 6);
            this.textBox_texto.Multiline = true;
            this.textBox_texto.Name = "textBox_texto";
            this.textBox_texto.Size = new System.Drawing.Size(691, 49);
            this.textBox_texto.TabIndex = 0;
            this.textBox_texto.TextChanged += new System.EventHandler(this.formularioModificado);
            // 
            // label_texto
            // 
            this.label_texto.AutoSize = true;
            this.label_texto.Location = new System.Drawing.Point(16, 8);
            this.label_texto.Name = "label_texto";
            this.label_texto.Size = new System.Drawing.Size(37, 13);
            this.label_texto.TabIndex = 0;
            this.label_texto.Text = "Texto:";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dateTimePicker_fecha);
            this.panel6.Controls.Add(this.label_fechaCreacion);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 90);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(851, 30);
            this.panel6.TabIndex = 5;
            // 
            // dateTimePicker_fecha
            // 
            this.dateTimePicker_fecha.CustomFormat = "dddd, dd \'de\' MMMM \'de\' yyyy, H:mm:ss";
            this.dateTimePicker_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_fecha.Location = new System.Drawing.Point(125, 5);
            this.dateTimePicker_fecha.Name = "dateTimePicker_fecha";
            this.dateTimePicker_fecha.ShowUpDown = true;
            this.dateTimePicker_fecha.Size = new System.Drawing.Size(267, 20);
            this.dateTimePicker_fecha.TabIndex = 0;
            this.dateTimePicker_fecha.ValueChanged += new System.EventHandler(this.formularioModificado);
            // 
            // label_fechaCreacion
            // 
            this.label_fechaCreacion.AutoSize = true;
            this.label_fechaCreacion.Location = new System.Drawing.Point(16, 8);
            this.label_fechaCreacion.Name = "label_fechaCreacion";
            this.label_fechaCreacion.Size = new System.Drawing.Size(99, 13);
            this.label_fechaCreacion.TabIndex = 0;
            this.label_fechaCreacion.Text = "Fecha de creación:";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.button_accion2);
            this.panel8.Controls.Add(this.button_accion1);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 120);
            this.panel8.Margin = new System.Windows.Forms.Padding(0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(851, 30);
            this.panel8.TabIndex = 8;
            // 
            // button_accion2
            // 
            this.button_accion2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_accion2.Location = new System.Drawing.Point(694, 3);
            this.button_accion2.Name = "button_accion2";
            this.button_accion2.Size = new System.Drawing.Size(121, 23);
            this.button_accion2.TabIndex = 1;
            this.button_accion2.UseVisualStyleBackColor = true;
            this.button_accion2.Click += new System.EventHandler(this.realizarAccion2);
            // 
            // button_accion1
            // 
            this.button_accion1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_accion1.Location = new System.Drawing.Point(578, 3);
            this.button_accion1.Name = "button_accion1";
            this.button_accion1.Size = new System.Drawing.Size(110, 23);
            this.button_accion1.TabIndex = 0;
            this.button_accion1.UseVisualStyleBackColor = true;
            this.button_accion1.Click += new System.EventHandler(this.realizarAccion1);
            // 
            // panel_contenedor
            // 
            this.panel_contenedor.Controls.Add(this.tableLayoutPanel_secundario);
            this.panel_contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_contenedor.Location = new System.Drawing.Point(0, 110);
            this.panel_contenedor.Margin = new System.Windows.Forms.Padding(0);
            this.panel_contenedor.Name = "panel_contenedor";
            this.panel_contenedor.Size = new System.Drawing.Size(851, 150);
            this.panel_contenedor.TabIndex = 7;
            // 
            // button_editar
            // 
            this.button_editar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_editar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_editar.FlatAppearance.BorderSize = 0;
            this.button_editar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_editar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_editar.Image = global::cacatUA.Properties.Resources.tool;
            this.button_editar.Location = new System.Drawing.Point(810, 5);
            this.button_editar.Name = "button_editar";
            this.button_editar.Size = new System.Drawing.Size(36, 36);
            this.button_editar.TabIndex = 9;
            this.button_editar.Tag = "";
            this.toolTip.SetToolTip(this.button_editar, "Editar comentario seleccionado");
            this.button_editar.UseVisualStyleBackColor = true;
            this.button_editar.Click += new System.EventHandler(this.editarComentario);
            // 
            // tableLayoutPanel_principal
            // 
            this.tableLayoutPanel_principal.ColumnCount = 1;
            this.tableLayoutPanel_principal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_principal.Controls.Add(this.panel_cabecera, 0, 0);
            this.tableLayoutPanel_principal.Controls.Add(this.panel_opciones, 0, 1);
            this.tableLayoutPanel_principal.Controls.Add(this.panel_cabeceraSeccion1, 0, 2);
            this.tableLayoutPanel_principal.Controls.Add(this.panel_cabeceraSeccion2, 0, 4);
            this.tableLayoutPanel_principal.Controls.Add(this.panel1, 0, 5);
            this.tableLayoutPanel_principal.Controls.Add(this.panel_contenedor, 0, 3);
            this.tableLayoutPanel_principal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_principal.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_principal.Name = "tableLayoutPanel_principal";
            this.tableLayoutPanel_principal.RowCount = 6;
            this.tableLayoutPanel_principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel_principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel_principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel_principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel_principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_principal.Size = new System.Drawing.Size(851, 501);
            this.tableLayoutPanel_principal.TabIndex = 2;
            // 
            // panel_cabecera
            // 
            this.panel_cabecera.BackColor = System.Drawing.Color.Blue;
            this.panel_cabecera.Controls.Add(this.label_comentarioMaterial);
            this.panel_cabecera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_cabecera.Location = new System.Drawing.Point(0, 0);
            this.panel_cabecera.Margin = new System.Windows.Forms.Padding(0);
            this.panel_cabecera.Name = "panel_cabecera";
            this.panel_cabecera.Size = new System.Drawing.Size(851, 30);
            this.panel_cabecera.TabIndex = 0;
            // 
            // label_comentarioMaterial
            // 
            this.label_comentarioMaterial.AutoSize = true;
            this.label_comentarioMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_comentarioMaterial.ForeColor = System.Drawing.Color.White;
            this.label_comentarioMaterial.Location = new System.Drawing.Point(11, 7);
            this.label_comentarioMaterial.Name = "label_comentarioMaterial";
            this.label_comentarioMaterial.Size = new System.Drawing.Size(38, 17);
            this.label_comentarioMaterial.TabIndex = 0;
            this.label_comentarioMaterial.Text = "título";
            // 
            // panel_opciones
            // 
            this.panel_opciones.Controls.Add(this.button_crear);
            this.panel_opciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_opciones.Location = new System.Drawing.Point(0, 30);
            this.panel_opciones.Margin = new System.Windows.Forms.Padding(0);
            this.panel_opciones.Name = "panel_opciones";
            this.panel_opciones.Size = new System.Drawing.Size(851, 45);
            this.panel_opciones.TabIndex = 1;
            // 
            // button_crear
            // 
            this.button_crear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_crear.FlatAppearance.BorderSize = 0;
            this.button_crear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_crear.Image = global::cacatUA.Properties.Resources.nuevo;
            this.button_crear.Location = new System.Drawing.Point(3, 2);
            this.button_crear.Name = "button_crear";
            this.button_crear.Size = new System.Drawing.Size(36, 36);
            this.button_crear.TabIndex = 1;
            this.toolTip.SetToolTip(this.button_crear, "Crear un nuevo comentario");
            this.button_crear.UseVisualStyleBackColor = true;
            this.button_crear.Click += new System.EventHandler(this.crearComentario);
            // 
            // panel_cabeceraSeccion1
            // 
            this.panel_cabeceraSeccion1.BackColor = System.Drawing.Color.LightGray;
            this.panel_cabeceraSeccion1.Controls.Add(this.label_modo);
            this.panel_cabeceraSeccion1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_cabeceraSeccion1.Location = new System.Drawing.Point(3, 78);
            this.panel_cabeceraSeccion1.Name = "panel_cabeceraSeccion1";
            this.panel_cabeceraSeccion1.Size = new System.Drawing.Size(845, 29);
            this.panel_cabeceraSeccion1.TabIndex = 2;
            // 
            // label_modo
            // 
            this.label_modo.AutoSize = true;
            this.label_modo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_modo.Location = new System.Drawing.Point(13, 8);
            this.label_modo.Name = "label_modo";
            this.label_modo.Size = new System.Drawing.Size(37, 13);
            this.label_modo.TabIndex = 0;
            this.label_modo.Text = "modo";
            // 
            // panel_cabeceraSeccion2
            // 
            this.panel_cabeceraSeccion2.BackColor = System.Drawing.Color.LightGray;
            this.panel_cabeceraSeccion2.Controls.Add(this.label_seccion2);
            this.panel_cabeceraSeccion2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_cabeceraSeccion2.Location = new System.Drawing.Point(3, 263);
            this.panel_cabeceraSeccion2.Name = "panel_cabeceraSeccion2";
            this.panel_cabeceraSeccion2.Size = new System.Drawing.Size(845, 29);
            this.panel_cabeceraSeccion2.TabIndex = 3;
            // 
            // label_seccion2
            // 
            this.label_seccion2.AutoSize = true;
            this.label_seccion2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_seccion2.Location = new System.Drawing.Point(13, 8);
            this.label_seccion2.Name = "label_seccion2";
            this.label_seccion2.Size = new System.Drawing.Size(145, 13);
            this.label_seccion2.TabIndex = 0;
            this.label_seccion2.Text = "Comentarios del material";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_editar);
            this.panel1.Controls.Add(this.button_borrar);
            this.panel1.Controls.Add(this.dataGridView_comentarios);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 295);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(851, 206);
            this.panel1.TabIndex = 5;
            // 
            // button_borrar
            // 
            this.button_borrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_borrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_borrar.FlatAppearance.BorderSize = 0;
            this.button_borrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_borrar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_borrar.Image = global::cacatUA.Properties.Resources.close;
            this.button_borrar.Location = new System.Drawing.Point(810, 41);
            this.button_borrar.Name = "button_borrar";
            this.button_borrar.Size = new System.Drawing.Size(36, 36);
            this.button_borrar.TabIndex = 10;
            this.button_borrar.Tag = "";
            this.toolTip.SetToolTip(this.button_borrar, "Eliminar comentarios seleccionados");
            this.button_borrar.UseVisualStyleBackColor = true;
            this.button_borrar.Click += new System.EventHandler(this.borrarComentario);
            // 
            // dataGridView_comentarios
            // 
            this.dataGridView_comentarios.AllowUserToAddRows = false;
            this.dataGridView_comentarios.AllowUserToDeleteRows = false;
            this.dataGridView_comentarios.AllowUserToResizeRows = false;
            this.dataGridView_comentarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_comentarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_comentarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_comentarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn_id,
            this.dataGridViewTextBoxColumn_texto,
            this.dataGridViewTextBoxColumn_usuario,
            this.dataGridViewTextBoxColumn_fecha});
            this.dataGridView_comentarios.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_comentarios.Name = "dataGridView_comentarios";
            this.dataGridView_comentarios.ReadOnly = true;
            this.dataGridView_comentarios.RowHeadersVisible = false;
            this.dataGridView_comentarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_comentarios.Size = new System.Drawing.Size(803, 200);
            this.dataGridView_comentarios.TabIndex = 4;
            this.dataGridView_comentarios.DoubleClick += new System.EventHandler(this.editarComentario);
            // 
            // dataGridViewTextBoxColumn_id
            // 
            this.dataGridViewTextBoxColumn_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn_id.FillWeight = 152.2843F;
            this.dataGridViewTextBoxColumn_id.HeaderText = "ID";
            this.dataGridViewTextBoxColumn_id.Name = "dataGridViewTextBoxColumn_id";
            this.dataGridViewTextBoxColumn_id.ReadOnly = true;
            this.dataGridViewTextBoxColumn_id.Width = 43;
            // 
            // dataGridViewTextBoxColumn_texto
            // 
            this.dataGridViewTextBoxColumn_texto.FillWeight = 89.54314F;
            this.dataGridViewTextBoxColumn_texto.HeaderText = "Texto";
            this.dataGridViewTextBoxColumn_texto.Name = "dataGridViewTextBoxColumn_texto";
            this.dataGridViewTextBoxColumn_texto.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn_usuario
            // 
            this.dataGridViewTextBoxColumn_usuario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn_usuario.FillWeight = 89.54314F;
            this.dataGridViewTextBoxColumn_usuario.HeaderText = "Autor";
            this.dataGridViewTextBoxColumn_usuario.Name = "dataGridViewTextBoxColumn_usuario";
            this.dataGridViewTextBoxColumn_usuario.ReadOnly = true;
            this.dataGridViewTextBoxColumn_usuario.Width = 57;
            // 
            // dataGridViewTextBoxColumn_fecha
            // 
            this.dataGridViewTextBoxColumn_fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn_fecha.FillWeight = 89.54314F;
            this.dataGridViewTextBoxColumn_fecha.HeaderText = "Fecha de creación";
            this.dataGridViewTextBoxColumn_fecha.Name = "dataGridViewTextBoxColumn_fecha";
            this.dataGridViewTextBoxColumn_fecha.ReadOnly = true;
            this.dataGridViewTextBoxColumn_fecha.Width = 140;
            // 
            // FormMaterialesComentarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel_principal);
            this.Name = "FormMaterialesComentarios";
            this.Size = new System.Drawing.Size(851, 501);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel_secundario.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel_contenedor.ResumeLayout(false);
            this.tableLayoutPanel_principal.ResumeLayout(false);
            this.panel_cabecera.ResumeLayout(false);
            this.panel_cabecera.PerformLayout();
            this.panel_opciones.ResumeLayout(false);
            this.panel_cabeceraSeccion1.ResumeLayout(false);
            this.panel_cabeceraSeccion1.PerformLayout();
            this.panel_cabeceraSeccion2.ResumeLayout(false);
            this.panel_cabeceraSeccion2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_comentarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_id;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_principal;
        private System.Windows.Forms.Panel panel_cabecera;
        private System.Windows.Forms.Label label_comentarioMaterial;
        private System.Windows.Forms.Panel panel_opciones;
        private System.Windows.Forms.Button button_crear;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel panel_cabeceraSeccion1;
        private System.Windows.Forms.Label label_modo;
        private System.Windows.Forms.Panel panel_cabeceraSeccion2;
        private System.Windows.Forms.Label label_seccion2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_editar;
        private System.Windows.Forms.Button button_borrar;
        private System.Windows.Forms.DataGridView dataGridView_comentarios;
        private System.Windows.Forms.Panel panel_contenedor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_secundario;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_seleccionarUsuario;
        private System.Windows.Forms.Label label_id;
        private System.Windows.Forms.TextBox textBox_usuario;
        private System.Windows.Forms.Label label_autor;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox textBox_texto;
        private System.Windows.Forms.Label label_texto;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DateTimePicker dateTimePicker_fecha;
        private System.Windows.Forms.Label label_fechaCreacion;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button button_accion2;
        private System.Windows.Forms.Button button_accion1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn_texto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn_usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn_fecha;
    }
}
