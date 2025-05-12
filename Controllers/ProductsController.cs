using Credit_Managment_System_ASP.NET_MVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Credit_Managment_System_ASP.NET_MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            var models=await _productService.GetAllAsync();
            return View(models);
        }
    }
}
