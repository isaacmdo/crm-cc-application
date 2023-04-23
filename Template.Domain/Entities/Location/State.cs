using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Domain.Entities.Location
{
    public class State : Entity
    {
        public string Name { get; set; }
        public string Initials { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

    }
}
