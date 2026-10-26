using MOROPO.Framework.Guama.Core.Persistence.ORM.EF.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class TraceInputViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Trace, long>
    {
        public long Id { get ; set; }

        public Trace Export()
        {
            throw new System.NotImplementedException();
        }

        public void Import(Trace entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Trace entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
