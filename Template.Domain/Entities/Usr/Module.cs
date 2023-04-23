using System.Collections.Generic;

namespace Template.Domain.Entities.Usr
{
    public class Module : Entity
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Sequence { get; set; }

        public ICollection<ModuleItem> ModuleItems { get; set; }
        public ICollection<ModuleProfile> Profiles { get; set; }
    }
}
