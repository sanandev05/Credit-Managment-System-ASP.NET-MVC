using Credit_Managment_System_ASP.NET_MVC.Models;

namespace Credit_Managment_System_ASP.NET_MVC.View_Models
{
    public class CategoryVM : BaseEntityVM
    {
        public string Name { get; set; }
        public int MerchantId { get; set; }
        public MerchantVM MerchantVM { get; set; }
        public int? ParentCategoryId { get; set; }
        public CategoryVM? ParentCategoryVM { get; set; }
        public ICollection<CategoryVM> SubcategoryVMs { get; set; } = new List<CategoryVM>();
        public ICollection<ProductVM> ProductVMs { get; set; }
    }
}
