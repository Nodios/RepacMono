using Lost.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lost.DAL.Mapping
{
    public class PersonInChargeMap : EntityTypeConfiguration<PersonInChargeEntity>
    {
        public PersonInChargeMap()
        {
            this.HasKey(t => t.Id);

            // Properties
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.FirstName).IsRequired().HasMaxLength(50);
            Property(t => t.LastName).IsRequired().HasMaxLength(50);
            Property(t => t.OIB).IsRequired().HasMaxLength(50);

            //Relation
            HasRequired(t => t.RedCrossEntity).WithMany(t => t.PersonInChargeEntities).HasForeignKey(t => t.RedCrossId);
            HasRequired(t => t.ApplicationUser).WithOptional(t => t.PersonInCharge);
        }
    }
}
