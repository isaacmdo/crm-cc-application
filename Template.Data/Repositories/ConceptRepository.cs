using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Data.Context;
using Template.Domain.Entities.Invent;
using Template.Domain.Entities.Production;
using Template.Domain.Entities.Sales;
using Template.Domain.Interfaces;

namespace Template.Data.Repositories
{
    public class ConceptRepository : Repository<Concept>, IConceptRepository
    {
        public ConceptRepository(PortalContext context)
            : base(context) { }

        public IQueryable<Concept> Get()
        {
            return Query(x => x.Name != null);
        }

        public bool UpdateType(Concept inventoryType)
        {
            return Update(inventoryType);
        }

        public Concept CreateType(Concept inventoryType)
        {
            return Create(inventoryType);
        }

        public Concept GetById(int typeId)
        {
            return Find(x => x.Id == typeId);
        }
    }
}
