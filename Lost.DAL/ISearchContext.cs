using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using Lost.DAL.Models;

namespace Lost.DAL
{
    public interface ISearchContext
    {
        DbSet<LostPersonEntity> LostPersons { get; set; }
        DbSet<RedCrossEntity> RedCrosses { get; set; }

        DbSet<T> Set<T>() where T : class;
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
        Task<int> SaveChangesAsync();
    }
}
