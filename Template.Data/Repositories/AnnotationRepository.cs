using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Data.Context;
using Template.Domain.Entities.Sales;
using Template.Domain.Interfaces;
using Annotation = Template.Domain.Entities.Sales.Annotation;

namespace Template.Data.Repositories
{
    public class AnnotationRepository : Repository<Annotation>, IAnnotationRepository
    {
        public AnnotationRepository(PortalContext context)
           : base(context) { }

        public IQueryable<Annotation> Get()
        {
            return Query(x => x.IsActive);
        }
    }
}
