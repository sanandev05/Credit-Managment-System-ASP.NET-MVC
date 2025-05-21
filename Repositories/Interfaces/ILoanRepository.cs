using Credit_Managment_System_ASP.NET_MVC.Models;
namespace Credit_Managment_System_ASP.NET_MVC.Repositories.Interfaces
{
    public interface ILoanRepository : IGenericRepository<Loan>
    {
        Task<IEnumerable<Loan>> GetAllWithIncludeAsync();
        Task<Loan> GetByIdWithIncludeAsync(int id);
    }
}
