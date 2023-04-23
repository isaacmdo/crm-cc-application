using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Data.Context;
using Template.Domain.Entities.Location;
using Template.Domain.Entities.Production;
using Template.Domain.Interfaces;

namespace Template.Data.Repositories
{
    public class ProductCategoryRepository : Repository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(PortalContext context)
           : base(context) { }

        public IQueryable<ProductCategory> Get()
        {
            return Query(x => x.IsActive);
        }
    }
}
