using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lost.Common
{
    public class Paging
    {
        protected int pageNumber;
        protected int pageSize;
        protected int defaultPageSize;

        public Paging(int pageNumber, int pageSize)
        {
            defaultPageSize = 10;
            this.pageSize = pageSize;
            this.pageNumber = pageNumber;
        }

        public virtual int PageNumber
        {
            get
            {
                if (pageNumber <= 0)
                    pageNumber = 1;

                return pageNumber;
            }
        }
        public virtual int PageSize
        {
            get
            {
                //page can contain only defaultPageSize elements
                if (pageSize <= 0 || pageSize > defaultPageSize)
                    pageSize = defaultPageSize;

                return pageSize;
            }
        }
    }
}
