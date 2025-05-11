using Credit_Managment_System_ASP.NET_MVC.Models;

namespace Credit_Managment_System_ASP.NET_MVC.View_Models
{
    public class CategoryVM : BaseEntityVM
    {
        public string Name { get; set; }
        public int MerchantId { get; set; }
        public MerchantVM MerchantVMs { get; set; }
        public int? ParentId { get; set; }
        public ICollection<ProductVM> ProductVMs { get; set; }
    }
}
