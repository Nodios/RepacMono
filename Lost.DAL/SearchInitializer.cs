using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Lost.DAL.Models;

namespace Lost.DAL
{
    public class SearchInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SearchContext>
    {
        protected override void Seed(SearchContext context)
        {
            #region new seed
            context.RedCrosses.Add(new RedCrossEntity()
            {
                Name = "GDCK Osijek",
                City = "Osijek",
                Country = "Croatia",
                PersonInCharge = "Goran Latkovic",

                LostPersonEntities = new List<LostPersonEntity>()
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
                    },
                    new LostPersonEntity{FirstName="Fgdfh", LastName="Tdhfjk", Birthday=DateTime.Parse("1966-03-01"), City="Osijek", Country="Hrvatska", DateLastSeen=DateTime.Parse("2015-09-25"), LocationLastSeen="Slavonski brod, Croatia", IsFound=false, ReporterName="Maja", Location="Slavonski brod, Croatia", ReportDate=DateTime.Parse("2015-10-11")},
                    new LostPersonEntity{FirstName="Petar", LastName="Bagarić", Birthday=DateTime.Parse("1968-08-12"), City="Zagreb", Country="Hrvatska", DateLastSeen=DateTime.Parse("2015-09-28"), LocationLastSeen="Opatovac, Croatia", IsFound=false, ReporterName="Davor", Location="Opatovac, Croatia", ReportDate=DateTime.Parse("2015-09-29")},
                    new LostPersonEntity{FirstName="Ivan", LastName="Bernatović", Birthday=DateTime.Parse("1968-06-10"), City="Virovitica", Country="Hrvatska", DateLastSeen=DateTime.Parse("2015-09-23"), LocationLastSeen="Tovarnik, Croatia", IsFound=false, ReporterName="Dino", Location="Tovarnik, Croatia", ReportDate=DateTime.Parse("2015-09-27")},
                    new LostPersonEntity{FirstName="Andi", LastName="Bašić", Birthday=DateTime.Parse("1968-10-19"), City="Rijeka", Country="Hrvatska", DateLastSeen=DateTime.Parse("2015-09-19"), LocationLastSeen="Tovarnik, Croatia", IsFound=false, ReporterName="Josip", Location="Tovarnik, Croatia", ReportDate=DateTime.Parse("2015-09-19")}
                }
            });
            context.SaveChanges();

            context.RedCrosses.Add(new RedCrossEntity()
            {
                Name = "GDCK Našice",
                City = "Našice",
                Country = "Croatia",
                PersonInCharge = "Igor Feldi",

                LostPersonEntities = new List<LostPersonEntity>()
                {
                    new LostPersonEntity{FirstName="Filip", LastName="Berečić", Birthday=DateTime.Parse("1968-12-30"), City="Split", Country="Hrvatska", DateLastSeen=DateTime.Parse("2015-09-20"), LocationLastSeen="Tovarnik, Croatia", IsFound=false, ReporterName="Ivan", Location="Tovarnik, Croatia", ReportDate=DateTime.Parse("2015-09-25")},
                    new LostPersonEntity{FirstName="Hrvoje", LastName="Hajduković", Birthday=DateTime.Parse("1968-09-01"), City="Zadar", Country="Hrvatska", DateLastSeen=DateTime.Parse("2015-09-25"), LocationLastSeen="Tovarnik, Croatia", IsFound=false, ReporterName="Kristijan", Location="Tovarnik, Croatia", ReportDate=DateTime.Parse("2015-09-30")},
                    new LostPersonEntity{FirstName="Tomislav", LastName="Jukić", Birthday=DateTime.Parse("1968-07-10"), City="Dubrovnik", Country="Hrvatska", DateLastSeen=DateTime.Parse("2015-09-21"), LocationLastSeen="Slavonski brod, Croatia", IsFound=false, ReporterName="Ivana", Location="Slavonski brod, Croatia", ReportDate=DateTime.Parse("2015-09-30")},
                    new LostPersonEntity{FirstName="Ivan", LastName="Jurić", Birthday=DateTime.Parse("1968-03-15"), City="Ploče", Country="Hrvatska", DateLastSeen=DateTime.Parse("2015-09-21"), LocationLastSeen="Opatovac, Croatia", IsFound=false, ReporterName="Mihaela", Location="Opatovac, Croatia", ReportDate=DateTime.Parse("2015-09-28")},
                    new LostPersonEntity{FirstName="Josip", LastName="Kopić", Birthday=DateTime.Parse("1968-01-14"), City="Sarajevo", Country="BiH", DateLastSeen=DateTime.Parse("2015-09-22"), LocationLastSeen="Opatovac, Croatia", IsFound=false, ReporterName="Samir", Location="Opatovac, Croatia", ReportDate=DateTime.Parse("2015-09-27")},
                    new LostPersonEntity{FirstName="Vlado", LastName="Kopić", Birthday=DateTime.Parse("1968-01-12"), City="Novi Sad", Country="Srbija", DateLastSeen=DateTime.Parse("2015-09-27"), LocationLastSeen="Opatovac, Croatia", IsFound=false, ReporterName="Milan", Location="Opatovac, Croatia", ReportDate=DateTime.Parse("2015-09-27")},
                    new LostPersonEntity{FirstName="Robert", LastName="Labus", Birthday=DateTime.Parse("1968-02-08"), City="Niš", Country="Srbija", DateLastSeen=DateTime.Parse("2015-09-29"), LocationLastSeen="Opatovac, Croatia", IsFound=false, ReporterName="Srđan", Location="Opatovac, Croatia", ReportDate=DateTime.Parse("2015-09-30")},
                    new LostPersonEntity{FirstName="Matija", LastName="Lekić", Birthday=DateTime.Parse("1968-02-18"), City="Ljubljana", Country="Slovenija", DateLastSeen=DateTime.Parse("2015-09-30"), LocationLastSeen="Opatovac, Croatia", IsFound=false, ReporterName="Davor", Location="Opatovac, Croatia", ReportDate=DateTime.Parse("2015-09-30")}        
                }
            });
            context.SaveChanges();
            #endregion


