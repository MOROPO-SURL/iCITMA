using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using System.Collections.Generic;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class ProjectResultManagerViewModel
    {
        public ProjectDisplayViewModel Project { get; set; }
        public List<ProjectResult> Results { get; set; } = new List<ProjectResult>();
    }
}
