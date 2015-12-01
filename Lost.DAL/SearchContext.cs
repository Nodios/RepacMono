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
            modelBuilder.Configurations.Add(new LostPersonEntityMap());
            modelBuilder.Configurations.Add(new RedCrossEntityMap());

            modelBuilder.Conventions.Add<PluralizingTableNameConvention>();
        }

        public override DbSet<T> Set<T>()
        {
            return base.Set<T>();
        }

        //Validation error catch
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    System.Diagnostics.Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}
