using Credit_Managment_System_ASP.NET_MVC.View_Models;

namespace Credit_Managment_System_ASP.NET_MVC.Services.Interfaces
{
    public interface IMerchantService
    {
        Task<MerchantVM> GetByIdAsync(int id);
        Task<IEnumerable<MerchantVM>> GetAllAsync();
        Task<MerchantVM> AddAsync(MerchantVM entity);
        Task UpdateAsync(MerchantVM entity);
        Task<bool> DeleteAsync(int id);
    }
}
