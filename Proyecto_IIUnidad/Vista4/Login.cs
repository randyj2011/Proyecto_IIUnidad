using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (CodigoUsuario.Text == String.Empty)
            {
                errorProvider1.SetError(CodigoUsuario, "Ingrese un codigo de usuario");
                CodigoUsuario.Focus();
                return;
            }
            errorProvider1.Clear();
            if (Clave.Text == String.Empty)
            {
                errorProvider1.SetError(CodigoUsuario, "Ingrese una clave de usuario");
                Clave.Focus();
                return;
            }
            errorProvider1.Clear();

            UsuarioDatos userDatos = new UsuarioDatos();

            bool valido = await userDatos.LoginAsync(CodigoUsuario.Text, Clave.Text);


            if (valido)
            {
                Menu formulario = new Menu();
                Hide();
                formulario.Show();

            }
            else
            {
                MessageBox.Show("Datos de usuario incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

    

