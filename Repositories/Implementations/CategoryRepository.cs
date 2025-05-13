using AutoMapper;
using Credit_Managment_System_ASP.NET_MVC.Data;
using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Credit_Managment_System_ASP.NET_MVC.Repositories.Implementations
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mappper;
        public CategoryRepository(AppDbContext context, IMapper mapper) : base(context,mapper)
        {
            _context = context;
        }
        public Task<IEnumerable<Category>> GetAllWithInclude()
        {
            var categories = _context.Categories
                    .Include(x => x.Products)
                    .Include(x => x.ParentCategories)
                 .Where(x => !x.IsDeleted)
                 .ToListAsync()
                 .ContinueWith(task => task.Result.AsEnumerable());
            return categories;
        }
        public Task<Category> GetByIdWithInclude(int id)
        {
            var category = _context.Categories
                .Include(x => x.Products)
                .Include(x => x.ParentCategories)
                .Where(x => x.Id == id && !x.IsDeleted)
                .FirstOrDefaultAsync();
            return category;
        }
        public Task Update(Category entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            _context.Update(entity);
            return _context.SaveChangesAsync();
        }
    }

}
