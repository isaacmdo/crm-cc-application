using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Domain.Entities.Usr;

namespace Template.Data.Mappings.Usr
{
    public class ModuleProfileMap : IEntityTypeConfiguration<ModuleProfile>
    {
        public void Configure(EntityTypeBuilder<ModuleProfile> builder)
        {
            builder.HasKey(key => new { key.ModuleId, key.ProfileId });
        }
    }
}
