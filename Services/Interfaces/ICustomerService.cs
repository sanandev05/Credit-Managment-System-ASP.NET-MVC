using Credit_Managment_System_ASP.NET_MVC.Models;

namespace Credit_Managment_System_ASP.NET_MVC.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> GetByIdAsync(int id);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> AddAsync(Customer entity);
        Task<Customer> UpdateAsync(Customer entity);
        Task<bool> DeleteAsync(int id);
    }
}
