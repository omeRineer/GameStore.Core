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
    public interface IProcessGroupRepository : IEntityRepository<ProcessGroup>
    {

    }
    public class ProcessGroupRepository : EfRepositoryBase<ProcessGroup>, IProcessGroupRepository
    {
        public ProcessGroupRepository(DbContext context) : base(context)
        {
        }
    }

    

}
