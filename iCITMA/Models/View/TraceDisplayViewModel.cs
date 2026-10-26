using System.ComponentModel.DataAnnotations;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    [Microsoft.AspNetCore.Mvc.ModelMetadataType(typeof(Framework.Guama.Core.Persistence.ORM.EF.Entities.Trace))]
    public class TraceDisplayViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Framework.Guama.Core.Persistence.ORM.EF.Entities.Trace, long>
    {
        [Key]
        public long Id { get; set; }

        public Microsoft.EntityFrameworkCore.EntityState Type { get; set; }

        [Display(Name = "Author")]
        public string Author { get; set; }

        [Required]
        [Display(Name = "Registered")]
        public System.DateTime Registered { get; private set; }

        [Required]
        [Display(Name = "EntityName")]
        public string EntityName { get; set; }

        [Required]
        [Display(Name = "BeforeData")]
        public string BeforeData { get; set; }

        [Display(Name = "AfterData")]
        public string AfterData { get; set; }

        public void Import(Framework.Guama.Core.Persistence.ORM.EF.Entities.Trace entity)
        {
            Id = entity.Id;
            Type = entity.Type;
            Author = entity.Author;
            Registered = entity.Registered;
            EntityName = entity.EntityName;
            BeforeData = entity.BeforeData;
            AfterData = entity.AfterData;
        }
    }
}
