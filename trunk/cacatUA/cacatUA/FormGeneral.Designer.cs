namespace cacatUA
{
    partial class FormGeneral
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
            this.panel_contenedor = new System.Windows.Forms.Panel();
            this.propertyGrid_resumenSistema = new System.Windows.Forms.PropertyGrid();
            this.panel_cabeceraSeccion1 = new System.Windows.Forms.Panel();
            this.label_seccion1 = new System.Windows.Forms.Label();
            this.panel_opciones = new System.Windows.Forms.Panel();
            this.button_seccionRefrescar = new System.Windows.Forms.Button();
            this.panel_cabecera = new System.Windows.Forms.Panel();
            this.label_general = new System.Windows.Forms.Label();
            this.tableLayoutPanel_principal = new System.Windows.Forms.TableLayoutPanel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel_contenedor.SuspendLayout();
            this.panel_cabeceraSeccion1.SuspendLayout();
            this.panel_opciones.SuspendLayout();
            this.panel_cabecera.SuspendLayout();
            this.tableLayoutPanel_principal.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_contenedor
            // 
            this.panel_contenedor.Controls.Add(this.propertyGrid_resumenSistema);
            this.panel_contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_contenedor.Location = new System.Drawing.Point(0, 110);
            this.panel_contenedor.Margin = new System.Windows.Forms.Padding(0);
            this.panel_contenedor.Name = "panel_contenedor";
            this.panel_contenedor.Size = new System.Drawing.Size(695, 456);
            this.panel_contenedor.TabIndex = 7;
            // 
            // propertyGrid_resumenSistema
            // 
            this.propertyGrid_resumenSistema.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.propertyGrid_resumenSistema.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid_resumenSistema.Location = new System.Drawing.Point(3, 3);
            this.propertyGrid_resumenSistema.Name = "propertyGrid_resumenSistema";
            this.propertyGrid_resumenSistema.Size = new System.Drawing.Size(689, 450);
            this.propertyGrid_resumenSistema.TabIndex = 0;
            this.propertyGrid_resumenSistema.ToolbarVisible = false;
            // 
            // panel_cabeceraSeccion1
            // 
            this.panel_cabeceraSeccion1.BackColor = System.Drawing.Color.LightGray;
            this.panel_cabeceraSeccion1.Controls.Add(this.label_seccion1);
            this.panel_cabeceraSeccion1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_cabeceraSeccion1.Location = new System.Drawing.Point(3, 78);
            this.panel_cabeceraSeccion1.Name = "panel_cabeceraSeccion1";
            this.panel_cabeceraSeccion1.Size = new System.Drawing.Size(689, 29);
            this.panel_cabeceraSeccion1.TabIndex = 2;
            // 
            // label_seccion1
            // 
            this.label_seccion1.AutoSize = true;
            this.label_seccion1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_seccion1.Location = new System.Drawing.Point(13, 8);
            this.label_seccion1.Name = "label_seccion1";
            this.label_seccion1.Size = new System.Drawing.Size(126, 13);
            this.label_seccion1.TabIndex = 0;
            this.label_seccion1.Text = "Resumen del sistema";
            // 
            // panel_opciones
            // 
            this.panel_opciones.Controls.Add(this.button_seccionRefrescar);
            this.panel_opciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_opciones.Location = new System.Drawing.Point(0, 30);
            this.panel_opciones.Margin = new System.Windows.Forms.Padding(0);
            this.panel_opciones.Name = "panel_opciones";
            this.panel_opciones.Size = new System.Drawing.Size(695, 45);
            this.panel_opciones.TabIndex = 1;
            // 
            // button_seccionRefrescar
            // 
            this.button_seccionRefrescar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_seccionRefrescar.FlatAppearance.BorderSize = 0;
            this.button_seccionRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_seccionRefrescar.Image = global::cacatUA.Properties.Resources.refrescar;
            this.button_seccionRefrescar.Location = new System.Drawing.Point(3, 2);
            this.button_seccionRefrescar.Name = "button_seccionRefrescar";
            this.button_seccionRefrescar.Size = new System.Drawing.Size(36, 36);
            this.button_seccionRefrescar.TabIndex = 0;
            this.toolTip1.SetToolTip(this.button_seccionRefrescar, "Actualiza la tabla de datos");
            this.button_seccionRefrescar.UseVisualStyleBackColor = true;
            this.button_seccionRefrescar.Click += new System.EventHandler(this.button_seccionRefrescar_Click);
            // 
            // panel_cabecera
            // 
            this.panel_cabecera.BackColor = System.Drawing.Color.Gray;
            this.panel_cabecera.Controls.Add(this.label_general);
            this.panel_cabecera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_cabecera.Location = new System.Drawing.Point(0, 0);
            this.panel_cabecera.Margin = new System.Windows.Forms.Padding(0);
            this.panel_cabecera.Name = "panel_cabecera";
            this.panel_cabecera.Size = new System.Drawing.Size(695, 30);
            this.panel_cabecera.TabIndex = 0;
            // 
            // label_general
            // 
            this.label_general.AutoSize = true;
            this.label_general.BackColor = System.Drawing.Color.Gray;
            this.label_general.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_general.ForeColor = System.Drawing.Color.White;
            this.label_general.Location = new System.Drawing.Point(11, 7);
            this.label_general.Name = "label_general";
            this.label_general.Size = new System.Drawing.Size(59, 17);
            this.label_general.TabIndex = 0;
            this.label_general.Text = "General";
            // 
            // tableLayoutPanel_principal
            // 
            this.tableLayoutPanel_principal.ColumnCount = 1;
            this.tableLayoutPanel_principal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_principal.Controls.Add(this.panel_cabecera, 0, 0);
            this.tableLayoutPanel_principal.Controls.Add(this.panel_opciones, 0, 1);
            this.tableLayoutPanel_principal.Controls.Add(this.panel_cabeceraSeccion1, 0, 2);
            this.tableLayoutPanel_principal.Controls.Add(this.panel_contenedor, 0, 3);
            this.tableLayoutPanel_principal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_principal.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_principal.Name = "tableLayoutPanel_principal";
            this.tableLayoutPanel_principal.RowCount = 4;
            this.tableLayoutPanel_principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel_principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel_principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.tableLayoutPanel_principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_principal.Size = new System.Drawing.Size(695, 566);
            this.tableLayoutPanel_principal.TabIndex = 1;
            // 
            // FormGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel_principal);
            this.Name = "FormGeneral";
            this.Size = new System.Drawing.Size(695, 566);
            this.panel_contenedor.ResumeLayout(false);
            this.panel_cabeceraSeccion1.ResumeLayout(false);
            this.panel_cabeceraSeccion1.PerformLayout();
            this.panel_opciones.ResumeLayout(false);
            this.panel_cabecera.ResumeLayout(false);
            this.panel_cabecera.PerformLayout();
            this.tableLayoutPanel_principal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_contenedor;
        private System.Windows.Forms.Panel panel_cabeceraSeccion1;
        private System.Windows.Forms.Label label_seccion1;
        private System.Windows.Forms.Panel panel_opciones;
        private System.Windows.Forms.Panel panel_cabecera;
        private System.Windows.Forms.Label label_general;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_principal;
        private System.Windows.Forms.PropertyGrid propertyGrid_resumenSistema;
        private System.Windows.Forms.Button button_seccionRefrescar;
        private System.Windows.Forms.ToolTip toolTip1;







    }
}
