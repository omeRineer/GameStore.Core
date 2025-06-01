using Core.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Core.Entities.Concrete.ProcessGroups;
using Core.DataAccess;

namespace DataAccess.Concrete.EntityFramework.General.Lookup
{
    public interface IEfStatusLookupRepository : IEfEntityRepository<StatusLookup, int>, IEfEntityRepositoryAsync<StatusLookup, int>
    {

    }
    public class EfStatusLookupRepository : EfRepositoryBase<StatusLookup, int>, IEfStatusLookupRepository
    {
        public EfStatusLookupRepository(DbContext context) : base(context)
        {
        }
    }
}
