using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Template.Data.Context;
using Template.Domain.Entities.Usr;
using Template.Domain.Interfaces;

namespace Template.Data.Repositories
{
    public class UserRepository : Repository<Users>, IUserRepository
	{
		public UserRepository(PortalContext context)
			: base(context) { }

		public Users GetByEmailAndPassword(string email, string password)
		{
			return Find(x => x.Email.ToLower() == email.ToLower() && x.Password == password && x.IsActive, i => i.Include(x => x.Profile));
		}

		public Users GetByEmail(string email)
		{
			return Find(x => x.Email.ToLower() == email.ToLower() && x.IsActive, i => i.Include(x => x.Profile).ThenInclude(then => then.Modules));
		}

		public Users GetByEmailAndCode(string email, string code)
		{
			return Find(x => x.Email.ToLower() == email.ToLower() && x.Code.ToUpper() == code.ToUpper() && x.IsActive);
		}

		public IQueryable<Users> GetByProfileId(int profileId)
		{
			return Query(x => x.IsActive && x.ProfileId == profileId);
		}

		public Users GetById(int userId)
		{
			return Find(x => x.Id == userId, i => i.Include(x => x.Profile).ThenInclude(x => x.Modules));
		}

		public IQueryable<Users> Get()
		{
			return Query(x => x.IsActive, i => i.Include(x => x.Profile).ThenInclude(x => x.Modules));
		}
	}
}
