using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Libreria;

namespace cacatUA
{
    public partial class FormGruposBusqueda : UserControl
    {
        public FormGruposBusqueda()
        {
            InitializeComponent();
        }

        private void button_buscar_Click(object sender, EventArgs e)
        {
            int a = 0, b = 0;
            if (numericUpDown_numUsuarios1.Value > numericUpDown_numUsuarios2.Value)
            {
                MessageBox.Show("El primer valor de usuarios debe ser menor que el segundo", "Ventana de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                a = int.Parse(numericUpDown_numUsuarios1.Value.ToString());
                b = int.Parse(numericUpDown_numUsuarios2.Value.ToString());
                ENGrupos grupo = new ENGrupos(textBox_filtroBusqueda.Text, textBox_usuario.Text, dateTimePicker_fecha.Value);
                //FormGrupos.Añadir(grupo.Buscar(a, b));
                ArrayList grupos = new ArrayList();
                grupos = grupo.Buscar(a, b);
                foreach (ENGrupos ob in grupos)
                {
                    //Escribira en datagrid los resultados
                    Console.Write(ob.Nombre + "\n");
                }

            }
        }
    }
}
