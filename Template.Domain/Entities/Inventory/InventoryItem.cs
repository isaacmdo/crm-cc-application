using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities.Production;

namespace Template.Domain.Entities.Invent
{
    public class InventoryItem : Entity
    {
        public string Barcode { get; set; }
        public double SellPrice { get; set; }
        public double BuyPrice { get; set; }
        public int Quantity { get; set; }

        public int InventoryId { get; set; }
        public virtual Inventory Inventory { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

    }
}
