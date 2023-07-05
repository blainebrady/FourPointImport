using FourPointImport.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPointImport.Services
{
    public class AgentDetailService : BaseService<AgentDetail>, IGenericService<AgentDetail>
    {
        public AgentDetailService(ApiDbContext dbContext) : base(dbContext) { }
    }
}

