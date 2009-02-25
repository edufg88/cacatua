namespace fBase
{
    partial class fBase
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.unoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unoToolStripMenuItem,
            this.dosToolStripMenuItem,
            this.tresToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(581, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // unoToolStripMenuItem
            // 
            this.unoToolStripMenuItem.Name = "unoToolStripMenuItem";
            this.unoToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.unoToolStripMenuItem.Text = "Uno";
            // 
            // dosToolStripMenuItem
            // 
            this.dosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.dosToolStripMenuItem.Name = "dosToolStripMenuItem";
            this.dosToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.dosToolStripMenuItem.Text = "Dos";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.menuToolStripMenuItem.Text = "Menu";
            this.menuToolStripMenuItem.Click += new System.EventHandler(this.menuToolStripMenuItem_Click);
            // 
            // tresToolStripMenuItem
            // 
            this.tresToolStripMenuItem.Name = "tresToolStripMenuItem";
            this.tresToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.tresToolStripMenuItem.Text = "Tres";
            // 
            // fBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 305);
            this.Controls.Add(this.menuStrip1);
            this.Name = "fBase";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem unoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
    }
}

