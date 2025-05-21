using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.View_Models;

namespace Credit_Managment_System_ASP.NET_MVC.Services.Interfaces
{
    public interface ILoanDetailService
    {
        Task<LoanDetailVM> GetByIdAsync(int id);
        Task<IEnumerable<LoanDetailVM>> GetAllAsync();
        Task<LoanDetailVM> AddAsync(LoanDetailVM entity);
        Task UpdateAsync(LoanDetailVM entity);
        Task<bool> DeleteAsync(int id);
    }
}
