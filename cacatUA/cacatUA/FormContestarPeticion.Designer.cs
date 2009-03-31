namespace cacatUA
{
    partial class FormContestarPeticion
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSalir = new System.Windows.Forms.Button();
            this.buttonEnviar = new System.Windows.Forms.Button();
            this.tableLayoutPanelDesc = new System.Windows.Forms.TableLayoutPanel();
            this.richTextBox_envPetRespuesta = new System.Windows.Forms.RichTextBox();
            this.panelDesc = new System.Windows.Forms.Panel();
            this.labelDesc = new System.Windows.Forms.Label();
            this.richTextBox_envPetPeticion = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanelAsunto = new System.Windows.Forms.TableLayoutPanel();
            this.panelAsunto = new System.Windows.Forms.Panel();
            this.labelAsunto = new System.Windows.Forms.Label();
            this.textBox_envPetAsunto = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelPara = new System.Windows.Forms.TableLayoutPanel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_envPetUsuario = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelDesc.SuspendLayout();
            this.panelDesc.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanelAsunto.SuspendLayout();
            this.panelAsunto.SuspendLayout();
            this.tableLayoutPanelPara.SuspendLayout();
            this.panel11.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSalir
            // 
            this.buttonSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSalir.Location = new System.Drawing.Point(673, 319);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(75, 23);
            this.buttonSalir.TabIndex = 121;
            this.buttonSalir.Text = "Salir";
            this.buttonSalir.UseVisualStyleBackColor = true;
            this.buttonSalir.Click += new System.EventHandler(this.buttonSalir_Click);
            // 
            // buttonEnviar
            // 
            this.buttonEnviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonEnviar.Location = new System.Drawing.Point(2, 319);
            this.buttonEnviar.Name = "buttonEnviar";
            this.buttonEnviar.Size = new System.Drawing.Size(75, 23);
            this.buttonEnviar.TabIndex = 120;
            this.buttonEnviar.Text = "Enviar";
            this.buttonEnviar.UseVisualStyleBackColor = true;
            this.buttonEnviar.Click += new System.EventHandler(this.buttonEnviar_Click);
            // 
            // tableLayoutPanelDesc
            // 
            this.tableLayoutPanelDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelDesc.ColumnCount = 1;
            this.tableLayoutPanelDesc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelDesc.Controls.Add(this.richTextBox_envPetRespuesta, 0, 3);
            this.tableLayoutPanelDesc.Controls.Add(this.panelDesc, 0, 0);
            this.tableLayoutPanelDesc.Controls.Add(this.richTextBox_envPetPeticion, 0, 1);
            this.tableLayoutPanelDesc.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanelDesc.Location = new System.Drawing.Point(2, 73);
            this.tableLayoutPanelDesc.Name = "tableLayoutPanelDesc";
            this.tableLayoutPanelDesc.RowCount = 4;
            this.tableLayoutPanelDesc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelDesc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDesc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelDesc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDesc.Size = new System.Drawing.Size(746, 239);
            this.tableLayoutPanelDesc.TabIndex = 119;
            // 
            // richTextBox_envPetRespuesta
            // 
            this.richTextBox_envPetRespuesta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_envPetRespuesta.Location = new System.Drawing.Point(3, 152);
            this.richTextBox_envPetRespuesta.Name = "richTextBox_envPetRespuesta";
            this.richTextBox_envPetRespuesta.Size = new System.Drawing.Size(740, 84);
            this.richTextBox_envPetRespuesta.TabIndex = 115;
            this.richTextBox_envPetRespuesta.Text = "descripción detallada del mensaje";
            // 
            // panelDesc
            // 
            this.panelDesc.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelDesc.Controls.Add(this.labelDesc);
            this.panelDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesc.Location = new System.Drawing.Point(3, 3);
            this.panelDesc.Name = "panelDesc";
            this.panelDesc.Size = new System.Drawing.Size(740, 24);
            this.panelDesc.TabIndex = 113;
            // 
            // labelDesc
            // 
            this.labelDesc.AutoSize = true;
            this.labelDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDesc.Location = new System.Drawing.Point(3, 5);
            this.labelDesc.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelDesc.Name = "labelDesc";
            this.labelDesc.Size = new System.Drawing.Size(53, 13);
            this.labelDesc.TabIndex = 88;
            this.labelDesc.Text = "Petición";
            // 
            // richTextBox_envPetPeticion
            // 
            this.richTextBox_envPetPeticion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_envPetPeticion.Location = new System.Drawing.Point(3, 33);
            this.richTextBox_envPetPeticion.Name = "richTextBox_envPetPeticion";
            this.richTextBox_envPetPeticion.ReadOnly = true;
            this.richTextBox_envPetPeticion.Size = new System.Drawing.Size(740, 83);
            this.richTextBox_envPetPeticion.TabIndex = 89;
            this.richTextBox_envPetPeticion.Text = "peticion del usuario";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 122);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(740, 24);
            this.panel1.TabIndex = 114;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 88;
            this.label1.Text = "Respuesta";
            // 
            // tableLayoutPanelAsunto
            // 
            this.tableLayoutPanelAsunto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelAsunto.ColumnCount = 2;
            this.tableLayoutPanelAsunto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanelAsunto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelAsunto.Controls.Add(this.panelAsunto, 0, 0);
            this.tableLayoutPanelAsunto.Controls.Add(this.textBox_envPetAsunto, 1, 0);
            this.tableLayoutPanelAsunto.Location = new System.Drawing.Point(2, 40);
            this.tableLayoutPanelAsunto.Name = "tableLayoutPanelAsunto";
            this.tableLayoutPanelAsunto.RowCount = 1;
            this.tableLayoutPanelAsunto.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelAsunto.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanelAsunto.Size = new System.Drawing.Size(746, 27);
            this.tableLayoutPanelAsunto.TabIndex = 118;
            // 
            // panelAsunto
            // 
            this.panelAsunto.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelAsunto.Controls.Add(this.labelAsunto);
            this.panelAsunto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAsunto.Location = new System.Drawing.Point(3, 3);
            this.panelAsunto.Name = "panelAsunto";
            this.panelAsunto.Size = new System.Drawing.Size(122, 21);
            this.panelAsunto.TabIndex = 113;
            // 
            // labelAsunto
            // 
            this.labelAsunto.AutoSize = true;
            this.labelAsunto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAsunto.ForeColor = System.Drawing.Color.Black;
            this.labelAsunto.Location = new System.Drawing.Point(3, 3);
            this.labelAsunto.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.labelAsunto.Name = "labelAsunto";
            this.labelAsunto.Size = new System.Drawing.Size(46, 13);
            this.labelAsunto.TabIndex = 84;
            this.labelAsunto.Text = "Asunto";
            // 
            // textBox_envPetAsunto
            // 
            this.textBox_envPetAsunto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_envPetAsunto.Location = new System.Drawing.Point(131, 3);
            this.textBox_envPetAsunto.Name = "textBox_envPetAsunto";
            this.textBox_envPetAsunto.ReadOnly = true;
            this.textBox_envPetAsunto.Size = new System.Drawing.Size(612, 20);
            this.textBox_envPetAsunto.TabIndex = 85;
            // 
            // tableLayoutPanelPara
            // 
            this.tableLayoutPanelPara.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelPara.ColumnCount = 2;
            this.tableLayoutPanelPara.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanelPara.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPara.Controls.Add(this.panel11, 0, 0);
            this.tableLayoutPanelPara.Controls.Add(this.textBox_envPetUsuario, 1, 0);
            this.tableLayoutPanelPara.Location = new System.Drawing.Point(2, 10);
            this.tableLayoutPanelPara.Name = "tableLayoutPanelPara";
            this.tableLayoutPanelPara.RowCount = 1;
            this.tableLayoutPanelPara.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPara.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanelPara.Size = new System.Drawing.Size(746, 27);
            this.tableLayoutPanelPara.TabIndex = 117;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel11.Controls.Add(this.label9);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(3, 3);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(94, 21);
            this.panel11.TabIndex = 113;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(3, 3);
            this.label9.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 84;
            this.label9.Text = "Para";
            // 
            // textBox_envPetUsuario
            // 
            this.textBox_envPetUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_envPetUsuario.Location = new System.Drawing.Point(103, 3);
            this.textBox_envPetUsuario.Name = "textBox_envPetUsuario";
            this.textBox_envPetUsuario.ReadOnly = true;
            this.textBox_envPetUsuario.Size = new System.Drawing.Size(640, 20);
            this.textBox_envPetUsuario.TabIndex = 85;
            // 
            // FormContestarPeticion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 352);
            this.Controls.Add(this.buttonSalir);
            this.Controls.Add(this.buttonEnviar);
            this.Controls.Add(this.tableLayoutPanelDesc);
            this.Controls.Add(this.tableLayoutPanelAsunto);
            this.Controls.Add(this.tableLayoutPanelPara);
            this.Name = "FormContestarPeticion";
            this.Text = "FormContestarPeticion";
            this.tableLayoutPanelDesc.ResumeLayout(false);
            this.panelDesc.ResumeLayout(false);
            this.panelDesc.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanelAsunto.ResumeLayout(false);
            this.tableLayoutPanelAsunto.PerformLayout();
            this.panelAsunto.ResumeLayout(false);
            this.panelAsunto.PerformLayout();
            this.tableLayoutPanelPara.ResumeLayout(false);
            this.tableLayoutPanelPara.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSalir;
        private System.Windows.Forms.Button buttonEnviar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDesc;
        private System.Windows.Forms.RichTextBox richTextBox_envPetRespuesta;
        private System.Windows.Forms.Panel panelDesc;
        private System.Windows.Forms.Label labelDesc;
        private System.Windows.Forms.RichTextBox richTextBox_envPetPeticion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelAsunto;
        private System.Windows.Forms.Panel panelAsunto;
        private System.Windows.Forms.Label labelAsunto;
        private System.Windows.Forms.TextBox textBox_envPetAsunto;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPara;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_envPetUsuario;
    }
}