using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities.Location;

namespace Template.Application.ViewModels.Environments
{
    public class BusinessUnitViewModel
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string BusinessName { get; set; }

        public string PhoneCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public string Street { get; set; }
        public string Number { get; set; }
        public string District { get; set; }
        public string Complement { get; set; }
        public string PostalCode { get; set; }

        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
    }
}
