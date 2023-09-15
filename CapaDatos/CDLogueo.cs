using MySql.Data.MySqlClient;

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
    }
}

