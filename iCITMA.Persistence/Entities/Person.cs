using System.Collections.Generic;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class Person : Framework.Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        public Person()
        {
            Id = System.Guid.NewGuid();
            ResearchAreaSpecializationBridges = new List<PersonResearchAreaSpecializationBridge>();
            ResearchAreaMasteryBridges = new List<PersonResearchAreaMasteryBridge>();
            ResearchAreaDoctorateBridges = new List<PersonResearchAreaDoctorateBridge>();
            InstitutionBridges = new List<PersonInstitutionBridge>();
        }

        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public Framework.Guama.Identity.Persistence.Entities.PersonIdentity Identity { get; set; }
        public System.Guid? IdentityId { get; set; }

        public Enumerators.SchoolingLevel SchoolingLevel { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("ResearcherCategoryId")]
        public ResearcherCategory ResearcherCategory { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public System.Guid? ResearcherCategoryId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("TeachingCategoryId")]
        public TeachingCategory TeachingCategory { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public System.Guid? TeachingCategoryId { get; set; }

        public List<PersonResearchAreaSpecializationBridge> ResearchAreaSpecializationBridges { get; set; }

        public List<PersonResearchAreaMasteryBridge> ResearchAreaMasteryBridges { get; set; }

        public List<PersonResearchAreaDoctorateBridge> ResearchAreaDoctorateBridges { get; set; }

        public List<PersonInstitutionBridge> InstitutionBridges { get; set; }
    }
}
