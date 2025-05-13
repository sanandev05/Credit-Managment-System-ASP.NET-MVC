namespace Credit_Managment_System_ASP.NET_MVC.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }              
        public string Description { get; set; }        
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string? ImageUrl { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<LoanItem> loanItems { get; set; }
    }
}
