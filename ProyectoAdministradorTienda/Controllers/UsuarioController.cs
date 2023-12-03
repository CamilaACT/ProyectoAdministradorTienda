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
        public async Task<IActionResult> Index()
        {
            List<Usuario> tipos = await _apiService.GetUsuarios();
            return View(tipos);
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

        // GET: ProductoController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            Usuario usuario1 = await _apiService.PostUsuario(usuario);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Search()
        {
            if (int.TryParse(Request.Query["idUsuario"], out int idUsario))
            {
                Usuario tipo2 = await _apiService.GetUsuario(idUsario);
                if (tipo2 != null)
                {
                    return View("Details", tipo2);
                }
            }

            return View("ErrorView");
        }
        

        // GET: ProductoController/Details/5
        public async Task<IActionResult> Details(int idUsuario)
        {
            //Console.WriteLine(color..ToString());
            Usuario tipo2 = await _apiService.GetUsuario(idUsuario);
            if (tipo2 != null)
            {
                return View(tipo2);
            }
            else
            {
                return View("Error");
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int idUsuario)
        {
            Usuario tipo = await _apiService.GetUsuario(idUsuario);
            if (tipo != null)
            {
                return View(tipo);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Usuario usuarioasd)
        {
           
            Usuario tipo2 = await _apiService.GetUsuario(usuarioasd.idUsuario);
            if (tipo2 != null)
            {
                Usuario tipo3 = await _apiService.PutUsuario(usuarioasd.idUsuario, usuarioasd);

                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int idUsuario)
        {
            Boolean producto2 = await _apiService.DeleteUsuario(idUsuario);
            if (producto2 != false)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
