using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoAdministradorTienda.Models;
using ProyectoAdministradorTienda.Services;

namespace ProyectoAdministradorTienda.Controllers
{
    public class TallaProductoController : Controller
    {
        // GET: ColorProductoController
        private readonly IAPIService _apiService;

        public TallaProductoController(IAPIService apiService)
        {
            _apiService = apiService;
        }


        // GET: ProductoController
        public async Task<IActionResult> Index()
        {
            List<TallaProducto> productos = await _apiService.GetTalla();
            return View(productos);
        }

        // GET: ProductoController/Details/5
        public async Task<IActionResult> Details(int idTallaProducto)
        {
            //Console.WriteLine(color..ToString());
            TallaProducto talla2 = await _apiService.GetTalla(idTallaProducto);
            if (talla2 != null)
            {
                return View(talla2);
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
        public async Task<IActionResult> Create(TallaProducto tallapto)
        {
            TallaProducto talla1 = await _apiService.PostTalla(tallapto);
            return RedirectToAction("Index");
        }



        // GET: ProductoController/Edit/5
        public async Task<IActionResult> Edit(int idTallaProducto)
        {
            TallaProducto talla = await _apiService.GetTalla(idTallaProducto);
            if (talla != null)
            {
                return View(talla);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TallaProducto tallapro)
        {
            Console.WriteLine(tallapro.idTallaProducto.ToString());
            Console.WriteLine(tallapro.talla.ToString());
            TallaProducto talla2 = await _apiService.GetTalla(tallapro.idTallaProducto);
            if (talla2 != null)
            {
                TallaProducto talla3 = await _apiService.PutTalla(tallapro.idTallaProducto, tallapro);

                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: ProductoController/Delete/5
        public async Task<IActionResult> Delete(int idTallaProducto)
        {
            Boolean producto2 = await _apiService.DeleteTalla(idTallaProducto);
            if (producto2 != false)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
