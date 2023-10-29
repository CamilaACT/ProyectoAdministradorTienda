using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoAdministradorTienda.Models;
using ProyectoAdministradorTienda.Services;

namespace ProyectoAdministradorTienda.Controllers
{
    public class TipoProductoController : Controller
    {
        // GET: ColorProductoController
        private readonly IAPIService _apiService;

        public TipoProductoController(IAPIService apiService)
        {
            _apiService = apiService;
        }


        // GET: ProductoController
        public async Task<IActionResult> Index()
        {
            List<TipoProducto> tipos = await _apiService.GetTipos();
            return View(tipos);
        }

        // GET: ProductoController/Details/5
        public async Task<IActionResult> Details(int IdTipoProducto)
        {
            //Console.WriteLine(color..ToString());
            TipoProducto tipo2 = await _apiService.GetTipo(IdTipoProducto);
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

        // GET: ProductoController/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TipoProducto tipoapto)
        {
            TipoProducto tipo1 = await _apiService.PostTipo(tipoapto);
            return RedirectToAction("Index");
        }



        // GET: ProductoController/Edit/5
        public async Task<IActionResult> Edit(int IdTipoProducto)
        {
            TipoProducto tipo = await _apiService.GetTipo(IdTipoProducto);
            if (tipo != null)
            {
                return View(tipo);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TipoProducto tipoapro)
        {
            Console.WriteLine(tipoapro.idTipoProducto.ToString());
            Console.WriteLine(tipoapro.nombre.ToString());
            TipoProducto tipo2 = await _apiService.GetTipo(tipoapro.idTipoProducto);
            if (tipo2 != null)
            {
                TipoProducto tipo3 = await _apiService.PutTipo(tipoapro.idTipoProducto, tipoapro);

                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: ProductoController/Delete/5
        public async Task<IActionResult> Delete(int IdTipoProducto)
        {
            Boolean producto2 = await _apiService.DeleteTipo(IdTipoProducto);
            if (producto2 != false)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }




        //metodos para vista producto
        /*public async Task<IActionResult> Createlista()
        {
            // Obtener la lista de tipos de producto
            List<TipoProducto> tipos = await _apiService.GetTipos();

            // Crear una lista de SelectListItem para la lista desplegable
            ViewBag.TipoProductos = new SelectList(tipos,"nombre");

            return View();
        }*/

        /*public async Task<IActionResult> Createlista()
        {
            // Obtener la lista de tipos de producto
            List<TipoProducto> tipos = await _apiService.GetTipos();

            // Almacena la lista de tipos de producto en ViewBag
            ViewBag.TipoProductos = new SelectList(tipos, "idTipoProducto", "nombre");

            return View();
        }*/


    }
}
