using AutoMapper;
using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.Repositories.Interfaces;
using Credit_Managment_System_ASP.NET_MVC.Services.Interfaces;
using Credit_Managment_System_ASP.NET_MVC.View_Models;

namespace Credit_Managment_System_ASP.NET_MVC.Services.Implementations
{
    public class MerchantService : IMerchantService
    {
        private readonly IMerchantRepository _repo;
        private readonly IMapper _mapper;

		public MerchantService(IMerchantRepository merchantRepository, IMapper mapper)
		{
			_repo = merchantRepository;
			_mapper = mapper;
		}
		public async Task<MerchantVM> AddAsync(MerchantVM entity)
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
           await _repo.AddAsync(merchant);
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
          await _repo.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<MerchantVM>> GetAllAsync()
        {
            var merchants = await _repo.GetAllAsync();
           
            return _mapper.Map<IEnumerable<MerchantVM>>(merchants);
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
           getData.Name = entity.Name;
            getData.LogoUrl = entity.LogoUrl;
            getData.Branches = entity.Branches;
            getData.UpdatedAt = DateTime.UtcNow;
            getData.IsDeleted = false;

            await _repo.UpdateAsync(getData);       
        }
    }


}
