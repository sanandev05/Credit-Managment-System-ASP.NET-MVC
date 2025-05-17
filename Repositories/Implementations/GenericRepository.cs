using AutoMapper;
using Credit_Managment_System_ASP.NET_MVC.Data;
using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Credit_Managment_System_ASP.NET_MVC.Repositories.Implementations
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public GenericRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var getEntity = await _context.Set<TEntity>().FindAsync(id);
            getEntity.IsDeleted = true;
             _context.Update(getEntity);

            await _context.SaveChangesAsync();
            return true;
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
           return _context.Set<TEntity>()
                .Where(x => !x.IsDeleted)
                .ToListAsync()
                .ContinueWith(task => task.Result.AsEnumerable());
        }

        public Task<TEntity> GetByIdAsync(int id) => _context.Set<TEntity>()
            .Where(x => x.Id == id && !x.IsDeleted)
            .FirstOrDefaultAsync();


        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            entity.UpdatedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
