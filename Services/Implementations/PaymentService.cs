using AutoMapper;
using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.Repositories.Interfaces;
using Credit_Managment_System_ASP.NET_MVC.View_Models;

namespace Credit_Managment_System_ASP.NET_MVC.Services.Implementations
{
    public class PaymentService
    {
        private readonly IGenericRepository<Payment> _repo;
        private readonly IMapper _mapper;
        public PaymentService(IGenericRepository<Payment> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<PaymentVM> AddAsync(PaymentVM entity)
        {
            if (entity == null)
            {
                return null;
            }

            var payment = new Payment
            {
                LoanId = entity.LoanId,
               Amount = entity.Amount,
                Loan = _mapper.Map<Loan>(entity.LoanVM),
                PaymentDate = entity.PaymentDate,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,

            };

            await _repo.AddAsync(payment);
            return _mapper.Map<PaymentVM>(payment);
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

        public async Task<IEnumerable<PaymentVM>> GetAllAsync()
        {
            var payments = await _repo.GetAllAsync();


            return _mapper.Map<IEnumerable<PaymentVM>>(payments);
        }

        public async Task<PaymentVM> GetByIdAsync(int id)
        {
            var categories = await _repo.GetAllAsync();
            return categories.Select(item => new PaymentVM()
            {
                Amount = item.Amount,
                PaymentDate = item.PaymentDate,
                Id = item.Id,
                LoanId = item.LoanId,
                LoanVM = _mapper.Map<LoanVM>(item.Loan),
                CreatedAt = item.CreatedAt,
                UpdatedAt = item.UpdatedAt,
            }).FirstOrDefault(x => x.Id == id);
        }

        public async Task UpdateAsync(PaymentVM entity)
        {
            var getData = await _repo.GetByIdAsync(entity.Id);
            await _repo.UpdateAsync(getData);
        }
    }
}
