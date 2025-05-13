using Credit_Managment_System_ASP.NET_MVC.Models;

namespace Credit_Managment_System_ASP.NET_MVC.Repositories.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product> GetByIdWithInclude(int id);
        Task<IEnumerable<Product>> GetAllWithInclude();
    }
}
