using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lost.Model.Common;

namespace Lost.UI.Models
{
    public class LostPersonViewModel
    {
        public IEnumerable<ILostPerson> LostPersons { get; private set; }
        public LostPersonViewModel(IEnumerable<ILostPerson> lostPersons)
        {
            LostPersons = lostPersons;
        }
    }
}