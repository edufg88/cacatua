namespace cacatUA
{
    partial class FormUsuarioFirmas
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
            this.tableLayoutPanel_principal = new System.Windows.Forms.TableLayoutPanel();
            this.panel_cabecera = new System.Windows.Forms.Panel();
            this.label_firmas = new System.Windows.Forms.Label();
            this.panel_cabeceraSeccion1 = new System.Windows.Forms.Panel();
            this.label_seccion1 = new System.Windows.Forms.Label();
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.label_id = new System.Windows.Forms.Label();
            this.panel_cabeceraSeccion2 = new System.Windows.Forms.Panel();
            this.label_seccion2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_editarFirma = new System.Windows.Forms.Button();
            this.button_borrarFirma = new System.Windows.Forms.Button();
            this.dataGridView_firmas = new System.Windows.Forms.DataGridView();
            this.panel_contenedor = new System.Windows.Forms.Panel();
            this.tableLayoutPanel_secundario = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label_receptor = new System.Windows.Forms.Label();
            this.textBox_receptor = new System.Windows.Forms.TextBox();
            this.textBox_emisor = new System.Windows.Forms.TextBox();
            this.label_emisor = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textBox_texto = new System.Windows.Forms.TextBox();
            this.label_texto = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dateTimePicker_fecha = new System.Windows.Forms.DateTimePicker();
            this.label_fechaCreacion = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.button_descartarCambios = new System.Windows.Forms.Button();
            this.button_guardarCambios = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receptor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechacreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel_principal.SuspendLayout();
            this.panel_cabecera.SuspendLayout();
            this.panel_cabeceraSeccion1.SuspendLayout();
            this.panel_cabeceraSeccion2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_firmas)).BeginInit();
            this.panel_contenedor.SuspendLayout();
            this.tableLayoutPanel_secundario.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
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
            this.tableLayoutPanel_principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel_principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel_principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_principal.Size = new System.Drawing.Size(751, 373);
            this.tableLayoutPanel_principal.TabIndex = 2;
            // 
            // panel_cabecera
            // 
            this.panel_cabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panel_cabecera.Controls.Add(this.label_firmas);
            this.panel_cabecera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_cabecera.Location = new System.Drawing.Point(0, 0);
            this.panel_cabecera.Margin = new System.Windows.Forms.Padding(0);
            this.panel_cabecera.Name = "panel_cabecera";
            this.panel_cabecera.Size = new System.Drawing.Size(751, 30);
            this.panel_cabecera.TabIndex = 0;
            // 
            // label_firmas
            // 
            this.label_firmas.AutoSize = true;
            this.label_firmas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_firmas.ForeColor = System.Drawing.Color.White;
            this.label_firmas.Location = new System.Drawing.Point(11, 7);
            this.label_firmas.Name = "label_firmas";
            this.label_firmas.Size = new System.Drawing.Size(124, 17);
            this.label_firmas.TabIndex = 0;
            this.label_firmas.Text = "Firmas del usuario";
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
            this.panel_cabeceraSeccion1.Size = new System.Drawing.Size(745, 29);
            this.panel_cabeceraSeccion1.TabIndex = 2;
            // 
            // label_seccion1
            // 
            this.label_seccion1.AutoSize = true;
            this.label_seccion1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_seccion1.Location = new System.Drawing.Point(13, 8);
            this.label_seccion1.Name = "label_seccion1";
            this.label_seccion1.Size = new System.Drawing.Size(136, 13);
            this.label_seccion1.TabIndex = 0;
            this.label_seccion1.Text = "Información de la firma";
            // 
            // textBox_id
            // 
            this.textBox_id.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_id.Location = new System.Drawing.Point(683, 6);
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
            this.label_id.Location = new System.Drawing.Point(656, 9);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(21, 13);
            this.label_id.TabIndex = 3;
            this.label_id.Text = "ID:";
            // 
            // panel_cabeceraSeccion2
            // 
            this.panel_cabeceraSeccion2.BackColor = System.Drawing.Color.LightGray;
            this.panel_cabeceraSeccion2.Controls.Add(this.label_seccion2);
            this.panel_cabeceraSeccion2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_cabeceraSeccion2.Location = new System.Drawing.Point(3, 218);
            this.panel_cabeceraSeccion2.Name = "panel_cabeceraSeccion2";
            this.panel_cabeceraSeccion2.Size = new System.Drawing.Size(745, 29);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.button_editarFirma);
            this.panel1.Controls.Add(this.button_borrarFirma);
            this.panel1.Controls.Add(this.dataGridView_firmas);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 250);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(751, 123);
            this.panel1.TabIndex = 5;
            // 
            // button_editarFirma
            // 
            this.button_editarFirma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_editarFirma.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_editarFirma.FlatAppearance.BorderSize = 0;
            this.button_editarFirma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_editarFirma.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_editarFirma.Image = global::cacatUA.Properties.Resources.tool;
            this.button_editarFirma.Location = new System.Drawing.Point(710, 5);
            this.button_editarFirma.Name = "button_editarFirma";
            this.button_editarFirma.Size = new System.Drawing.Size(36, 36);
            this.button_editarFirma.TabIndex = 9;
            this.button_editarFirma.Tag = "";
            this.button_editarFirma.UseVisualStyleBackColor = true;
            this.button_editarFirma.Click += new System.EventHandler(this.button_editarFirma_Click);
            // 
            // button_borrarFirma
            // 
            this.button_borrarFirma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_borrarFirma.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_borrarFirma.FlatAppearance.BorderSize = 0;
            this.button_borrarFirma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_borrarFirma.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_borrarFirma.Image = global::cacatUA.Properties.Resources.close;
            this.button_borrarFirma.Location = new System.Drawing.Point(710, 41);
            this.button_borrarFirma.Name = "button_borrarFirma";
            this.button_borrarFirma.Size = new System.Drawing.Size(36, 36);
            this.button_borrarFirma.TabIndex = 10;
            this.button_borrarFirma.Tag = "";
            this.button_borrarFirma.UseVisualStyleBackColor = true;
            this.button_borrarFirma.Click += new System.EventHandler(this.button_borrarFirma_Click);
            // 
            // dataGridView_firmas
            // 
            this.dataGridView_firmas.AllowUserToAddRows = false;
            this.dataGridView_firmas.AllowUserToDeleteRows = false;
            this.dataGridView_firmas.AllowUserToResizeRows = false;
            this.dataGridView_firmas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_firmas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_firmas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_firmas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.descripcion,
            this.emisor,
            this.receptor,
            this.fechacreacion});
            this.dataGridView_firmas.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_firmas.Name = "dataGridView_firmas";
            this.dataGridView_firmas.ReadOnly = true;
            this.dataGridView_firmas.RowHeadersVisible = false;
            this.dataGridView_firmas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_firmas.Size = new System.Drawing.Size(703, 117);
            this.dataGridView_firmas.TabIndex = 4;
            this.dataGridView_firmas.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_firmas_CellMouseDoubleClick);
            // 
            // panel_contenedor
            // 
            this.panel_contenedor.Controls.Add(this.tableLayoutPanel_secundario);
            this.panel_contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_contenedor.Location = new System.Drawing.Point(0, 65);
            this.panel_contenedor.Margin = new System.Windows.Forms.Padding(0);
            this.panel_contenedor.Name = "panel_contenedor";
            this.panel_contenedor.Size = new System.Drawing.Size(751, 150);
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
            this.tableLayoutPanel_secundario.Size = new System.Drawing.Size(751, 150);
            this.tableLayoutPanel_secundario.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label_receptor);
            this.panel2.Controls.Add(this.textBox_receptor);
            this.panel2.Controls.Add(this.textBox_emisor);
            this.panel2.Controls.Add(this.label_emisor);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(751, 30);
            this.panel2.TabIndex = 1;
            // 
            // label_receptor
            // 
            this.label_receptor.AutoSize = true;
            this.label_receptor.Location = new System.Drawing.Point(400, 9);
            this.label_receptor.Name = "label_receptor";
            this.label_receptor.Size = new System.Drawing.Size(54, 13);
            this.label_receptor.TabIndex = 146;
            this.label_receptor.Text = "Receptor:";
            // 
            // textBox_receptor
            // 
            this.textBox_receptor.Location = new System.Drawing.Point(553, 5);
            this.textBox_receptor.Name = "textBox_receptor";
            this.textBox_receptor.ReadOnly = true;
            this.textBox_receptor.Size = new System.Drawing.Size(163, 20);
            this.textBox_receptor.TabIndex = 145;
            // 
            // textBox_emisor
            // 
            this.textBox_emisor.Location = new System.Drawing.Point(125, 5);
            this.textBox_emisor.Name = "textBox_emisor";
            this.textBox_emisor.ReadOnly = true;
            this.textBox_emisor.Size = new System.Drawing.Size(163, 20);
            this.textBox_emisor.TabIndex = 0;
            // 
            // label_emisor
            // 
            this.label_emisor.AutoSize = true;
            this.label_emisor.Location = new System.Drawing.Point(16, 8);
            this.label_emisor.Name = "label_emisor";
            this.label_emisor.Size = new System.Drawing.Size(41, 13);
            this.label_emisor.TabIndex = 0;
            this.label_emisor.Text = "Emisor:";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.textBox_texto);
            this.panel5.Controls.Add(this.label_texto);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 30);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(751, 60);
            this.panel5.TabIndex = 4;
            // 
            // textBox_texto
            // 
            this.textBox_texto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_texto.Location = new System.Drawing.Point(125, 6);
            this.textBox_texto.Multiline = true;
            this.textBox_texto.Name = "textBox_texto";
            this.textBox_texto.Size = new System.Drawing.Size(591, 49);
            this.textBox_texto.TabIndex = 0;
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
            this.panel6.Size = new System.Drawing.Size(751, 30);
            this.panel6.TabIndex = 5;
            // 
            // dateTimePicker_fecha
            // 
            this.dateTimePicker_fecha.Location = new System.Drawing.Point(125, 5);
            this.dateTimePicker_fecha.Name = "dateTimePicker_fecha";
            this.dateTimePicker_fecha.Size = new System.Drawing.Size(235, 20);
            this.dateTimePicker_fecha.TabIndex = 0;
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
            this.panel8.Size = new System.Drawing.Size(751, 30);
            this.panel8.TabIndex = 8;
            // 
            // button_descartarCambios
            // 
            this.button_descartarCambios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_descartarCambios.Location = new System.Drawing.Point(594, 3);
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
            this.button_guardarCambios.Location = new System.Drawing.Point(478, 3);
            this.button_guardarCambios.Name = "button_guardarCambios";
            this.button_guardarCambios.Size = new System.Drawing.Size(110, 23);
            this.button_guardarCambios.TabIndex = 0;
            this.button_guardarCambios.Text = "Guardar cambios";
            this.button_guardarCambios.UseVisualStyleBackColor = true;
            this.button_guardarCambios.Click += new System.EventHandler(this.button_guardarCambios_Click);
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
            // descripcion
            // 
            this.descripcion.FillWeight = 89.54314F;
            this.descripcion.HeaderText = "Texto";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // emisor
            // 
            this.emisor.HeaderText = "Emisor";
            this.emisor.Name = "emisor";
            this.emisor.ReadOnly = true;
            // 
            // receptor
            // 
            this.receptor.HeaderText = "Receptor";
            this.receptor.Name = "receptor";
            this.receptor.ReadOnly = true;
            // 
            // fechacreacion
            // 
            this.fechacreacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fechacreacion.FillWeight = 89.54314F;
            this.fechacreacion.HeaderText = "Fecha de creación";
            this.fechacreacion.Name = "fechacreacion";
            this.fechacreacion.ReadOnly = true;
            this.fechacreacion.Width = 111;
            // 
            // FormUsuarioFirmas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel_principal);
            this.Name = "FormUsuarioFirmas";
            this.Size = new System.Drawing.Size(751, 373);
            this.Load += new System.EventHandler(this.FormUsuarioFirmas_Load);
            this.tableLayoutPanel_principal.ResumeLayout(false);
            this.panel_cabecera.ResumeLayout(false);
            this.panel_cabecera.PerformLayout();
            this.panel_cabeceraSeccion1.ResumeLayout(false);
            this.panel_cabeceraSeccion1.PerformLayout();
            this.panel_cabeceraSeccion2.ResumeLayout(false);
            this.panel_cabeceraSeccion2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_firmas)).EndInit();
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

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_principal;
        private System.Windows.Forms.Panel panel_cabecera;
        private System.Windows.Forms.Label label_firmas;
        private System.Windows.Forms.Panel panel_cabeceraSeccion1;
        private System.Windows.Forms.Label label_seccion1;
        private System.Windows.Forms.Panel panel_cabeceraSeccion2;
        private System.Windows.Forms.Label label_seccion2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_editarFirma;
        private System.Windows.Forms.Button button_borrarFirma;
        private System.Windows.Forms.DataGridView dataGridView_firmas;
        private System.Windows.Forms.Panel panel_contenedor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_secundario;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox_id;
        private System.Windows.Forms.Label label_id;
        private System.Windows.Forms.TextBox textBox_emisor;
        private System.Windows.Forms.Label label_emisor;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox textBox_texto;
        private System.Windows.Forms.Label label_texto;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DateTimePicker dateTimePicker_fecha;
        private System.Windows.Forms.Label label_fechaCreacion;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button button_descartarCambios;
        private System.Windows.Forms.Button button_guardarCambios;
        private System.Windows.Forms.TextBox textBox_receptor;
        private System.Windows.Forms.Label label_receptor;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn emisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn receptor;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechacreacion;
    }
}
