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
            Form1 form1 = new Form1();
            Form2 form2 = new Form2();
            form2.Close();
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CEUser user = new CEUser()
            {
                Id = Convert.ToInt32(textBox1.Text),
                Password = textBox2.Text
            };
            cNLogueo.Logueo(user);

        }
    }
}
