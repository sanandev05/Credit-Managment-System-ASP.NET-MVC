using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.Repositories.Interfaces;
using Credit_Managment_System_ASP.NET_MVC.Services.Interfaces;
using Credit_Managment_System_ASP.NET_MVC.View_Models;

namespace Credit_Managment_System_ASP.NET_MVC.Services.Implementations
{
    public class MerchantService : IMerchantService
    {
        private readonly IMerchantRepository _repo;

        public MerchantService(IMerchantRepository merchantRepository)
        {
            _repo = merchantRepository;
        }
        public Task<MerchantVM> AddAsync(MerchantVM entity)
        {
            if (entity == null)
            {
                return null;
            }
            var merchant = new Merchant
            {
                Branches = entity.Branches,
                IsDeleted = false,
                LogoUrl = entity.LogoUrl,
                Name = entity.Name,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                
            };
            _repo.AddAsync(merchant);
            return Task.FromResult(entity);
        }

        public Task<bool> DeleteAsync(int id)
        {
           _repo.DeleteAsync(id);
            return Task.FromResult(true);
        }

        public async Task<IEnumerable<MerchantVM>> GetAllAsync()
        {
            var merchants = await _repo.GetAllAsync();
           
            return merchants.Select(item=>new MerchantVM()
            {
                Branches = item.Branches,
                LogoUrl = item.LogoUrl,
                Name = item.Name,
            });
        }

        public async Task<MerchantVM> GetByIdAsync(int id)
        {
            var allMerchants = await _repo.GetAllAsync();
            return allMerchants.Select(item => new MerchantVM()
            {
                Branches = item.Branches,
                LogoUrl = item.LogoUrl,
                Name = item.Name,
            }).FirstOrDefault(x => x.Id == id);
        }

        public async Task UpdateAsync(MerchantVM entity)
        {
           var getData=await _repo.GetByIdAsync(entity.Id);
           await _repo.UpdateAsync(getData);       
        }
    }


}
