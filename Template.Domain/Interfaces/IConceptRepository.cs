﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities.Invent;
using Template.Domain.Entities.Sales;
using Template.Domain.Entities.Usr;

namespace Template.Domain.Interfaces
{
    public interface IConceptRepository
    {
        IQueryable<Concept> Get();
        bool UpdateType(Concept conceptType);
        Concept GetById(int typeId);
        Concept CreateType(Concept conceptType);
    }
}
