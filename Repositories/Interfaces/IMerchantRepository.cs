using Credit_Managment_System_ASP.NET_MVC.Models;

namespace Credit_Managment_System_ASP.NET_MVC.Repositories.Interfaces
{
    public interface IMerchantRepository : IGenericRepository<Merchant>
    {
		Task<IEnumerable<Merchant>> GetAllWithInclude();
		Task<Merchant> GetByIdWithInclude(int id);
	}
}
