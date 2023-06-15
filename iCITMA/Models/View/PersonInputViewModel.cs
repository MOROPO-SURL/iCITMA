using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Presentation.Web.Common.ComponentModel.DataAnnotations;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Extensions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class PersonInputViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Person, System.Guid>
    {
        public System.Guid Id { get; set; }

        [FormFileContentTypes(ContentTypes = new string[] { "image/png", "image/jpeg" }, ErrorMessage = "PNG_JPEG_FileAllowedOnlyMessage")]
        [FormFileMaxLength(Length = 3145728, ErrorMessage = "FileLimitSizeExcededMessage")]
        [Display(Name = "ImageFile")]
        public Microsoft.AspNetCore.Http.IFormFile ImageFile { get; set; }

        public System.Guid ImageId { get; set; }

        public string ImageExtension { get; set; }

        public bool ResetImage { get; set; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
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
        public Persistence.Enumerators.SchoolingLevel SchoolingLevel { get; set; }

        [Display(Name = "ResearcherCategoryId")]
        public System.Guid? ResearcherCategoryId { get; set; }

        [Display(Name = "ResearcherCategory")]
        public System.Collections.Generic.ICollection<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> ResearcherCategorys { get; set; }

        [Display(Name = "TeachingCategoryId")]
        public System.Guid? TeachingCategoryId { get; set; }

        [Display(Name = "TeachingCategory")]
        public System.Collections.Generic.ICollection<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> TeachingCategorys { get; set; }

        public ICollection<PersonResearchAreaSpecializationBridge> ResearchAreaSpecializationBridge { get; set; }

        public ICollection<PersonResearchAreaMasteryBridge> ResearchAreaMasteryBridges { get; set; }

        public ICollection<PersonResearchAreaDoctorateBridge> ResearchAreaDoctorateBridges { get; set; }

        public ICollection<PersonInstitutionBridge> InstitutionBridges { get; set; }

        public List<Framework.Guama.Core.Presentation.Models.View.SelectionDescriptedItemInputViewModel<System.Guid>> InstitutionsToSelect { get; set; } = new List<Framework.Guama.Core.Presentation.Models.View.SelectionDescriptedItemInputViewModel<System.Guid>>();

        public Person Export()
        {
            var entity = new Person();

            Mergue(entity);

            return entity;
        }

        public void Import(Person entity)
        {
            Id = entity.Id;
            ImageId = entity.Identity.Image?.Id ?? System.Guid.Empty;
            ImageExtension = entity.Identity.Image?.ContentType.ContentTypeToExtension() ?? null;
            Name = entity.Identity.Name;
            LastName = entity.Identity.LastName;
            Sex = entity.Identity.Sex;
            Alias = entity.Identity.Alias;
            About = entity.Identity.About;
            SchoolingLevel = entity.SchoolingLevel;
            ResearcherCategoryId = entity.ResearcherCategoryId;
            TeachingCategoryId = entity.TeachingCategoryId;
            ResearchAreaSpecializationBridge = entity.ResearchAreaSpecializationBridges;
            ResearchAreaMasteryBridges = entity.ResearchAreaMasteryBridges;
            ResearchAreaDoctorateBridges = entity.ResearchAreaDoctorateBridges;
            InstitutionBridges = entity.InstitutionBridges;
        }

        public void Mergue(Person entity)
        {
            entity.Identity.Name = Name;
            entity.Identity.LastName = LastName;
            entity.Identity.Sex = Sex;
            entity.Identity.Alias = Alias;
            entity.Identity.About = About;
            entity.SchoolingLevel = SchoolingLevel;
        }
    }
}
