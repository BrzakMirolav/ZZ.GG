using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.GlobalModels
{
    public class PagingResult<T>
    {
        public IEnumerable<T>? Data { get; set; }
        public int? TotalCount { get; set; }
        public PagingResult(){
            Data = default;
        }
    }
}
