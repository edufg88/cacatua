namespace cacatUA
{
    partial class FormUsuarioImagenes
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
            this.panel_contenedor = new System.Windows.Forms.Panel();
            this.tableLayoutPanel_secundario = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateTimePicker_fecha = new System.Windows.Forms.DateTimePicker();
            this.label_fechaCreacion = new System.Windows.Forms.Label();
            this.textBox_titulo = new System.Windows.Forms.TextBox();
            this.label_titulo = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label_descripcion = new System.Windows.Forms.Label();
            this.textBox_descripcion = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.textBox_archivo = new System.Windows.Forms.TextBox();
            this.label_archivo = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.button_descartarCambios = new System.Windows.Forms.Button();
            this.button_guardarCambios = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_editarImagen = new System.Windows.Forms.Button();
            this.button_borrarImagen = new System.Windows.Forms.Button();
            this.dataGridView_imagenes = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.archivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_cabeceraSeccion2 = new System.Windows.Forms.Panel();
            this.label_seccion2 = new System.Windows.Forms.Label();
            this.panel_cabeceraSeccion1 = new System.Windows.Forms.Panel();
            this.label_seccion1 = new System.Windows.Forms.Label();
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.label_id = new System.Windows.Forms.Label();
            this.panel_cabecera = new System.Windows.Forms.Panel();
            this.label_imagenes = new System.Windows.Forms.Label();
            this.tableLayoutPanel_principal = new System.Windows.Forms.TableLayoutPanel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel_contenedor.SuspendLayout();
            this.tableLayoutPanel_secundario.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_imagenes)).BeginInit();
            this.panel_cabeceraSeccion2.SuspendLayout();
            this.panel_cabeceraSeccion1.SuspendLayout();
            this.panel_cabecera.SuspendLayout();
            this.tableLayoutPanel_principal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_contenedor
            // 
            this.panel_contenedor.Controls.Add(this.tableLayoutPanel_secundario);
            this.panel_contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_contenedor.Location = new System.Drawing.Point(0, 65);
            this.panel_contenedor.Margin = new System.Windows.Forms.Padding(0);
            this.panel_contenedor.Name = "panel_contenedor";
            this.panel_contenedor.Size = new System.Drawing.Size(732, 133);
            this.panel_contenedor.TabIndex = 7;
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
            this.tableLayoutPanel_secundario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel_secundario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel_secundario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel_secundario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_secundario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_secundario.Size = new System.Drawing.Size(732, 133);
            this.tableLayoutPanel_secundario.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dateTimePicker_fecha);
            this.panel2.Controls.Add(this.label_fechaCreacion);
            this.panel2.Controls.Add(this.textBox_titulo);
            this.panel2.Controls.Add(this.label_titulo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(732, 30);
            this.panel2.TabIndex = 1;
            // 
            // dateTimePicker_fecha
            // 
            this.dateTimePicker_fecha.CustomFormat = "dddd, dd \'de\' MMMM \'de\' yyyy, H:mm:ss";
            this.dateTimePicker_fecha.Enabled = false;
            this.dateTimePicker_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_fecha.Location = new System.Drawing.Point(446, 5);
            this.dateTimePicker_fecha.Name = "dateTimePicker_fecha";
            this.dateTimePicker_fecha.ShowUpDown = true;
            this.dateTimePicker_fecha.Size = new System.Drawing.Size(250, 20);
            this.dateTimePicker_fecha.TabIndex = 2;
            this.toolTip1.SetToolTip(this.dateTimePicker_fecha, "Fecha de creación de la imagen");
            // 
            // label_fechaCreacion
            // 
            this.label_fechaCreacion.AutoSize = true;
            this.label_fechaCreacion.Location = new System.Drawing.Point(351, 8);
            this.label_fechaCreacion.Name = "label_fechaCreacion";
            this.label_fechaCreacion.Size = new System.Drawing.Size(40, 13);
            this.label_fechaCreacion.TabIndex = 1;
            this.label_fechaCreacion.Text = "Fecha:";
            // 
            // textBox_titulo
            // 
            this.textBox_titulo.Location = new System.Drawing.Point(125, 5);
            this.textBox_titulo.Name = "textBox_titulo";
            this.textBox_titulo.Size = new System.Drawing.Size(144, 20);
            this.textBox_titulo.TabIndex = 0;
            this.toolTip1.SetToolTip(this.textBox_titulo, "Título de la imagen");
            // 
            // label_titulo
            // 
            this.label_titulo.AutoSize = true;
            this.label_titulo.Location = new System.Drawing.Point(16, 8);
            this.label_titulo.Name = "label_titulo";
            this.label_titulo.Size = new System.Drawing.Size(38, 13);
            this.label_titulo.TabIndex = 0;
            this.label_titulo.Text = "Título:";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label_descripcion);
            this.panel5.Controls.Add(this.textBox_descripcion);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 30);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(732, 37);
            this.panel5.TabIndex = 4;
            // 
            // label_descripcion
            // 
            this.label_descripcion.AutoSize = true;
            this.label_descripcion.Location = new System.Drawing.Point(16, 11);
            this.label_descripcion.Name = "label_descripcion";
            this.label_descripcion.Size = new System.Drawing.Size(66, 13);
            this.label_descripcion.TabIndex = 2;
            this.label_descripcion.Text = "Descripción:";
            // 
            // textBox_descripcion
            // 
            this.textBox_descripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_descripcion.Location = new System.Drawing.Point(125, 8);
            this.textBox_descripcion.Name = "textBox_descripcion";
            this.textBox_descripcion.Size = new System.Drawing.Size(571, 20);
            this.textBox_descripcion.TabIndex = 1;
            this.toolTip1.SetToolTip(this.textBox_descripcion, "Descripción de la imagen");
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.textBox_archivo);
            this.panel6.Controls.Add(this.label_archivo);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 67);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(732, 32);
            this.panel6.TabIndex = 5;
            // 
            // textBox_archivo
            // 
            this.textBox_archivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_archivo.Location = new System.Drawing.Point(125, 5);
            this.textBox_archivo.Name = "textBox_archivo";
            this.textBox_archivo.ReadOnly = true;
            this.textBox_archivo.Size = new System.Drawing.Size(571, 20);
            this.textBox_archivo.TabIndex = 4;
            this.toolTip1.SetToolTip(this.textBox_archivo, "Ruta del fichero imagen");
            // 
            // label_archivo
            // 
            this.label_archivo.AutoSize = true;
            this.label_archivo.Location = new System.Drawing.Point(16, 12);
            this.label_archivo.Name = "label_archivo";
            this.label_archivo.Size = new System.Drawing.Size(46, 13);
            this.label_archivo.TabIndex = 3;
            this.label_archivo.Text = "Archivo:";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.button_descartarCambios);
            this.panel8.Controls.Add(this.button_guardarCambios);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 99);
            this.panel8.Margin = new System.Windows.Forms.Padding(0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(732, 41);
            this.panel8.TabIndex = 8;
            // 
            // button_descartarCambios
            // 
            this.button_descartarCambios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_descartarCambios.Location = new System.Drawing.Point(575, 5);
            this.button_descartarCambios.Name = "button_descartarCambios";
            this.button_descartarCambios.Size = new System.Drawing.Size(121, 23);
            this.button_descartarCambios.TabIndex = 1;
            this.button_descartarCambios.Text = "Descartar cambios";
            this.button_descartarCambios.UseVisualStyleBackColor = true;
            this.button_descartarCambios.Click += new System.EventHandler(this.button_descartarCambios_Click);
            // 
            // button_guardarCambios
            // 
            this.button_guardarCambios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_guardarCambios.Location = new System.Drawing.Point(459, 5);
            this.button_guardarCambios.Name = "button_guardarCambios";
            this.button_guardarCambios.Size = new System.Drawing.Size(110, 23);
            this.button_guardarCambios.TabIndex = 0;
            this.button_guardarCambios.Text = "Guardar cambios";
            this.button_guardarCambios.UseVisualStyleBackColor = true;
            this.button_guardarCambios.Click += new System.EventHandler(this.button_guardarCambios_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_editarImagen);
            this.panel1.Controls.Add(this.button_borrarImagen);
            this.panel1.Controls.Add(this.dataGridView_imagenes);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 233);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(732, 122);
            this.panel1.TabIndex = 5;
            // 
            // button_editarImagen
            // 
            this.button_editarImagen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_editarImagen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_editarImagen.FlatAppearance.BorderSize = 0;
            this.button_editarImagen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_editarImagen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_editarImagen.Image = global::cacatUA.Properties.Resources.tool;
            this.button_editarImagen.Location = new System.Drawing.Point(691, 5);
            this.button_editarImagen.Name = "button_editarImagen";
            this.button_editarImagen.Size = new System.Drawing.Size(36, 36);
            this.button_editarImagen.TabIndex = 9;
            this.button_editarImagen.Tag = "";
            this.toolTip1.SetToolTip(this.button_editarImagen, "Editar la imagen seleccionada");
            this.button_editarImagen.UseVisualStyleBackColor = true;
            this.button_editarImagen.Click += new System.EventHandler(this.button_editarImagen_Click);
            // 
            // button_borrarImagen
            // 
            this.button_borrarImagen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_borrarImagen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_borrarImagen.FlatAppearance.BorderSize = 0;
            this.button_borrarImagen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_borrarImagen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_borrarImagen.Image = global::cacatUA.Properties.Resources.close;
            this.button_borrarImagen.Location = new System.Drawing.Point(691, 41);
            this.button_borrarImagen.Name = "button_borrarImagen";
            this.button_borrarImagen.Size = new System.Drawing.Size(36, 36);
            this.button_borrarImagen.TabIndex = 10;
            this.button_borrarImagen.Tag = "";
            this.toolTip1.SetToolTip(this.button_borrarImagen, "Borrar la imagen seleccionada");
            this.button_borrarImagen.UseVisualStyleBackColor = true;
            this.button_borrarImagen.Click += new System.EventHandler(this.button_borrarImagen_Click);
            // 
            // dataGridView_imagenes
            // 
            this.dataGridView_imagenes.AllowUserToAddRows = false;
            this.dataGridView_imagenes.AllowUserToDeleteRows = false;
            this.dataGridView_imagenes.AllowUserToResizeRows = false;
            this.dataGridView_imagenes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_imagenes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_imagenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_imagenes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.usuario,
            this.titulo,
            this.descripcion,
            this.fecha,
            this.archivo});
            this.dataGridView_imagenes.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_imagenes.Name = "dataGridView_imagenes";
            this.dataGridView_imagenes.ReadOnly = true;
            this.dataGridView_imagenes.RowHeadersVisible = false;
            this.dataGridView_imagenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_imagenes.Size = new System.Drawing.Size(684, 150);
            this.dataGridView_imagenes.TabIndex = 4;
            this.dataGridView_imagenes.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_imagenes_CellMouseDoubleClick);
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.id.FillWeight = 152.2843F;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 43;
            // 
            // usuario
            // 
            this.usuario.HeaderText = "Usuario";
            this.usuario.Name = "usuario";
            this.usuario.ReadOnly = true;
            // 
            // titulo
            // 
            this.titulo.HeaderText = "Titulo";
            this.titulo.Name = "titulo";
            this.titulo.ReadOnly = true;
            // 
            // descripcion
            // 
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // fecha
            // 
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            // 
            // archivo
            // 
            this.archivo.HeaderText = "Archivo";
            this.archivo.Name = "archivo";
            this.archivo.ReadOnly = true;
            // 
            // panel_cabeceraSeccion2
            // 
            this.panel_cabeceraSeccion2.BackColor = System.Drawing.Color.LightGray;
            this.panel_cabeceraSeccion2.Controls.Add(this.label_seccion2);
            this.panel_cabeceraSeccion2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_cabeceraSeccion2.Location = new System.Drawing.Point(3, 201);
            this.panel_cabeceraSeccion2.Name = "panel_cabeceraSeccion2";
            this.panel_cabeceraSeccion2.Size = new System.Drawing.Size(726, 29);
            this.panel_cabeceraSeccion2.TabIndex = 3;
            // 
            // label_seccion2
            // 
            this.label_seccion2.AutoSize = true;
            this.label_seccion2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_seccion2.Location = new System.Drawing.Point(13, 8);
            this.label_seccion2.Name = "label_seccion2";
            this.label_seccion2.Size = new System.Drawing.Size(109, 13);
            this.label_seccion2.TabIndex = 0;
            this.label_seccion2.Text = "Firmas del usuario";
            // 
            // panel_cabeceraSeccion1
            // 
            this.panel_cabeceraSeccion1.BackColor = System.Drawing.Color.LightGray;
            this.panel_cabeceraSeccion1.Controls.Add(this.label_seccion1);
            this.panel_cabeceraSeccion1.Controls.Add(this.textBox_id);
            this.panel_cabeceraSeccion1.Controls.Add(this.label_id);
            this.panel_cabeceraSeccion1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_cabeceraSeccion1.Location = new System.Drawing.Point(3, 33);
            this.panel_cabeceraSeccion1.Name = "panel_cabeceraSeccion1";
            this.panel_cabeceraSeccion1.Size = new System.Drawing.Size(726, 29);
            this.panel_cabeceraSeccion1.TabIndex = 2;
            // 
            // label_seccion1
            // 
            this.label_seccion1.AutoSize = true;
            this.label_seccion1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_seccion1.Location = new System.Drawing.Point(13, 8);
            this.label_seccion1.Name = "label_seccion1";
            this.label_seccion1.Size = new System.Drawing.Size(149, 13);
            this.label_seccion1.TabIndex = 0;
            this.label_seccion1.Text = "Información de la imagen";
            // 
            // textBox_id
            // 
            this.textBox_id.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_id.Location = new System.Drawing.Point(664, 6);
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.ReadOnly = true;
            this.textBox_id.Size = new System.Drawing.Size(49, 20);
            this.textBox_id.TabIndex = 4;
            this.textBox_id.TabStop = false;
            // 
            // label_id
            // 
            this.label_id.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_id.AutoSize = true;
            this.label_id.Location = new System.Drawing.Point(637, 9);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(21, 13);
            this.label_id.TabIndex = 3;
            this.label_id.Text = "ID:";
            // 
            // panel_cabecera
            // 
            this.panel_cabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panel_cabecera.Controls.Add(this.label_imagenes);
            this.panel_cabecera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_cabecera.Location = new System.Drawing.Point(0, 0);
            this.panel_cabecera.Margin = new System.Windows.Forms.Padding(0);
            this.panel_cabecera.Name = "panel_cabecera";
            this.panel_cabecera.Size = new System.Drawing.Size(732, 30);
            this.panel_cabecera.TabIndex = 0;
            // 
            // label_imagenes
            // 
            this.label_imagenes.AutoSize = true;
            this.label_imagenes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_imagenes.ForeColor = System.Drawing.Color.White;
            this.label_imagenes.Location = new System.Drawing.Point(11, 7);
            this.label_imagenes.Name = "label_imagenes";
            this.label_imagenes.Size = new System.Drawing.Size(143, 17);
            this.label_imagenes.TabIndex = 0;
            this.label_imagenes.Text = "Imágenes del usuario";
            // 
            // tableLayoutPanel_principal
            // 
            this.tableLayoutPanel_principal.ColumnCount = 1;
            this.tableLayoutPanel_principal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_principal.Controls.Add(this.panel_cabecera, 0, 0);
            this.tableLayoutPanel_principal.Controls.Add(this.panel_cabeceraSeccion1, 0, 1);
            this.tableLayoutPanel_principal.Controls.Add(this.panel_cabeceraSeccion2, 0, 3);
            this.tableLayoutPanel_principal.Controls.Add(this.panel1, 0, 4);
            this.tableLayoutPanel_principal.Controls.Add(this.panel_contenedor, 0, 2);
            this.tableLayoutPanel_principal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_principal.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_principal.Name = "tableLayoutPanel_principal";
            this.tableLayoutPanel_principal.RowCount = 5;
            this.tableLayoutPanel_principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel_principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel_principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel_principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_principal.Size = new System.Drawing.Size(732, 355);
            this.tableLayoutPanel_principal.TabIndex = 3;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FormUsuarioImagenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel_principal);
            this.Name = "FormUsuarioImagenes";
            this.Size = new System.Drawing.Size(732, 355);
            this.Load += new System.EventHandler(this.FormUsuarioImagenes_Load);
            this.panel_contenedor.ResumeLayout(false);
            this.tableLayoutPanel_secundario.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_imagenes)).EndInit();
            this.panel_cabeceraSeccion2.ResumeLayout(false);
            this.panel_cabeceraSeccion2.PerformLayout();
            this.panel_cabeceraSeccion1.ResumeLayout(false);
            this.panel_cabeceraSeccion1.PerformLayout();
            this.panel_cabecera.ResumeLayout(false);
            this.panel_cabecera.PerformLayout();
            this.tableLayoutPanel_principal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_contenedor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_secundario;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label_fechaCreacion;
        private System.Windows.Forms.TextBox textBox_titulo;
        private System.Windows.Forms.Label label_titulo;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label_descripcion;
        private System.Windows.Forms.TextBox textBox_descripcion;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox textBox_archivo;
        private System.Windows.Forms.Label label_archivo;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button button_descartarCambios;
        private System.Windows.Forms.Button button_guardarCambios;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_editarImagen;
        private System.Windows.Forms.Button button_borrarImagen;
        private System.Windows.Forms.DataGridView dataGridView_imagenes;
        private System.Windows.Forms.Panel panel_cabeceraSeccion2;
        private System.Windows.Forms.Label label_seccion2;
        private System.Windows.Forms.Panel panel_cabeceraSeccion1;
        private System.Windows.Forms.Label label_seccion1;
        private System.Windows.Forms.TextBox textBox_id;
        private System.Windows.Forms.Label label_id;
        private System.Windows.Forms.Panel panel_cabecera;
        private System.Windows.Forms.Label label_imagenes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_principal;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn titulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn archivo;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_fecha;
        private System.Windows.Forms.ToolTip toolTip1;

    }
}
