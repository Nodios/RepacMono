using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lost.DAL;
using Lost.Repository.Common;

namespace Lost.Repository.DBInteractions
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private SearchContext Context;

        public UnitOfWork(SearchContext context)
        {
            Context = context;
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        //Commit changes
        public bool Commit()
        {
            try
            {
                return Context.SaveChanges() > 0;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
