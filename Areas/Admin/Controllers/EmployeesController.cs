using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.Services.Interfaces;
using Credit_Managment_System_ASP.NET_MVC.View_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Credit_Managment_System_ASP.NET_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IBranchService _branchService;
        public EmployeesController(IEmployeeService employeeService, IBranchService branchService)
        {
            _employeeService = employeeService;
            _branchService = branchService;
        }
        public async Task<IActionResult> Index()
        {
            var models = await _employeeService.GetAllAsync();
            return View(models);
        }
        public async Task<IActionResult> Create()
        {
            var branches = await _branchService.GetAllAsync();
            ViewBag.Branches = new SelectList(branches, "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeVM model)
        {
            if (ModelState.IsValid)
            {

                await _employeeService.AddAsync(model);
                return RedirectToAction(nameof(Index));
            }
            var branches = await _branchService.GetAllAsync();
            ViewBag.Branches = new SelectList(branches, "Id", "Name");
            return View(model);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }
            var branches = await _branchService.GetAllAsync();
            ViewBag.Branches = new SelectList(branches, "Id", "Name");
            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeVM model)
        {
            
            if (ModelState.IsValid)
            {               
                await _employeeService.UpdateAsync(model);
                return RedirectToAction(nameof(Index));
            }

            var branches = await _branchService.GetAllAsync();
            ViewBag.Branches = new SelectList(branches, "Id", "Name");

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id) {

          var model= await _employeeService.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost, ActionName("DeleteConfirm")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            await _employeeService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

