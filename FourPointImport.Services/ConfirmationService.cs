using FourPointImport.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPointImport.Services
{
    public class ConfirmationService : BaseService<Confirmation>, IGenericService<Confirmation>
    {
        public ConfirmationService(ApiDbContext dbContext) : base(dbContext) { }
    
    }
}
