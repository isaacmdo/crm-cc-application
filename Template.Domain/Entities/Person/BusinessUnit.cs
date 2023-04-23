using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities.Location;

namespace Template.Domain.Entities.Person
{
    public class BusinessUnit : Entity
    {
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
