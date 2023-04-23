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
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(PortalContext context)
           : base(context) { }

        public IQueryable<Order> Get()
        {
            return Query(x => x.IsActive);
        }
    }
}
