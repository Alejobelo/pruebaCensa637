using CapaEntidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDInsertData
    {   
        CDLogueo CDLogueo = new CDLogueo();
        public void InsertUser(EntidadesCE User) {
            string conexion = "Server=localhost;User=root;Password=h42wfhnf;Port=3306;database=pruebacensa";
            MySqlConnection connection = new MySqlConnection(conexion);
            try
            {
                connection.Open();

                string insertQuery = "INSERT INTO usuarios (documento, nombre, apellido, contrasela) VALUES (@documento, @nombre, @apellido, @contrasela)";
                MySqlCommand command = new MySqlCommand(insertQuery, connection);

                command.Parameters.AddWithValue("@documento", User.Id);
                command.Parameters.AddWithValue("@nombre", User.Name);
                command.Parameters.AddWithValue("@apellido", User.LastName);
                command.Parameters.AddWithValue("@contrasela", User.Password);

                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Filas afectadas: {rowsAffected}");
                MessageBox.Show("Usuario creado exitosamente!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                CDLogueo.CloseConnetion();
            }
        }
        public void InsertCliente(Clientes Cliente)
        {
            string conexion = "Server=localhost;User=root;Password=h42wfhnf;Port=3306;database=pruebacensa";
            MySqlConnection connection = new MySqlConnection(conexion);
            try
            {
                connection.Open();

                string insertQuery = "INSERT INTO clientes (id_cliente, nombre, apellido) VALUES (@id_cliente, @nombre, @apellido)";
                MySqlCommand command = new MySqlCommand(insertQuery, connection);

                command.Parameters.AddWithValue("@id_cliente", Cliente.Id_Cliente);
                command.Parameters.AddWithValue("@nombre", Cliente.Nombre);
                command.Parameters.AddWithValue("@apellido", Cliente.Apellido);

                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Filas afectadas: {rowsAffected}");
                MessageBox.Show("Cliente creado exitosamente!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                CDLogueo.CloseConnetion();
            }
        }

    }
}
