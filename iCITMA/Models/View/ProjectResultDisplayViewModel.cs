using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class ProjectResultDisplayViewModel: Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<ProjectResult, Guid>
    {
        public Guid Id { get; set; }
        [Display(Name = "Result")]
        public string Result { get; set; }
        [Display(Name = "ProjectId")]
        public System.Guid ProjectId { get; set; }

        public void Import(ProjectResult entity)
        {
            Id = entity.Id;
            Result = entity.Result;
            ProjectId = (System.Guid)entity.ProjectId;
        }
    }
}
