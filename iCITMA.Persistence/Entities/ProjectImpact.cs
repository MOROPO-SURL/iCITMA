using System.Collections.Generic;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class ProjectImpact : Framework.Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        public ProjectImpact()
        {
            Id = System.Guid.NewGuid();

            ProgramExpectResultBridges = new List<ProjectImpactProgramExpectResultBridge>();
            ODSIndicatorBridges = new List<ProjectImpactODSIndicatorBridge>();
        }

        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("ProjectId")]
        public Project Project { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public System.Guid? ProjectId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("IndicatorId")]
        public ImpactIndicator Indicator { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public System.Guid? IndicatorId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Description { get; set; }

        public List<ProjectImpactProgramExpectResultBridge> ProgramExpectResultBridges { get; set; }

        public List<ProjectImpactODSIndicatorBridge> ODSIndicatorBridges { get; set; }
    }
}
