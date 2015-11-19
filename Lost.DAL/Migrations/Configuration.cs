namespace Lost.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Lost.DAL.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<Lost.DAL.SearchContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Lost.DAL.SearchContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
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
            redCrosses.ForEach(s => context.RedCrosses.AddOrUpdate(c => c.Country, s));
            context.SaveChanges();

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
                new LostPersonEntity{FirstName="Fgdfh", LastName="Tdhfjk", Birthday=DateTime.Parse("1966-03-01"), City="Osijek", Country="Hrvatska", DateLastSeen=DateTime.Parse("2015-09-25"), LocationLastSeen="Slavonski brod, Croatia", IsFound=false, ReporterName="Maja", Location="Slavonski brod, Croatia", ReportDate=DateTime.Parse("2015-10-11"), RedCrossId=1},
                new LostPersonEntity{FirstName="Petar", LastName="Bagariæ", Birthday=DateTime.Parse("1968-08-12"), City="Zagreb", Country="Hrvatska", DateLastSeen=DateTime.Parse("2015-09-28"), LocationLastSeen="Opatovac, Croatia", IsFound=false, ReporterName="Davor", Location="Opatovac, Croatia", ReportDate=DateTime.Parse("2015-09-29"), RedCrossId=1},
                new LostPersonEntity{FirstName="Ivan", LastName="Bernatoviæ", Birthday=DateTime.Parse("1968-06-10"), City="Virovitica", Country="Hrvatska", DateLastSeen=DateTime.Parse("2015-09-23"), LocationLastSeen="Tovarnik, Croatia", IsFound=false, ReporterName="Dino", Location="Tovarnik, Croatia", ReportDate=DateTime.Parse("2015-09-27"), RedCrossId=1},
                new LostPersonEntity{FirstName="Andi", LastName="Bašiæ", Birthday=DateTime.Parse("1968-10-19"), City="Rijeka", Country="Hrvatska", DateLastSeen=DateTime.Parse("2015-09-19"), LocationLastSeen="Tovarnik, Croatia", IsFound=false, ReporterName="Josip", Location="Tovarnik, Croatia", ReportDate=DateTime.Parse("2015-09-19"), RedCrossId=1},
                new LostPersonEntity{FirstName="Filip", LastName="Bereèiæ", Birthday=DateTime.Parse("1968-12-30"), City="Split", Country="Hrvatska", DateLastSeen=DateTime.Parse("2015-09-20"), LocationLastSeen="Tovarnik, Croatia", IsFound=false, ReporterName="Ivan", Location="Tovarnik, Croatia", ReportDate=DateTime.Parse("2015-09-25"), RedCrossId=1},
                new LostPersonEntity{FirstName="Hrvoje", LastName="Hajdukoviæ", Birthday=DateTime.Parse("1968-09-01"), City="Zadar", Country="Hrvatska", DateLastSeen=DateTime.Parse("2015-09-25"), LocationLastSeen="Tovarnik, Croatia", IsFound=false, ReporterName="Kristijan", Location="Tovarnik, Croatia", ReportDate=DateTime.Parse("2015-09-30"), RedCrossId=1},
                new LostPersonEntity{FirstName="Tomislav", LastName="Jukiæ", Birthday=DateTime.Parse("1968-07-10"), City="Dubrovnik", Country="Hrvatska", DateLastSeen=DateTime.Parse("2015-09-21"), LocationLastSeen="Slavonski brod, Croatia", IsFound=false, ReporterName="Ivana", Location="Slavonski brod, Croatia", ReportDate=DateTime.Parse("2015-09-30"), RedCrossId=1},
                new LostPersonEntity{FirstName="Ivan", LastName="Juriæ", Birthday=DateTime.Parse("1968-03-15"), City="Ploèe", Country="Hrvatska", DateLastSeen=DateTime.Parse("2015-09-21"), LocationLastSeen="Opatovac, Croatia", IsFound=false, ReporterName="Mihaela", Location="Opatovac, Croatia", ReportDate=DateTime.Parse("2015-09-28"), RedCrossId=1},
                new LostPersonEntity{FirstName="Josip", LastName="Kopiæ", Birthday=DateTime.Parse("1968-01-14"), City="Sarajevo", Country="BiH", DateLastSeen=DateTime.Parse("2015-09-22"), LocationLastSeen="Opatovac, Croatia", IsFound=false, ReporterName="Samir", Location="Opatovac, Croatia", ReportDate=DateTime.Parse("2015-09-27"), RedCrossId=1},
                new LostPersonEntity{FirstName="Vlado", LastName="Kopiæ", Birthday=DateTime.Parse("1968-01-12"), City="Novi Sad", Country="Srbija", DateLastSeen=DateTime.Parse("2015-09-27"), LocationLastSeen="Opatovac, Croatia", IsFound=false, ReporterName="Milan", Location="Opatovac, Croatia", ReportDate=DateTime.Parse("2015-09-27"), RedCrossId=1},
                new LostPersonEntity{FirstName="Robert", LastName="Labus", Birthday=DateTime.Parse("1968-02-08"), City="Niš", Country="Srbija", DateLastSeen=DateTime.Parse("2015-09-29"), LocationLastSeen="Opatovac, Croatia", IsFound=false, ReporterName="Srðan", Location="Opatovac, Croatia", ReportDate=DateTime.Parse("2015-09-30"), RedCrossId=1},
                new LostPersonEntity{FirstName="Matija", LastName="Lekiæ", Birthday=DateTime.Parse("1968-02-18"), City="Ljubljana", Country="Slovenija", DateLastSeen=DateTime.Parse("2015-09-30"), LocationLastSeen="Opatovac, Croatia", IsFound=false, ReporterName="Davor", Location="Opatovac, Croatia", ReportDate=DateTime.Parse("2015-09-30"), RedCrossId=1}
            };
            lostPersons.ForEach(s => context.LostPersons.AddOrUpdate(l => l.LastName, s));
            context.SaveChanges();
        }
    }
}
