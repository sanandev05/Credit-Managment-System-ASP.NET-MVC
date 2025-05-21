using Credit_Managment_System_ASP.NET_MVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Credit_Managment_System_ASP.NET_MVC.Controllers
{
    public class LoanController : Controller
    {
        private readonly ILoanService _loanService;
        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }
        public async Task<IActionResult> Index()
        {
          var models = await _loanService.GetAllAsync();
            return View(models);
        }
    }
}
