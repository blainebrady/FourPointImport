using FourPointImport.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPointImport.Services
{
    public class RateDetailService: BaseService<RateDetailLife>, IGenericService<RateDetailLife>
    {
        public RateDetailService(ApiDbContext dbContext) : base(dbContext) { }

    }
}
