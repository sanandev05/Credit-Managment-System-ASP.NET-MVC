using Microsoft.AspNetCore.Mvc;

namespace Credit_Managment_System_ASP.NET_MVC.Areas.Admin.Views
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
