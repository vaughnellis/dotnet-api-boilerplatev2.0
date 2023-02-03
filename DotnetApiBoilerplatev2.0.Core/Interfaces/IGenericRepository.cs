namespace DotnetApiBoilerplatev2._0.Core.Interfaces
{
    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetById(int id);

        Task Create(TEntity entity);
        Task CreateMany(List<TEntity> entity);

        Task Update(int id, TEntity entity);

        Task Delete(int id);
    }
}
