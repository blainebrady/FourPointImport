using FourPointImport.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace FourPointImport.Services
{
    public class FormMasterService :BaseService<FormMaster>, IGenericService<FormMaster>
    {
        public FormMasterService(ApiDbContext dbContext) : base(dbContext) { }
       
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

    }
}
