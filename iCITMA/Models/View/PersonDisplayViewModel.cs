using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using MOROPO.CITMA.CMG.iCITMA.Persistence.Enumerators;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Extensions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class PersonDisplayViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Person, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.Guid ImageId { get; set; }

        public string ImageExtension { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Display(Name = "Sex")]
        public Framework.Guama.Identity.Persistence.Enumerations.Sex Sex { get; set; }

        [Display(Name = "Alias")]
        public string Alias { get; set; }

        [Display(Name = "Description")]
        public string About { get; set; }

        [Display(Name = "SchoolLevel")]
        public SchoolingLevel SchoolingLevel { get; set; }

        [Display(Name = "ResearcherCategory")]
        public string ResearcherCategoryName { get; set; }

        [Display(Name = "TeachingCategory")]
        public string TeachingCategoryName { get; set; }

        public ICollection<PersonResearchAreaSpecializationBridge> ResearchAreaSpecializationBridge { get; set; }

        public ICollection<PersonResearchAreaMasteryBridge> ResearchAreaMasteryBridges { get; set; }

        public ICollection<PersonResearchAreaDoctorateBridge> ResearchAreaDoctorateBridges { get; set; }

        public ICollection<PersonInstitutionBridge> InstitutionBridges { get; set; }

        public void Import(Person entity)
        {
            Id = entity.Id;
            ImageId = entity.Identity.ImageId ?? System.Guid.Empty;
            ImageExtension = entity.Identity.Image?.ContentType.ContentTypeToExtension() ?? null;
            Name = entity.Identity.Name;
            LastName = entity.Identity.LastName;
            Sex = entity.Identity.Sex;
            Alias = entity.Identity.Alias;
            About = entity.Identity.About;
            SchoolingLevel = entity.SchoolingLevel;
            ResearcherCategoryName = entity.ResearcherCategory.Name;
            TeachingCategoryName = entity.TeachingCategory.Name;
            ResearchAreaSpecializationBridge = entity.ResearchAreaSpecializationBridges;
            ResearchAreaMasteryBridges = entity.ResearchAreaMasteryBridges;
            ResearchAreaDoctorateBridges = entity.ResearchAreaDoctorateBridges;
            InstitutionBridges = entity.InstitutionBridges;
        }
    }
}
