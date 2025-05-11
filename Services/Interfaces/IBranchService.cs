using Credit_Managment_System_ASP.NET_MVC.Models;

namespace Credit_Managment_System_ASP.NET_MVC.Services.Interfaces
{
    public interface IBranchService
    {
        Task<Branch> GetByIdAsync(int id);
        Task<IEnumerable<Branch>> GetAllAsync();
        Task<Branch> AddAsync(Branch entity);
        Task<Branch> UpdateAsync(Branch entity);
        Task<bool> DeleteAsync(int id);
    }
}
