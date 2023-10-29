namespace ProyectoAdministradorTienda.Models
{
    public class ProductoColorTallaCrea
    {
        public int idProductoColorTalla { get; set; }
        public int productoIdProduto { get; set; }
        public int colorProductoIdColorProducto { get; set; }
        public int tallaProductoIdTallaProducto { get; set; }

        public int stock { get; set; }
        public int stockMin { get; set; }
        public int stockMax { get; set; }
        public double precio { get; set; }
    }
}
