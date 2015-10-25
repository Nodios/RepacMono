using System.Collections.Generic;
using System;

namespace Lost.DAL
{
    public interface ISearchContext
    {
        List<LostPersonEntity> LostPersons { get; set; }
        List<RedCrossEntity> RedCrosses { get; set; }
    }
}
