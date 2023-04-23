using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Application.ViewModels.Users
{
    public class UserUpdateAccess : EntityViewModel
    {
        public string Name { get; set; }
        public int ProfileId { get; set; }
        public string Email { get; set; }
    }
}
