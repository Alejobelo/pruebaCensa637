using MySql.Data.MySqlClient;
using CapaEntidades;

namespace CapaDatos
{
    public class CDLogueo
    {
        string conexion = "Server=localhost;User=root;Password=h42wfhnf;Port=3306;database=pruebacensa";
    
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
        public void LogueoCD(CEUser user)
        {
            MySqlConnection connection = new MySqlConnection(conexion);

            connection.Open();

            string queryLogueo= "SELECT * FROM usuarios WHERE documento = @documento AND contrasela = @contrasela";

            MySqlCommand comando = new MySqlCommand(queryLogueo, connection);

            comando.Parameters.AddWithValue("@documento", user.Id);
            comando.Parameters.AddWithValue("@contrasela", user.Password);
            try
            {
            MySqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                MessageBox.Show("Acceso exitoso");
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas");
            }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }    
}

