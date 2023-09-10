using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class SpecificObjectiveDisplayViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<SpecificObjective, Guid>
    {
        public Guid Id { get; set; }
        [Display(Name = "Objective")]
        public string Objective { get; set; }
        [Display(Name = "ProjectId")]
        public System.Guid ProjectId { get; set; }

        public void Import(SpecificObjective entity)
        {
            Id = entity.Id;
            Objective = entity.Objective;
            ProjectId =(System.Guid) entity.ProjectId;
        }
    }
}
