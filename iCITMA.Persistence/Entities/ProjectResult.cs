using System;
using System.Collections.Generic;
using System.Text;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class ProjectResult: Framework.Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        public ProjectResult()
        {
            Id = System.Guid.NewGuid();
        }
        [System.ComponentModel.DataAnnotations.Key]
        public Guid Id { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.Display(Name = "Result")]
        public string Result { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("ProjectId")]
        public Project Project { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public System.Guid? ProjectId { get; set; }
    }
}
