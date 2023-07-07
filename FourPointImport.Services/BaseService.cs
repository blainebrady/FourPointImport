using FourPointImport.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPointImport.Services
{
    public abstract class BaseService<TEntity>:IGenericService<TEntity>
        where TEntity : class, IBase
    {
        protected ApiDbContext _db;

        public BaseService([NotNull] ApiDbContext db)
        {
            _db = db;
        }
        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _db.Set<TEntity>().AddAsync(entity);
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
            return entity;
        }
        public virtual async Task DeleteAsync(int id)
        {
            //see if the record exists
            var entity = await ReadAsync(id);
            if (entity == null)
            {
                throw new ArgumentException("Unable to find record with id = " + id.ToString());
            }
            entity.Archive = DateTime.Now;
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
        public virtual async Task<List<TEntity>> ReadAllAsync(bool tracking = true)
        {
            IQueryable<TEntity> query = _db.Set<TEntity>();
            query = query.Where(entity => entity.Archive.HasValue);
            if (!tracking)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }
        public virtual async Task<TEntity> ReadAsync(int id, bool Tracking = true)
        {
            var query = _db.Set<TEntity>().AsQueryable();
            if (!Tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(entity => entity.id == id && entity.Archive.HasValue);
        }

        public virtual async Task<TEntity> UpdateAsync(int id, TEntity updateEntity)
        {
            //check that the record exists
            var entity = await ReadAsync(id);
            if (entity == null)
                throw new Exception("Unable to find record with id " + id.ToString());
            //update changes if any of the values have been modified
            _db.Entry(entity).CurrentValues.SetValues(updateEntity);
            _db.Entry(entity).State = EntityState.Modified;
            if (_db.Entry(entity).Properties.Any(property => property.IsModified))
            {
                await _db.SaveChangesAsync();
            }
            return entity;
        }


    }
}
