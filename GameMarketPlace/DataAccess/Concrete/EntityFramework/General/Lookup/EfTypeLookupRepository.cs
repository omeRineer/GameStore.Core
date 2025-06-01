using Core.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Core.Entities.Concrete.ProcessGroups;
using Core.DataAccess;

namespace DataAccess.Concrete.EntityFramework.General.Lookup
{
    public interface IEfTypeLookupRepository : IEfEntityRepository<TypeLookup, int>, IEfEntityRepositoryAsync<TypeLookup, int>
    {

    }
    public class EfTypeLookupRepository : EfRepositoryBase<TypeLookup, int>, IEfTypeLookupRepository
    {
        public EfTypeLookupRepository(DbContext context) : base(context)
        {
        }
    }

}
