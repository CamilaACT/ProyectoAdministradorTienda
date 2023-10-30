using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoAdministradorTienda.Models;
using ProyectoAdministradorTienda.Services;

namespace ProyectoAdministradorTienda.Controllers
{
    public class ProductoController : Controller
    {
        // GET: ColorProductoController
        private readonly IAPIService _apiService;

        public ProductoController(IAPIService apiService)
        {
            _apiService = apiService;
        }


        // GET: ProductoController
        public async Task<IActionResult> Index()
        {
            List<Producto> tipos = await _apiService.GetProductos();
            return View(tipos);
        }

        // GET: ProductoController/Details/5
        public async Task<IActionResult> Details(int IdProducto)
        {
            //Console.WriteLine(color..ToString());
            Producto tipo2 = await _apiService.GetProducto(IdProducto);
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
        public async Task<IActionResult> Search()
        {
            if (int.TryParse(Request.Query["IdProducto"], out int idProducto))
            {
                Producto tipo2 = await _apiService.GetProducto(idProducto);
                if (tipo2 != null)
                {
                    return View("Details", tipo2);
                }
            }

            return View("ErrorView");
        }

        // GET: ProductoController/Create
        public async Task<IActionResult> Create()
        {
            // Obtener la lista de tipos de producto
            List<TipoProducto> tipos = await _apiService.GetTipos();

            // Almacena la lista de tipos de producto en ViewBag
            ViewBag.TipoProductos = new SelectList(tipos, "idTipoProducto", "nombre");

            return View();
        
        
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductoCrea productoapto)
        {
            ProductoCrea tipo1 = await _apiService.PostProducto(productoapto);
            return RedirectToAction("Index");
        }



        // GET: ProductoController/Edit/5
        public async Task<IActionResult> Edit(int idProducto)
        {
            Producto tipo = await _apiService.GetProducto(idProducto);
            if (tipo != null)
            {
                return View(tipo);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductoCrea productoapro)
        {
            Console.WriteLine(productoapro.idProduto.ToString());
            Console.WriteLine(productoapro.nombre.ToString());
            Producto tipo2 = await _apiService.GetProducto(productoapro.idProduto);
            if (tipo2 != null)
            {
                ProductoCrea tipo3 = await _apiService.PutProducto(productoapro.idProduto, productoapro);

                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: ProductoController/Delete/5
        public async Task<IActionResult> Delete(int idProducto)
        {
            Boolean producto2 = await _apiService.DeleteProducto(idProducto);
            if (producto2 != false)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
