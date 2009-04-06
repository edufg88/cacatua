using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cacatUA
{
    abstract public partial class InterfazForm : UserControl
    {
        abstract public Object Enviar();
        abstract public void Recibir(Object objeto);
    }
}
