using AutoMapper;
using Credit_Managment_System_ASP.NET_MVC.Data;
using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Credit_Managment_System_ASP.NET_MVC.Repositories.Implementations
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        public CustomerRepository(AppDbContext context, IMapper mapper) : base(context,mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Customer>> GetAllWithInclude()
        {
            var customers = await _context.Customers
                .Include(b => b.Loans)
                .Include(b => b.Payments)
                .Where(b => !b.IsDeleted)
                .ToListAsync()
                .ContinueWith(task => task.Result.AsEnumerable());
            return customers;
        }

        public async Task<Customer> GetByIdWithInclude(int id)
        {
            var customer = await _context.Customers
                .Include(b => b.Loans)
                .Include(b => b.Payments)
                .Where(b => b.Id == id && !b.IsDeleted)
                .FirstOrDefaultAsync();
            return customer;
        }
    }
   
}
