namespace Credit_Managment_System_ASP.NET_MVC.Models
{
    public class Payment : BaseEntity
    {
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        public int LoanId { get; set; }
        public Loan? Loan { get; set; }
    }
}
