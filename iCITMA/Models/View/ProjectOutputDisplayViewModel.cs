using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class ProjectOutputDisplayViewModel: Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<ProjectOutput, System.Guid>
    {
        public System.Guid Id { get; set; }
        public System.Guid ProjectId { get; set; }
        public string ProjectOutput { get; set; }
        public string Description { get; set; }

        public void Import(ProjectOutput entity)
        {
            Id = entity.Id;
            ProjectId = (System.Guid)entity.ProjectId;
            ProjectOutput = entity.Kind.Name;
            Description = entity.Description;
        }
    }
}
