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
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
            }

            DataTable dataTable = new DataTable("Clientes");

            // Define las columnas de la DataTable
            dataTable.Columns.Add("ID_Cliente", typeof(int));
            dataTable.Columns.Add("Nombre", typeof(string));
            dataTable.Columns.Add("Apellido", typeof(string));
            dataTable.Columns.Add("Direccion", typeof(string));
            dataTable.Columns.Add("Telefono", typeof(string));
            dataTable.Columns.Add("CorreoElectronico", typeof(string));

            DataRow newRow = dataTable.NewRow();

            // Establecer los valores para cada columna en la nueva fila
            newRow["ID_Cliente"] = 1; // ID del cliente
            newRow["Nombre"] = "Juan";
            newRow["Apellido"] = "Pérez";
            newRow["Direccion"] = "Calle 123";
            newRow["Telefono"] = "123-456-7890";
            newRow["CorreoElectronico"] = "juan@example.com";

            dataTable.Rows.Add(newRow);

            dataGridView1.DataSource = dataTable;
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
                        CNLogueo insertData = new CNLogueo();
                        Clientes cliente = new Clientes()
                        {
                            Id_Cliente = Convert.ToInt32(id),
                            Nombre = name,
                            Apellido = lastName,
                            //Foto = password,
                        };
                        insertData.CrearCliente(cliente);

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
    }
}
