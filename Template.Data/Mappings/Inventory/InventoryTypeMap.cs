using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities.Invent;
using Template.Domain.Entities.Sales;

namespace Template.Data.Mappings.Sales
{
    public class InventoryTypeMap : IEntityTypeConfiguration<InventoryType>
    {
        public void Configure(EntityTypeBuilder<InventoryType> builder)
        {
            builder.HasKey(key => key.Id);
        }
    }
}
