using MOROPO.Framework.Guama.Location.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class InstitutionPostalContactDisplayViewModel: PostalContactDisplayViewModel
    {
        public System.Guid InstitutionId { get; set; }

        public string Label { get; set; }
        
        public System.Guid StateId { get; set; }
        public State State { get; set; }
        
        public System.Guid MunicipalityId { get; set; }
        public Municipality Municipality { get; set; }
    }
}
