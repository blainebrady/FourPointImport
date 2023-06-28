using FourPointImport.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace FourPointImport.Services
{
    public class BillingDetailService : BaseService<BillingDetail>, IGenericService<BillingDetail>
    {
        public BillingDetailService(ApiDbContext dbContext) : base(dbContext) { }
          

    }
}