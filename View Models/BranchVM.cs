using Credit_Managment_System_ASP.NET_MVC.Models;

namespace Credit_Managment_System_ASP.NET_MVC.View_Models
{
    public class BranchVM : BaseEntityVM
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public int MerchantId { get; set; }
        public MerchantVM? Merchant { get; set; }

        public ICollection<EmployeeVM>? Employee { get; set; }
    }
}
