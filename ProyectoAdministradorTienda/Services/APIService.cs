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
    }
}
