namespace cacatUA
{
    partial class FormForoRespuestas
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button_seccionCrear = new System.Windows.Forms.Button();
            this.button_editarRespuesta = new System.Windows.Forms.Button();
            this.button_borrarRespuesta = new System.Windows.Forms.Button();
            this.button_seleccionarUsuario = new System.Windows.Forms.Button();
            this.tableLayoutPanel_principal = new System.Windows.Forms.TableLayoutPanel();
            this.panel_cabecera = new System.Windows.Forms.Panel();
            this.label_foro = new System.Windows.Forms.Label();
            this.panel_opciones = new System.Windows.Forms.Panel();
            this.panel_cabeceraSeccion1 = new System.Windows.Forms.Panel();
            this.label_seccion1 = new System.Windows.Forms.Label();
            this.panel_cabeceraSeccion2 = new System.Windows.Forms.Panel();
            this.label_seccion2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView_resultados = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.autor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechacreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_contenedor = new System.Windows.Forms.Panel();
            this.tableLayoutPanel_secundario = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.label_id = new System.Windows.Forms.Label();
            this.textBox_autor = new System.Windows.Forms.TextBox();
            this.label_autor = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textBox_texto = new System.Windows.Forms.TextBox();
            this.label_texto = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dateTimePicker_fecha = new System.Windows.Forms.DateTimePicker();
            this.label_fechaCreacion = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.button_descartarCambios = new System.Windows.Forms.Button();
            this.button_guardarCambios = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tableLayoutPanel_principal.SuspendLayout();
            this.panel_cabecera.SuspendLayout();
            this.panel_opciones.SuspendLayout();
            this.panel_cabeceraSeccion1.SuspendLayout();
            this.panel_cabeceraSeccion2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_resultados)).BeginInit();
            this.panel_contenedor.SuspendLayout();
            this.tableLayoutPanel_secundario.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // button_seccionCrear
            // 
            this.button_seccionCrear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_seccionCrear.FlatAppearance.BorderSize = 0;
            this.button_seccionCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_seccionCrear.Image = global::cacatUA.Properties.Resources.nuevo;
            this.button_seccionCrear.Location = new System.Drawing.Point(3, 2);
            this.button_seccionCrear.Name = "button_seccionCrear";
            this.button_seccionCrear.Size = new System.Drawing.Size(36, 36);
            this.button_seccionCrear.TabIndex = 1;
            this.toolTip1.SetToolTip(this.button_seccionCrear, "Crear un nuevo hilo");
            this.button_seccionCrear.UseVisualStyleBackColor = true;
            this.button_seccionCrear.Click += new System.EventHandler(this.button_seccionCrear_Click);
            // 
            // button_editarRespuesta
            // 
            this.button_editarRespuesta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_editarRespuesta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_editarRespuesta.FlatAppearance.BorderSize = 0;
            this.button_editarRespuesta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_editarRespuesta.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_editarRespuesta.Image = global::cacatUA.Properties.Resources.tool;
            this.button_editarRespuesta.Location = new System.Drawing.Point(798, 5);
            this.button_editarRespuesta.Name = "button_editarRespuesta";
            this.button_editarRespuesta.Size = new System.Drawing.Size(36, 36);
            this.button_editarRespuesta.TabIndex = 9;
            this.button_editarRespuesta.Tag = "";
            this.toolTip1.SetToolTip(this.button_editarRespuesta, "Editar respuesta seleccionada");
            this.button_editarRespuesta.UseVisualStyleBackColor = true;
            this.button_editarRespuesta.Click += new System.EventHandler(this.button_editarRespuesta_Click);
            // 
            // button_borrarRespuesta
            // 
            this.button_borrarRespuesta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_borrarRespuesta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_borrarRespuesta.FlatAppearance.BorderSize = 0;
            this.button_borrarRespuesta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_borrarRespuesta.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_borrarRespuesta.Image = global::cacatUA.Properties.Resources.close;
            this.button_borrarRespuesta.Location = new System.Drawing.Point(798, 41);
            this.button_borrarRespuesta.Name = "button_borrarRespuesta";
            this.button_borrarRespuesta.Size = new System.Drawing.Size(36, 36);
            this.button_borrarRespuesta.TabIndex = 10;
            this.button_borrarRespuesta.Tag = "";
            this.toolTip1.SetToolTip(this.button_borrarRespuesta, "Eliminar respuestas seleccionadas");
            this.button_borrarRespuesta.UseVisualStyleBackColor = true;
            this.button_borrarRespuesta.Click += new System.EventHandler(this.button_borrarRespuesta_Click);
            // 
            // button_seleccionarUsuario
            // 
            this.button_seleccionarUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_seleccionarUsuario.BackColor = System.Drawing.SystemColors.Window;
            this.button_seleccionarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_seleccionarUsuario.FlatAppearance.BorderSize = 0;
            this.button_seleccionarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_seleccionarUsuario.Image = global::cacatUA.Properties.Resources.seleccionar1;
            this.button_seleccionarUsuario.Location = new System.Drawing.Point(678, 6);
            this.button_seleccionarUsuario.Name = "button_seleccionarUsuario";
            this.button_seleccionarUsuario.Size = new System.Drawing.Size(20, 18);
            this.button_seleccionarUsuario.TabIndex = 144;
            this.button_seleccionarUsuario.TabStop = false;
            this.toolTip1.SetToolTip(this.button_seleccionarUsuario, "Haz clic para seleccionar un usuario de la lista");
            this.button_seleccionarUsuario.UseVisualStyleBackColor = false;
            this.button_seleccionarUsuario.Click += new System.EventHandler(this.button_seleccionarUsuario_Click);
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
            this.tableLayoutPanel_principal.Size = new System.Drawing.Size(839, 522);
            this.tableLayoutPanel_principal.TabIndex = 1;
            // 
            // panel_cabecera
            // 
            this.panel_cabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(110)))), ((int)(((byte)(0)))));
            this.panel_cabecera.Controls.Add(this.label_foro);
            this.panel_cabecera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_cabecera.Location = new System.Drawing.Point(0, 0);
            this.panel_cabecera.Margin = new System.Windows.Forms.Padding(0);
            this.panel_cabecera.Name = "panel_cabecera";
            this.panel_cabecera.Size = new System.Drawing.Size(839, 30);
            this.panel_cabecera.TabIndex = 0;
            // 
            // label_foro
            // 
            this.label_foro.AutoSize = true;
            this.label_foro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_foro.ForeColor = System.Drawing.Color.White;
            this.label_foro.Location = new System.Drawing.Point(11, 7);
            this.label_foro.Name = "label_foro";
            this.label_foro.Size = new System.Drawing.Size(132, 17);
            this.label_foro.TabIndex = 0;
            this.label_foro.Text = "Respuestas del hilo";
            // 
            // panel_opciones
            // 
            this.panel_opciones.Controls.Add(this.button_seccionCrear);
            this.panel_opciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_opciones.Location = new System.Drawing.Point(0, 30);
            this.panel_opciones.Margin = new System.Windows.Forms.Padding(0);
            this.panel_opciones.Name = "panel_opciones";
            this.panel_opciones.Size = new System.Drawing.Size(839, 45);
            this.panel_opciones.TabIndex = 1;
            // 
            // panel_cabeceraSeccion1
            // 
            this.panel_cabeceraSeccion1.BackColor = System.Drawing.Color.LightGray;
            this.panel_cabeceraSeccion1.Controls.Add(this.label_seccion1);
            this.panel_cabeceraSeccion1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_cabeceraSeccion1.Location = new System.Drawing.Point(3, 78);
            this.panel_cabeceraSeccion1.Name = "panel_cabeceraSeccion1";
            this.panel_cabeceraSeccion1.Size = new System.Drawing.Size(833, 29);
            this.panel_cabeceraSeccion1.TabIndex = 2;
            // 
            // label_seccion1
            // 
            this.label_seccion1.AutoSize = true;
            this.label_seccion1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_seccion1.Location = new System.Drawing.Point(13, 8);
            this.label_seccion1.Name = "label_seccion1";
            this.label_seccion1.Size = new System.Drawing.Size(160, 13);
            this.label_seccion1.TabIndex = 0;
            this.label_seccion1.Text = "Crear una nueva respuesta";
            // 
            // panel_cabeceraSeccion2
            // 
            this.panel_cabeceraSeccion2.BackColor = System.Drawing.Color.LightGray;
            this.panel_cabeceraSeccion2.Controls.Add(this.label_seccion2);
            this.panel_cabeceraSeccion2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_cabeceraSeccion2.Location = new System.Drawing.Point(3, 263);
            this.panel_cabeceraSeccion2.Name = "panel_cabeceraSeccion2";
            this.panel_cabeceraSeccion2.Size = new System.Drawing.Size(833, 29);
            this.panel_cabeceraSeccion2.TabIndex = 3;
            // 
            // label_seccion2
            // 
            this.label_seccion2.AutoSize = true;
            this.label_seccion2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_seccion2.Location = new System.Drawing.Point(13, 8);
            this.label_seccion2.Name = "label_seccion2";
            this.label_seccion2.Size = new System.Drawing.Size(118, 13);
            this.label_seccion2.TabIndex = 0;
            this.label_seccion2.Text = "Respuestas del hilo";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_editarRespuesta);
            this.panel1.Controls.Add(this.button_borrarRespuesta);
            this.panel1.Controls.Add(this.dataGridView_resultados);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 295);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(839, 227);
            this.panel1.TabIndex = 5;
            // 
            // dataGridView_resultados
            // 
            this.dataGridView_resultados.AllowUserToAddRows = false;
            this.dataGridView_resultados.AllowUserToDeleteRows = false;
            this.dataGridView_resultados.AllowUserToResizeRows = false;
            this.dataGridView_resultados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_resultados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_resultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_resultados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.descripcion,
            this.autor,
            this.fechacreacion});
            this.dataGridView_resultados.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_resultados.Name = "dataGridView_resultados";
            this.dataGridView_resultados.ReadOnly = true;
            this.dataGridView_resultados.RowHeadersVisible = false;
            this.dataGridView_resultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_resultados.Size = new System.Drawing.Size(791, 221);
            this.dataGridView_resultados.TabIndex = 4;
            this.dataGridView_resultados.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_resultados_CellMouseDoubleClick);
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.id.FillWeight = 152.2843F;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 41;
            // 
            // descripcion
            // 
            this.descripcion.FillWeight = 89.54314F;
            this.descripcion.HeaderText = "Texto";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // autor
            // 
            this.autor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.autor.FillWeight = 89.54314F;
            this.autor.HeaderText = "Autor";
            this.autor.Name = "autor";
            this.autor.ReadOnly = true;
            this.autor.Width = 55;
            // 
            // fechacreacion
            // 
            this.fechacreacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fechacreacion.FillWeight = 89.54314F;
            this.fechacreacion.HeaderText = "Fecha de creación";
            this.fechacreacion.Name = "fechacreacion";
            this.fechacreacion.ReadOnly = true;
            this.fechacreacion.Width = 109;
            // 
            // panel_contenedor
            // 
            this.panel_contenedor.Controls.Add(this.tableLayoutPanel_secundario);
            this.panel_contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_contenedor.Location = new System.Drawing.Point(0, 110);
            this.panel_contenedor.Margin = new System.Windows.Forms.Padding(0);
            this.panel_contenedor.Name = "panel_contenedor";
            this.panel_contenedor.Size = new System.Drawing.Size(839, 150);
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
            this.tableLayoutPanel_secundario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel_secundario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_secundario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_secundario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_secundario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_secundario.Size = new System.Drawing.Size(839, 150);
            this.tableLayoutPanel_secundario.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button_seleccionarUsuario);
            this.panel2.Controls.Add(this.textBox_id);
            this.panel2.Controls.Add(this.label_id);
            this.panel2.Controls.Add(this.textBox_autor);
            this.panel2.Controls.Add(this.label_autor);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(839, 30);
            this.panel2.TabIndex = 1;
            // 
            // textBox_id
            // 
            this.textBox_id.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_id.Location = new System.Drawing.Point(755, 5);
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
            this.label_id.Location = new System.Drawing.Point(728, 8);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(21, 13);
            this.label_id.TabIndex = 3;
            this.label_id.Text = "ID:";
            // 
            // textBox_autor
            // 
            this.textBox_autor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_autor.Location = new System.Drawing.Point(125, 5);
            this.textBox_autor.Name = "textBox_autor";
            this.textBox_autor.Size = new System.Drawing.Size(574, 20);
            this.textBox_autor.TabIndex = 0;
            this.textBox_autor.TextChanged += new System.EventHandler(this.formulario_Modificado);
            // 
            // label_autor
            // 
            this.label_autor.AutoSize = true;
            this.label_autor.Location = new System.Drawing.Point(16, 8);
            this.label_autor.Name = "label_autor";
            this.label_autor.Size = new System.Drawing.Size(35, 13);
            this.label_autor.TabIndex = 0;
            this.label_autor.Text = "Autor:";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.textBox_texto);
            this.panel5.Controls.Add(this.label_texto);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 30);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(839, 60);
            this.panel5.TabIndex = 4;
            // 
            // textBox_texto
            // 
            this.textBox_texto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_texto.Location = new System.Drawing.Point(125, 6);
            this.textBox_texto.Multiline = true;
            this.textBox_texto.Name = "textBox_texto";
            this.textBox_texto.Size = new System.Drawing.Size(679, 49);
            this.textBox_texto.TabIndex = 0;
            this.textBox_texto.TextChanged += new System.EventHandler(this.formulario_Modificado);
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
            this.panel6.Size = new System.Drawing.Size(839, 30);
            this.panel6.TabIndex = 5;
            // 
            // dateTimePicker_fecha
            // 
            this.dateTimePicker_fecha.CustomFormat = "dddd, dd \'de\' MMMM \'de\' yyyy, H:mm:ss";
            this.dateTimePicker_fecha.Enabled = false;
            this.dateTimePicker_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_fecha.Location = new System.Drawing.Point(125, 5);
            this.dateTimePicker_fecha.Name = "dateTimePicker_fecha";
            this.dateTimePicker_fecha.ShowUpDown = true;
            this.dateTimePicker_fecha.Size = new System.Drawing.Size(250, 20);
            this.dateTimePicker_fecha.TabIndex = 0;
            this.dateTimePicker_fecha.ValueChanged += new System.EventHandler(this.formulario_Modificado);
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
            this.panel8.Controls.Add(this.button_descartarCambios);
            this.panel8.Controls.Add(this.button_guardarCambios);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 120);
            this.panel8.Margin = new System.Windows.Forms.Padding(0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(839, 30);
            this.panel8.TabIndex = 8;
            // 
            // button_descartarCambios
            // 
            this.button_descartarCambios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_descartarCambios.Location = new System.Drawing.Point(682, 3);
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
            this.button_guardarCambios.Location = new System.Drawing.Point(566, 3);
            this.button_guardarCambios.Name = "button_guardarCambios";
            this.button_guardarCambios.Size = new System.Drawing.Size(110, 23);
            this.button_guardarCambios.TabIndex = 0;
            this.button_guardarCambios.Text = "Guardar cambios";
            this.button_guardarCambios.UseVisualStyleBackColor = true;
            this.button_guardarCambios.Click += new System.EventHandler(this.button_guardarCambios_Click);
            // 
            // FormForoRespuestas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel_principal);
            this.Name = "FormForoRespuestas";
            this.Size = new System.Drawing.Size(839, 522);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tableLayoutPanel_principal.ResumeLayout(false);
            this.panel_cabecera.ResumeLayout(false);
            this.panel_cabecera.PerformLayout();
            this.panel_opciones.ResumeLayout(false);
            this.panel_cabeceraSeccion1.ResumeLayout(false);
            this.panel_cabeceraSeccion1.PerformLayout();
            this.panel_cabeceraSeccion2.ResumeLayout(false);
            this.panel_cabeceraSeccion2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_resultados)).EndInit();
            this.panel_contenedor.ResumeLayout(false);
            this.tableLayoutPanel_secundario.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_principal;
        private System.Windows.Forms.Panel panel_cabecera;
        private System.Windows.Forms.Label label_foro;
        private System.Windows.Forms.Panel panel_opciones;
        private System.Windows.Forms.Button button_seccionCrear;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel_cabeceraSeccion1;
        private System.Windows.Forms.Label label_seccion1;
        private System.Windows.Forms.Panel panel_cabeceraSeccion2;
        private System.Windows.Forms.Label label_seccion2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_editarRespuesta;
        private System.Windows.Forms.Button button_borrarRespuesta;
        private System.Windows.Forms.DataGridView dataGridView_resultados;
        private System.Windows.Forms.Panel panel_contenedor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_secundario;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox_id;
        private System.Windows.Forms.Label label_id;
        private System.Windows.Forms.TextBox textBox_autor;
        private System.Windows.Forms.Label label_autor;
        private System.Windows.Forms.Button button_seleccionarUsuario;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox textBox_texto;
        private System.Windows.Forms.Label label_texto;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DateTimePicker dateTimePicker_fecha;
        private System.Windows.Forms.Label label_fechaCreacion;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button button_descartarCambios;
        private System.Windows.Forms.Button button_guardarCambios;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn autor;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechacreacion;
    }
}
