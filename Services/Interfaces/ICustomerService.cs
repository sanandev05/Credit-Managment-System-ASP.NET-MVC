using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.View_Models;

namespace Credit_Managment_System_ASP.NET_MVC.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerVM> GetByIdAsync(int id);
        Task<IEnumerable<CustomerVM>> GetAllAsync();
        Task<CustomerVM> AddAsync(CustomerVM entity);
        Task UpdateAsync(CustomerVM entity);
        Task<bool> DeleteAsync(int id);
    }
}
