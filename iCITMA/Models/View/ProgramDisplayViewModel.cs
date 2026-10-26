using System.Linq;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class ProgramDisplayViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Program, System.Guid>
    {
        public System.Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string Code { get; set; }
        
        public string Manager { get; set; }
        
        public string Category { get; set; }
        
        public string Leader { get; set; }
        
        public System.DateTime StartDate { get; set; }
        
        public System.DateTime? EndAt { get; set; }

        public string Description { get; set; }

        public PersonDisplayViewModel[] Experts { get; set; }
        public KeyWordDisplayViewModel[] KeyWords { get; set; }
        public DocumentDisplayViewModel[] Documents { get; set; }

        public void Import(Persistence.Entities.Program entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Code = entity.Code;
            Category = entity.Category.Name;
            Manager = entity.Manager.Identity.Name;
            Leader = entity.Leader.Identity.LastName != null ? string.Format("{0} {1}", entity.Leader.Identity.Name, entity.Leader.Identity.LastName) : entity.Leader.Identity.Name;
            StartDate = entity.StartAt;
            EndAt = entity.EndAt;
            Description = entity.Description;
            Experts = entity.PersonExpertBridges.Select(bridge =>
            {
                var model = new PersonDisplayViewModel();

                model.Import(bridge.Stern);

                return model;
            }).ToArray();
            KeyWords = entity.KeyWordBridges.Select(bridge =>
            {
                var model = new KeyWordDisplayViewModel();

                model.Import(bridge.Stern);

                return model;
            }).ToArray();
            Documents = entity.DocumentBridges.Select(bridge =>
            {
                var model = new DocumentDisplayViewModel();

                model.Import(bridge.Stern);

                return model;
            }).ToArray();
        }
    }
}
