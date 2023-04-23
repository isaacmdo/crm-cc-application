using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Domain.Entities.Location
{
    public class City : Entity
    {
        public string Name { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public int StateId { get; set; }
        public virtual State State { get; set; }
    }
}
