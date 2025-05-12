using Credit_Managment_System_ASP.NET_MVC.View_Models;

namespace Credit_Managment_System_ASP.NET_MVC.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryVM> GetByIdAsync(int id);
        Task<IEnumerable<CategoryVM>> GetAllAsync();
        Task<CategoryVM> AddAsync(CategoryVM model);
        Task UpdateAsync(CategoryVM model);
        Task<bool> DeleteAsync(int id);
    }
}
