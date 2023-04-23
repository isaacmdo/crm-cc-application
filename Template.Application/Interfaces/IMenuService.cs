using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.ViewModels.Modules;

namespace Template.Application.Interfaces
{
    public interface IMenuService
    {
        List<MenuViewModel> GetMenuByProfile(int profileId);
    }
}
