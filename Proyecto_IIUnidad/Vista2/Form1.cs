using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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

            UsuarioDatos userDatos = new UsuarioDatos;
        }
    }
    }

