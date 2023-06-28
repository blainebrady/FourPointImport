using FourPointImport.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace FourPointImport.Services
{
    public class CoverageMasterService : BaseService<CoverageInsuranceMaster>, IGenericService<CoverageInsuranceMaster>
    {
        public CoverageMasterService(ApiDbContext dbContext) : base(dbContext) { }
    }
}
