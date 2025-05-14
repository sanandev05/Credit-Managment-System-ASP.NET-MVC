using AutoMapper;
using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.Repositories.Interfaces;
using Credit_Managment_System_ASP.NET_MVC.Services.Interfaces;
using Credit_Managment_System_ASP.NET_MVC.View_Models;
using NuGet.Protocol.Core.Types;

namespace Credit_Managment_System_ASP.NET_MVC.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository repo, IMapper mapper)
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

            var category = new Category
            {
                Products = _mapper.Map<ICollection<Product>>(entity.ProductVMs),
                ParentId = entity.ParentId,
                Name = entity.Name,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,

            };
            await _repo.AddAsync(category);
            return _mapper.Map<CategoryVM>(category);
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

        public async Task<IEnumerable<CategoryVM>> GetAllAsync()
        {
            var categories = await _repo.GetAllWithInclude();


            return _mapper.Map<IEnumerable<CategoryVM>>(categories);
        }

        public async Task<CategoryVM> GetByIdAsync(int id)
        {
            var category = await _repo.GetByIdWithInclude(id);
           return _mapper.Map<CategoryVM>(category);


        }
        public async Task UpdateAsync(CategoryVM entity)
        {

            var data = _mapper.Map<Category>(entity);
            var result = await _repo.UpdateAsync(data);
            if (result == null)
            {
                throw new Exception("Category not found");
            }
            var entityVM = _mapper.Map<CategoryVM>(data);
            
        }
    } }
