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
        public void Register(CEUser user)
        {
            MessageBox.Show($"user enviado:{user.Name} ");
            InsertData.InsertUser(user);
        }
        public void Logueo(CEUser user)
        {
            CDLogueo.LogueoCD(user);
        }
    }
}
