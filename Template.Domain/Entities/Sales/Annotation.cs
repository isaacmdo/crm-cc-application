using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Domain.Entities.Sales
{
    public class Annotation : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public int OpportunityId { get; set; }
        public virtual Opportunity Opportunity { get; set; }

        public int AnnotationTypeId { get; set; }
        public virtual AnnotationType AnnotationType { get; set; }
    }
}
