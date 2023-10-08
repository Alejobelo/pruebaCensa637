using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Menu : Form
    {

        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CNLogueo getData = new CNLogueo();
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
                dataGridView1.DataSource = getData.DataProveedores();
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            CNLogueo getData = new CNLogueo();
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
                dataGridView1.DataSource = getData.DataClientes();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                string id = numericUpDown1.Text;
                string name = textBox2.Text;
                string lastName = textBox3.Text;
                try
                {
                    if (id != null && name != null && lastName != null)
                    {
                        string ruta = openFileDialog1.FileName;
                        CNLogueo insertData = new CNLogueo();
                        ClientesProvedores clientesProvedores = new ClientesProvedores()
                        {
                            Id = Convert.ToInt32(id),
                            Nombre = name,
                            Apellido = lastName,
                            Foto = ruta
                        };
                        if (checkBox1.Checked)
                        {
                            insertData.CrearProveedor(clientesProvedores);
                        }
                        if (checkBox2.Checked)
                        {
                            insertData.CrearCliente(clientesProvedores);
                        }

                    }
                    numericUpDown1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    pictureBox1.Image = null;

                }
                catch
                {
                    {
                        MessageBox.Show("Todos los campo son requeridos");
                    }
                }
            }

        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                string ruta = openFileDialog1.FileName;
                pictureBox1.Image = Image.FromFile(ruta);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
            numericUpDown1.Value = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["id_proveedor"].Value);
            textBox2.Text = dataGridView1.CurrentRow.Cells["nombre"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["apellido"].Value.ToString(); ;
            pictureBox1.Image = Image.FromFile(dataGridView1.CurrentRow.Cells["foto"].Value.ToString());
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch
            {
                Console.WriteLine("imagen null");
            }
        }
    }
}
