using AutoMapper;
using Credit_Managment_System_ASP.NET_MVC.Data;
using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.Repositories.Interfaces;

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
    }

}
