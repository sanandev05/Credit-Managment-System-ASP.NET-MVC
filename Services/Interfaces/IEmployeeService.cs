using Credit_Managment_System_ASP.NET_MVC.Models;

namespace Credit_Managment_System_ASP.NET_MVC.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<Employee> GetByIdAsync(int id);
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> AddAsync(Employee entity);
        Task<Employee> UpdateAsync(Employee entity);
        Task<bool> DeleteAsync(int id);
    }
}
