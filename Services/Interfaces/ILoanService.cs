using Credit_Managment_System_ASP.NET_MVC.Models;
using System.Drawing;

namespace Credit_Managment_System_ASP.NET_MVC.Services.Interfaces
{
    public interface ILoanService
    {
        Task<Loan> GetByIdAsync(int id);
        Task<IEnumerable<Loan>> GetAllAsync();
        Task<Loan> AddAsync(Loan entity);
        Task<Loan> UpdateAsync(Loan entity);
        Task<bool> DeleteAsync(int id);
    }
}
