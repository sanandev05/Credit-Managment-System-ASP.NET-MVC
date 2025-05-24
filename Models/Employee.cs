namespace Credit_Managment_System_ASP.NET_MVC.Models
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }

        public int BranchId { get; set; }
        public Branch? Branch { get; set; }

        public ICollection<Loan>? LoansCreated { get; set; }
    }
    
}
