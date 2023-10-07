using CapaEntidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Form2 : Form
    {
        CNLogueo cNLogueo = new CNLogueo();
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 register = new Form1();
            this.Close();
            register.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EntidadesCE user = new EntidadesCE()
            {
                Id = Convert.ToInt32(textBox1.Text),
                Password = textBox2.Text
            };
            if (cNLogueo.Logueo(user))
            {
                Menu menu = new Menu();
                menu.Show();
                this.Hide();
            }
            else return;

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator validator = new Validator();
            validator.vnumero(e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
