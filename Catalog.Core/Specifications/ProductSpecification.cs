using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Core.Specifications
{
    public class ProductSpecification
    {
        private const int MaxPageSize = 30;
        private int pageSize = 10;
        public int PageIndex { get; set; } = 1;
        public int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                pageSize = value > MaxPageSize ? MaxPageSize : value;
            }
        }
       
        public string? Sort { get; set; }
        public string? Search { get; set; }
    }
}
