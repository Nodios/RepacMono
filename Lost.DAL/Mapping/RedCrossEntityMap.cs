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
            HasKey(t => t.RedCrossId);            

            // Properties
            Property(t => t.RedCrossId).HasColumnName("RedCrossId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).HasMaxLength(60);
            Property(t => t.City).HasMaxLength(30);
            Property(t => t.Country).HasMaxLength(20);
            Property(t => t.PersonInCharge).HasMaxLength(70);
        }
    }
}
