using System.Collections.Generic;
using Template.Application.ViewModels.Profiles;

namespace Template.Application.Interfaces
{
	public interface IProfileService
	{
        List<ProfileViewModel> Get();
    }
}
