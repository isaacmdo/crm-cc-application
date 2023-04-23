using System.Collections.Generic;
using System.Linq;
using Template.Domain.Entities.Usr;

namespace Template.Domain.Interfaces
{
    public interface IModuleRepository
	{
		IQueryable<Module> GetByProfileId(int profileId);
	}
}
