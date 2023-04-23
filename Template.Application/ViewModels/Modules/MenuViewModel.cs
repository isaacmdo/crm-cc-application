using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities.Usr;

namespace Template.Application.ViewModels.Modules
{
    public class MenuViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Sequence { get; set; }
        public List<ModuleItemViewModel> ModuleItem { get; set; }
    }
}
