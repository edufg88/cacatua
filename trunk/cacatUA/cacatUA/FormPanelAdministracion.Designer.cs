namespace cacatUA
{
    partial class FormPanelAdministracion
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel_botones = new System.Windows.Forms.TableLayoutPanel();
            this.button_categorias = new System.Windows.Forms.Button();
            this.button_general = new System.Windows.Forms.Button();
            this.button_usuarios = new System.Windows.Forms.Button();
            this.button_materiales = new System.Windows.Forms.Button();
            this.button_grupos = new System.Windows.Forms.Button();
            this.button_foro = new System.Windows.Forms.Button();
            this.button_peticiones = new System.Windows.Forms.Button();
            this.button_salir = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.toolTip_avanzado = new System.Windows.Forms.ToolTip(this.components);
            this.button_volver = new System.Windows.Forms.Button();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.flowLayoutPanel_navegacion = new System.Windows.Forms.FlowLayoutPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel_navegacion = new System.Windows.Forms.Panel();
            this.tableLayoutPanel_botones.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel_navegacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_botones
            // 
            this.tableLayoutPanel_botones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.tableLayoutPanel_botones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tableLayoutPanel_botones.ColumnCount = 1;
            this.tableLayoutPanel_botones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_botones.Controls.Add(this.button_categorias, 0, 6);
            this.tableLayoutPanel_botones.Controls.Add(this.button_general, 0, 0);
            this.tableLayoutPanel_botones.Controls.Add(this.button_usuarios, 0, 1);
            this.tableLayoutPanel_botones.Controls.Add(this.button_materiales, 0, 2);
            this.tableLayoutPanel_botones.Controls.Add(this.button_grupos, 0, 5);
            this.tableLayoutPanel_botones.Controls.Add(this.button_foro, 0, 3);
            this.tableLayoutPanel_botones.Controls.Add(this.button_peticiones, 0, 4);
            this.tableLayoutPanel_botones.Controls.Add(this.button_salir, 0, 7);
            this.tableLayoutPanel_botones.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_botones.Name = "tableLayoutPanel_botones";
            this.tableLayoutPanel_botones.RowCount = 8;
            this.tableLayoutPanel_botones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel_botones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel_botones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel_botones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel_botones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel_botones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel_botones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel_botones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_botones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_botones.Size = new System.Drawing.Size(197, 528);
            this.tableLayoutPanel_botones.TabIndex = 1;
            // 
            // button_categorias
            // 
            this.button_categorias.FlatAppearance.BorderSize = 0;
            this.button_categorias.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
            this.button_categorias.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.button_categorias.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button_categorias.Image = global::cacatUA.Properties.Resources.categorias;
            this.button_categorias.Location = new System.Drawing.Point(3, 273);
            this.button_categorias.Name = "button_categorias";
            this.button_categorias.Size = new System.Drawing.Size(190, 39);
            this.button_categorias.TabIndex = 6;
            this.button_categorias.UseVisualStyleBackColor = true;
            this.button_categorias.Click += new System.EventHandler(this.button_categorias_Click);
            // 
            // button_general
            // 
            this.button_general.FlatAppearance.BorderSize = 0;
            this.button_general.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
            this.button_general.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.button_general.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button_general.Image = global::cacatUA.Properties.Resources.general;
            this.button_general.Location = new System.Drawing.Point(3, 3);
            this.button_general.Name = "button_general";
            this.button_general.Size = new System.Drawing.Size(190, 39);
            this.button_general.TabIndex = 0;
            this.button_general.UseVisualStyleBackColor = true;
            this.button_general.Click += new System.EventHandler(this.button_general_Click);
            // 
            // button_usuarios
            // 
            this.button_usuarios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_usuarios.FlatAppearance.BorderSize = 0;
            this.button_usuarios.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
            this.button_usuarios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.button_usuarios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button_usuarios.Image = global::cacatUA.Properties.Resources.usuarios;
            this.button_usuarios.Location = new System.Drawing.Point(3, 48);
            this.button_usuarios.Name = "button_usuarios";
            this.button_usuarios.Size = new System.Drawing.Size(190, 39);
            this.button_usuarios.TabIndex = 1;
            this.button_usuarios.UseVisualStyleBackColor = true;
            this.button_usuarios.Click += new System.EventHandler(this.button_usuarios_Click);
            // 
            // button_materiales
            // 
            this.button_materiales.FlatAppearance.BorderSize = 0;
            this.button_materiales.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
            this.button_materiales.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.button_materiales.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button_materiales.Image = global::cacatUA.Properties.Resources.materiales;
            this.button_materiales.Location = new System.Drawing.Point(3, 93);
            this.button_materiales.Name = "button_materiales";
            this.button_materiales.Size = new System.Drawing.Size(190, 39);
            this.button_materiales.TabIndex = 2;
            this.button_materiales.UseVisualStyleBackColor = true;
            this.button_materiales.Click += new System.EventHandler(this.button_materiales_Click);
            // 
            // button_grupos
            // 
            this.button_grupos.FlatAppearance.BorderSize = 0;
            this.button_grupos.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
            this.button_grupos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.button_grupos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button_grupos.Image = global::cacatUA.Properties.Resources.personas;
            this.button_grupos.Location = new System.Drawing.Point(3, 228);
            this.button_grupos.Name = "button_grupos";
            this.button_grupos.Size = new System.Drawing.Size(190, 39);
            this.button_grupos.TabIndex = 5;
            this.button_grupos.UseVisualStyleBackColor = true;
            this.button_grupos.Click += new System.EventHandler(this.button_grupos_Click);
            // 
            // button_foro
            // 
            this.button_foro.FlatAppearance.BorderSize = 0;
            this.button_foro.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
            this.button_foro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.button_foro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button_foro.Image = global::cacatUA.Properties.Resources.foro;
            this.button_foro.Location = new System.Drawing.Point(3, 138);
            this.button_foro.Name = "button_foro";
            this.button_foro.Size = new System.Drawing.Size(190, 39);
            this.button_foro.TabIndex = 3;
            this.button_foro.UseVisualStyleBackColor = true;
            this.button_foro.Click += new System.EventHandler(this.button_foro_Click);
            // 
            // button_peticiones
            // 
            this.button_peticiones.FlatAppearance.BorderSize = 0;
            this.button_peticiones.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
            this.button_peticiones.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.button_peticiones.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button_peticiones.Image = global::cacatUA.Properties.Resources.peticiones;
            this.button_peticiones.Location = new System.Drawing.Point(3, 183);
            this.button_peticiones.Name = "button_peticiones";
            this.button_peticiones.Size = new System.Drawing.Size(190, 39);
            this.button_peticiones.TabIndex = 4;
            this.button_peticiones.UseVisualStyleBackColor = true;
            this.button_peticiones.Click += new System.EventHandler(this.button_peticiones_Click);
            // 
            // button_salir
            // 
            this.button_salir.FlatAppearance.BorderSize = 0;
            this.button_salir.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
            this.button_salir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.button_salir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button_salir.Image = global::cacatUA.Properties.Resources.salir;
            this.button_salir.Location = new System.Drawing.Point(3, 318);
            this.button_salir.Name = "button_salir";
            this.button_salir.Size = new System.Drawing.Size(190, 39);
            this.button_salir.TabIndex = 7;
            this.button_salir.UseVisualStyleBackColor = true;
            this.button_salir.Click += new System.EventHandler(this.button_salir_Click);
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.AutoScroll = true;
            this.panel.AutoScrollMinSize = new System.Drawing.Size(630, 0);
            this.panel.BackColor = System.Drawing.SystemColors.Control;
            this.panel.Location = new System.Drawing.Point(197, 27);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(784, 501);
            this.panel.TabIndex = 0;
            // 
            // toolTip_avanzado
            // 
            this.toolTip_avanzado.IsBalloon = true;
            this.toolTip_avanzado.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip_avanzado.ToolTipTitle = "Preparado para volver";
            // 
            // button_volver
            // 
            this.button_volver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.button_volver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_volver.FlatAppearance.BorderSize = 0;
            this.button_volver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_volver.Image = global::cacatUA.Properties.Resources.volver;
            this.button_volver.Location = new System.Drawing.Point(0, 0);
            this.button_volver.Margin = new System.Windows.Forms.Padding(0);
            this.button_volver.Name = "button_volver";
            this.button_volver.Size = new System.Drawing.Size(24, 24);
            this.button_volver.TabIndex = 2;
            this.toolTip1.SetToolTip(this.button_volver, "Vuelve al panel anterior");
            this.button_volver.UseVisualStyleBackColor = true;
            this.button_volver.Click += new System.EventHandler(this.button_volver_Click);
            // 
            // button_cancelar
            // 
            this.button_cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.button_cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_cancelar.FlatAppearance.BorderSize = 0;
            this.button_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_cancelar.Image = global::cacatUA.Properties.Resources.cancelar;
            this.button_cancelar.Location = new System.Drawing.Point(24, 0);
            this.button_cancelar.Margin = new System.Windows.Forms.Padding(0);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(24, 24);
            this.button_cancelar.TabIndex = 3;
            this.toolTip1.SetToolTip(this.button_cancelar, "Cancela la selección y vuelve al panel anterior");
            this.button_cancelar.UseVisualStyleBackColor = true;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // flowLayoutPanel_navegacion
            // 
            this.flowLayoutPanel_navegacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel_navegacion.Location = new System.Drawing.Point(48, 0);
            this.flowLayoutPanel_navegacion.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel_navegacion.Name = "flowLayoutPanel_navegacion";
            this.flowLayoutPanel_navegacion.Size = new System.Drawing.Size(736, 27);
            this.flowLayoutPanel_navegacion.TabIndex = 4;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 526);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(981, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // panel_navegacion
            // 
            this.panel_navegacion.Controls.Add(this.button_volver);
            this.panel_navegacion.Controls.Add(this.button_cancelar);
            this.panel_navegacion.Controls.Add(this.flowLayoutPanel_navegacion);
            this.panel_navegacion.Location = new System.Drawing.Point(197, 0);
            this.panel_navegacion.Margin = new System.Windows.Forms.Padding(0);
            this.panel_navegacion.Name = "panel_navegacion";
            this.panel_navegacion.Size = new System.Drawing.Size(784, 28);
            this.panel_navegacion.TabIndex = 6;
            // 
            // FormPanelAdministracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 548);
            this.Controls.Add(this.panel_navegacion);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.tableLayoutPanel_botones);
            this.Name = "FormPanelAdministracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel de administración";
            this.Load += new System.EventHandler(this.FormPanelAdministracion_Load);
            this.tableLayoutPanel_botones.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel_navegacion.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_usuarios;
        private System.Windows.Forms.Button button_general;
        private System.Windows.Forms.Button button_materiales;
        private System.Windows.Forms.Button button_foro;
        private System.Windows.Forms.Button button_peticiones;
        private System.Windows.Forms.Button button_grupos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_botones;
        private System.Windows.Forms.Button button_categorias;
        private System.Windows.Forms.Button button_salir;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button button_volver;
        private System.Windows.Forms.ToolTip toolTip_avanzado;
        private System.Windows.Forms.Button button_cancelar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_navegacion;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel_navegacion;


    }
}