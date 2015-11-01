using System.Collections.Generic;
using System;
using System.Data.Entity;

namespace Lost.DAL
{
    public interface ISearchContext
    {
        DbSet<LostPersonEntity> LostPersons { get; set; }
        DbSet<RedCrossEntity> RedCrosses { get; set; }  
    }
}
