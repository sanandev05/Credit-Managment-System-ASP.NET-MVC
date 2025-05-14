using AutoMapper;
using Credit_Managment_System_ASP.NET_MVC.Services.Interfaces;
using Credit_Managment_System_ASP.NET_MVC.View_Models;
using Microsoft.AspNetCore.Mvc;

namespace Credit_Managment_System_ASP.NET_MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _web;
        public ProductsController(IProductService productService, ICategoryService categoryService, IMapper mapper, IWebHostEnvironment web)
        {
            _productService = productService;
            _categoryService = categoryService;
            _mapper = mapper;
            _web = web;
        }
        public async Task<IActionResult> Index()
        {
            var models=await _productService.GetAllAsync();
            return View(models);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories=await _categoryService.GetAllAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.Image == null)
            {

                return View(model);
            }
            if (model.Image.Length > 100 * 1024)
            {
                ModelState.AddModelError("Image", "Image size cant be greater than 100 kB");
            }
            if (model.Image.ContentType.StartsWith("image/png"))
            {
                string fileName = Guid.NewGuid() + Path.GetExtension(model.Image.FileName);
                string path = Path.Combine(_web.WebRootPath, "images", "products");

                if(!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                using(var stream=new FileStream(path,FileMode.Create))
                {
                   await model.Image.CopyToAsync(stream);
                }

                model.ImageUrl = path;
                var result = await _productService.AddAsync(model);
                if (result != null)
                {
                    return RedirectToAction("Index");
                }
                
            }
            return View(model);
        }
    }
}
