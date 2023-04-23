using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities.Usr;

namespace Template.Domain.Entities.Usr
{
    public class ModuleItem : Entity
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Sequence { get; set; }

        public int ModuleId { get; set; }
        public virtual Module Module { get; set; }

        public ICollection<ModuleMenu> ModuleMenus { get; set; }
    }
}
