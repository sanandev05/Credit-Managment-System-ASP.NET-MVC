using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.View_Models;

namespace Credit_Managment_System_ASP.NET_MVC.Services.Interfaces
{
    public interface ILoanItemService
    {
        Task<LoanItemVM> GetByIdAsync(int id);
        Task<IEnumerable<LoanItemVM>> GetAllAsync();
        Task<LoanItemVM> AddAsync(LoanItemVM entity);
        Task UpdateAsync(LoanItemVM entity);
        Task<bool> DeleteAsync(int id);
    }
}
