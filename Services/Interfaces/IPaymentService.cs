using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.View_Models;

namespace Credit_Managment_System_ASP.NET_MVC.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentVM> GetByIdAsync(int id);
        Task<IEnumerable<PaymentVM>> GetAllAsync();
        Task<PaymentVM> AddAsync(PaymentVM entity);
        Task UpdateAsync(PaymentVM entity);
        Task<bool> DeleteAsync(int id);
    }
}
