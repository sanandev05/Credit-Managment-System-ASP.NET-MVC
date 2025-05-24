using AutoMapper;
using Credit_Managment_System_ASP.NET_MVC.Services.Interfaces;
using Credit_Managment_System_ASP.NET_MVC.View_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Credit_Managment_System_ASP.NET_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MerchantsController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IMerchantService _merchantService;
        private readonly IBranchService _branchService;
        private readonly IMapper _mapper;
        public MerchantsController(IMerchantService merchantService, IWebHostEnvironment webHost, IBranchService branchService, IMapper mapper)
        {
            _merchantService = merchantService;
            _env = webHost;
            _branchService = branchService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var merchants = await _merchantService.GetAllAsync();

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
            if (model.Logo == null)
            {
                ModelState.AddModelError("Logo", "Please upload a logo.");
                return View(model);
            }
            if (model.Logo.Length > 1048576) // 1 MB
            {
                ModelState.AddModelError("Logo", "Logo size must be less than 1 MB.");
                return View(model);
            }
            if (model.Logo.ContentType.StartsWith("image/") == false)
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
                string fullPath = Path.Combine(path, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await model.Logo.CopyToAsync(stream);
                }
                model.LogoUrl = "/images/merchants/" + fileName;
                var result = await _merchantService.AddAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);

        }
        public async Task<IActionResult> Edit(int id)
        {
            var branches = await _branchService.GetAllAsync();
            ViewBag.Branches = new MultiSelectList(branches, "Id", "Name");
            var data = _mapper.Map<MerchantUpdateVM>(await _merchantService.GetByIdAsync(id));
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MerchantUpdateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            if (model.Logo != null)
            {
                if (model.Logo.Length > 1048576) // 1 MB
                {
                    ModelState.AddModelError("Logo", "Logo size must be less than 1 MB.");
                    return View(model);
                }
                if (model.Logo.ContentType.StartsWith("image/") == false)
                {
                    ModelState.AddModelError("Logo", "Logo must be an image.");
                    return View(model);
                }
                var fileName = Guid.NewGuid().ToString() + "_" + model.Logo.FileName;
                var path = Path.Combine(_env.WebRootPath, "images", "merchants");

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string fullPath = Path.Combine(path, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await model.Logo.CopyToAsync(stream);
                }
                model.LogoUrl = "/images/merchants/" + fileName;
                var map = _mapper.Map<MerchantVM>(model);
                await _merchantService.UpdateAsync(map);
                return RedirectToAction("Index");
            }
            else
            {
                var oldData = await _merchantService.GetByIdAsync(model.Id);
                model.LogoUrl = oldData.LogoUrl;
                var map = _mapper.Map<MerchantVM>(model);
                await _merchantService.UpdateAsync(map);

                return RedirectToAction("Index");

            }
           

        }
        public async Task<IActionResult> Delete(int id)
        {
            var merchantVM = await _merchantService.GetByIdAsync(id);

            if (merchantVM == null)
            {
                return NotFound();
            }

            
            return View(merchantVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var merchantVM = await _merchantService.GetByIdAsync(id);

            if (merchantVM == null)
            {
                return NotFound();
            }

            if (merchantVM.Branches != null)
            {
                foreach (var branch in merchantVM.Branches)
                {
                    await _branchService.DeleteAsync(branch.Id); 
                }
            }

            await _merchantService.DeleteAsync(id);

            return RedirectToAction(nameof(Index)); 
        }
    }
}
