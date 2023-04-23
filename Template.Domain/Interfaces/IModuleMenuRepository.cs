using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities.Usr;

namespace Template.Domain.Interfaces
{
    public interface IModuleMenuRepository
    {
        IQueryable<ModuleMenu> GetByProfileId(int profileId);
    }
}
