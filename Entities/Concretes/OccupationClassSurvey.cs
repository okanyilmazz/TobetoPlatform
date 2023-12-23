using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class OccupationClassSurvey : Entity<Guid>
    {
        public Guid SurveyId { get; set; }
        public Guid OccupationClassId { get; set; }

        public Survey? Survey { get; set; }
        public OccupationClass? OccupationClass { get; set; }
    }
}
