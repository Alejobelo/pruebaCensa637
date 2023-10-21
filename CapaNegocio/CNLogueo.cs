using CapaDatos;
using CapaEntidades;
using Org.BouncyCastle.Asn1.X509.SigI;
using System.Data;

namespace CapaNegocio
{
    public class CNLogueo
    {
        CDCreate InsertData = new CDCreate();
        CDLogueo CDLogueo = new CDLogueo();
        CDRead CDRead = new CDRead();
        CDDelete CDDelete = new CDDelete();
        CDUpdate CDUpdate = new CDUpdate();
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
            return CDRead.ObtenerDatosProveedores();
        }
        public DataTable DataClientes()
        {
            return CDRead.ObtenerDatosClientes();
        }
        public void eliminarCliente( int id) 
        {
            string person = "cliente";
            string table = "clientes";
            CDDelete.eliminar(id, person, table);
        }
        public void eliminarProveedor(int id)
        {
            string person = "proveedor";
            string table = "proveedores";
            CDDelete.eliminar(id, person, table);
        }
        public void actualizarCliente(ClientesProvedores personClass)
        {
            string person = "cliente";
            string table = "clientes";
            CDUpdate.UClientesProveedores(person, table, personClass);
        }
        public void actualizarProveedor(ClientesProvedores personClass)
        {
            string person = "proveedor";
            string table = "proveedores";
            CDUpdate.UClientesProveedores(person, table, personClass);
        }

    }
}
