using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Lost.DAL
{
    public class SearchContext : DbContext, ISearchContext
    {
        public SearchContext() : base("SearchContext") { }

        public DbSet<LostPersonEntity> LostPersons { get; set; }
        public DbSet<RedCrossEntity> RedCrosses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Singular names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
