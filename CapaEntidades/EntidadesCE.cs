using System.Data;

namespace CapaEntidades
{
    public class EntidadesCE
    {
        public int Id;
        public string? Name;
        public string? LastName;
        public string Password;
    }
    public class Clientes {
        public int Id_Cliente;
    public string? Nombre;
    public string? Apellido;
    public string? Foto;
    }

    public class Proveedores
    {
        public int Id_Proveedor;
        public string? Nombre;
        public string? Apellido;
        public string? Foto;
    }
    public class Productos
    {
        public int Id_Producto;
        public string Nombre;
        public string Detalle;
        public int Cantidad;
        public decimal Precio;
        public int id_proveedor;

    }
    public class Ventas
    {
        public int Id_Venta;
        public DateTime Fecha;
        public decimal Total;
        public int Id_Cliente;
    }
    public class DetalleVentas
    {
        public int Id_Detalle;
        public int Id_Venta;
        public int Id_Producto;
        public decimal Precio_Unitario;
        public int Cantidad;
        public decimal Total;
    }
}