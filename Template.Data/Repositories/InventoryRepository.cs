using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Data.Context;
using Template.Domain.Entities.Invent;
using Template.Domain.Interfaces;

namespace Template.Data.Repositories
{
    public class InventoryRepository : Repository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(PortalContext context)
          : base(context) { }

        public IQueryable<Inventory> Get()
        {
            return Query(x => x.IsActive);
        }
    }
}
