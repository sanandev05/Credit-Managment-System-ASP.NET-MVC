using Credit_Managment_System_ASP.NET_MVC.Models;

namespace Credit_Managment_System_ASP.NET_MVC.View_Models
{
    public class ProductVM : BaseEntityVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IFormFile Image { get; set; }
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }
        public CategoryVM Category { get; set; }
        public ICollection<CategoryVM> CategoryVMs { get; set; }
        public ICollection<LoanItemVM> loanItems { get; set; }
    }
}
