using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHubEntity
{
    public class UniversityDetail : Entity
    {      
        public string UniversityName { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public string SubjectName { get; set; }
        public long TuitionFees { get; set; }
        public string IELTSScoreRequirement { get; set; }
        public string GREScoreRequirement { get; set; }
        public string TOFELScoreRequirement { get; set; }
        public string UniversityQSWorldRank { get; set; }
        public string MinimumCGPARequirement { get; set; }
        public int CourseType { get; set; }
        public string AdditonalRequirements { get; set; }
    }
}
