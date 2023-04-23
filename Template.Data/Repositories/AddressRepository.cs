using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Data.Context;
using Template.Domain.Entities.Location;
using Template.Domain.Interfaces;

namespace Template.Data.Repositories
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(PortalContext context)
           : base(context) { }

        public IQueryable<Address> Get()
        {
            return Query(x => x.IsActive);
        }
    }
}
