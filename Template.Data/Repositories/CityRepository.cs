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
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(PortalContext context)
           : base(context) { }

        public IQueryable<City> Get()
        {
            return Query(x => x.IsActive);
        }
    }
}
