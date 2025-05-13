using AutoMapper;
using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.Repositories.Interfaces;
using Credit_Managment_System_ASP.NET_MVC.Services.Interfaces;
using Credit_Managment_System_ASP.NET_MVC.View_Models;

namespace Credit_Managment_System_ASP.NET_MVC.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<ProductVM> AddAsync(ProductVM entity)
        {
            if (entity == null)
            {
                return null;
            }

            var product = new Product
            {
                CategoryId = entity.CategoryId,
                Category = _mapper.Map<Category>(entity.Category),
                Description = entity.Description,
                ImageUrl = entity.ImageUrl,
                loanItems = _mapper.Map<ICollection<LoanItem>>(entity.loanItems),
                Name = entity.Name,
                Price = entity.Price,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,

            };

            await _repo.AddAsync(product);
            return _mapper.Map<ProductVM>(product);
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

        public async Task<IEnumerable<ProductVM>> GetAllAsync()
        {
            var products = await _repo.GetAllWithInclude();


            return _mapper.Map<IEnumerable<ProductVM>>(products);
        }

        public async Task<ProductVM> GetByIdAsync(int id)
        {
            var category = await _repo.GetByIdWithInclude(id);
            return _mapper.Map<ProductVM>(category);
        }

        public async Task UpdateAsync(ProductVM entity)
        {
            var getData = await _repo.GetByIdAsync(entity.Id);
            await _repo.UpdateAsync(getData);
        }

        
    }
}
