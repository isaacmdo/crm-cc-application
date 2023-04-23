using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Application.ViewModels.Modules
{
    public class ModuleItemViewModel : EntityViewModel
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Sequence { get; set; }
        public int ModuleId { get; set; }
        public List<ModuleMenuViewModel> ModuleMenu { get; set; }
    }
}
