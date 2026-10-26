using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class SpecificObjectiveInputViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<SpecificObjective, Guid>
    {
        public Guid Id { get; set; }

        [Display(Name = "Objective")]
        [Required(ErrorMessage = "El Objetivo es requerido")]
        public string Objective { get; set; }

        [Display(Name = "ProjectId")]
        public System.Guid ProjectId { get; set; }

        public SpecificObjective Export()
        {
            var entity = new SpecificObjective();

            Mergue(entity);

            return entity;
        }

        public void Import(SpecificObjective entity)
        {
            Id = entity.Id;
            Objective = entity.Objective;
            ProjectId = (Guid)entity.ProjectId;
        }

        public void Mergue(SpecificObjective entity)
        {
            entity.Objective = Objective;           
        }
    }
}
