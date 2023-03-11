namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class ProgramKeyWordBridge
    {
        public System.Guid ProgramId { get; set; }

        public System.Guid KeyWordId { get; set; }

        public Program Program { get; set; }

        public KeyWord KeyWord { get; set; }
    }
}
