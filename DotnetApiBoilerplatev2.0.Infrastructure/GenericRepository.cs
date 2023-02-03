using DotnetApiBoilerplatev2._0.Core.Interfaces;
using DotnetApiBoilerplatev2._0.Core.Models.Common;
using Microsoft.EntityFrameworkCore;

namespace DotnetApiBoilerplatev2._0.Infrastructure
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : BaseEntity
    {
        private readonly DataContext _dbContext;

        public GenericRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>().Where(x => x.IsActive == true).AsNoTracking();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Create(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateMany(List<T> entity)
        {
            await _dbContext.Set<T>().AddRangeAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(int id, T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
