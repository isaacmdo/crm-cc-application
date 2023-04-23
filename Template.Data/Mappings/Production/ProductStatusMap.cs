using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Template.Domain.Entities.Production;

namespace Template.Data.Mappings.Production
{
    public class ProductStatusMap : IEntityTypeConfiguration<ProductStatus>
    {
        public void Configure(EntityTypeBuilder<ProductStatus> builder)
        {
            builder.HasKey(key => key.Id);
        }
    }
}
