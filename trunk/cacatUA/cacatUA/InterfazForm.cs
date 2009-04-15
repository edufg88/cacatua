using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cacatUA
{
    public partial class InterfazForm : UserControl
    {
        virtual public Object Enviar()
        {
            return null;
        }

        virtual public void Recibir(Object objeto)
        {

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // InterfazForm
            // 
            this.Name = "InterfazForm";
            this.Load += new System.EventHandler(this.InterfazForm_Load);
            this.ResumeLayout(false);

        }
    }
}
