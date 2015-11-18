using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Lost.DAL.Models;

namespace Lost.DAL.Mapping
{
    public class RedCrossEntityMap : EntityTypeConfiguration<RedCrossEntity>
    {
        public RedCrossEntityMap()
        {
            // Primary Key
            this.HasKey(t => t.RedCrossId);

            // Properties
            // Table & Column Mappings
            this.ToTable("RedCrossEntity");
            this.Property(t => t.RedCrossId).HasColumnName("RedCrossId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.Country).HasColumnName("Country");
            this.Property(t => t.PersonInCharge).HasColumnName("PersonInCharge");
        }
    }
}
