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
    public class RateMasterService : BaseService<RateMaster>, IGenericService<RateMaster>
    {

        public RateMasterService(ApiDbContext dbContext) : base(dbContext) { }
    }
}
