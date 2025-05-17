using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.View_Models;

namespace Credit_Managment_System_ASP.NET_MVC.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductVM> GetByIdAsync(int id);
        Task<IEnumerable<ProductVM>> GetAllAsync();
        Task<ProductVM> AddAsync(ProductVM entity);
        Task UpdateAsync(ProductUpdateVM entity);
        Task<bool> DeleteAsync(int id);
    }
}
