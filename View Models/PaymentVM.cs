using Credit_Managment_System_ASP.NET_MVC.Models;

namespace Credit_Managment_System_ASP.NET_MVC.View_Models
{
    public class PaymentVM : BaseEntityVM
    {
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        public int LoanId { get; set; }
        public LoanVM LoanVM { get; set; }
    }
}
