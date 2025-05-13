using AutoMapper;
using Credit_Managment_System_ASP.NET_MVC.Data;
using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Credit_Managment_System_ASP.NET_MVC.Repositories.Implementations
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ProductRepository(AppDbContext context, IMapper mapper) : base(context,mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<IEnumerable<Product>> GetAllWithInclude()
        {
           var products = _context.Products
                .Include(x=>x.Category)
                .Include(x => x.loanItems)
                .Where(x => !x.IsDeleted)
                .ToListAsync()
                .ContinueWith(task => task.Result.AsEnumerable());
            return products;
        }
        public Task<Product> GetByIdWithInclude(int id)
        {
            var product = _context.Products
                .Include(x => x.Category)
                .Include(x => x.loanItems)
                .Where(x => x.Id == id && !x.IsDeleted)
                .FirstOrDefaultAsync();
            return product;
        }
    }
    
}
