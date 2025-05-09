using Credit_Managment_System_ASP.NET_MVC.Models;

namespace Credit_Managment_System_ASP.NET_MVC.View_Models
{
    public class MerchantVM : BaseEntityVM
    {
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public ICollection<Branch> Branches { get; set; }
    }
}
