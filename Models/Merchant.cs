namespace Credit_Managment_System_ASP.NET_MVC.Models
{
	public class Merchant : BaseEntity
	{
        public string Name { get; set; }
        public string LogoUrl { get; set; }

        public ICollection<Branch>? Branches { get; set; }

    }
}
