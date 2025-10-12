using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Common
{
    public class ListResponse<TData>
    {
        public ListResponse(IList<TData> data)
        {
            Data = new ReadOnlyCollection<TData>(data);
        }

        public int Count => Data.Count;
        public IReadOnlyCollection<TData> Data { get; set; }
    }
}
