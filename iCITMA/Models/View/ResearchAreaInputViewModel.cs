using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using System;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class ResearchAreaInputViewModel: SAPRESSC.Core.Persistence.Models.IEntityInputModel<ResearchArea, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Name")]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Description")]
        public string Description { get; set; }

        public ResearchArea Export()
        {
            var entity = new ResearchArea();

            Mergue(entity);

            return entity;
        }

        public void Import(ResearchArea entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
        }

        public void Mergue(ResearchArea entity)
        {
            entity.Name = Name;
            entity.Description = Description;
        }
    }
}