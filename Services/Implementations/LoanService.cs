using AutoMapper;
using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.Repositories.Interfaces;
using Credit_Managment_System_ASP.NET_MVC.Services.Interfaces;
using Credit_Managment_System_ASP.NET_MVC.View_Models;

namespace Credit_Managment_System_ASP.NET_MVC.Services.Implementations
{
    public class LoanService : ILoanService
    {
        private readonly IGenericRepository<Loan> _repo;
        private readonly IMapper _mapper;

        public LoanService(IGenericRepository<Loan> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<LoanVM> AddAsync(LoanVM entity)
        {
            if (entity == null)
            {
                return null;
            }

            var loan = new Loan
            {
                DateOfApplication = entity.DateOfApplication,
                Id = entity.Id,
                CustomerId = entity.CustomerId,
                
                Employee = _mapper.Map<Employee>(entity.Employee),
                LoanAmount = entity.LoanAmount,
                LoanDetail = _mapper.Map<LoanDetail>(entity.LoanDetailVM),
                LoanItems = _mapper.Map<ICollection<LoanItem>>(entity.LoanItemVMs),
                Payments = _mapper.Map<ICollection<Payment>>(entity.PaymentVMs),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                

            };
            await _repo.AddAsync(loan);
            return _mapper.Map<LoanVM>(loan);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var getData = await _repo.GetByIdAsync(id);
            if (getData == null)
            {
                return false;
            }
           await _repo.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<LoanVM>> GetAllAsync()
        {
            var loans = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<LoanVM>>(loans);
        }

        public async Task<LoanVM> GetByIdAsync(int id)
        {
            var loan = await _repo.GetByIdAsync(id);
            return _mapper.Map<LoanVM>(loan);
        }

        public async Task UpdateAsync(LoanVM entity)
        {
            var getData = await _repo.GetByIdAsync(entity.Id);
            getData.DateOfApplication = entity.DateOfApplication;
            getData.CustomerId = entity.CustomerId;
            getData.Employee = _mapper.Map<Employee>(entity.Employee);
            getData.LoanAmount = entity.LoanAmount;
            getData.LoanDetail = _mapper.Map<LoanDetail>(entity.LoanDetailVM);
            getData.LoanItems = _mapper.Map<ICollection<LoanItem>>(entity.LoanItemVMs);
            getData.Payments = _mapper.Map<ICollection<Payment>>(entity.PaymentVMs);
            getData.UpdatedAt = DateTime.UtcNow;
            getData.LoanItems = _mapper.Map<ICollection<LoanItem>>(entity.LoanItemVMs);

            await _repo.UpdateAsync(getData);
        }
    }
}
