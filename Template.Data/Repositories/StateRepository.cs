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
    public class StateRepository : Repository<State>, IStateRepository
    {
        public StateRepository(PortalContext context)
         : base(context) { }

        public IQueryable<State> Get()
        {
            return Query(x => x.IsActive);
        }
    }
}
