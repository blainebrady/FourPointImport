using FourPointImport.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPointImport.Services
{
    public  class PatronCustomerService : BaseService<PatronCustomer>, IGenericService<PatronCustomer>
    {
        public PatronCustomerService(ApiDbContext dbContext) : base(dbContext) { }
    }
}
