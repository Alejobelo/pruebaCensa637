using CapaEntidades;
using CapaNegocio;
using static CapaEntidades.CEUser;
namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        Validator validator = new Validator();
        CNLogueo CNLogueo = new CNLogueo();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            validator.vnumero(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            validator.vletra(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            validator.vletra(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string name = textBox2.Text;
            string lastName = textBox3.Text;
            string password = textBox4.Text;

            try
            {
                if (id != null && name != null && lastName != null && password != null)
                {
                    CNLogueo register = new CNLogueo();
                    CEUser user = new CEUser()
                    {
                        Id = Convert.ToInt32(id),
                        Name = name,
                        LastName = lastName,
                        Password = password,
                    };
                    CNLogueo.Register(user);
                }
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
            catch
            {
                {
                    MessageBox.Show("Todos los campo son requeridos");
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CNLogueo.PruebaMysql();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}