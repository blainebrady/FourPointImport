using FourPointImport.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace FourPointImport.Services
{
    public class ProductCoverageService : IGenericService<productCoverage>
    {
        protected ApiDbContext _db;

        public ProductCoverageService([NotNull] ApiDbContext db)
        {
            _db = db;
        }
        public virtual async Task<productCoverage> CreateAsync(productCoverage entity)
        {
            await _db.Set<productCoverage>().AddAsync(entity);
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
        public virtual async Task<List<productCoverage>> ReadAllAsync(bool tracking = true)
        {
            IQueryable<productCoverage> query = _db.Set<productCoverage>();
            if (!tracking)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }
        public virtual async Task<productCoverage> ReadAsync(int id, bool Tracking = true)
        {
            var query = _db.Set<productCoverage>().AsQueryable();
            if (!Tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(entity => entity.id == id);
        }
        public virtual async Task<List<productCoverage>> ReadAsyncD(decimal SeDebt, bool Tracking = true)
        {
            var query = _db.Set<productCoverage>().AsQueryable();
            if (!Tracking)
                query = query.AsNoTracking();
            return await query.Where(entity => entity.PCCOVC == SeDebt).ToListAsync();
        }
        public virtual async Task<List<productCoverage>> ReadAsyncL(decimal seLif, string seCalc, bool Tracking = true)
        {
            var query = _db.Set<productCoverage>().AsQueryable();
            if (!Tracking)
                query = query.AsNoTracking();
            return await query.Where(entity => entity.PCCOVC == seLif && entity.PCCALC == seCalc).ToListAsync();
        }
        public virtual async Task<productCoverage> ReadAsyncP(decimal pcCovc, string pcCalc, bool Tracking = true)
        {
            var query = _db.Set<productCoverage>().AsQueryable();
            if (!Tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(entity => entity.PCCOVC == pcCovc && entity.PCCALC == pcCalc);
        }
        public virtual async Task<productCoverage> ReadAsyncW(decimal Key04_Fld01, bool Tracking = true)
        {
            var query = _db.Set<productCoverage>().AsQueryable();
            if (!Tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(entity => entity.PCCOVC == Key04_Fld01);
        }
        public virtual async Task<productCoverage> UpdateAsync(int id, productCoverage updateEntity)
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
