using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lost.Repository.Common;
using Lost.DAL;

namespace Lost.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private SearchContext Context;

        public UnitOfWork(SearchContext context)
        {
            Context = context;
        }

        public int Commit()
        {
            return Context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Context != null)
                {
                    Context.Dispose();
                    Context = null;
                }
            }
        }
    }
}
