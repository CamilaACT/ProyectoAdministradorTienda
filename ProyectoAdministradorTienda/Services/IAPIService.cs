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


    }
}
