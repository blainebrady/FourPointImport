using FourPointImport.Data;

namespace FourPointImport.Services
{
    public interface IGenericService<TEntity>
        where TEntity : class, IImport
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(int id, TEntity entity);
        Task<TEntity> DeleteAsync(int id);
        Task<TEntity> ReadAsync(int id, bool Tracking = true);
        Task<List<TEntity>> ReadAllAsync(bool tracking = true);

    }
}
