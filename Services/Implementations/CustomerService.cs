using AutoMapper;
using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.Repositories.Interfaces;
using Credit_Managment_System_ASP.NET_MVC.View_Models;

namespace Credit_Managment_System_ASP.NET_MVC.Services.Implementations
{
    public class CustomerService
    {
        private readonly IGenericRepository<Customer> _repo;
        private readonly IMapper _mapper;

        public CustomerService(IGenericRepository<Customer> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CustomerVM> AddAsync(CustomerVM entity)
        {
            if (entity == null)
            {
                return null;
            }

            var customer = new Customer
            {
                Loans = _mapper.Map<ICollection<Loan>>(entity.LoanVMs),
                PhoneNumber = entity.PhoneNumber,
                Surname = entity.Surname,
                Name = entity.Name,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,

            };
            await _repo.AddAsync(customer);
            return _mapper.Map<CustomerVM>(customer);
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

        public async Task<IEnumerable<CustomerVM>> GetAllAsync()
        {
            var customers = await _repo.GetAllAsync();


            return _mapper.Map<IEnumerable<CustomerVM>>(customers);
        }

        public async Task<CustomerVM> GetByIdAsync(int id)
        {
            var customers = await _repo.GetAllAsync();
            return customers.Select(item => new CustomerVM()
            {
                Name = item.Name,
               LoanVMs = _mapper.Map<ICollection<LoanVM>>(item.Loans),
                Surname = item.Surname,
                PhoneNumber = item.PhoneNumber,
                CreatedAt = item.CreatedAt,
                UpdatedAt = item.UpdatedAt,
            }).FirstOrDefault(x => x.Id == id);
        }

        public async Task UpdateAsync(CustomerVM entity)
        {
            var getData = await _repo.GetByIdAsync(entity.Id);
            await _repo.UpdateAsync(getData);
        }
    }
}
