using AutoMapper;
using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.Repositories.Interfaces;
using Credit_Managment_System_ASP.NET_MVC.Services.Interfaces;
using Credit_Managment_System_ASP.NET_MVC.View_Models;

namespace Credit_Managment_System_ASP.NET_MVC.Services.Implementations
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _repo;
        private readonly IMerchantRepository _merchantRepo;
        private readonly IMapper _mapper;
        public BranchService(IBranchRepository branch, IMapper mapper, IMerchantRepository merchantRepo)
        {
            _repo = branch;
            _mapper = mapper;
            _merchantRepo = merchantRepo;
        }
        public async Task<BranchVM> CreateAsync(BranchVM entity)
        {


            var branch = new Branch
            {
                Email = entity.Email,
                Address = entity.Address,
                PhoneNumber = entity.PhoneNumber,
                MerchantId = entity.MerchantId,
                Merchant = _mapper.Map<Merchant>(entity.Merchant),
                Employees = _mapper.Map<ICollection<Employee>>(entity.Employee),
                Name = entity.Name,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,

            };
            await _repo.AddAsync(branch);
            return _mapper.Map<BranchVM>(branch);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var getData = await _repo.GetByIdWithInclude(id);
            if (getData == null)
            {
                return false;
            }
            await _repo.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<BranchVM>> GetAllAsync()
        {
            var branches = await _repo.GetAllWithInclude();
            var map = _mapper.Map<IEnumerable<BranchVM>>(branches);
            return map;
        }


        public async Task<BranchVM> GetByIdAsync(int id)
        {
            var Branch = await _repo.GetByIdWithInclude(id);

            return _mapper.Map<BranchVM>(Branch);
        }

        public async Task UpdateAsync(BranchVM entity)
        {
            var getData = await _repo.GetByIdWithInclude(entity.Id);
            getData.PhoneNumber = entity.PhoneNumber;
            getData.Email = entity.Email;
            getData.PhoneNumber = entity.PhoneNumber;
            getData.Address = entity.Address;
            getData.MerchantId = entity.MerchantId;
          //  getData.Merchant = _mapper.Map<Merchant>(entity.Merchant);
            getData.Employees = _mapper.Map<ICollection<Employee>>(entity.Employee);
            getData.Name = entity.Name;
            getData.UpdatedAt = DateTime.UtcNow;

            await _repo.UpdateAsync(getData);
        }
    }
}
