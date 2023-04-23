using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Data.Context;
using Template.Domain.Entities.Location;
using Template.Domain.Entities.Person;
using Template.Domain.Interfaces;

namespace Template.Data.Repositories
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(PortalContext context)
           : base(context) { }

        public IQueryable<Contact> Get()
        {
            return Query(x => x.IsActive);
        }
    }
}
