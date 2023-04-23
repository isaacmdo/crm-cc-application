using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Data.Context;
using Template.Domain.Entities.Location;
using Template.Domain.Entities.Person;
using Template.Domain.Entities.Sales;
using Template.Domain.Interfaces;

namespace Template.Data.Repositories
{
    public class BusinessUnitRepository : Repository<BusinessUnit>, IBusinessUnitRepository
    {
        public BusinessUnitRepository(PortalContext context)
          : base(context) { }

        public IQueryable<BusinessUnit> Get()
        {
            //return Query(x => x.IsActive);
            var query = (from b in context.BusinessUnits
                         join c in context.Companies on b.CompanyId equals c.Id
                         where b.IsActive == true
                         select new { b.CompanyId, c.BusinessName });
            var test = Query(x => x.Company.Name != null, i => i.Include(x => x.Company).ThenInclude(x => x.Address));
            return test;
            //return Query(x => x.IsActive, i => i.Include(x => x.Company).ThenInclude(x => x.Address));
            //return test;
            //return (from b in context.BusinessUnits
            //join c in context.Companies on b.CompanyId equals c.Id
            //where b.IsActive == true
            //select b);
            //public IQueryable<Module> GetByProfileId(int profileId)
            //{
            //    return (from m in context.Modules
            //            join mp in context.ModuleProfiles on m.Id equals mp.ModuleId
            //            where mp.ProfileId == profileId && m.IsActive == true
            //            select m);
            //}
        }

        public bool UpdateType(BusinessUnit businessUnit)
        {
            return Update(businessUnit);
        }

        public BusinessUnit CreateBusinessUnit(BusinessUnit businessUnit)
        {
            return Create(businessUnit);
        }

        public BusinessUnit GetById(int typeId)
        {
            return Find(x => x.Id == typeId);
        }
    }
}
