using FourPointImport.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace FourPointImport.Services
{
    public class billingDetailService : IGenericService<billingDetail>

    {
        protected ApiDbContext _db;

        public billingDetailService([NotNull] ApiDbContext db)
        {
            _db = db;
        }
        public virtual async Task<billingDetail> CreateAsync(billingDetail entity)
        {
            await _db.Set<billingDetail>().AddAsync(entity);
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
            entity.Archive = true;
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
        public virtual async Task<List<billingDetail>> ReadAllAsync(bool tracking = true)
        {
            IQueryable<billingDetail> query = _db.Set<billingDetail>();
            if (!tracking)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }
        public virtual async Task<billingDetail> ReadAsync(int id, bool Tracking = true)
        {
            var query = _db.Set<billingDetail>().AsQueryable();
            if (!Tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(entity => entity.id == id);
        }
        public virtual async Task<billingDetail> ReadAsyncB(int id, bool Tracking = true)
        {
            var query = _db.Set<billingDetail>().AsQueryable();
            if (!Tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(entity => entity.id == id);
        }
        public virtual async Task<billingDetail> UpdateAsync(int id, billingDetail updateEntity)
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