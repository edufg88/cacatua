﻿namespace cacatUA
{
    partial class FormForo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormForo));
            this.tableLayoutPanel_principal = new System.Windows.Forms.TableLayoutPanel();
            this.panel_cabecera = new System.Windows.Forms.Panel();
            this.label_foro = new System.Windows.Forms.Label();
            this.panel_opciones = new System.Windows.Forms.Panel();
            this.button_seccionCrear = new System.Windows.Forms.Button();
            this.button_seccionBuscar = new System.Windows.Forms.Button();
            this.panel_cabeceraSeccion1 = new System.Windows.Forms.Panel();
            this.label_seccion1 = new System.Windows.Forms.Label();
            this.panel_cabeceraSeccion2 = new System.Windows.Forms.Panel();
            this.label_resultados = new System.Windows.Forms.Label();
            this.label_seccion2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_cantidadPagina = new System.Windows.Forms.Label();
            this.comboBox_cantidadPorPagina = new System.Windows.Forms.ComboBox();
            this.button_paginaSiguiente = new System.Windows.Forms.Button();
            this.button_paginaAnterior = new System.Windows.Forms.Button();
            this.comboBox_pagina = new System.Windows.Forms.ComboBox();
            this.button_editarHilo = new System.Windows.Forms.Button();
            this.button_borrarHilo = new System.Windows.Forms.Button();
            this.dataGridView_resultados = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.texto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.autor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechacreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numRespuestas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_contenedor = new System.Windows.Forms.Panel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel_principal.SuspendLayout();
            this.panel_cabecera.SuspendLayout();
            this.panel_opciones.SuspendLayout();
            this.panel_cabeceraSeccion1.SuspendLayout();
            this.panel_cabeceraSeccion2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_resultados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
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
            this.tableLayoutPanel_principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.tableLayoutPanel_principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel_principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_principal.Size = new System.Drawing.Size(838, 582);
            this.tableLayoutPanel_principal.TabIndex = 0;
            // 
            // panel_cabecera
            // 
            this.panel_cabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(110)))), ((int)(((byte)(0)))));
            this.panel_cabecera.Controls.Add(this.label_foro);
            this.panel_cabecera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_cabecera.Location = new System.Drawing.Point(0, 0);
            this.panel_cabecera.Margin = new System.Windows.Forms.Padding(0);
            this.panel_cabecera.Name = "panel_cabecera";
            this.panel_cabecera.Size = new System.Drawing.Size(838, 30);
            this.panel_cabecera.TabIndex = 0;
            // 
            // label_foro
            // 
            this.label_foro.AutoSize = true;
            this.label_foro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_foro.ForeColor = System.Drawing.Color.White;
            this.label_foro.Location = new System.Drawing.Point(11, 7);
            this.label_foro.Name = "label_foro";
            this.label_foro.Size = new System.Drawing.Size(37, 17);
            this.label_foro.TabIndex = 0;
            this.label_foro.Text = "Foro";
            // 
            // panel_opciones
            // 
            this.panel_opciones.Controls.Add(this.button_seccionCrear);
            this.panel_opciones.Controls.Add(this.button_seccionBuscar);
            this.panel_opciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_opciones.Location = new System.Drawing.Point(0, 30);
            this.panel_opciones.Margin = new System.Windows.Forms.Padding(0);
            this.panel_opciones.Name = "panel_opciones";
            this.panel_opciones.Size = new System.Drawing.Size(838, 45);
            this.panel_opciones.TabIndex = 1;
            // 
            // button_seccionCrear
            // 
            this.button_seccionCrear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_seccionCrear.FlatAppearance.BorderSize = 0;
            this.button_seccionCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_seccionCrear.Image = ((System.Drawing.Image)(resources.GetObject("button_seccionCrear.Image")));
            this.button_seccionCrear.Location = new System.Drawing.Point(39, 2);
            this.button_seccionCrear.Name = "button_seccionCrear";
            this.button_seccionCrear.Size = new System.Drawing.Size(36, 36);
            this.button_seccionCrear.TabIndex = 1;
            this.toolTip1.SetToolTip(this.button_seccionCrear, "Crear un nuevo hilo");
            this.button_seccionCrear.UseVisualStyleBackColor = true;
            this.button_seccionCrear.Click += new System.EventHandler(this.button_seccionCrear_Click);
            // 
            // button_seccionBuscar
            // 
            this.button_seccionBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_seccionBuscar.FlatAppearance.BorderSize = 0;
            this.button_seccionBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_seccionBuscar.Image = ((System.Drawing.Image)(resources.GetObject("button_seccionBuscar.Image")));
            this.button_seccionBuscar.Location = new System.Drawing.Point(3, 2);
            this.button_seccionBuscar.Name = "button_seccionBuscar";
            this.button_seccionBuscar.Size = new System.Drawing.Size(36, 36);
            this.button_seccionBuscar.TabIndex = 0;
            this.toolTip1.SetToolTip(this.button_seccionBuscar, "Realizar nueva búsqueda");
            this.button_seccionBuscar.UseVisualStyleBackColor = true;
            this.button_seccionBuscar.Click += new System.EventHandler(this.button_seccionBuscar_Click);
            // 
            // panel_cabeceraSeccion1
            // 
            this.panel_cabeceraSeccion1.BackColor = System.Drawing.Color.LightGray;
            this.panel_cabeceraSeccion1.Controls.Add(this.label_seccion1);
            this.panel_cabeceraSeccion1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_cabeceraSeccion1.Location = new System.Drawing.Point(3, 78);
            this.panel_cabeceraSeccion1.Name = "panel_cabeceraSeccion1";
            this.panel_cabeceraSeccion1.Size = new System.Drawing.Size(832, 29);
            this.panel_cabeceraSeccion1.TabIndex = 2;
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
            // panel_cabeceraSeccion2
            // 
            this.panel_cabeceraSeccion2.BackColor = System.Drawing.Color.LightGray;
            this.panel_cabeceraSeccion2.Controls.Add(this.label_resultados);
            this.panel_cabeceraSeccion2.Controls.Add(this.label_seccion2);
            this.panel_cabeceraSeccion2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_cabeceraSeccion2.Location = new System.Drawing.Point(3, 353);
            this.panel_cabeceraSeccion2.Name = "panel_cabeceraSeccion2";
            this.panel_cabeceraSeccion2.Size = new System.Drawing.Size(832, 29);
            this.panel_cabeceraSeccion2.TabIndex = 3;
            // 
            // label_resultados
            // 
            this.label_resultados.AutoSize = true;
            this.label_resultados.Location = new System.Drawing.Point(166, 8);
            this.label_resultados.Name = "label_resultados";
            this.label_resultados.Size = new System.Drawing.Size(214, 13);
            this.label_resultados.TabIndex = 1;
            this.label_resultados.Text = "(mostrando 1 - 61 de 379 hilos encontrados)";
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
            // panel1
            // 
            this.panel1.Controls.Add(this.label_cantidadPagina);
            this.panel1.Controls.Add(this.comboBox_cantidadPorPagina);
            this.panel1.Controls.Add(this.button_paginaSiguiente);
            this.panel1.Controls.Add(this.button_paginaAnterior);
            this.panel1.Controls.Add(this.comboBox_pagina);
            this.panel1.Controls.Add(this.button_editarHilo);
            this.panel1.Controls.Add(this.button_borrarHilo);
            this.panel1.Controls.Add(this.dataGridView_resultados);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 385);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(838, 197);
            this.panel1.TabIndex = 5;
            // 
            // label_cantidadPagina
            // 
            this.label_cantidadPagina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_cantidadPagina.AutoSize = true;
            this.label_cantidadPagina.Location = new System.Drawing.Point(3, 173);
            this.label_cantidadPagina.Name = "label_cantidadPagina";
            this.label_cantidadPagina.Size = new System.Drawing.Size(105, 13);
            this.label_cantidadPagina.TabIndex = 2;
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
            this.comboBox_cantidadPorPagina.Location = new System.Drawing.Point(111, 169);
            this.comboBox_cantidadPorPagina.Name = "comboBox_cantidadPorPagina";
            this.comboBox_cantidadPorPagina.Size = new System.Drawing.Size(45, 21);
            this.comboBox_cantidadPorPagina.TabIndex = 3;
            this.comboBox_cantidadPorPagina.SelectionChangeCommitted += new System.EventHandler(this.comboBox_cantidadPorPagina_SelectionChangeCommitted);
            // 
            // button_paginaSiguiente
            // 
            this.button_paginaSiguiente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_paginaSiguiente.Location = new System.Drawing.Point(720, 168);
            this.button_paginaSiguiente.Name = "button_paginaSiguiente";
            this.button_paginaSiguiente.Size = new System.Drawing.Size(75, 23);
            this.button_paginaSiguiente.TabIndex = 6;
            this.button_paginaSiguiente.Text = "Siguiente";
            this.button_paginaSiguiente.UseVisualStyleBackColor = true;
            this.button_paginaSiguiente.Click += new System.EventHandler(this.button_paginaSiguiente_Click);
            // 
            // button_paginaAnterior
            // 
            this.button_paginaAnterior.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_paginaAnterior.Location = new System.Drawing.Point(587, 168);
            this.button_paginaAnterior.Name = "button_paginaAnterior";
            this.button_paginaAnterior.Size = new System.Drawing.Size(75, 23);
            this.button_paginaAnterior.TabIndex = 4;
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
            this.comboBox_pagina.Location = new System.Drawing.Point(668, 169);
            this.comboBox_pagina.Name = "comboBox_pagina";
            this.comboBox_pagina.Size = new System.Drawing.Size(46, 21);
            this.comboBox_pagina.TabIndex = 5;
            this.comboBox_pagina.SelectionChangeCommitted += new System.EventHandler(this.comboBox_pagina_SelectionChangeCommitted);
            // 
            // button_editarHilo
            // 
            this.button_editarHilo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_editarHilo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_editarHilo.FlatAppearance.BorderSize = 0;
            this.button_editarHilo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_editarHilo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_editarHilo.Image = ((System.Drawing.Image)(resources.GetObject("button_editarHilo.Image")));
            this.button_editarHilo.Location = new System.Drawing.Point(797, 5);
            this.button_editarHilo.Name = "button_editarHilo";
            this.button_editarHilo.Size = new System.Drawing.Size(36, 36);
            this.button_editarHilo.TabIndex = 1;
            this.button_editarHilo.Tag = "Modificar hilo seleccionado";
            this.toolTip1.SetToolTip(this.button_editarHilo, "Editar hilo seleccionado");
            this.button_editarHilo.UseVisualStyleBackColor = true;
            this.button_editarHilo.Click += new System.EventHandler(this.button_editarHilo_Click);
            // 
            // button_borrarHilo
            // 
            this.button_borrarHilo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_borrarHilo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_borrarHilo.FlatAppearance.BorderSize = 0;
            this.button_borrarHilo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_borrarHilo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_borrarHilo.Image = ((System.Drawing.Image)(resources.GetObject("button_borrarHilo.Image")));
            this.button_borrarHilo.Location = new System.Drawing.Point(797, 41);
            this.button_borrarHilo.Name = "button_borrarHilo";
            this.button_borrarHilo.Size = new System.Drawing.Size(36, 36);
            this.button_borrarHilo.TabIndex = 2;
            this.button_borrarHilo.Tag = "Eliminar hilo seleccionado";
            this.toolTip1.SetToolTip(this.button_borrarHilo, "Eliminar hilos seleccionados");
            this.button_borrarHilo.UseVisualStyleBackColor = true;
            this.button_borrarHilo.Click += new System.EventHandler(this.button_borrarHilo_Click);
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
            this.titulo,
            this.texto,
            this.autor,
            this.fechacreacion,
            this.numRespuestas});
            this.dataGridView_resultados.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_resultados.Name = "dataGridView_resultados";
            this.dataGridView_resultados.ReadOnly = true;
            this.dataGridView_resultados.RowHeadersVisible = false;
            this.dataGridView_resultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_resultados.Size = new System.Drawing.Size(790, 161);
            this.dataGridView_resultados.TabIndex = 0;
            this.dataGridView_resultados.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_resultados_ColumnHeaderMouseClick);
            this.dataGridView_resultados.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_resultados_CellMouseDoubleClick);
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.id.FillWeight = 152.2843F;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.id.Width = 41;
            // 
            // titulo
            // 
            this.titulo.FillWeight = 89.54314F;
            this.titulo.HeaderText = "Título";
            this.titulo.Name = "titulo";
            this.titulo.ReadOnly = true;
            // 
            // texto
            // 
            this.texto.FillWeight = 89.54314F;
            this.texto.HeaderText = "Texto";
            this.texto.Name = "texto";
            this.texto.ReadOnly = true;
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
            // numRespuestas
            // 
            this.numRespuestas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.numRespuestas.FillWeight = 89.54314F;
            this.numRespuestas.HeaderText = "Número de respuestas";
            this.numRespuestas.Name = "numRespuestas";
            this.numRespuestas.ReadOnly = true;
            this.numRespuestas.Width = 124;
            // 
            // panel_contenedor
            // 
            this.panel_contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_contenedor.Location = new System.Drawing.Point(0, 110);
            this.panel_contenedor.Margin = new System.Windows.Forms.Padding(0);
            this.panel_contenedor.Name = "panel_contenedor";
            this.panel_contenedor.Size = new System.Drawing.Size(838, 240);
            this.panel_contenedor.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FormForo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel_principal);
            this.Name = "FormForo";
            this.Size = new System.Drawing.Size(838, 582);
            this.tableLayoutPanel_principal.ResumeLayout(false);
            this.panel_cabecera.ResumeLayout(false);
            this.panel_cabecera.PerformLayout();
            this.panel_opciones.ResumeLayout(false);
            this.panel_cabeceraSeccion1.ResumeLayout(false);
            this.panel_cabeceraSeccion1.PerformLayout();
            this.panel_cabeceraSeccion2.ResumeLayout(false);
            this.panel_cabeceraSeccion2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_resultados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_principal;
        private System.Windows.Forms.Panel panel_cabecera;
        private System.Windows.Forms.Label label_foro;
        private System.Windows.Forms.Panel panel_opciones;
        private System.Windows.Forms.Panel panel_cabeceraSeccion1;
        private System.Windows.Forms.Label label_seccion1;
        private System.Windows.Forms.Panel panel_cabeceraSeccion2;
        private System.Windows.Forms.Label label_seccion2;
        private System.Windows.Forms.Button button_seccionBuscar;
        private System.Windows.Forms.Button button_seccionCrear;
        private System.Windows.Forms.DataGridView dataGridView_resultados;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_editarHilo;
        private System.Windows.Forms.Button button_borrarHilo;
        private System.Windows.Forms.Panel panel_contenedor;
        private System.Windows.Forms.Button button_paginaAnterior;
        private System.Windows.Forms.ComboBox comboBox_pagina;
        private System.Windows.Forms.Button button_paginaSiguiente;
        private System.Windows.Forms.Label label_cantidadPagina;
        private System.Windows.Forms.ComboBox comboBox_cantidadPorPagina;
        private System.Windows.Forms.Label label_resultados;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn titulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn texto;
        private System.Windows.Forms.DataGridViewTextBoxColumn autor;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechacreacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn numRespuestas;

    }
}
