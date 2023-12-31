﻿using MySql.Data.MySqlClient;
using CapaEntidades;
using System.Data;

namespace CapaDatos
{
    public class CDLogueo
    {
        string conexion = "Server=localhost;User=root;Port=3306;Password=h42wfhnf;database=pruebacensa";
    
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
    }    
}

