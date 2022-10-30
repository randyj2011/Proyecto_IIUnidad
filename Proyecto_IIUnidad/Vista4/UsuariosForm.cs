using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vista4
{
    public partial class UsuariosForm : Form
    {
        public UsuariosForm()
        {
            InitializeComponent();
        }
        UsuarioDatos userDatos = new UsuarioDatos();

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void UsuariosForm_Load(object sender, EventArgs e)
        {
            LlenarDataGrid();
        }
        private async void LlenarDataGrid()
        {
            UsuariosdataGridView1.DataSource = await userDatos.DevolverListaAsync();
        }

        private void UsuariosdataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CodigoTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HabilitarControles();
        }
        private void HabilitarControles()
        {
            CodigoTextBox.Enabled = true;
            NombreTextBox.Enabled = true;
            ClaveTextBox.Enabled = true;
            CorreoTextBox.Enabled = true;
            comboBox.Enabled = true;
            checkBox.Enabled = true;
        }

        private void DesHabilitarControles()
        {
            CodigoTextBox.Enabled = false;
            NombreTextBox.Enabled = false;
            ClaveTextBox.Enabled = false;
            CorreoTextBox.Enabled = false;
            comboBox.Enabled = false;
            checkBox.Enabled = false;
        }

        private void LimpiarControles()
        {
            CodigoTextBox.Clear();
            NombreTextBox.Text = String.Empty;
            ClaveTextBox.Text = "";
            CorreoTextBox.Clear();
            comboBox.Text = String.Empty;
            checkBox.Checked = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DesHabilitarControles();
            LimpiarControles();
        }
    }
}
