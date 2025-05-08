namespace Credit_Managment_System_ASP.NET_MVC.Models
{
    public class Loan : BaseEntity
    {
        public decimal LoanAmount { get; set; }
       
        public DateTime DateOfApplication { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public LoanDetail LoanDetail { get; set; } 
        public ICollection<LoanItem> LoanItems { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

    }
}