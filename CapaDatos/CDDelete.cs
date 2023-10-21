using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDDelete
    {
        public void eliminar(int id, string person, string table)
        {
            string conexion = "Server=localhost;User=root;Port=3306;Password=h42wfhnf;database=pruebacensa";
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
