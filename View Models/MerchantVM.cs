using Credit_Managment_System_ASP.NET_MVC.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Credit_Managment_System_ASP.NET_MVC.View_Models
{
    public class MerchantVM : BaseEntityVM
    {
        public string Name { get; set; }
        [NotMapped]
        public IFormFile Logo { get; set; }
        public string? LogoUrl { get; set; }
        public ICollection<Branch>? Branches { get; set; }
        public ICollection<int>? BranchIDs { get; set; }
    }
}
