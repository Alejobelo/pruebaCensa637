using CapaEntidades;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDUpdate
    {
        public void UClientesProveedores(string person, string table, ClientesProvedores personClass) {
            string conexion = "Server=localhost;User=root;Port=3306;Password=h42wfhnf;database=pruebacensa";
            MySqlConnection connection = new MySqlConnection(conexion);
            connection.Open();

            decimal id = personClass.Id;
            string actualizar = $"UPDATE {table} SET nombre = @nombre, apellido = @apellido WHERE id_{person} = @id";

            using (MySqlCommand cmd = new MySqlCommand(actualizar, connection))
            {
                cmd.Parameters.AddWithValue("@nombre", personClass.Nombre);
                cmd.Parameters.AddWithValue("@apellido", personClass.Apellido);
                cmd.Parameters.AddWithValue("@id", id);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine($"{person} actualizado con éxito.");
                    MessageBox.Show("registro actualizado");
                }
                else
                {
                    Console.WriteLine($"No se encontró el {person} con el ID proporcionado.");
                }

            }

        }
    
    }
}
