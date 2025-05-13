using Credit_Managment_System_ASP.NET_MVC.Models;

namespace Credit_Managment_System_ASP.NET_MVC.Repositories.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        public Task<Category> GetByIdWithInclude(int id);
        public Task<IEnumerable<Category>> GetAllWithInclude();
        public Task Update(Category entity);
    }
}
