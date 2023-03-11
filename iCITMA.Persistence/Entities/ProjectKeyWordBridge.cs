namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class ProjectKeyWordBridge
    {
        public System.Guid ProjectId { get; set; }

        public System.Guid KeyWordId { get; set; }

        public Project Project { get; set; }

        public KeyWord KeyWord { get; set; }
    }
}
