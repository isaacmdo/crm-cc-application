using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities.Usr;
using Template.Domain.Entities.Person;

namespace Template.Domain.Entities.Sales
{
    public class Opportunity : Entity
    {

        public string Description { get; set; }

        public DateTime NextRelationshipDate { get; set; }
        public DateTime ValidityDate { get; set; }
        public DateTime ForecastDate { get; set; }

        public string PhoneCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public int ConceptId { get; set; }
        public virtual Concept Concept { get; set; }

        public int OpportunityTypeId { get; set; }
        public virtual OpportunityType OpportunityType { get; set; }

        public int UserId { get; set; }
        public virtual Users User { get; set; }

        public int StageId { get; set; }
        public virtual Stage Stage { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public int ContactId { get; set; }
        public virtual Contact Contact { get; set; }

        public ICollection<Annotation> Annotations { get; set; }
    }
}
