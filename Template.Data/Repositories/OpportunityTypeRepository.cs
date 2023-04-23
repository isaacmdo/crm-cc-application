using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Data.Context;
using Template.Domain.Entities.Invent;
using Template.Domain.Entities.Sales;
using Template.Domain.Interfaces;

namespace Template.Data.Repositories
{
    public class OpportunityTypeRepository : Repository<OpportunityType>, IOpportunityTypeRepository
    {
        public OpportunityTypeRepository(PortalContext context)
          : base(context) { }

        public IQueryable<OpportunityType> Get()
        {
            return Query(x => x.Name != null);
        }

        public bool UpdateType(OpportunityType inventoryType)
        {
            return Update(inventoryType);
        }

        public OpportunityType CreateType(OpportunityType inventoryType)
        {
            return Create(inventoryType);
        }

        public OpportunityType GetById(int typeId)
        {
            return Find(x => x.Id == typeId);
        }
    }
}
