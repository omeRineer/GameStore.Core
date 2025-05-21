using Core.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Core.Entities.Concrete.ProcessGroups;
using Core.DataAccess;

namespace DataAccess.Concrete.EntityFramework.General.Lookup
{
    public interface IStatusLookupRepository : IEntityRepository<StatusLookup>
    {

    }
    public class StatusLookupRepository : EfRepositoryBase<StatusLookup>, IStatusLookupRepository
    {
        public StatusLookupRepository(DbContext context) : base(context)
        {
        }
    }
}
