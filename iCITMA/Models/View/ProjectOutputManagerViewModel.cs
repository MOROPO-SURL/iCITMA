using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using System.Collections.Generic;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class ProjectOutputManagerViewModel
    {        public ProjectDisplayViewModel Project { get; set; }
        public List<ProjectOutput> ProjectOuputs { get; set; } = new List<ProjectOutput>();
    }
}
