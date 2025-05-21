using Core.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Core.Entities.Concrete.ProcessGroups;
using Core.DataAccess;

namespace DataAccess.Concrete.EntityFramework.General.Lookup
{
    public interface ITypeLookupRepository : IEntityRepository<TypeLookup>
    {

    }
    public class TypeLookupRepository : EfRepositoryBase<TypeLookup>, ITypeLookupRepository
    {
        public TypeLookupRepository(DbContext context) : base(context)
        {
        }
    }

}
