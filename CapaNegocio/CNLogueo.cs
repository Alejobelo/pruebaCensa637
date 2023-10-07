using CapaDatos;
using CapaEntidades;
using System.Data;

namespace CapaNegocio
{
    public class CNLogueo
    {
        CDInsertData InsertData = new CDInsertData();
        CDLogueo CDLogueo = new CDLogueo();

        public void PruebaMysql()
        {
            CDLogueo.PruebaConexion();
        }
        public void Register(EntidadesCE user)
        {
            MessageBox.Show($"user enviado:{user.Name} ");
            InsertData.InsertUser(user);
        }
        public bool Logueo(EntidadesCE user)
        {

            return CDLogueo.LogueoCD(user);
            
        }
        public void CrearCliente(ClientesProvedores person)
        {
            InsertData.InsertCliente(person);
        }
        public void CrearProveedor (ClientesProvedores person)
        {
            InsertData.InsertProveedor(person);
        }


        public DataTable DataProveedores()
        {
            return CDLogueo.ObtenerDatosProveedores();
        }
        public DataTable DataClientes()
        {
            return CDLogueo.ObtenerDatosClientes();
        }

    }
}
