using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Domain.Entities.Production
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }

        public int ProductStatusId { get; set; }
        public virtual ProductStatus ProductStatus { get; set; }

        public int ProductSubCategoryId { get; set; }
        public virtual ProductSubCategory ProductSubCategory { get; set; }

    }
}
