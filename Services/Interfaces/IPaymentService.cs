using Credit_Managment_System_ASP.NET_MVC.Models;

namespace Credit_Managment_System_ASP.NET_MVC.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<Payment> GetByIdAsync(int id);
        Task<IEnumerable<Payment>> GetAllAsync();
        Task<Payment> AddAsync(Payment entity);
        Task<Payment> UpdateAsync(Payment entity);
        Task<bool> DeleteAsync(int id);
    }
}
