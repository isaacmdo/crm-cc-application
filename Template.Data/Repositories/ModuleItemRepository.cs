using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Data.Context;
using Template.Domain.Entities.Usr;
using Template.Domain.Interfaces;

namespace Template.Data.Repositories
{
    public class ModuleItemRepository : Repository<ModuleItem>, IModuleItemRepository
    {
        public ModuleItemRepository(PortalContext context)
           : base(context) { }

        public IQueryable<ModuleItem> GetByProfileId(int profileId)
        {
            return (from m in context.ModuleItems
                    join mi in context.Modules on m.ModuleId equals mi.Id
                    join mp in context.ModuleProfiles on mi.Id equals mp.ModuleId
                    where mp.ProfileId == profileId && m.IsActive == true
                    select m);
        }
    }
}
