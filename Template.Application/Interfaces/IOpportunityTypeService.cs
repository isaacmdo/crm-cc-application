using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.ViewModels.Environments;
using Template.Domain.Entities.Invent;
using Template.Domain.Entities.Sales;

namespace Template.Application.Interfaces
{
    public interface IOpportunityTypeService
    {
        List<OpportunityType> Get();
        bool Update(OpportunityType inventoryType);
        bool Create(OpportunityTypeRequestCreateViewModel inventoryType);
        bool Deactivate(int opportunityTypeId);
        bool Activate(int opportunityTypeId);
    }
}
