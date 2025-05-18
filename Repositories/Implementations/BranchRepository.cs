using AutoMapper;
using Credit_Managment_System_ASP.NET_MVC.Data;
using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Credit_Managment_System_ASP.NET_MVC.Repositories.Implementations
{
    public class BranchRepository : GenericRepository<Branch>, IBranchRepository
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        public BranchRepository(AppDbContext context, IMapper mapper) : base(context,mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Branch>> GetAllWithInclude()
        {
            var branches = await _context.Branches
                .Include(b => b.Merchant)
                .Include(b => b.Employees)
                .Where(b => !b.IsDeleted)
                .ToListAsync()
                .ContinueWith(task => task.Result.AsEnumerable());
            return branches;
        }

        public async Task<Branch> GetByIdWithInclude(int id)
        {
            var branch = await _context.Branches
                .Include(b => b.Merchant)
                .Include(b => b.Employees)
                .Where(b => b.Id == id && !b.IsDeleted)
                .FirstOrDefaultAsync();
            return branch;
        }


    }
}
