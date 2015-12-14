using Lost.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Lost.DAL.Mapping
{
    public class RedCrossEntityMap : EntityTypeConfiguration<RedCrossEntity>
    {
        public RedCrossEntityMap()
        {
            // Primary Key
            this.HasKey(t => t.RedCrossId);            

            // Properties
            Property(t => t.RedCrossId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).IsRequired().HasMaxLength(60);
            Property(t => t.City).IsRequired().HasMaxLength(30);
            Property(t => t.Country).IsRequired().HasMaxLength(20);
            Property(t => t.PersonInCharge).IsRequired().HasMaxLength(70);
        }
    }
}
