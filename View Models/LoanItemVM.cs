using Credit_Managment_System_ASP.NET_MVC.Models;

namespace Credit_Managment_System_ASP.NET_MVC.View_Models
{
    public class LoanItemVM : BaseEntityVM
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public int LoanId { get; set; }
        public LoanVM LoanVM { get; set; }

        public int ProductId { get; set; }
        public ProductVM ProductVM { get; set; }
    }
}
