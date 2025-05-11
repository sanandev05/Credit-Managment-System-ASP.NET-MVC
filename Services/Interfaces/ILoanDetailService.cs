using Credit_Managment_System_ASP.NET_MVC.Models;

namespace Credit_Managment_System_ASP.NET_MVC.Services.Interfaces
{
    public interface ILoanDetailService
    {
        Task<LoanDetail> GetByIdAsync(int id);
        Task<IEnumerable<LoanDetail>> GetAllAsync();
        Task<LoanDetail> AddAsync(LoanDetail entity);
        Task<LoanDetail> UpdateAsync(LoanDetail entity);
        Task<bool> DeleteAsync(int id);
    }
}
