using AutoMapper;
using Credit_Managment_System_ASP.NET_MVC.Data;
using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IEnumerable<LoanItem>> GetAllWithIncludeAsync()
        {
            return await _context.LoanItems
                .Include(l => l.Loan)
                .Include(l => l.Product)
                .ToListAsync();
        }
        public async Task<LoanItem> GetByIdWithIncludeAsync(int id)
        {
            return await _context.LoanItems
                .Include(l => l.Loan)
                .Include(l => l.Product)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

    }
}
