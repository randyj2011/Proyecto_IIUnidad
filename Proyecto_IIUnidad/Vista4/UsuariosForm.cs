using Datos;
using Entidades;
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
        string tipoOperacion = string.Empty;
        Usuario user;

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
            tipoOperacion = "Nuevo";
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

        private void button2_Click(object sender, EventArgs e)
        {
            tipoOperacion = "Modificar";
            if (UsuariosdataGridView1.SelectedRows.Count>0)
            {
                CodigoTextBox.Text = UsuariosdataGridView1.CurrentRow.Cells["Codigo"].Value.ToString();
                NombreTextBox.Text = UsuariosdataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                ClaveTextBox.Text = UsuariosdataGridView1.CurrentRow.Cells["Clave"].Value.ToString();
                CorreoTextBox.Text = UsuariosdataGridView1.CurrentRow.Cells["Correo"].Value.ToString();
                comboBox.Text = UsuariosdataGridView1.CurrentRow.Cells["Rol"].Value.ToString();
                checkBox.Checked = Convert.ToBoolean(UsuariosdataGridView1.CurrentRow.Cells["EstaActivo"].Value);
                HabilitarControles();
                CodigoTextBox.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Debe Seleccionar un registro", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            user = new Usuario();
            if (tipoOperacion == "Nuevo")
            {
                if (CodigoTextBox.Text == "")
                {
                    errorProvider1.SetError(CodigoTextBox, "Ingrese un codigo");
                    CodigoTextBox.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(NombreTextBox.Text))

                {
                    errorProvider1.SetError(NombreTextBox, "Ingrese un nombre");
                    NombreTextBox.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(ClaveTextBox.Text))

                {
                    errorProvider1.SetError(ClaveTextBox, "Ingrese una clave");
                    ClaveTextBox.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(comboBox.Text))

                {
                    errorProvider1.SetError(comboBox, "Seleccione un ROL");
                    comboBox.Focus();
                    return;
                }

                user.Codigo = CodigoTextBox.Text;
                user.Nombre = NombreTextBox.Text;
                user.Clave = ClaveTextBox.Text;
                user.Correo = CorreoTextBox.Text;
                user.Rol = comboBox.Text;
                user.EstaActivo = checkBox.Checked;

                bool inserto = await userDatos.InsertarAsync(user);

                if(inserto)
                {
                    LlenarDataGrid();
                    LimpiarControles();
                    DesHabilitarControles();
                    MessageBox.Show("Usuario Guardado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Usuario no se pudo guardar", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            else if (tipoOperacion == "Modificar")
            {
                if (CodigoTextBox.Text == "")
                {
                    errorProvider1.SetError(CodigoTextBox, "Ingrese un codigo");
                    CodigoTextBox.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(NombreTextBox.Text))

                {
                    errorProvider1.SetError(NombreTextBox, "Ingrese un nombre");
                    NombreTextBox.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(ClaveTextBox.Text))

                {
                    errorProvider1.SetError(ClaveTextBox, "Ingrese una clave");
                    ClaveTextBox.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(comboBox.Text))

                {
                    errorProvider1.SetError(comboBox, "Seleccione un ROL");
                    comboBox.Focus();
                    return;
                }

                user.Codigo = CodigoTextBox.Text;
                user.Nombre = NombreTextBox.Text;
                user.Clave = ClaveTextBox.Text;
                user.Correo = CorreoTextBox.Text;
                user.Rol = comboBox.Text;
                user.EstaActivo = checkBox.Checked;

                bool modifico = await userDatos.ActualizarAsync(user);
                if (modifico)
                {
                    LlenarDataGrid();
                    LimpiarControles();
                    DesHabilitarControles();
                    MessageBox.Show("Usuario Guardado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Usuario no se pudo guardar", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (UsuariosdataGridView1.SelectedRows.Count > 0)
            {
                bool elimino = await userDatos.EliminarAsync(UsuariosdataGridView1.CurrentRow.Cells["Codigo"].Value.ToString());
                if (elimino)
                {
                    LlenarDataGrid();
                    
                    MessageBox.Show("Usuario Eliminado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Usuario no se pudo eliminar", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
    }
}
