using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Models.Common
{
    public class PaginationResponse<TData>
    {
        public PaginationResponse(IList<TData> data, int totalCount, int page, int size)
        {
            Data = new ReadOnlyCollection<TData>(data);
            TotalCount = totalCount;
            Page = page;
            Size = size;
        }

        public int Page { get; }
        public int Size { get; }
        public int TotalCount { get; }
        public IReadOnlyCollection<TData> Data { get; }
    }
}
