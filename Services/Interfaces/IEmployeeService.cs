using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.View_Models;

namespace Credit_Managment_System_ASP.NET_MVC.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeVM> GetByIdAsync(int id);
        Task<IEnumerable<EmployeeVM>> GetAllAsync();
        Task<EmployeeVM> AddAsync(EmployeeVM entity);
        Task UpdateAsync(EmployeeVM entity);
        Task<bool> DeleteAsync(int id);
    }
}
