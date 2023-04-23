﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities.Production;

namespace Template.Domain.Interfaces
{
    public interface IProductRepository
    {
        IQueryable<Product> Get();
    }
}
