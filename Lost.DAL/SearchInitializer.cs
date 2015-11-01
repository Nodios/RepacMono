using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Lost.DAL
{
    public class SearchInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SearchContext>
    {
        protected override void Seed(SearchContext context)
        {
            var lostPersons = new List<LostPersonEntity>
            {
                new LostPersonEntity
                {
                    FirstName="Abdul",
                    LastName="Ghulabudin",
                    Birthday=DateTime.Parse("1978-01-01"), 
                    City="Damask", 
                    Country="Siria",
                    DateLastSeen=DateTime.Parse("2015-09-25"),
                    LocationLastSeen="Opatovac, Croatia", 
                    IsFound=false, 
                    ReporterName="Dino", 
                    Location="Opatovac, Croatia", 
                    ReportDate=DateTime.Parse("2015-09-29"),
                    RedCrossId=1
                },
                new LostPersonEntity
                {
                    FirstName="Afsdg", 
                    LastName="Rdgjfhk",
                    Birthday=DateTime.Parse("1962-04-01"),
                    City="Damask", 
                    Country="Siria",
                    DateLastSeen=DateTime.Parse("2015-09-25"),
                    LocationLastSeen="Opatovac, Croatia", 
                    IsFound=false, 
                    ReporterName="Dinko", 
                    Location="Opatovac, Croatia", 
                    ReportDate=DateTime.Parse("2015-10-15"),
                    RedCrossId=1
                },
                new LostPersonEntity{FirstName="Fgdfh", LastName="Tdhfjk", Birthday=DateTime.Parse("1966-03-01"), City="Damask", Country="Siria", DateLastSeen=DateTime.Parse("2015-09-25"), LocationLastSeen="Opatovac, Croatia", IsFound=false, ReporterName="Maja", Location="Opatovac, Croatia", ReportDate=DateTime.Parse("2015-10-11"), RedCrossId=1},
                new LostPersonEntity{FirstName="Tdfhfg", LastName="Vsdfghd", Birthday=DateTime.Parse("1968-02-10"), City="Damask", Country="Siria", DateLastSeen=DateTime.Parse("2015-09-25"), LocationLastSeen="Opatovac, Croatia", IsFound=true, ReporterName="Davor", Location="Opatovac, Croatia", ReportDate=DateTime.Parse("2015-09-01"), RedCrossId=1}
            };
            lostPersons.ForEach(s => context.LostPersons.Add(s));
            context.SaveChanges();

            var redCrosses = new List<RedCrossEntity>
            {
                new RedCrossEntity
                {
                    Name="GDCK Osijek", 
                    City="Osijek", 
                    Country="Croatia",
                    PersonInCharge="Goran Latkovic"
                }
            };
            redCrosses.ForEach(s => context.RedCrosses.Add(s));
            context.SaveChanges();
        }
    }
}
