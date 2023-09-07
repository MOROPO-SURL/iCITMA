using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using System.Collections.Generic;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class ProjectSpecificObjectiveManagerViewModel
    {
        public ProjectDisplayViewModel Project { get; set; }
        public List<SpecificObjective> Objectives { get; set; } = new List<SpecificObjective>();
    }
}
