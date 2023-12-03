using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoAdministradorTienda.Models;
using ProyectoAdministradorTienda.Services;

namespace ProyectoAdministradorTienda.Controllers
{
    public class UsuarioController : Controller
    {

        // GET: ColorProductoController
        private readonly IAPIService _apiService;

        public UsuarioController(IAPIService apiService)
        {
            _apiService = apiService;
        }


        // GET: ProductoController
        public async Task<IActionResult> Login()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string Login, string Contrasenia)
        {
            //List<Producto> tipos = await _apiService.GetProductos();

            Usuario usuario = await _apiService.GetValidacion(Login,Contrasenia);
            if(usuario == null)
            {
                ViewBag.ErrorMessage = "Credenciales incorrectas. Vuelva a intentarlo.";
                return View ();
            }
            else
            {
                return RedirectToAction("Index","Home");
            }

        }


    }
}
