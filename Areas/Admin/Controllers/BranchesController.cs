using Credit_Managment_System_ASP.NET_MVC.Services.Interfaces;
using Credit_Managment_System_ASP.NET_MVC.View_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Credit_Managment_System_ASP.NET_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BranchesController : Controller
    {
        private readonly IBranchService _branchService;
        private readonly IMerchantService _merchantService;

        public BranchesController(IBranchService branchService, IMerchantService merchantService)
        {
            _branchService = branchService;
            _merchantService = merchantService;
        }

        public async Task<IActionResult> Index()
        {
            var branches = await _branchService.GetAllAsync();
            return View(branches);
        }

		public async Task<IActionResult> Create()
		{
			var merchants = await _merchantService.GetAllAsync();
			ViewBag.Merchants = new SelectList(merchants, "Id", "Name");
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(BranchVM branchVM)
		{
           

            if (ModelState.IsValid)
			{
                //branchVM.MerchantVM = await _merchantService.GetByIdAsync(branchVM.MerchantId);

                await _branchService.CreateAsync(branchVM);
                return RedirectToAction(nameof(Index));
			}
            else
            {
                var merchants = await _merchantService.GetAllAsync();
                ViewBag.Merchants = new SelectList(merchants, "Id", "Name");
            }
           
            return View(branchVM);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var branch = await _branchService.GetByIdAsync(id);
			if (branch == null) return NotFound();

            var merchants = await _merchantService.GetAllAsync();
            ViewBag.Merchants = new SelectList(merchants, "Id", "Name");
            return View(branch);
		}

		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BranchVM branchVM)
        {
            var merchants = await _merchantService.GetAllAsync();
            ViewBag.Merchants = new SelectList(merchants, "Id", "Name");
            if (ModelState.IsValid)
            {
                await _branchService.UpdateAsync(branchVM);
                return RedirectToAction(nameof(Index));
            }

           
            return View(branchVM);
        }
        public async Task<IActionResult> Delete(int id)
        {
           
            var model = await _branchService.GetByIdAsync(id);

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var branch = await _branchService.GetByIdAsync(id);
            if (branch == null)
            {
                return NotFound();
            }

            await _branchService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));  
        }


    }
}
