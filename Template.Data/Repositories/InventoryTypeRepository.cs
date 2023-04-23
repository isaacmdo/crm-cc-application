using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Data.Context;
using Template.Domain.Entities.Invent;
using Template.Domain.Entities.Sales;
using Template.Domain.Entities.Usr;
using Template.Domain.Interfaces;

namespace Template.Data.Repositories
{
    public class InventoryTypeRepository : Repository<InventoryType>, IInventoryTypeRepository
    {
        public InventoryTypeRepository(PortalContext context)
           : base(context) { }

        public IQueryable<InventoryType> Get()
        {
            return Query(x => x.Name != null);
        }

        public bool UpdateType(InventoryType inventoryType)
        {
            return Update(inventoryType);
        }

        public InventoryType CreateType(InventoryType inventoryType)
        {
            return Create(inventoryType);
        }

        public InventoryType GetById(int typeId)
        {
            return Find(x => x.Id == typeId);
        }

    }
}
