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
    public class CoverageInsuranceService : BaseService<CoverageInsHist>, IGenericService<CoverageInsHist>
    {
        public CoverageInsuranceService(ApiDbContext dbContext) : base(dbContext) { }
        
    }
    
}