            #region old seed
            //var redCrosses = new List<RedCrossEntity>
            //{
            //    new RedCrossEntity
            //    {
            //        Name="GDCK Osijek", 
            //        City="Osijek", 
            //        Country="Croatia",
            //        PersonInCharge="Goran Latkovic"
            //    },
            //    new RedCrossEntity
            //    {
            //        Name="GDCK Našice", 
            //        City="Našice", 
            //        Country="Croatia",
            //        PersonInCharge="Igor Feldi"
            //    }
            //};
            //redCrosses.ForEach(s => context.RedCrosses.Add(s));
            //context.SaveChanges();

            //var lostPersons = new List<LostPersonEntity>
            //{
            //    new LostPersonEntity
            //    {
            //        FirstName="Abdul",
            //        LastName="Ghulabudin",
            //        Birthday=DateTime.Parse("1978-01-01"), 
            //        City="Damask", 
            //        Country="Siria",
            //        DateLastSeen=DateTime.Parse("2015-09-25"),
            //        LocationLastSeen="Opatovac, Croatia", 
            //        IsFound=false, 
            //        ReporterName="Dino", 
            //        Location="Opatovac, Croatia", 
            //        ReportDate=DateTime.Parse("2015-09-29"),
            //    },
            //    new LostPersonEntity
            //    {
            //        FirstName="Afsdg", 
            //        LastName="Rdgjfhk",
            //        Birthday=DateTime.Parse("1962-04-01"),
            //        City="Damask", 
            //        Country="Siria",
            //        DateLastSeen=DateTime.Parse("2015-09-25"),
            //        LocationLastSeen="Opatovac, Croatia", 
            //        IsFound=false, 
            //        ReporterName="Dinko", 
            //        Location="Opatovac, Croatia", 
            //        ReportDate=DateTime.Parse("2015-10-15"),
            //    },
            //    new LostPersonEntity{FirstName="Fgdfh", LastName="Tdhfjk", Birthday=DateTime.Parse("1966-03-01"), City="Osijek", Country="Hrvatska", DateLastSeen=DateTime.Parse("2015-09-25"), LocationLastSeen="Slavonski brod, Croatia", IsFound=false, ReporterName="Maja", Location="Slavonski brod, Croatia", ReportDate=DateTime.Parse("2015-10-11")},
            //    new LostPersonEntity{FirstName="Petar", LastName="Bagarić", Birthday=DateTime.Parse("1968-08-12"), City="Zagreb", Country="Hrvatska", DateLastSeen=DateTime.Parse("2015-09-28"), LocationLastSeen="Opatovac, Croatia", IsFound=false, ReporterName="Davor", Location="Opatovac, Croatia", ReportDate=DateTime.Parse("2015-09-29")},
            //    new LostPersonEntity{FirstName="Ivan", LastName="Bernatović", Birthday=DateTime.Parse("1968-06-10"), City="Virovitica", Country="Hrvatska", DateLastSeen=DateTime.Parse("2015-09-23"), LocationLastSeen="Tovarnik, Croatia", IsFound=false, ReporterName="Dino", Location="Tovarnik, Croatia", ReportDate=DateTime.Parse("2015-09-27")},
            //    new LostPersonEntity{FirstName="Andi", LastName="Bašić", Birthday=DateTime.Parse("1968-10-19"), City="Rijeka", Country="Hrvatska", DateLastSeen=DateTime.Parse("2015-09-19"), LocationLastSeen="Tovarnik, Croatia", IsFound=false, ReporterName="Josip", Location="Tovarnik, Croatia", ReportDate=DateTime.Parse("2015-09-19")},
            //    new LostPersonEntity{FirstName="Filip", LastName="Berečić", Birthday=DateTime.Parse("1968-12-30"), City="Split", Country="Hrvatska", DateLastSeen=DateTime.Parse("2015-09-20"), LocationLastSeen="Tovarnik, Croatia", IsFound=false, ReporterName="Ivan", Location="Tovarnik, Croatia", ReportDate=DateTime.Parse("2015-09-25")},
            //    new LostPersonEntity{FirstName="Hrvoje", LastName="Hajduković", Birthday=DateTime.Parse("1968-09-01"), City="Zadar", Country="Hrvatska", DateLastSeen=DateTime.Parse("2015-09-25"), LocationLastSeen="Tovarnik, Croatia", IsFound=false, ReporterName="Kristijan", Location="Tovarnik, Croatia", ReportDate=DateTime.Parse("2015-09-30")},
            //    new LostPersonEntity{FirstName="Tomislav", LastName="Jukić", Birthday=DateTime.Parse("1968-07-10"), City="Dubrovnik", Country="Hrvatska", DateLastSeen=DateTime.Parse("2015-09-21"), LocationLastSeen="Slavonski brod, Croatia", IsFound=false, ReporterName="Ivana", Location="Slavonski brod, Croatia", ReportDate=DateTime.Parse("2015-09-30")},
            //    new LostPersonEntity{FirstName="Ivan", LastName="Jurić", Birthday=DateTime.Parse("1968-03-15"), City="Ploče", Country="Hrvatska", DateLastSeen=DateTime.Parse("2015-09-21"), LocationLastSeen="Opatovac, Croatia", IsFound=false, ReporterName="Mihaela", Location="Opatovac, Croatia", ReportDate=DateTime.Parse("2015-09-28")},
            //    new LostPersonEntity{FirstName="Josip", LastName="Kopić", Birthday=DateTime.Parse("1968-01-14"), City="Sarajevo", Country="BiH", DateLastSeen=DateTime.Parse("2015-09-22"), LocationLastSeen="Opatovac, Croatia", IsFound=false, ReporterName="Samir", Location="Opatovac, Croatia", ReportDate=DateTime.Parse("2015-09-27")},
            //    new LostPersonEntity{FirstName="Vlado", LastName="Kopić", Birthday=DateTime.Parse("1968-01-12"), City="Novi Sad", Country="Srbija", DateLastSeen=DateTime.Parse("2015-09-27"), LocationLastSeen="Opatovac, Croatia", IsFound=false, ReporterName="Milan", Location="Opatovac, Croatia", ReportDate=DateTime.Parse("2015-09-27")},
            //    new LostPersonEntity{FirstName="Robert", LastName="Labus", Birthday=DateTime.Parse("1968-02-08"), City="Niš", Country="Srbija", DateLastSeen=DateTime.Parse("2015-09-29"), LocationLastSeen="Opatovac, Croatia", IsFound=false, ReporterName="Srđan", Location="Opatovac, Croatia", ReportDate=DateTime.Parse("2015-09-30")},
            //    new LostPersonEntity{FirstName="Matija", LastName="Lekić", Birthday=DateTime.Parse("1968-02-18"), City="Ljubljana", Country="Slovenija", DateLastSeen=DateTime.Parse("2015-09-30"), LocationLastSeen="Opatovac, Croatia", IsFound=false, ReporterName="Davor", Location="Opatovac, Croatia", ReportDate=DateTime.Parse("2015-09-30")}
            //};
            //lostPersons.ForEach(s => context.LostPersons.Add(s));
            //context.SaveChanges();
            #endregion

        }
    }
}
