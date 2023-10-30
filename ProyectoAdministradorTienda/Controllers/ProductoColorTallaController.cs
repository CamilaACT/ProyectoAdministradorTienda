using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoAdministradorTienda.Models;
using ProyectoAdministradorTienda.Services;

namespace ProyectoAdministradorTienda.Controllers
{
    public class ProductoColorTallaController : Controller
    {
        // GET: ColorProductoController
        private readonly IAPIService _apiService;

        public ProductoColorTallaController(IAPIService apiService)
        {
            _apiService = apiService;
        }


        // GET: ProductoController
        public async Task<IActionResult> Index()
        {
            List<ProductoColorTalla> tipos = await _apiService.GetProductosColresTallas();
            return View(tipos);
        }
        public async Task<IActionResult> Search()
        {
            if (int.TryParse(Request.Query["IdProducto"], out int idProducto))
            {
                ProductoColorTalla tipo2 = await _apiService.GetProductoColorTalla(idProducto);
                if (tipo2 != null)
                {
                    return View("Details",tipo2);
                }
            }

            return View("ErrorView");
        }


        // GET: ProductoController/Details/5
        public async Task<IActionResult> Details(int IdProducto)
            {
                //Console.WriteLine(color..ToString());
                ProductoColorTalla tipo2 = await _apiService.GetProductoColorTalla(IdProducto);
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
        public async Task<IActionResult> Create()
        {
            // Obtener la lista de tipos de producto
            List<Producto> tipos = await _apiService.GetProductos();

            // Almacena la lista de tipos de producto en ViewBag
            ViewBag.Productos = new SelectList(tipos, "idProduto", "nombre");

            List<ColorProducto> colores = await _apiService.GetColores();
            ViewBag.Colores = new SelectList(colores, "idColorProducto", "nombre");

            List<TallaProducto> tallas = await _apiService.GetTalla();
            ViewBag.Tallas = new SelectList(tallas, "idTallaProducto", "talla");

            return View();


        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductoColorTallaCrea productoapto)
        {
            ProductoColorTallaCrea tipo1 = await _apiService.PostProductoColorTalla(productoapto);
            return RedirectToAction("Index");
        }



        // GET: ProductoController/Edit/5
        public async Task<IActionResult> Edit(int idProducto)
        {
            ProductoColorTalla tipo = await _apiService.GetProductoColorTalla(idProducto);
            if (tipo != null)
            {
                return View(tipo);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductoColorTallaCrea productoapro)
        {
            //Console.WriteLine(productoapro.idProduto.ToString());
            //Console.WriteLine(productoapro.nombre.ToString());
            ProductoColorTalla tipo2 = await _apiService.GetProductoColorTalla(productoapro.idProductoColorTalla);
            if (tipo2 != null)
            {
                ProductoColorTallaCrea tipo3 = await _apiService.PutProducto(productoapro.idProductoColorTalla, productoapro);

                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: ProductoController/Delete/5
        public async Task<IActionResult> Delete(int idProducto)
        {
            Boolean producto2 = await _apiService.DeleteProductoColorTalla(idProducto);
            if (producto2 != false)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
