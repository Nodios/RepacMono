using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Lost.DAL.Mapping;
using Lost.DAL.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Lost.DAL
{
    public partial class SearchContext : DbContext, ISearchContext
    {
        //static SearchContext()
        //{
        //    Database.SetInitializer<SearchContext>(null);
        //}

        public SearchContext()
            : base("Name=SearchContext")
        {
        }

        public DbSet<LostPersonEntity> LostPersons { get; set; }
        public DbSet<RedCrossEntity> RedCrosses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<LostPersonEntity>();
            modelBuilder.Configurations.Add(new LostPersonEntityMap());
            
            //modelBuilder.Entity<RedCrossEntity>();
            modelBuilder.Configurations.Add(new RedCrossEntityMap());

            //singular table names
            modelBuilder.Conventions.Add<PluralizingTableNameConvention>();
        }

        public override DbSet<T> Set<T>()
        {
            return base.Set<T>();
        }
    }
}
