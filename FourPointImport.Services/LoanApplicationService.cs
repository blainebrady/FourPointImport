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
    public class LoanApplicationService : IGenericService<LoanApplicationMaster>
    {
        protected ApiDbContext _db;

        public LoanApplicationService([NotNull] ApiDbContext db)
        {
            _db = db;
        }
        public virtual async Task<LoanApplicationMaster> CreateAsync(LoanApplicationMaster entity)
        {
            await _db.Set<LoanApplicationMaster>().AddAsync(entity);
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
        public virtual async Task<List<LoanApplicationMaster>> ReadAllAsync(bool tracking = true)
        {
            IQueryable<LoanApplicationMaster> query = _db.Set<LoanApplicationMaster>();
            if (!tracking)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }
        public virtual async Task<LoanApplicationMaster> ReadAsync(int id, bool Tracking = true)
        {
            var query = _db.Set<LoanApplicationMaster>().AsQueryable();
            if (!Tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(entity => entity.id == id);
        }
        public virtual async Task<LoanApplicationMaster> UpdateAsync(int id, LoanApplicationMaster updateEntity)
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
