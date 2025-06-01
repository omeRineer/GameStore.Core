using Core.DataAccess.EntityFramework;
using Core.DataAccess;
using Entities.Main;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.General
{
    public interface IEfSliderContentRepository : IEfEntityRepository<SliderContent, Guid>, IEfEntityRepositoryAsync<SliderContent, Guid>
    {

    }
    public class EfSliderContentRepository : EfRepositoryBase<SliderContent, Guid>, IEfSliderContentRepository
    {
        public EfSliderContentRepository(DbContext context) : base(context)
        {
        }
    }
}
