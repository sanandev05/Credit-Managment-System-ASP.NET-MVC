using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.View_Models;

namespace Credit_Managment_System_ASP.NET_MVC.Services.Interfaces
{
    public interface IBranchService
    {
        Task<BranchVM> GetByIdAsync(int id);
        Task<IEnumerable<BranchVM>> GetAllAsync();
        Task<BranchVM> AddAsync(BranchVM model);
        Task UpdateAsync(BranchVM model);
        Task<bool> DeleteAsync(int id);
    }
}
