using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Data.Context;
using Template.Domain.Entities.Person;
using Template.Domain.Entities.Sales;
using Template.Domain.Interfaces;

namespace Template.Data.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(PortalContext context)
           : base(context) { }

        public IQueryable<Company> Get()
        {
            return Query(x => x.IsActive);
        }

        public Company GetById(int id)
        {
            return Find(x => x.Id == id);
        }
    }
}
