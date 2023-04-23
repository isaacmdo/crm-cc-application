using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities.Invent;
using Template.Domain.Entities.Person;
using Template.Domain.Entities.Production;
using Template.Domain.Entities.Sales;
using Template.Domain.Entities.Usr;

namespace Template.Domain.Interfaces
{
    public interface IBusinessUnitRepository
    {
        IQueryable<BusinessUnit> Get();
        bool UpdateType(BusinessUnit businessUnit);
        BusinessUnit GetById(int typeId);
        BusinessUnit Create(BusinessUnit businessUnit);
    }
}
