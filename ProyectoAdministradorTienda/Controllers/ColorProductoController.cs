using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoAdministradorTienda.Models;
using ProyectoAdministradorTienda.Services;

namespace ProyectoAdministradorTienda.Controllers
{
    public class ColorProductoController : Controller
    {
        // GET: ColorProductoController
        private readonly IAPIService _apiService;

        public ColorProductoController(IAPIService apiService)
        {
            _apiService = apiService;
        }


        // GET: ProductoController
        public async Task<IActionResult> Index()
        {
            List<ColorProducto> productos = await _apiService.GetColores();
            return View(productos);
        }

        // GET: ProductoController/Details/5
        public async Task<IActionResult> Details(int idColorProducto)
        {
            Console.WriteLine(idColorProducto.ToString());
            ColorProducto color = await _apiService.GetColor(idColorProducto);
            if (color != null)
            {
                return View(color);
            }
            else
            {
                return View("Error");
            }
            return RedirectToAction("Index");
        }

        // GET: ProductoController/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ColorProducto color)
        {
            ColorProducto color1 = await _apiService.PostColor(color);
            return RedirectToAction("Index");
        }



        // GET: ProductoController/Edit/5
        public async Task<IActionResult> Edit(int IdColorProducto)
        {
            ColorProducto producto = await _apiService.GetColor(IdColorProducto);
            if (producto != null)
            {
                return View(producto);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ColorProducto color)
        {
            ColorProducto color2 = await _apiService.GetColor(color.IdColorProducto);
            if (color2 != null)
            {
                ColorProducto color3 = await _apiService.PutColor(color.IdColorProducto, color);

                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: ProductoController/Delete/5
        public async Task<IActionResult> Delete(int IdColorProducto)
        {
            Boolean producto2 = await _apiService.DeleteColor(IdColorProducto);
            if (producto2 != false)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
