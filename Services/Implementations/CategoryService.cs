using AutoMapper;
using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.Repositories.Interfaces;
using Credit_Managment_System_ASP.NET_MVC.Services.Interfaces;
using Credit_Managment_System_ASP.NET_MVC.View_Models;

namespace Credit_Managment_System_ASP.NET_MVC.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _repo;
        private readonly IMapper _mapper;
        public CategoryService(IGenericRepository<Category> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<CategoryVM> AddAsync(CategoryVM entity)
        {
            if (entity == null)
            {
                return null;
            }

            var branch = new Category
            {
                MerchantId = entity.MerchantId,
                Merchant = _mapper.Map<Merchant>(entity.MerchantVMs),
                Products = _mapper.Map<ICollection<Product>>(entity.ProductVMs),
                ParentId = entity.ParentId,
                Name = entity.Name,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,

            };
            await _repo.AddAsync(branch);
            return _mapper.Map<CategoryVM>(branch);
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

        public async Task<IEnumerable<CategoryVM>> GetAllAsync()
        {
            var categories = await _repo.GetAllAsync();


            return _mapper.Map<IEnumerable<CategoryVM>>(categories);
        }

        public async Task<CategoryVM> GetByIdAsync(int id)
        {
            var categories = await _repo.GetAllAsync();
            return categories.Select(item => new CategoryVM()
            {
                Name = item.Name,
                ProductVMs = _mapper.Map<ICollection<ProductVM>>(item.Products),
                MerchantId = item.MerchantId,
                MerchantVMs = _mapper.Map<MerchantVM>(item.Merchant),
                ParentId = item.ParentId,
                CreatedAt = item.CreatedAt,
                UpdatedAt = item.UpdatedAt,
            }).FirstOrDefault(x => x.Id == id);
        }

        public async Task UpdateAsync(CategoryVM entity)
        {
            var getData = await _repo.GetByIdAsync(entity.Id);
            await _repo.UpdateAsync(getData);
        }
    }
    
}
