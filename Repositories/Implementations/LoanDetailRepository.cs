using AutoMapper;
using Credit_Managment_System_ASP.NET_MVC.Data;
using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Credit_Managment_System_ASP.NET_MVC.Repositories.Implementations
{
    public class LoanDetailRepository : GenericRepository<LoanDetail>, ILoanDetailRepository
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        public LoanDetailRepository(AppDbContext _context, IMapper mapper) : base(_context, mapper)
        {
            _context = _context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LoanDetail>> GetAllWithIncludeAsync()
        {
            return await _context.LoanDetails
                .Include(x => x.Loan)
                .ToListAsync();
        }

        public async Task<LoanDetail> GetByIdWithIncludeAsync(int id)
        {
            return await _context.LoanDetails
                .Include(x => x.Loan)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

