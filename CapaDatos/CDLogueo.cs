using MySql.Data.MySqlClient;
using CapaEntidades;
using System.Data;

namespace CapaDatos
{
    public class CDLogueo
    {
        string conexion = "Server=localhost;User=root;Port=3306;Password=h42wfhnf;database=pruebacensa";
    
    public void PruebaConexion()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(conexion);
            try{
                mySqlConnection.Open();
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Error al conectarse a la BD" + ex.Message);
                return;
            }
            mySqlConnection.Close();
            MessageBox.Show("coectado Exitosamente a la BD");
        }
        public void Conexion()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(conexion);
            try
            {
                mySqlConnection.Open();
                MessageBox.Show("conexion abierta");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectarse a la BD" + ex.Message);
                return;
            }
        }
        public void CloseConnetion()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(conexion);
            mySqlConnection.Close();
        }
        public bool LogueoCD(EntidadesCE user)
        {
            MySqlConnection connection = new MySqlConnection(conexion);

            try
            {
            connection.Open();

            string queryLogueo= "SELECT * FROM usuarios WHERE documento = @documento AND contrasela = @contrasela";

            MySqlCommand comando = new MySqlCommand(queryLogueo, connection);

            comando.Parameters.AddWithValue("@documento", user.Id);
            comando.Parameters.AddWithValue("@contrasela", user.Password);
            MySqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                return true;
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas");   
                    return false;
            }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }


        }


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
        public void eliminar(int id, string person, string table)
        {
            MySqlConnection connection = new MySqlConnection(conexion);

            
                connection.Open();

                string actualizar = $"UPDATE {table} SET estado = 0 WHERE id_{person} = @id";

                using (MySqlCommand cmd = new MySqlCommand(actualizar, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Proveedor actualizado con éxito.");
                    }
                    else
                    {
                        Console.WriteLine("No se encontró el proveedor con el ID proporcionado.");
                    }

                }

            MessageBox.Show("registro eliminado");
        }
    }    
}

