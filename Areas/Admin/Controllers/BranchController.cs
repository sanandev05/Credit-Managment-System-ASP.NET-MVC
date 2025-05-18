using Credit_Managment_System_ASP.NET_MVC.Services.Interfaces;
using Credit_Managment_System_ASP.NET_MVC.View_Models;
using Microsoft.AspNetCore.Mvc;

namespace Credit_Managment_System_ASP.NET_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BranchController : Controller
    {
        private readonly IBranchService _branchService;
        private readonly IMerchantService _merchantService;

        public BranchController(IBranchService branchService, IMerchantService merchantService)
        {
            _branchService = branchService;
            _merchantService = merchantService;
        }

        public async Task<IActionResult> Index()
        {
            var branches = await _branchService.GetAllAsync();
            return View(branches);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BranchVM branchVM)
        {
            if (ModelState.IsValid)
            {
                await _branchService.UpdateAsync(branchVM);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Merchants = await _merchantService.GetAllAsync();
            return View(branchVM);
        }
    }
}
