using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Application.ViewModels.Modules
{
    public class ModuleMenuViewModel : EntityViewModel
    {
        public string Name { get; set; }
        public string URL { get; set; }
        public string Icon { get; set; }
        public int ModuleItemId { get; set; }
        public int Sequence { get; set; }
    }
}
