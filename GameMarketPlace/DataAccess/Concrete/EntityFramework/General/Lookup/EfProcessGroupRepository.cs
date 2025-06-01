using Core.DataAccess.EntityFramework;
using Core.DataAccess;
using Entities.Main;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete.ProcessGroups;

namespace DataAccess.Concrete.EntityFramework.General.Lookup
{
    public interface IEfProcessGroupRepository : IEfEntityRepository<ProcessGroup, int>, IEfEntityRepositoryAsync<ProcessGroup, int>
    {

    }
    public class EfProcessGroupRepository : EfRepositoryBase<ProcessGroup, int>, IEfProcessGroupRepository
    {
        public EfProcessGroupRepository(DbContext context) : base(context)
        {
        }
    }

    

}
