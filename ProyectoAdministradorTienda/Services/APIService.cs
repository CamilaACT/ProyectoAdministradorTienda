using Newtonsoft.Json;
using ProyectoAdministradorTienda.Models;
using System.Drawing;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace ProyectoAdministradorTienda.Services
{
    public class APIService : IAPIService
    {
        private static string _baseUrl;
        private HttpClient _httpClient;

        public APIService() {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            _baseUrl = builder.GetSection("ApiSettings:BaseUrl").Value;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseUrl);
        }
        public async Task<bool> DeleteColor(int idColorProducto)
        {
            var response = await _httpClient.DeleteAsync("/api/ColorProducto/"+idColorProducto);
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteProducto(int IdProducto)
        {
            var response = await _httpClient.DeleteAsync("/api/Producto/"+IdProducto);
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteProductoColorTalla(int IdProducto)
        {
            var response = await _httpClient.DeleteAsync("/api/ProductoColorTalla/"+IdProducto);
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteTalla(int idTallaProducto)
        {
            var response = await _httpClient.DeleteAsync("/api/TallaProducto/"+idTallaProducto);
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteTipo(int IdTipoProducto)
        {
            var response = await _httpClient.DeleteAsync("/api/TipoProducto/"+IdTipoProducto);
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return true;
            }
            return false;
        }

        public async Task<ColorProducto> GetColor(int idColorProducto)
        {
            
            Console.WriteLine(idColorProducto.ToString());
            var response = await _httpClient.GetAsync("api/ColorProducto/"+idColorProducto);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                ColorProducto color = JsonConvert.DeserializeObject<ColorProducto>(json_response);
                return color;
            }
            return null;    
        }

       

        public async Task<List<ColorProducto>> GetColores()
        {
           
                var response = await _httpClient.GetAsync("api/ColorProducto");//verbo get porque retorna todo
                // Procesa la respuesta correcta
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    // Imprime el JSON en la consola
                    //Console.WriteLine(data);
                    List<ColorProducto> colores = JsonConvert.DeserializeObject<List<ColorProducto>>(data);

                    return colores;
                }
                else
                {
                    return new List<ColorProducto>();
                }
            
        }

        public async Task<Producto> GetProducto(int IdProducto)
        {
            Console.WriteLine(IdProducto.ToString());
            var response = await _httpClient.GetAsync("api/Producto/"+IdProducto);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Producto producto = JsonConvert.DeserializeObject<Producto>(json_response);
                return producto;
            }
            return null;
        }

        public async Task<ProductoColorTalla> GetProductoColorTalla(int IdProducto)
        {
            Console.WriteLine(IdProducto.ToString());
            var response = await _httpClient.GetAsync("api/ProductoColorTalla/"+IdProducto);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                ProductoColorTalla producto = JsonConvert.DeserializeObject<ProductoColorTalla>(json_response);
                return producto;
            }
            return null;
        }

        public async Task<List<Producto>> GetProductos()
        {
            var response = await _httpClient.GetAsync("api/Producto");//verbo get porque retorna todo
                                                                           // Procesa la respuesta correcta
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                // Imprime el JSON en la consola
                //Console.WriteLine(data);
                List<Producto> productos = JsonConvert.DeserializeObject<List<Producto>>(data);

                return productos;
            }
            else
            {
                return new List<Producto>();
            }
        }

        public async Task<List<ProductoColorTalla>> GetProductosColresTallas()
        {
            var response = await _httpClient.GetAsync("api/ProductoColorTalla");//verbo get porque retorna todo
                                                                      // Procesa la respuesta correcta
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                // Imprime el JSON en la consola
                //Console.WriteLine(data);
                List<ProductoColorTalla> productos = JsonConvert.DeserializeObject<List<ProductoColorTalla>>(data);

                return productos;
            }
            else
            {
                return new List<ProductoColorTalla>();
            }
        }

        public async Task<List<TallaProducto>> GetTalla()
        {
            var response = await _httpClient.GetAsync("api/TallaProducto");//verbo get porque retorna todo
                                                                           // Procesa la respuesta correcta
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                // Imprime el JSON en la consola
                //Console.WriteLine(data);
                List<TallaProducto> tallas = JsonConvert.DeserializeObject<List<TallaProducto>>(data);

                return tallas;
            }
            else
            {
                return new List<TallaProducto>();
            }
        }

        public async Task<TallaProducto> GetTalla(int IdTallaProucto)
        {
            Console.WriteLine(IdTallaProucto.ToString());
            var response = await _httpClient.GetAsync("api/TallaProducto/"+IdTallaProucto);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                TallaProducto talla = JsonConvert.DeserializeObject<TallaProducto>(json_response);
                return talla;
            }
            return null;
        }

        public async Task<TipoProducto> GetTipo(int IdTipoProducto)
        {
            Console.WriteLine(IdTipoProducto.ToString());
            var response = await _httpClient.GetAsync("api/TipoProducto/"+IdTipoProducto);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                TipoProducto tippo = JsonConvert.DeserializeObject<TipoProducto>(json_response);
                return tippo;
            }
            return null;
        }

        public async Task<List<TipoProducto>> GetTipos()
        {
            var response = await _httpClient.GetAsync("api/TipoProducto");//verbo get porque retorna todo
                                                                           // Procesa la respuesta correcta
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                // Imprime el JSON en la consola
                //Console.WriteLine(data);
                List<TipoProducto> tipos = JsonConvert.DeserializeObject<List<TipoProducto>>(data);

                return tipos;
            }
            else
            {
                return new List<TipoProducto>();
            }
        }

        public async Task<ColorProducto> PostColor(ColorProducto colorProducto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(colorProducto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/ColorProducto/", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                ColorProducto color2 = JsonConvert.DeserializeObject<ColorProducto>(json_response);
                return color2;
            }
            return new ColorProducto();
        }

        public async Task<ProductoCrea> PostProducto(ProductoCrea producto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(producto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/Producto/", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                ProductoCrea producto2 = JsonConvert.DeserializeObject<ProductoCrea>(json_response);
                return producto2;
            }
            return new ProductoCrea();
        }

        public async Task<ProductoColorTallaCrea> PostProductoColorTalla(ProductoColorTallaCrea producto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(producto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/ProductoColorTalla/", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                ProductoColorTallaCrea producto2 = JsonConvert.DeserializeObject<ProductoColorTallaCrea>(json_response);
                return producto2;
            }
            return new ProductoColorTallaCrea();
        }

        public async Task<TallaProducto> PostTalla(TallaProducto tallaProducto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(tallaProducto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/TallaProducto/", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                TallaProducto talla2 = JsonConvert.DeserializeObject<TallaProducto>(json_response);
                return talla2;
            }
            return new TallaProducto();
        }

        public async Task<TipoProducto> PostTipo(TipoProducto tipoProducto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(tipoProducto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/TipoProducto/", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                TipoProducto tipo2 = JsonConvert.DeserializeObject<TipoProducto>(json_response);
                return tipo2;
            }
            return new TipoProducto();
        }

        public async Task<ColorProducto> PutColor(int idColorProducto, ColorProducto colorProducto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(colorProducto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("api/ColorProducto/"+idColorProducto, content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                ColorProducto color2 = JsonConvert.DeserializeObject<ColorProducto>(json_response);
                return color2;
            }
            return new ColorProducto();
        }

        public async Task<ProductoCrea> PutProducto(int IdProducto, ProductoCrea producto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(producto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("api/Producto/"+IdProducto, content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                ProductoCrea prod = JsonConvert.DeserializeObject<ProductoCrea>(json_response);
                return prod;
            }
            return new ProductoCrea();
        }

        public async Task<ProductoColorTallaCrea> PutProducto(int IdProducto, ProductoColorTallaCrea producto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(producto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("api/ProductoColorTalla/"+IdProducto, content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                ProductoColorTallaCrea prod = JsonConvert.DeserializeObject<ProductoColorTallaCrea>(json_response);
                return prod;
            }
            return new ProductoColorTallaCrea();
        }

        public async Task<TallaProducto> PutTalla(int IdTallaProucto, TallaProducto tallaProducto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(tallaProducto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("api/TallaProducto/"+IdTallaProucto, content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                TallaProducto talla2 = JsonConvert.DeserializeObject<TallaProducto>(json_response);
                return talla2;
            }
            return new TallaProducto();
        }

        public async Task<TipoProducto> PutTipo(int IdTipoProducto, TipoProducto tipoProducto)
        {
            
            var content = new StringContent(JsonConvert.SerializeObject(tipoProducto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("api/TipoProducto/"+IdTipoProducto, content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                TipoProducto tipo2 = JsonConvert.DeserializeObject<TipoProducto>(json_response);
                return tipo2;
            }
            return new TipoProducto();
        }
    }
}
