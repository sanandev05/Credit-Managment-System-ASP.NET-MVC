using Credit_Managment_System_ASP.NET_MVC.Services.Interfaces;
using Credit_Managment_System_ASP.NET_MVC.View_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Credit_Managment_System_ASP.NET_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
	public class MerchantController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IMerchantService _merchantService;
        private readonly IBranchService _branchService;
		public MerchantController(IMerchantService merchantService, IWebHostEnvironment webHost, IBranchService branchService)
		{
			_merchantService = merchantService;
			_env = webHost;
			_branchService = branchService;
		}
		public async Task<IActionResult> Index()
        {
            var merchants =await _merchantService.GetAllAsync();
            return View(merchants);
        }
        public async Task<IActionResult> Create()
		{
	
			var branches = await _branchService.GetAllAsync();
			ViewBag.Branches = new MultiSelectList(branches, "Id", "Name");
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(MerchantVM model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			if(model.Logo == null)
			{
				ModelState.AddModelError("Logo", "Please upload a logo.");
				return View(model);
			}
			if (model.Logo.Length > 1048576) // 1 MB
			{
				ModelState.AddModelError("Logo", "Logo size must be less than 1 MB.");
				return View(model);
			}
			if(model.Logo.ContentType.StartsWith("image/") == false)
			{
				ModelState.AddModelError("Logo", "Logo must be an image.");
				return View(model);
			}
			if (model.Logo != null)
			{
				var fileName = Guid.NewGuid().ToString() + "_" + model.Logo.FileName;
				var path = Path.Combine(_env.WebRootPath, "images", "merchants");

				if (!Directory.Exists(path))
				{
					Directory.CreateDirectory(path);
				}
                string fullPath = Path.Combine(path,fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
				{
					await model.Logo.CopyToAsync(stream);
				}
				model.LogoUrl = "/images/merchants/"+ fileName;
				var result = await _merchantService.AddAsync(model);
				return RedirectToAction("Index");
			}
			return View(model);

		}
	}
}
