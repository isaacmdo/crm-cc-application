using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Domain.Entities.Invent;

public class Inventory : Entity
{
    public string Title { get; set; }
    public string Description { get; set; }

    public int InventoryTypeId { get; set; }
    public virtual InventoryType InventoryType { get; set; }

    public ICollection<InventoryItem> InventoryItem { get; set; }
}
