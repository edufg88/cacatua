namespace cacatUA
{
    partial class FormUsuarioEdicion
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
            this.tableLayoutPanel_formEdicion = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_descartarCambios = new System.Windows.Forms.Button();
            this.button_guardarCambios = new System.Windows.Forms.Button();
            this.panel_usuarioEdicion = new System.Windows.Forms.Panel();
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.label_id = new System.Windows.Forms.Label();
            this.linkLabel_verEncuestas = new System.Windows.Forms.LinkLabel();
            this.linkLabel_verMensajes = new System.Windows.Forms.LinkLabel();
            this.linkLabel_verImagenes = new System.Windows.Forms.LinkLabel();
            this.linkLabel_verFirmas = new System.Windows.Forms.LinkLabel();
            this.textBox_numEncuestas = new System.Windows.Forms.TextBox();
            this.textBox_numMensajes = new System.Windows.Forms.TextBox();
            this.textBox_numImagenes = new System.Windows.Forms.TextBox();
            this.textBox_numFirmas = new System.Windows.Forms.TextBox();
            this.label_numEncuestas = new System.Windows.Forms.Label();
            this.label_numMensajes = new System.Windows.Forms.Label();
            this.label_numImagenes = new System.Windows.Forms.Label();
            this.label_numFirmas = new System.Windows.Forms.Label();
            this.textBox_adicional = new System.Windows.Forms.TextBox();
            this.label_adicional = new System.Windows.Forms.Label();
            this.textBox_contrasena = new System.Windows.Forms.TextBox();
            this.label_contrasena = new System.Windows.Forms.Label();
            this.textBox_dni = new System.Windows.Forms.TextBox();
            this.label_dni = new System.Windows.Forms.Label();
            this.checkBox_activo = new System.Windows.Forms.CheckBox();
            this.textBox_usuario = new System.Windows.Forms.TextBox();
            this.label_usuario = new System.Windows.Forms.Label();
            this.checkBox_administrador = new System.Windows.Forms.CheckBox();
            this.label_fechaDeIngreso = new System.Windows.Forms.Label();
            this.textBox_email = new System.Windows.Forms.TextBox();
            this.textBox_nombre = new System.Windows.Forms.TextBox();
            this.label_email = new System.Windows.Forms.Label();
            this.label_nombre = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dateTimePicker_fechaDeIngreso = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel_formEdicion.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel_usuarioEdicion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_formEdicion
            // 
            this.tableLayoutPanel_formEdicion.ColumnCount = 1;
            this.tableLayoutPanel_formEdicion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_formEdicion.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel_formEdicion.Controls.Add(this.panel_usuarioEdicion, 0, 0);
            this.tableLayoutPanel_formEdicion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_formEdicion.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_formEdicion.Name = "tableLayoutPanel_formEdicion";
            this.tableLayoutPanel_formEdicion.RowCount = 2;
            this.tableLayoutPanel_formEdicion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.42065F));
            this.tableLayoutPanel_formEdicion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel_formEdicion.Size = new System.Drawing.Size(765, 325);
            this.tableLayoutPanel_formEdicion.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button_descartarCambios);
            this.panel2.Controls.Add(this.button_guardarCambios);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 294);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(759, 28);
            this.panel2.TabIndex = 36;
            // 
            // button_descartarCambios
            // 
            this.button_descartarCambios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_descartarCambios.Location = new System.Drawing.Point(635, 3);
            this.button_descartarCambios.Name = "button_descartarCambios";
            this.button_descartarCambios.Size = new System.Drawing.Size(121, 23);
            this.button_descartarCambios.TabIndex = 3;
            this.button_descartarCambios.Text = "Descartar cambios";
            this.button_descartarCambios.UseVisualStyleBackColor = true;
            this.button_descartarCambios.Click += new System.EventHandler(this.button_descartarCambios_Click);
            // 
            // button_guardarCambios
            // 
            this.button_guardarCambios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_guardarCambios.Location = new System.Drawing.Point(519, 3);
            this.button_guardarCambios.Name = "button_guardarCambios";
            this.button_guardarCambios.Size = new System.Drawing.Size(110, 23);
            this.button_guardarCambios.TabIndex = 2;
            this.button_guardarCambios.Text = "Guardar cambios";
            this.button_guardarCambios.UseVisualStyleBackColor = true;
            this.button_guardarCambios.Click += new System.EventHandler(this.button_guardarCambios_Click);
            // 
            // panel_usuarioEdicion
            // 
            this.panel_usuarioEdicion.Controls.Add(this.dateTimePicker_fechaDeIngreso);
            this.panel_usuarioEdicion.Controls.Add(this.textBox_id);
            this.panel_usuarioEdicion.Controls.Add(this.label_id);
            this.panel_usuarioEdicion.Controls.Add(this.linkLabel_verEncuestas);
            this.panel_usuarioEdicion.Controls.Add(this.linkLabel_verMensajes);
            this.panel_usuarioEdicion.Controls.Add(this.linkLabel_verImagenes);
            this.panel_usuarioEdicion.Controls.Add(this.linkLabel_verFirmas);
            this.panel_usuarioEdicion.Controls.Add(this.textBox_numEncuestas);
            this.panel_usuarioEdicion.Controls.Add(this.textBox_numMensajes);
            this.panel_usuarioEdicion.Controls.Add(this.textBox_numImagenes);
            this.panel_usuarioEdicion.Controls.Add(this.textBox_numFirmas);
            this.panel_usuarioEdicion.Controls.Add(this.label_numEncuestas);
            this.panel_usuarioEdicion.Controls.Add(this.label_numMensajes);
            this.panel_usuarioEdicion.Controls.Add(this.label_numImagenes);
            this.panel_usuarioEdicion.Controls.Add(this.label_numFirmas);
            this.panel_usuarioEdicion.Controls.Add(this.textBox_adicional);
            this.panel_usuarioEdicion.Controls.Add(this.label_adicional);
            this.panel_usuarioEdicion.Controls.Add(this.textBox_contrasena);
            this.panel_usuarioEdicion.Controls.Add(this.label_contrasena);
            this.panel_usuarioEdicion.Controls.Add(this.textBox_dni);
            this.panel_usuarioEdicion.Controls.Add(this.label_dni);
            this.panel_usuarioEdicion.Controls.Add(this.checkBox_activo);
            this.panel_usuarioEdicion.Controls.Add(this.textBox_usuario);
            this.panel_usuarioEdicion.Controls.Add(this.label_usuario);
            this.panel_usuarioEdicion.Controls.Add(this.checkBox_administrador);
            this.panel_usuarioEdicion.Controls.Add(this.label_fechaDeIngreso);
            this.panel_usuarioEdicion.Controls.Add(this.textBox_email);
            this.panel_usuarioEdicion.Controls.Add(this.textBox_nombre);
            this.panel_usuarioEdicion.Controls.Add(this.label_email);
            this.panel_usuarioEdicion.Controls.Add(this.label_nombre);
            this.panel_usuarioEdicion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_usuarioEdicion.Location = new System.Drawing.Point(3, 3);
            this.panel_usuarioEdicion.Name = "panel_usuarioEdicion";
            this.panel_usuarioEdicion.Size = new System.Drawing.Size(759, 285);
            this.panel_usuarioEdicion.TabIndex = 37;
            // 
            // textBox_id
            // 
            this.textBox_id.Location = new System.Drawing.Point(241, 11);
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.ReadOnly = true;
            this.textBox_id.Size = new System.Drawing.Size(49, 20);
            this.textBox_id.TabIndex = 93;
            this.textBox_id.TabStop = false;
            this.toolTip1.SetToolTip(this.textBox_id, "Número de ID del usuario");
            // 
            // label_id
            // 
            this.label_id.AutoSize = true;
            this.label_id.Location = new System.Drawing.Point(214, 14);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(21, 13);
            this.label_id.TabIndex = 92;
            this.label_id.Text = "ID:";
            // 
            // linkLabel_verEncuestas
            // 
            this.linkLabel_verEncuestas.AutoSize = true;
            this.linkLabel_verEncuestas.Location = new System.Drawing.Point(558, 142);
            this.linkLabel_verEncuestas.Name = "linkLabel_verEncuestas";
            this.linkLabel_verEncuestas.Size = new System.Drawing.Size(74, 13);
            this.linkLabel_verEncuestas.TabIndex = 91;
            this.linkLabel_verEncuestas.TabStop = true;
            this.linkLabel_verEncuestas.Text = "ver encuestas";
            this.toolTip1.SetToolTip(this.linkLabel_verEncuestas, "Acceder a las encuestas del usuario");
            this.linkLabel_verEncuestas.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_verEncuestas_LinkClicked);
            // 
            // linkLabel_verMensajes
            // 
            this.linkLabel_verMensajes.AutoSize = true;
            this.linkLabel_verMensajes.Location = new System.Drawing.Point(558, 112);
            this.linkLabel_verMensajes.Name = "linkLabel_verMensajes";
            this.linkLabel_verMensajes.Size = new System.Drawing.Size(69, 13);
            this.linkLabel_verMensajes.TabIndex = 90;
            this.linkLabel_verMensajes.TabStop = true;
            this.linkLabel_verMensajes.Text = "ver mensajes";
            this.toolTip1.SetToolTip(this.linkLabel_verMensajes, "Acceder a los mensajes del usuario");
            this.linkLabel_verMensajes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_verMensajes_LinkClicked);
            // 
            // linkLabel_verImagenes
            // 
            this.linkLabel_verImagenes.AutoSize = true;
            this.linkLabel_verImagenes.Location = new System.Drawing.Point(558, 80);
            this.linkLabel_verImagenes.Name = "linkLabel_verImagenes";
            this.linkLabel_verImagenes.Size = new System.Drawing.Size(70, 13);
            this.linkLabel_verImagenes.TabIndex = 89;
            this.linkLabel_verImagenes.TabStop = true;
            this.linkLabel_verImagenes.Text = "ver imágenes";
            this.toolTip1.SetToolTip(this.linkLabel_verImagenes, "Acceder a las imágenes del usuario");
            this.linkLabel_verImagenes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_verImagenes_LinkClicked);
            // 
            // linkLabel_verFirmas
            // 
            this.linkLabel_verFirmas.AutoSize = true;
            this.linkLabel_verFirmas.Location = new System.Drawing.Point(558, 49);
            this.linkLabel_verFirmas.Name = "linkLabel_verFirmas";
            this.linkLabel_verFirmas.Size = new System.Drawing.Size(52, 13);
            this.linkLabel_verFirmas.TabIndex = 88;
            this.linkLabel_verFirmas.TabStop = true;
            this.linkLabel_verFirmas.Text = "ver firmas";
            this.toolTip1.SetToolTip(this.linkLabel_verFirmas, "Acceder a las firmas del usuario");
            this.linkLabel_verFirmas.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_verFirmas_LinkClicked);
            // 
            // textBox_numEncuestas
            // 
            this.textBox_numEncuestas.Location = new System.Drawing.Point(502, 139);
            this.textBox_numEncuestas.Name = "textBox_numEncuestas";
            this.textBox_numEncuestas.ReadOnly = true;
            this.textBox_numEncuestas.Size = new System.Drawing.Size(38, 20);
            this.textBox_numEncuestas.TabIndex = 87;
            this.toolTip1.SetToolTip(this.textBox_numEncuestas, "Encuestas realizadas por el usuario");
            // 
            // textBox_numMensajes
            // 
            this.textBox_numMensajes.Location = new System.Drawing.Point(502, 108);
            this.textBox_numMensajes.Name = "textBox_numMensajes";
            this.textBox_numMensajes.ReadOnly = true;
            this.textBox_numMensajes.Size = new System.Drawing.Size(38, 20);
            this.textBox_numMensajes.TabIndex = 86;
            this.toolTip1.SetToolTip(this.textBox_numMensajes, "Mensajes enviados por el usuario");
            // 
            // textBox_numImagenes
            // 
            this.textBox_numImagenes.Location = new System.Drawing.Point(502, 77);
            this.textBox_numImagenes.Name = "textBox_numImagenes";
            this.textBox_numImagenes.ReadOnly = true;
            this.textBox_numImagenes.Size = new System.Drawing.Size(38, 20);
            this.textBox_numImagenes.TabIndex = 85;
            this.toolTip1.SetToolTip(this.textBox_numImagenes, "Imágenes realizadas por el usuario");
            // 
            // textBox_numFirmas
            // 
            this.textBox_numFirmas.Location = new System.Drawing.Point(502, 46);
            this.textBox_numFirmas.Name = "textBox_numFirmas";
            this.textBox_numFirmas.ReadOnly = true;
            this.textBox_numFirmas.Size = new System.Drawing.Size(38, 20);
            this.textBox_numFirmas.TabIndex = 84;
            this.toolTip1.SetToolTip(this.textBox_numFirmas, "Firmas realizadas por el usuario");
            // 
            // label_numEncuestas
            // 
            this.label_numEncuestas.AutoSize = true;
            this.label_numEncuestas.Location = new System.Drawing.Point(402, 141);
            this.label_numEncuestas.Name = "label_numEncuestas";
            this.label_numEncuestas.Size = new System.Drawing.Size(92, 13);
            this.label_numEncuestas.TabIndex = 83;
            this.label_numEncuestas.Text = "Nº de encuestas: ";
            // 
            // label_numMensajes
            // 
            this.label_numMensajes.AutoSize = true;
            this.label_numMensajes.Location = new System.Drawing.Point(402, 112);
            this.label_numMensajes.Name = "label_numMensajes";
            this.label_numMensajes.Size = new System.Drawing.Size(87, 13);
            this.label_numMensajes.TabIndex = 82;
            this.label_numMensajes.Text = "Nº de mensajes: ";
            // 
            // label_numImagenes
            // 
            this.label_numImagenes.AutoSize = true;
            this.label_numImagenes.Location = new System.Drawing.Point(402, 82);
            this.label_numImagenes.Name = "label_numImagenes";
            this.label_numImagenes.Size = new System.Drawing.Size(88, 13);
            this.label_numImagenes.TabIndex = 81;
            this.label_numImagenes.Text = "Nº de imágenes: ";
            // 
            // label_numFirmas
            // 
            this.label_numFirmas.AutoSize = true;
            this.label_numFirmas.Location = new System.Drawing.Point(402, 52);
            this.label_numFirmas.Name = "label_numFirmas";
            this.label_numFirmas.Size = new System.Drawing.Size(70, 13);
            this.label_numFirmas.TabIndex = 80;
            this.label_numFirmas.Text = "Nº de firmas: ";
            // 
            // textBox_adicional
            // 
            this.textBox_adicional.Location = new System.Drawing.Point(80, 158);
            this.textBox_adicional.Multiline = true;
            this.textBox_adicional.Name = "textBox_adicional";
            this.textBox_adicional.Size = new System.Drawing.Size(238, 116);
            this.textBox_adicional.TabIndex = 77;
            this.toolTip1.SetToolTip(this.textBox_adicional, "Información adicional sobre el usuario");
            // 
            // label_adicional
            // 
            this.label_adicional.AutoSize = true;
            this.label_adicional.Location = new System.Drawing.Point(7, 165);
            this.label_adicional.Name = "label_adicional";
            this.label_adicional.Size = new System.Drawing.Size(56, 13);
            this.label_adicional.TabIndex = 78;
            this.label_adicional.Text = "Adicional: ";
            // 
            // textBox_contrasena
            // 
            this.textBox_contrasena.Location = new System.Drawing.Point(80, 41);
            this.textBox_contrasena.Name = "textBox_contrasena";
            this.textBox_contrasena.Size = new System.Drawing.Size(120, 20);
            this.textBox_contrasena.TabIndex = 73;
            this.toolTip1.SetToolTip(this.textBox_contrasena, "Contraseña del usuario");
            // 
            // label_contrasena
            // 
            this.label_contrasena.AutoSize = true;
            this.label_contrasena.Location = new System.Drawing.Point(7, 44);
            this.label_contrasena.Name = "label_contrasena";
            this.label_contrasena.Size = new System.Drawing.Size(67, 13);
            this.label_contrasena.TabIndex = 76;
            this.label_contrasena.Text = "Contraseña: ";
            // 
            // textBox_dni
            // 
            this.textBox_dni.Location = new System.Drawing.Point(80, 128);
            this.textBox_dni.Name = "textBox_dni";
            this.textBox_dni.Size = new System.Drawing.Size(120, 20);
            this.textBox_dni.TabIndex = 76;
            this.toolTip1.SetToolTip(this.textBox_dni, "DNI del usuario");
            // 
            // label_dni
            // 
            this.label_dni.AutoSize = true;
            this.label_dni.Location = new System.Drawing.Point(7, 131);
            this.label_dni.Name = "label_dni";
            this.label_dni.Size = new System.Drawing.Size(32, 13);
            this.label_dni.TabIndex = 74;
            this.label_dni.Text = "DNI: ";
            // 
            // checkBox_activo
            // 
            this.checkBox_activo.AutoSize = true;
            this.checkBox_activo.Location = new System.Drawing.Point(405, 182);
            this.checkBox_activo.Name = "checkBox_activo";
            this.checkBox_activo.Size = new System.Drawing.Size(56, 17);
            this.checkBox_activo.TabIndex = 79;
            this.checkBox_activo.Text = "Activo";
            this.toolTip1.SetToolTip(this.checkBox_activo, "Seleccionar si el usuario está activo o no");
            this.checkBox_activo.UseVisualStyleBackColor = true;
            // 
            // textBox_usuario
            // 
            this.textBox_usuario.Location = new System.Drawing.Point(80, 11);
            this.textBox_usuario.Name = "textBox_usuario";
            this.textBox_usuario.Size = new System.Drawing.Size(120, 20);
            this.textBox_usuario.TabIndex = 72;
            this.toolTip1.SetToolTip(this.textBox_usuario, "Nick o Apodo del usuario");
            // 
            // label_usuario
            // 
            this.label_usuario.AutoSize = true;
            this.label_usuario.Location = new System.Drawing.Point(7, 14);
            this.label_usuario.Name = "label_usuario";
            this.label_usuario.Size = new System.Drawing.Size(49, 13);
            this.label_usuario.TabIndex = 71;
            this.label_usuario.Text = "Usuario: ";
            // 
            // checkBox_administrador
            // 
            this.checkBox_administrador.AutoSize = true;
            this.checkBox_administrador.Location = new System.Drawing.Point(405, 218);
            this.checkBox_administrador.Name = "checkBox_administrador";
            this.checkBox_administrador.Size = new System.Drawing.Size(89, 17);
            this.checkBox_administrador.TabIndex = 80;
            this.checkBox_administrador.Text = "Administrador";
            this.toolTip1.SetToolTip(this.checkBox_administrador, "Seleccionar si el usuario es administrador o no");
            this.checkBox_administrador.UseVisualStyleBackColor = true;
            // 
            // label_fechaDeIngreso
            // 
            this.label_fechaDeIngreso.AutoSize = true;
            this.label_fechaDeIngreso.Location = new System.Drawing.Point(402, 14);
            this.label_fechaDeIngreso.Name = "label_fechaDeIngreso";
            this.label_fechaDeIngreso.Size = new System.Drawing.Size(95, 13);
            this.label_fechaDeIngreso.TabIndex = 68;
            this.label_fechaDeIngreso.Text = "Fecha de ingreso: ";
            // 
            // textBox_email
            // 
            this.textBox_email.Location = new System.Drawing.Point(80, 99);
            this.textBox_email.Name = "textBox_email";
            this.textBox_email.Size = new System.Drawing.Size(120, 20);
            this.textBox_email.TabIndex = 75;
            this.toolTip1.SetToolTip(this.textBox_email, "Dirección de correo electrónico del usuario");
            // 
            // textBox_nombre
            // 
            this.textBox_nombre.Location = new System.Drawing.Point(80, 70);
            this.textBox_nombre.Name = "textBox_nombre";
            this.textBox_nombre.Size = new System.Drawing.Size(120, 20);
            this.textBox_nombre.TabIndex = 74;
            this.toolTip1.SetToolTip(this.textBox_nombre, "Nombre de pila del usuario");
            // 
            // label_email
            // 
            this.label_email.AutoSize = true;
            this.label_email.Location = new System.Drawing.Point(7, 102);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(38, 13);
            this.label_email.TabIndex = 66;
            this.label_email.Text = "Email: ";
            // 
            // label_nombre
            // 
            this.label_nombre.AutoSize = true;
            this.label_nombre.Location = new System.Drawing.Point(7, 73);
            this.label_nombre.Name = "label_nombre";
            this.label_nombre.Size = new System.Drawing.Size(50, 13);
            this.label_nombre.TabIndex = 63;
            this.label_nombre.Text = "Nombre: ";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dateTimePicker_fechaDeIngreso
            // 
            this.dateTimePicker_fechaDeIngreso.CustomFormat = "dddd, dd \'de\' MMMM \'de\' yyyy, H:mm:ss";
            this.dateTimePicker_fechaDeIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_fechaDeIngreso.Location = new System.Drawing.Point(502, 11);
            this.dateTimePicker_fechaDeIngreso.Name = "dateTimePicker_fechaDeIngreso";
            this.dateTimePicker_fechaDeIngreso.ShowUpDown = true;
            this.dateTimePicker_fechaDeIngreso.Size = new System.Drawing.Size(250, 20);
            this.dateTimePicker_fechaDeIngreso.TabIndex = 94;
            this.toolTip1.SetToolTip(this.dateTimePicker_fechaDeIngreso, "Fecha de creación de la encuesta");
            // 
            // FormUsuarioEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel_formEdicion);
            this.Name = "FormUsuarioEdicion";
            this.Size = new System.Drawing.Size(765, 325);
            this.tableLayoutPanel_formEdicion.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel_usuarioEdicion.ResumeLayout(false);
            this.panel_usuarioEdicion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_formEdicion;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_descartarCambios;
        private System.Windows.Forms.Button button_guardarCambios;
        private System.Windows.Forms.Panel panel_usuarioEdicion;
        private System.Windows.Forms.TextBox textBox_usuario;
        private System.Windows.Forms.Label label_usuario;
        private System.Windows.Forms.CheckBox checkBox_administrador;
        private System.Windows.Forms.Label label_fechaDeIngreso;
        private System.Windows.Forms.TextBox textBox_email;
        private System.Windows.Forms.TextBox textBox_nombre;
        private System.Windows.Forms.Label label_email;
        private System.Windows.Forms.Label label_nombre;
        private System.Windows.Forms.CheckBox checkBox_activo;
        private System.Windows.Forms.TextBox textBox_dni;
        private System.Windows.Forms.Label label_dni;
        private System.Windows.Forms.TextBox textBox_contrasena;
        private System.Windows.Forms.Label label_contrasena;
        private System.Windows.Forms.TextBox textBox_adicional;
        private System.Windows.Forms.Label label_adicional;
        private System.Windows.Forms.Label label_numMensajes;
        private System.Windows.Forms.Label label_numImagenes;
        private System.Windows.Forms.Label label_numFirmas;
        private System.Windows.Forms.TextBox textBox_numFirmas;
        private System.Windows.Forms.Label label_numEncuestas;
        private System.Windows.Forms.TextBox textBox_numEncuestas;
        private System.Windows.Forms.TextBox textBox_numMensajes;
        private System.Windows.Forms.TextBox textBox_numImagenes;
        private System.Windows.Forms.LinkLabel linkLabel_verEncuestas;
        private System.Windows.Forms.LinkLabel linkLabel_verMensajes;
        private System.Windows.Forms.LinkLabel linkLabel_verImagenes;
        private System.Windows.Forms.LinkLabel linkLabel_verFirmas;
        private System.Windows.Forms.TextBox textBox_id;
        private System.Windows.Forms.Label label_id;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_fechaDeIngreso;

    }
}
