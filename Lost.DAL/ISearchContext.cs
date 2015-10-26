using System.Collections.Generic;
using System;
using System.Data.Entity;

namespace Lost.DAL
{
    public interface ISearchContext
    {
        IDbSet<LostPersonEntity> LostPersons { get; set; }
        IDbSet<RedCrossEntity> RedCrosses { get; set; }

        /*
        List<LostPersonEntity> LostPersons { get; set; }
        List<RedCrossEntity> RedCrosses { get; set; }         
        */
    }
}
