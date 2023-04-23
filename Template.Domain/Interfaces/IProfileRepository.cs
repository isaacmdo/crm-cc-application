using System.Linq;
using Template.Domain.Entities.Usr;

namespace Template.Domain.Interfaces
{
    public interface IProfileRepository
	{
		Profile GetDefault();

        IQueryable<Profile> Get();
        Profile GetById(int profileId);

    }
}
