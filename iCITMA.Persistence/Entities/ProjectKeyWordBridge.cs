namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class ProjectKeyWordBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Project, System.Guid, KeyWord, System.Guid>
    {
        public System.Guid ProwId { get; set; }

        public System.Guid SternId { get; set; }

        public Project Prow { get; set; }

        public KeyWord Stern { get; set; }
    }
}
