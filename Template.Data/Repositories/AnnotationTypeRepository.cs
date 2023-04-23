using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Data.Context;
using Template.Domain.Entities.Sales;
using Template.Domain.Interfaces;

namespace Template.Data.Repositories
{
    public class AnnotationTypeRepository : Repository<AnnotationType>, IAnnotationTypeRepository
    {
        public AnnotationTypeRepository(PortalContext context)
          : base(context) { }

        public IQueryable<AnnotationType> Get()
        {
            return Query(x => x.IsActive);
        }
    }
}
