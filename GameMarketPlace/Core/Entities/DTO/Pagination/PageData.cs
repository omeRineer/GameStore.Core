using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.DTO.Pagination
{
    public class PageData<TEntity>
    {
        public int Page { get; init; }
        public int Size { get; init; }
        public int TotalCount { get; init; }
        public List<TEntity>? Data { get; set; }
    }
}
