using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDRead
    {
        string conexion = "Server=localhost;User=root;Port=3306;Password=h42wfhnf;database=pruebacensa";
        public DataTable ObtenerDatosProveedores()
        {
            DataTable dataTable = new DataTable();

            MySqlConnection connection = new MySqlConnection(conexion);

            {
                connection.Open();

                string consulta = "SELECT * FROM proveedores WHERE estado = 1";

                using (MySqlCommand comando = new MySqlCommand(consulta, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(comando))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }
        public DataTable ObtenerDatosClientes()
        {
            DataTable dataTable = new DataTable();

            MySqlConnection connection = new MySqlConnection(conexion);

            {
                connection.Open();

                string consulta = "SELECT * FROM clientes WHERE estado = 1";

                using (MySqlCommand comando = new MySqlCommand(consulta, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(comando))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }
    }
}
