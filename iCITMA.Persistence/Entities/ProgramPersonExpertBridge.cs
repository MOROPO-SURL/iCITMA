namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class ProgramPersonExpertBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Program, System.Guid, Person, System.Guid>
    {
        public System.Guid ProwId
        {
            get; set;
        }
        public System.Guid SternId
        {
            get; set;
        }
        public Program Prow
        {
            get; set;
        }
        public Person Stern
        {
            get; set;
        }
    }
}
