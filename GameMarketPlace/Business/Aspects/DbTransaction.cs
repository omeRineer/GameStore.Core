using AspectInjector.Broker;
using Castle.DynamicProxy;
using Core.Utilities.Interceptor;
using Core.Utilities.ServiceTools;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Aspects
{
    public class DbTransaction
    {
        readonly DbContext Context;

        public DbTransaction()
        {
            Context = StaticServiceProvider.GetService<DbContext>();
        }

    }
}
