using Credit_Managment_System_ASP.NET_MVC.Models;

namespace Credit_Managment_System_ASP.NET_MVC.View_Models
{
    public class LoanDetailVM : BaseEntityVM
    {
        public decimal RemainingDebt { get; set; }
        public float InterestRate { get; set; }
        public int TermInMonths { get; set; }
        public decimal TotalPayment { get; set; }
        public decimal TotalInterestPaid { get; set; }

        public int LoanId { get; set; }
        public LoanVM LoanVM { get; set; }
    }
}
