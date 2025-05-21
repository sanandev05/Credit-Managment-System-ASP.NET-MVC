using Credit_Managment_System_ASP.NET_MVC.Models;

namespace Credit_Managment_System_ASP.NET_MVC.Repositories.Interfaces
{
    public interface ILoanDetailRepository : IGenericRepository<LoanDetail>
    {
        Task<IEnumerable<LoanDetail>> GetAllWithIncludeAsync();
        Task<LoanDetail> GetByIdWithIncludeAsync(int id);
    }
}
