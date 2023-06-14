using FourPointImport.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace FourPointImport.Services
{
    public class FormMasterService : IGenericService<FormMaster>
    {
        protected ApiDbContext _db;

        public FormMasterService([NotNull] ApiDbContext db)
        {
            _db = db;
        }
        public virtual async Task<FormMaster> CreateAsync(FormMaster entity)
        {
            await _db.Set<FormMaster>().AddAsync(entity);
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                string s= ex.Message;
            }
            return entity;
        }
        public virtual async Task DeleteAsync(int id)
        {
            //see if the record exists
            var entity = await ReadAsync(id);
            if(entity == null)
            {
                throw new ArgumentException("Unable to find record with id = " +  id.ToString());
            }
            entity.Archive = true;
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
        public virtual async Task<List<FormMaster>> ReadAllAsync(bool tracking = true)
        {
            IQueryable<FormMaster> query = _db.Set<FormMaster>();
            if (!tracking)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }
        public virtual async Task<FormMaster> ReadAsync(int id, bool Tracking = true)
        {
            var query = _db.Set<FormMaster>().AsQueryable();
            if (!Tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(entity => entity.FmForm == id);
        }

        public virtual async Task<FormMaster> ReadAsyncF(string seCalc, bool Tracking = true)
        {
            var query = _db.Set<FormMaster>().AsQueryable();
            if (!Tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(entity => entity.FmCalc == seCalc);
        }
        //ReadAsyncL(inComing.SeType, inComing.SeLend)
        public virtual async Task<FormMaster> ReadAsyncL(string seType, string seLend, bool Tracking = true)
        {
            var query = _db.Set<FormMaster>().AsQueryable();
            if (!Tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(entity => entity.FmType == seType && entity.FmLend == seLend);
        }
        public virtual async Task<FormMaster> ReadAsyncP(string seAgent, int seForm, bool Tracking = true)
        {
            var query = _db.Set<FormMaster>().AsQueryable();
            if (!Tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(entity => entity.FmAGNT == seAgent && entity.FmForm == seForm);
        }
        public virtual async Task<FormMaster> UpdateAsync(int id, FormMaster updateEntity)
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
