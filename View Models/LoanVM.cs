using Credit_Managment_System_ASP.NET_MVC.Models;

namespace Credit_Managment_System_ASP.NET_MVC.View_Models
{
    public class LoanVM : BaseEntityVM
    {
        public decimal LoanAmount { get; set; }

        public DateTime DateOfApplication { get; set; }
        public LoanStatus Status { get; set; } = LoanStatus.Pending;

        public int CustomerId { get; set; }
        public CustomerVM CustomerVM { get; set; }
        public LoanDetailVM LoanDetailVM { get; set; }
        public ICollection<LoanItemVM> LoanItemVMs { get; set; }
        public ICollection<PaymentVM> PaymentVMs { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeVM Employee { get; set; }
    }
}
