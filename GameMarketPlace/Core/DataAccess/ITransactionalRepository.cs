using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface ITransactionalRepository
    {
        void BeginScope(Action action);
        Task BeginScopeAsync(Action action);
    }
}
