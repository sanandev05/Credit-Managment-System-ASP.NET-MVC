using AutoMapper;
using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.Repositories.Interfaces;
using Credit_Managment_System_ASP.NET_MVC.Services.Interfaces;
using Credit_Managment_System_ASP.NET_MVC.View_Models;

namespace Credit_Managment_System_ASP.NET_MVC.Services.Implementations
{
    public class LoanDetailService : ILoanDetailService
    {
        private readonly IGenericRepository<LoanDetail> _repo;
        private readonly IMapper _mapper;
        public LoanDetailService(IGenericRepository<LoanDetail> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<LoanDetailVM> AddAsync(LoanDetailVM entity)
        {
            if (entity == null)
            {
                return null;
            }

            var loanDetail = new LoanDetail
            {
                LoanId = entity.LoanId,
                Loan = _mapper.Map<Loan>(entity.LoanVM),
                InterestRate = entity.InterestRate,
                RemainingDebt = entity.RemainingDebt,
                TotalInterestPaid = entity.TotalInterestPaid,
                TermInMonths = entity.TermInMonths,
                TotalPayment = entity.TotalPayment,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                
            };
           
            await _repo.AddAsync(loanDetail);
            return _mapper.Map<LoanDetailVM>(loanDetail);
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

        public async Task<IEnumerable<LoanDetailVM>> GetAllAsync()
        {
            var loanDetails = await _repo.GetAllAsync();


            return _mapper.Map<IEnumerable<LoanDetailVM>>(loanDetails);
        }

        public async Task<LoanDetailVM> GetByIdAsync(int id)
        {
            var categories = await _repo.GetAllAsync();
            return categories.Select(item => new LoanDetailVM()
            {
                TotalPayment = item.TotalPayment,
                TermInMonths = item.TermInMonths,
                TotalInterestPaid = item.TotalInterestPaid,
                RemainingDebt = item.RemainingDebt,
                Id = item.Id,
                InterestRate = item.InterestRate,
                LoanId = item.LoanId,
                LoanVM = _mapper.Map<LoanVM>(item.Loan),
                CreatedAt = item.CreatedAt,
                UpdatedAt = item.UpdatedAt,
            }).FirstOrDefault(x => x.Id == id);
        }

        public async Task UpdateAsync(LoanDetailVM entity)
        {
            var getData = await _repo.GetByIdAsync(entity.Id);
            await _repo.UpdateAsync(getData);
        }
    }
}
