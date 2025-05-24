using Credit_Managment_System_ASP.NET_MVC.Models;

namespace Credit_Managment_System_ASP.NET_MVC.View_Models
{
    public class CustomerVM : BaseEntityVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<LoanVM>? Loans { get; set; }
        public ICollection<PaymentVM>? Payments { get; set; }
    }
}
