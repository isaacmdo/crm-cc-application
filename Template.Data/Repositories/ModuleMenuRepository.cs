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
    public class ModuleMenuRepository : Repository<ModuleMenu>, IModuleMenuRepository
    {
        public ModuleMenuRepository(PortalContext context)
           : base(context) { }

        public IQueryable<ModuleMenu> GetByProfileId(int profileId)
        {
            return (from m in context.ModuleMenus
                    join mi in context.ModuleItems on m.ModuleItemId equals mi.Id
                    join mu in context.Modules on mi.ModuleId equals mu.Id
                    join mp in context.ModuleProfiles on mu.Id equals mp.ModuleId
                    where mp.ProfileId == profileId && m.IsActive == true
                    select m);
        }
    }
}
