using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lost.UI.Models
{
    public class RcViewModel
    {
        public IEnumerable<RedCrossModel> RedCross { get; private set; }

        public RcViewModel(IEnumerable<RedCrossModel> redCross)
        {
            RedCross = redCross;
        }
    }
}