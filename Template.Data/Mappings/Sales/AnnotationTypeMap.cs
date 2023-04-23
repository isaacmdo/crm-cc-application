using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities.Sales;

namespace Template.Data.Mappings.Sales
{
    public class AnnotationTypeMap : IEntityTypeConfiguration<AnnotationType>
    {
        public void Configure(EntityTypeBuilder<AnnotationType> builder)
        {
            builder.HasKey(key => key.Id);
        }
    }
}
