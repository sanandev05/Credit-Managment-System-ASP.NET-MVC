namespace Credit_Managment_System_ASP.NET_MVC.Models
{
    public class LoanItem : BaseEntity
    {

        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public int LoanId { get; set; }
        public Loan Loan { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }


      
    }
}
