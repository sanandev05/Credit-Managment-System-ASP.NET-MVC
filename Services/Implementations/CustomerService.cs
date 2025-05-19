using AutoMapper;
using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.Repositories.Interfaces;
using Credit_Managment_System_ASP.NET_MVC.Services.Interfaces;
using Credit_Managment_System_ASP.NET_MVC.View_Models;

namespace Credit_Managment_System_ASP.NET_MVC.Services.Implementations
{
    public class CustomerService : ICustomerService
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
                Loans = _mapper.Map<ICollection<Loan>>(entity.Loans),
                PhoneNumber = entity.PhoneNumber,
                Surname = entity.Surname,
                Name = entity.Name,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Payments = _mapper.Map<ICollection<Payment>>(entity.Payments),
            };
            await _repo.AddAsync(customer);
            return _mapper.Map<CustomerVM>(customer);
        }

     

        public async Task<bool> DeleteAsync(int id)
        {
            var getData =await _repo.GetByIdAsync(id);
            if (getData == null)
            {
                return false;
            }
           await _repo.DeleteAsync(id);
            return true;
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
               Loans = _mapper.Map<ICollection<LoanVM>>(item.Loans),
                Surname = item.Surname,
                PhoneNumber = item.PhoneNumber,
                CreatedAt = item.CreatedAt,
                UpdatedAt = item.UpdatedAt,
                Payments = _mapper.Map<ICollection<PaymentVM>>(item.Payments),
                 Id = id
            }).FirstOrDefault(x => x.Id == id);
        }

        public async Task UpdateAsync(CustomerVM entity)
        {
            var getData = await _repo.GetByIdAsync(entity.Id);
            getData.Surname = entity.Surname;
            getData.PhoneNumber = entity.PhoneNumber;
            getData.CreatedAt = entity.CreatedAt;
            getData.UpdatedAt = entity.UpdatedAt;
            getData.Payments = _mapper.Map<ICollection<Payment>>(entity.Payments);
            getData.Loans = _mapper.Map<ICollection<Loan>>(entity.Loans);
            getData.Name = entity.Name;

            getData.Id = entity.Id;

            await _repo.UpdateAsync(getData);
        }

      
    }
}
