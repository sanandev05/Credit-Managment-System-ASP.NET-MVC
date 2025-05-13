using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Credit_Managment_System_ASP.NET_MVC.Services.Interfaces;
using Credit_Managment_System_ASP.NET_MVC.View_Models;
using Credit_Managment_System_ASP.NET_MVC.Models;

namespace Credit_Managment_System_ASP.NET_MVC.Controllers
{
    public class CategoriesController : Controller
    {
        ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
           var datas= await _categoryService.GetAllAsync();

            return View(datas.Where(x=>x.ParentId==null|| x.ParentId==0));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _categoryService.GetByIdAsync(id.Value);
                
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

      
        public async Task<IActionResult> Create()
        {
            var getDatas= await _categoryService.GetAllAsync();
            var model = new CategoryVM
            {
                ParentCategories = getDatas.Where(x => x.ParentId == null || x.ParentId == 0).ToList()
            };
            return View(model);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,ParentId,Id,CreatedAt,UpdatedAt,IsDeleted")] CategoryVM model)
        {
            if (ModelState.IsValid)
            {
               await _categoryService.AddAsync(model);
                
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,ParentId,Id,CreatedAt,UpdatedAt,IsDeleted")] CategoryVM model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   await _categoryService.UpdateAsync(model);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_categoryService.GetByIdAsync((model.Id))==null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

               
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            _categoryService.DeleteAsync(id);

            return View(category);
        }
		public async Task<IActionResult> SubCategory(int parentId)
		{
			var model = (await _categoryService.GetAllAsync())?.Where(x => x.ParentId == parentId);
			return View(model);
		}

        public async Task<IActionResult> AddSubCategory(int parentId)
        {
            var parent = await _categoryService.GetByIdAsync(parentId);
            if (parent == null) return NotFound();

            var newCategory = new CategoryVM
            {
                ParentId = parentId
            };

            ViewBag.ParentName = parent.Name;

            return View(newCategory);
        }


        [HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddSubCategory(CategoryVM model)
		{
			if (ModelState.IsValid)
			{
                await _categoryService.AddAsync(model);
                return RedirectToAction("SubCategories", new { id = model.ParentId });
            }

            return View(model);
		}

	}
}
