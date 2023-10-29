using ProyectoAdministradorTienda.Models;

namespace ProyectoAdministradorTienda.Services
{
    public interface IAPIService
    {
        //AQUI SE PONEN LOS METODOS QUE HACEN REFERENCIA A LOS END POINT

        //ENDPOINT PARA GESTIONAR COLORES
        public Task<List<ColorProducto>> GetColores();
        public Task<ColorProducto> GetColor(int IdColorProducto);
        
        public Task<ColorProducto> PostColor(ColorProducto colorProducto);
        public Task<ColorProducto> PutColor(int IdColorProducto, ColorProducto colorProducto);
        public Task<Boolean> DeleteColor(int IdColorProducto);

        //ENDPOINT PARA GESTIONAR TALLAS
        public Task<List<TallaProducto>> GetTalla();
        public Task<TallaProducto> GetTalla(int IdTallaProucto);

        public Task<TallaProducto> PostTalla(TallaProducto tallaProducto);
        public Task<TallaProducto> PutTalla(int IdTallaProucto, TallaProducto tallaProducto);
        public Task<Boolean> DeleteTalla(int IdTallaProucto);

        //ENDPOINT PARA GESTIONAR TIPOPRODUCTOS
        public Task<List<TipoProducto>> GetTipos();
        public Task<TipoProducto> GetTipo(int IdTipoProducto);

        public Task<TipoProducto> PostTipo(TipoProducto tipoProducto);
        public Task<TipoProducto> PutTipo(int IdTipoProducto, TipoProducto tipoProducto);
        public Task<Boolean> DeleteTipo(int IdTipoProducto);

        //ENDPOINT PARA GESTIONAR Productos
        public Task<List<Producto>> GetProductos();
        public Task<Producto> GetProducto(int IdProducto);

        public Task<ProductoCrea> PostProducto(ProductoCrea producto);
        public Task<ProductoCrea> PutProducto(int IdProducto, ProductoCrea producto);
        public Task<Boolean> DeleteProducto(int IdProducto);

    }
}
