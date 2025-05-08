namespace Credit_Managment_System_ASP.NET_MVC.Models
{
    public class Branch : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public int MerchantId { get; set; }
        public Merchant Merchant { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
