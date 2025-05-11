using AutoMapper;
using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.Repositories.Interfaces;
using Credit_Managment_System_ASP.NET_MVC.View_Models;

namespace Credit_Managment_System_ASP.NET_MVC.Services.Implementations
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _repo;
        private readonly IMapper _mapper;
        public EmployeeService(IEmployeeRepository employee, IMapper mapper)
        {
            _repo = employee;
            _mapper = mapper;
        }
        public async Task<EmployeeVM> AddAsync(EmployeeVM entity)
        {
            if (entity == null)
            {
                return null;
            }

            var employee = new Employee
            {
                Branch = _mapper.Map<Branch>(entity.BranchVM),
                BranchId = entity.BranchId,
                LoansCreated = _mapper.Map<ICollection<Loan>>(entity.LoansCreatedVMs),
                PhoneNumber = entity.PhoneNumber,
                Surname = entity.Surname,
                Name = entity.Name,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,

            };
            await _repo.AddAsync(employee);
            return _mapper.Map<EmployeeVM>(employee);
        }

        public Task<bool> DeleteAsync(int id)
        {
            var getData = _repo.GetByIdAsync(id);
            if (getData == null)
            {
                return Task.FromResult(false);
            }
            _repo.DeleteAsync(id);
            return Task.FromResult(true);
        }

        public async Task<IEnumerable<EmployeeVM>> GetAllAsync()
        {
            var employees = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<EmployeeVM>>(employees);
        }

        public async Task<EmployeeVM> GetByIdAsync(int id)
        {
            var employees = await _repo.GetAllAsync();
            if (employees == null)
            {
                return null;
            }

            return employees.Select(item => new EmployeeVM()
            {
                Name = item.Name,
               Surname= item.Surname,
                PhoneNumber = item.PhoneNumber,
                BranchId = item.BranchId,
                BranchVM = _mapper.Map<BranchVM>(item.Branch),
                LoansCreatedVMs = _mapper.Map<ICollection<LoanVM>>(item.LoansCreated),
                CreatedAt = item.CreatedAt,
                UpdatedAt = item.UpdatedAt,
            }).FirstOrDefault(x => x.Id == id);
        }

        public async Task UpdateAsync(EmployeeVM entity)
        {
            var getData = await _repo.GetByIdAsync(entity.Id);
            await _repo.UpdateAsync(getData);
        }
    }
}
