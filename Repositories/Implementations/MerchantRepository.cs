using AutoMapper;
using Credit_Managment_System_ASP.NET_MVC.Data;
using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Credit_Managment_System_ASP.NET_MVC.Repositories.Implementations
{
    public class MerchantRepository : GenericRepository<Merchant>, IMerchantRepository
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        public MerchantRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Merchant>> GetAllWithInclude()
        {
            var merchants = await _context.Merchants
                 .Include(x => x.Branches)
                 .Where(x => !x.IsDeleted)
                 .ToListAsync()
                 .ContinueWith(task => task.Result.AsEnumerable());
            return merchants;
        }
        public async Task<Merchant> GetByIdWithInclude(int id)
        {
            var merchant = await _context.Merchants
                  .Include(x => x.Branches)
                .Where(x => x.Id == id && !x.IsDeleted)
                .FirstOrDefaultAsync();
            return merchant;
        }
    }

}
