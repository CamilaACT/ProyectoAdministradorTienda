namespace ProyectoAdministradorTienda.Models
{
    public class Producto
    {
        public int idProduto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public TipoProducto tipoProducto { get; set; }
    }
}
