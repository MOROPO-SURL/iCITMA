using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class ProjectImpactProgramExpectResultInputViewModel
    {
        public Guid ProgramExpectResultId { get; set; }

        public Guid ProjectImpactId { get; set; }

        [Display(Name = "Results")]
        public System.Collections.Generic.ICollection<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> NotSelectedProgramExpectResult { get; set; } = new System.Collections.Generic.List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
        

        
    }
}
