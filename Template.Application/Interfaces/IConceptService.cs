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
    public interface IConceptService 
    {
        List<Concept> Get();
        bool Update(Concept inventoryType);
        bool Create(ConceptRequestCreateViewModel inventoryType);
        bool Deactivate(int conceptId);
        bool Activate(int conceptId);
    }
}
