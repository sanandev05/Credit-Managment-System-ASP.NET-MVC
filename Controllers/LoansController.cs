using Credit_Managment_System_ASP.NET_MVC.Services.Interfaces;
using Credit_Managment_System_ASP.NET_MVC.View_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Credit_Managment_System_ASP.NET_MVC.Controllers
{
    public class LoansController : Controller
    {
        private readonly ILoanService _loanService;
        private readonly ICustomerService _customerService;
        public LoansController(ILoanService loanService, ICustomerService customerService)
        {
            _loanService = loanService;
            _customerService = customerService;
        }
        public async Task<IActionResult> Index()
        {
            var models = await _loanService.GetAllAsync();
            return View(models);
        }
        public async Task<IActionResult> Create()
        {
            var customers = await _customerService.GetAllAsync();
            ViewBag.Customers = new SelectList(customers, "Id", "Name");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LoanVM model)
        {
            if (ModelState.IsValid)
            {
               await _loanService.AddAsync(model);
            }
            var customers = await _customerService.GetAllAsync();
            ViewBag.Customers = new SelectList(customers, "Id", "Name");

            return View();
        }
    }
}
