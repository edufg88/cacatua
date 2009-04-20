namespace cacatUA
{
    partial class FormGrupos
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
            this.tableLayoutPanel_principal = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_paginaSiguiente = new System.Windows.Forms.Button();
            this.comboBox_pagina = new System.Windows.Forms.ComboBox();
            this.button_paginaAnterior = new System.Windows.Forms.Button();
            this.comboBox_cantidadPorPagina = new System.Windows.Forms.ComboBox();
            this.label_cantidadPagina = new System.Windows.Forms.Label();
            this.button_editar = new System.Windows.Forms.Button();
            this.button_borrar = new System.Windows.Forms.Button();
            this.dataGridView_resultados = new System.Windows.Forms.DataGridView();
            this.DataGridViewTextBoxColumn_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumn_nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumn_numUsuarios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumn_fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_tituloResultado = new System.Windows.Forms.Panel();
            this.label_resultados = new System.Windows.Forms.Label();
            this.label_resultado = new System.Windows.Forms.Label();
            this.panel_Titulo = new System.Windows.Forms.Panel();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.panel_contenedor = new System.Windows.Forms.Panel();
            this.panel_cabeceraSeccion1 = new System.Windows.Forms.Panel();
            this.label_seccion1 = new System.Windows.Forms.Label();
            this.panel_opciones = new System.Windows.Forms.Panel();
            this.button_seccionCrear = new System.Windows.Forms.Button();
            this.button_seccionBuscar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel_principal.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_resultados)).BeginInit();
            this.panel_tituloResultado.SuspendLayout();
            this.panel_Titulo.SuspendLayout();
            this.panel_cabeceraSeccion1.SuspendLayout();
            this.panel_opciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_principal
            // 
            this.tableLayoutPanel_principal.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel_principal.ColumnCount = 1;
            this.tableLayoutPanel_principal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_principal.Controls.Add(this.panel1, 0, 5);
            this.tableLayoutPanel_principal.Controls.Add(this.panel_tituloResultado, 0, 4);
            this.tableLayoutPanel_principal.Controls.Add(this.panel_Titulo, 0, 0);
            this.tableLayoutPanel_principal.Controls.Add(this.panel_contenedor, 0, 3);
            this.tableLayoutPanel_principal.Controls.Add(this.panel_cabeceraSeccion1, 0, 2);
            this.tableLayoutPanel_principal.Controls.Add(this.panel_opciones, 0, 1);
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
            this.tableLayoutPanel_principal.Size = new System.Drawing.Size(860, 522);
            this.tableLayoutPanel_principal.TabIndex = 34;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_paginaSiguiente);
            this.panel1.Controls.Add(this.comboBox_pagina);
            this.panel1.Controls.Add(this.button_paginaAnterior);
            this.panel1.Controls.Add(this.comboBox_cantidadPorPagina);
            this.panel1.Controls.Add(this.label_cantidadPagina);
            this.panel1.Controls.Add(this.button_editar);
            this.panel1.Controls.Add(this.button_borrar);
            this.panel1.Controls.Add(this.dataGridView_resultados);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 385);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(860, 137);
            this.panel1.TabIndex = 104;
            // 
            // button_paginaSiguiente
            // 
            this.button_paginaSiguiente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_paginaSiguiente.Location = new System.Drawing.Point(742, 108);
            this.button_paginaSiguiente.Name = "button_paginaSiguiente";
            this.button_paginaSiguiente.Size = new System.Drawing.Size(75, 23);
            this.button_paginaSiguiente.TabIndex = 6;
            this.button_paginaSiguiente.Text = "Siguiente";
            this.button_paginaSiguiente.UseVisualStyleBackColor = true;
            this.button_paginaSiguiente.Click += new System.EventHandler(this.button_paginaSiguiente_Click);
            // 
            // comboBox_pagina
            // 
            this.comboBox_pagina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_pagina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_pagina.Items.AddRange(new object[] {
            "1"});
            this.comboBox_pagina.Location = new System.Drawing.Point(690, 109);
            this.comboBox_pagina.Name = "comboBox_pagina";
            this.comboBox_pagina.Size = new System.Drawing.Size(46, 21);
            this.comboBox_pagina.TabIndex = 5;
            this.comboBox_pagina.SelectionChangeCommitted += new System.EventHandler(this.comboBox_pagina_SelectionChangeCommitted);
            // 
            // button_paginaAnterior
            // 
            this.button_paginaAnterior.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_paginaAnterior.Enabled = false;
            this.button_paginaAnterior.Location = new System.Drawing.Point(609, 108);
            this.button_paginaAnterior.Name = "button_paginaAnterior";
            this.button_paginaAnterior.Size = new System.Drawing.Size(75, 23);
            this.button_paginaAnterior.TabIndex = 4;
            this.button_paginaAnterior.Text = "Anterior";
            this.button_paginaAnterior.UseVisualStyleBackColor = true;
            this.button_paginaAnterior.Click += new System.EventHandler(this.button_paginaAnterior_Click);
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
            "11",
            "12",
            "13",
            "15",
            "17",
            "20",
            "30",
            "40",
            "50",
            "60",
            "70",
            "80",
            "90",
            "100",
            "150",
            "200",
            "250",
            "300"});
            this.comboBox_cantidadPorPagina.Location = new System.Drawing.Point(111, 109);
            this.comboBox_cantidadPorPagina.Name = "comboBox_cantidadPorPagina";
            this.comboBox_cantidadPorPagina.Size = new System.Drawing.Size(45, 21);
            this.comboBox_cantidadPorPagina.TabIndex = 3;
            this.comboBox_cantidadPorPagina.SelectionChangeCommitted += new System.EventHandler(this.comboBox_cantidadPorPagina_SelectionChangeCommitted);
            this.comboBox_cantidadPorPagina.SelectedIndexChanged += new System.EventHandler(this.comboBox_cantidadPorPagina_SelectedIndexChanged);
            // 
            // label_cantidadPagina
            // 
            this.label_cantidadPagina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_cantidadPagina.AutoSize = true;
            this.label_cantidadPagina.Location = new System.Drawing.Point(3, 113);
            this.label_cantidadPagina.Name = "label_cantidadPagina";
            this.label_cantidadPagina.Size = new System.Drawing.Size(105, 13);
            this.label_cantidadPagina.TabIndex = 2;
            this.label_cantidadPagina.Text = "Cantidad por página:";
            // 
            // button_editar
            // 
            this.button_editar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_editar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_editar.FlatAppearance.BorderSize = 0;
            this.button_editar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_editar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_editar.Image = global::cacatUA.Properties.Resources.tool;
            this.button_editar.Location = new System.Drawing.Point(821, 3);
            this.button_editar.Name = "button_editar";
            this.button_editar.Size = new System.Drawing.Size(36, 36);
            this.button_editar.TabIndex = 1;
            this.button_editar.Tag = "";
            this.toolTip1.SetToolTip(this.button_editar, "Editar grupo seleccionado");
            this.button_editar.UseVisualStyleBackColor = true;
            this.button_editar.Click += new System.EventHandler(this.button_editar_Click);
            // 
            // button_borrar
            // 
            this.button_borrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_borrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_borrar.FlatAppearance.BorderSize = 0;
            this.button_borrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_borrar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_borrar.Image = global::cacatUA.Properties.Resources.close;
            this.button_borrar.Location = new System.Drawing.Point(821, 39);
            this.button_borrar.Name = "button_borrar";
            this.button_borrar.Size = new System.Drawing.Size(36, 36);
            this.button_borrar.TabIndex = 2;
            this.button_borrar.Tag = "";
            this.toolTip1.SetToolTip(this.button_borrar, "Borrar grupo seleccionado");
            this.button_borrar.UseVisualStyleBackColor = true;
            this.button_borrar.Click += new System.EventHandler(this.button_borrar_Click);
            // 
            // dataGridView_resultados
            // 
            this.dataGridView_resultados.AllowUserToAddRows = false;
            this.dataGridView_resultados.AllowUserToDeleteRows = false;
            this.dataGridView_resultados.AllowUserToResizeRows = false;
            this.dataGridView_resultados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_resultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_resultados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataGridViewTextBoxColumn_id,
            this.DataGridViewTextBoxColumn_nombre,
            this.DataGridViewTextBoxColumn_numUsuarios,
            this.DataGridViewTextBoxColumn_fecha});
            this.dataGridView_resultados.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_resultados.Name = "dataGridView_resultados";
            this.dataGridView_resultados.ReadOnly = true;
            this.dataGridView_resultados.RowHeadersVisible = false;
            this.dataGridView_resultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_resultados.Size = new System.Drawing.Size(814, 96);
            this.dataGridView_resultados.TabIndex = 0;
            this.dataGridView_resultados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_resultados_CellClick);
            this.dataGridView_resultados.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_resultados_CellMouseDoubleClick);
            // 
            // DataGridViewTextBoxColumn_id
            // 
            this.DataGridViewTextBoxColumn_id.HeaderText = "ID";
            this.DataGridViewTextBoxColumn_id.Name = "DataGridViewTextBoxColumn_id";
            this.DataGridViewTextBoxColumn_id.ReadOnly = true;
            this.DataGridViewTextBoxColumn_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.DataGridViewTextBoxColumn_id.Width = 50;
            // 
            // DataGridViewTextBoxColumn_nombre
            // 
            this.DataGridViewTextBoxColumn_nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DataGridViewTextBoxColumn_nombre.HeaderText = "Nombre";
            this.DataGridViewTextBoxColumn_nombre.Name = "DataGridViewTextBoxColumn_nombre";
            this.DataGridViewTextBoxColumn_nombre.ReadOnly = true;
            this.DataGridViewTextBoxColumn_nombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // DataGridViewTextBoxColumn_numUsuarios
            // 
            this.DataGridViewTextBoxColumn_numUsuarios.HeaderText = "Número de Usuarios";
            this.DataGridViewTextBoxColumn_numUsuarios.Name = "DataGridViewTextBoxColumn_numUsuarios";
            this.DataGridViewTextBoxColumn_numUsuarios.ReadOnly = true;
            this.DataGridViewTextBoxColumn_numUsuarios.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.DataGridViewTextBoxColumn_numUsuarios.Width = 128;
            // 
            // DataGridViewTextBoxColumn_fecha
            // 
            this.DataGridViewTextBoxColumn_fecha.HeaderText = "Fecha de Creación";
            this.DataGridViewTextBoxColumn_fecha.Name = "DataGridViewTextBoxColumn_fecha";
            this.DataGridViewTextBoxColumn_fecha.ReadOnly = true;
            this.DataGridViewTextBoxColumn_fecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.DataGridViewTextBoxColumn_fecha.Width = 122;
            // 
            // panel_tituloResultado
            // 
            this.panel_tituloResultado.BackColor = System.Drawing.Color.LightGray;
            this.panel_tituloResultado.Controls.Add(this.label_resultados);
            this.panel_tituloResultado.Controls.Add(this.label_resultado);
            this.panel_tituloResultado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_tituloResultado.Location = new System.Drawing.Point(3, 353);
            this.panel_tituloResultado.Name = "panel_tituloResultado";
            this.panel_tituloResultado.Size = new System.Drawing.Size(854, 29);
            this.panel_tituloResultado.TabIndex = 101;
            // 
            // label_resultados
            // 
            this.label_resultados.AutoSize = true;
            this.label_resultados.Location = new System.Drawing.Point(180, 8);
            this.label_resultados.Name = "label_resultados";
            this.label_resultados.Size = new System.Drawing.Size(225, 13);
            this.label_resultados.TabIndex = 3;
            this.label_resultados.Text = "(mostrando 1 - 50 de 200 grupos encontrados)";
            // 
            // label_resultado
            // 
            this.label_resultado.AutoSize = true;
            this.label_resultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_resultado.Location = new System.Drawing.Point(13, 8);
            this.label_resultado.Name = "label_resultado";
            this.label_resultado.Size = new System.Drawing.Size(161, 13);
            this.label_resultado.TabIndex = 2;
            this.label_resultado.Text = "Resultados de la búsqueda";
            // 
            // panel_Titulo
            // 
            this.panel_Titulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(182)))), ((int)(((byte)(56)))));
            this.panel_Titulo.Controls.Add(this.labelTitulo);
            this.panel_Titulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Titulo.Location = new System.Drawing.Point(0, 0);
            this.panel_Titulo.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Titulo.Name = "panel_Titulo";
            this.panel_Titulo.Size = new System.Drawing.Size(860, 30);
            this.panel_Titulo.TabIndex = 30;
            // 
            // labelTitulo
            // 
            this.labelTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.ForeColor = System.Drawing.Color.White;
            this.labelTitulo.Location = new System.Drawing.Point(11, 7);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(55, 17);
            this.labelTitulo.TabIndex = 7;
            this.labelTitulo.Text = "Grupos";
            // 
            // panel_contenedor
            // 
            this.panel_contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_contenedor.Location = new System.Drawing.Point(0, 110);
            this.panel_contenedor.Margin = new System.Windows.Forms.Padding(0);
            this.panel_contenedor.Name = "panel_contenedor";
            this.panel_contenedor.Size = new System.Drawing.Size(860, 240);
            this.panel_contenedor.TabIndex = 1;
            // 
            // panel_cabeceraSeccion1
            // 
            this.panel_cabeceraSeccion1.BackColor = System.Drawing.Color.LightGray;
            this.panel_cabeceraSeccion1.Controls.Add(this.label_seccion1);
            this.panel_cabeceraSeccion1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_cabeceraSeccion1.Location = new System.Drawing.Point(3, 78);
            this.panel_cabeceraSeccion1.Name = "panel_cabeceraSeccion1";
            this.panel_cabeceraSeccion1.Size = new System.Drawing.Size(854, 29);
            this.panel_cabeceraSeccion1.TabIndex = 107;
            // 
            // label_seccion1
            // 
            this.label_seccion1.AutoSize = true;
            this.label_seccion1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label_seccion1.Location = new System.Drawing.Point(13, 8);
            this.label_seccion1.Name = "label_seccion1";
            this.label_seccion1.Size = new System.Drawing.Size(63, 13);
            this.label_seccion1.TabIndex = 0;
            this.label_seccion1.Text = "Búsqueda";
            // 
            // panel_opciones
            // 
            this.panel_opciones.Controls.Add(this.button_seccionCrear);
            this.panel_opciones.Controls.Add(this.button_seccionBuscar);
            this.panel_opciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_opciones.Location = new System.Drawing.Point(0, 30);
            this.panel_opciones.Margin = new System.Windows.Forms.Padding(0);
            this.panel_opciones.Name = "panel_opciones";
            this.panel_opciones.Size = new System.Drawing.Size(860, 45);
            this.panel_opciones.TabIndex = 106;
            // 
            // button_seccionCrear
            // 
            this.button_seccionCrear.FlatAppearance.BorderSize = 0;
            this.button_seccionCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_seccionCrear.Image = global::cacatUA.Properties.Resources.nuevo;
            this.button_seccionCrear.Location = new System.Drawing.Point(39, 2);
            this.button_seccionCrear.Name = "button_seccionCrear";
            this.button_seccionCrear.Size = new System.Drawing.Size(36, 36);
            this.button_seccionCrear.TabIndex = 1;
            this.toolTip1.SetToolTip(this.button_seccionCrear, "Crear un nuevo grupo");
            this.button_seccionCrear.UseVisualStyleBackColor = true;
            this.button_seccionCrear.Click += new System.EventHandler(this.button_seccionCrear_Click);
            // 
            // button_seccionBuscar
            // 
            this.button_seccionBuscar.FlatAppearance.BorderSize = 0;
            this.button_seccionBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_seccionBuscar.Image = global::cacatUA.Properties.Resources.buscar1;
            this.button_seccionBuscar.Location = new System.Drawing.Point(3, 2);
            this.button_seccionBuscar.Name = "button_seccionBuscar";
            this.button_seccionBuscar.Size = new System.Drawing.Size(36, 36);
            this.button_seccionBuscar.TabIndex = 0;
            this.toolTip1.SetToolTip(this.button_seccionBuscar, "Realizar nueva búsqueda");
            this.button_seccionBuscar.UseVisualStyleBackColor = true;
            this.button_seccionBuscar.Click += new System.EventHandler(this.button_seccionBuscar_Click);
            // 
            // FormGrupos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel_principal);
            this.Name = "FormGrupos";
            this.Size = new System.Drawing.Size(860, 522);
            this.tableLayoutPanel_principal.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_resultados)).EndInit();
            this.panel_tituloResultado.ResumeLayout(false);
            this.panel_tituloResultado.PerformLayout();
            this.panel_Titulo.ResumeLayout(false);
            this.panel_Titulo.PerformLayout();
            this.panel_cabeceraSeccion1.ResumeLayout(false);
            this.panel_cabeceraSeccion1.PerformLayout();
            this.panel_opciones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_principal;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_editar;
        private System.Windows.Forms.Button button_borrar;
        private System.Windows.Forms.DataGridView dataGridView_resultados;
        private System.Windows.Forms.Panel panel_tituloResultado;
        private System.Windows.Forms.Label label_resultado;
        private System.Windows.Forms.Panel panel_Titulo;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Panel panel_contenedor;
        private System.Windows.Forms.Panel panel_opciones;
        private System.Windows.Forms.Button button_seccionCrear;
        private System.Windows.Forms.Button button_seccionBuscar;
        private System.Windows.Forms.Panel panel_cabeceraSeccion1;
        private System.Windows.Forms.Label label_seccion1;
        private System.Windows.Forms.Button button_paginaSiguiente;
        private System.Windows.Forms.ComboBox comboBox_pagina;
        private System.Windows.Forms.Button button_paginaAnterior;
        private System.Windows.Forms.ComboBox comboBox_cantidadPorPagina;
        private System.Windows.Forms.Label label_cantidadPagina;
        private System.Windows.Forms.Label label_resultados;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn_nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn_numUsuarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn_fecha;

    }
}
