using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion
{
    internal class Validator
    {
        public void vnumero(KeyPressEventArgs e)
        {
            if ((!(e.KeyChar >= 48 && e.KeyChar < 57)) && (!(e.KeyChar >= 0 && e.KeyChar < 28)))
            {
                MessageBox.Show("solo numeros", "advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                e.Handled = true;
                return;
            }
        }

        public void vletra(KeyPressEventArgs e)
        {
            if (((e.KeyChar >= 48 && e.KeyChar < 57)) && (!(e.KeyChar >= 0 && e.KeyChar < 28)))
            {
                MessageBox.Show("solo letras", "advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                e.Handled = true;
                return;
            }
        }
    }
}
