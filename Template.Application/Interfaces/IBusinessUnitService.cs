using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.ViewModels.Environments;
using Template.Domain.Entities.Invent;
using Template.Domain.Entities.Person;
using Template.Domain.Entities.Sales;

namespace Template.Application.Interfaces
{
    public interface IBusinessUnitService
    {
        List<BusinessUnit> Get();
        bool Update(BusinessUnit businessUnit);
        bool CreateBusinessUnit(BusinessUnitRequestCreateViewModel companyId);
        bool Activate(int businessUnitId);
        bool Deactivate(int businessUnitId);
    }
}
