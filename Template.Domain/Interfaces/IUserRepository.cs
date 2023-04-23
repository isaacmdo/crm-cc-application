using System.Linq;
using Template.Domain.Entities.Usr;

namespace Template.Domain.Interfaces
{
    public interface IUserRepository : IRepository<Users>
	{
		Users GetByEmailAndPassword(string email, string password);
		Users GetByEmail(string email);
		Users GetByEmailAndCode(string email, string code);
		IQueryable<Users> GetByProfileId(int profileId);
		Users GetById(int userId);
		IQueryable<Users> Get();
	}
}
