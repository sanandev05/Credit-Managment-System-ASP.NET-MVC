namespace Credit_Managment_System_ASP.NET_MVC.Models
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Loan>? Loans { get; set; }
        public ICollection<Payment>? Payments { get; set; }
    }
}
