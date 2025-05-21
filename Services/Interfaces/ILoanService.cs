using Credit_Managment_System_ASP.NET_MVC.View_Models;
using System.Drawing;

namespace Credit_Managment_System_ASP.NET_MVC.Services.Interfaces
{
    public interface ILoanService
    {
        Task<LoanVM> GetByIdAsync(int id);
        Task<IEnumerable<LoanVM>> GetAllAsync();
        Task<LoanVM> AddAsync(LoanVM entity);
        Task UpdateAsync(LoanVM entity);
        Task<bool> DeleteAsync(int id);
    }
}
