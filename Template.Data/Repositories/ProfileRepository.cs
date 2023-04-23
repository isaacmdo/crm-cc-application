using Microsoft.EntityFrameworkCore;
using System.Linq;
using Template.Data.Context;
using Template.Domain.Entities.Usr;
using Template.Domain.Interfaces;

namespace Template.Data.Repositories
{
    public class ProfileRepository: Repository<Profile>, IProfileRepository
	{
		public ProfileRepository(PortalContext context)
			: base(context) { }

		public Profile GetDefault()
		{
			return Find(x => x.IsDefault);
		}

        public IQueryable<Profile> Get()
        {
            return Query(x => x.IsActive);
        }

        public Profile GetById(int profileId)
        {   
            return Find(x => x.Id == profileId);
        }
    }
}
