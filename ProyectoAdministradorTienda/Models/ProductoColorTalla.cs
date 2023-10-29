namespace ProyectoAdministradorTienda.Models
{
    public class ProductoColorTalla
    {
        public int idProductoColorTalla { get; set; }
        public Producto Producto { get; set; }
        public ColorProducto ColorProducto { get; set; }
        public TallaProducto TallaProducto { get; set; }

        public int stock { get; set; }
        public int stockMin { get; set; }
        public int stockMax { get; set; }
        public double precio { get; set; }
    }
}
