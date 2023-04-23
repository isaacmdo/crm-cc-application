using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities.Usr;

namespace Template.Data.Mappings.Usr
{
    public class ModuleMenuMap : IEntityTypeConfiguration<ModuleMenu>
    {
        public void Configure(EntityTypeBuilder<ModuleMenu> builder)
        {
            builder.HasKey(key => key.Id);
        }
    }
}
