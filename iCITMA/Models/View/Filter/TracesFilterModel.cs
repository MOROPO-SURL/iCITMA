using MOROPO.Framework.Guama.Core.Persistence.ORM.EF.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract;
using System;
using System.Linq.Expressions;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View.Filter
{
    public class TracesFilterModel : IEntityFilterModel<Trace, long>
    {
        public string Id { get; set; }
        public Expression<Func<Trace, bool>> GetSelector()
        {
            if (Id == null || Id == string.Empty) return null;

            return user => user.Author.Contains(Id);
        }
    }
}
