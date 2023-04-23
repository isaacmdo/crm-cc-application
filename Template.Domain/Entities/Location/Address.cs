using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Domain.Entities.Location
{
    public class Address : Entity
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string District { get; set; }
        public string Complement { get; set; }
        public string PostalCode { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public int StateId { get; set; }
        public virtual State State { get; set; }

        public int CityId { get; set; }
        public virtual City City { get; set; }

    }
}
