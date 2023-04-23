using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.ViewModels.Environments;
using Template.Domain.Entities.Invent;

namespace Template.Application.Interfaces
{
    public interface IInventoryTypeService
    {
        List<InventoryType> Get();
        bool Update(InventoryType inventoryType);
        bool Create(InventoryTypeRequestCreateViewModel inventoryType);
        bool Deactivate(int inventoryTypeId);
        bool Activate(int inventoryTypeId);
    }
}
