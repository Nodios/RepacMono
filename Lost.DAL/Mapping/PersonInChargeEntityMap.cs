using Lost.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Lost.DAL.Mapping
{
    public class PersonInChargeEntityMap : EntityTypeConfiguration<PersonInChargeEntity>
    {
        public PersonInChargeEntityMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Table & Column Mappings
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.FirstName).HasColumnName("FirstName").HasMaxLength(30);
            Property(t => t.LastName).HasColumnName("LastName").HasMaxLength(30);
            Property(t => t.OIB).HasColumnName("OIB").HasMaxLength(13);

            // Relationships
            HasRequired(t => t.RedCrossEntity).WithMany(u => u.PersonInChargeEntities).HasForeignKey(t => t.RedCrossId);

        }
    }
}
