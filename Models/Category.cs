namespace Credit_Managment_System_ASP.NET_MVC.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public ICollection<Product>? Products { get; set; }
        public ICollection<Category>? ParentCategories { get; set; }
    }
}
