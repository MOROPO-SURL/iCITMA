using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using System;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class SceneryKindInputViewModel: SAPRESSC.Core.Persistence.Models.IEntityInputModel<SceneryKind, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Name")]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Description")]
        public string Description { get; set; }

        public SceneryKind Export()
        {
            var entity = new SceneryKind();

            Mergue(entity);

            return entity;
        }

        public void Import(SceneryKind entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
        }

        public void Mergue(SceneryKind entity)
        {
            entity.Name = Name;
            entity.Description = Description;
        }
    }
}