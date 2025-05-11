using AutoMapper;
using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.View_Models;

namespace Credit_Managment_System_ASP.NET_MVC.Custom_Profiles
{
    public class CustomProfile : Profile
    {
        public CustomProfile()
        {
            CreateMap<Branch,BranchVM>();
            CreateMap<Merchant,MerchantVM>();
            CreateMap<Customer, CustomerVM>();
            CreateMap<Category, CategoryVM>();
            CreateMap<Customer, CustomerVM>();
            CreateMap<Employee, EmployeeVM>();
            CreateMap<Loan, LoanVM>();
            CreateMap<LoanItem, LoanItemVM>();
            CreateMap<LoanDetail, LoanDetailVM>();
            CreateMap<Payment, PaymentVM>();
        }
    }
    
}
