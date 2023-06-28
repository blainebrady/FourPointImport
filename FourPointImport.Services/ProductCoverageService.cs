using FourPointImport.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace FourPointImport.Services
{
    public class ProductCoverageService : BaseService<productCoverage>, IGenericService<productCoverage>
    {
        public ProductCoverageService(ApiDbContext dbContext) : base(dbContext) { }
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
        
    }
}
