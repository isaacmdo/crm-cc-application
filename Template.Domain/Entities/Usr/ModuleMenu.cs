using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Domain.Entities.Usr
{
    public class ModuleMenu : Entity
    {
        public string Name { get; set; }
        public string URL { get; set; }
        public string Icon { get; set; }
        public int Sequence { get; set; }

        public int ModuleItemId { get; set; }
        public virtual ModuleItem ModuleItem { get; set; }
    }
}
