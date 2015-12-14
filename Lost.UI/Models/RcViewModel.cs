using Lost.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lost.UI.Models
{
    public class RcViewModel
    {
        public IEnumerable<IRedCross> RedCross { get; private set; }

        public RcViewModel(IEnumerable<IRedCross> redCross)
        {
            RedCross = redCross;
        }
    }
}