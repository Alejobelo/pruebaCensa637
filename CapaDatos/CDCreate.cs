using CapaEntidades;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDCreate
    {   
        CDLogueo CDLogueo = new CDLogueo();
            string conexion = "Server=localhost;User=root;Port=3306;Password=h42wfhnf;database=pruebacensa";
        public void InsertUser(EntidadesCE User) {
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
        public void InsertCliente(ClientesProvedores Cliente)
        {
            string conexion = "Server=localhost;User=root;Port=3306;Password=h42wfhnf;database=pruebacensa";
            MySqlConnection connection = new MySqlConnection(conexion);
            try
            {

                connection.Open();


                string insertQuery = "INSERT INTO clientes (id_cliente, nombre, apellido, foto) VALUES (@id_cliente, @nombre, @apellido, @foto)";
                MySqlCommand command = new MySqlCommand(insertQuery, connection);

                command.Parameters.AddWithValue("@id_cliente", Cliente.Id);
                command.Parameters.AddWithValue("@nombre", Cliente.Nombre);
                command.Parameters.AddWithValue("@apellido", Cliente.Apellido);
                command.Parameters.AddWithValue("@foto", Cliente.Foto);

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
        public void InsertProveedor(ClientesProvedores Proveedor)
        {
            MySqlConnection connection = new MySqlConnection(conexion);
            try
            {
                connection.Open();

                string insertQuery = "INSERT INTO proveedores (id_proveedor, nombre, apellido, foto) VALUES (@id_proveedor, @nombre, @apellido, @foto)";
                MySqlCommand command = new MySqlCommand(insertQuery, connection);

                command.Parameters.AddWithValue("@id_proveedor", Proveedor.Id);
                command.Parameters.AddWithValue("@nombre", Proveedor.Nombre);
                command.Parameters.AddWithValue("@apellido", Proveedor.Apellido);
                command.Parameters.AddWithValue("@foto", Proveedor.Foto);

                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Filas afectadas: {rowsAffected}");
                MessageBox.Show("Proveedor creado exitosamente!");
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
