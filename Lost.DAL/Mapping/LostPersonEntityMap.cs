using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Lost.DAL.Models;

namespace Lost.DAL.Mapping
{
    public class LostPersonEntityMap : EntityTypeConfiguration<LostPersonEntity>
    {
        public LostPersonEntityMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("LostPersonEntity");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.Birthday).HasColumnName("Birthday");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.Country).HasColumnName("Country");
            this.Property(t => t.DateLastSeen).HasColumnName("DateLastSeen");
            this.Property(t => t.LocationLastSeen).HasColumnName("LocationLastSeen");
            this.Property(t => t.ReporterName).HasColumnName("ReporterName");
            this.Property(t => t.ReportDate).HasColumnName("ReportDate");
            this.Property(t => t.Location).HasColumnName("Location");
            this.Property(t => t.IsFound).HasColumnName("IsFound");
            this.Property(t => t.RedCrossId).HasColumnName("RedCrossId");

            // Relationships
            this.HasRequired(t => t.RedCrossEntity)
                .WithMany(t => t.LostPersonEntities)
                .HasForeignKey(d => d.RedCrossId);

        }
    }
}
