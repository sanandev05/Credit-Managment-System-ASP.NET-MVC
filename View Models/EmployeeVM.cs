using Credit_Managment_System_ASP.NET_MVC.Models;

namespace Credit_Managment_System_ASP.NET_MVC.View_Models
{
    public class EmployeeVM : BaseEntityVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }

        public int BranchId { get; set; }
        public BranchVM BranchVM { get; set; }

        public ICollection<LoanVM> LoansCreatedVMs { get; set; }
    }
}
