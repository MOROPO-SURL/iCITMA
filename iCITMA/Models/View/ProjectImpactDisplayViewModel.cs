using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using System.Collections.Generic;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class ProjectImpactDisplayViewModel: Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<ProjectImpact, System.Guid>
    {
        public System.Guid Id { get; set; }
        public System.Guid ProjectId { get; set; }
        public string ImpactIndicator { get; set; }
        public string Description { get; set; }
        public List<ProjectImpactProgramExpectResultBridge> ProgramExpectResultBridges { get; set; }

        public List<ProjectImpactODSIndicatorBridge> ODSIndicatorBridges { get; set; }

        public void Import(ProjectImpact entity)
        {
            Id = entity.Id;
            ProjectId =(System.Guid)entity.ProjectId;
            ImpactIndicator = entity.Indicator.Name;
            Description = entity.Description;
            ProgramExpectResultBridges = entity.ProgramExpectResultBridges;
            ODSIndicatorBridges = entity.ODSIndicatorBridges;
        }
    }
}
