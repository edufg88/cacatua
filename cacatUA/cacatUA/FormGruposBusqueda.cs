﻿using System;
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
    public partial class FormGruposBusqueda : InterfazForm
    {
        private FormGrupos formularioPadre = null;
        private ENUsuario usuario = null;

        private ArrayList ultimaBusqueda = null;

        public FormGruposBusqueda(FormGrupos formularioPadre)
        {
            int a = 0;
            this.formularioPadre = formularioPadre;
            InitializeComponent();
            ultimaBusqueda = new ArrayList();
            ultimaBusqueda.Add("");
            ultimaBusqueda.Add((ENUsuario) null);
            ultimaBusqueda.Add(new DateTime(2008, 9, 1));
            ultimaBusqueda.Add(DateTime.Now);
            ultimaBusqueda.Add(a);
            ultimaBusqueda.Add(a);
        }

        public FormGruposBusqueda(FormGrupos formularioPadre,ENUsuario usuario)
        {
            int a = 0;
            this.formularioPadre = formularioPadre;
            InitializeComponent();
            ultimaBusqueda = new ArrayList();
            ultimaBusqueda.Add("");
            ultimaBusqueda.Add(usuario);
            ultimaBusqueda.Add(new DateTime(2008, 9, 1));
            ultimaBusqueda.Add(DateTime.Now);
            ultimaBusqueda.Add(a);
            ultimaBusqueda.Add(a);
            textBox_usuario.Text = usuario.Usuario;
        }

        public void inicio()
        {
            textBox_filtroBusqueda.Text = "";
            textBox_usuario.Text = "";
            numericUpDown_numUsuarios1.Value = 0;
            numericUpDown_numUsuarios2.Value = 0;
            DateTime inicio = new DateTime(2006, 01, 01);
            dateTimePicker_fecha.Value = inicio;
            dateTimePicker_hasta.Value = DateTime.Now;
            errorProvider1.Clear();
        }

        private bool ValidarFormulario()
        {
            string errorFecha="";
            string errorNum="";
            string errorUsuario="";
            bool correcto = true;

            if (numericUpDown_numUsuarios1.Value > numericUpDown_numUsuarios2.Value)
            {
                errorNum = "El primer valor de usuarios debe ser menor que el segundo";
                correcto = false;
            }
            if (dateTimePicker_fecha.Value > dateTimePicker_hasta.Value)
            {
                errorFecha = "La primera fecha debe ser menor que la segunda";
                correcto = false;
            }
            if (textBox_usuario.Text != "")
            {
                ENUsuario usuario = ENUsuario.Obtener(textBox_usuario.Text);
                if (usuario == null)
                {
                    correcto = false;
                    errorUsuario = "Este usuario no existe.";
                }
            }

            errorProvider1.SetError(dateTimePicker_hasta, errorFecha);
            errorProvider1.SetError(numericUpDown_numUsuarios2, errorNum);
            errorProvider1.SetError(textBox_usuario, errorUsuario);

            return correcto;
        }

        /*private void button_buscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }*/

        private void button_seleccionarUsuario_Click(object sender, EventArgs e)
        {
            FormPanelAdministracion.Instancia.Apilar(new FormUsuarios(), "Seleccionando usuario", true, true, "Volver al panel anterior seleccionando el usuario actual", "Cancelar la selección y volver al panel anterior");
        }

        public override void Recibir(object objeto)
        {
            if (objeto != null)
            {
                if (objeto is ENUsuario)
                {
                    usuario = (ENUsuario)objeto;
                    textBox_usuario.Text = usuario.Usuario;
                }
            }
        }

        private void button_limpiar_Click(object sender, EventArgs e)
        {
            inicio();
            formularioPadre.ReiniciarResultados();
        }

        public ArrayList Buscar()
        {
            ArrayList grupos = null;
            // Obtenemos los datos introducidos por el usuario
            try
            {
                // Tipo de orden (ascendente o descendente)
                SortOrder orden = formularioPadre.Ordenar();
                bool ascendente = false;
                if (orden == SortOrder.Ascending)
                {
                    ascendente = true;
                }

                ENUsuario usuarioAux = (ENUsuario)ultimaBusqueda[1];
                DateTime fechaInicio = (DateTime)ultimaBusqueda[2];
                DateTime fechaFin = (DateTime)ultimaBusqueda[3];

                int cantidad = formularioPadre.CantidadPorPagina;
                int pagina = formularioPadre.PaginaActual;
                string propiedadOrdenar = formularioPadre.PropiedadOrdenar;

                ENGrupos grupo = new ENGrupos((string)ultimaBusqueda[0], fechaInicio);
                int cont = grupo.Cantidad((int)ultimaBusqueda[4], (int)ultimaBusqueda[5],
                    fechaFin, ref usuarioAux);
                formularioPadre.Resultado = grupo.Buscar(propiedadOrdenar, pagina, cantidad, ascendente, (int)ultimaBusqueda[4], (int)ultimaBusqueda[5],
                    fechaFin, ref usuarioAux);

                // Obtenemos el número de materiales total de la búsqueda (contando todas las páginas)
                //MessageBox.Show(busquedaActual.NumResultados.ToString());
                formularioPadre.ActualizarPaginacion(cont);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return grupos;
        }

        public void NuevaBusqueda()
        {
            errorProvider1.Clear();
            // Creamos una nueva búsqueda
            try
            {
                if (ValidarFormulario())
                {
                    string filtroBusqueda = textBox_filtroBusqueda.Text;
                    DateTime fechaInicio = dateTimePicker_fecha.Value;
                    DateTime fechaFin = dateTimePicker_hasta.Value;
                    ultimaBusqueda.Clear();
                    ultimaBusqueda.Add(textBox_filtroBusqueda.Text);
                    ultimaBusqueda.Add(ENUsuario.Obtener(textBox_usuario.Text));
                    ultimaBusqueda.Add(dateTimePicker_fecha.Value);
                    ultimaBusqueda.Add(dateTimePicker_hasta.Value);
                    ultimaBusqueda.Add(int.Parse(numericUpDown_numUsuarios1.Value.ToString()));
                    ultimaBusqueda.Add(int.Parse(numericUpDown_numUsuarios2.Value.ToString()));
                    // Ponemos la página a 1
                    formularioPadre.PaginaActual = 1;
                    Buscar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buscarGrupo(object sender, EventArgs e)
        {
            NuevaBusqueda();
        }
    }
}
