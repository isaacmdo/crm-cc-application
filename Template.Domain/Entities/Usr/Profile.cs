using System.Collections.Generic;

namespace Template.Domain.Entities.Usr
{
    public class Profile : Entity
    {
        public string Name { get; set; }
        public bool IsDefault { get; set; }


        public ICollection<Users> Users { get; set; }
        public ICollection<ModuleProfile> Modules { get; set; }
    }
}
