using AutoMapper;
using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.View_Models;

namespace Credit_Managment_System_ASP.NET_MVC.Custom_Profiles
{
    public class CustomProfile : Profile
    {
        public CustomProfile()
        {
            CreateMap<Branch,BranchVM>().ReverseMap();
            CreateMap<Merchant,MerchantVM>().ReverseMap();
            CreateMap<Customer, CustomerVM>().ReverseMap();
            CreateMap<Category, CategoryVM>().ReverseMap();
            CreateMap<Customer, CustomerVM>().ReverseMap();
            CreateMap<Employee, EmployeeVM>().ReverseMap();
            CreateMap<Loan, LoanVM>().ReverseMap();
            CreateMap<LoanItem, LoanItemVM>().ReverseMap();
            CreateMap<LoanDetail, LoanDetailVM>().ReverseMap();
            CreateMap<Payment, PaymentVM>().ReverseMap();
            CreateMap<Product, ProductVM>().ReverseMap();
            CreateMap<ProductUpdateVM, ProductVM>().ReverseMap();
			CreateMap<Branch, BranchVM>().ReverseMap();
			CreateMap<Merchant, MerchantVM>().ReverseMap();
			
		}
    }
    
}
