using AutoMapper;
using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.Repositories.Interfaces;
using Credit_Managment_System_ASP.NET_MVC.Services.Interfaces;
using Credit_Managment_System_ASP.NET_MVC.View_Models;

namespace Credit_Managment_System_ASP.NET_MVC.Services.Implementations
{
    public class BranchService 
    {
        private readonly IBranchRepository _repo;
        private readonly IMapper _mapper;
        public BranchService(IBranchRepository branch, IMapper mapper)
        {
            _repo = branch;
            _mapper = mapper;
        }
        public async Task<BranchVM> AddAsync(BranchVM entity)
        {
            if (entity == null)
            {
                return null;
            }
            
            var branch = new Branch
            {
                Email = entity.Email,
                Address = entity.Address,
                PhoneNumber = entity.PhoneNumber,
                MerchantId = entity.MerchantId,
                Merchant = _mapper.Map<Merchant>(entity.MerchantVM),
                Employees = _mapper.Map<ICollection<Employee>>(entity.EmployeeVMs),
                Name = entity.Name,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,

            };
            await _repo.AddAsync(branch);
            return _mapper.Map<BranchVM>(branch); 
        }

        public Task<bool> DeleteAsync(int id)
        {
            var getData = _repo.GetByIdAsync(id);
            if(getData == null)
            {
                return Task.FromResult(false);
            }
            _repo.DeleteAsync(id);
            return Task.FromResult(true);
        }

        public async Task<IEnumerable<BranchVM>> GetAllAsync()
        {
            var branches = await _repo.GetAllAsync();
            

            return _mapper.Map<IEnumerable<BranchVM>>(branches);
        }

        public async Task<BranchVM> GetByIdAsync(int id)
        {
            var allBranches = await _repo.GetAllAsync();
            return allBranches.Select(item => new BranchVM()
            {
                Name = item.Name,
                Email = item.Email,
                PhoneNumber = item.PhoneNumber,
                Address = item.Address,
                MerchantId = item.MerchantId,
                MerchantVM = _mapper.Map<MerchantVM>(item.Merchant),
                EmployeeVMs = _mapper.Map<ICollection<EmployeeVM>>(item.Employees),
                CreatedAt = item.CreatedAt,
                UpdatedAt = item.UpdatedAt,
            }).FirstOrDefault(x => x.Id == id);
        }

        public async Task UpdateAsync(BranchVM entity)
        {
            var getData = await _repo.GetByIdAsync(entity.Id);
            await _repo.UpdateAsync(getData);
        }
    }
}
