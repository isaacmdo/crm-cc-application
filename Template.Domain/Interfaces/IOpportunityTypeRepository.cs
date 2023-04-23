using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities.Invent;
using Template.Domain.Entities.Location;
using Template.Domain.Entities.Sales;
using Template.Domain.Entities.Usr;

namespace Template.Domain.Interfaces
{
    public interface IOpportunityTypeRepository
    {
        IQueryable<OpportunityType> Get();
        bool UpdateType(OpportunityType inventoryType);
        OpportunityType GetById(int typeId);
        OpportunityType CreateType(OpportunityType inventoryType);
    }
}
