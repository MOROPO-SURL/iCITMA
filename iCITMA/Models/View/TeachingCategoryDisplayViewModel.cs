using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using System;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class TeachingCategoryDisplayViewModel : SAPRESSC.Core.Persistence.Models.IEntityDisplayModel<TeachingCategory, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Name")]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Description")]
        public string Description { get; set; }

        public void Import(TeachingCategory entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
        }
    }
}
