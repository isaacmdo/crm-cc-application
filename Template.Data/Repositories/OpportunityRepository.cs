using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Data.Context;
using Template.Domain.Entities.Location;
using Template.Domain.Entities.Sales;
using Template.Domain.Interfaces;

namespace Template.Data.Repositories
{
    public class OpportunityRepository : Repository<Opportunity>, IOpportunityRepository
    {
        public OpportunityRepository(PortalContext context)
          : base(context) { }

        public IQueryable<Opportunity> Get()
        {
            return Query(x => x.IsActive);
        }
    }
}
