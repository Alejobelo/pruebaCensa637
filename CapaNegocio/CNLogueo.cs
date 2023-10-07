using CapaDatos;
using CapaEntidades;

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
        public void CrearCliente(Clientes cliente)
        {
            InsertData.InsertCliente(cliente);
        }
    }
}
