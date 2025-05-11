using Credit_Managment_System_ASP.NET_MVC.Models;

namespace Credit_Managment_System_ASP.NET_MVC.Services.Interfaces
{
    public interface ILoanItemService
    {
        Task<LoanItem> GetByIdAsync(int id);
        Task<IEnumerable<LoanItem>> GetAllAsync();
        Task<LoanItem> AddAsync(LoanItem entity);
        Task<LoanItem> UpdateAsync(LoanItem entity);
        Task<bool> DeleteAsync(int id);
    }
}
