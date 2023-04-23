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
    public class StageRepository : Repository<Stage>, IStageRepository
    {
        public StageRepository(PortalContext context)
           : base(context) { }

        public IQueryable<Stage> Get()
        {
            return Query(x => x.IsActive);
        }
    }
}
