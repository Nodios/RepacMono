using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lost.Common.Filters
{
    public class GenericFilter
    {
        public string searchString { get; set; }
        public string sortOrder { get; private set; }
        public int pageNumber { get; private set; }
        public int pageSize { get; private set; }

        //determines default page size
        public int defaultPageSize = 10;

        public GenericFilter(string searchString, int pageNumber, int pageSize)
        {
            this.searchString = searchString;
            this.pageNumber = (pageNumber > 0) ? pageNumber : 1;
            this.pageSize = (pageSize > 0 && pageSize <= defaultPageSize) ? pageSize : defaultPageSize;
        }


    }
}
