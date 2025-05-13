using AutoMapper;
using Credit_Managment_System_ASP.NET_MVC.Data;
using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.Repositories.Interfaces;

namespace Credit_Managment_System_ASP.NET_MVC.Repositories.Implementations
{
    public class LoanItemRepository : GenericRepository<LoanItem>,ILoanItemRepository  
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        public LoanItemRepository(AppDbContext _context, IMapper mapper) : base(_context, mapper)
        {
            _context = _context;
            _mapper = mapper;
        }

    }
}
