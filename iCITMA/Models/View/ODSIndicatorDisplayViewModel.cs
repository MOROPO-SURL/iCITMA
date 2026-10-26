using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using System;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class ODSIndicatorDisplayViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<ODSIndicator, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Name")]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Description")]
        public string Description { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Reference")]        
        public string Reference { get; set; }       

        public void Import(ODSIndicator entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
            Reference = entity.Reference;
        }       
    }
}
