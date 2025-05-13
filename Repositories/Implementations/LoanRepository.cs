using AutoMapper;
using Credit_Managment_System_ASP.NET_MVC.Data;
using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.Repositories.Interfaces;

namespace Credit_Managment_System_ASP.NET_MVC.Repositories.Implementations
{
    public class LoanRepository : GenericRepository<Loan>, ILoanRepository
    {
        private readonly IMapper _mappper;
        private readonly AppDbContext _context;
        public LoanRepository(AppDbContext context, IMapper mapper) : base(context,mapper)
        {
            _context = context;
            _mappper = mapper;
        }
    }

}
