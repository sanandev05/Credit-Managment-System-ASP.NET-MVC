using AutoMapper;
using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.Services.Interfaces;
using Credit_Managment_System_ASP.NET_MVC.View_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = new SelectList(categories.Where(x => x.ParentId > 0), "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductVM model)
        {
            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = new SelectList(categories.Where(x => x.ParentId > 0), "Id", "Name");
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
            if (model.Image.ContentType.StartsWith("image"))
            {


                string fileName = Guid.NewGuid() + Path.GetExtension(model.Image.FileName);
                string path = Path.Combine(_web.WebRootPath, "images", "products");

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string fullPath = Path.Combine(path, fileName);
                using (var stream = new FileStream(Path.Combine(fullPath), FileMode.Create))
                {
                    await model.Image.CopyToAsync(stream);
                }
                
                model.ImageUrl ="/images/products/" + fileName; 

                var result = await _productService.AddAsync(model);
                if (result != null)
                {
                    return RedirectToAction("Index");
                }

            }
            return View(model);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = new SelectList(categories.Where(x => x.ParentId > 0), "Id", "Name");
            var data = await _productService.GetByIdAsync(id);
            var model =  _mapper.Map<ProductVM,ProductUpdateVM>(data);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductUpdateVM model)
        {
            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = new SelectList(categories.Where(x => x.ParentId > 0), "Id", "Name");
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.Image != null)
            {
                if (model.Image.Length > 100 * 1024)
                {
                    ModelState.AddModelError("Image", "Image size cant be greater than 100 kB");
                }
                if (model.Image.ContentType.StartsWith("image"))
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(model.Image.FileName);
                    string path = Path.Combine(_web.WebRootPath, "images", "products");

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    string fullPath = Path.Combine(path, fileName);
                    using (var stream = new FileStream(Path.Combine(fullPath), FileMode.Create))
                    {
                        await model.Image.CopyToAsync(stream);
                    }
                    model.ImageUrl = "/images/products/" + fileName;

                    await _productService.UpdateAsync(model);


                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Image", "File type is not supported");
                }
               
            }
            else
            {
                var getData = await _productService.GetByIdAsync(model.Id);

                model.ImageUrl = getData.ImageUrl;
                model.Image = getData.Image;
                
                await _productService.UpdateAsync(model);


                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ProductVM model)
        {
            if (model.Id == 0)
            {
                return NotFound();
            }


            var result =await _productService.DeleteAsync(model.Id);
            if (result != false) {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }
       

        }

    }
}
