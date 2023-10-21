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
using Org.BouncyCastle.Asn1.Cms;

namespace CapaPresentacion
{
    public partial class Menu : Form
    {

        CNLogueo getData = new CNLogueo();

        public Menu()
        {
            InitializeComponent();
        }
        private void Menu_Shown(object sender, EventArgs e)
        {

            if (checkBox1.Checked != true && checkBox2.Checked != true)
            {
                numericUpDown1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                linkLabel1.Enabled = false;
                actualizar.Enabled = false;
                eliminar.Enabled = false;
                dataGridView1.ReadOnly = true;

            }
        }
        private void actualizarDataClientes()
        {
                numericUpDown1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                linkLabel1.Enabled = true;
                dataGridView1.DataSource = getData.DataClientes();
                dataGridView1.Columns[0].HeaderText = "Id cliente";
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
        }

        private void actualizarDataProveedores()
        {
                numericUpDown1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                linkLabel1.Enabled = true;
                dataGridView1.DataSource = getData.DataProveedores();
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            actualizarDataProveedores();
            checkBox2.Checked = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            actualizarDataClientes();
            checkBox1.Checked = false;
        }

        private void guardar_Click(object sender, EventArgs e)
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
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Imagenes (*.jpg)|*.jpg; (*.png)|*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string ruta = openFileDialog1.FileName;
                pictureBox1.Image = Image.FromFile(ruta);
            }
        }
        DataTable dataTable = null;

        private void button3_Click(object sender, EventArgs e)
        {
            numericUpDown1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            pictureBox1.Image = null;
            actualizar.Enabled = false;
        }
        private void eliminar_Click_1(object sender, EventArgs e)
        {
            int id = -1;
            id = Convert.ToInt32(numericUpDown1.Text);
            if (checkBox2.Checked)
            {
                getData.eliminarCliente(id);
                checkBox1.Checked = false;
                actualizarDataClientes();
            }
            if (checkBox1.Checked)
            {
                getData.eliminarProveedor(id);
                checkBox2.Checked = false;
                actualizarDataProveedores();
            }
            
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            pictureBox1.Image = null;
            guardar.Enabled = false;
            linkLabel1.Enabled = false;
            eliminar.Enabled = true;
            actualizar.Enabled = true;
            string person = "";
            if (checkBox1.Checked)
            {
                dataTable = getData.DataProveedores();
                person = "proveedor";
            }
            else
            {
                dataTable = getData.DataClientes();
                person = "cliente";
            }
            try
            {
                numericUpDown1.Value = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[$"id_{person}"].Value);
                textBox2.Text = dataGridView1.CurrentRow.Cells["nombre"].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells["apellido"].Value.ToString();
                string rutaFoto = dataTable.Rows[dataGridView1.CurrentRow.Index]["foto"].ToString();
                pictureBox1.Image = Image.FromFile(rutaFoto);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                actualizar.Enabled = true;
            }
            catch
            {
                Console.WriteLine("imagen null");
            }
        }

        private void actualizar_Click(object sender, EventArgs e)
        {
            string id = numericUpDown1.Text;
            string name = textBox2.Text;
            string lastName = textBox3.Text;
            string ruta = "";
            if (openFileDialog1.FileName != "") {
                ruta= openFileDialog1.FileName;
            }
            else{
                ruta = "sin foto";
            }
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
                        Foto = ruta
                    };
                    if (checkBox1.Checked)
                    {
                        insertData.actualizarProveedor(clientesProvedores);
                    }
                    if (checkBox2.Checked)
                    {
                        insertData.actualizarCliente(clientesProvedores);
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
}
