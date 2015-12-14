using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Lost.DAL.Models;

namespace Lost.DAL.Mapping
{
    public class LostPersonEntityMap : EntityTypeConfiguration<LostPersonEntity>
    {
        public LostPersonEntityMap()
        {
            //Primary key
            this.HasKey(t => t.Id);

            // Properties
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.FirstName).IsRequired().HasMaxLength(50);
            Property(t => t.LastName).IsRequired().HasMaxLength(50);
            Property(t => t.Birthday).HasColumnType("datetime2");
            Property(t => t.City).IsRequired().HasMaxLength(50);
            Property(t => t.Country).IsRequired().HasMaxLength(50);
            Property(t => t.DateLastSeen).HasColumnType("datetime2");
            Property(t => t.LocationLastSeen).IsRequired().HasMaxLength(50);
            Property(t => t.ReporterName).IsRequired().HasMaxLength(70);
            Property(t => t.ReportDate).HasColumnType("datetime2");
            Property(t => t.Location).IsRequired().HasMaxLength(50);
            Property(t => t.IsFound).IsRequired();

            // Relationships
            HasRequired(t => t.RedCrossEntity).WithMany(t => t.LostPersonEntities).HasForeignKey(d => d.RedCrossEntityId);

        }
    }
}
