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
    public partial class ProductosForm : Form
    {
        public ProductosForm()
        {
            InitializeComponent();
        }

        ProductoDatos proDatos = new ProductoDatos();
        Producto producto = new Producto();
        string tipoOperacion = string.Empty;

        private void ProductosForm_Load(object sender, EventArgs e)
        {
            LlenarProductos();
        }

        private async void LlenarProductos()
        {
            ProductodataGridView.DataSource = await proDatos.DevolverListaAsync();

        }

        private void HabilitarControles()
        {
            CodigoTextBox.Enabled = true;
            DescripcionTextBox.Enabled = true;
            PrecioTextBox.Enabled = true;
            ExistenciaTextBox.Enabled = true;
            FechadateTimePicker.Enabled = true;
            ImagenPictureBox1.Enabled = true;
            button1.Enabled = true;
        }

        private void LimpiarControles()
        {
            CodigoTextBox.Clear();
            DescripcionTextBox.Clear();
            PrecioTextBox.Clear();
            ExistenciaTextBox.Clear();
            FechadateTimePicker.Value = DateTime.Now;
            ImagenPictureBox1.Image = null;
            
        }

        private void DesHabilitarControles()
        {
            CodigoTextBox.Enabled = false;
            DescripcionTextBox.Enabled = false;
            PrecioTextBox.Enabled = false;
            ExistenciaTextBox.Enabled = false;
            FechadateTimePicker.Enabled = false;
            ImagenPictureBox1.Enabled = false;
            button1.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tipoOperacion = "Nuevo";
            HabilitarControles();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CodigoTextBox.Text))
            {

            }
        }
    }
}
