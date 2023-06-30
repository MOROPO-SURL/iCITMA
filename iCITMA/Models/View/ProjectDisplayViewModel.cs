using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class ProjectDisplayViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Project, Guid>
    {
        public Guid Id { get; set; }
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name = "Code")]
        public string Code { get; set; }
        [Display(Name = "Program")]
        public string Program { get; set; }
        public string Category { get; set; }
        [Display(Name = "Principal Executor")]
        public string Manager { get; set; }
        [Display(Name = "Boss")]
        public string Leader { get; set; }
        [Display(Name = "Start At")]
        public DateTime StartAt { get; set; }
        [Display(Name = "End At")]
        public DateTime? EndAt { get; set; }
        [Display(Name = "Budget")]
        public decimal? Budget { get; set; }

        public void Import(Project entity)
        {
            Id = entity.Id;
            Title = entity.Title;
            Code = entity.Code;
            Program = entity.Program.Name;
            Category = entity.Category.Name;
            Leader = $"{entity.Leader.Identity.Name} {entity.Leader.Identity.LastName}";
            Manager = entity.Manager.Identity.Name;
            StartAt = entity.StartAt;
            EndAt = entity.EndAt;
            Budget = entity.Budget;
        }
    }
}
