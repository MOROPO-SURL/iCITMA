using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using System.Collections.Generic;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class ProjectImpactManagerViewModel
    {
        public ProjectDisplayViewModel Project { get; set; }
        public List<ProjectImpact> ProjectImpacts { get; set; } = new List<ProjectImpact>();
    }
}
