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
                dataGridView2.Visible = false;
                checkBox2.Checked = false;
                dataGridView1.Visible = true;
                dataGridView1.DataSource = getData.DataProveedores();
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            CNLogueo getData = new CNLogueo();
            if (checkBox2.Checked)
            {
                dataGridView1.Visible = false;
                checkBox1.Checked = false;
                dataGridView2.Visible = true;
                dataGridView2.DataSource = getData.DataClientes();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                string id = numericUpDown1.Text;
                string name = textBox2.Text;
                string lastName = textBox3.Text;
                string person = "";



                try
                {
                    if (id != null && name != null && lastName != null)
                    {
                        CNLogueo insertData = new CNLogueo();
                        ClientesProvedores clientesProvedores = new ClientesProvedores()
                        {
                            Id = Convert.ToInt32(id),
                            Nombre = name,
                            Apellido = lastName,
                            //Foto = password,
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

                }
                catch
                {
                    {
                        MessageBox.Show("Todos los campo son requeridos");
                    }
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
