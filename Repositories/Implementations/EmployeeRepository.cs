using AutoMapper;
using Credit_Managment_System_ASP.NET_MVC.Data;
using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Credit_Managment_System_ASP.NET_MVC.Repositories.Implementations
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Employee>> GetAllWithInclude()
        {
            var employees = await _context.Employees
                .Include(b => b.LoansCreated)
                .Include(b => b.Branch)
                .Where(b => !b.IsDeleted)
                .ToListAsync()
                .ContinueWith(task => task.Result.AsEnumerable());
            return employees;
        }

        public async Task<Employee> GetByIdWithInclude(int id)
        {
            var employee = await _context.Employees
               .Include(b => b.LoansCreated)
               .Include(b => b.Branch)
               .Where(b => b.Id == id && !b.IsDeleted)
                .FirstOrDefaultAsync();
            return employee;
        }
    }
    
}
