using AutoMapper;
using Credit_Managment_System_ASP.NET_MVC.Data;
using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IEnumerable<Loan>> GetAllWithIncludeAsync()
        {
            return await _context.Loans
                .Include(l => l.Customer)
                .Include(l => l.Employee)
                .Include(l => l.LoanDetail)
                .Include(l => l.LoanItems)
                .Include(l => l.Payments)
                .ToListAsync();
        }
        public async Task<Loan> GetByIdWithIncludeAsync(int id)
        {
            return await _context.Loans
                .Include(l => l.Customer)
                .Include(l => l.Employee)
                .Include(l => l.LoanDetail)
                .Include(l => l.LoanItems)
                .Include(l => l.Payments)
                .FirstOrDefaultAsync(l => l.Id == id);
        }
    }

}
