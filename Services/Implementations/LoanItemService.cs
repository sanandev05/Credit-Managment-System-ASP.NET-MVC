using AutoMapper;
using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.Repositories.Interfaces;
using Credit_Managment_System_ASP.NET_MVC.View_Models;

namespace Credit_Managment_System_ASP.NET_MVC.Services.Implementations
{
    public class LoanItemService
    {
        private readonly IGenericRepository<LoanItem> _repo;
        private readonly IMapper _mapper;
        public LoanItemService(IGenericRepository<LoanItem> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<LoanItemVM> AddAsync(LoanItemVM entity)
        {
            if (entity == null)
            {
                return null;
            }

            var loanItem = new LoanItem
            {
                LoanId = entity.LoanId,
                Loan = _mapper.Map<Loan>(entity.LoanVM),
                Product = _mapper.Map<Product>(entity.ProductVM),
                ProductId = entity.ProductId,
                Price = entity.Price,
                Quantity = entity.Quantity,            
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,

            };
           
            await _repo.AddAsync(loanItem);
            return _mapper.Map<LoanItemVM>(loanItem);
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

        public async Task<IEnumerable<LoanItemVM>> GetAllAsync()
        {
            var loanItems = await _repo.GetAllAsync();


            return _mapper.Map<IEnumerable<LoanItemVM>>(loanItems);
        }

        public async Task<LoanItemVM> GetByIdAsync(int id)
        {
            var categories = await _repo.GetAllAsync();
            return categories.Select(item => new LoanItemVM()
            {
                Quantity = item.Quantity,
                Price = item.Price,
                ProductId = item.ProductId,
                ProductVM = _mapper.Map<ProductVM>(item.Product),
                LoanId = item.LoanId,
                LoanVM = _mapper.Map<LoanVM>(item.Loan),
                CreatedAt = item.CreatedAt,
                UpdatedAt = item.UpdatedAt,
            }).FirstOrDefault(x => x.Id == id);
        }

        public async Task UpdateAsync(LoanItemVM entity)
        {
            var getData = await _repo.GetByIdAsync(entity.Id);
            await _repo.UpdateAsync(getData);
        }
    }
}
