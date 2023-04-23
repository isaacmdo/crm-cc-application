using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Data.Context;
using Template.Domain.Entities.Production;
using Template.Domain.Entities.Usr;
using Template.Domain.Interfaces;

namespace Template.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(PortalContext context)
            : base(context) { }

        public IQueryable<Product> Get()
        {
            return Query(x => x.IsActive);
        }
    }
}
