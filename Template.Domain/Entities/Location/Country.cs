using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Domain.Entities.Location
{
    public class Country : Entity
    {
        public string Name { get; set; }
        public string Name_PT { get; set; }
        public string Initials { get; set; }
    }
}
